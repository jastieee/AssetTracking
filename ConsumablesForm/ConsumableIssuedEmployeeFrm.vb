'----- ConsumableIssuedEmployeeFrm.vb -----
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing
Imports QRCoder ' You'll need to install QRCoder NuGet package

Public Class ConsumableIssuedEmployeeFrm
    Private selectedEmployeeId As Integer = 0
    Private searchTimer As Timer

    Private Sub ConsumableIssuedEmployeeFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadDepartments()
        LoadEmployees()
    End Sub

    Private Sub InitializeForm()
        StyleDataGridView(dgvEmployees)
        StyleDataGridView(dgvIssuedConsumables)
        ClearEmployeeInfo()
    End Sub

    Private Sub StyleDataGridView(dgv As DataGridView)
        With dgv
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

    Private Sub LoadDepartments()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT department_id, department_name FROM departments WHERE status = 'Active' ORDER BY department_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboDepartmentFilter.Items.Clear()
                        cboDepartmentFilter.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Departments"))

                        While reader.Read()
                            cboDepartmentFilter.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("department_id"),
                                reader.GetString("department_name")
                            ))
                        End While
                    End Using
                End Using

                cboDepartmentFilter.DisplayMember = "Value"
                cboDepartmentFilter.ValueMember = "Key"
                cboDepartmentFilter.SelectedIndex = 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadEmployees()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    e.employee_id AS 'ID',
                    e.employee_number AS 'Employee #',
                    CONCAT(e.first_name, ' ', IFNULL(e.middle_name, ''), ' ', e.last_name) AS 'Full Name',
                    d.department_name AS 'Department',
                    ep.position_name AS 'Position',
                    e.email AS 'Email'
                    FROM employees e
                    INNER JOIN departments d ON e.department_id = d.department_id
                    INNER JOIN employee_positions ep ON e.position_id = ep.position_id
                    WHERE e.employment_status = 'Active'"

                Dim parameters As New List(Of MySqlParameter)

                If Not String.IsNullOrWhiteSpace(txtSearchEmployee.Text) Then
                    query &= " AND (e.employee_number LIKE @search OR 
                              e.first_name LIKE @search OR 
                              e.last_name LIKE @search OR 
                              e.email LIKE @search)"
                    parameters.Add(New MySqlParameter("@search", "%" & txtSearchEmployee.Text.Trim() & "%"))
                End If

                If cboDepartmentFilter.SelectedIndex > 0 Then
                    Dim selectedDept = DirectCast(cboDepartmentFilter.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND e.department_id = @deptId"
                    parameters.Add(New MySqlParameter("@deptId", selectedDept.Key))
                End If

                query &= " ORDER BY e.employee_number"

                Using cmd As New MySqlCommand(query, conn)
                    For Each param In parameters
                        cmd.Parameters.Add(param)
                    Next

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvEmployees.DataSource = dt

                        If dgvEmployees.Columns.Contains("ID") Then
                            dgvEmployees.Columns("ID").Visible = False
                        End If

                        lblRecordCount.Text = $"Total Employees: {dt.Rows.Count}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading employees: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearchEmployee_TextChanged(sender As Object, e As EventArgs) Handles txtSearchEmployee.TextChanged
        If searchTimer Is Nothing Then
            searchTimer = New Timer()
            searchTimer.Interval = 500
            AddHandler searchTimer.Tick, Sub()
                                             searchTimer.Stop()
                                             LoadEmployees()
                                         End Sub
        End If
        searchTimer.Stop()
        searchTimer.Start()
    End Sub

    Private Sub cboDepartmentFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartmentFilter.SelectedIndexChanged
        If cboDepartmentFilter.SelectedIndex <> -1 Then
            LoadEmployees()
        End If
    End Sub

    Private Sub dgvEmployees_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEmployees.SelectionChanged
        If dgvEmployees.SelectedRows.Count > 0 Then
            selectedEmployeeId = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("ID").Value)
            LoadEmployeeDetails()
            LoadIssuedConsumables()
        Else
            ClearEmployeeInfo()
        End If
    End Sub

    Private Sub LoadEmployeeDetails()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    e.*,
                    d.department_name,
                    ep.position_name
                    FROM employees e
                    INNER JOIN departments d ON e.department_id = d.department_id
                    INNER JOIN employee_positions ep ON e.position_id = ep.position_id
                    WHERE e.employee_id = @employeeId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@employeeId", selectedEmployeeId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim fullName As String = $"{reader("first_name")} {If(IsDBNull(reader("middle_name")), "", reader("middle_name").ToString())} {reader("last_name")}"
                            lblEmployeeName.Text = fullName.Trim()
                            lblEmployeeNumber.Text = $"ID: {reader("employee_number")}"
                            lblEmployeeDepartment.Text = $"🏢 Department: {reader("department_name")}"
                            lblEmployeePosition.Text = $"💼 Position: {reader("position_name")}"
                            lblEmployeePhone.Text = $"📞 {If(IsDBNull(reader("phone_number")), "N/A", reader("phone_number"))}"
                            lblEmployeeEmail.Text = $"📧 {If(IsDBNull(reader("email")), "N/A", reader("email"))}"

                            ' Generate QR Code
                            GenerateQRCode(reader("qr_code_data").ToString())
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading employee details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateQRCode(data As String)
        Try
            Dim qrGenerator As New QRCodeGenerator()
            Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode As New QRCode(qrCodeData)
            picQRCode.Image = qrCode.GetGraphic(4)
        Catch ex As Exception
            ' QRCoder not available, show placeholder
            picQRCode.Image = Nothing
            Debug.WriteLine("QRCoder not available: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadIssuedConsumables()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    ci.issuance_id AS 'ID',
                    ci.issue_date AS 'Issue Date',
                    c.consumable_code AS 'Code',
                    c.consumable_name AS 'Consumable',
                    cc.category_name AS 'Category',
                    ci.quantity_issued AS 'Quantity',
                    c.unit_of_measure AS 'Unit',
                    ci.purpose AS 'Purpose',
                    CONCAT(u.first_name, ' ', u.last_name) AS 'Issued By'
                    FROM consumable_issuance ci
                    INNER JOIN consumables c ON ci.consumable_id = c.consumable_id
                    LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id
                    INNER JOIN users u ON ci.issued_by = u.user_id
                    WHERE ci.employee_id = @employeeId
                    ORDER BY ci.issue_date DESC
                    LIMIT 10"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@employeeId", selectedEmployeeId)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvIssuedConsumables.DataSource = dt

                        If dgvIssuedConsumables.Columns.Contains("ID") Then
                            dgvIssuedConsumables.Columns("ID").Visible = False
                        End If

                        If dgvIssuedConsumables.Columns.Contains("Issue Date") Then
                            dgvIssuedConsumables.Columns("Issue Date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                        End If

                        lblTotalItemsValue.Text = dt.Rows.Count.ToString()
                        lblItemsTitle.Text = $"📦 Recently Issued Consumables to {lblEmployeeNumber.Text}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading issued consumables: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearEmployeeInfo()
        lblEmployeeName.Text = "Select an employee to view"
        lblEmployeeNumber.Text = "ID: EMP-000000"
        lblEmployeeDepartment.Text = "🏢 Department: ---"
        lblEmployeePosition.Text = "💼 Position: ---"
        lblEmployeePhone.Text = "📞 +63 123 456 789"
        lblEmployeeEmail.Text = "📧 employee@email.com"
        picQRCode.Image = Nothing
        dgvIssuedConsumables.DataSource = Nothing
        lblTotalItemsValue.Text = "0"
        lblItemsTitle.Text = "📦 Recently Issued Consumables to ID"
    End Sub

    Private Sub btnIssueConsumable_Click(sender As Object, e As EventArgs) Handles btnIssueConsumable.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an employee first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim employeeId As Integer = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("ID").Value)
            Dim employeeName As String = dgvEmployees.SelectedRows(0).Cells("Full Name").Value.ToString()

            ' Get department ID
            Dim departmentId As Integer = 0
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT department_id FROM employees WHERE employee_id = @employeeId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@employeeId", employeeId)
                    departmentId = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using

            Dim issueForm As New IssueConsumableFrm(employeeId, employeeName, departmentId)
            If issueForm.ShowDialog() = DialogResult.OK Then
                LoadIssuedConsumables() ' Refresh the issued consumables list
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening issue form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewHistory_Click(sender As Object, e As EventArgs) Handles btnViewHistory.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an employee first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim employeeId As Integer = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("ID").Value)
            Dim employeeName As String = dgvEmployees.SelectedRows(0).Cells("Full Name").Value.ToString()
            Dim employeeNumber As String = dgvEmployees.SelectedRows(0).Cells("Employee #").Value.ToString()

            Dim historyForm As New ViewEmployeeConsumableHistoryFrm(employeeId, employeeName, employeeNumber)
            historyForm.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Error opening history form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadEmployees()
        If selectedEmployeeId > 0 Then
            LoadIssuedConsumables()
        End If
    End Sub
End Class