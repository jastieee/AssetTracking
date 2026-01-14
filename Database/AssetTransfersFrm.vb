Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class AssetTransfersFrm

    Private currentFilter As String = "All"

    ''' <summary>
    ''' Form Load - Initialize
    ''' </summary>
    Private Sub AssetTransfersFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default filter
        rbAll.Checked = True

        ' Load transfer list
        LoadTransferList()

        ' Disable action buttons initially
        DisableActionButtons()
    End Sub

    ''' <summary>
    ''' Load transfer list into DataGridView
    ''' </summary>
    Private Sub LoadTransferList(Optional statusFilter As String = "All", Optional searchText As String = "")
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                                        t.transfer_id,
                                        a.asset_tag,
                                        a.asset_name,
                                        IFNULL(d1.department_name, 'N/A') as from_department,
                                        d2.department_name as to_department,
                                        IFNULL(CONCAT(u1.first_name, ' ', u1.last_name), 'N/A') as from_user,
                                        IFNULL(CONCAT(u2.first_name, ' ', u2.last_name), 'N/A') as to_user,
                                        CONCAT(u3.first_name, ' ', u3.last_name) as requested_by,
                                        t.transfer_date,
                                        t.status,
                                        t.reason
                                      FROM asset_transfers t
                                      INNER JOIN assets a ON t.asset_id = a.asset_id
                                      LEFT JOIN departments d1 ON t.from_department_id = d1.department_id
                                      INNER JOIN departments d2 ON t.to_department_id = d2.department_id
                                      LEFT JOIN users u1 ON t.from_user_id = u1.user_id
                                      LEFT JOIN users u2 ON t.to_user_id = u2.user_id
                                      INNER JOIN users u3 ON t.requested_by = u3.user_id
                                      WHERE 1=1"

                ' Add status filter
                If statusFilter <> "All" Then
                    query &= " AND t.status = @status"
                End If

                ' Add search filter
                If Not String.IsNullOrWhiteSpace(searchText) Then
                    query &= " AND (a.asset_tag LIKE @search OR a.asset_name LIKE @search OR CONCAT(u3.first_name, ' ', u3.last_name) LIKE @search)"
                End If

                query &= " ORDER BY t.transfer_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    If statusFilter <> "All" Then
                        cmd.Parameters.AddWithValue("@status", statusFilter)
                    End If

                    If Not String.IsNullOrWhiteSpace(searchText) Then
                        cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvTransfers.DataSource = dt

                        ' Configure columns
                        If dgvTransfers.Columns.Count > 0 Then
                            dgvTransfers.Columns("transfer_id").Visible = False
                            dgvTransfers.Columns("asset_tag").HeaderText = "Asset Tag"
                            dgvTransfers.Columns("asset_tag").Width = 100
                            dgvTransfers.Columns("asset_name").HeaderText = "Asset Name"
                            dgvTransfers.Columns("asset_name").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            dgvTransfers.Columns("from_department").HeaderText = "From Dept"
                            dgvTransfers.Columns("from_department").Width = 120
                            dgvTransfers.Columns("to_department").HeaderText = "To Dept"
                            dgvTransfers.Columns("to_department").Width = 120
                            dgvTransfers.Columns("from_user").HeaderText = "From User"
                            dgvTransfers.Columns("from_user").Width = 120
                            dgvTransfers.Columns("to_user").HeaderText = "To User"
                            dgvTransfers.Columns("to_user").Width = 120
                            dgvTransfers.Columns("requested_by").HeaderText = "Requested By"
                            dgvTransfers.Columns("requested_by").Width = 120
                            dgvTransfers.Columns("transfer_date").HeaderText = "Request Date"
                            dgvTransfers.Columns("transfer_date").Width = 140
                            dgvTransfers.Columns("transfer_date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                            dgvTransfers.Columns("status").HeaderText = "Status"
                            dgvTransfers.Columns("status").Width = 100
                            dgvTransfers.Columns("reason").Visible = False
                        End If

                        ' Apply status colors
                        ApplyStatusColors()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading transfers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Apply color coding based on status
    ''' </summary>
    Private Sub ApplyStatusColors()
        For Each row As DataGridViewRow In dgvTransfers.Rows
            If row.Cells("status").Value IsNot Nothing Then
                Dim status As String = row.Cells("status").Value.ToString()

                Select Case status
                    Case "Pending"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205) ' Light orange
                    Case "Approved"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(212, 239, 223) ' Light green
                    Case "Rejected"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(248, 215, 218) ' Light red
                    Case "Completed"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(217, 237, 247) ' Light blue
                End Select
            End If
        Next
    End Sub

    ''' <summary>
    ''' Filter radio button changed
    ''' </summary>
    Private Sub FilterRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles rbAll.CheckedChanged, rbPending.CheckedChanged, rbApproved.CheckedChanged, rbRejected.CheckedChanged, rbCompleted.CheckedChanged
        Dim rb As RadioButton = CType(sender, RadioButton)
        If rb.Checked Then
            currentFilter = rb.Text
            LoadTransferList(currentFilter, txtSearchTransfer.Text.Trim())
        End If
    End Sub

    ''' <summary>
    ''' Search button click
    ''' </summary>
    Private Sub btnSearchTransfer_Click(sender As Object, e As EventArgs) Handles btnSearchTransfer.Click
        LoadTransferList(currentFilter, txtSearchTransfer.Text.Trim())
    End Sub

    ''' <summary>
    ''' Search textbox key press
    ''' </summary>
    Private Sub txtSearchTransfer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchTransfer.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            btnSearchTransfer.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' New Transfer button click
    ''' </summary>
    Private Sub btnNewTransfer_Click(sender As Object, e As EventArgs) Handles btnNewTransfer.Click
        Dim transferForm As New NewTransferFrm()
        If transferForm.ShowDialog() = DialogResult.OK Then
            LoadTransferList(currentFilter)
            MessageBox.Show("Transfer request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ''' <summary>
    ''' DataGridView selection changed
    ''' </summary>
    Private Sub dgvTransfers_SelectionChanged(sender As Object, e As EventArgs) Handles dgvTransfers.SelectionChanged
        If dgvTransfers.SelectedRows.Count > 0 Then
            Dim status As String = dgvTransfers.SelectedRows(0).Cells("status").Value.ToString()

            btnViewDetails.Enabled = True

            ' Only enable approve/reject for pending transfers and if user has permission
            If status = "Pending" AndAlso (gCurrentUserRole = "Admin" OrElse gCurrentUserRole = "Approver") Then
                btnApprove.Enabled = True
                btnReject.Enabled = True
            Else
                btnApprove.Enabled = False
                btnReject.Enabled = False
            End If
        Else
            DisableActionButtons()
        End If
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
        Dim assetTag As String = dgvTransfers.SelectedRows(0).Cells("asset_tag").Value.ToString()
        Dim fromDept As String = dgvTransfers.SelectedRows(0).Cells("from_department").Value.ToString()
        Dim toDept As String = dgvTransfers.SelectedRows(0).Cells("to_department").Value.ToString()
        Dim requestedBy As String = dgvTransfers.SelectedRows(0).Cells("requested_by").Value.ToString()
        Dim status As String = dgvTransfers.SelectedRows(0).Cells("status").Value.ToString()
        Dim reason As String = If(dgvTransfers.SelectedRows(0).Cells("reason").Value IsNot Nothing, dgvTransfers.SelectedRows(0).Cells("reason").Value.ToString(), "")

        Dim details As String = $"Transfer Details:{vbCrLf}{vbCrLf}" &
                               $"Transfer ID: {transferId}{vbCrLf}" &
                               $"Asset: {assetTag}{vbCrLf}" &
                               $"From: {fromDept}{vbCrLf}" &
                               $"To: {toDept}{vbCrLf}" &
                               $"Requested By: {requestedBy}{vbCrLf}" &
                               $"Status: {status}{vbCrLf}" &
                               $"Reason: {reason}"

        MessageBox.Show(details, "Transfer Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Approve button click
    ''' </summary>
    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If dgvTransfers.SelectedRows.Count = 0 Then Return

        Dim transferId As Integer = Convert.ToInt32(dgvTransfers.SelectedRows(0).Cells("transfer_id").Value)
        Dim assetTag As String = dgvTransfers.SelectedRows(0).Cells("asset_tag").Value.ToString()

        Dim result As DialogResult = MessageBox.Show($"Approve transfer for asset '{assetTag}'?",
                                                     "Confirm Approval",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question)

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

                ' Start transaction
                Dim transaction As MySqlTransaction = conn.BeginTransaction()

                Try
                    ' Get transfer details
                    Dim queryTransfer As String = "SELECT asset_id, to_department_id, to_user_id FROM asset_transfers WHERE transfer_id = @transferId"
                    Dim assetId As Integer
                    Dim toDeptId As Object
                    Dim toUserId As Object

                    Using cmd As New MySqlCommand(queryTransfer, conn, transaction)
                        cmd.Parameters.AddWithValue("@transferId", transferId)
                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                assetId = Convert.ToInt32(reader("asset_id"))
                                toDeptId = reader("to_department_id")
                                toUserId = If(IsDBNull(reader("to_user_id")), Nothing, reader("to_user_id"))
                            Else
                                MessageBox.Show("Transfer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                transaction.Rollback()
                                Return
                            End If
                        End Using
                    End Using

                    ' Update transfer status
                    Dim queryUpdate As String = "UPDATE asset_transfers SET status = 'Approved', approved_by = @approvedBy WHERE transfer_id = @transferId"
                    Using cmd As New MySqlCommand(queryUpdate, conn, transaction)
                        cmd.Parameters.AddWithValue("@transferId", transferId)
                        cmd.Parameters.AddWithValue("@approvedBy", gCurrentUserId)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' Update asset assignment
                    Dim queryAsset As String = "UPDATE assets SET current_department_id = @deptId, assigned_to_user_id = @userId, status = 'In Use' WHERE asset_id = @assetId"
                    Using cmd As New MySqlCommand(queryAsset, conn, transaction)
                        cmd.Parameters.AddWithValue("@assetId", assetId)
                        cmd.Parameters.AddWithValue("@deptId", toDeptId)
                        cmd.Parameters.AddWithValue("@userId", If(toUserId, DBNull.Value))
                        cmd.ExecuteNonQuery()
                    End Using

                    ' Commit transaction
                    transaction.Commit()

                    ' Log activity
                    LogActivity(gCurrentUserId, "Transfer Approved", "asset_transfers", transferId, $"Approved transfer ID: {transferId}")

                    ' Refresh list
                    LoadTransferList(currentFilter)

                    MessageBox.Show("Transfer approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Catch ex As Exception
                    transaction.Rollback()
                    Throw
                End Try
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
        Dim assetTag As String = dgvTransfers.SelectedRows(0).Cells("asset_tag").Value.ToString()

        ' Ask for rejection reason
        Dim reason As String = InputBox("Please enter rejection reason:", "Reject Transfer", "")

        If String.IsNullOrWhiteSpace(reason) Then
            MessageBox.Show("Rejection reason is required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                Dim query As String = "UPDATE asset_transfers SET status = 'Rejected', approved_by = @approvedBy, notes = @reason WHERE transfer_id = @transferId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@transferId", transferId)
                    cmd.Parameters.AddWithValue("@approvedBy", gCurrentUserId)
                    cmd.Parameters.AddWithValue("@reason", reason)
                    cmd.ExecuteNonQuery()
                End Using

                ' Log activity
                LogActivity(gCurrentUserId, "Transfer Rejected", "asset_transfers", transferId, $"Rejected transfer ID: {transferId} - Reason: {reason}")

                ' Refresh list
                LoadTransferList(currentFilter)

                MessageBox.Show("Transfer rejected!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error rejecting transfer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Export button click
    ''' </summary>
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' TODO: Implement export to Excel/CSV
        MessageBox.Show("Export functionality coming soon!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Log activity
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
            ' Silent fail
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

End Class