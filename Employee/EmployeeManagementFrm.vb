Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing

Public Class EmployeeManagementFrm
    Private currentUserId As Integer = 0
    Private searchTimer As Timer

    Public Sub New()
        InitializeComponent()
        currentUserId = gCurrentUserId
    End Sub

    Private Sub EmployeeManagementFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadFilterData()
        LoadEmployees()
    End Sub

    ''' <summary>
    ''' Initialize form settings and styles
    ''' </summary>
    Private Sub InitializeForm()
        ' Style DataGridView
        StyleDataGridView(dgvEmployees)

        ' Initialize search timer
        searchTimer = New Timer()
        searchTimer.Interval = 500 ' 500ms delay
        AddHandler searchTimer.Tick, Sub()
                                         searchTimer.Stop()
                                         LoadEmployees()
                                     End Sub

        ' Set default filter values
        cboStatus.SelectedIndex = 0
        cboEmploymentType.SelectedIndex = 0
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
    ''' Load filter data (Departments, Positions)
    ''' </summary>
    Private Sub LoadFilterData()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

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

                ' Load Positions
                Dim posQuery As String = "SELECT position_id, position_name FROM employee_positions ORDER BY position_level, position_name"
                Using cmd As New MySqlCommand(posQuery, conn)
                    cboPosition.Items.Clear()
                    cboPosition.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Positions"))

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cboPosition.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("position_id"),
                                reader.GetString("position_name")
                            ))
                        End While
                    End Using
                End Using

                cboPosition.DisplayMember = "Value"
                cboPosition.ValueMember = "Key"
                cboPosition.SelectedIndex = 0

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading filter data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load employees with filters
    ''' </summary>
    Private Sub LoadEmployees()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Build query
                Dim query As String = "
                    SELECT 
                        e.employee_id AS 'ID',
                        e.employee_number AS 'Employee No.',
                        CONCAT(e.first_name, ' ', COALESCE(e.middle_name, ''), ' ', e.last_name) AS 'Employee Name',
                        d.department_name AS 'Department',
                        ep.position_name AS 'Position',
                        e.email AS 'Email',
                        e.phone_number AS 'Phone',
                        e.employment_status AS 'Status',
                        e.employment_type AS 'Type',
                        DATE_FORMAT(e.hire_date, '%Y-%m-%d') AS 'Hire Date',
                        (SELECT COUNT(*) FROM asset_issuance ai WHERE ai.employee_id = e.employee_id AND ai.status = 'Active') AS 'Assets Issued'
                    FROM employees e
                    INNER JOIN departments d ON e.department_id = d.department_id
                    INNER JOIN employee_positions ep ON e.position_id = ep.position_id
                    WHERE 1=1"

                Dim parameters As New List(Of MySqlParameter)

                ' Search filter
                If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                    query &= " AND (e.employee_number LIKE @search 
                              OR e.first_name LIKE @search 
                              OR e.middle_name LIKE @search
                              OR e.last_name LIKE @search 
                              OR e.email LIKE @search
                              OR CONCAT(e.first_name, ' ', e.last_name) LIKE @search)"
                    parameters.Add(New MySqlParameter("@search", "%" & txtSearch.Text.Trim() & "%"))
                End If

                ' Department filter
                If cboDepartment.SelectedIndex > 0 Then
                    Dim selectedDept = DirectCast(cboDepartment.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND e.department_id = @departmentId"
                    parameters.Add(New MySqlParameter("@departmentId", selectedDept.Key))
                End If

                ' Position filter
                If cboPosition.SelectedIndex > 0 Then
                    Dim selectedPos = DirectCast(cboPosition.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND e.position_id = @positionId"
                    parameters.Add(New MySqlParameter("@positionId", selectedPos.Key))
                End If

                ' Status filter
                If cboStatus.SelectedIndex > 0 Then
                    query &= " AND e.employment_status = @status"
                    parameters.Add(New MySqlParameter("@status", cboStatus.Text))
                End If

                ' Employment Type filter
                If cboEmploymentType.SelectedIndex > 0 Then
                    query &= " AND e.employment_type = @empType"
                    parameters.Add(New MySqlParameter("@empType", cboEmploymentType.Text))
                End If

                ' Order by employee number
                query &= " ORDER BY e.employee_number"

                Using cmd As New MySqlCommand(query, conn)
                    ' Add all parameters
                    For Each param In parameters
                        cmd.Parameters.Add(param)
                    Next

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvEmployees.DataSource = dt

                        ' Hide ID column
                        If dgvEmployees.Columns.Contains("ID") Then
                            dgvEmployees.Columns("ID").Visible = False
                        End If

                        ' Color-code rows based on status
                        For Each row As DataGridViewRow In dgvEmployees.Rows
                            If Not row.IsNewRow Then
                                Dim status As String = row.Cells("Status").Value.ToString()
                                Select Case status
                                    Case "Active"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 247, 255) ' Light blue
                                    Case "On Leave"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 230) ' Light yellow
                                    Case "Resigned", "Terminated"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235) ' Light red
                                    Case "Retired"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240) ' Light gray
                                End Select
                            End If
                        Next

                        ' Update record count
                        lblRecordCount.Text = $"Total Employees: {dt.Rows.Count}"
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading employees: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Event Handlers - Search and Filters"

    ''' <summary>
    ''' Search text changed with delay
    ''' </summary>
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        searchTimer.Stop()
        searchTimer.Start()
    End Sub

    ''' <summary>
    ''' Clear filters button
    ''' </summary>
    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        ' Clear text box
        txtSearch.Clear()

        ' Reset combo boxes
        cboDepartment.SelectedIndex = 0
        cboPosition.SelectedIndex = 0
        cboStatus.SelectedIndex = 0
        cboEmploymentType.SelectedIndex = 0

        ' Reload data
        LoadEmployees()
    End Sub

#End Region

#Region "Event Handlers - Action Buttons"

    ''' <summary>
    ''' Refresh data
    ''' </summary>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadEmployees()
        MessageBox.Show("Data refreshed successfully!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Add new employee
    ''' </summary>
    Private Sub btnAddEmployee_Click(sender As Object, e As EventArgs) Handles btnAddEmployee.Click
        Try
            Dim addForm As New AddEditEmployeeFrm(0) ' 0 = Add mode
            If addForm.ShowDialog() = DialogResult.OK Then
                LoadEmployees()
                MessageBox.Show("Employee added successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error opening add employee form: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' View employee details
    ''' </summary>
    Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an employee to view details.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim employeeId As Integer = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("ID").Value)

            ' Open details form
            Dim detailsForm As New EmployeeDetailsViewFrm(employeeId)
            detailsForm.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error viewing employee details: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Edit employee
    ''' </summary>
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an employee to edit.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim employeeId As Integer = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("ID").Value)

            ' Open edit form
            Dim editForm As New AddEditEmployeeFrm(employeeId) ' Pass ID = Edit mode
            If editForm.ShowDialog() = DialogResult.OK Then
                LoadEmployees()
                MessageBox.Show("Employee updated successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error editing employee: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Delete employee
    ''' </summary>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an employee to delete.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim employeeId As Integer = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("ID").Value)
            Dim employeeName As String = dgvEmployees.SelectedRows(0).Cells("Employee Name").Value.ToString()
            Dim employeeNo As String = dgvEmployees.SelectedRows(0).Cells("Employee No.").Value.ToString()

            ' Check if employee has active assets
            Dim assetsIssued As Integer = Convert.ToInt32(dgvEmployees.SelectedRows(0).Cells("Assets Issued").Value)
            If assetsIssued > 0 Then
                MessageBox.Show($"Cannot delete employee {employeeNo} - {employeeName}." & vbCrLf & vbCrLf &
                              $"This employee still has {assetsIssued} active asset(s) issued." & vbCrLf &
                              "Please return all assets before deleting.",
                              "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Confirm deletion
            Dim result As DialogResult = MessageBox.Show(
                $"Are you sure you want to delete employee:" & vbCrLf & vbCrLf &
                $"{employeeNo} - {employeeName}?" & vbCrLf & vbCrLf &
                "This action cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    If conn Is Nothing Then Return

                    Dim query As String = "DELETE FROM employees WHERE employee_id = @employeeId"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@employeeId", employeeId)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                ' Log activity
                LogActivity("Employee Deleted", "employees", employeeId,
                           $"Deleted employee: {employeeNo} - {employeeName}")

                LoadEmployees()
                MessageBox.Show("Employee deleted successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error deleting employee: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Print QR codes for selected employees
    ''' </summary>
    Private Sub btnPrintQR_Click(sender As Object, e As EventArgs) Handles btnPrintQR.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select employee(s) to print QR codes.", "No Selection",
                      MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' Collect selected employee IDs
            Dim selectedEmployeeIds As New List(Of Integer)
            For Each row As DataGridViewRow In dgvEmployees.SelectedRows
                selectedEmployeeIds.Add(Convert.ToInt32(row.Cells("ID").Value))
            Next

            ' Pass to the QR print form
            Dim qrcode As New EmployeeQRCodePrintFrm(selectedEmployeeIds)
            qrcode.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error printing QR codes: " & ex.Message, "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ''' <summary>
    ''' Export employees data
    ''' </summary>
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If dgvEmployees.Rows.Count = 0 Then
            MessageBox.Show("No data to export.", "No Data",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Excel Files|*.xlsx|CSV Files|*.csv"
            saveFileDialog.Title = "Export Employees Data"
            saveFileDialog.FileName = $"Employees_{Date.Today:yyyyMMdd}"

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
    ''' DataGridView selection changed - enable/disable action buttons
    ''' </summary>
    Private Sub dgvEmployees_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEmployees.SelectionChanged
        Dim hasSelection As Boolean = dgvEmployees.SelectedRows.Count > 0
        btnViewDetails.Enabled = hasSelection
        btnEdit.Enabled = hasSelection
        btnDelete.Enabled = hasSelection
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
        For Each column As DataGridViewColumn In dgvEmployees.Columns
            If column.Visible Then
                headers.Add(column.HeaderText)
            End If
        Next
        csv.AppendLine(String.Join(",", headers))

        ' Add rows
        For Each row As DataGridViewRow In dgvEmployees.Rows
            If Not row.IsNewRow Then
                Dim cells As New List(Of String)
                For Each cell As DataGridViewCell In row.Cells
                    If dgvEmployees.Columns(cell.ColumnIndex).Visible Then
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