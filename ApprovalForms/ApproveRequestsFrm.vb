Imports MySql.Data.MySqlClient

Public Class ApproveRequestsFrm
    Private currentUserId As Integer = gCurrentUserId

    Private Sub ApproveRequestsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadRequests()
    End Sub

    Private Sub InitializeForm()
        ' Initialize filters with default items
        cboStatusFilter.Items.Clear()
        cboStatusFilter.Items.AddRange({"Pending", "Approved", "Rejected", "Fulfilled", "All"})

        cboTypeFilter.Items.Clear()
        cboTypeFilter.Items.AddRange({"All Types", "Asset Request", "Consumable Request"})

        ' Set default selections
        cboStatusFilter.SelectedIndex = 0 ' Pending
        cboTypeFilter.SelectedIndex = 0 ' All Types

        ' Setup DataGridView
        SetupDataGridView()

        ' Initially disable action buttons
        EnableActionButtons(False)

        ' Show appropriate message based on role
        ShowRoleBasedMessage()
    End Sub

    Private Sub ShowRoleBasedMessage()
        Dim userRole As String = gCurrentUserRole.ToUpper()

        Select Case userRole
            Case "APPROVER"
                lblTitle.Text = "✅ Approve/Reject Requests"
                ' Managers see pending requests by default
                cboStatusFilter.SelectedIndex = 0 ' Pending

            Case "ADMIN"
                lblTitle.Text = "📦 Issue Approved Requests"
                ' Admins see approved requests by default
                If cboStatusFilter.Items.Contains("Approved") Then
                    cboStatusFilter.SelectedItem = "Approved"
                End If

            Case Else
                lblTitle.Text = "📋 View Requests"
                ' Others can only view
        End Select
    End Sub

    Private Sub SetupDataGridView()
        With dgvRequests
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .RowHeadersVisible = False

            ' Style
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .ColumnHeadersHeight = 40

            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
            .RowTemplate.Height = 35
        End With
    End Sub

    Private Sub LoadRequests(Optional statusFilter As String = "Pending", Optional typeFilter As String = "All Types")
        Try
            ' Validate filter parameters
            If String.IsNullOrEmpty(statusFilter) Then statusFilter = "Pending"
            If String.IsNullOrEmpty(typeFilter) Then typeFilter = "All Types"

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = BuildRequestQuery(statusFilter, typeFilter)

                Using adapter As New MySqlDataAdapter(query, conn)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvRequests.DataSource = dt

                    ' Format display
                    FormatDataGridView()

                    ' Update count
                    lblTotalRequests.Text = $"Total Requests: {dt.Rows.Count}"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function BuildRequestQuery(statusFilter As String, typeFilter As String) As String
        Dim baseQuery As String = ""

        ' Asset Requests
        If typeFilter = "All Types" OrElse typeFilter = "Asset Request" Then
            baseQuery = "SELECT 
                'Asset' AS request_type,
                ar.request_id,
                ar.request_date,
                CONCAT(u.first_name, ' ', u.last_name) AS requester_name,
                d.department_name,
                CASE 
                    WHEN ar.asset_id IS NOT NULL THEN CONCAT(a.asset_tag, ' - ', a.asset_name)
                    ELSE CONCAT('New: ', ac.category_name)
                END AS item_description,
                ar.quantity,
                ar.reason,
                ar.purpose,
                ar.priority,
                ar.status,
                ar.asset_id,
                NULL AS consumable_id,
                ar.approved_by,
                ar.approved_date,
                ar.rejection_reason
            FROM asset_requests ar
            INNER JOIN users u ON ar.requested_by = u.user_id
            LEFT JOIN departments d ON u.department_id = d.department_id
            LEFT JOIN assets a ON ar.asset_id = a.asset_id
            LEFT JOIN asset_categories ac ON ar.category_id = ac.category_id"
        End If

        ' Consumable Requests
        If typeFilter = "All Types" OrElse typeFilter = "Consumable Request" Then
            If baseQuery <> "" Then baseQuery &= " UNION ALL "

            baseQuery &= "SELECT 
                'Consumable' AS request_type,
                cr.request_id,
                cr.request_date,
                CONCAT(u.first_name, ' ', u.last_name) AS requester_name,
                d.department_name,
                c.consumable_name AS item_description,
                cr.quantity_requested AS quantity,
                cr.reason,
                cr.purpose,
                cr.priority,
                cr.status,
                NULL AS asset_id,
                cr.consumable_id,
                cr.approved_by,
                cr.approved_date,
                cr.rejection_reason
            FROM consumable_requests cr
            INNER JOIN users u ON cr.requested_by = u.user_id
            LEFT JOIN departments d ON u.department_id = d.department_id
            INNER JOIN consumables c ON cr.consumable_id = c.consumable_id"
        End If

        ' Add status filter
        If baseQuery <> "" Then
            If statusFilter <> "All" Then
                baseQuery = $"SELECT * FROM ({baseQuery}) AS requests WHERE status = '{statusFilter}'"
            Else
                baseQuery = $"SELECT * FROM ({baseQuery}) AS requests"
            End If

            baseQuery &= " ORDER BY request_date DESC"
        End If

        Return baseQuery
    End Function

    Private Function GetSelectedStatus() As String
        If cboStatusFilter.SelectedItem IsNot Nothing Then
            Return cboStatusFilter.SelectedItem.ToString()
        End If
        Return "Pending"
    End Function

    Private Function GetSelectedType() As String
        If cboTypeFilter.SelectedItem IsNot Nothing Then
            Return cboTypeFilter.SelectedItem.ToString()
        End If
        Return "All Types"
    End Function

    Private Sub FormatDataGridView()
        If dgvRequests.Columns.Count = 0 Then Return

        ' Hide internal/detailed columns - they'll show in the right panel
        If dgvRequests.Columns.Contains("asset_id") Then dgvRequests.Columns("asset_id").Visible = False
        If dgvRequests.Columns.Contains("consumable_id") Then dgvRequests.Columns("consumable_id").Visible = False
        If dgvRequests.Columns.Contains("approved_by") Then dgvRequests.Columns("approved_by").Visible = False
        If dgvRequests.Columns.Contains("approved_date") Then dgvRequests.Columns("approved_date").Visible = False
        If dgvRequests.Columns.Contains("rejection_reason") Then dgvRequests.Columns("rejection_reason").Visible = False

        ' ADD THESE NEW LINES TO HIDE MORE COLUMNS:
        If dgvRequests.Columns.Contains("reason") Then dgvRequests.Columns("reason").Visible = False
        If dgvRequests.Columns.Contains("purpose") Then dgvRequests.Columns("purpose").Visible = False
        If dgvRequests.Columns.Contains("priority") Then dgvRequests.Columns("priority").Visible = False

        ' Set column headers for VISIBLE columns only
        If dgvRequests.Columns.Contains("request_type") Then dgvRequests.Columns("request_type").HeaderText = "Type"
        If dgvRequests.Columns.Contains("request_id") Then dgvRequests.Columns("request_id").HeaderText = "Request ID"
        If dgvRequests.Columns.Contains("request_date") Then dgvRequests.Columns("request_date").HeaderText = "Date"
        If dgvRequests.Columns.Contains("requester_name") Then dgvRequests.Columns("requester_name").HeaderText = "Requester"
        If dgvRequests.Columns.Contains("department_name") Then dgvRequests.Columns("department_name").HeaderText = "Department"
        If dgvRequests.Columns.Contains("item_description") Then dgvRequests.Columns("item_description").HeaderText = "Item"
        If dgvRequests.Columns.Contains("quantity") Then dgvRequests.Columns("quantity").HeaderText = "Qty"
        If dgvRequests.Columns.Contains("status") Then dgvRequests.Columns("status").HeaderText = "Status"

        ' REMOVE THESE WIDTH SETTINGS since columns are now hidden:
        ' dgvRequests.Columns("priority").Width = 80

        ' Set column widths for visible columns only
        dgvRequests.Columns("request_type").Width = 80
        dgvRequests.Columns("request_id").Width = 30
        dgvRequests.Columns("request_date").Width = 120
        dgvRequests.Columns("requester_name").Width = 150
        dgvRequests.Columns("department_name").Width = 100
        dgvRequests.Columns("quantity").Width = 30
        dgvRequests.Columns("status").Width = 70

        ' Color code status
        For Each row As DataGridViewRow In dgvRequests.Rows
            If row.Cells("status").Value IsNot Nothing Then
                Dim status As String = row.Cells("status").Value.ToString()
                Select Case status
                    Case "Pending"
                        row.Cells("status").Style.BackColor = Color.FromArgb(255, 243, 205)
                        row.Cells("status").Style.ForeColor = Color.FromArgb(133, 100, 4)
                    Case "Approved"
                        row.Cells("status").Style.BackColor = Color.FromArgb(212, 237, 218)
                        row.Cells("status").Style.ForeColor = Color.FromArgb(21, 87, 36)
                    Case "Rejected"
                        row.Cells("status").Style.BackColor = Color.FromArgb(248, 215, 218)
                        row.Cells("status").Style.ForeColor = Color.FromArgb(114, 28, 36)
                    Case "Fulfilled"
                        row.Cells("status").Style.BackColor = Color.FromArgb(209, 231, 221)
                        row.Cells("status").Style.ForeColor = Color.FromArgb(13, 110, 253)
                End Select
            End If

            ' Priority color
            If row.Cells("priority").Value IsNot Nothing Then
                Dim priority As String = row.Cells("priority").Value.ToString()
                Select Case priority
                    Case "Urgent"
                        row.Cells("priority").Style.BackColor = Color.FromArgb(231, 76, 60)
                        row.Cells("priority").Style.ForeColor = Color.White
                    Case "High"
                        row.Cells("priority").Style.BackColor = Color.FromArgb(243, 156, 18)
                        row.Cells("priority").Style.ForeColor = Color.White
                End Select
            End If
        Next
    End Sub

    Private Sub dgvRequests_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRequests.SelectionChanged
        If dgvRequests.SelectedRows.Count > 0 Then
            LoadRequestDetails()
            UpdateActionButtons()
        Else
            ClearRequestDetails()
            EnableActionButtons(False)
        End If
    End Sub

    Private Sub LoadRequestDetails()
        If dgvRequests.SelectedRows.Count = 0 Then Return

        Dim row As DataGridViewRow = dgvRequests.SelectedRows(0)

        ' Display basic info
        lblRequestId.Text = $"Request ID: {row.Cells("request_id").Value}"
        lblRequestType.Text = $"Type: {row.Cells("request_type").Value}"
        lblRequester.Text = $"Requester: {row.Cells("requester_name").Value}"
        lblItem.Text = $"Item: {row.Cells("item_description").Value}"
        lblQuantity.Text = $"Quantity: {row.Cells("quantity").Value}"
        lblReason.Text = $"Reason: {row.Cells("reason").Value}"

        Dim purpose As String = If(IsDBNull(row.Cells("purpose").Value), "N/A", row.Cells("purpose").Value.ToString())
        lblPurpose.Text = $"Purpose: {purpose}"

        ' Show/hide rejection reason
        Dim status As String = row.Cells("status").Value.ToString()
        If status = "Rejected" AndAlso Not IsDBNull(row.Cells("rejection_reason").Value) Then
            lblRejectionReason.Visible = True
            txtRejectionReason.Visible = True
            txtRejectionReason.Text = row.Cells("rejection_reason").Value.ToString()
            txtRejectionReason.ReadOnly = True
        Else
            lblRejectionReason.Visible = False
            txtRejectionReason.Visible = False
        End If
    End Sub

    Private Sub ClearRequestDetails()
        lblRequestId.Text = "Request ID:"
        lblRequestType.Text = "Type:"
        lblRequester.Text = "Requester:"
        lblItem.Text = "Item:"
        lblQuantity.Text = "Quantity:"
        lblReason.Text = "Reason:"
        lblPurpose.Text = "Purpose:"
        txtApprovalNotes.Clear()
        lblRejectionReason.Visible = False
        txtRejectionReason.Visible = False
    End Sub

    Private Sub UpdateActionButtons()
        If dgvRequests.SelectedRows.Count = 0 Then
            EnableActionButtons(False)
            Return
        End If

        Dim status As String = dgvRequests.SelectedRows(0).Cells("status").Value.ToString()
        Dim userRole As String = gCurrentUserRole.ToUpper()

        Select Case status
            Case "Pending"
                ' Only Approvers/Managers can approve/reject pending requests
                If userRole = "APPROVER" Then
                    btnApprove.Enabled = True
                    btnReject.Enabled = True
                    btnIssue.Enabled = False
                ElseIf userRole = "ADMIN" Then
                    ' Admin cannot approve/reject, only issue after approval
                    btnApprove.Enabled = False
                    btnReject.Enabled = False
                    btnIssue.Enabled = False
                Else
                    EnableActionButtons(False)
                End If

            Case "Approved"
                ' Only Admins can issue approved requests
                If userRole = "ADMIN" Then
                    btnApprove.Enabled = False
                    btnReject.Enabled = False
                    btnIssue.Enabled = True
                Else
                    ' Managers/Approvers cannot issue
                    EnableActionButtons(False)
                End If

            Case Else
                ' No actions for Rejected/Fulfilled
                EnableActionButtons(False)
        End Select
    End Sub

    Private Sub EnableActionButtons(enable As Boolean)
        btnApprove.Enabled = enable
        btnReject.Enabled = enable
        btnIssue.Enabled = enable
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If dgvRequests.SelectedRows.Count = 0 Then Return

        ' Check if user has permission to approve
        Dim userRole As String = gCurrentUserRole.ToUpper()
        If userRole <> "APPROVER" Then
            MessageBox.Show("Only Managers/Approvers can approve requests.", "Access Denied",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = dgvRequests.SelectedRows(0)
        Dim requestType As String = row.Cells("request_type").Value.ToString()
        Dim requestId As Integer = Convert.ToInt32(row.Cells("request_id").Value)

        Dim result = MessageBox.Show("Approve this request?", "Confirm Approval",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            If ApproveRequest(requestType, requestId, txtApprovalNotes.Text) Then
                MessageBox.Show("Request approved successfully!" & vbCrLf & vbCrLf &
                              "Admin can now issue this request.", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadRequests(GetSelectedStatus(), GetSelectedType())
            End If
        End If
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If dgvRequests.SelectedRows.Count = 0 Then Return

        ' Check if user has permission to reject
        Dim userRole As String = gCurrentUserRole.ToUpper()
        If userRole <> "APPROVER" Then
            MessageBox.Show("Only Managers/Approvers can reject requests.", "Access Denied",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = dgvRequests.SelectedRows(0)
        Dim requestType As String = row.Cells("request_type").Value.ToString()
        Dim requestId As Integer = Convert.ToInt32(row.Cells("request_id").Value)

        ' Ask for rejection reason
        Dim reason As String = InputBox("Please provide a reason for rejection:", "Reject Request", "")

        If String.IsNullOrWhiteSpace(reason) Then
            MessageBox.Show("Rejection reason is required.", "Validation",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If RejectRequest(requestType, requestId, reason) Then
            MessageBox.Show("Request rejected.", "Success",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadRequests(GetSelectedStatus(), GetSelectedType())
        End If
    End Sub

    Private Sub btnIssue_Click(sender As Object, e As EventArgs) Handles btnIssue.Click
        If dgvRequests.SelectedRows.Count = 0 Then Return

        ' Check if user has permission to issue
        Dim userRole As String = gCurrentUserRole.ToUpper()
        If userRole <> "ADMIN" Then
            MessageBox.Show("Only Admins can issue requests.", "Access Denied",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = dgvRequests.SelectedRows(0)
        Dim requestType As String = row.Cells("request_type").Value.ToString()
        Dim requestId As Integer = Convert.ToInt32(row.Cells("request_id").Value)

        ' Get employee details for the requester
        Dim employeeInfo = GetEmployeeInfoFromRequest(requestType, requestId)
        If employeeInfo Is Nothing Then
            MessageBox.Show("Could not retrieve employee information for this request.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open appropriate issuance form
        If requestType = "Asset" Then
            OpenAssetIssuanceForm(requestId, employeeInfo)
        Else
            OpenConsumableIssuanceForm(requestId, employeeInfo)
        End If
    End Sub

    Private Function GetEmployeeInfoFromRequest(requestType As String, requestId As Integer) As RequestEmployeeInfo
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = ""

                If requestType = "Asset" Then
                    query = "SELECT ar.asset_id, ar.requested_by, ar.quantity, ar.purpose,
                                   CONCAT(u.first_name, ' ', u.last_name) AS employee_name,
                                   e.employee_id, u.department_id
                            FROM asset_requests ar
                            INNER JOIN users u ON ar.requested_by = u.user_id
                            INNER JOIN employees e ON u.user_id = e.user_id
                            WHERE ar.request_id = @requestId"
                Else
                    query = "SELECT cr.consumable_id, cr.requested_by, cr.quantity_requested AS quantity,
                                   cr.purpose, CONCAT(u.first_name, ' ', u.last_name) AS employee_name,
                                   e.employee_id, cr.department_id
                            FROM consumable_requests cr
                            INNER JOIN users u ON cr.requested_by = u.user_id
                            INNER JOIN employees e ON u.user_id = e.user_id
                            WHERE cr.request_id = @requestId"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@requestId", requestId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New RequestEmployeeInfo With {
                                .EmployeeId = Convert.ToInt32(reader("employee_id")),
                                .EmployeeName = reader("employee_name").ToString(),
                                .DepartmentId = Convert.ToInt32(reader("department_id")),
                                .ItemId = If(requestType = "Asset",
                                           Convert.ToInt32(reader("asset_id")),
                                           Convert.ToInt32(reader("consumable_id"))),
                                .Quantity = Convert.ToInt32(reader("quantity")),
                                .Purpose = If(IsDBNull(reader("purpose")), "", reader("purpose").ToString())
                            }
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving employee info: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
    End Function

    Private Sub OpenAssetIssuanceForm(requestId As Integer, empInfo As RequestEmployeeInfo)
        ' Create a modified IssueAssetFrm that will update the request status after successful issuance
        Dim issueForm As New IssueAssetFrm(empInfo.EmployeeId, empInfo.EmployeeName)

        ' Pre-select the asset if it exists
        If empInfo.ItemId > 0 Then
            ' Access the asset combo box and set its value
            Dim assetCombo = issueForm.Controls.Find("cboAsset", True).FirstOrDefault()
            If assetCombo IsNot Nothing AndAlso TypeOf assetCombo Is ComboBox Then
                Dim combo As ComboBox = DirectCast(assetCombo, ComboBox)
                ' Set the selected value to the asset_id
                combo.SelectedValue = empInfo.ItemId
            End If
        End If

        ' Pre-fill notes with request purpose
        If Not String.IsNullOrWhiteSpace(empInfo.Purpose) Then
            Dim notesControl = issueForm.Controls.Find("txtNotes", True).FirstOrDefault()
            If notesControl IsNot Nothing AndAlso TypeOf notesControl Is TextBox Then
                DirectCast(notesControl, TextBox).Text = $"From Request #{requestId}: {empInfo.Purpose}"
            End If
        End If

        If issueForm.ShowDialog() = DialogResult.OK Then
            ' Update request status to Fulfilled
            UpdateRequestStatusToFulfilled("Asset", requestId)
            MessageBox.Show("Request has been marked as fulfilled!", "Success",
                      MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadRequests(GetSelectedStatus(), GetSelectedType())
        End If
    End Sub

    Private Sub OpenConsumableIssuanceForm(requestId As Integer, empInfo As RequestEmployeeInfo)
        ' Create IssueConsumableFrm
        Dim issueForm As New IssueConsumableFrm(empInfo.EmployeeId, empInfo.EmployeeName, empInfo.DepartmentId)

        ' Pre-fill purpose with request info
        If Not String.IsNullOrWhiteSpace(empInfo.Purpose) Then
            Dim purposeControl = issueForm.Controls.Find("txtPurpose", True).FirstOrDefault()
            If purposeControl IsNot Nothing AndAlso TypeOf purposeControl Is TextBox Then
                DirectCast(purposeControl, TextBox).Text = $"From Request #{requestId}: {empInfo.Purpose}"
            End If
        End If

        If issueForm.ShowDialog() = DialogResult.OK Then
            ' Update request status to Fulfilled
            UpdateRequestStatusToFulfilled("Consumable", requestId)
            MessageBox.Show("Request has been marked as fulfilled!", "Success",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadRequests(GetSelectedStatus(), GetSelectedType())
        End If
    End Sub

    Private Function UpdateRequestStatusToFulfilled(requestType As String, requestId As Integer) As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim tableName As String = If(requestType = "Asset", "asset_requests", "consumable_requests")

                Dim query As String = $"UPDATE {tableName} 
                                       SET status = 'Fulfilled', 
                                           fulfillment_date = NOW(),
                                           issued_by = @issuedBy
                                       WHERE request_id = @requestId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@issuedBy", currentUserId)
                    cmd.Parameters.AddWithValue("@requestId", requestId)
                    cmd.ExecuteNonQuery()
                End Using

                ' Log activity
                LogActivity($"{requestType} Request Fulfilled", tableName, requestId,
                          $"Request ID {requestId} marked as fulfilled")

                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error updating request status: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function ApproveRequest(requestType As String, requestId As Integer, notes As String) As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim tableName As String = If(requestType = "Asset", "asset_requests", "consumable_requests")

                Dim query As String = $"UPDATE {tableName} 
                                       SET status = 'Approved', 
                                           approved_by = @approvedBy, 
                                           approved_date = NOW(),
                                           notes = @notes
                                       WHERE request_id = @requestId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@approvedBy", currentUserId)
                    cmd.Parameters.AddWithValue("@notes", If(String.IsNullOrWhiteSpace(notes), DBNull.Value, CType(notes, Object)))
                    cmd.Parameters.AddWithValue("@requestId", requestId)
                    cmd.ExecuteNonQuery()
                End Using

                ' Log activity
                LogActivity($"{requestType} Request Approved", tableName, requestId,
                          $"Request ID {requestId} approved")

                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error approving request: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function RejectRequest(requestType As String, requestId As Integer, reason As String) As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim tableName As String = If(requestType = "Asset", "asset_requests", "consumable_requests")

                Dim query As String = $"UPDATE {tableName} 
                                       SET status = 'Rejected', 
                                           approved_by = @approvedBy, 
                                           approved_date = NOW(),
                                           rejection_reason = @reason
                                       WHERE request_id = @requestId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@approvedBy", currentUserId)
                    cmd.Parameters.AddWithValue("@reason", reason)
                    cmd.Parameters.AddWithValue("@requestId", requestId)
                    cmd.ExecuteNonQuery()
                End Using

                ' Log activity
                LogActivity($"{requestType} Request Rejected", tableName, requestId,
                          $"Request ID {requestId} rejected: {reason}")

                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error rejecting request: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    'Private Function IssueRequest(requestType As String, requestId As Integer) As Boolean
    '    Try
    '        Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
    '            Using transaction As MySqlTransaction = conn.BeginTransaction()
    '                Try
    '                    If requestType = "Asset" Then
    '                        IssueAssetRequest(conn, transaction, requestId)
    '                    Else
    '                        IssueConsumableRequest(conn, transaction, requestId)
    '                    End If

    '                    transaction.Commit()
    '                    Return True
    '                Catch ex As Exception
    '                    transaction.Rollback()
    '                    Throw ex
    '                End Try
    '            End Using
    '        End Using
    '    Catch ex As Exception
    '        MessageBox.Show($"Error issuing request: {ex.Message}", "Error",
    '                      MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return False
    '    End Try
    'End Function

    'Private Sub IssueAssetRequest(conn As MySqlConnection, transaction As MySqlTransaction, requestId As Integer)
    '    ' Get request details
    '    Dim query As String = "SELECT ar.asset_id, ar.requested_by, ar.quantity, ar.purpose, u.user_id AS requester_user_id,
    '                                 e.employee_id
    '                          FROM asset_requests ar
    '                          INNER JOIN users u ON ar.requested_by = u.user_id
    '                          INNER JOIN employees e ON u.user_id = e.user_id
    '                          WHERE ar.request_id = @requestId"

    '    Dim assetId, requestedBy, quantity, employeeId As Integer
    '    Dim purpose As String = ""

    '    Using cmd As New MySqlCommand(query, conn, transaction)
    '        cmd.Parameters.AddWithValue("@requestId", requestId)
    '        Using reader As MySqlDataReader = cmd.ExecuteReader()
    '            If reader.Read() Then
    '                assetId = Convert.ToInt32(reader("asset_id"))
    '                requestedBy = Convert.ToInt32(reader("requester_user_id"))
    '                quantity = Convert.ToInt32(reader("quantity"))
    '                employeeId = Convert.ToInt32(reader("employee_id"))
    '                purpose = If(IsDBNull(reader("purpose")), "", reader("purpose").ToString())
    '            End If
    '        End Using
    '    End Using

    '    ' Create asset issuance
    '    query = "INSERT INTO asset_issuance (asset_id, employee_id, issued_by, issue_notes, status)
    '            VALUES (@assetId, @employeeId, @issuedBy, @notes, 'Active')"

    '    Using cmd As New MySqlCommand(query, conn, transaction)
    '        cmd.Parameters.AddWithValue("@assetId", assetId)
    '        cmd.Parameters.AddWithValue("@employeeId", employeeId)
    '        cmd.Parameters.AddWithValue("@issuedBy", currentUserId)
    '        cmd.Parameters.AddWithValue("@notes", purpose)
    '        cmd.ExecuteNonQuery()
    '    End Using

    '    ' Update asset status
    '    query = "UPDATE assets SET status = 'Issued' WHERE asset_id = @assetId"
    '    Using cmd As New MySqlCommand(query, conn, transaction)
    '        cmd.Parameters.AddWithValue("@assetId", assetId)
    '        cmd.ExecuteNonQuery()
    '    End Using

    '    ' Update request status
    '    query = "UPDATE asset_requests 
    '            SET status = 'Fulfilled', 
    '                fulfillment_date = NOW(),
    '                issued_by = @issuedBy
    '            WHERE request_id = @requestId"

    '    Using cmd As New MySqlCommand(query, conn, transaction)
    '        cmd.Parameters.AddWithValue("@issuedBy", currentUserId)
    '        cmd.Parameters.AddWithValue("@requestId", requestId)
    '        cmd.ExecuteNonQuery()
    '    End Using

    '    ' Log activity
    '    LogActivity("Asset Issued from Request", "asset_issuance", requestId,
    '               $"Asset issued for request ID {requestId}")
    'End Sub

    'Private Sub IssueConsumableRequest(conn As MySqlConnection, transaction As MySqlTransaction, requestId As Integer)
    '    ' Get request details
    '    Dim query As String = "SELECT cr.consumable_id, cr.department_id, cr.requested_by, 
    '                                 cr.quantity_requested, cr.purpose, u.user_id AS requester_user_id,
    '                                 e.employee_id
    '                          FROM consumable_requests cr
    '                          INNER JOIN users u ON cr.requested_by = u.user_id
    '                          INNER JOIN employees e ON u.user_id = e.user_id
    '                          WHERE cr.request_id = @requestId"

    '    Dim consumableId, departmentId, requestedBy, quantity, employeeId As Integer
    '    Dim purpose As String = ""

    '    Using cmd As New MySqlCommand(query, conn, transaction)
    '        cmd.Parameters.AddWithValue("@requestId", requestId)
    '        Using reader As MySqlDataReader = cmd.ExecuteReader()
    '            If reader.Read() Then
    '                consumableId = Convert.ToInt32(reader("consumable_id"))
    '                departmentId = Convert.ToInt32(reader("department_id"))
    '                requestedBy = Convert.ToInt32(reader("requester_user_id"))
    '                quantity = Convert.ToInt32(reader("quantity_requested"))
    '                employeeId = Convert.ToInt32(reader("employee_id"))
    '                purpose = If(IsDBNull(reader("purpose")), "", reader("purpose").ToString())
    '            End If
    '        End Using
    '    End Using

    '    ' Check stock availability
    '    query = "SELECT total_quantity_in_stock FROM consumables WHERE consumable_id = @consumableId"
    '    Dim currentStock As Integer = 0
    '    Using cmd As New MySqlCommand(query, conn, transaction)
    '        cmd.Parameters.AddWithValue("@consumableId", consumableId)
    '        currentStock = Convert.ToInt32(cmd.ExecuteScalar())
    '    End Using

    '    If currentStock < quantity Then
    '        Throw New Exception("Insufficient stock to fulfill request.")
    '    End If

    '    ' Create consumable issuance
    '    query = "INSERT INTO consumable_issuance (consumable_id, employee_id, department_id, 
    '                                              quantity_issued, issued_by, purpose)
    '            VALUES (@consumableId, @employeeId, @departmentId, @quantity, @issuedBy, @purpose)"

    '    Using cmd As New MySqlCommand(query, conn, transaction)
    '        cmd.Parameters.AddWithValue("@consumableId", consumableId)
    '        cmd.Parameters.AddWithValue("@employeeId", employeeId)
    '        cmd.Parameters.AddWithValue("@departmentId", departmentId)
    '        cmd.Parameters.AddWithValue("@quantity", quantity)
    '        cmd.Parameters.AddWithValue("@issuedBy", currentUserId)
    '        cmd.Parameters.AddWithValue("@purpose", purpose)
    '        cmd.ExecuteNonQuery()
    '    End Using

    '    ' Update stock
    '    query = "UPDATE consumables 
    '            SET total_quantity_in_stock = total_quantity_in_stock - @quantity
    '            WHERE consumable_id = @consumableId"

    '    Using cmd As New MySqlCommand(query, conn, transaction)
    '        cmd.Parameters.AddWithValue("@quantity", quantity)
    '        cmd.Parameters.AddWithValue("@consumableId", consumableId)
    '        cmd.ExecuteNonQuery()
    '    End Using

    '    ' Update request status
    '    query = "UPDATE consumable_requests 
    '            SET status = 'Fulfilled', 
    '                fulfillment_date = NOW(),
    '                issued_by = @issuedBy
    '            WHERE request_id = @requestId"

    '    Using cmd As New MySqlCommand(query, conn, transaction)
    '        cmd.Parameters.AddWithValue("@issuedBy", currentUserId)
    '        cmd.Parameters.AddWithValue("@requestId", requestId)
    '        cmd.ExecuteNonQuery()
    '    End Using

    '    ' Log activity
    '    LogActivity("Consumable Issued from Request", "consumable_issuance", requestId,
    '               $"Consumable issued for request ID {requestId}")
    'End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        If cboStatusFilter.SelectedItem IsNot Nothing AndAlso cboTypeFilter.SelectedItem IsNot Nothing Then
            LoadRequests(GetSelectedStatus(), GetSelectedType())
        End If
    End Sub

    Private Sub cboTypeFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTypeFilter.SelectedIndexChanged
        If cboStatusFilter.SelectedItem IsNot Nothing AndAlso cboTypeFilter.SelectedItem IsNot Nothing Then
            LoadRequests(GetSelectedStatus(), GetSelectedType())
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadRequests(GetSelectedStatus(), GetSelectedType())
    End Sub

    Private Sub LogActivity(actionType As String, tableName As String, recordId As Integer, description As String)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description, ip_address)
                                      VALUES (@userId, @actionType, @tableName, @recordId, @description, @ipAddress)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", currentUserId)
                    cmd.Parameters.AddWithValue("@actionType", actionType)
                    cmd.Parameters.AddWithValue("@tableName", tableName)
                    cmd.Parameters.AddWithValue("@recordId", recordId)
                    cmd.Parameters.AddWithValue("@description", description)
                    cmd.Parameters.AddWithValue("@ipAddress", GetLocalIPAddress())
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error logging activity: " & ex.Message)
        End Try
    End Sub

    Private Function GetLocalIPAddress() As String
        Try
            Dim host As String = System.Net.Dns.GetHostName()
            Dim ip = System.Net.Dns.GetHostEntry(host).AddressList.FirstOrDefault(Function(x) x.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)
            Return If(ip IsNot Nothing, ip.ToString(), "Unknown")
        Catch
            Return "Unknown"
        End Try
    End Function
End Class

' Helper class to store employee info from request
Public Class RequestEmployeeInfo
    Public Property EmployeeId As Integer
    Public Property EmployeeName As String
    Public Property DepartmentId As Integer
    Public Property ItemId As Integer
    Public Property Quantity As Integer
    Public Property Purpose As String
End Class