'----- ManageConsumablesFrm.vb -----
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class ManageConsumablesFrm

    Private Sub ManageConsumablesFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadCategories()
        cboStockStatus.SelectedIndex = 0
        LoadConsumables()
    End Sub

    Private Sub InitializeForm()
        StyleDataGridView()
        AddContextMenu()
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

    Private Sub AddContextMenu()
        Dim contextMenu As New ContextMenuStrip()
        Dim viewItem As New ToolStripMenuItem("View Details", Nothing, AddressOf ViewConsumableDetails)
        Dim editItem As New ToolStripMenuItem("Edit Consumable", Nothing, AddressOf EditConsumable)
        Dim deleteItem As New ToolStripMenuItem("Delete Consumable", Nothing, AddressOf DeleteConsumable)
        contextMenu.Items.AddRange({viewItem, editItem, New ToolStripSeparator(), deleteItem})
        dgvConsumables.ContextMenuStrip = contextMenu
    End Sub

    Private Sub LoadCategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT consumable_category_id, category_name FROM consumable_categories ORDER BY category_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboCategory.Items.Clear()
                        cboCategory.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Categories"))

                        While reader.Read()
                            cboCategory.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("consumable_category_id"),
                                reader.GetString("category_name")
                            ))
                        End While
                    End Using
                End Using

                cboCategory.DisplayMember = "Value"
                cboCategory.ValueMember = "Key"
                cboCategory.SelectedIndex = 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        Try
            If cboCategory.SelectedIndex = -1 Then Return

            Dim selectedItem = DirectCast(cboCategory.SelectedItem, KeyValuePair(Of Integer, String))
            Dim categoryId As Integer = selectedItem.Key

            cboSubcategory.Items.Clear()
            cboSubcategory.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Subcategories"))

            If categoryId = 0 Then
                cboSubcategory.Enabled = False
                cboSubcategory.DisplayMember = "Value"
                cboSubcategory.ValueMember = "Key"
                cboSubcategory.SelectedIndex = 0
                LoadConsumables()
                Return
            End If

            cboSubcategory.Enabled = True

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT subcategory_id, subcategory_name FROM consumable_subcategories 
                                      WHERE category_id = @categoryId ORDER BY subcategory_name"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@categoryId", categoryId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cboSubcategory.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("subcategory_id"),
                                reader.GetString("subcategory_name")
                            ))
                        End While
                    End Using
                End Using
            End Using

            cboSubcategory.DisplayMember = "Value"
            cboSubcategory.ValueMember = "Key"
            cboSubcategory.SelectedIndex = 0
            LoadConsumables()

        Catch ex As Exception
            MessageBox.Show("Error loading subcategories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadConsumables()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    c.consumable_id,
                    c.consumable_code AS 'Code',
                    c.consumable_name AS 'Consumable Name',
                    cc.category_name AS 'Category',
                    cs.subcategory_name AS 'Subcategory',
                    c.unit_of_measure AS 'Unit',
                    c.total_quantity_in_stock AS 'Stock Qty',
                    c.minimum_stock_level AS 'Min Level',
                    c.reorder_level AS 'Reorder Level',
                    c.unit_cost AS 'Unit Cost',
                    CASE 
                        WHEN c.total_quantity_in_stock <= c.minimum_stock_level THEN 'Critical'
                        WHEN c.total_quantity_in_stock <= c.reorder_level THEN 'Low Stock'
                        ELSE 'Sufficient'
                    END AS 'Stock Status'
                    FROM consumables c
                    LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id
                    LEFT JOIN consumable_subcategories cs ON c.subcategory_id = cs.subcategory_id
                    WHERE 1=1"

                Dim parameters As New List(Of MySqlParameter)

                If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                    query &= " AND (c.consumable_code LIKE @search OR c.consumable_name LIKE @search)"
                    parameters.Add(New MySqlParameter("@search", "%" & txtSearch.Text.Trim() & "%"))
                End If

                If cboCategory.SelectedIndex > 0 Then
                    Dim selectedCategory = DirectCast(cboCategory.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND c.category_id = @categoryId"
                    parameters.Add(New MySqlParameter("@categoryId", selectedCategory.Key))
                End If

                If cboSubcategory.Enabled AndAlso cboSubcategory.SelectedIndex > 0 Then
                    Dim selectedSubcategory = DirectCast(cboSubcategory.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND c.subcategory_id = @subcategoryId"
                    parameters.Add(New MySqlParameter("@subcategoryId", selectedSubcategory.Key))
                End If

                If cboStockStatus.SelectedIndex > 0 Then
                    Dim status As String = cboStockStatus.SelectedItem.ToString()
                    If status = "Critical" Then
                        query &= " AND c.total_quantity_in_stock <= c.minimum_stock_level"
                    ElseIf status = "Low Stock" Then
                        query &= " AND c.total_quantity_in_stock > c.minimum_stock_level AND c.total_quantity_in_stock <= c.reorder_level"
                    ElseIf status = "Sufficient" Then
                        query &= " AND c.total_quantity_in_stock > c.reorder_level"
                    End If
                End If

                query &= " ORDER BY c.created_at DESC"

                Using cmd As New MySqlCommand(query, conn)
                    For Each param In parameters
                        cmd.Parameters.Add(param)
                    Next

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvConsumables.DataSource = dt

                        If dgvConsumables.Columns.Contains("consumable_id") Then
                            dgvConsumables.Columns("consumable_id").Visible = False
                        End If

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

                        lblRecordCount.Text = $"Total Consumables: {dt.Rows.Count}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading consumables: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private searchTimer As Timer
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

    Private Sub cboSubcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubcategory.SelectedIndexChanged
        If cboSubcategory.SelectedIndex <> -1 Then LoadConsumables()
    End Sub

    Private Sub cboStockStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStockStatus.SelectedIndexChanged
        If cboStockStatus.SelectedIndex <> -1 Then LoadConsumables()
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        txtSearch.Clear()
        cboCategory.SelectedIndex = 0
        cboSubcategory.SelectedIndex = 0
        cboStockStatus.SelectedIndex = 0
        LoadConsumables()
    End Sub

    Private Sub btnAddConsumable_Click(sender As Object, e As EventArgs) Handles btnAddConsumable.Click
        Dim addForm As New AddEditConsumableFrm()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadConsumables()
            LogActivity(gCurrentUserId, "Consumable Created", "consumables", 0, "New consumable added")
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadConsumables()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvConsumables.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV File (*.csv)|*.csv"
            saveDialog.FileName = $"Consumables_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportToCSV(saveDialog.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show("Error exporting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToCSV(filePath As String)
        Try
            Using writer As New IO.StreamWriter(filePath)
                Dim headers As New List(Of String)
                For Each column As DataGridViewColumn In dgvConsumables.Columns
                    If column.Visible Then headers.Add(column.HeaderText)
                Next
                writer.WriteLine(String.Join(",", headers))

                For Each row As DataGridViewRow In dgvConsumables.Rows
                    If Not row.IsNewRow Then
                        Dim cells As New List(Of String)
                        For Each column As DataGridViewColumn In dgvConsumables.Columns
                            If column.Visible Then
                                Dim value As String = If(row.Cells(column.Index).Value?.ToString(), "")
                                value = value.Replace("""", """""")
                                If value.Contains(",") OrElse value.Contains("""") Then
                                    value = """" & value & """"
                                End If
                                cells.Add(value)
                            End If
                        Next
                        writer.WriteLine(String.Join(",", cells))
                    End If
                Next
            End Using

            MessageBox.Show($"Data exported successfully to:{vbCrLf}{filePath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LogActivity(gCurrentUserId, "Consumable Export", "consumables", 0, "Exported consumable list to CSV")

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub dgvConsumables_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsumables.CellDoubleClick
        If e.RowIndex >= 0 Then ViewConsumableDetails(Nothing, Nothing)
    End Sub

    Private Sub ViewConsumableDetails(sender As Object, e As EventArgs)
        If dgvConsumables.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a consumable to view.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim consumableId As Integer = Convert.ToInt32(dgvConsumables.SelectedRows(0).Cells("consumable_id").Value)

            ' Create and show the ConsumableDetailsViewerFrm
            Dim detailsForm As New ConsumableDetailsViewerFrm(consumableId)
            detailsForm.ShowDialog()

            ' Refresh the grid in case any changes were made
            LoadConsumables()

        Catch ex As Exception
            MessageBox.Show("Error viewing consumable details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EditConsumable(sender As Object, e As EventArgs)
        If dgvConsumables.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a consumable to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim consumableId As Integer = Convert.ToInt32(dgvConsumables.SelectedRows(0).Cells("consumable_id").Value)
        Dim editForm As New AddEditConsumableFrm(consumableId)
        If editForm.ShowDialog() = DialogResult.OK Then
            LoadConsumables()
            LogActivity(gCurrentUserId, "Consumable Updated", "consumables", consumableId, "Consumable information updated")
        End If
    End Sub

    Private Sub DeleteConsumable(sender As Object, e As EventArgs)
        If dgvConsumables.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a consumable to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim consumableId As Integer = Convert.ToInt32(dgvConsumables.SelectedRows(0).Cells("consumable_id").Value)
        Dim code As String = dgvConsumables.SelectedRows(0).Cells("Code").Value.ToString()
        Dim name As String = dgvConsumables.SelectedRows(0).Cells("Consumable Name").Value.ToString()

        Dim result = MessageBox.Show($"Are you sure you want to delete this consumable?" & vbCrLf & vbCrLf &
                                    $"Code: {code}" & vbCrLf &
                                    $"Name: {name}" & vbCrLf & vbCrLf &
                                    "This action cannot be undone!",
                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    If conn Is Nothing Then Return

                    Dim checkQuery As String = "SELECT COUNT(*) FROM consumable_issuance WHERE consumable_id = @consumableId"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@consumableId", consumableId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("This consumable cannot be deleted because it has issuance history.",
                                          "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    Dim deleteQuery As String = "DELETE FROM consumables WHERE consumable_id = @consumableId"
                    Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@consumableId", consumableId)
                        deleteCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Consumable deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LogActivity(gCurrentUserId, "Consumable Deleted", "consumables", consumableId, $"Deleted consumable: {code} - {name}")
                    LoadConsumables()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting consumable: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub LogActivity(userId As Integer, actionType As String, tableName As String, recordId As Integer, description As String)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description, ip_address) 
                                       VALUES (@userId, @actionType, @tableName, @recordId, @description, @ipAddress)"

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
            Debug.WriteLine("Error logging activity: " & ex.Message)
        End Try
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