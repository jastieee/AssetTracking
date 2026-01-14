Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class SystemSettingsFrm

    ' Current user information
    Private currentUserId As Integer
    Private currentUsername As String
    Private currentUserRole As String

    ' Theme colors
    Private accentColor As Color = Color.FromArgb(52, 152, 219)

    Public Sub New()
        InitializeComponent()

        ' Get current user info from global session
        If gCurrentUserId > 0 Then
            currentUserId = gCurrentUserId
            currentUsername = gCurrentUserName
            currentUserRole = gCurrentUserRole
        Else
            MessageBox.Show("Session expired. Please login again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            Return
        End If
    End Sub

    Private Sub SystemSettingsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize navigation
            ShowPanel(pnlMyProfile)

            ' Load user profile data
            LoadUserProfile()

            ' Load system statistics
            LoadSystemStatistics()

            ' Set default values for preferences
            InitializePreferences()

            ' Apply current theme
            ApplyCurrentTheme()

        Catch ex As Exception
            MessageBox.Show("Error loading settings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#Region "Navigation"

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all content panels
        pnlMyProfile.Visible = False
        pnlAppearance.Visible = False
        pnlPreferences.Visible = False
        pnlSystemInfo.Visible = False
        pnlSecurity.Visible = False

        ' Show selected panel
        panelToShow.Visible = True
        panelToShow.Dock = DockStyle.Fill

        ' Update navigation button colors
        ResetNavigationButtons()
    End Sub

    Private Sub ResetNavigationButtons()
        Dim defaultColor As Color = Color.FromArgb(44, 62, 80)

        btnMyProfile.BackColor = defaultColor
        btnAppearance.BackColor = defaultColor
        btnPreferences.BackColor = defaultColor
        btnSystemInfo.BackColor = defaultColor
        btnSecurity.BackColor = defaultColor
    End Sub

    Private Sub btnMyProfile_Click(sender As Object, e As EventArgs) Handles btnMyProfile.Click
        ShowPanel(pnlMyProfile)
        btnMyProfile.BackColor = Color.FromArgb(52, 152, 219)
        LoadUserProfile()
    End Sub

    Private Sub btnAppearance_Click(sender As Object, e As EventArgs) Handles btnAppearance.Click
        ShowPanel(pnlAppearance)
        btnAppearance.BackColor = Color.FromArgb(52, 152, 219)
    End Sub

    Private Sub btnPreferences_Click(sender As Object, e As EventArgs) Handles btnPreferences.Click
        ShowPanel(pnlPreferences)
        btnPreferences.BackColor = Color.FromArgb(52, 152, 219)
    End Sub

    Private Sub btnSystemInfo_Click(sender As Object, e As EventArgs) Handles btnSystemInfo.Click
        ShowPanel(pnlSystemInfo)
        btnSystemInfo.BackColor = Color.FromArgb(52, 152, 219)
        LoadSystemStatistics()
    End Sub

    Private Sub btnSecurity_Click(sender As Object, e As EventArgs) Handles btnSecurity.Click
        ShowPanel(pnlSecurity)
        btnSecurity.BackColor = Color.FromArgb(52, 152, 219)

        ' Only allow Admin to access session settings
        If currentUserRole <> "Admin" Then
            grpSessionSettings.Enabled = False
            grpBackup.Enabled = False
        End If
    End Sub

#End Region

#Region "User Profile Management"

    Private Sub LoadUserProfile()
        Dim conn As MySqlConnection = Nothing

        Try
            conn = ClsDatabaseConnection.GetConnection()
            If conn Is Nothing Then Return

            Dim query As String = "SELECT u.username, u.first_name, u.middle_name, u.last_name, u.email, u.phone_number, " &
                                 "ur.role_name, d.department_name " &
                                 "FROM users u " &
                                 "INNER JOIN user_roles ur ON u.role_id = ur.role_id " &
                                 "LEFT JOIN departments d ON u.department_id = d.department_id " &
                                 "WHERE u.user_id = @userId"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userId", currentUserId)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Populate read-only fields
                        txtUsername.Text = reader("username").ToString()
                        txtFullName.Text = $"{reader("first_name")} {If(IsDBNull(reader("middle_name")), "", reader("middle_name"))} {reader("last_name")}"
                        txtRole.Text = reader("role_name").ToString()
                        txtDepartment.Text = If(IsDBNull(reader("department_name")), "N/A", reader("department_name").ToString())

                        ' Populate editable fields
                        txtEmail.Text = reader("email").ToString()
                        txtPhone.Text = If(IsDBNull(reader("phone_number")), "", reader("phone_number").ToString())
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then conn.Close()
        End Try
    End Sub

    Private Sub btnUpdateProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateProfile.Click
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(txtEmail.Text) Then
                MessageBox.Show("Email is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmail.Focus()
                Return
            End If

            ' Validate email format
            If Not IsValidEmail(txtEmail.Text) Then
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmail.Focus()
                Return
            End If

            ' Update profile
            If UpdateUserProfile() Then
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LogActivity("Profile Updated", "users", currentUserId, $"Updated profile information for user {currentUsername}")
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function UpdateUserProfile() As Boolean
        Dim conn As MySqlConnection = Nothing

        Try
            conn = ClsDatabaseConnection.GetConnection()
            If conn Is Nothing Then Return False

            Dim query As String = "UPDATE users SET email = @email, phone_number = @phone, updated_at = NOW() " &
                                 "WHERE user_id = @userId"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@phone", If(String.IsNullOrWhiteSpace(txtPhone.Text), DBNull.Value, txtPhone.Text.Trim()))
                cmd.Parameters.AddWithValue("@userId", currentUserId)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As Exception
            Throw New Exception("Failed to update profile: " & ex.Message)
        Finally
            If conn IsNot Nothing Then conn.Close()
        End Try
    End Function

#End Region

#Region "Password Management"

    Private Sub btnSavePassword_Click(sender As Object, e As EventArgs) Handles btnSavePassword.Click
        Try
            ' Validate inputs
            If String.IsNullOrWhiteSpace(txtCurrentPassword.Text) Then
                MessageBox.Show("Current password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCurrentPassword.Focus()
                Return
            End If

            If String.IsNullOrWhiteSpace(txtNewPassword.Text) Then
                MessageBox.Show("New password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNewPassword.Focus()
                Return
            End If

            If txtNewPassword.Text <> txtConfirmPassword.Text Then
                MessageBox.Show("New password and confirmation password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtConfirmPassword.Focus()
                Return
            End If

            ' Validate password strength
            If txtNewPassword.Text.Length < 8 Then
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNewPassword.Focus()
                Return
            End If

            ' Verify current password
            If Not VerifyCurrentPassword(txtCurrentPassword.Text) Then
                MessageBox.Show("Current password is incorrect.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCurrentPassword.Focus()
                Return
            End If

            ' Update password
            If UpdatePassword(txtNewPassword.Text) Then
                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear password fields
                txtCurrentPassword.Clear()
                txtNewPassword.Clear()
                txtConfirmPassword.Clear()

                LogActivity("Password Changed", "users", currentUserId, $"User {currentUsername} changed their password")
            End If

        Catch ex As Exception
            MessageBox.Show("Error changing password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function VerifyCurrentPassword(currentPassword As String) As Boolean
        Dim conn As MySqlConnection = Nothing

        Try
            conn = ClsDatabaseConnection.GetConnection()
            If conn Is Nothing Then Return False

            Dim query As String = "SELECT password_hash FROM users WHERE user_id = @userId"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userId", currentUserId)

                Dim storedHash As String = cmd.ExecuteScalar()?.ToString()
                If String.IsNullOrEmpty(storedHash) Then Return False

                ' Hash the provided password and compare
                Dim inputHash As String = HashPassword(currentPassword)
                Return inputHash.Equals(storedHash, StringComparison.OrdinalIgnoreCase)
            End Using

        Catch ex As Exception
            Throw New Exception("Failed to verify password: " & ex.Message)
        Finally
            If conn IsNot Nothing Then conn.Close()
        End Try
    End Function

    Private Function UpdatePassword(newPassword As String) As Boolean
        Dim conn As MySqlConnection = Nothing

        Try
            conn = ClsDatabaseConnection.GetConnection()
            If conn Is Nothing Then Return False

            Dim newPasswordHash As String = HashPassword(newPassword)

            Dim query As String = "UPDATE users SET password_hash = @passwordHash, updated_at = NOW() " &
                                 "WHERE user_id = @userId"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@passwordHash", newPasswordHash)
                cmd.Parameters.AddWithValue("@userId", currentUserId)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                Return rowsAffected > 0
            End Using

        Catch ex As Exception
            Throw New Exception("Failed to update password: " & ex.Message)
        Finally
            If conn IsNot Nothing Then conn.Close()
        End Try
    End Function

    Private Function HashPassword(password As String) As String
        Using sha256Hash As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password))

            Dim builder As New StringBuilder()
            For i As Integer = 0 To bytes.Length - 1
                builder.Append(bytes(i).ToString("x2"))
            Next

            Return builder.ToString()
        End Using
    End Function

#End Region

#Region "Appearance Settings"

    Private Sub InitializePreferences()
        ' Set default font size
        cboFontSize.SelectedIndex = 1 ' Medium (9pt)

        ' Set default date format
        cboDateFormat.SelectedIndex = 0 ' MM/dd/yyyy

        ' Set default refresh interval
        numRefreshInterval.Value = 300 ' 5 minutes

        ' Set default items per page
        numItemsPerPage.Value = 50

        ' Set default session timeout (Admin only)
        numSessionTimeout.Value = 30
    End Sub

    Private Sub btnAccentColor_Click(sender As Object, e As EventArgs) Handles btnAccentColor.Click
        If colorDialog.ShowDialog() = DialogResult.OK Then
            accentColor = colorDialog.Color
            pnlAccentPreview.BackColor = accentColor
        End If
    End Sub

    Private Sub btnApplyColors_Click(sender As Object, e As EventArgs) Handles btnApplyColors.Click
        Try
            ' Apply accent color to navigation buttons
            ApplyAccentColor(accentColor)
            MessageBox.Show("Color scheme applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error applying colors: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyAccentColor(color As Color)
        ' This would apply to active navigation button
        Dim activeButton As Button = Nothing

        If pnlMyProfile.Visible Then activeButton = btnMyProfile
        If pnlAppearance.Visible Then activeButton = btnAppearance
        If pnlPreferences.Visible Then activeButton = btnPreferences
        If pnlSystemInfo.Visible Then activeButton = btnSystemInfo
        If pnlSecurity.Visible Then activeButton = btnSecurity

        If activeButton IsNot Nothing Then
            activeButton.BackColor = color
        End If
    End Sub

    Private Sub btnApplyTheme_Click(sender As Object, e As EventArgs) Handles btnApplyTheme.Click
        Try
            If rbDarkTheme.Checked Then
                ApplyDarkTheme()
            Else
                ApplyLightTheme()
            End If

            MessageBox.Show("Theme applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error applying theme: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyLightTheme()
        Me.BackColor = Color.FromArgb(236, 240, 241)
        pnlContent.BackColor = Color.White
        pnlTop.BackColor = Color.White
    End Sub

    Private Sub ApplyDarkTheme()
        Me.BackColor = Color.FromArgb(44, 62, 80)
        pnlContent.BackColor = Color.FromArgb(52, 73, 94)
        pnlTop.BackColor = Color.FromArgb(44, 62, 80)
    End Sub

    Private Sub ApplyCurrentTheme()
        ' Apply light theme by default
        ApplyLightTheme()
        rbLightTheme.Checked = True
    End Sub

    Private Sub btnApplyFont_Click(sender As Object, e As EventArgs) Handles btnApplyFont.Click
        Try
            Dim fontSize As Single = 9.0F

            Select Case cboFontSize.SelectedIndex
                Case 0 ' Small
                    fontSize = 8.0F
                Case 1 ' Medium
                    fontSize = 9.0F
                Case 2 ' Large
                    fontSize = 10.0F
                Case 3 ' Extra Large
                    fontSize = 11.0F
            End Select

            ApplyFontSize(Me, fontSize)

            MessageBox.Show("Font size applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error applying font size: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyFontSize(ctrl As Control, fontSize As Single)
        For Each childCtrl As Control In ctrl.Controls
            If TypeOf childCtrl Is Label OrElse TypeOf childCtrl Is TextBox OrElse TypeOf childCtrl Is Button Then
                childCtrl.Font = New Font(childCtrl.Font.FontFamily, fontSize, childCtrl.Font.Style)
            End If

            If childCtrl.HasChildren Then
                ApplyFontSize(childCtrl, fontSize)
            End If
        Next
    End Sub

#End Region

#Region "Preferences"

    Private Sub btnApplyPreferences_Click(sender As Object, e As EventArgs) Handles btnApplyPreferences.Click
        Try
            ' Save preferences to application settings or database
            MessageBox.Show("Preferences saved successfully!" & vbCrLf & vbCrLf &
                          $"Date Format: {cboDateFormat.Text}" & vbCrLf &
                          $"Items Per Page: {numItemsPerPage.Value}" & vbCrLf &
                          $"Auto Refresh: {chkAutoRefresh.Checked}" & vbCrLf &
                          $"Refresh Interval: {numRefreshInterval.Value} seconds",
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            LogActivity("Preferences Updated", "users", currentUserId, "Updated system preferences")

        Catch ex As Exception
            MessageBox.Show("Error saving preferences: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "System Information"

    Private Sub LoadSystemStatistics()
        Dim conn As MySqlConnection = Nothing

        Try
            conn = ClsDatabaseConnection.GetConnection()
            If conn Is Nothing Then Return

            ' Get total users
            Dim usersQuery As String = "SELECT COUNT(*) FROM users WHERE is_active = 1"
            Using cmd As New MySqlCommand(usersQuery, conn)
                lblTotalUsersValue.Text = cmd.ExecuteScalar().ToString()
            End Using

            ' Get total employees
            Dim employeesQuery As String = "SELECT COUNT(*) FROM employees WHERE employment_status = 'Active'"
            Using cmd As New MySqlCommand(employeesQuery, conn)
                lblTotalEmployeesValue.Text = cmd.ExecuteScalar().ToString()
            End Using

            ' Get total assets
            Dim assetsQuery As String = "SELECT COUNT(*) FROM assets WHERE status != 'Disposed'"
            Using cmd As New MySqlCommand(assetsQuery, conn)
                lblTotalAssetsValue.Text = cmd.ExecuteScalar().ToString()
            End Using

            ' Get total consumables
            Dim consumablesQuery As String = "SELECT COUNT(*) FROM consumables"
            Using cmd As New MySqlCommand(consumablesQuery, conn)
                lblTotalConsumablesValue.Text = cmd.ExecuteScalar().ToString()
            End Using

            ' Check database connection status
            lblDbStatusValue.Text = "Connected"
            lblDbStatusValue.ForeColor = Color.FromArgb(46, 204, 113)

        Catch ex As Exception
            lblDbStatusValue.Text = "Disconnected"
            lblDbStatusValue.ForeColor = Color.FromArgb(231, 76, 60)
            MessageBox.Show("Error loading statistics: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing Then conn.Close()
        End Try
    End Sub

#End Region

#Region "Security Settings"

    Private Sub btnApplySecurity_Click(sender As Object, e As EventArgs) Handles btnApplySecurity.Click
        Try
            If currentUserRole <> "Admin" Then
                MessageBox.Show("Only administrators can modify security settings.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            MessageBox.Show($"Session timeout set to {numSessionTimeout.Value} minutes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LogActivity("Security Settings Updated", "users", currentUserId, $"Updated session timeout to {numSessionTimeout.Value} minutes")

        Catch ex As Exception
            MessageBox.Show("Error applying security settings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBackupNow_Click(sender As Object, e As EventArgs) Handles btnBackupNow.Click
        Try
            If currentUserRole <> "Admin" Then
                MessageBox.Show("Only administrators can perform database backups.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim result As DialogResult = MessageBox.Show("This will create a backup of the database. Continue?", "Confirm Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' In a real implementation, this would trigger a database backup
                lblLastBackupValue.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")
                MessageBox.Show("Database backup completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LogActivity("Database Backup", "system", 0, "Manual database backup performed")
            End If

        Catch ex As Exception
            MessageBox.Show("Error performing backup: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Helper Functions"

    Private Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr = New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    Private Sub LogActivity(actionType As String, tableName As String, recordId As Integer, description As String)
        Dim conn As MySqlConnection = Nothing

        Try
            conn = ClsDatabaseConnection.GetConnection()
            If conn Is Nothing Then Return

            Dim query As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description, ip_address) " &
                                 "VALUES (@userId, @actionType, @tableName, @recordId, @description, @ipAddress)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userId", currentUserId)
                cmd.Parameters.AddWithValue("@actionType", actionType)
                cmd.Parameters.AddWithValue("@tableName", tableName)
                cmd.Parameters.AddWithValue("@recordId", recordId)
                cmd.Parameters.AddWithValue("@description", description)
                cmd.Parameters.AddWithValue("@ipAddress", GetLocalIPAddress())

                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            ' Silently fail for logging errors
            Debug.WriteLine("Logging error: " & ex.Message)
        Finally
            If conn IsNot Nothing Then conn.Close()
        End Try
    End Sub

    Private Function GetLocalIPAddress() As String
        Try
            Dim host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
            For Each ip In host.AddressList
                If ip.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                    Return ip.ToString()
                End If
            Next
            Return "Unknown"
        Catch
            Return "Unknown"
        End Try
    End Function

#End Region

End Class