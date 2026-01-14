Imports MySql.Data.MySqlClient

Public Class AddEditEmployeeFrm
    Private currentEmployeeId As Integer = 0
    Private editMode As Boolean = False
    Private loggedInUserId As Integer = 0
    Private isLoadingData As Boolean = False

    ' Store values to set after loading
    Private savedDepartmentId As Integer = 0
    Private savedPositionId As Integer = 0
    Private savedSupervisorId As Integer? = Nothing

    Public Sub New(Optional employeeId As Integer = 0)
        InitializeComponent()
        currentEmployeeId = employeeId
        editMode = (employeeId > 0)

        ' Get logged-in user ID from global variable
        loggedInUserId = gCurrentUserId

        ' Validate user ID
        If loggedInUserId <= 0 Then
            MessageBox.Show("Invalid user session. Please login again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Public Property EmployeeId As Integer
        Get
            Return currentEmployeeId
        End Get
        Set(value As Integer)
            currentEmployeeId = value
            editMode = (value > 0)
        End Set
    End Property

    Public Property IsEditMode As Boolean
        Get
            Return editMode
        End Get
        Set(value As Boolean)
            editMode = value
        End Set
    End Property

    Private Sub AddEditEmployeeFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isLoadingData = True

        ' Initialize status combo
        cboStatus.Items.Clear()
        cboStatus.Items.AddRange(New String() {"Active", "On Leave", "Resigned", "Terminated", "Retired"})
        cboStatus.SelectedIndex = 0

        ' Initialize employment type combo
        cboEmploymentType.Items.Clear()
        cboEmploymentType.Items.AddRange(New String() {"Regular", "Contractual", "Part-time", "Probationary"})
        cboEmploymentType.SelectedIndex = 0

        ' Set default date
        dtpHireDate.Value = DateTime.Now

        ' Load departments first
        LoadDepartments()

        If editMode AndAlso currentEmployeeId > 0 Then
            lblTitle.Text = "✏️ Edit Employee"
            btnSave.Text = "💾 Update Employee"
            LoadEmployeeData()
        Else
            lblTitle.Text = "➕ Add Employee"
            btnSave.Text = "💾 Save Employee"
            GenerateEmployeeNumber()
            isLoadingData = False ' Release flag for new employee
        End If
    End Sub

    Private Sub LoadDepartments()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = "SELECT department_id, department_name FROM departments WHERE status = 'Active' ORDER BY department_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)

                        cboDepartment.DataSource = Nothing
                        cboDepartment.DisplayMember = "department_name"
                        cboDepartment.ValueMember = "department_id"
                        cboDepartment.DataSource = dt
                        cboDepartment.SelectedIndex = -1
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPositions(Optional selectPositionId As Integer = 0)
        Try
            If cboDepartment.SelectedValue Is Nothing Then
                cboPosition.DataSource = Nothing
                Return
            End If

            Dim deptId As Integer
            If Not Integer.TryParse(cboDepartment.SelectedValue.ToString(), deptId) Then
                cboPosition.DataSource = Nothing
                Return
            End If

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = "SELECT position_id, position_name, position_level 
                                      FROM employee_positions 
                                      WHERE department_id = @deptId
                                      ORDER BY position_level, position_name"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@deptId", deptId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Load(reader)

                        cboPosition.DataSource = Nothing
                        cboPosition.DisplayMember = "position_name"
                        cboPosition.ValueMember = "position_id"
                        cboPosition.DataSource = dt

                        ' Set position if provided
                        If selectPositionId > 0 AndAlso dt.Rows.Count > 0 Then
                            cboPosition.SelectedValue = selectPositionId
                        Else
                            cboPosition.SelectedIndex = -1
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading positions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSupervisors(Optional selectSupervisorId As Integer? = Nothing)
        Try
            If cboDepartment.SelectedValue Is Nothing OrElse cboPosition.SelectedValue Is Nothing Then
                cboSupervisor.DataSource = Nothing
                Return
            End If

            Dim deptId As Integer
            Dim posId As Integer

            If Not Integer.TryParse(cboDepartment.SelectedValue.ToString(), deptId) OrElse
               Not Integer.TryParse(cboPosition.SelectedValue.ToString(), posId) Then
                cboSupervisor.DataSource = Nothing
                Return
            End If

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()

                Dim query As String = "SELECT e.employee_id, 
                                             CONCAT(e.first_name, ' ', e.last_name, ' (', ep.position_name, ')') as full_name,
                                             ep.position_level
                                      FROM employees e
                                      INNER JOIN employee_positions ep ON e.position_id = ep.position_id
                                      WHERE e.employment_status = 'Active'
                                        AND e.department_id = @deptId
                                        AND ep.position_level < (
                                            SELECT position_level 
                                            FROM employee_positions 
                                            WHERE position_id = @posId
                                        )"

                If editMode AndAlso currentEmployeeId > 0 Then
                    query &= " AND e.employee_id != @empId"
                End If

                query &= " ORDER BY ep.position_level, e.first_name, e.last_name"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@deptId", deptId)
                    cmd.Parameters.AddWithValue("@posId", posId)

                    If editMode AndAlso currentEmployeeId > 0 Then
                        cmd.Parameters.AddWithValue("@empId", currentEmployeeId)
                    End If

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim dt As New DataTable()
                        dt.Columns.Add("employee_id", GetType(Integer))
                        dt.Columns.Add("full_name", GetType(String))
                        dt.Columns.Add("position_level", GetType(Integer))

                        ' Add "No Supervisor" option first
                        Dim noSupRow As DataRow = dt.NewRow()
                        noSupRow("employee_id") = 0  ' Use 0 instead of DBNull
                        noSupRow("full_name") = "-- No Supervisor --"
                        noSupRow("position_level") = 999
                        dt.Rows.Add(noSupRow)

                        ' Add actual supervisors
                        While reader.Read()
                            Dim row As DataRow = dt.NewRow()
                            row("employee_id") = reader.GetInt32("employee_id")
                            row("full_name") = reader.GetString("full_name")
                            row("position_level") = reader.GetInt32("position_level")
                            dt.Rows.Add(row)
                        End While

                        cboSupervisor.DataSource = Nothing
                        cboSupervisor.DisplayMember = "full_name"
                        cboSupervisor.ValueMember = "employee_id"
                        cboSupervisor.DataSource = dt

                        ' Set supervisor if provided
                        If selectSupervisorId.HasValue AndAlso selectSupervisorId.Value > 0 Then
                            cboSupervisor.SelectedValue = selectSupervisorId.Value
                        Else
                            cboSupervisor.SelectedValue = 0 ' Select "No Supervisor"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading supervisors: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateEmployeeNumber()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = "SELECT employee_number FROM employees ORDER BY employee_id DESC LIMIT 1"
                Using cmd As New MySqlCommand(query, conn)
                    Dim lastNumber As Object = cmd.ExecuteScalar()

                    If lastNumber IsNot Nothing AndAlso Not IsDBNull(lastNumber) Then
                        Dim parts As String() = lastNumber.ToString().Split("-"c)
                        If parts.Length = 3 Then
                            Dim numPart As Integer
                            If Integer.TryParse(parts(2), numPart) Then
                                numPart += 1
                                txtEmployeeNumber.Text = $"EMP-{parts(1)}-{numPart.ToString("000")}"
                            Else
                                txtEmployeeNumber.Text = "EMP-XXX-001"
                            End If
                        Else
                            txtEmployeeNumber.Text = "EMP-XXX-001"
                        End If
                    Else
                        txtEmployeeNumber.Text = "EMP-XXX-001"
                    End If
                End Using
            End Using
        Catch ex As Exception
            txtEmployeeNumber.Text = "EMP-XXX-001"
        End Try
    End Sub

    Private Sub LoadEmployeeData()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = "SELECT * FROM employees WHERE employee_id = @empId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@empId", currentEmployeeId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Basic Information
                            txtEmployeeNumber.Text = reader("employee_number").ToString()
                            txtEmployeeNumber.ReadOnly = True

                            txtFirstName.Text = reader("first_name").ToString()
                            txtMiddleName.Text = If(IsDBNull(reader("middle_name")), "", reader("middle_name").ToString())
                            txtLastName.Text = reader("last_name").ToString()
                            txtEmail.Text = If(IsDBNull(reader("email")), "", reader("email").ToString())
                            txtPhone.Text = If(IsDBNull(reader("phone_number")), "", reader("phone_number").ToString())

                            ' Store IDs to set after loading dropdowns
                            savedDepartmentId = If(IsDBNull(reader("department_id")), 0, Convert.ToInt32(reader("department_id")))
                            savedPositionId = If(IsDBNull(reader("position_id")), 0, Convert.ToInt32(reader("position_id")))

                            If IsDBNull(reader("direct_supervisor_id")) Then
                                savedSupervisorId = Nothing
                            Else
                                savedSupervisorId = Convert.ToInt32(reader("direct_supervisor_id"))
                            End If

                            ' Employment Details
                            dtpHireDate.Value = Convert.ToDateTime(reader("hire_date"))
                            cboStatus.Text = reader("employment_status").ToString()
                            cboEmploymentType.Text = reader("employment_type").ToString()
                        End If
                    End Using
                End Using
            End Using

            ' Now load cascading dropdowns with saved values
            If savedDepartmentId > 0 Then
                cboDepartment.SelectedValue = savedDepartmentId
                LoadPositions(savedPositionId)

                If savedPositionId > 0 Then
                    LoadSupervisors(savedSupervisorId)
                End If
            End If

            isLoadingData = False ' Release flag after everything is loaded

        Catch ex As Exception
            MessageBox.Show($"Error loading employee data: {ex.Message}{vbCrLf}{vbCrLf}{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            isLoadingData = False
        End Try
    End Sub

    Private Function ValidateForm() As Boolean
        If String.IsNullOrWhiteSpace(txtEmployeeNumber.Text) Then
            MessageBox.Show("Employee Number is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmployeeNumber.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("First Name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MessageBox.Show("Last Name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLastName.Focus()
            Return False
        End If

        If cboDepartment.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a Department!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDepartment.Focus()
            Return False
        End If

        If cboPosition.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a Position!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPosition.Focus()
            Return False
        End If

        If cboEmploymentType.SelectedIndex = -1 Then
            MessageBox.Show("Please select an Employment Type!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboEmploymentType.Focus()
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(txtEmail.Text) Then
            If Not txtEmail.Text.Contains("@") OrElse Not txtEmail.Text.Contains(".") Then
                MessageBox.Show("Please enter a valid email address!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmail.Focus()
                Return False
            End If
        End If

        If Not editMode Then
            If EmployeeNumberExists(txtEmployeeNumber.Text) Then
                MessageBox.Show("Employee Number already exists! Please use a different number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmployeeNumber.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Function EmployeeNumberExists(empNumber As String) As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = "SELECT COUNT(*) FROM employees WHERE employee_number = @empNum"
                If editMode Then
                    query &= " AND employee_id != @empId"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@empNum", empNumber)
                    If editMode Then
                        cmd.Parameters.AddWithValue("@empId", currentEmployeeId)
                    End If

                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateForm() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()


                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        If editMode Then
                            UpdateEmployee(conn, transaction)
                        Else
                            AddEmployee(conn, transaction)
                        End If

                        transaction.Commit()

                        Dim msg As String = If(editMode, "Employee updated successfully!", "Employee added successfully!")
                        MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Catch ex As Exception
                        transaction.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error saving employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddEmployee(conn As MySqlConnection, transaction As MySqlTransaction)
        Dim query As String = "INSERT INTO employees 
                              (employee_number, qr_code_data, first_name, middle_name, last_name, 
                               email, phone_number, department_id, position_id, direct_supervisor_id, 
                               hire_date, employment_status, employment_type, created_by) 
                              VALUES 
                              (@empNum, @qrData, @firstName, @middleName, @lastName, 
                               @email, @phone, @deptId, @posId, @supId, 
                               @hireDate, @status, @empType, @createdBy)"

        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@empNum", txtEmployeeNumber.Text.Trim())
            cmd.Parameters.AddWithValue("@qrData", txtEmployeeNumber.Text.Trim())
            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim())
            cmd.Parameters.AddWithValue("@middleName", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), DBNull.Value, CObj(txtMiddleName.Text.Trim())))
            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim())
            cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, CObj(txtEmail.Text.Trim())))
            cmd.Parameters.AddWithValue("@phone", If(String.IsNullOrWhiteSpace(txtPhone.Text), DBNull.Value, CObj(txtPhone.Text.Trim())))
            cmd.Parameters.AddWithValue("@deptId", Convert.ToInt32(cboDepartment.SelectedValue))
            cmd.Parameters.AddWithValue("@posId", Convert.ToInt32(cboPosition.SelectedValue))

            ' Handle supervisor - 0 means no supervisor
            Dim supValue As Integer = If(cboSupervisor.SelectedValue IsNot Nothing, Convert.ToInt32(cboSupervisor.SelectedValue), 0)
            If supValue > 0 Then
                cmd.Parameters.AddWithValue("@supId", supValue)
            Else
                cmd.Parameters.AddWithValue("@supId", DBNull.Value)
            End If

            cmd.Parameters.AddWithValue("@hireDate", dtpHireDate.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@status", cboStatus.Text)
            cmd.Parameters.AddWithValue("@empType", cboEmploymentType.Text)
            cmd.Parameters.AddWithValue("@createdBy", loggedInUserId)

            cmd.ExecuteNonQuery()

            Dim newId As Long = cmd.LastInsertedId

            LogActivity(conn, transaction, "Employee Created", CInt(newId),
                       $"Created employee: {txtFirstName.Text} {txtLastName.Text} ({txtEmployeeNumber.Text})")
        End Using
    End Sub

    Private Sub UpdateEmployee(conn As MySqlConnection, transaction As MySqlTransaction)
        Dim query As String = "UPDATE employees SET 
                              first_name = @firstName, 
                              middle_name = @middleName, 
                              last_name = @lastName, 
                              email = @email, 
                              phone_number = @phone, 
                              department_id = @deptId, 
                              position_id = @posId, 
                              direct_supervisor_id = @supId, 
                              hire_date = @hireDate, 
                              employment_status = @status, 
                              employment_type = @empType 
                              WHERE employee_id = @empId"

        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text.Trim())
            cmd.Parameters.AddWithValue("@middleName", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), DBNull.Value, CObj(txtMiddleName.Text.Trim())))
            cmd.Parameters.AddWithValue("@lastName", txtLastName.Text.Trim())
            cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, CObj(txtEmail.Text.Trim())))
            cmd.Parameters.AddWithValue("@phone", If(String.IsNullOrWhiteSpace(txtPhone.Text), DBNull.Value, CObj(txtPhone.Text.Trim())))
            cmd.Parameters.AddWithValue("@deptId", Convert.ToInt32(cboDepartment.SelectedValue))
            cmd.Parameters.AddWithValue("@posId", Convert.ToInt32(cboPosition.SelectedValue))

            ' Handle supervisor - 0 means no supervisor
            Dim supValue As Integer = If(cboSupervisor.SelectedValue IsNot Nothing, Convert.ToInt32(cboSupervisor.SelectedValue), 0)
            If supValue > 0 Then
                cmd.Parameters.AddWithValue("@supId", supValue)
            Else
                cmd.Parameters.AddWithValue("@supId", DBNull.Value)
            End If

            cmd.Parameters.AddWithValue("@hireDate", dtpHireDate.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@status", cboStatus.Text)
            cmd.Parameters.AddWithValue("@empType", cboEmploymentType.Text)
            cmd.Parameters.AddWithValue("@empId", currentEmployeeId)

            cmd.ExecuteNonQuery()

            LogActivity(conn, transaction, "Employee Updated", currentEmployeeId,
                       $"Updated employee: {txtFirstName.Text} {txtLastName.Text} ({txtEmployeeNumber.Text})")
        End Using
    End Sub

    Private Sub LogActivity(conn As MySqlConnection, transaction As MySqlTransaction,
                           actionType As String, recordId As Integer, description As String)
        Dim logQuery As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description, ip_address) 
                                 VALUES (@userId, @action, 'employees', @recordId, @desc, @ip)"

        Using logCmd As New MySqlCommand(logQuery, conn, transaction)
            logCmd.Parameters.AddWithValue("@userId", loggedInUserId)
            logCmd.Parameters.AddWithValue("@action", actionType)
            logCmd.Parameters.AddWithValue("@recordId", recordId)
            logCmd.Parameters.AddWithValue("@desc", description)
            logCmd.Parameters.AddWithValue("@ip", GetLocalIPAddress())
            logCmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Function GetLocalIPAddress() As String
        Try
            Dim host As String = System.Net.Dns.GetHostName()
            Dim ip As String = System.Net.Dns.GetHostEntry(host).AddressList(0).ToString()
            Return ip
        Catch ex As Exception
            Return "Unknown"
        End Try
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged
        If isLoadingData Then Return

        If cboDepartment.SelectedValue IsNot Nothing Then
            LoadPositions()
            cboSupervisor.DataSource = Nothing

            ' Generate employee number based on department (only for new employees)
            If Not editMode Then
                Try
                    Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()

                        Dim query As String = "SELECT department_code FROM departments WHERE department_id = @deptId"
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@deptId", cboDepartment.SelectedValue)

                            Dim deptCode As Object = cmd.ExecuteScalar()
                            If deptCode IsNot Nothing Then
                                Dim countQuery As String = "SELECT COUNT(*) FROM employees WHERE department_id = @deptId"
                                Using countCmd As New MySqlCommand(countQuery, conn)
                                    countCmd.Parameters.AddWithValue("@deptId", cboDepartment.SelectedValue)
                                    Dim count As Integer = Convert.ToInt32(countCmd.ExecuteScalar())

                                    txtEmployeeNumber.Text = $"EMP-{deptCode}-{(count + 1).ToString("000")}"
                                End Using
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    ' Keep existing employee number if error occurs
                End Try
            End If
        End If
    End Sub

    Private Sub cboPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPosition.SelectedIndexChanged
        If isLoadingData Then Return

        If cboPosition.SelectedValue IsNot Nothing Then
            LoadSupervisors()
        End If
    End Sub
End Class