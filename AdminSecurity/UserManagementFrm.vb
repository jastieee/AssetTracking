Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class UserManagementFrm
    ' Form-level variables
    Private currentUserId As Integer = 0
    Private isEditMode As Boolean = False
    Private allCheckboxes As New List(Of CheckBox)

    ' Form Load Event
    Private Sub UserManagementFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadDepartments()
        LoadRoles()
        LoadUsers()
        CollectAllCheckboxes()
        WireCheckboxEvents()
        SetInitialState()
    End Sub

    ' Initialize form controls
    Private Sub InitializeForm()
        ' Set default tab
        tabUserDetails.SelectedIndex = 0

        ' Configure DataGridView
        With dgvUserList
            .AutoGenerateColumns = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With

        ' Add columns to DataGridView
        dgvUserList.Columns.Clear()
        dgvUserList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "user_id", .HeaderText = "ID", .DataPropertyName = "user_id", .Visible = False})
        dgvUserList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "username", .HeaderText = "Username", .DataPropertyName = "username", .Width = 120})
        dgvUserList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "full_name", .HeaderText = "Full Name", .DataPropertyName = "full_name", .Width = 180})
        dgvUserList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "role_name", .HeaderText = "Role", .DataPropertyName = "role_name", .Width = 100})
        dgvUserList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "department_name", .HeaderText = "Department", .DataPropertyName = "department_name", .Width = 120})
        dgvUserList.Columns.Add(New DataGridViewCheckBoxColumn With {.Name = "is_active", .HeaderText = "Active", .DataPropertyName = "is_active", .Width = 60})

        ' Set search textbox placeholder behavior
        txtSearchModule.ForeColor = Color.Gray

        ' Disable Access Rights tab initially
        TabPage2.Enabled = False
    End Sub

    ' Set initial state (Add New User mode)
    Private Sub SetInitialState()
        ClearForm()
        isEditMode = False
        currentUserId = 0
        TabPage2.Enabled = False
        tabUserDetails.SelectedIndex = 0
        btnSaveAccessRights.Enabled = False
    End Sub

    ' Load Departments
    Private Sub LoadDepartments()
        Try
            Dim query As String = "SELECT department_id, department_name FROM departments WHERE status = 'Active' ORDER BY department_name"
            Dim dt As DataTable = ExecuteQuery(query)

            cboDepartment.DataSource = dt
            cboDepartment.DisplayMember = "department_name"
            cboDepartment.ValueMember = "department_id"
            cboDepartment.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load Roles
    Private Sub LoadRoles()
        Try
            Dim query As String = "SELECT role_id, role_name FROM user_roles ORDER BY role_name"
            Dim dt As DataTable = ExecuteQuery(query)

            cboRole.DataSource = dt
            cboRole.DisplayMember = "role_name"
            cboRole.ValueMember = "role_id"
            cboRole.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error loading roles: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load Users
    Private Sub LoadUsers(Optional searchTerm As String = "")
        Try
            Dim query As String = "SELECT u.user_id, u.username, " &
                                  "CONCAT(u.first_name, ' ', IFNULL(u.middle_name, ''), ' ', u.last_name) AS full_name, " &
                                  "r.role_name, d.department_name, u.is_active " &
                                  "FROM users u " &
                                  "LEFT JOIN user_roles r ON u.role_id = r.role_id " &
                                  "LEFT JOIN departments d ON u.department_id = d.department_id "

            If Not String.IsNullOrEmpty(searchTerm) Then
                query &= "WHERE u.username LIKE @search OR u.first_name LIKE @search OR u.last_name LIKE @search "
            End If

            query &= "ORDER BY u.username"

            Dim params As New List(Of MySqlParameter)
            If Not String.IsNullOrEmpty(searchTerm) Then
                params.Add(New MySqlParameter("@search", "%" & searchTerm & "%"))
            End If

            Dim dt As DataTable = ExecuteQuery(query, params)
            dgvUserList.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Collect all checkboxes for access rights
    Private Sub CollectAllCheckboxes()
        allCheckboxes.Clear()

        ' Add all checkboxes from all group boxes
        For Each grp As GroupBox In pnlModuleGroups.Controls.OfType(Of GroupBox)()
            For Each chk As CheckBox In grp.Controls.OfType(Of CheckBox)()
                allCheckboxes.Add(chk)
            Next
        Next
    End Sub

    ' Button: Add New User
    Private Sub btnAddNewUser_Click(sender As Object, e As EventArgs) Handles btnAddNewUser.Click
        SetInitialState()
        MessageBox.Show("Please fill in the user information and click 'Save User'.", "Add New User", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Button: Save User (Create or Update)
    Private Sub btnsaveUser_Click(sender As Object, e As EventArgs) Handles btnsaveUser.Click
        If ValidateUserForm() Then
            If isEditMode Then
                UpdateUser()
            Else
                CreateUser()
            End If
        End If
    End Sub

    ' Validate User Form
    Private Function ValidateUserForm() As Boolean
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        If Not isEditMode AndAlso String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Password is required for new users.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("First name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtLastName.Text) Then
            MessageBox.Show("Last name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLastName.Focus()
            Return False
        End If

        If cboRole.SelectedIndex = -1 Then
            MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboRole.Focus()
            Return False
        End If

        Return True
    End Function

    ' Create New User
    Private Sub CreateUser()
        Try
            ' Check if username exists
            Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE username = @username"
            Dim checkParams As New List(Of MySqlParameter) From {
            New MySqlParameter("@username", txtUsername.Text.Trim())
        }

            Dim count As Integer = Convert.ToInt32(ExecuteScalar(checkQuery, checkParams))
            If count > 0 Then
                MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUsername.Focus()
                Return
            End If

            ' Hash password
            Dim hashedPassword As String = HashPassword(txtPassword.Text)

            ' Insert user
            Dim query As String = "INSERT INTO users (username, password_hash, first_name, middle_name, last_name, " &
                              "email, phone_number, role_id, department_id, is_active) " &
                              "VALUES (@username, @password, @firstname, @middlename, @lastname, " &
                              "@email, @phone, @role, @dept, @active); " &
                              "SELECT LAST_INSERT_ID();"

            Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@username", txtUsername.Text.Trim()),
            New MySqlParameter("@password", hashedPassword),
            New MySqlParameter("@firstname", txtFirstName.Text.Trim()),
            New MySqlParameter("@middlename", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), DBNull.Value, txtMiddleName.Text.Trim())),
            New MySqlParameter("@lastname", txtLastName.Text.Trim()),
            New MySqlParameter("@email", If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim())),
            New MySqlParameter("@phone", If(String.IsNullOrWhiteSpace(txtPhone.Text), DBNull.Value, txtPhone.Text.Trim())),
            New MySqlParameter("@role", cboRole.SelectedValue),
            New MySqlParameter("@dept", If(cboDepartment.SelectedIndex = -1, DBNull.Value, cboDepartment.SelectedValue)),
            New MySqlParameter("@active", If(chkActive.Checked, 1, 0))
        }

            currentUserId = Convert.ToInt32(ExecuteScalar(query, params))

            ' ============================================================
            ' NEW: Try to link with existing employee record
            ' ============================================================
            LinkUserToEmployee(currentUserId)

            ' Log activity
            LogActivity(gCurrentUserId, "User Created", "users", currentUserId,
                   $"Created user: {txtUsername.Text.Trim()}")

            MessageBox.Show("User created successfully! You can now assign access rights.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Enable access rights tab
            isEditMode = True
            TabPage2.Enabled = True
            btnSaveAccessRights.Enabled = True
            LoadUsers()

            ' Switch to access rights tab
            tabUserDetails.SelectedIndex = 1
            LoadUserAccessRights(currentUserId)

        Catch ex As Exception
            MessageBox.Show("Error creating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' NEW METHOD: Link user to existing employee record
    Private Sub LinkUserToEmployee(userId As Integer)
        Try
            ' Get user details
            Dim getUserQuery As String = "SELECT email, first_name, last_name, department_id FROM users WHERE user_id = @userid"
            Dim getUserParams As New List(Of MySqlParameter) From {
            New MySqlParameter("@userid", userId)
        }

            Dim userDt As DataTable = ExecuteQuery(getUserQuery, getUserParams)
            If userDt.Rows.Count = 0 Then Return

            Dim userRow As DataRow = userDt.Rows(0)
            Dim userEmail As String = If(IsDBNull(userRow("email")), "", userRow("email").ToString())
            Dim userFirstName As String = userRow("first_name").ToString()
            Dim userLastName As String = userRow("last_name").ToString()
            Dim userDeptId As Object = userRow("department_id")

            ' Try to find matching employee by email first (most reliable)
            Dim findEmployeeQuery As String = ""
            Dim findParams As New List(Of MySqlParameter)
            Dim employeeId As Integer = 0

            If Not String.IsNullOrWhiteSpace(userEmail) Then
                ' Try matching by email
                findEmployeeQuery = "SELECT employee_id FROM employees WHERE email = @email AND user_id IS NULL LIMIT 1"
                findParams.Add(New MySqlParameter("@email", userEmail))

                Dim result = ExecuteScalar(findEmployeeQuery, findParams)
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    employeeId = Convert.ToInt32(result)
                End If
            End If

            ' If not found by email, try matching by name and department
            If employeeId = 0 AndAlso Not IsDBNull(userDeptId) Then
                findEmployeeQuery = "SELECT employee_id FROM employees " &
                              "WHERE first_name = @firstname " &
                              "AND last_name = @lastname " &
                              "AND department_id = @deptid " &
                              "AND user_id IS NULL " &
                              "LIMIT 1"

                findParams.Clear()
                findParams.Add(New MySqlParameter("@firstname", userFirstName))
                findParams.Add(New MySqlParameter("@lastname", userLastName))
                findParams.Add(New MySqlParameter("@deptid", userDeptId))

                Dim result = ExecuteScalar(findEmployeeQuery, findParams)
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    employeeId = Convert.ToInt32(result)
                End If
            End If

            ' If employee found, link them
            If employeeId > 0 Then
                Dim updateQuery As String = "UPDATE employees SET user_id = @userid WHERE employee_id = @empid"
                Dim updateParams As New List(Of MySqlParameter) From {
                New MySqlParameter("@userid", userId),
                New MySqlParameter("@empid", employeeId)
            }

                ExecuteNonQuery(updateQuery, updateParams)

                ' Log the linking
                LogActivity(gCurrentUserId, "User-Employee Linked", "employees", employeeId,
                       $"Linked user ID {userId} ({txtUsername.Text.Trim()}) to employee ID {employeeId}")

                MessageBox.Show("User account has been linked to existing employee record.",
                          "Employee Linked", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ' Silent fail for linking - don't interrupt user creation
            Console.WriteLine("Error linking user to employee: " & ex.Message)
        End Try
    End Sub
    ' Update Existing User
    ' Update Existing User - UPDATED VERSION
    Private Sub UpdateUser()
        Try
            Dim query As String = "UPDATE users SET " &
                              "username = @username, " &
                              "first_name = @firstname, " &
                              "middle_name = @middlename, " &
                              "last_name = @lastname, " &
                              "email = @email, " &
                              "phone_number = @phone, " &
                              "role_id = @role, " &
                              "department_id = @dept, " &
                              "is_active = @active"

            Dim params As New List(Of MySqlParameter) From {
            New MySqlParameter("@username", txtUsername.Text.Trim()),
            New MySqlParameter("@firstname", txtFirstName.Text.Trim()),
            New MySqlParameter("@middlename", If(String.IsNullOrWhiteSpace(txtMiddleName.Text), DBNull.Value, txtMiddleName.Text.Trim())),
            New MySqlParameter("@lastname", txtLastName.Text.Trim()),
            New MySqlParameter("@email", If(String.IsNullOrWhiteSpace(txtEmail.Text), DBNull.Value, txtEmail.Text.Trim())),
            New MySqlParameter("@phone", If(String.IsNullOrWhiteSpace(txtPhone.Text), DBNull.Value, txtPhone.Text.Trim())),
            New MySqlParameter("@role", cboRole.SelectedValue),
            New MySqlParameter("@dept", If(cboDepartment.SelectedIndex = -1, DBNull.Value, cboDepartment.SelectedValue)),
            New MySqlParameter("@active", If(chkActive.Checked, 1, 0)),
            New MySqlParameter("@userid", currentUserId)
        }

            ' Update password if changed
            If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then
                query &= ", password_hash = @password "
                params.Add(New MySqlParameter("@password", HashPassword(txtPassword.Text)))
            End If

            query &= " WHERE user_id = @userid"

            ExecuteNonQuery(query, params)

            ' NEW: Try to link/update employee connection when user details change
            LinkUserToEmployee(currentUserId)

            ' Log activity
            LogActivity(gCurrentUserId, "User Updated", "users", currentUserId,
                   $"Updated user: {txtUsername.Text.Trim()}")

            MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers()

        Catch ex As Exception
            MessageBox.Show("Error updating user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' DataGridView: Cell Click - Load selected user
    Private Sub dgvUserList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUserList.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvUserList.Rows(e.RowIndex)
            currentUserId = Convert.ToInt32(row.Cells("user_id").Value)

            LoadUserDetails(currentUserId)
            LoadUserAccessRights(currentUserId)

            isEditMode = True
            TabPage2.Enabled = True
            btnSaveAccessRights.Enabled = True
            tabUserDetails.SelectedIndex = 0
        End If
    End Sub

    ' Load User Details
    Private Sub LoadUserDetails(userId As Integer)
        Try
            Dim query As String = "SELECT * FROM users WHERE user_id = @userid"
            Dim params As New List(Of MySqlParameter) From {
                New MySqlParameter("@userid", userId)
            }

            Dim dt As DataTable = ExecuteQuery(query, params)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)

                txtUsername.Text = row("username").ToString()
                txtPassword.Text = "" ' Don't show password
                txtFirstName.Text = row("first_name").ToString()
                txtMiddleName.Text = If(IsDBNull(row("middle_name")), "", row("middle_name").ToString())
                txtLastName.Text = row("last_name").ToString()
                txtEmail.Text = If(IsDBNull(row("email")), "", row("email").ToString())
                txtPhone.Text = If(IsDBNull(row("phone_number")), "", row("phone_number").ToString())

                cboRole.SelectedValue = row("role_id")
                If Not IsDBNull(row("department_id")) Then
                    cboDepartment.SelectedValue = row("department_id")
                Else
                    cboDepartment.SelectedIndex = -1
                End If

                chkActive.Checked = Convert.ToBoolean(row("is_active"))
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading user details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load User Access Rights
    Private Sub LoadUserAccessRights(userId As Integer)
        Try
            ' Clear all checkboxes first
            For Each chk As CheckBox In allCheckboxes
                chk.Checked = False
            Next

            ' Load user's access rights
            Dim query As String = "SELECT module_id FROM security_access WHERE user_id = @userid AND access_flag = 1"
            Dim params As New List(Of MySqlParameter) From {
                New MySqlParameter("@userid", userId)
            }

            Dim dt As DataTable = ExecuteQuery(query, params)

            For Each row As DataRow In dt.Rows
                Dim moduleId As Integer = Convert.ToInt32(row("module_id"))

                ' Find and check the corresponding checkbox
                For Each chk As CheckBox In allCheckboxes
                    If chk.Tag IsNot Nothing AndAlso Convert.ToInt32(chk.Tag) = moduleId Then
                        chk.Checked = True
                        Exit For
                    End If
                Next
            Next

            UpdateAccessSummary()

        Catch ex As Exception
            MessageBox.Show("Error loading access rights: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button: Save Access Rights
    Private Sub btnSaveAccessRights_Click(sender As Object, e As EventArgs) Handles btnSaveAccessRights.Click
        If currentUserId = 0 Then
            MessageBox.Show("Please select a user first.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Delete existing access rights
            Dim deleteQuery As String = "DELETE FROM security_access WHERE user_id = @userid"
            Dim deleteParams As New List(Of MySqlParameter) From {
                New MySqlParameter("@userid", currentUserId)
            }
            ExecuteNonQuery(deleteQuery, deleteParams)

            ' Insert new access rights
            Dim insertQuery As String = "INSERT INTO security_access (user_id, module_id, access_flag) VALUES (@userid, @moduleid, 1)"

            For Each chk As CheckBox In allCheckboxes
                If chk.Checked AndAlso chk.Tag IsNot Nothing Then
                    Dim params As New List(Of MySqlParameter) From {
                        New MySqlParameter("@userid", currentUserId),
                        New MySqlParameter("@moduleid", Convert.ToInt32(chk.Tag))
                    }
                    ExecuteNonQuery(insertQuery, params)
                End If
            Next

            ' Log activity
            LogActivity(gCurrentUserId, "Access Rights Updated", "security_access", currentUserId,
                       $"Updated access rights for user ID: {currentUserId}")

            MessageBox.Show("Access rights saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error saving access rights: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button: Select All Modules
    Private Sub btnSelectAllModules_Click(sender As Object, e As EventArgs) Handles btnSelectAllModules.Click
        For Each chk As CheckBox In allCheckboxes
            chk.Checked = True
        Next
        UpdateAccessSummary()
    End Sub

    ' Button: Clear All Modules
    Private Sub btnClearAllModules_Click(sender As Object, e As EventArgs) Handles btnClearAllModules.Click
        For Each chk As CheckBox In allCheckboxes
            chk.Checked = False
        Next
        UpdateAccessSummary()
    End Sub

    ' Update Access Summary Label
    Private Sub UpdateAccessSummary()
        Dim checkedCount As Integer = 0
        For Each chk As CheckBox In allCheckboxes
            If chk.Checked Then
                checkedCount += 1
            End If
        Next

        Dim totalCount As Integer = allCheckboxes.Count
        lblAccessSummary.Text = $"{checkedCount} of {totalCount} modules selected"
    End Sub

    ' Checkbox CheckedChanged - Update summary
    Private Sub ModuleCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        UpdateAccessSummary()
    End Sub

    ' Wire up all checkbox events after form load
    Private Sub WireCheckboxEvents()
        For Each chk As CheckBox In allCheckboxes
            AddHandler chk.CheckedChanged, AddressOf ModuleCheckBox_CheckedChanged
        Next
    End Sub

    ' Button: Clear Form
    Private Sub btnClearForm_Click(sender As Object, e As EventArgs) Handles btnClearForm.Click
        SetInitialState()
    End Sub

    ' Clear Form
    Private Sub ClearForm()
        txtUsername.Clear()
        txtPassword.Clear()
        txtFirstName.Clear()
        txtMiddleName.Clear()
        txtLastName.Clear()
        txtEmail.Clear()
        txtPhone.Clear()
        cboRole.SelectedIndex = -1
        cboDepartment.SelectedIndex = -1
        chkActive.Checked = True

        ' Clear all access rights checkboxes
        For Each chk As CheckBox In allCheckboxes
            chk.Checked = False
        Next
        UpdateAccessSummary()
    End Sub

    ' Button: Show/Hide Password
    Private Sub btnShowPassword_Click(sender As Object, e As EventArgs) Handles btnShowPassword.Click
        If txtPassword.PasswordChar = "*"c Then
            txtPassword.PasswordChar = Nothing
            btnShowPassword.Text = "🙈"
        Else
            txtPassword.PasswordChar = "*"c
            btnShowPassword.Text = "👁"
        End If
    End Sub

    ' Button: Search Users
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadUsers(txtSearchUser.Text.Trim())
    End Sub

    ' TextBox: Search User - Enter Key
    Private Sub txtSearchUser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchUser.KeyPress
        If e.KeyChar = Chr(13) Then ' Enter key
            LoadUsers(txtSearchUser.Text.Trim())
            e.Handled = True
        End If
    End Sub

    ' TextBox: Search Module - Filter modules
    Private Sub txtSearchModule_TextChanged(sender As Object, e As EventArgs) Handles txtSearchModule.TextChanged
        FilterModules(txtSearchModule.Text.Trim())
    End Sub

    ' Filter modules based on search
    Private Sub FilterModules(searchTerm As String)
        If String.IsNullOrWhiteSpace(searchTerm) OrElse searchTerm = "🔍 Search modules..." Then
            ' Show all groups
            For Each grp As GroupBox In pnlModuleGroups.Controls.OfType(Of GroupBox)()
                grp.Visible = True
            Next
            Return
        End If

        searchTerm = searchTerm.ToLower()

        For Each grp As GroupBox In pnlModuleGroups.Controls.OfType(Of GroupBox)()
            Dim hasMatch As Boolean = False

            ' Check if group name matches
            If grp.Text.ToLower().Contains(searchTerm) Then
                hasMatch = True
            Else
                ' Check if any checkbox text matches
                For Each chk As CheckBox In grp.Controls.OfType(Of CheckBox)()
                    If chk.Text.ToLower().Contains(searchTerm) Then
                        hasMatch = True
                        Exit For
                    End If
                Next
            End If

            grp.Visible = hasMatch
        Next
    End Sub

    ' Search Module TextBox - Placeholder behavior
    Private Sub txtSearchModule_Enter(sender As Object, e As EventArgs) Handles txtSearchModule.Enter
        If txtSearchModule.Text = "🔍 Search modules..." Then
            txtSearchModule.Text = ""
            txtSearchModule.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSearchModule_Leave(sender As Object, e As EventArgs) Handles txtSearchModule.Leave
        If String.IsNullOrWhiteSpace(txtSearchModule.Text) Then
            txtSearchModule.Text = "🔍 Search modules..."
            txtSearchModule.ForeColor = Color.Gray
        End If
    End Sub

    ' Hash Password using SHA256
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(password)
            Dim hash As Byte() = sha256.ComputeHash(bytes)
            Dim builder As New StringBuilder()

            For Each b As Byte In hash
                builder.Append(b.ToString("x2"))
            Next

            Return builder.ToString()
        End Using
    End Function

    ' DATABASE HELPER METHODS
    ' These should ideally be in a separate database helper class

    Private Function ExecuteQuery(query As String, Optional params As List(Of MySqlParameter) = Nothing) As DataTable
        Dim dt As New DataTable()
        Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
            Using cmd As New MySqlCommand(query, conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params.ToArray())
                End If

                ' Remove this line - connection is already open
                ' conn.Open()

                Using adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Private Function ExecuteScalar(query As String, Optional params As List(Of MySqlParameter) = Nothing) As Object
        Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
            Using cmd As New MySqlCommand(query, conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params.ToArray())
                End If

                ' Remove this line - connection is already open
                ' conn.Open()

                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

    Private Function ExecuteNonQuery(query As String, Optional params As List(Of MySqlParameter) = Nothing) As Integer
        Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
            Using cmd As New MySqlCommand(query, conn)
                If params IsNot Nothing Then
                    cmd.Parameters.AddRange(params.ToArray())
                End If

                ' Remove this line - connection is already open
                ' conn.Open()

                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Private Sub LogActivity(userId As Integer, actionType As String, tableName As String, recordId As Integer, description As String)
        Try
            Dim query As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description) " &
                                  "VALUES (@userid, @action, @table, @recordid, @desc)"

            Dim params As New List(Of MySqlParameter) From {
                New MySqlParameter("@userid", userId),
                New MySqlParameter("@action", actionType),
                New MySqlParameter("@table", tableName),
                New MySqlParameter("@recordid", recordId),
                New MySqlParameter("@desc", description)
            }

            ExecuteNonQuery(query, params)
        Catch ex As Exception
            ' Silent fail for logging errors
            Console.WriteLine("Logging error: " & ex.Message)
        End Try
    End Sub
End Class