Imports MySql.Data.MySqlClient
Imports System.Data

Public Class ManageAssetsFrm
    Private currentAssetId As Integer = 0

    Private Sub ManageAssetsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadCategories()

        ' Set default filter values after categories are loaded
        cboStatus.SelectedIndex = 0
        cboCondition.SelectedIndex = 0

        LoadAssets()
    End Sub

    ''' <summary>
    ''' Initialize form settings
    ''' </summary>
    Private Sub InitializeForm()
        ' Style DataGridView
        StyleDataGridView()

        ' Add context menu for right-click
        AddContextMenu()

        ' Set default filter values (after initialization)
        ' This will be done after LoadCategories() completes
    End Sub

    ''' <summary>
    ''' Style the DataGridView
    ''' </summary>
    Private Sub StyleDataGridView()
        With dgvAssets
            ' Header style
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 40
            .EnableHeadersVisualStyles = False

            ' Row style
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.FromArgb(52, 73, 94)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .RowTemplate.Height = 35
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)

            ' Grid style
            .GridColor = Color.FromArgb(189, 195, 199)
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        End With
    End Sub

    ''' <summary>
    ''' Add context menu for right-click actions
    ''' </summary>
    Private Sub AddContextMenu()
        Dim contextMenu As New ContextMenuStrip()

        Dim viewItem As New ToolStripMenuItem("View Details", Nothing, AddressOf ViewAssetDetails)
        Dim editItem As New ToolStripMenuItem("Edit Asset", Nothing, AddressOf EditAsset)
        Dim deleteItem As New ToolStripMenuItem("Delete Asset", Nothing, AddressOf DeleteAsset)

        contextMenu.Items.AddRange({viewItem, editItem, New ToolStripSeparator(), deleteItem})
        dgvAssets.ContextMenuStrip = contextMenu
    End Sub

    ''' <summary>
    ''' Load asset categories
    ''' </summary>
    Private Sub LoadCategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Load categories
                Dim query As String = "SELECT category_id, category_name FROM asset_categories ORDER BY category_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboCategory.Items.Clear()
                        cboCategory.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Categories"))

                        While reader.Read()
                            cboCategory.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("category_id"),
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
            MessageBox.Show("Error loading categories: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load subcategories based on selected category
    ''' </summary>
    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        Try
            If cboCategory.SelectedIndex = -1 Then Return

            Dim selectedItem = DirectCast(cboCategory.SelectedItem, KeyValuePair(Of Integer, String))
            Dim categoryId As Integer = selectedItem.Key

            cboSubcategory.Items.Clear()
            cboSubcategory.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Subcategories"))

            If categoryId = 0 Then
                ' "All Categories" selected - disable subcategory and don't load
                cboSubcategory.Enabled = False
                cboSubcategory.DisplayMember = "Value"
                cboSubcategory.ValueMember = "Key"
                cboSubcategory.SelectedIndex = 0
                ' Trigger LoadAssets only if this is not the initial load
                If cboStatus.SelectedIndex <> -1 Then
                    LoadAssets()
                End If
                Return
            End If

            cboSubcategory.Enabled = True

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT subcategory_id, subcategory_name 
                                      FROM asset_subcategories 
                                      WHERE category_id = @categoryId 
                                      ORDER BY subcategory_name"

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

            ' Trigger LoadAssets only if this is not the initial load
            If cboStatus.SelectedIndex <> -1 Then
                LoadAssets()
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading subcategories: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load assets with filters
    ''' </summary>
    Private Sub LoadAssets()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Build query with filters
                Dim query As String = "SELECT 
                    a.asset_id,
                    a.asset_tag AS 'Asset Tag',
                    a.asset_name AS 'Asset Name',
                    ac.category_name AS 'Category',
                    asub.subcategory_name AS 'Subcategory',
                    a.serial_number AS 'Serial Number',
                    a.model AS 'Model',
                    a.manufacturer AS 'Manufacturer',
                    a.status AS 'Status',
                    a.condition_status AS 'Condition',
                    d.department_name AS 'Current Department',
                    DATE_FORMAT(a.purchase_date, '%Y-%m-%d') AS 'Purchase Date'
                    FROM assets a
                    LEFT JOIN asset_categories ac ON a.category_id = ac.category_id
                    LEFT JOIN asset_subcategories asub ON a.subcategory_id = asub.subcategory_id
                    LEFT JOIN departments d ON a.current_department_id = d.department_id
                    WHERE 1=1"

                ' Apply filters
                Dim parameters As New List(Of MySqlParameter)

                ' Search filter
                If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                    query &= " AND (a.asset_tag LIKE @search OR a.asset_name LIKE @search OR a.serial_number LIKE @search)"
                    parameters.Add(New MySqlParameter("@search", "%" & txtSearch.Text.Trim() & "%"))
                End If

                ' Category filter
                If cboCategory.SelectedIndex > 0 Then
                    Dim selectedCategory = DirectCast(cboCategory.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND a.category_id = @categoryId"
                    parameters.Add(New MySqlParameter("@categoryId", selectedCategory.Key))
                End If

                ' Subcategory filter
                If cboSubcategory.Enabled AndAlso cboSubcategory.SelectedIndex > 0 Then
                    Dim selectedSubcategory = DirectCast(cboSubcategory.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND a.subcategory_id = @subcategoryId"
                    parameters.Add(New MySqlParameter("@subcategoryId", selectedSubcategory.Key))
                End If

                ' Status filter
                If cboStatus.SelectedIndex > 0 Then
                    Dim status As String = cboStatus.SelectedItem.ToString()
                    query &= " AND a.status = @status"
                    parameters.Add(New MySqlParameter("@status", status))
                End If

                ' Condition filter
                If cboCondition.SelectedIndex > 0 Then
                    Dim condition As String = cboCondition.SelectedItem.ToString()
                    query &= " AND a.condition_status = @condition"
                    parameters.Add(New MySqlParameter("@condition", condition))
                End If

                query &= " ORDER BY a.created_at DESC"

                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters
                    For Each param In parameters
                        cmd.Parameters.Add(param)
                    Next

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvAssets.DataSource = dt

                        ' Hide asset_id column
                        If dgvAssets.Columns.Contains("asset_id") Then
                            dgvAssets.Columns("asset_id").Visible = False
                        End If

                        ' Update record count
                        lblRecordCount.Text = $"Total Assets: {dt.Rows.Count}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading assets: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Handle search text change with delay
    ''' </summary>
    Private searchTimer As Timer
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If searchTimer Is Nothing Then
            searchTimer = New Timer()
            searchTimer.Interval = 500 ' 500ms delay
            AddHandler searchTimer.Tick, Sub()
                                             searchTimer.Stop()
                                             LoadAssets()
                                         End Sub
        End If

        searchTimer.Stop()
        searchTimer.Start()
    End Sub

    ''' <summary>
    ''' Handle filter changes
    ''' </summary>
    Private Sub cboSubcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubcategory.SelectedIndexChanged
        ' Only load if form is fully initialized
        If cboSubcategory.SelectedIndex <> -1 AndAlso cboStatus.SelectedIndex <> -1 Then
            LoadAssets()
        End If
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        If cboStatus.SelectedIndex <> -1 Then LoadAssets()
    End Sub

    Private Sub cboCondition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCondition.SelectedIndexChanged
        If cboCondition.SelectedIndex <> -1 Then LoadAssets()
    End Sub

    ''' <summary>
    ''' Clear all filters
    ''' </summary>
    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        txtSearch.Clear()
        cboCategory.SelectedIndex = 0
        cboSubcategory.SelectedIndex = 0
        cboStatus.SelectedIndex = 0
        cboCondition.SelectedIndex = 0
        LoadAssets()
    End Sub

    ''' <summary>
    ''' Add new asset
    ''' </summary>
    Private Sub btnAddAsset_Click(sender As Object, e As EventArgs) Handles btnAddAsset.Click
        Dim addForm As New AddEditAssetFrm()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadAssets()
            LogActivity(gCurrentUserId, "Asset Created", "assets", 0, "New asset added")
        End If
    End Sub

    ''' <summary>
    ''' Refresh data
    ''' </summary>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAssets()
    End Sub

    ''' <summary>
    ''' Print QR code for selected asset
    ''' </summary>
    Private Sub btnPrintQR_Click(sender As Object, e As EventArgs)
        If dgvAssets.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an asset to print QR code.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim assetTag As String = dgvAssets.SelectedRows(0).Cells("Asset Tag").Value.ToString()
        MessageBox.Show($"Print QR Code for: {assetTag}" & vbCrLf & vbCrLf &
                       "QR Code printing functionality will be implemented here.",
                       "Print QR Code", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Export assets to Excel/CSV
    ''' </summary>
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvAssets.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV File (*.csv)|*.csv|Excel File (*.xlsx)|*.xlsx"
            saveDialog.FileName = $"Assets_Export_{DateTime.Now:yyyyMMdd_HHmmss}"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                If saveDialog.FilterIndex = 1 Then
                    ExportToCSV(saveDialog.FileName)
                Else
                    MessageBox.Show("Excel export requires additional libraries. CSV export is available.",
                                  "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ExportToCSV(saveDialog.FileName.Replace(".xlsx", ".csv"))
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error exporting data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Export DataGridView to CSV
    ''' </summary>
    Private Sub ExportToCSV(filePath As String)
        Try
            Using writer As New IO.StreamWriter(filePath)
                ' Write headers
                Dim headers As New List(Of String)
                For Each column As DataGridViewColumn In dgvAssets.Columns
                    If column.Visible Then
                        headers.Add(column.HeaderText)
                    End If
                Next
                writer.WriteLine(String.Join(",", headers))

                ' Write rows
                For Each row As DataGridViewRow In dgvAssets.Rows
                    If Not row.IsNewRow Then
                        Dim cells As New List(Of String)
                        For Each column As DataGridViewColumn In dgvAssets.Columns
                            If column.Visible Then
                                Dim value As String = If(row.Cells(column.Index).Value?.ToString(), "")
                                ' Escape commas and quotes
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

            MessageBox.Show($"Data exported successfully to:{vbCrLf}{filePath}",
                          "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LogActivity(gCurrentUserId, "Asset Export", "assets", 0, "Exported asset list to CSV")

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Handle double-click to view details
    ''' </summary>
    Private Sub dgvAssets_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAssets.CellDoubleClick
        If e.RowIndex >= 0 Then
            ViewAssetDetails(Nothing, Nothing)
        End If
    End Sub

    ''' <summary>
    ''' View asset details
    ''' </summary>
    Private Sub ViewAssetDetails(sender As Object, e As EventArgs)
        If dgvAssets.SelectedRows.Count = 0 Then Return

        Dim assetId As Integer = Convert.ToInt32(dgvAssets.SelectedRows(0).Cells("asset_id").Value)

        Dim detailsForm As New AssetDetailsViewerFrm(assetId)
        detailsForm.ShowDialog()

        ' Refresh in case anything changed
        LoadAssets()
    End Sub

    ''' <summary>
    ''' Edit selected asset
    ''' </summary>
    Private Sub EditAsset(sender As Object, e As EventArgs)
        If dgvAssets.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an asset to edit.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim assetId As Integer = Convert.ToInt32(dgvAssets.SelectedRows(0).Cells("asset_id").Value)

        Dim editForm As New AddEditAssetFrm(assetId)
        If editForm.ShowDialog() = DialogResult.OK Then
            LoadAssets()
            LogActivity(gCurrentUserId, "Asset Updated", "assets", assetId, "Asset information updated")
        End If
    End Sub

    ''' <summary>
    ''' Delete selected asset
    ''' </summary>
    Private Sub DeleteAsset(sender As Object, e As EventArgs)
        If dgvAssets.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an asset to delete.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim assetId As Integer = Convert.ToInt32(dgvAssets.SelectedRows(0).Cells("asset_id").Value)
        Dim assetTag As String = dgvAssets.SelectedRows(0).Cells("Asset Tag").Value.ToString()
        Dim assetName As String = dgvAssets.SelectedRows(0).Cells("Asset Name").Value.ToString()

        Dim result = MessageBox.Show($"Are you sure you want to delete this asset?" & vbCrLf & vbCrLf &
                                    $"Asset Tag: {assetTag}" & vbCrLf &
                                    $"Asset Name: {assetName}" & vbCrLf & vbCrLf &
                                    "This action cannot be undone!",
                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    If conn Is Nothing Then Return

                    ' Check if asset has been issued
                    Dim checkQuery As String = "SELECT COUNT(*) FROM asset_issuance WHERE asset_id = @assetId"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@assetId", assetId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("This asset cannot be deleted because it has issuance history." & vbCrLf &
                                          "Please use the disposal request feature instead.",
                                          "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Delete asset
                    Dim deleteQuery As String = "DELETE FROM assets WHERE asset_id = @assetId"
                    Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@assetId", assetId)
                        deleteCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Asset deleted successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LogActivity(gCurrentUserId, "Asset Deleted", "assets", assetId,
                               $"Deleted asset: {assetTag} - {assetName}")

                    LoadAssets()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting asset: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Log activity to database
    ''' </summary>
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