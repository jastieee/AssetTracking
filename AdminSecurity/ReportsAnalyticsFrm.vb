Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO

Public Class ReportsAnalyticsFrm

    Private Sub ReportsAnalyticsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            InitializeControls()
            LoadDashboardKPIs()
            LoadDashboardCharts()
        Catch ex As Exception
            MessageBox.Show("Error loading form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeControls()
        cboAssetReportType.SelectedIndex = 0
        cboConsumableReportType.SelectedIndex = 0
        cboRequestReportType.SelectedIndex = 0
        dtpRequestStartDate.Value = DateTime.Now.AddMonths(-1)
        dtpRequestEndDate.Value = DateTime.Now
        cboEmployeeReportType.SelectedIndex = 0
        LoadDepartments()
    End Sub

    Private Sub LoadDepartments()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT department_id, department_name FROM departments WHERE status = 'Active' ORDER BY department_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboDepartmentFilter.Items.Clear()
                        cboDepartmentFilter.Items.Add("All Departments")
                        While reader.Read()
                            cboDepartmentFilter.Items.Add(New DepartmentItem With {
                                .DepartmentId = Convert.ToInt32(reader("department_id")),
                                .DepartmentName = reader("department_name").ToString()
                            })
                        End While
                        cboDepartmentFilter.SelectedIndex = 0
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "Dashboard Methods"

    Private Sub LoadDashboardKPIs()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM assets", conn)
                    lblKPI1Value.Text = cmd.ExecuteScalar().ToString()
                End Using

                Using cmd As New MySqlCommand("SELECT ROUND(SUM(CASE WHEN status = 'Issued' THEN 1 ELSE 0 END) * 100.0 / COUNT(*), 2) FROM assets", conn)
                    Dim result = cmd.ExecuteScalar()
                    lblKPI2Value.Text = If(IsDBNull(result), "0", result.ToString()) & "%"
                End Using

                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM consumables WHERE total_quantity_in_stock <= reorder_level", conn)
                    lblKPI3Value.Text = cmd.ExecuteScalar().ToString()
                End Using

                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM (SELECT request_id FROM asset_requests WHERE status = 'Pending' UNION ALL SELECT request_id FROM consumable_requests WHERE status = 'Pending') AS combined", conn)
                    lblKPI4Value.Text = cmd.ExecuteScalar().ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading KPIs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadDashboardCharts()
        LoadAssetsByStatus()
        LoadTopConsumables()
    End Sub

    Private Sub LoadAssetsByStatus()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Using cmd As New MySqlCommand("SELECT status AS 'Status', COUNT(*) AS 'Count' FROM assets GROUP BY status ORDER BY COUNT(*) DESC", conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvAssetsByStatus.DataSource = dt
                        If dgvAssetsByStatus.Columns.Count > 0 Then
                            dgvAssetsByStatus.Columns("Status").Width = 200
                            dgvAssetsByStatus.Columns("Count").Width = 100
                            dgvAssetsByStatus.Columns("Count").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading assets by status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadTopConsumables()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Dim query As String = "SELECT c.consumable_name AS 'Consumable', SUM(ci.quantity_issued) AS 'Total Issued' " &
                    "FROM consumable_issuance ci JOIN consumables c ON ci.consumable_id = c.consumable_id " &
                    "GROUP BY c.consumable_id, c.consumable_name ORDER BY SUM(ci.quantity_issued) DESC LIMIT 10"
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvTopConsumables.DataSource = dt
                        If dgvTopConsumables.Columns.Count > 0 Then
                            dgvTopConsumables.Columns("Consumable").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            dgvTopConsumables.Columns("Total Issued").Width = 120
                            dgvTopConsumables.Columns("Total Issued").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading top consumables: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Asset Reports"

    Private Sub btnGenerateAssetReport_Click(sender As Object, e As EventArgs) Handles btnGenerateAssetReport.Click
        If cboAssetReportType.SelectedIndex < 0 Then
            MessageBox.Show("Please select a report type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Select Case cboAssetReportType.SelectedItem.ToString()
            Case "Complete Asset Inventory" : GenerateCompleteAssetInventory()
            Case "Assets by Status" : GenerateAssetsByStatus()
            Case "Assets by Category" : GenerateAssetsByCategory()
            Case "Assets by Department" : GenerateAssetsByDepartment()
            Case "Asset Issuance History" : GenerateAssetIssuanceHistory()
            Case "Overdue Assets" : GenerateOverdueAssets()
            Case "Assets Under Maintenance" : GenerateAssetsUnderMaintenance()
            Case "Idle Assets (Never Issued)" : GenerateIdleAssets()
        End Select
    End Sub

    Private Sub GenerateCompleteAssetInventory()
        Try
            Dim query As String = "SELECT a.asset_tag AS 'Asset Tag', a.asset_name AS 'Asset Name', " &
                "ac.category_name AS 'Category', asub.subcategory_name AS 'Subcategory', " &
                "a.serial_number AS 'Serial Number', a.model AS 'Model', a.manufacturer AS 'Manufacturer', " &
                "a.status AS 'Status', a.condition_status AS 'Condition', a.purchase_date AS 'Purchase Date' " &
                "FROM assets a " &
                "LEFT JOIN asset_categories ac ON a.category_id = ac.category_id " &
                "LEFT JOIN asset_subcategories asub ON a.subcategory_id = asub.subcategory_id " &
                "ORDER BY a.asset_tag"
            LoadDataToGrid(query, dgvAssetReport, lblAssetReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateAssetsByStatus()
        Try
            Dim query As String = "SELECT a.status AS 'Status', a.asset_tag AS 'Asset Tag', " &
                "a.asset_name AS 'Asset Name', ac.category_name AS 'Category', a.condition_status AS 'Condition' " &
                "FROM assets a LEFT JOIN asset_categories ac ON a.category_id = ac.category_id " &
                "ORDER BY a.status, a.asset_tag"
            LoadDataToGrid(query, dgvAssetReport, lblAssetReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateAssetsByCategory()
        Try
            Dim query As String = "SELECT ac.category_name AS 'Category', asub.subcategory_name AS 'Subcategory', " &
                "COUNT(*) AS 'Total Assets', SUM(CASE WHEN a.status = 'In Stock' THEN 1 ELSE 0 END) AS 'In Stock', " &
                "SUM(CASE WHEN a.status = 'Issued' THEN 1 ELSE 0 END) AS 'Issued' " &
                "FROM assets a LEFT JOIN asset_categories ac ON a.category_id = ac.category_id " &
                "LEFT JOIN asset_subcategories asub ON a.subcategory_id = asub.subcategory_id " &
                "GROUP BY ac.category_name, asub.subcategory_name ORDER BY ac.category_name, asub.subcategory_name"
            LoadDataToGrid(query, dgvAssetReport, lblAssetReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateAssetsByDepartment()
        Try
            Dim query As String = "SELECT d.department_name AS 'Department', COUNT(DISTINCT ai.asset_id) AS 'Total Assets', " &
                "COUNT(DISTINCT e.employee_id) AS 'Employees' FROM asset_issuance ai " &
                "JOIN employees e ON ai.employee_id = e.employee_id JOIN departments d ON e.department_id = d.department_id " &
                "WHERE ai.status = 'Active' GROUP BY d.department_name ORDER BY COUNT(DISTINCT ai.asset_id) DESC"
            LoadDataToGrid(query, dgvAssetReport, lblAssetReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateAssetIssuanceHistory()
        Try
            Dim query As String = "SELECT a.asset_tag AS 'Asset Tag', a.asset_name AS 'Asset Name', " &
                "CONCAT(e.first_name, ' ', e.last_name) AS 'Issued To', d.department_name AS 'Department', " &
                "ai.issue_date AS 'Issue Date', ai.expected_return_date AS 'Expected Return', " &
                "ai.actual_return_date AS 'Actual Return', ai.status AS 'Status' " &
                "FROM asset_issuance ai JOIN assets a ON ai.asset_id = a.asset_id " &
                "JOIN employees e ON ai.employee_id = e.employee_id JOIN departments d ON e.department_id = d.department_id " &
                "ORDER BY ai.issue_date DESC"
            LoadDataToGrid(query, dgvAssetReport, lblAssetReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateOverdueAssets()
        Try
            Dim query As String = "SELECT a.asset_tag AS 'Asset Tag', a.asset_name AS 'Asset Name', " &
                "CONCAT(e.first_name, ' ', e.last_name) AS 'Employee', e.phone_number AS 'Phone', d.department_name AS 'Department', " &
                "ai.issue_date AS 'Issue Date', ai.expected_return_date AS 'Expected Return', " &
                "DATEDIFF(CURDATE(), ai.expected_return_date) AS 'Days Overdue' FROM asset_issuance ai " &
                "JOIN assets a ON ai.asset_id = a.asset_id JOIN employees e ON ai.employee_id = e.employee_id " &
                "JOIN departments d ON e.department_id = d.department_id " &
                "WHERE ai.status = 'Active' AND ai.expected_return_date < CURDATE() " &
                "ORDER BY DATEDIFF(CURDATE(), ai.expected_return_date) DESC"
            LoadDataToGrid(query, dgvAssetReport, lblAssetReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateAssetsUnderMaintenance()
        Try
            Dim query As String = "SELECT a.asset_tag AS 'Asset Tag', a.asset_name AS 'Asset Name', " &
                "ac.category_name AS 'Category', a.condition_status AS 'Condition', a.updated_at AS 'Status Updated' " &
                "FROM assets a LEFT JOIN asset_categories ac ON a.category_id = ac.category_id " &
                "WHERE a.status = 'Under Maintenance' ORDER BY a.updated_at DESC"
            LoadDataToGrid(query, dgvAssetReport, lblAssetReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateIdleAssets()
        Try
            Dim query As String = "SELECT a.asset_tag AS 'Asset Tag', a.asset_name AS 'Asset Name', " &
                "ac.category_name AS 'Category', asub.subcategory_name AS 'Subcategory', " &
                "a.purchase_date AS 'Purchase Date', a.condition_status AS 'Condition' FROM assets a " &
                "LEFT JOIN asset_categories ac ON a.category_id = ac.category_id " &
                "LEFT JOIN asset_subcategories asub ON a.subcategory_id = asub.subcategory_id " &
                "WHERE a.asset_id NOT IN (SELECT DISTINCT asset_id FROM asset_issuance) AND a.status = 'In Stock' " &
                "ORDER BY a.purchase_date"
            LoadDataToGrid(query, dgvAssetReport, lblAssetReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportAssetReport_Click(sender As Object, e As EventArgs) Handles btnExportAssetReport.Click
        ExportToCSV(dgvAssetReport, "AssetReport")
    End Sub

#End Region

#Region "Consumable Reports"

    Private Sub btnGenerateConsumableReport_Click(sender As Object, e As EventArgs) Handles btnGenerateConsumableReport.Click
        If cboConsumableReportType.SelectedIndex < 0 Then
            MessageBox.Show("Please select a report type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Select Case cboConsumableReportType.SelectedItem.ToString()
            Case "Stock Status Report" : GenerateStockStatusReport()
            Case "Low Stock Items" : GenerateLowStockReport()
            Case "Reorder Alert Report" : GenerateReorderAlertReport()
            Case "Consumable Issuance History" : GenerateConsumableIssuanceHistory()
            Case "Consumption by Category" : GenerateConsumptionByCategory()
            Case "Consumption by Department" : GenerateConsumptionByDepartment()
            Case "Top 10 Most Used Items" : GenerateTopMostUsedItems()
        End Select
    End Sub

    Private Sub GenerateStockStatusReport()
        Try
            Dim query As String = "SELECT c.consumable_code AS 'Code', c.consumable_name AS 'Name', " &
                "cc.category_name AS 'Category', c.unit_of_measure AS 'Unit', c.total_quantity_in_stock AS 'Current Stock', " &
                "c.minimum_stock_level AS 'Min Level', c.reorder_level AS 'Reorder Level', " &
                "CASE WHEN c.total_quantity_in_stock <= c.minimum_stock_level THEN 'Critical' " &
                "WHEN c.total_quantity_in_stock <= c.reorder_level THEN 'Low' ELSE 'Sufficient' END AS 'Status' " &
                "FROM consumables c LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id " &
                "ORDER BY c.total_quantity_in_stock ASC"
            LoadDataToGrid(query, dgvConsumableReport, lblConsumableReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateLowStockReport()
        Try
            Dim query As String = "SELECT c.consumable_code AS 'Code', c.consumable_name AS 'Name', cc.category_name AS 'Category', " &
                "c.total_quantity_in_stock AS 'Current Stock', c.reorder_level AS 'Reorder Level', c.unit_of_measure AS 'Unit', " &
                "(c.reorder_level - c.total_quantity_in_stock) AS 'Needed Quantity' FROM consumables c " &
                "LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id " &
                "WHERE c.total_quantity_in_stock <= c.reorder_level ORDER BY c.total_quantity_in_stock ASC"
            LoadDataToGrid(query, dgvConsumableReport, lblConsumableReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateReorderAlertReport()
        Try
            Dim query As String = "SELECT c.consumable_code AS 'Code', c.consumable_name AS 'Name', cc.category_name AS 'Category', " &
                "c.total_quantity_in_stock AS 'Current Stock', c.minimum_stock_level AS 'Min Level', " &
                "CASE WHEN c.total_quantity_in_stock <= c.minimum_stock_level THEN 'URGENT' ELSE 'Medium' END AS 'Priority', " &
                "(c.reorder_level - c.total_quantity_in_stock) AS 'Qty Needed' FROM consumables c " &
                "LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id " &
                "WHERE c.total_quantity_in_stock <= c.reorder_level ORDER BY c.total_quantity_in_stock ASC"
            LoadDataToGrid(query, dgvConsumableReport, lblConsumableReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateConsumableIssuanceHistory()
        Try
            Dim query As String = "SELECT c.consumable_code AS 'Code', c.consumable_name AS 'Name', " &
                "CONCAT(e.first_name, ' ', e.last_name) AS 'Issued To', d.department_name AS 'Department', " &
                "ci.quantity_issued AS 'Quantity', ci.issue_date AS 'Issue Date', ci.purpose AS 'Purpose' " &
                "FROM consumable_issuance ci JOIN consumables c ON ci.consumable_id = c.consumable_id " &
                "JOIN employees e ON ci.employee_id = e.employee_id JOIN departments d ON ci.department_id = d.department_id " &
                "ORDER BY ci.issue_date DESC"
            LoadDataToGrid(query, dgvConsumableReport, lblConsumableReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateConsumptionByCategory()
        Try
            Dim query As String = "SELECT cc.category_name AS 'Category', COUNT(DISTINCT c.consumable_id) AS 'No. of Items', " &
                "SUM(ci.quantity_issued) AS 'Total Issued', COUNT(ci.issuance_id) AS 'Transactions' " &
                "FROM consumable_issuance ci JOIN consumables c ON ci.consumable_id = c.consumable_id " &
                "LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id " &
                "GROUP BY cc.category_name ORDER BY SUM(ci.quantity_issued) DESC"
            LoadDataToGrid(query, dgvConsumableReport, lblConsumableReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateConsumptionByDepartment()
        Try
            Dim query As String = "SELECT d.department_name AS 'Department', COUNT(DISTINCT ci.consumable_id) AS 'Different Items', " &
                "SUM(ci.quantity_issued) AS 'Total Quantity', COUNT(ci.issuance_id) AS 'Transactions' " &
                "FROM consumable_issuance ci JOIN departments d ON ci.department_id = d.department_id " &
                "GROUP BY d.department_name ORDER BY SUM(ci.quantity_issued) DESC"
            LoadDataToGrid(query, dgvConsumableReport, lblConsumableReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateTopMostUsedItems()
        Try
            Dim query As String = "SELECT c.consumable_code AS 'Code', c.consumable_name AS 'Name', cc.category_name AS 'Category', " &
                "SUM(ci.quantity_issued) AS 'Total Issued', COUNT(ci.issuance_id) AS 'Times Issued', c.unit_of_measure AS 'Unit' " &
                "FROM consumable_issuance ci JOIN consumables c ON ci.consumable_id = c.consumable_id " &
                "LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id " &
                "GROUP BY c.consumable_id, c.consumable_code, c.consumable_name, cc.category_name, c.unit_of_measure " &
                "ORDER BY SUM(ci.quantity_issued) DESC LIMIT 10"
            LoadDataToGrid(query, dgvConsumableReport, lblConsumableReportCount)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportConsumableReport_Click(sender As Object, e As EventArgs) Handles btnExportConsumableReport.Click
        ExportToCSV(dgvConsumableReport, "ConsumableReport")
    End Sub

#End Region

#Region "Request Reports"

    Private Sub btnGenerateRequestReport_Click(sender As Object, e As EventArgs) Handles btnGenerateRequestReport.Click
        If cboRequestReportType.SelectedIndex < 0 Then
            MessageBox.Show("Please select a report type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Select Case cboRequestReportType.SelectedItem.ToString()
            Case "Fulfilled Requests" : GenerateFulfilledRequests()
            Case "Requests by Department" : GenerateRequestsByDepartment()
            Case "Requests by Priority" : GenerateRequestsByPriority()
        End Select
    End Sub

    Private Sub GenerateFulfilledRequests()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Dim query As String = "SELECT request_type AS 'Type', request_id AS 'Request ID', requester_name AS 'Requested By', " &
                    "requester_department AS 'Department', item_description AS 'Item', quantity AS 'Qty', " &
                    "approved_by_name AS 'Approved By', issued_by_name AS 'Issued By', fulfillment_date AS 'Fulfilled Date' " &
                    "FROM vw_pending_requests_summary WHERE status = 'Fulfilled' " &
                    "AND DATE(request_date) BETWEEN @startDate AND @endDate ORDER BY fulfillment_date DESC"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@startDate", dtpRequestStartDate.Value.Date)
                    cmd.Parameters.AddWithValue("@endDate", dtpRequestEndDate.Value.Date)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvRequestReport.DataSource = dt
                        lblRequestReportCount.Text = "Total Items: " & dt.Rows.Count.ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateRequestsByDepartment()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Dim query As String = "SELECT requester_department AS 'Department', request_type AS 'Type', COUNT(*) AS 'Total Requests', " &
                    "SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END) AS 'Pending', " &
                    "SUM(CASE WHEN status = 'Approved' THEN 1 ELSE 0 END) AS 'Approved', " &
                    "SUM(CASE WHEN status = 'Fulfilled' THEN 1 ELSE 0 END) AS 'Fulfilled', " &
                    "SUM(CASE WHEN status = 'Rejected' THEN 1 ELSE 0 END) AS 'Rejected' " &
                    "FROM vw_pending_requests_summary WHERE DATE(request_date) BETWEEN @startDate AND @endDate " &
                    "GROUP BY requester_department, request_type ORDER BY requester_department, request_type"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@startDate", dtpRequestStartDate.Value.Date)
                    cmd.Parameters.AddWithValue("@endDate", dtpRequestEndDate.Value.Date)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvRequestReport.DataSource = dt
                        lblRequestReportCount.Text = "Total Items: " & dt.Rows.Count.ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateRequestsByPriority()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Dim query As String = "SELECT priority AS 'Priority', request_type AS 'Type', COUNT(*) AS 'Total Requests', " &
                    "SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END) AS 'Pending', " &
                    "SUM(CASE WHEN status = 'Fulfilled' THEN 1 ELSE 0 END) AS 'Fulfilled', " &
                    "ROUND(AVG(DATEDIFF(COALESCE(fulfillment_date, CURDATE()), request_date)), 1) AS 'Avg Days to Fulfill' " &
                    "FROM vw_pending_requests_summary WHERE DATE(request_date) BETWEEN @startDate AND @endDate " &
                    "GROUP BY priority, request_type ORDER BY FIELD(priority, 'Urgent', 'High', 'Medium', 'Low'), request_type"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@startDate", dtpRequestStartDate.Value.Date)
                    cmd.Parameters.AddWithValue("@endDate", dtpRequestEndDate.Value.Date)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvRequestReport.DataSource = dt
                        lblRequestReportCount.Text = "Total Items: " & dt.Rows.Count.ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportRequestReport_Click(sender As Object, e As EventArgs) Handles btnExportRequestReport.Click
        ExportToCSV(dgvRequestReport, "RequestReport")
    End Sub

#End Region

#Region "Employee Reports"

    Private Sub btnGenerateEmployeeReport_Click(sender As Object, e As EventArgs) Handles btnGenerateEmployeeReport.Click
        If cboEmployeeReportType.SelectedIndex < 0 Then
            MessageBox.Show("Please select a report type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Select Case cboEmployeeReportType.SelectedItem.ToString()
            Case "Employee Asset Allocation" : GenerateEmployeeAssetAllocation()
            Case "Employee Issued Items" : GenerateEmployeeIssuedItems()
            Case "Assets by Department" : GenerateAssetsByEmployeeDepartment()
            Case "Employees with Most Assets" : GenerateEmployeesWithMostAssets()
            Case "Employee Directory" : GenerateEmployeeDirectory()
        End Select
    End Sub

    Private Sub GenerateEmployeeAssetAllocation()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Dim query As String = "SELECT e.employee_number AS 'Employee #', CONCAT(e.first_name, ' ', e.last_name) AS 'Employee Name', " &
                    "d.department_name AS 'Department', ep.position_name AS 'Position', COUNT(DISTINCT ai.asset_id) AS 'Assets Issued', " &
                    "COUNT(DISTINCT ci.consumable_id) AS 'Consumables Issued' FROM employees e " &
                    "JOIN departments d ON e.department_id = d.department_id JOIN employee_positions ep ON e.position_id = ep.position_id " &
                    "LEFT JOIN asset_issuance ai ON e.employee_id = ai.employee_id AND ai.status = 'Active' " &
                    "LEFT JOIN consumable_issuance ci ON e.employee_id = ci.employee_id WHERE e.employment_status = 'Active'"

                If cboDepartmentFilter.SelectedIndex > 0 Then
                    Dim deptItem As DepartmentItem = CType(cboDepartmentFilter.SelectedItem, DepartmentItem)
                    query &= " AND e.department_id = @deptId"
                End If

                query &= " GROUP BY e.employee_id, e.employee_number, e.first_name, e.last_name, d.department_name, ep.position_name " &
                         "ORDER BY COUNT(DISTINCT ai.asset_id) DESC"

                Using cmd As New MySqlCommand(query, conn)
                    If cboDepartmentFilter.SelectedIndex > 0 Then
                        Dim deptItem As DepartmentItem = CType(cboDepartmentFilter.SelectedItem, DepartmentItem)
                        cmd.Parameters.AddWithValue("@deptId", deptItem.DepartmentId)
                    End If
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvEmployeeReport.DataSource = dt
                        lblEmployeeReportCount.Text = "Total Items: " & dt.Rows.Count.ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateEmployeeIssuedItems()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Dim query As String = "SELECT employee_number AS 'Employee #', employee_name AS 'Employee Name', " &
                    "department_name AS 'Department', position_name AS 'Position', item_type AS 'Type', item_code AS 'Code', " &
                    "item_name AS 'Item Name', category AS 'Category', issue_date AS 'Issue Date', COALESCE(quantity, 1) AS 'Quantity' " &
                    "FROM vw_employee_issued_items WHERE 1=1"

                If cboDepartmentFilter.SelectedIndex > 0 Then
                    Dim deptItem As DepartmentItem = CType(cboDepartmentFilter.SelectedItem, DepartmentItem)
                    query &= " AND department_name = @deptName"
                End If

                query &= " ORDER BY employee_number, item_type, issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    If cboDepartmentFilter.SelectedIndex > 0 Then
                        Dim deptItem As DepartmentItem = CType(cboDepartmentFilter.SelectedItem, DepartmentItem)
                        cmd.Parameters.AddWithValue("@deptName", deptItem.DepartmentName)
                    End If
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvEmployeeReport.DataSource = dt
                        lblEmployeeReportCount.Text = "Total Items: " & dt.Rows.Count.ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateAssetsByEmployeeDepartment()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Dim query As String = "SELECT d.department_name AS 'Department', COUNT(DISTINCT ai.asset_id) AS 'Total Assets', " &
                    "COUNT(DISTINCT ai.employee_id) AS 'Employees with Assets', " &
                    "GROUP_CONCAT(DISTINCT ac.category_name SEPARATOR ', ') AS 'Asset Categories' FROM departments d " &
                    "LEFT JOIN employees e ON d.department_id = e.department_id " &
                    "LEFT JOIN asset_issuance ai ON e.employee_id = ai.employee_id AND ai.status = 'Active' " &
                    "LEFT JOIN assets a ON ai.asset_id = a.asset_id " &
                    "LEFT JOIN asset_categories ac ON a.category_id = ac.category_id WHERE d.status = 'Active'"

                If cboDepartmentFilter.SelectedIndex > 0 Then
                    Dim deptItem As DepartmentItem = CType(cboDepartmentFilter.SelectedItem, DepartmentItem)
                    query &= " AND d.department_id = @deptId"
                End If

                query &= " GROUP BY d.department_id, d.department_name ORDER BY COUNT(DISTINCT ai.asset_id) DESC"

                Using cmd As New MySqlCommand(query, conn)
                    If cboDepartmentFilter.SelectedIndex > 0 Then
                        Dim deptItem As DepartmentItem = CType(cboDepartmentFilter.SelectedItem, DepartmentItem)
                        cmd.Parameters.AddWithValue("@deptId", deptItem.DepartmentId)
                    End If
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvEmployeeReport.DataSource = dt
                        lblEmployeeReportCount.Text = "Total Items: " & dt.Rows.Count.ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateEmployeesWithMostAssets()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Dim query As String = "SELECT e.employee_number AS 'Employee #', CONCAT(e.first_name, ' ', e.last_name) AS 'Employee Name', " &
                    "d.department_name AS 'Department', ep.position_name AS 'Position', COUNT(DISTINCT ai.asset_id) AS 'Total Assets', " &
                    "GROUP_CONCAT(DISTINCT a.asset_tag ORDER BY a.asset_tag SEPARATOR ', ') AS 'Asset Tags' FROM employees e " &
                    "JOIN departments d ON e.department_id = d.department_id JOIN employee_positions ep ON e.position_id = ep.position_id " &
                    "JOIN asset_issuance ai ON e.employee_id = ai.employee_id AND ai.status = 'Active' " &
                    "JOIN assets a ON ai.asset_id = a.asset_id WHERE e.employment_status = 'Active'"

                If cboDepartmentFilter.SelectedIndex > 0 Then
                    Dim deptItem As DepartmentItem = CType(cboDepartmentFilter.SelectedItem, DepartmentItem)
                    query &= " AND e.department_id = @deptId"
                End If

                query &= " GROUP BY e.employee_id, e.employee_number, e.first_name, e.last_name, d.department_name, ep.position_name " &
                         "HAVING COUNT(DISTINCT ai.asset_id) > 0 ORDER BY COUNT(DISTINCT ai.asset_id) DESC LIMIT 20"

                Using cmd As New MySqlCommand(query, conn)
                    If cboDepartmentFilter.SelectedIndex > 0 Then
                        Dim deptItem As DepartmentItem = CType(cboDepartmentFilter.SelectedItem, DepartmentItem)
                        cmd.Parameters.AddWithValue("@deptId", deptItem.DepartmentId)
                    End If
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvEmployeeReport.DataSource = dt
                        lblEmployeeReportCount.Text = "Total Items: " & dt.Rows.Count.ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateEmployeeDirectory()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Dim query As String = "SELECT e.employee_number AS 'Employee #', " &
                    "CONCAT(e.first_name, ' ', COALESCE(e.middle_name, ''), ' ', e.last_name) AS 'Full Name', " &
                    "d.department_name AS 'Department', ep.position_name AS 'Position', e.email AS 'Email', " &
                    "e.phone_number AS 'Phone', e.employment_status AS 'Status', e.hire_date AS 'Hire Date' FROM employees e " &
                    "JOIN departments d ON e.department_id = d.department_id JOIN employee_positions ep ON e.position_id = ep.position_id " &
                    "WHERE 1=1"

                If cboDepartmentFilter.SelectedIndex > 0 Then
                    Dim deptItem As DepartmentItem = CType(cboDepartmentFilter.SelectedItem, DepartmentItem)
                    query &= " AND e.department_id = @deptId"
                End If

                query &= " ORDER BY d.department_name, e.last_name, e.first_name"

                Using cmd As New MySqlCommand(query, conn)
                    If cboDepartmentFilter.SelectedIndex > 0 Then
                        Dim deptItem As DepartmentItem = CType(cboDepartmentFilter.SelectedItem, DepartmentItem)
                        cmd.Parameters.AddWithValue("@deptId", deptItem.DepartmentId)
                    End If
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvEmployeeReport.DataSource = dt
                        lblEmployeeReportCount.Text = "Total Items: " & dt.Rows.Count.ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportEmployeeReport_Click(sender As Object, e As EventArgs) Handles btnExportEmployeeReport.Click
        ExportToCSV(dgvEmployeeReport, "EmployeeReport")
    End Sub

#End Region

#Region "Helper Methods"

    Private Sub LoadDataToGrid(query As String, grid As DataGridView, countLabel As Label)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        grid.DataSource = dt
                        countLabel.Text = "Total Items: " & dt.Rows.Count.ToString()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExportToCSV(grid As DataGridView, fileName As String)
        Try
            If grid.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv"
            saveFileDialog.FileName = fileName & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Using writer As New StreamWriter(saveFileDialog.FileName)
                    Dim headers As New List(Of String)
                    For Each column As DataGridViewColumn In grid.Columns
                        If column.Visible Then
                            headers.Add("""" & column.HeaderText.Replace("""", """""") & """")
                        End If
                    Next
                    writer.WriteLine(String.Join(",", headers))

                    For Each row As DataGridViewRow In grid.Rows
                        If Not row.IsNewRow Then
                            Dim cells As New List(Of String)
                            For Each column As DataGridViewColumn In grid.Columns
                                If column.Visible Then
                                    Dim cellValue As String = If(row.Cells(column.Index).Value IsNot Nothing,
                                                                row.Cells(column.Index).Value.ToString(), "")
                                    cells.Add("""" & cellValue.Replace("""", """""") & """")
                                End If
                            Next
                            writer.WriteLine(String.Join(",", cells))
                        End If
                    Next
                End Using

                MessageBox.Show("Report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If MessageBox.Show("Do you want to open the exported file?", "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Process.Start(saveFileDialog.FileName)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting to CSV: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class

Public Class DepartmentItem
    Public Property DepartmentId As Integer
    Public Property DepartmentName As String

    Public Overrides Function ToString() As String
        Return DepartmentName
    End Function
End Class