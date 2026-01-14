Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class TransferConsumablesFrm

    ''' <summary>
    ''' Form Load - Initialize everything
    ''' </summary>
    Private Sub TransferConsumablesFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load transfer list
        LoadTransferList()

        ' Disable action buttons initially
        DisableActionButtons()
    End Sub

    ''' <summary>
    ''' Load transfer list into DataGridView
    ''' </summary>
    Private Sub LoadTransferList(Optional searchText As String = "", Optional statusFilter As String = "All")
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT ct.transfer_id, ct.transfer_date, c.consumable_code, c.consumable_name, " &
                                     "ct.quantity, c.unit_of_measure, " &
                                     "d1.department_name as from_department, " &
                                     "d2.department_name as to_department, " &
                                     "CONCAT(u1.first_name, ' ', u1.last_name) as requested_by_name, " &
                                     "IFNULL(CONCAT(u2.first_name, ' ', u2.last_name), 'Pending') as approved_by_name, " &
                                     "ct.status, ct.reason " &
                                     "FROM consumable_transfers ct " &
                                     "INNER JOIN consumables c ON ct.consumable_id = c.consumable_id " &
                                     "INNER JOIN departments d1 ON ct.from_department_id = d1.department_id " &
                                     "INNER JOIN departments d2 ON ct.to_department_id = d2.department_id " &
                                     "INNER JOIN users u1 ON ct.requested_by = u1.user_id " &
                                     "LEFT JOIN users u2 ON ct.approved_by = u2.user_id " &
                                     "WHERE 1=1"

                ' Add search filter
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    query &= " AND (c.consumable_code LIKE @search OR c.consumable_name LIKE @search OR d1.department_name LIKE @search OR d2.department_name LIKE @search)"
                End If

                ' Add status filter
                If statusFilter <> "All" Then
                    query &= " AND ct.status = @status"
                End If

                query &= " ORDER BY ct.transfer_date DESC, ct.transfer_id DESC"

                Using cmd As New MySqlCommand(query, conn)
                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                    End If

                    If statusFilter <> "All" Then
                        cmd.Parameters.AddWithValue("@status", statusFilter)
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvTransfers.DataSource = dt

                        ' Configure columns
                        If dgvTransfers.Columns.Count > 0 Then
                            dgvTransfers.Columns("transfer_id").HeaderText = "ID"
                            dgvTransfers.Columns("transfer_id").Width = 60
                            dgvTransfers.Columns("transfer_date").HeaderText = "Transfer Date"
                            dgvTransfers.Columns("transfer_date").Width = 130
                            dgvTransfers.Columns("transfer_date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                            dgvTransfers.Columns("consumable_code").HeaderText = "Item Code"
                            dgvTransfers.Columns("consumable_code").Width = 100
                            dgvTransfers.Columns("consumable_name").HeaderText = "Item Name"
                            dgvTransfers.Columns("consumable_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            dgvTransfers.Columns("quantity").HeaderText = "Qty"
                            dgvTransfers.Columns("quantity").Width = 60
                            dgvTransfers.Columns("unit_of_measure").HeaderText = "Unit"
                            dgvTransfers.Columns("unit_of_measure").Width = 70
                            dgvTransfers.Columns("from_department").HeaderText = "From Dept"
                            dgvTransfers.Columns("from_department").Width = 120
                            dgvTransfers.Columns("to_department").HeaderText = "To Dept"
                            dgvTransfers.Columns("to_department").Width = 120
                            dgvTransfers.Columns("requested_by_name").HeaderText = "Requested By"
                            dgvTransfers.Columns("requested_by_name").Width = 120
                            dgvTransfers.Columns("approved_by_name").HeaderText = "Approved By"
                            dgvTransfers.Columns("approved_by_name").Width = 120
                            dgvTransfers.Columns("status").HeaderText = "Status"
                            dgvTransfers.Columns("status").Width = 90
                            dgvTransfers.Columns("reason").Visible = False
                        End If

                        ' Apply row colors based on status
                        ApplyStatusColors()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading transfers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Apply color coding to rows based on status
    ''' </summary>
    Private Sub ApplyStatusColors()
        For Each row As DataGridViewRow In dgvTransfers.Rows
            If row.Cells("status").Value IsNot Nothing Then
                Dim status As String = row.Cells("status").Value.ToString()

                Select Case status
                    Case "Pending"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205) ' Light yellow
                    Case "Approved"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(209, 231, 221) ' Light blue
                    Case "Completed"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(212, 239, 223) ' Light green
                    Case "Rejected"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(248, 215, 218) ' Light red
                        row.DefaultCellStyle.ForeColor = Color.Gray
                End Select
            End If
        Next
    End Sub

    ''' <summary>
    ''' Get current status filter
    ''' </summary>
    Private Function GetStatusFilter() As String
        If rbPending.Checked Then Return "Pending"
        If rbApproved.Checked Then Return "Approved"
        If rbRejected.Checked Then Return "Rejected"
        If rbCompleted.Checked Then Return "Completed"
        Return "All"
    End Function

    ''' <summary>
    ''' Search button click
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchText As String = txtSearch.Text.Trim()
        Dim statusFilter As String = GetStatusFilter()
        LoadTransferList(searchText, statusFilter)
    End Sub

    ''' <summary>
    ''' Status radio button changed
    ''' </summary>
    Private Sub rbStatus_CheckedChanged(sender As Object, e As EventArgs) Handles rbAll.CheckedChanged, rbPending.CheckedChanged, rbApproved.CheckedChanged, rbRejected.CheckedChanged, rbCompleted.CheckedChanged
        If CType(sender, RadioButton).Checked Then
            Dim searchText As String = txtSearch.Text.Trim()
            Dim statusFilter As String = GetStatusFilter()
            LoadTransferList(searchText, statusFilter)
        End If
    End Sub

    ''' <summary>
    ''' New Transfer button click
    ''' </summary>
    'Private Sub btnNewTransfer_Click(sender As Object, e As EventArgs) Handles btnNewTransfer.Click
    '    Dim newTransferForm As New NewConsumableTransferFrm()
    '    If newTransferForm.ShowDialog() = DialogResult.OK Then
    '        LoadTransferList() ' Refresh list
    '        MessageBox.Show("Transfer request created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    'End Sub

    ''' <summary>
    ''' DataGridView selection changed
    ''' </summary>
    Private Sub dgvTransfers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTransfers.SelectionChanged
        If dgvTransfers.SelectedRows.Count = 0 Then
            DisableActionButtons()
            Return
        End If

        Dim status As String = dgvTransfers.SelectedRows(0).Cells("status").Value.ToString()

        btnViewDetails.Enabled = True

        ' Enable Approve/Reject only for Pending transfers
        btnApprove.Enabled = (status = "Pending")
        btnReject.Enabled = (status = "Pending")
    End Sub

    ''' <summary>
    ''' Disable all action buttons
    ''' </summary>
    Private Sub DisableActionButtons()
        btnViewDetails.Enabled = False
        btnApprove.Enabled = False
        btnReject.Enabled = False
    End Sub

    ''' <summary>
    ''' View Details button click
    ''' </summary>
    Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        If dgvTransfers.SelectedRows.Count = 0 Then Return

        Dim transferId As Integer = Convert.ToInt32(dgvTransfers.SelectedRows(0).Cells("transfer_id").Value)
        ShowTransferDetails(transferId)
    End Sub

    ''' <summary>
    ''' Show transfer details
    ''' </summary>
    Private Sub ShowTransferDetails(transferId As Integer)
        Try
            Dim details As New System.Text.StringBuilder()

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT ct.*, c.consumable_code, c.consumable_name, c.unit_of_measure, " &
                                     "d1.department_name as from_department, d2.department_name as to_department, " &
                                     "CONCAT(u1.first_name, ' ', u1.last_name) as requested_by_name, " &
                                     "IFNULL(CONCAT(u2.first_name, ' ', u2.last_name), 'N/A') as approved_by_name " &
                                     "FROM consumable_transfers ct " &
                                     "INNER JOIN consumables c ON ct.consumable_id = c.consumable_id " &
                                     "INNER JOIN departments d1 ON ct.from_department_id = d1.department_id " &
                                     "INNER JOIN departments d2 ON ct.to_department_id = d2.department_id " &
                                     "INNER JOIN users u1 ON ct.requested_by = u1.user_id " &
                                     "LEFT JOIN users u2 ON ct.approved_by = u2.user_id " &
                                     "WHERE ct.transfer_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", transferId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            details.AppendLine("TRANSFER DETAILS")
                            details.AppendLine(New String("="c, 50))
                            details.AppendLine($"Transfer ID: {transferId}")
                            details.AppendLine($"Date: {Convert.ToDateTime(reader("transfer_date")):yyyy-MM-dd HH:mm}")
                            details.AppendLine($"Status: {reader("status")}")
                            details.AppendLine()
                            details.AppendLine("ITEM INFORMATION")
                            details.AppendLine(New String("-"c, 50))
                            details.AppendLine($"Code: {reader("consumable_code")}")
                            details.AppendLine($"Name: {reader("consumable_name")}")
                            details.AppendLine($"Quantity: {reader("quantity")} {reader("unit_of_measure")}")
                            details.AppendLine()
                            details.AppendLine("TRANSFER ROUTE")
                            details.AppendLine(New String("-"c, 50))
                            details.AppendLine($"From: {reader("from_department")}")
                            details.AppendLine($"To: {reader("to_department")}")
                            details.AppendLine()
                            details.AppendLine("PERSONNEL")
                            details.AppendLine(New String("-"c, 50))
                            details.AppendLine($"Requested By: {reader("requested_by_name")}")
                            details.AppendLine($"Approved By: {reader("approved_by_name")}")

                            If Not IsDBNull(reader("reason")) AndAlso Not String.IsNullOrWhiteSpace(reader("reason").ToString()) Then
                                details.AppendLine()
                                details.AppendLine("REASON")
                                details.AppendLine(New String("-"c, 50))
                                details.AppendLine(reader("reason").ToString())
                            End If

                            If Not IsDBNull(reader("notes")) AndAlso Not String.IsNullOrWhiteSpace(reader("notes").ToString()) Then
                                details.AppendLine()
                                details.AppendLine("NOTES")
                                details.AppendLine(New String("-"c, 50))
                                details.AppendLine(reader("notes").ToString())
                            End If
                        End If
                    End Using
                End Using
            End Using

            MessageBox.Show(details.ToString(), "Transfer Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error loading transfer details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Approve button click
    ''' </summary>
    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If dgvTransfers.SelectedRows.Count = 0 Then Return

        Dim transferId As Integer = Convert.ToInt32(dgvTransfers.SelectedRows(0).Cells("transfer_id").Value)
        Dim itemName As String = dgvTransfers.SelectedRows(0).Cells("consumable_name").Value.ToString()

        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to approve this transfer?" & vbCrLf & vbCrLf &
                                                     $"Item: {itemName}",
                                                     "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ApproveTransfer(transferId)
        End If
    End Sub

    ''' <summary>
    ''' Approve transfer
    ''' </summary>
    Private Sub ApproveTransfer(transferId As Integer)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Update transfer status
                Dim query As String = "UPDATE consumable_transfers SET status = 'Approved', approved_by = @userId WHERE transfer_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", transferId)
                    cmd.Parameters.AddWithValue("@userId", gCurrentUserId)
                    cmd.ExecuteNonQuery()
                End Using

                ' Log activity
                LogActivity(gCurrentUserId, "Transfer Approved", "consumable_transfers", transferId, $"Approved consumable transfer ID: {transferId}")

                ' Refresh list
                LoadTransferList()

                MessageBox.Show("Transfer approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error approving transfer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Reject button click
    ''' </summary>
    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If dgvTransfers.SelectedRows.Count = 0 Then Return

        Dim transferId As Integer = Convert.ToInt32(dgvTransfers.SelectedRows(0).Cells("transfer_id").Value)
        Dim itemName As String = dgvTransfers.SelectedRows(0).Cells("consumable_name").Value.ToString()

        Dim reason As String = InputBox("Please enter reason for rejection:", "Reject Transfer", "")
        If String.IsNullOrWhiteSpace(reason) Then
            MessageBox.Show("Rejection reason is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        RejectTransfer(transferId, reason)
    End Sub

    ''' <summary>
    ''' Reject transfer
    ''' </summary>
    Private Sub RejectTransfer(transferId As Integer, reason As String)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Update transfer status
                Dim query As String = "UPDATE consumable_transfers SET status = 'Rejected', approved_by = @userId, notes = @reason WHERE transfer_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", transferId)
                    cmd.Parameters.AddWithValue("@userId", gCurrentUserId)
                    cmd.Parameters.AddWithValue("@reason", reason)
                    cmd.ExecuteNonQuery()
                End Using

                ' Log activity
                LogActivity(gCurrentUserId, "Transfer Rejected", "consumable_transfers", transferId, $"Rejected consumable transfer ID: {transferId}")

                ' Refresh list
                LoadTransferList()

                MessageBox.Show("Transfer rejected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error rejecting transfer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Export button click
    ''' </summary>
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' TODO: Implement export to Excel
        MessageBox.Show("Export functionality coming soon!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Log activity to database
    ''' </summary>
    Private Sub LogActivity(userId As Integer, actionType As String, tableName As String, recordId As Integer, description As String)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description, ip_address) " &
                                     "VALUES (@userId, @actionType, @tableName, @recordId, @description, @ipAddress)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)
                    cmd.Parameters.AddWithValue("@actionType", actionType)
                    cmd.Parameters.AddWithValue("@tableName", tableName)
                    cmd.Parameters.AddWithValue("@recordId", recordId)
                    cmd.Parameters.AddWithValue("@description", description)
                    cmd.Parameters.AddWithValue("@ipAddress", GetLocalIPAddress())
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Silent fail for logging
        End Try
    End Sub

    ''' <summary>
    ''' Get local IP address
    ''' </summary>
    Private Function GetLocalIPAddress() As String
        Try
            Dim host As String = System.Net.Dns.GetHostName()
            Dim ip As System.Net.IPAddress = System.Net.Dns.GetHostEntry(host).AddressList.FirstOrDefault(Function(x) x.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)
            If ip IsNot Nothing Then
                Return ip.ToString()
            End If
        Catch ex As Exception
        End Try
        Return "Unknown"
    End Function

    ''' <summary>
    ''' Enter key press in search textbox
    ''' </summary>
    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            btnSearch.PerformClick()
        End If
    End Sub

End Class