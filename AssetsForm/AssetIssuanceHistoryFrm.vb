Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing

Public Class AssetIssuanceHistoryFrm
    Private currentUserId As Integer = 0
    Private searchTimer As Timer

    Public Sub New()
        InitializeComponent()
        ' Get current user ID from global variable
        currentUserId = gCurrentUserId
    End Sub

    Private Sub AssetIssuanceHistoryFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadFilterData()
        LoadIssuanceHistory()
    End Sub

    ''' <summary>
    ''' Initialize form settings and styles
    ''' </summary>
    Private Sub InitializeForm()
        ' Style DataGridView
        StyleDataGridView(dgvIssuanceHistory)

        ' Initialize search timer
        searchTimer = New Timer()
        searchTimer.Interval = 500 ' 500ms delay
        AddHandler searchTimer.Tick, Sub()
                                         searchTimer.Stop()
                                         LoadIssuanceHistory()
                                     End Sub

        ' Set date filters to default range (last 30 days to today)
        dtpStartDate.Value = Date.Today.AddDays(-30)
        dtpEndDate.Value = Date.Today
    End Sub

    ''' <summary>
    ''' Style DataGridView
    ''' </summary>
    Private Sub StyleDataGridView(dgv As DataGridView)
        With dgv
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
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)

            ' Grid style
            .GridColor = Color.FromArgb(189, 195, 199)
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .RowTemplate.Height = 35
        End With
    End Sub

#Region "Load Data"

    ''' <summary>
    ''' Load filter data (Categories, Departments, Status)
    ''' </summary>
    Private Sub LoadFilterData()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Load Asset Categories
                Dim categoryQuery As String = "SELECT category_id, category_name FROM asset_categories ORDER BY category_name"
                Using cmd As New MySqlCommand(categoryQuery, conn)
                    cboCategory.Items.Clear()
                    cboCategory.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Categories"))

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
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

                ' Load Departments
                Dim deptQuery As String = "SELECT department_id, department_name FROM departments WHERE status = 'Active' ORDER BY department_name"
                Using cmd As New MySqlCommand(deptQuery, conn)
                    cboDepartment.Items.Clear()
                    cboDepartment.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Departments"))

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cboDepartment.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("department_id"),
                                reader.GetString("department_name")
                            ))
                        End While
                    End Using
                End Using

                cboDepartment.DisplayMember = "Value"
                cboDepartment.ValueMember = "Key"
                cboDepartment.SelectedIndex = 0

                ' Load Status Options
                cboStatus.Items.Clear()
                cboStatus.Items.Add(New KeyValuePair(Of String, String)("ALL", "All Status"))
                cboStatus.Items.Add(New KeyValuePair(Of String, String)("Active", "Active"))
                cboStatus.Items.Add(New KeyValuePair(Of String, String)("Returned", "Returned"))
                cboStatus.Items.Add(New KeyValuePair(Of String, String)("Lost", "Lost"))
                cboStatus.Items.Add(New KeyValuePair(Of String, String)("Damaged", "Damaged"))

                cboStatus.DisplayMember = "Value"
                cboStatus.ValueMember = "Key"
                cboStatus.SelectedIndex = 0

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading filter data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load complete issuance history with filters
    ''' </summary>
    Private Sub LoadIssuanceHistory()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Build query - Get ALL issuance records (Active, Returned, Lost, Damaged)
                Dim query As String = "
                    SELECT 
                        ai.issuance_id AS 'ID',
                        a.asset_tag AS 'Asset Tag',
                        a.asset_name AS 'Asset Name',
                        ac.category_name AS 'Category',
                        asub.subcategory_name AS 'Subcategory',
                        e.employee_number AS 'Employee No.',
                        CONCAT(e.first_name, ' ', COALESCE(e.middle_name, ''), ' ', e.last_name) AS 'Employee Name',
                        d.department_name AS 'Department',
                        DATE_FORMAT(ai.issue_date, '%Y-%m-%d %H:%i') AS 'Issue Date',
                        DATE_FORMAT(ai.expected_return_date, '%Y-%m-%d') AS 'Expected Return',
                        DATE_FORMAT(ai.actual_return_date, '%Y-%m-%d %H:%i') AS 'Actual Return',
                        ai.status AS 'Status',
                        ai.return_condition AS 'Return Condition',
                        CONCAT(u.first_name, ' ', u.last_name) AS 'Issued By',
                        DATEDIFF(COALESCE(ai.actual_return_date, NOW()), ai.issue_date) AS 'Days Issued'
                    FROM asset_issuance ai
                    INNER JOIN assets a ON ai.asset_id = a.asset_id
                    LEFT JOIN asset_categories ac ON a.category_id = ac.category_id
                    LEFT JOIN asset_subcategories asub ON a.subcategory_id = asub.subcategory_id
                    INNER JOIN employees e ON ai.employee_id = e.employee_id
                    INNER JOIN departments d ON e.department_id = d.department_id
                    INNER JOIN users u ON ai.issued_by = u.user_id
                    WHERE 1=1"

                Dim parameters As New List(Of MySqlParameter)

                ' Asset Tag/Name filter
                If Not String.IsNullOrWhiteSpace(txtSearchAsset.Text) Then
                    query &= " AND (a.asset_tag LIKE @assetSearch OR a.asset_name LIKE @assetSearch)"
                    parameters.Add(New MySqlParameter("@assetSearch", "%" & txtSearchAsset.Text.Trim() & "%"))
                End If

                ' Employee Name filter
                If Not String.IsNullOrWhiteSpace(txtSearchEmployee.Text) Then
                    query &= " AND (e.employee_number LIKE @empSearch 
                              OR e.first_name LIKE @empSearch 
                              OR e.last_name LIKE @empSearch 
                              OR CONCAT(e.first_name, ' ', e.last_name) LIKE @empSearch)"
                    parameters.Add(New MySqlParameter("@empSearch", "%" & txtSearchEmployee.Text.Trim() & "%"))
                End If

                ' Category filter
                If cboCategory.SelectedIndex > 0 Then
                    Dim selectedCategory = DirectCast(cboCategory.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND a.category_id = @categoryId"
                    parameters.Add(New MySqlParameter("@categoryId", selectedCategory.Key))
                End If

                ' Department filter
                If cboDepartment.SelectedIndex > 0 Then
                    Dim selectedDept = DirectCast(cboDepartment.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND e.department_id = @departmentId"
                    parameters.Add(New MySqlParameter("@departmentId", selectedDept.Key))
                End If

                ' Status filter
                If cboStatus.SelectedIndex > 0 Then
                    Dim selectedStatus = DirectCast(cboStatus.SelectedItem, KeyValuePair(Of String, String))
                    If selectedStatus.Key <> "ALL" Then
                        query &= " AND ai.status = @status"
                        parameters.Add(New MySqlParameter("@status", selectedStatus.Key))
                    End If
                End If

                ' Date range filter
                query &= " AND DATE(ai.issue_date) BETWEEN @startDate AND @endDate"
                parameters.Add(New MySqlParameter("@startDate", dtpStartDate.Value.Date))
                parameters.Add(New MySqlParameter("@endDate", dtpEndDate.Value.Date))

                ' Order by most recent first
                query &= " ORDER BY ai.issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    ' Add all parameters
                    For Each param In parameters
                        cmd.Parameters.Add(param)
                    Next

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvIssuanceHistory.DataSource = dt

                        ' Hide ID column
                        If dgvIssuanceHistory.Columns.Contains("ID") Then
                            dgvIssuanceHistory.Columns("ID").Visible = False
                        End If

                        ' Color-code rows based on status
                        For Each row As DataGridViewRow In dgvIssuanceHistory.Rows
                            If Not row.IsNewRow Then
                                Dim status As String = row.Cells("Status").Value.ToString()
                                Select Case status
                                    Case "Active"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 247, 255) ' Light blue
                                    Case "Returned"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230) ' Light green
                                    Case "Lost"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235) ' Light red
                                    Case "Damaged"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 230) ' Light orange
                                End Select
                            End If
                        Next

                        ' Update record count
                        lblRecordCount.Text = $"Total Records: {dt.Rows.Count}"
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading issuance history: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Event Handlers - Search and Filters"

    ''' <summary>
    ''' Search button click
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadIssuanceHistory()
    End Sub

    ''' <summary>
    ''' Clear filters button
    ''' </summary>
    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        ' Clear text boxes
        txtSearchAsset.Clear()
        txtSearchEmployee.Clear()

        ' Reset combo boxes
        cboCategory.SelectedIndex = 0
        cboDepartment.SelectedIndex = 0
        cboStatus.SelectedIndex = 0

        ' Reset date range
        dtpStartDate.Value = Date.Today.AddDays(-30)
        dtpEndDate.Value = Date.Today

        ' Reload data
        LoadIssuanceHistory()
    End Sub

    ''' <summary>
    ''' Asset search text changed with delay
    ''' </summary>
    Private Sub txtSearchAsset_TextChanged(sender As Object, e As EventArgs) Handles txtSearchAsset.TextChanged
        searchTimer.Stop()
        searchTimer.Start()
    End Sub

    ''' <summary>
    ''' Employee search text changed with delay
    ''' </summary>
    Private Sub txtSearchEmployee_TextChanged(sender As Object, e As EventArgs) Handles txtSearchEmployee.TextChanged
        searchTimer.Stop()
        searchTimer.Start()
    End Sub

#End Region

#Region "Event Handlers - Action Buttons"

    ''' <summary>
    ''' Refresh data
    ''' </summary>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadIssuanceHistory()
        MessageBox.Show("Data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' View details of selected issuance
    ''' </summary>
    'Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
    '    If dgvIssuanceHistory.SelectedRows.Count = 0 Then
    '        MessageBox.Show("Please select an issuance record to view details.", "No Selection",
    '                      MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Return
    '    End If

    '    Try
    '        Dim issuanceId As Integer = Convert.ToInt32(dgvIssuanceHistory.SelectedRows(0).Cells("ID").Value)

    '        ' Open details form (you can create a separate form for this)
    '        Dim detailsForm As New IssuanceDetailsViewFrm(issuanceId)
    '        detailsForm.ShowDialog()

    '    Catch ex As Exception
    '        MessageBox.Show("Error viewing details: " & ex.Message, "Error",
    '                      MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    ''' <summary>
    ''' Return asset
    ''' </summary>
    Private Sub btnReturnAsset_Click(sender As Object, e As EventArgs) Handles btnReturnAsset.Click
        If dgvIssuanceHistory.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an active issuance to return.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim status As String = dgvIssuanceHistory.SelectedRows(0).Cells("Status").Value.ToString()

            If status <> "Active" Then
                MessageBox.Show("Only active issuances can be returned.", "Invalid Status",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim issuanceId As Integer = Convert.ToInt32(dgvIssuanceHistory.SelectedRows(0).Cells("ID").Value)
            Dim assetTag As String = dgvIssuanceHistory.SelectedRows(0).Cells("Asset Tag").Value.ToString()
            Dim employeeName As String = dgvIssuanceHistory.SelectedRows(0).Cells("Employee Name").Value.ToString()

            ' Confirm return
            Dim result As DialogResult = MessageBox.Show(
                $"Return asset '{assetTag}' from {employeeName}?",
                "Confirm Return",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            'If result = DialogResult.Yes Then
            '    ' Open return asset form
            '    Dim returnForm As New ReturnAssetFrm(issuanceId, assetTag, employeeName)
            '    If returnForm.ShowDialog() = DialogResult.OK Then
            '        LoadIssuanceHistory()
            '        MessageBox.Show("Asset returned successfully!", "Success",
            '                      MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'End If

        Catch ex As Exception
            MessageBox.Show("Error returning asset: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Export to Excel
    ''' </summary>
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If dgvIssuanceHistory.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "No Data",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files|*.xlsx|CSV Files|*.csv"
            saveFileDialog.Title = "Export Issuance History"
            saveFileDialog.FileName = $"Asset_Issuance_History_{Date.Today:yyyyMMdd}"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                If saveFileDialog.FileName.EndsWith(".csv") Then
                    ExportToCSV(saveFileDialog.FileName)
                Else
                    ExportToExcel(saveFileDialog.FileName)
                End If

                MessageBox.Show("Data exported successfully!", "Export Complete",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error exporting data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Print report
    ''' </summary>
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvIssuanceHistory.Rows.Count = 0 Then
            MessageBox.Show("No data to print.", "No Data",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' Implement print functionality
            MessageBox.Show("Print functionality will be implemented here.", "Print",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error printing: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Export Functions"

    ''' <summary>
    ''' Export to CSV
    ''' </summary>
    Private Sub ExportToCSV(filePath As String)
        Dim csv As New System.Text.StringBuilder()

        ' Add headers
        Dim headers As New List(Of String)
        For Each column As DataGridViewColumn In dgvIssuanceHistory.Columns
            If column.Visible Then
                headers.Add(column.HeaderText)
            End If
        Next
        csv.AppendLine(String.Join(",", headers))

        ' Add rows
        For Each row As DataGridViewRow In dgvIssuanceHistory.Rows
            If Not row.IsNewRow Then
                Dim cells As New List(Of String)
                For Each cell As DataGridViewCell In row.Cells
                    If dgvIssuanceHistory.Columns(cell.ColumnIndex).Visible Then
                        Dim value As String = If(cell.Value?.ToString(), "")
                        ' Escape commas and quotes
                        If value.Contains(",") OrElse value.Contains("""") Then
                            value = """" & value.Replace("""", """""") & """"
                        End If
                        cells.Add(value)
                    End If
                Next
                csv.AppendLine(String.Join(",", cells))
            End If
        Next

        System.IO.File.WriteAllText(filePath, csv.ToString())
    End Sub

    ''' <summary>
    ''' Export to Excel (basic implementation)
    ''' </summary>
    Private Sub ExportToExcel(filePath As String)
        ' For full Excel support, you would need EPPlus or ClosedXML NuGet package
        ' For now, we'll export as CSV with .xlsx extension
        ExportToCSV(filePath)
    End Sub

#End Region

#Region "Utility Functions"

    ''' <summary>
    ''' Log activity to database
    ''' </summary>
    Private Sub LogActivity(actionType As String, tableName As String, recordId As Integer, description As String)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

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


#End Region

End Class