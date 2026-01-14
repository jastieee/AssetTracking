'----- ViewEmployeeConsumableHistoryFrm.vb -----
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO

Public Class ViewEmployeeConsumableHistoryFrm
    Private employeeId As Integer
    Private employeeName As String
    Private employeeNumber As String

    Public Sub New(empId As Integer, empName As String, empNumber As String)
        InitializeComponent()
        employeeId = empId
        employeeName = empName
        employeeNumber = empNumber
    End Sub

    Private Sub ViewEmployeeConsumableHistoryFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadCategories()
        LoadHistory()
    End Sub

    Private Sub InitializeForm()
        StyleDataGridView()
        lblEmployeeInfo.Text = $"Employee: {employeeName} - {employeeNumber}"

        ' Set date range to last 30 days by default
        dtpStartDate.Value = DateTime.Now.AddDays(-30)
        dtpEndDate.Value = DateTime.Now
    End Sub

    Private Sub StyleDataGridView()
        With dgvHistory
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

    Private Sub LoadCategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT consumable_category_id, category_name FROM consumable_categories ORDER BY category_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboCategoryFilter.Items.Clear()
                        cboCategoryFilter.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Categories"))

                        While reader.Read()
                            cboCategoryFilter.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("consumable_category_id"),
                                reader.GetString("category_name")
                            ))
                        End While
                    End Using
                End Using

                cboCategoryFilter.DisplayMember = "Value"
                cboCategoryFilter.ValueMember = "Key"
                cboCategoryFilter.SelectedIndex = 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadHistory()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    ci.issuance_id AS 'ID',
                    ci.issue_date AS 'Issue Date',
                    c.consumable_code AS 'Code',
                    c.consumable_name AS 'Consumable Name',
                    cc.category_name AS 'Category',
                    cs.subcategory_name AS 'Subcategory',
                    ci.quantity_issued AS 'Quantity',
                    c.unit_of_measure AS 'Unit',
                    (ci.quantity_issued * c.unit_cost) AS 'Total Cost',
                    ci.purpose AS 'Purpose',
                    ci.notes AS 'Notes',
                    CONCAT(u.first_name, ' ', u.last_name) AS 'Issued By',
                    d.department_name AS 'Department'
                    FROM consumable_issuance ci
                    INNER JOIN consumables c ON ci.consumable_id = c.consumable_id
                    LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id
                    LEFT JOIN consumable_subcategories cs ON c.subcategory_id = cs.subcategory_id
                    INNER JOIN users u ON ci.issued_by = u.user_id
                    INNER JOIN departments d ON ci.department_id = d.department_id
                    WHERE ci.employee_id = @employeeId
                    AND DATE(ci.issue_date) BETWEEN @startDate AND @endDate"

                Dim parameters As New List(Of MySqlParameter)
                parameters.Add(New MySqlParameter("@employeeId", employeeId))
                parameters.Add(New MySqlParameter("@startDate", dtpStartDate.Value.Date))
                parameters.Add(New MySqlParameter("@endDate", dtpEndDate.Value.Date))

                If cboCategoryFilter.SelectedIndex > 0 Then
                    Dim selectedCategory = DirectCast(cboCategoryFilter.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND c.category_id = @categoryId"
                    parameters.Add(New MySqlParameter("@categoryId", selectedCategory.Key))
                End If

                query &= " ORDER BY ci.issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    For Each param In parameters
                        cmd.Parameters.Add(param)
                    Next

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvHistory.DataSource = dt

                        If dgvHistory.Columns.Contains("ID") Then
                            dgvHistory.Columns("ID").Visible = False
                        End If

                        If dgvHistory.Columns.Contains("Issue Date") Then
                            dgvHistory.Columns("Issue Date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                        End If

                        If dgvHistory.Columns.Contains("Total Cost") Then
                            dgvHistory.Columns("Total Cost").DefaultCellStyle.Format = "₱#,##0.00"
                        End If

                        ' Calculate totals
                        Dim totalRecords As Integer = dt.Rows.Count
                        Dim totalQuantity As Integer = 0

                        For Each row As DataRow In dt.Rows
                            totalQuantity += Convert.ToInt32(row("Quantity"))
                        Next

                        lblTotalRecords.Text = $"Total Records: {totalRecords}"
                        lblTotalQuantity.Text = $"Total Quantity Issued: {totalQuantity}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboCategoryFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategoryFilter.SelectedIndexChanged
        If cboCategoryFilter.SelectedIndex <> -1 Then
            LoadHistory()
        End If
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        If dtpStartDate.Value > dtpEndDate.Value Then
            MessageBox.Show("Start date cannot be greater than end date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpStartDate.Value = dtpEndDate.Value.AddDays(-30)
            Return
        End If
        LoadHistory()
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        If dtpEndDate.Value < dtpStartDate.Value Then
            MessageBox.Show("End date cannot be less than start date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpEndDate.Value = dtpStartDate.Value.AddDays(30)
            Return
        End If
        LoadHistory()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvHistory.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV File (*.csv)|*.csv"
            saveDialog.FileName = $"ConsumableHistory_{employeeNumber}_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportToCSV(saveDialog.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show("Error exporting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToCSV(filePath As String)
        Try
            Using writer As New StreamWriter(filePath)
                ' Write header with employee info
                writer.WriteLine($"Employee Consumable Issuance History")
                writer.WriteLine($"Employee: {employeeName}")
                writer.WriteLine($"Employee Number: {employeeNumber}")
                writer.WriteLine($"Date Range: {dtpStartDate.Value:yyyy-MM-dd} to {dtpEndDate.Value:yyyy-MM-dd}")
                writer.WriteLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
                writer.WriteLine()

                ' Write column headers
                Dim headers As New List(Of String)
                For Each column As DataGridViewColumn In dgvHistory.Columns
                    If column.Visible Then
                        headers.Add(column.HeaderText)
                    End If
                Next
                writer.WriteLine(String.Join(",", headers))

                ' Write data rows
                For Each row As DataGridViewRow In dgvHistory.Rows
                    If Not row.IsNewRow Then
                        Dim cells As New List(Of String)
                        For Each column As DataGridViewColumn In dgvHistory.Columns
                            If column.Visible Then
                                Dim value As String = If(row.Cells(column.Index).Value?.ToString(), "")
                                value = value.Replace("""", """""")
                                If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbCrLf) Then
                                    value = """" & value & """"
                                End If
                                cells.Add(value)
                            End If
                        Next
                        writer.WriteLine(String.Join(",", cells))
                    End If
                Next

                ' Write summary
                writer.WriteLine()
                writer.WriteLine($"Summary:")
                writer.WriteLine($"{lblTotalRecords.Text}")
                writer.WriteLine($"{lblTotalQuantity.Text}")
            End Using

            MessageBox.Show($"Data exported successfully to:{vbCrLf}{filePath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Log activity
            LogActivity(gCurrentUserId, "Consumable History Export", "consumable_issuance", employeeId,
                       $"Exported consumable history for employee {employeeNumber}")

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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