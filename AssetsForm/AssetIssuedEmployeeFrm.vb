Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing
Imports QRCoder ' Make sure to install QRCoder NuGet package

Public Class AssetIssuedEmployeeFrm
    Private currentEmployeeId As Integer = 0
    Private searchTimer As Timer

    Private Sub AssetIssuedEmployeeFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadDepartments()
        LoadStatusFilters()
        LoadEmployees()
    End Sub

    ''' <summary>
    ''' Initialize form settings and styles
    ''' </summary>
    Private Sub InitializeForm()
        ' Style DataGridViews
        StyleDataGridView(dgvEmployees)
        StyleDataGridView(dgvIssuedItems)

        ' Initialize search timer
        searchTimer = New Timer()
        searchTimer.Interval = 500 ' 500ms delay
        AddHandler searchTimer.Tick, Sub()
                                         searchTimer.Stop()
                                         LoadEmployees()
                                     End Sub

        ' Clear employee details
        ClearEmployeeDetails()

        ' Set button initial states
        btnIssueAsset.Enabled = False
        btnViewHistory.Enabled = False
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
        End With
    End Sub

#Region "Load Data"

    ''' <summary>
    ''' Load status filters
    ''' </summary>
    Private Sub LoadStatusFilters()
        cboStatusFilter.Items.Clear()
        cboStatusFilter.Items.Add(New KeyValuePair(Of String, String)("ALL", "All Employees"))
        cboStatusFilter.Items.Add(New KeyValuePair(Of String, String)("NO_ITEMS", "Without Assets (Priority)"))
        cboStatusFilter.Items.Add(New KeyValuePair(Of String, String)("HAS_ITEMS", "With Assets"))

        cboStatusFilter.DisplayMember = "Value"
        cboStatusFilter.ValueMember = "Key"
        cboStatusFilter.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Load departments for filter
    ''' </summary>
    Private Sub LoadDepartments()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT department_id, department_name FROM departments WHERE status = 'Active' ORDER BY department_name"

                Using cmd As New MySqlCommand(query, conn)
                    cboDepartmentFilter.Items.Clear()
                    cboDepartmentFilter.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Departments"))

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
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
            MessageBox.Show("Error loading departments: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load employees - prioritizing those without assets
    ''' </summary>
    Private Sub LoadEmployees()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Base query - prioritize employees without assets
                Dim query As String = "SELECT 
                    e.employee_id AS 'ID',
                    e.employee_number AS 'Employee No.',
                    CONCAT(e.first_name, ' ', COALESCE(e.middle_name, ''), ' ', e.last_name) AS 'Employee Name',
                    d.department_name AS 'Department',
                    ep.position_name AS 'Position',
                    (SELECT COUNT(*) FROM asset_issuance ai WHERE ai.employee_id = e.employee_id AND ai.status = 'Active') AS 'Total Assets',
                    CASE 
                        WHEN (SELECT COUNT(*) FROM asset_issuance ai WHERE ai.employee_id = e.employee_id AND ai.status = 'Active') = 0 
                        THEN 1 ELSE 0 
                    END AS 'priority_flag'
                    FROM employees e
                    INNER JOIN departments d ON e.department_id = d.department_id
                    INNER JOIN employee_positions ep ON e.position_id = ep.position_id
                    WHERE e.employment_status = 'Active'"

                ' Apply filters
                Dim parameters As New List(Of MySqlParameter)

                ' Department filter
                If cboDepartmentFilter.SelectedIndex > 0 Then
                    Dim selectedDept = DirectCast(cboDepartmentFilter.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND e.department_id = @departmentId"
                    parameters.Add(New MySqlParameter("@departmentId", selectedDept.Key))
                End If

                ' Status filter
                If cboStatusFilter.SelectedIndex > 0 Then
                    Dim selectedStatus = DirectCast(cboStatusFilter.SelectedItem, KeyValuePair(Of String, String))
                    If selectedStatus.Key = "NO_ITEMS" Then
                        query &= " AND NOT EXISTS (SELECT 1 FROM asset_issuance ai WHERE ai.employee_id = e.employee_id AND ai.status = 'Active')"
                    ElseIf selectedStatus.Key = "HAS_ITEMS" Then
                        query &= " AND EXISTS (SELECT 1 FROM asset_issuance ai WHERE ai.employee_id = e.employee_id AND ai.status = 'Active')"
                    End If
                End If

                ' Search filter
                If Not String.IsNullOrWhiteSpace(txtSearchEmployee.Text) Then
                    query &= " AND (e.employee_number LIKE @search 
                              OR e.first_name LIKE @search 
                              OR e.last_name LIKE @search 
                              OR CONCAT(e.first_name, ' ', e.last_name) LIKE @search)"
                    parameters.Add(New MySqlParameter("@search", "%" & txtSearchEmployee.Text.Trim() & "%"))
                End If

                ' Order by: Priority first (no assets), then by employee number
                query &= " ORDER BY priority_flag DESC, e.employee_number"

                Using cmd As New MySqlCommand(query, conn)
                    For Each param In parameters
                        cmd.Parameters.Add(param)
                    Next

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvEmployees.DataSource = dt

                        ' Hide ID and priority_flag columns
                        If dgvEmployees.Columns.Contains("ID") Then
                            dgvEmployees.Columns("ID").Visible = False
                        End If
                        If dgvEmployees.Columns.Contains("priority_flag") Then
                            dgvEmployees.Columns("priority_flag").Visible = False
                        End If

                        ' Highlight employees without assets (in light green)
                        For Each row As DataGridViewRow In dgvEmployees.Rows
                            If Not row.IsNewRow Then
                                Dim totalAssets As Integer = Convert.ToInt32(row.Cells("Total Assets").Value)
                                If totalAssets = 0 Then
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230) ' Light green
                                End If
                            End If
                        Next

                        ' Update count
                        lblRecordCount.Text = $"Total Employees: {dt.Rows.Count}"
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading employees: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load employee details
    ''' </summary>
    Private Sub LoadEmployeeDetails(employeeId As Integer)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    e.employee_id,
                    e.employee_number,
                    e.qr_code_data,
                    CONCAT(e.first_name, ' ', COALESCE(e.middle_name, ''), ' ', e.last_name) AS full_name,
                    e.email,
                    e.phone_number,
                    d.department_name,
                    ep.position_name
                    FROM employees e
                    INNER JOIN departments d ON e.department_id = d.department_id
                    INNER JOIN employee_positions ep ON e.position_id = ep.position_id
                    WHERE e.employee_id = @employeeId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@employeeId", employeeId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            currentEmployeeId = employeeId
                            lblEmployeeName.Text = reader.GetString("full_name")
                            lblEmployeeNumber.Text = $"ID: {reader.GetString("employee_number")}"
                            lblEmployeeDepartment.Text = $"🏢 Department: {reader.GetString("department_name")}"
                            lblEmployeePosition.Text = $"💼 Position: {reader.GetString("position_name")}"
                            lblEmployeePhone.Text = $"📞 {If(reader.IsDBNull(reader.GetOrdinal("phone_number")), "N/A", reader.GetString("phone_number"))}"
                            lblEmployeeEmail.Text = $"📧 {If(reader.IsDBNull(reader.GetOrdinal("email")), "N/A", reader.GetString("email"))}"

                            ' Generate QR Code
                            GenerateQRCode(reader.GetString("qr_code_data"))

                            ' Enable buttons
                            btnIssueAsset.Enabled = True
                            btnViewHistory.Enabled = True
                        End If
                    End Using
                End Using

                ' Load issued assets
                LoadIssuedAssets(employeeId)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading employee details: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load issued assets for selected employee
    ''' </summary>
    Private Sub LoadIssuedAssets(employeeId As Integer)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Query for active assets only
                Dim query As String = "
                    SELECT 
                        a.asset_tag AS 'Asset Tag',
                        a.asset_name AS 'Asset Name',
                        ac.category_name AS 'Category',
                        asub.subcategory_name AS 'Subcategory',
                        a.serial_number AS 'Serial Number',
                        DATE_FORMAT(ai.issue_date, '%Y-%m-%d') AS 'Issue Date',
                        ai.status AS 'Status',
                        ai.issuance_id AS 'ID'
                    FROM asset_issuance ai
                    INNER JOIN assets a ON ai.asset_id = a.asset_id
                    LEFT JOIN asset_categories ac ON a.category_id = ac.category_id
                    LEFT JOIN asset_subcategories asub ON a.subcategory_id = asub.subcategory_id
                    WHERE ai.employee_id = @employeeId AND ai.status = 'Active'
                    ORDER BY ai.issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@employeeId", employeeId)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvIssuedItems.DataSource = dt

                        ' Hide ID column
                        If dgvIssuedItems.Columns.Contains("ID") Then
                            dgvIssuedItems.Columns("ID").Visible = False
                        End If

                        ' Update total assets count
                        lblTotalItemsValue.Text = dt.Rows.Count.ToString()
                        lblItemsTitle.Text = $"📦 Currently Issued Assets to {lblEmployeeNumber.Text}"
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading issued assets: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "QR Code Generation"

    ''' <summary>
    ''' Generate QR Code for employee
    ''' </summary>
    Private Sub GenerateQRCode(qrData As String)
        Try
            Using qrGenerator As New QRCodeGenerator()
                Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q)
                Using qrCode As New QRCode(qrCodeData)
                    Dim qrCodeImage As Bitmap = qrCode.GetGraphic(20)
                    picQRCode.Image = qrCodeImage
                End Using
            End Using
        Catch ex As Exception
            ' If QRCoder is not installed, show a placeholder
            picQRCode.Image = Nothing
            Debug.WriteLine("QR Code generation error: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Issue Assets"

    ''' <summary>
    ''' Issue Asset to Employee
    ''' </summary>
    Private Sub btnIssueAsset_Click(sender As Object, e As EventArgs) Handles btnIssueAsset.Click
        If currentEmployeeId = 0 Then
            MessageBox.Show("Please select an employee first.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' Open the Issue Asset Form
            Dim issueForm As New IssueAssetFrm(currentEmployeeId, lblEmployeeName.Text)
            If issueForm.ShowDialog() = DialogResult.OK Then
                ' Refresh the employee list and details
                LoadEmployees()
                LoadEmployeeDetails(currentEmployeeId)
            End If

        Catch ex As Exception
            MessageBox.Show("Error opening issue asset form: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    ''' <summary>
    ''' Employee selection changed
    ''' </summary>
    Private Sub dgvEmployees_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEmployees.SelectionChanged
        If dgvEmployees.SelectedRows.Count > 0 Then
            Dim employeeId As Integer = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("ID").Value)
            LoadEmployeeDetails(employeeId)
        Else
            ClearEmployeeDetails()
        End If
    End Sub

    ''' <summary>
    ''' Clear employee details display
    ''' </summary>
    Private Sub ClearEmployeeDetails()
        currentEmployeeId = 0
        lblEmployeeName.Text = "Select an employee to view"
        lblEmployeeNumber.Text = "ID: EMP-000000"
        lblEmployeeDepartment.Text = "🏢 Department: ---"
        lblEmployeePosition.Text = "💼 Position: ---"
        lblEmployeePhone.Text = "📞 +63 123 456 789"
        lblEmployeeEmail.Text = "📧 employee@email.com"
        lblTotalItemsValue.Text = "0"
        lblItemsTitle.Text = "📦 Currently Issued Assets to ID"
        picQRCode.Image = Nothing

        dgvIssuedItems.DataSource = Nothing

        btnIssueAsset.Enabled = False
        btnViewHistory.Enabled = False
    End Sub

    ''' <summary>
    ''' Search text changed with delay
    ''' </summary>
    Private Sub txtSearchEmployee_TextChanged(sender As Object, e As EventArgs) Handles txtSearchEmployee.TextChanged
        searchTimer.Stop()
        searchTimer.Start()
    End Sub

    ''' <summary>
    ''' Department filter changed
    ''' </summary>
    Private Sub cboDepartmentFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartmentFilter.SelectedIndexChanged
        If cboDepartmentFilter.SelectedIndex <> -1 Then
            LoadEmployees()
        End If
    End Sub

    ''' <summary>
    ''' Status filter changed
    ''' </summary>
    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        If cboStatusFilter.SelectedIndex <> -1 Then
            LoadEmployees()
        End If
    End Sub

    ''' <summary>
    ''' Refresh data
    ''' </summary>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadEmployees()
        If currentEmployeeId > 0 Then
            LoadEmployeeDetails(currentEmployeeId)
        End If
        MessageBox.Show("Data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' View issuance history for employee
    ''' </summary>
    Private Sub btnViewHistory_Click(sender As Object, e As EventArgs) Handles btnViewHistory.Click
        If currentEmployeeId = 0 Then
            MessageBox.Show("Please select an employee first.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' Open the View History Form
            Dim historyForm As New ViewEmployeeHistoryFrm(currentEmployeeId, lblEmployeeName.Text)
            historyForm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error loading history: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Utility Functions"

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

#End Region

End Class