Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class loginFrm

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Validate inputs
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter your username", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter your password", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        ' Authenticate user
        btnLogin.Enabled = False
        btnLogin.Text = "LOGGING IN..."
        Me.Cursor = Cursors.WaitCursor

        If AuthenticateUser(txtUsername.Text.Trim(), txtPassword.Text) Then
            ' Authentication successful
            Me.Cursor = Cursors.Default
            Me.DialogResult = DialogResult.OK  ' ✅ Signal success to Main module
            Me.Close()  ' ✅ Close login form
        Else
            ' Authentication failed
            MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnLogin.Enabled = True
            btnLogin.Text = "LOGIN"
            Me.Cursor = Cursors.Default
            txtPassword.Clear()
            txtPassword.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Authenticate user against database
    ''' </summary>

    Private Function AuthenticateUser(username As String, password As String) As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then
                    Return False
                End If

                Dim query As String = "SELECT u.user_id, u.username, u.password_hash, u.first_name, u.last_name, 
                                         u.role_id, u.department_id, u.is_active, 
                                         r.role_name,
                                         IFNULL(d.department_name, 'No Department') as department_name
                                   FROM users u
                                   INNER JOIN user_roles r ON u.role_id = r.role_id
                                   LEFT JOIN departments d ON u.department_id = d.department_id
                                   WHERE u.username = @username AND u.is_active = 1"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim storedHash As String = reader("password_hash").ToString()

                            ' Verify password
                            If VerifyPassword(password, storedHash) Then
                                ' Store user information in global variables
                                gCurrentUserId = Convert.ToInt32(reader("user_id"))
                                gCurrentUserName = reader("username").ToString()
                                gCurrentUserRole = reader("role_name").ToString()
                                gCurrentUserDepartment = reader("department_name").ToString()
                                gCurrentUserFullName = reader("first_name").ToString() & " " & reader("last_name").ToString()
                                gCurrentRoleId = Convert.ToInt32(reader("role_id"))

                                ' Close reader before loading permissions
                                reader.Close()

                                ' *** NEW: Load user access permissions ***
                                If Not SecurityAccessManager.LoadUserAccessPermissions(gCurrentUserId) Then
                                    MessageBox.Show("Error loading user permissions. Please contact administrator.",
                                              "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Return False
                                End If

                                ' Log the login activity
                                LogActivity(gCurrentUserId, "User Login", "users", gCurrentUserId,
                                      "User " & gCurrentUserName & " logged in successfully")

                                ' Update last login timestamp
                                UpdateLastLogin(gCurrentUserId)

                                Return True
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return False
    End Function

    ''' <summary>
    ''' Verify password against stored hash
    ''' For demo: using simple SHA256 hash
    ''' In production: use BCrypt or Argon2
    ''' </summary>
    Private Function VerifyPassword(password As String, storedHash As String) As Boolean
        ' For the default admin user with hash from database creation
        ' Password: admin123
        ' You can also do simple comparison for testing

        ' Generate hash from input password
        Dim inputHash As String = HashPassword(password)

        ' Compare hashes
        Return inputHash.Equals(storedHash, StringComparison.OrdinalIgnoreCase)
    End Function

    ''' <summary>
    ''' Close button
    ''' </summary>

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Add these event handlers to create a hover effect
    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        btnClose.BackColor = Color.FromArgb(231, 76, 60) ' Red color on hover
        btnClose.ForeColor = Color.White
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.BackColor = Color.Transparent
        btnClose.ForeColor = Color.FromArgb(127, 140, 141)
    End Sub

    ''' <summary>
    ''' Hash password using SHA256
    ''' NOTE: In production, use BCrypt.Net-Next NuGet package for better security
    ''' </summary>
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ''' <summary>
    ''' Log user activity to database
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
            ' Silent fail for logging
        End Try
    End Sub

    ''' <summary>
    ''' Update user's last login timestamp
    ''' </summary>
    Private Sub UpdateLastLogin(userId As Integer)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "UPDATE users SET last_login = NOW() WHERE user_id = @userId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Silent fail
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
            ' Return default if error
        End Try
        Return "Unknown"
    End Function

    ''' <summary>
    ''' Form load event - can add initialization code here
    ''' </summary>
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center form on screen
        Me.CenterToScreen()

        ' Focus username textbox
        txtUsername.Focus()

        ' Optional: Load remembered username
        ' LoadRememberedUsername()
    End Sub

    ''' <summary>
    ''' Handle Enter key press on password field
    ''' </summary>
    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            e.Handled = True
            btnLogin.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' Optional: Create a test user function for initial setup
    ''' Call this once to create admin user with hashed password
    ''' </summary>
    Public Sub CreateDefaultAdmin()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Check if admin already exists
                Dim checkQuery As String = "SELECT COUNT(*) FROM users WHERE username = 'admin'"
                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Admin user already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End Using

                ' Create admin user with hashed password
                Dim hashedPassword As String = HashPassword("admin123")
                Dim query As String = "INSERT INTO users (username, password_hash, email, first_name, last_name, role_id, is_active) 
                                       VALUES (@username, @password, @email, @firstName, @lastName, 1, 1)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@username", "admin")
                    cmd.Parameters.AddWithValue("@password", hashedPassword)
                    cmd.Parameters.AddWithValue("@email", "admin@company.com")
                    cmd.Parameters.AddWithValue("@firstName", "System")
                    cmd.Parameters.AddWithValue("@lastName", "Administrator")
                    cmd.ExecuteNonQuery()
                End Using


            End Using
        Catch ex As Exception
            MessageBox.Show("Error creating admin user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class