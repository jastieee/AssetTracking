Imports MySql.Data.MySqlClient

Public Class RequestHistoryFrm
    Private currentUserId As Integer = gCurrentUserId

    Private Sub RequestHistoryFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadRequestHistory()
    End Sub

    Private Sub InitializeForm()
        ' Initialize status filter
        cmbStatusFilter.Items.Clear()
        cmbStatusFilter.Items.AddRange({"All Status", "Pending", "Approved", "Rejected", "Fulfilled", "Cancelled"})
        cmbStatusFilter.SelectedIndex = 0

        ' Initialize type filter
        cmbTypeFilter.Items.Clear()
        cmbTypeFilter.Items.AddRange({"All Types", "Asset Request", "Consumable Request"})
        cmbTypeFilter.SelectedIndex = 0

        ' Setup DataGridView styling
        SetupDataGridView()

        ' Initially disable action buttons
        btnViewDetails.Enabled = False
    End Sub

    Private Sub SetupDataGridView()
        With dgvRequests
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ' Changed back to Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .RowHeadersVisible = False

            ' Enable text wrapping and auto row height
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            ' Style
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnHeadersHeight = 40

            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
            .DefaultCellStyle.Padding = New Padding(5, 5, 5, 5) ' Add padding for better readability
        End With
    End Sub

    Private Sub LoadRequestHistory(Optional statusFilter As String = "All Status", Optional typeFilter As String = "All Types")
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = BuildHistoryQuery(statusFilter, typeFilter)

                Using adapter As New MySqlDataAdapter(query, conn)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvRequests.DataSource = dt

                    ' Format display
                    FormatDataGridView()

                    ' Update count
                    lblRequestCount.Text = $"Total Requests: {dt.Rows.Count}"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading request history: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function BuildHistoryQuery(statusFilter As String, typeFilter As String) As String
        Dim baseQuery As String = ""

        ' Asset Requests Query
        If typeFilter = "All Types" OrElse typeFilter = "Asset Request" Then
            baseQuery = "SELECT 
                'Asset' AS request_type,
                ar.request_id,
                ar.request_date,
                CONCAT(u.first_name, ' ', u.last_name) AS requester_name,
                d.department_name AS requester_department,
                CASE 
                    WHEN ar.asset_id IS NOT NULL THEN CONCAT(a.asset_tag, ' - ', a.asset_name)
                    ELSE CONCAT('New: ', ac.category_name, ' - ', COALESCE(sub.subcategory_name, 'General'))
                END AS item_description,
                ar.quantity,
                ar.reason,
                ar.purpose,
                ar.priority,
                ar.status,
                ar.approved_date,
                CONCAT(approver.first_name, ' ', approver.last_name) AS approved_by_name,
                ar.rejection_reason,
                ar.fulfillment_date,
                CONCAT(issuer.first_name, ' ', issuer.last_name) AS issued_by_name,
                ar.notes,
                ar.asset_id,
                NULL AS consumable_id,
                ar.approved_by,
                ar.issued_by
            FROM asset_requests ar
            INNER JOIN users u ON ar.requested_by = u.user_id
            LEFT JOIN departments d ON u.department_id = d.department_id
            LEFT JOIN assets a ON ar.asset_id = a.asset_id
            LEFT JOIN asset_categories ac ON ar.category_id = ac.category_id
            LEFT JOIN asset_subcategories sub ON ar.subcategory_id = sub.subcategory_id
            LEFT JOIN users approver ON ar.approved_by = approver.user_id
            LEFT JOIN users issuer ON ar.issued_by = issuer.user_id"
        End If

        ' Consumable Requests Query
        If typeFilter = "All Types" OrElse typeFilter = "Consumable Request" Then
            If baseQuery <> "" Then baseQuery &= " UNION ALL "

            baseQuery &= "SELECT 
                'Consumable' AS request_type,
                cr.request_id,
                cr.request_date,
                CONCAT(u.first_name, ' ', u.last_name) AS requester_name,
                d.department_name AS requester_department,
                c.consumable_name AS item_description,
                cr.quantity_requested AS quantity,
                cr.reason,
                cr.purpose,
                cr.priority,
                cr.status,
                cr.approved_date,
                CONCAT(approver.first_name, ' ', approver.last_name) AS approved_by_name,
                cr.rejection_reason,
                cr.fulfillment_date,
                CONCAT(issuer.first_name, ' ', issuer.last_name) AS issued_by_name,
                cr.notes,
                NULL AS asset_id,
                cr.consumable_id,
                cr.approved_by,
                cr.issued_by
            FROM consumable_requests cr
            INNER JOIN users u ON cr.requested_by = u.user_id
            LEFT JOIN departments d ON u.department_id = d.department_id
            INNER JOIN consumables c ON cr.consumable_id = c.consumable_id
            LEFT JOIN users approver ON cr.approved_by = approver.user_id
            LEFT JOIN users issuer ON cr.issued_by = issuer.user_id"
        End If

        ' Add status filter
        If baseQuery <> "" Then
            If statusFilter <> "All Status" Then
                baseQuery = $"SELECT * FROM ({baseQuery}) AS requests WHERE status = '{statusFilter}'"
            Else
                baseQuery = $"SELECT * FROM ({baseQuery}) AS requests"
            End If

            baseQuery &= " ORDER BY request_date DESC"
        End If

        Return baseQuery
    End Function

    Private Sub FormatDataGridView()
        If dgvRequests.Columns.Count = 0 Then Return

        ' Hide internal columns
        If dgvRequests.Columns.Contains("asset_id") Then dgvRequests.Columns("asset_id").Visible = False
        If dgvRequests.Columns.Contains("consumable_id") Then dgvRequests.Columns("consumable_id").Visible = False
        If dgvRequests.Columns.Contains("approved_by") Then dgvRequests.Columns("approved_by").Visible = False
        If dgvRequests.Columns.Contains("issued_by") Then dgvRequests.Columns("issued_by").Visible = False
        If dgvRequests.Columns.Contains("purpose") Then dgvRequests.Columns("purpose").Visible = False
        If dgvRequests.Columns.Contains("notes") Then dgvRequests.Columns("notes").Visible = False
        If dgvRequests.Columns.Contains("rejection_reason") Then dgvRequests.Columns("rejection_reason").Visible = False
        If dgvRequests.Columns.Contains("approved_date") Then dgvRequests.Columns("approved_date").Visible = False
        If dgvRequests.Columns.Contains("fulfillment_date") Then dgvRequests.Columns("fulfillment_date").Visible = False

        ' Set column headers and properties
        If dgvRequests.Columns.Contains("request_type") Then
            With dgvRequests.Columns("request_type")
                .HeaderText = "Type"
                .FillWeight = 5
                .MinimumWidth = 50
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End If

        If dgvRequests.Columns.Contains("request_id") Then
            With dgvRequests.Columns("request_id")
                .HeaderText = "ID"
                .FillWeight = 4
                .MinimumWidth = 40
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End If

        If dgvRequests.Columns.Contains("request_date") Then
            With dgvRequests.Columns("request_date")
                .HeaderText = "Date"
                .FillWeight = 12
                .MinimumWidth = 90
                .DefaultCellStyle.Format = "MM/dd/yyyy h:mm tt"
            End With
        End If

        If dgvRequests.Columns.Contains("requester_name") Then
            With dgvRequests.Columns("requester_name")
                .HeaderText = "Requester"
                .FillWeight = 10
                .MinimumWidth = 90
            End With
        End If

        If dgvRequests.Columns.Contains("requester_department") Then
            With dgvRequests.Columns("requester_department")
                .HeaderText = "Dept"
                .FillWeight = 8
                .MinimumWidth = 70
            End With
        End If

        If dgvRequests.Columns.Contains("item_description") Then
            With dgvRequests.Columns("item_description")
                .HeaderText = "Item"
                .FillWeight = 18
                .MinimumWidth = 120
            End With
        End If

        If dgvRequests.Columns.Contains("quantity") Then
            With dgvRequests.Columns("quantity")
                .HeaderText = "Qty"
                .FillWeight = 4
                .MinimumWidth = 40
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End If

        If dgvRequests.Columns.Contains("reason") Then
            With dgvRequests.Columns("reason")
                .HeaderText = "Reason"
                .FillWeight = 15
                .MinimumWidth = 100
            End With
        End If

        If dgvRequests.Columns.Contains("priority") Then
            With dgvRequests.Columns("priority")
                .HeaderText = "Priority"
                .FillWeight = 6
                .MinimumWidth = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End If

        If dgvRequests.Columns.Contains("status") Then
            With dgvRequests.Columns("status")
                .HeaderText = "Status"
                .FillWeight = 7
                .MinimumWidth = 70
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        End If

        If dgvRequests.Columns.Contains("approved_by_name") Then
            With dgvRequests.Columns("approved_by_name")
                .HeaderText = "Approved By"
                .FillWeight = 10
                .MinimumWidth = 90
            End With
        End If

        If dgvRequests.Columns.Contains("issued_by_name") Then
            With dgvRequests.Columns("issued_by_name")
                .HeaderText = "Issued By"
                .FillWeight = 10
                .MinimumWidth = 90
            End With
        End If

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
                    Case "Cancelled"
                        row.Cells("status").Style.BackColor = Color.FromArgb(220, 220, 220)
                        row.Cells("status").Style.ForeColor = Color.FromArgb(100, 100, 100)
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
                    Case "Medium"
                        row.Cells("priority").Style.BackColor = Color.FromArgb(241, 196, 15)
                End Select
            End If
        Next
    End Sub

    Private Sub dgvRequests_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRequests.SelectionChanged
        btnViewDetails.Enabled = dgvRequests.SelectedRows.Count > 0
    End Sub

    Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        If dgvRequests.SelectedRows.Count = 0 Then Return

        Dim row As DataGridViewRow = dgvRequests.SelectedRows(0)
        ShowRequestDetails(row)
    End Sub

    Private Sub ShowRequestDetails(row As DataGridViewRow)
        Dim details As New System.Text.StringBuilder()

        ' Basic Information
        details.AppendLine("═══════════════════════════════════════════════════")
        details.AppendLine("REQUEST DETAILS")
        details.AppendLine("═══════════════════════════════════════════════════")
        details.AppendLine()
        details.AppendLine($"Request Type: {row.Cells("request_type").Value}")
        details.AppendLine($"Request ID: #{row.Cells("request_id").Value}")
        details.AppendLine($"Request Date: {Convert.ToDateTime(row.Cells("request_date").Value):yyyy-MM-dd HH:mm}")
        details.AppendLine($"Status: {row.Cells("status").Value}")
        details.AppendLine()

        ' Requester Information
        details.AppendLine("───────────────────────────────────────────────────")
        details.AppendLine("REQUESTER INFORMATION")
        details.AppendLine("───────────────────────────────────────────────────")
        details.AppendLine($"Name: {row.Cells("requester_name").Value}")
        details.AppendLine($"Department: {row.Cells("requester_department").Value}")
        details.AppendLine()

        ' Item Information
        details.AppendLine("───────────────────────────────────────────────────")
        details.AppendLine("ITEM INFORMATION")
        details.AppendLine("───────────────────────────────────────────────────")
        details.AppendLine($"Item: {row.Cells("item_description").Value}")
        details.AppendLine($"Quantity: {row.Cells("quantity").Value}")
        details.AppendLine($"Priority: {row.Cells("priority").Value}")
        details.AppendLine()

        ' Request Details
        details.AppendLine("───────────────────────────────────────────────────")
        details.AppendLine("REQUEST DETAILS")
        details.AppendLine("───────────────────────────────────────────────────")
        details.AppendLine($"Reason: {row.Cells("reason").Value}")

        If Not IsDBNull(row.Cells("purpose").Value) AndAlso Not String.IsNullOrWhiteSpace(row.Cells("purpose").Value.ToString()) Then
            details.AppendLine($"Purpose: {row.Cells("purpose").Value}")
        End If
        details.AppendLine()

        ' Approval Information
        Dim status As String = row.Cells("status").Value.ToString()
        If status = "Approved" OrElse status = "Fulfilled" OrElse status = "Rejected" Then
            details.AppendLine("───────────────────────────────────────────────────")
            details.AppendLine("APPROVAL INFORMATION")
            details.AppendLine("───────────────────────────────────────────────────")

            If Not IsDBNull(row.Cells("approved_by_name").Value) Then
                details.AppendLine($"Approved By: {row.Cells("approved_by_name").Value}")
            End If

            If Not IsDBNull(row.Cells("approved_date").Value) Then
                details.AppendLine($"Approval Date: {Convert.ToDateTime(row.Cells("approved_date").Value):yyyy-MM-dd HH:mm}")
            End If

            If status = "Rejected" AndAlso Not IsDBNull(row.Cells("rejection_reason").Value) Then
                details.AppendLine($"Rejection Reason: {row.Cells("rejection_reason").Value}")
            End If

            If Not IsDBNull(row.Cells("notes").Value) AndAlso Not String.IsNullOrWhiteSpace(row.Cells("notes").Value.ToString()) Then
                details.AppendLine($"Notes: {row.Cells("notes").Value}")
            End If
            details.AppendLine()
        End If

        ' Fulfillment Information
        If status = "Fulfilled" Then
            details.AppendLine("───────────────────────────────────────────────────")
            details.AppendLine("FULFILLMENT INFORMATION")
            details.AppendLine("───────────────────────────────────────────────────")

            If Not IsDBNull(row.Cells("issued_by_name").Value) Then
                details.AppendLine($"Issued By: {row.Cells("issued_by_name").Value}")
            End If

            If Not IsDBNull(row.Cells("fulfillment_date").Value) Then
                details.AppendLine($"Fulfillment Date: {Convert.ToDateTime(row.Cells("fulfillment_date").Value):yyyy-MM-dd HH:mm}")
            End If
        End If

        details.AppendLine("═══════════════════════════════════════════════════")

        ' Show in message box
        MessageBox.Show(details.ToString(), "Request Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub cmbStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatusFilter.SelectedIndexChanged
        If cmbStatusFilter.SelectedItem IsNot Nothing AndAlso cmbTypeFilter.SelectedItem IsNot Nothing Then
            LoadRequestHistory(cmbStatusFilter.SelectedItem.ToString(), cmbTypeFilter.SelectedItem.ToString())
        End If
    End Sub

    Private Sub cmbTypeFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTypeFilter.SelectedIndexChanged
        If cmbStatusFilter.SelectedItem IsNot Nothing AndAlso cmbTypeFilter.SelectedItem IsNot Nothing Then
            LoadRequestHistory(cmbStatusFilter.SelectedItem.ToString(), cmbTypeFilter.SelectedItem.ToString())
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadRequestHistory(cmbStatusFilter.SelectedItem.ToString(), cmbTypeFilter.SelectedItem.ToString())
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvRequests.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Create SaveFileDialog
            Using sfd As New SaveFileDialog()
                sfd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
                sfd.FileName = $"RequestHistory_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

                If sfd.ShowDialog() = DialogResult.OK Then
                    ExportToCSV(sfd.FileName)
                    MessageBox.Show("Export completed successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToCSV(filePath As String)
        Using sw As New System.IO.StreamWriter(filePath)
            ' Write headers
            Dim headers As New List(Of String)()
            For Each column As DataGridViewColumn In dgvRequests.Columns
                If column.Visible Then
                    headers.Add(column.HeaderText)
                End If
            Next
            sw.WriteLine(String.Join(",", headers))

            ' Write data
            For Each row As DataGridViewRow In dgvRequests.Rows
                Dim cells As New List(Of String)()
                For Each column As DataGridViewColumn In dgvRequests.Columns
                    If column.Visible Then
                        Dim cellValue As String = If(row.Cells(column.Index).Value?.ToString(), "")
                        ' Escape commas and quotes
                        If cellValue.Contains(",") OrElse cellValue.Contains("""") Then
                            cellValue = """" & cellValue.Replace("""", """""") & """"
                        End If
                        cells.Add(cellValue)
                    End If
                Next
                sw.WriteLine(String.Join(",", cells))
            Next
        End Using
    End Sub
End Class