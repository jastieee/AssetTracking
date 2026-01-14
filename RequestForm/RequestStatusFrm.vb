Imports MySql.Data.MySqlClient

Public Class RequestStatusFrm
    Private currentUserId As Integer
    Private currentEmployeeId As Integer
    Private requestType As String ' "Asset" or "Consumable"

    Public Sub New(userId As Integer, employeeId As Integer, reqType As String)
        InitializeComponent()
        currentUserId = userId
        currentEmployeeId = employeeId
        requestType = reqType
    End Sub

    Private Sub RequestStatusFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadMyRequests()
    End Sub

    Private Sub InitializeForm()
        ' Set form title
        If requestType = "Asset" Then
            lblTitle.Text = "📋 My Asset Requests"
        Else
            lblTitle.Text = "📋 My Consumable Requests"
        End If

        ' Setup DataGridView
        SetupDataGridView()

        ' Setup filter combo - Clear existing items first
        cmbStatusFilter.Items.Clear()
        cmbStatusFilter.Items.AddRange(New Object() {"All Requests", "Pending", "Approved", "Rejected", "Fulfilled", "Cancelled"})
        cmbStatusFilter.SelectedIndex = 0
    End Sub

    Private Sub SetupDataGridView()
        With dgvRequests
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False

            ' Style headers
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .ColumnHeadersHeight = 35

            ' Alternating row colors
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)
        End With
    End Sub

    Private Sub LoadMyRequests(Optional statusFilter As String = "All Requests")
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = ""

                If requestType = "Asset" Then
                    query = "SELECT 
                                ar.request_id AS 'Request ID',
                                ar.request_date AS 'Request Date',
                                CASE 
                                    WHEN ar.asset_id IS NOT NULL THEN CONCAT(a.asset_tag, ' - ', a.asset_name)
                                    ELSE CONCAT(ac.category_name, ' - New Item')
                                END AS 'Item Description',
                                ar.quantity AS 'Qty',
                                ar.priority AS 'Priority',
                                ar.status AS 'Status',
                                ar.reason AS 'Reason',
                                COALESCE(CONCAT(approver.first_name, ' ', approver.last_name), 'Pending') AS 'Approved By',
                                ar.approved_date AS 'Approval Date',
                                ar.rejection_reason AS 'Rejection Reason'
                            FROM asset_requests ar
                            LEFT JOIN assets a ON ar.asset_id = a.asset_id
                            LEFT JOIN asset_categories ac ON ar.category_id = ac.category_id
                            LEFT JOIN users approver ON ar.approved_by = approver.user_id
                            WHERE ar.requested_by = @userId"
                Else
                    query = "SELECT 
                                cr.request_id AS 'Request ID',
                                cr.request_date AS 'Request Date',
                                c.consumable_name AS 'Item Description',
                                cr.quantity_requested AS 'Qty',
                                cr.priority AS 'Priority',
                                cr.status AS 'Status',
                                cr.reason AS 'Reason',
                                COALESCE(CONCAT(approver.first_name, ' ', approver.last_name), 'Pending') AS 'Approved By',
                                cr.approved_date AS 'Approval Date',
                                cr.rejection_reason AS 'Rejection Reason'
                            FROM consumable_requests cr
                            LEFT JOIN consumables c ON cr.consumable_id = c.consumable_id
                            LEFT JOIN users approver ON cr.approved_by = approver.user_id
                            WHERE cr.requested_by = @userId"
                End If

                ' Add status filter if not "All Requests"
                If statusFilter <> "All Requests" Then
                    query &= " AND " & If(requestType = "Asset", "ar", "cr") & ".status = @status"
                End If

                query &= " ORDER BY " & If(requestType = "Asset", "ar", "cr") & ".request_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", currentUserId)
                    If statusFilter <> "All Requests" Then
                        cmd.Parameters.AddWithValue("@status", statusFilter)
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvRequests.DataSource = dt

                        ' Hide sensitive columns and format display
                        If dgvRequests.Columns.Count > 0 Then
                            dgvRequests.Columns("Request ID").Width = 80
                            dgvRequests.Columns("Request Date").Width = 150
                            dgvRequests.Columns("Request Date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                            dgvRequests.Columns("Qty").Width = 60
                            dgvRequests.Columns("Priority").Width = 80
                            dgvRequests.Columns("Status").Width = 100

                            ' Hide detailed columns by default
                            dgvRequests.Columns("Reason").Visible = False
                            dgvRequests.Columns("Approved By").Visible = False
                            dgvRequests.Columns("Approval Date").Visible = False
                            dgvRequests.Columns("Rejection Reason").Visible = False

                            ' Color code status
                            For Each row As DataGridViewRow In dgvRequests.Rows
                                Dim status As String = row.Cells("Status").Value.ToString()
                                Select Case status
                                    Case "Pending"
                                        row.Cells("Status").Style.BackColor = Color.FromArgb(255, 243, 205)
                                        row.Cells("Status").Style.ForeColor = Color.FromArgb(133, 100, 4)
                                    Case "Approved"
                                        row.Cells("Status").Style.BackColor = Color.FromArgb(212, 237, 218)
                                        row.Cells("Status").Style.ForeColor = Color.FromArgb(21, 87, 36)
                                    Case "Rejected"
                                        row.Cells("Status").Style.BackColor = Color.FromArgb(248, 215, 218)
                                        row.Cells("Status").Style.ForeColor = Color.FromArgb(114, 28, 36)
                                    Case "Fulfilled"
                                        row.Cells("Status").Style.BackColor = Color.FromArgb(209, 231, 221)
                                        row.Cells("Status").Style.ForeColor = Color.FromArgb(13, 110, 253)
                                    Case "Cancelled"
                                        row.Cells("Status").Style.BackColor = Color.LightGray
                                        row.Cells("Status").Style.ForeColor = Color.DarkGray
                                End Select
                            Next
                        End If

                        ' Update count label
                        lblRequestCount.Text = $"Total Requests: {dt.Rows.Count}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading requests: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatusFilter.SelectedIndexChanged
        LoadMyRequests(cmbStatusFilter.SelectedItem.ToString())
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadMyRequests(cmbStatusFilter.SelectedItem.ToString())
    End Sub

    Private Sub btnNewRequest_Click(sender As Object, e As EventArgs) Handles btnNewRequest.Click
        ' Open the request slip form
        Dim requestForm As New RequestSlipFrm(currentUserId, currentEmployeeId, requestType)
        requestForm.StartPosition = FormStartPosition.CenterParent

        Dim result As DialogResult = requestForm.ShowDialog(Me)

        ' Refresh the list if a request was submitted
        If result = DialogResult.OK Then
            LoadMyRequests(cmbStatusFilter.SelectedItem.ToString())
        End If
    End Sub

    Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        If dgvRequests.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to view details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row As DataGridViewRow = dgvRequests.SelectedRows(0)
        Dim details As String = ""

        details &= "REQUEST DETAILS" & vbCrLf & vbCrLf
        details &= $"Request ID: {row.Cells("Request ID").Value}" & vbCrLf
        details &= $"Date: {row.Cells("Request Date").Value}" & vbCrLf
        details &= $"Item: {row.Cells("Item Description").Value}" & vbCrLf
        details &= $"Quantity: {row.Cells("Qty").Value}" & vbCrLf
        details &= $"Priority: {row.Cells("Priority").Value}" & vbCrLf
        details &= $"Status: {row.Cells("Status").Value}" & vbCrLf & vbCrLf
        details &= $"Reason: {row.Cells("Reason").Value}" & vbCrLf & vbCrLf

        If Not IsDBNull(row.Cells("Approved By").Value) AndAlso row.Cells("Approved By").Value.ToString() <> "Pending" Then
            details &= $"Approved By: {row.Cells("Approved By").Value}" & vbCrLf
            If Not IsDBNull(row.Cells("Approval Date").Value) Then
                details &= $"Approval Date: {row.Cells("Approval Date").Value}" & vbCrLf
            End If
        End If

        If Not IsDBNull(row.Cells("Rejection Reason").Value) AndAlso Not String.IsNullOrWhiteSpace(row.Cells("Rejection Reason").Value.ToString()) Then
            details &= vbCrLf & $"Rejection Reason: {row.Cells("Rejection Reason").Value}" & vbCrLf
        End If

        MessageBox.Show(details, "Request Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnCancelRequest_Click(sender As Object, e As EventArgs) Handles btnCancelRequest.Click
        If dgvRequests.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to cancel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row As DataGridViewRow = dgvRequests.SelectedRows(0)
        Dim status As String = row.Cells("Status").Value.ToString()
        Dim requestId As Integer = Convert.ToInt32(row.Cells("Request ID").Value)

        ' Can only cancel pending requests
        If status <> "Pending" Then
            MessageBox.Show("Only pending requests can be cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel this request?",
                                                    "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    Dim tableName As String = If(requestType = "Asset", "asset_requests", "consumable_requests")
                    Dim query As String = $"UPDATE {tableName} SET status = 'Cancelled' WHERE request_id = @requestId"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@requestId", requestId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Request cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadMyRequests(cmbStatusFilter.SelectedItem.ToString())

            Catch ex As Exception
                MessageBox.Show($"Error cancelling request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class