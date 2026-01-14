'----- ConsumableIssuanceHistoryFrm.vb -----
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class ConsumableIssuanceHistoryFrm

    Private Sub ConsumableIssuanceHistoryFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadFilters()
        LoadIssuanceHistory()
    End Sub

    Private Sub InitializeForm()
        StyleDataGridView()

        dtpStartDate.Value = DateTime.Now.AddMonths(-3)
        dtpEndDate.Value = DateTime.Now
    End Sub

    Private Sub StyleDataGridView()
        With dgvIssuanceHistory
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

    Private Sub LoadFilters()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim categoryQuery As String = "SELECT consumable_category_id, category_name FROM consumable_categories ORDER BY category_name"
                Using cmd As New MySqlCommand(categoryQuery, conn)
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

                Dim deptQuery As String = "SELECT department_id, department_name FROM departments ORDER BY department_name"
                Using cmd As New MySqlCommand(deptQuery, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboDepartment.Items.Clear()
                        cboDepartment.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Departments"))

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

                cboSubcategory.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Subcategories"))
                cboSubcategory.DisplayMember = "Value"
                cboSubcategory.ValueMember = "Key"
                cboSubcategory.SelectedIndex = 0
                cboSubcategory.Enabled = False
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading filters: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                cboSubcategory.SelectedIndex = 0
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

        Catch ex As Exception
            MessageBox.Show("Error loading subcategories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadIssuanceHistory()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    ci.issuance_id,
                    c.consumable_code AS 'Code',
                    c.consumable_name AS 'Consumable',
                    cc.category_name AS 'Category',
                    cs.subcategory_name AS 'Subcategory',
                    CONCAT(e.first_name, ' ', e.last_name) AS 'Employee',
                    e.employee_number AS 'Emp. No.',
                    d.department_name AS 'Department',
                    ci.quantity_issued AS 'Qty',
                    c.unit_of_measure AS 'Unit',
                    ci.purpose AS 'Purpose',
                    DATE_FORMAT(ci.issue_date, '%Y-%m-%d %H:%i') AS 'Issue Date',
                    CONCAT(u.first_name, ' ', u.last_name) AS 'Issued By'
                    FROM consumable_issuance ci
                    INNER JOIN consumables c ON ci.consumable_id = c.consumable_id
                    LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id
                    LEFT JOIN consumable_subcategories cs ON c.subcategory_id = cs.subcategory_id
                    INNER JOIN employees e ON ci.employee_id = e.employee_id
                    INNER JOIN departments d ON ci.department_id = d.department_id
                    INNER JOIN users u ON ci.issued_by = u.user_id
                    WHERE 1=1"

                Dim parameters As New List(Of MySqlParameter)

                If Not String.IsNullOrWhiteSpace(txtSearchConsumable.Text) Then
                    query &= " AND (c.consumable_code LIKE @searchConsumable OR c.consumable_name LIKE @searchConsumable)"
                    parameters.Add(New MySqlParameter("@searchConsumable", "%" & txtSearchConsumable.Text.Trim() & "%"))
                End If

                If Not String.IsNullOrWhiteSpace(txtSearchEmployee.Text) Then
                    query &= " AND (e.first_name LIKE @searchEmployee OR e.last_name LIKE @searchEmployee OR e.employee_number LIKE @searchEmployee)"
                    parameters.Add(New MySqlParameter("@searchEmployee", "%" & txtSearchEmployee.Text.Trim() & "%"))
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

                If cboDepartment.SelectedIndex > 0 Then
                    Dim selectedDepartment = DirectCast(cboDepartment.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND ci.department_id = @departmentId"
                    parameters.Add(New MySqlParameter("@departmentId", selectedDepartment.Key))
                End If

                query &= " AND DATE(ci.issue_date) BETWEEN @startDate AND @endDate"
                parameters.Add(New MySqlParameter("@startDate", dtpStartDate.Value.Date))
                parameters.Add(New MySqlParameter("@endDate", dtpEndDate.Value.Date))

                query &= " ORDER BY ci.issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    For Each param In parameters
                        cmd.Parameters.Add(param)
                    Next

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvIssuanceHistory.DataSource = dt

                        If dgvIssuanceHistory.Columns.Contains("issuance_id") Then
                            dgvIssuanceHistory.Columns("issuance_id").Visible = False
                        End If

                        Dim totalQuantity As Integer = 0
                        For Each row As DataRow In dt.Rows
                            totalQuantity += Convert.ToInt32(row("Qty"))
                        Next

                        lblRecordCount.Text = $"Total Records: {dt.Rows.Count}"
                        lblTotalQuantity.Text = $"Total Quantity Issued: {totalQuantity}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading issuance history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadIssuanceHistory()
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        txtSearchConsumable.Clear()
        txtSearchEmployee.Clear()
        cboCategory.SelectedIndex = 0
        cboSubcategory.SelectedIndex = 0
        cboDepartment.SelectedIndex = 0
        dtpStartDate.Value = DateTime.Now.AddMonths(-3)
        dtpEndDate.Value = DateTime.Now
        LoadIssuanceHistory()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadIssuanceHistory()
    End Sub

    Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        If dgvIssuanceHistory.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to view details.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim row As DataGridViewRow = dgvIssuanceHistory.SelectedRows(0)
        Dim details As String = $"Consumable Issuance Details:{vbCrLf}{vbCrLf}" &
                               $"Code: {row.Cells("Code").Value}{vbCrLf}" &
                               $"Consumable: {row.Cells("Consumable").Value}{vbCrLf}" &
                               $"Category: {row.Cells("Category").Value}{vbCrLf}" &
                               $"Employee: {row.Cells("Employee").Value} ({row.Cells("Emp. No.").Value}){vbCrLf}" &
                               $"Department: {row.Cells("Department").Value}{vbCrLf}" &
                               $"Quantity: {row.Cells("Qty").Value} {row.Cells("Unit").Value}{vbCrLf}" &
                               $"Purpose: {row.Cells("Purpose").Value}{vbCrLf}" &
                               $"Issue Date: {row.Cells("Issue Date").Value}{vbCrLf}" &
                               $"Issued By: {row.Cells("Issued By").Value}"

        MessageBox.Show(details, "Issuance Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvIssuanceHistory.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV File (*.csv)|*.csv"
            saveDialog.FileName = $"Consumable_Issuance_History_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

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
                writer.WriteLine("Consumable Issuance History Report")
                writer.WriteLine($"Period: {dtpStartDate.Value:yyyy-MM-dd} to {dtpEndDate.Value:yyyy-MM-dd}")
                writer.WriteLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
                writer.WriteLine()

                Dim headers As New List(Of String)
                For Each column As DataGridViewColumn In dgvIssuanceHistory.Columns
                    If column.Visible Then headers.Add(column.HeaderText)
                Next
                writer.WriteLine(String.Join(",", headers))

                For Each row As DataGridViewRow In dgvIssuanceHistory.Rows
                    If Not row.IsNewRow Then
                        Dim cells As New List(Of String)
                        For Each column As DataGridViewColumn In dgvIssuanceHistory.Columns
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

                writer.WriteLine()
                writer.WriteLine($"Summary:")
                writer.WriteLine($"Total Records: {dgvIssuanceHistory.Rows.Count}")
                writer.WriteLine($"{lblTotalQuantity.Text}")
            End Using

            MessageBox.Show($"Data exported successfully to:{vbCrLf}{filePath}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        MessageBox.Show("Print functionality will be implemented with reporting tools.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class