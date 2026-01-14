'----- IssueConsumableFrm.vb -----
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class IssueConsumableFrm
    Private selectedEmployeeId As Integer
    Private selectedEmployeeName As String
    Private selectedDepartmentId As Integer
    Private selectedConsumableId As Integer = 0
    Private availableStock As Integer = 0
    Private searchTimer As Timer

    Public Sub New(employeeId As Integer, employeeName As String, departmentId As Integer)
        InitializeComponent()
        selectedEmployeeId = employeeId
        selectedEmployeeName = employeeName
        selectedDepartmentId = departmentId
    End Sub

    Private Sub IssueConsumableFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StyleDataGridView()
        LoadConsumables()
        lblFormTitle.Text = $"📦 Issue Consumable to: {selectedEmployeeName}"
    End Sub

    Private Sub StyleDataGridView()
        With dgvConsumables
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 40
            .EnableHeadersVisualStyles = False

            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.FromArgb(52, 73, 94)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .RowTemplate.Height = 35
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)

            .GridColor = Color.FromArgb(189, 195, 199)
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        End With
    End Sub

    Private Sub LoadConsumables()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    c.consumable_id AS 'ID',
                    c.consumable_code AS 'Code',
                    c.consumable_name AS 'Consumable Name',
                    cc.category_name AS 'Category',
                    cs.subcategory_name AS 'Subcategory',
                    c.unit_of_measure AS 'Unit',
                    c.total_quantity_in_stock AS 'Available Stock',
                    c.unit_cost AS 'Unit Cost',
                    CASE 
                        WHEN c.total_quantity_in_stock <= c.minimum_stock_level THEN 'Critical'
                        WHEN c.total_quantity_in_stock <= c.reorder_level THEN 'Low Stock'
                        ELSE 'Sufficient'
                    END AS 'Stock Status'
                    FROM consumables c
                    LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id
                    LEFT JOIN consumable_subcategories cs ON c.subcategory_id = cs.subcategory_id
                    WHERE c.total_quantity_in_stock > 0"

                If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                    query &= " AND (c.consumable_code LIKE @search OR c.consumable_name LIKE @search)"
                End If

                query &= " ORDER BY c.consumable_name"

                Using cmd As New MySqlCommand(query, conn)
                    If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                        cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text.Trim() & "%")
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvConsumables.DataSource = dt

                        If dgvConsumables.Columns.Contains("ID") Then
                            dgvConsumables.Columns("ID").Visible = False
                        End If

                        ' Color code stock status
                        If dgvConsumables.Columns.Contains("Stock Status") Then
                            For Each row As DataGridViewRow In dgvConsumables.Rows
                                Dim status As String = row.Cells("Stock Status").Value.ToString()
                                If status = "Critical" Then
                                    row.Cells("Stock Status").Style.BackColor = Color.FromArgb(231, 76, 60)
                                    row.Cells("Stock Status").Style.ForeColor = Color.White
                                ElseIf status = "Low Stock" Then
                                    row.Cells("Stock Status").Style.BackColor = Color.FromArgb(241, 196, 15)
                                    row.Cells("Stock Status").Style.ForeColor = Color.White
                                Else
                                    row.Cells("Stock Status").Style.BackColor = Color.FromArgb(46, 204, 113)
                                    row.Cells("Stock Status").Style.ForeColor = Color.White
                                End If
                            Next
                        End If

                        lblConsumableCount.Text = $"Total Available Consumables: {dt.Rows.Count}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading consumables: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If searchTimer Is Nothing Then
            searchTimer = New Timer()
            searchTimer.Interval = 500
            AddHandler searchTimer.Tick, Sub()
                                             searchTimer.Stop()
                                             LoadConsumables()
                                         End Sub
        End If
        searchTimer.Stop()
        searchTimer.Start()
    End Sub

    Private Sub dgvConsumables_SelectionChanged(sender As Object, e As EventArgs) Handles dgvConsumables.SelectionChanged
        If dgvConsumables.SelectedRows.Count > 0 Then
            selectedConsumableId = Convert.ToInt32(dgvConsumables.SelectedRows(0).Cells("ID").Value)
            availableStock = Convert.ToInt32(dgvConsumables.SelectedRows(0).Cells("Available Stock").Value)

            lblAvailableStock.Text = $"Available Stock: {availableStock}"
            nudQuantity.Maximum = availableStock
            nudQuantity.Value = 1
        Else
            selectedConsumableId = 0
            availableStock = 0
            lblAvailableStock.Text = "Available Stock: 0"
            nudQuantity.Maximum = 10000
            nudQuantity.Value = 1
        End If
    End Sub

    Private Sub btnIssue_Click(sender As Object, e As EventArgs) Handles btnIssue.Click
        If Not ValidateInputs() Then Return

        Dim result = MessageBox.Show($"Are you sure you want to issue this consumable?" & vbCrLf & vbCrLf &
                                    $"Consumable: {dgvConsumables.SelectedRows(0).Cells("Consumable Name").Value}" & vbCrLf &
                                    $"Quantity: {nudQuantity.Value}" & vbCrLf &
                                    $"To: {selectedEmployeeName}",
                                    "Confirm Issuance", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    If conn Is Nothing Then Return

                    ' Use stored procedure if available, otherwise direct insert
                    Dim query As String = "CALL sp_issue_consumable(@consumableId, @employeeId, @departmentId, @quantity, @issuedBy, @purpose, @notes, @issuanceId)"

                    ' Fallback to direct query if procedure doesn't work
                    Try
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@consumableId", selectedConsumableId)
                            cmd.Parameters.AddWithValue("@employeeId", selectedEmployeeId)
                            cmd.Parameters.AddWithValue("@departmentId", selectedDepartmentId)
                            cmd.Parameters.AddWithValue("@quantity", nudQuantity.Value)
                            cmd.Parameters.AddWithValue("@issuedBy", gCurrentUserId)
                            cmd.Parameters.AddWithValue("@purpose", txtPurpose.Text.Trim())
                            cmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim())
                            cmd.Parameters.Add("@issuanceId", MySqlDbType.Int32).Direction = ParameterDirection.Output

                            cmd.ExecuteNonQuery()
                        End Using
                    Catch procEx As Exception
                        ' Fallback to manual transaction
                        IssueConsumableManual(conn)
                    End Try

                    MessageBox.Show("Consumable issued successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error issuing consumable: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub IssueConsumableManual(conn As MySqlConnection)
        Using transaction = conn.BeginTransaction()
            Try
                ' Check stock availability
                Dim checkQuery As String = "SELECT total_quantity_in_stock FROM consumables WHERE consumable_id = @consumableId"
                Dim currentStock As Integer

                Using checkCmd As New MySqlCommand(checkQuery, conn, transaction)
                    checkCmd.Parameters.AddWithValue("@consumableId", selectedConsumableId)
                    currentStock = Convert.ToInt32(checkCmd.ExecuteScalar())
                End Using

                If currentStock < nudQuantity.Value Then
                    Throw New Exception("Insufficient stock for issuance")
                End If

                ' Insert issuance record
                Dim insertQuery As String = "INSERT INTO consumable_issuance 
                    (consumable_id, employee_id, department_id, quantity_issued, issued_by, purpose, notes)
                    VALUES (@consumableId, @employeeId, @departmentId, @quantity, @issuedBy, @purpose, @notes)"

                Using insertCmd As New MySqlCommand(insertQuery, conn, transaction)
                    insertCmd.Parameters.AddWithValue("@consumableId", selectedConsumableId)
                    insertCmd.Parameters.AddWithValue("@employeeId", selectedEmployeeId)
                    insertCmd.Parameters.AddWithValue("@departmentId", selectedDepartmentId)
                    insertCmd.Parameters.AddWithValue("@quantity", nudQuantity.Value)
                    insertCmd.Parameters.AddWithValue("@issuedBy", gCurrentUserId)
                    insertCmd.Parameters.AddWithValue("@purpose", txtPurpose.Text.Trim())
                    insertCmd.Parameters.AddWithValue("@notes", txtNotes.Text.Trim())
                    insertCmd.ExecuteNonQuery()
                End Using

                ' Update stock
                Dim updateQuery As String = "UPDATE consumables 
                    SET total_quantity_in_stock = total_quantity_in_stock - @quantity 
                    WHERE consumable_id = @consumableId"

                Using updateCmd As New MySqlCommand(updateQuery, conn, transaction)
                    updateCmd.Parameters.AddWithValue("@quantity", nudQuantity.Value)
                    updateCmd.Parameters.AddWithValue("@consumableId", selectedConsumableId)
                    updateCmd.ExecuteNonQuery()
                End Using

                ' Log activity
                Dim logQuery As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description, ip_address)
                    VALUES (@userId, 'Consumable Issued', 'consumable_issuance', LAST_INSERT_ID(), @description, @ipAddress)"

                Using logCmd As New MySqlCommand(logQuery, conn, transaction)
                    logCmd.Parameters.AddWithValue("@userId", gCurrentUserId)
                    logCmd.Parameters.AddWithValue("@description",
                        $"Issued {nudQuantity.Value} units of consumable ID {selectedConsumableId} to employee ID {selectedEmployeeId}")
                    logCmd.Parameters.AddWithValue("@ipAddress", GetLocalIPAddress())
                    logCmd.ExecuteNonQuery()
                End Using

                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()
                Throw
            End Try
        End Using
    End Sub

    Private Function ValidateInputs() As Boolean
        If dgvConsumables.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a consumable to issue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dgvConsumables.Focus()
            Return False
        End If

        If nudQuantity.Value <= 0 Then
            MessageBox.Show("Quantity must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            nudQuantity.Focus()
            Return False
        End If

        If nudQuantity.Value > availableStock Then
            MessageBox.Show($"Quantity exceeds available stock ({availableStock}).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            nudQuantity.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtPurpose.Text) Then
            MessageBox.Show("Please enter the purpose for this issuance.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPurpose.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Function GetLocalIPAddress() As String
        Try
            Dim host As String = System.Net.Dns.GetHostName()
            Dim ip As System.Net.IPAddress = System.Net.Dns.GetHostEntry(host).AddressList.FirstOrDefault(Function(x) x.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)
            If ip IsNot Nothing Then Return ip.ToString()
        Catch ex As Exception
        End Try
        Return "Unknown"
    End Function
End Class