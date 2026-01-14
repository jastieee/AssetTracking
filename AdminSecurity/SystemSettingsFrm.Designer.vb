<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SystemSettingsFrm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SystemSettingsFrm))
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlMyProfile = New System.Windows.Forms.Panel()
        Me.grpChangePassword = New System.Windows.Forms.GroupBox()
        Me.btnSavePassword = New System.Windows.Forms.Button()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.lblConfirmPassword = New System.Windows.Forms.Label()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.txtCurrentPassword = New System.Windows.Forms.TextBox()
        Me.lblCurrentPassword = New System.Windows.Forms.Label()
        Me.grpUserInfo = New System.Windows.Forms.GroupBox()
        Me.btnUpdateProfile = New System.Windows.Forms.Button()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtDepartment = New System.Windows.Forms.TextBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.txtRole = New System.Windows.Forms.TextBox()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.pnlAppearance = New System.Windows.Forms.Panel()
        Me.grpColorScheme = New System.Windows.Forms.GroupBox()
        Me.btnApplyColors = New System.Windows.Forms.Button()
        Me.pnlAccentPreview = New System.Windows.Forms.Panel()
        Me.lblAccentPreview = New System.Windows.Forms.Label()
        Me.btnAccentColor = New System.Windows.Forms.Button()
        Me.lblAccentColor = New System.Windows.Forms.Label()
        Me.grpFontSettings = New System.Windows.Forms.GroupBox()
        Me.btnApplyFont = New System.Windows.Forms.Button()
        Me.cboFontSize = New System.Windows.Forms.ComboBox()
        Me.lblFontSize = New System.Windows.Forms.Label()
        Me.grpTheme = New System.Windows.Forms.GroupBox()
        Me.btnApplyTheme = New System.Windows.Forms.Button()
        Me.rbDarkTheme = New System.Windows.Forms.RadioButton()
        Me.rbLightTheme = New System.Windows.Forms.RadioButton()
        Me.pnlPreferences = New System.Windows.Forms.Panel()
        Me.grpNotifications = New System.Windows.Forms.GroupBox()
        Me.chkShowNotifications = New System.Windows.Forms.CheckBox()
        Me.chkSoundAlerts = New System.Windows.Forms.CheckBox()
        Me.grpDisplay = New System.Windows.Forms.GroupBox()
        Me.btnApplyPreferences = New System.Windows.Forms.Button()
        Me.numItemsPerPage = New System.Windows.Forms.NumericUpDown()
        Me.lblItemsPerPage = New System.Windows.Forms.Label()
        Me.cboDateFormat = New System.Windows.Forms.ComboBox()
        Me.lblDateFormat = New System.Windows.Forms.Label()
        Me.grpAutoRefresh = New System.Windows.Forms.GroupBox()
        Me.numRefreshInterval = New System.Windows.Forms.NumericUpDown()
        Me.lblRefreshInterval = New System.Windows.Forms.Label()
        Me.chkAutoRefresh = New System.Windows.Forms.CheckBox()
        Me.pnlSystemInfo = New System.Windows.Forms.Panel()
        Me.grpStatistics = New System.Windows.Forms.GroupBox()
        Me.lblTotalConsumablesValue = New System.Windows.Forms.Label()
        Me.lblTotalConsumables = New System.Windows.Forms.Label()
        Me.lblTotalAssetsValue = New System.Windows.Forms.Label()
        Me.lblTotalAssets = New System.Windows.Forms.Label()
        Me.lblTotalEmployeesValue = New System.Windows.Forms.Label()
        Me.lblTotalEmployees = New System.Windows.Forms.Label()
        Me.lblTotalUsersValue = New System.Windows.Forms.Label()
        Me.lblTotalUsers = New System.Windows.Forms.Label()
        Me.grpDatabase = New System.Windows.Forms.GroupBox()
        Me.lblDbStatusValue = New System.Windows.Forms.Label()
        Me.lblDbStatus = New System.Windows.Forms.Label()
        Me.lblDbNameValue = New System.Windows.Forms.Label()
        Me.lblDbName = New System.Windows.Forms.Label()
        Me.grpAppInfo = New System.Windows.Forms.GroupBox()
        Me.lblBuildDateValue = New System.Windows.Forms.Label()
        Me.lblBuildDate = New System.Windows.Forms.Label()
        Me.lblVersionValue = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblAppNameValue = New System.Windows.Forms.Label()
        Me.lblAppName = New System.Windows.Forms.Label()
        Me.pnlSecurity = New System.Windows.Forms.Panel()
        Me.grpBackup = New System.Windows.Forms.GroupBox()
        Me.btnBackupNow = New System.Windows.Forms.Button()
        Me.lblLastBackupValue = New System.Windows.Forms.Label()
        Me.lblLastBackup = New System.Windows.Forms.Label()
        Me.grpSessionSettings = New System.Windows.Forms.GroupBox()
        Me.btnApplySecurity = New System.Windows.Forms.Button()
        Me.numSessionTimeout = New System.Windows.Forms.NumericUpDown()
        Me.lblSessionTimeout = New System.Windows.Forms.Label()
        Me.grpPasswordPolicy = New System.Windows.Forms.GroupBox()
        Me.lblPolicyInfo = New System.Windows.Forms.Label()
        Me.pnlNavigation = New System.Windows.Forms.Panel()
        Me.btnSecurity = New System.Windows.Forms.Button()
        Me.btnSystemInfo = New System.Windows.Forms.Button()
        Me.btnPreferences = New System.Windows.Forms.Button()
        Me.btnAppearance = New System.Windows.Forms.Button()
        Me.btnMyProfile = New System.Windows.Forms.Button()
        Me.colorDialog = New System.Windows.Forms.ColorDialog()
        Me.pnlTop.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlMyProfile.SuspendLayout()
        Me.grpChangePassword.SuspendLayout()
        Me.grpUserInfo.SuspendLayout()
        Me.pnlAppearance.SuspendLayout()
        Me.grpColorScheme.SuspendLayout()
        Me.grpFontSettings.SuspendLayout()
        Me.grpTheme.SuspendLayout()
        Me.pnlPreferences.SuspendLayout()
        Me.grpNotifications.SuspendLayout()
        Me.grpDisplay.SuspendLayout()
        CType(Me.numItemsPerPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAutoRefresh.SuspendLayout()
        CType(Me.numRefreshInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSystemInfo.SuspendLayout()
        Me.grpStatistics.SuspendLayout()
        Me.grpDatabase.SuspendLayout()
        Me.grpAppInfo.SuspendLayout()
        Me.pnlSecurity.SuspendLayout()
        Me.grpBackup.SuspendLayout()
        Me.grpSessionSettings.SuspendLayout()
        CType(Me.numSessionTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPasswordPolicy.SuspendLayout()
        Me.pnlNavigation.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.White
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.pnlTop.Size = New System.Drawing.Size(1200, 70)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(292, 41)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "⚙️ System Settings"
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlContent)
        Me.pnlMain.Controls.Add(Me.pnlNavigation)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 70)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlMain.Size = New System.Drawing.Size(1200, 630)
        Me.pnlMain.TabIndex = 1
        '
        'pnlContent
        '
        Me.pnlContent.AutoScroll = True
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.pnlMyProfile)
        Me.pnlContent.Controls.Add(Me.pnlAppearance)
        Me.pnlContent.Controls.Add(Me.pnlPreferences)
        Me.pnlContent.Controls.Add(Me.pnlSystemInfo)
        Me.pnlContent.Controls.Add(Me.pnlSecurity)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(220, 20)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(960, 590)
        Me.pnlContent.TabIndex = 1
        '
        'pnlMyProfile
        '
        Me.pnlMyProfile.Controls.Add(Me.grpChangePassword)
        Me.pnlMyProfile.Controls.Add(Me.grpUserInfo)
        Me.pnlMyProfile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMyProfile.Location = New System.Drawing.Point(20, 20)
        Me.pnlMyProfile.Name = "pnlMyProfile"
        Me.pnlMyProfile.Size = New System.Drawing.Size(920, 550)
        Me.pnlMyProfile.TabIndex = 0
        '
        'grpChangePassword
        '
        Me.grpChangePassword.Controls.Add(Me.btnSavePassword)
        Me.grpChangePassword.Controls.Add(Me.txtConfirmPassword)
        Me.grpChangePassword.Controls.Add(Me.lblConfirmPassword)
        Me.grpChangePassword.Controls.Add(Me.txtNewPassword)
        Me.grpChangePassword.Controls.Add(Me.lblNewPassword)
        Me.grpChangePassword.Controls.Add(Me.txtCurrentPassword)
        Me.grpChangePassword.Controls.Add(Me.lblCurrentPassword)
        Me.grpChangePassword.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpChangePassword.Location = New System.Drawing.Point(10, 310)
        Me.grpChangePassword.Name = "grpChangePassword"
        Me.grpChangePassword.Padding = New System.Windows.Forms.Padding(15)
        Me.grpChangePassword.Size = New System.Drawing.Size(880, 220)
        Me.grpChangePassword.TabIndex = 1
        Me.grpChangePassword.TabStop = False
        Me.grpChangePassword.Text = "Change Password"
        '
        'btnSavePassword
        '
        Me.btnSavePassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnSavePassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSavePassword.FlatAppearance.BorderSize = 0
        Me.btnSavePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSavePassword.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSavePassword.ForeColor = System.Drawing.Color.White
        Me.btnSavePassword.Location = New System.Drawing.Point(180, 160)
        Me.btnSavePassword.Name = "btnSavePassword"
        Me.btnSavePassword.Size = New System.Drawing.Size(150, 40)
        Me.btnSavePassword.TabIndex = 6
        Me.btnSavePassword.Text = "💾 Save Password"
        Me.btnSavePassword.UseVisualStyleBackColor = False
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtConfirmPassword.Location = New System.Drawing.Point(180, 115)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(300, 27)
        Me.txtConfirmPassword.TabIndex = 5
        Me.txtConfirmPassword.UseSystemPasswordChar = True
        '
        'lblConfirmPassword
        '
        Me.lblConfirmPassword.AutoSize = True
        Me.lblConfirmPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblConfirmPassword.Location = New System.Drawing.Point(30, 118)
        Me.lblConfirmPassword.Name = "lblConfirmPassword"
        Me.lblConfirmPassword.Size = New System.Drawing.Size(130, 20)
        Me.lblConfirmPassword.TabIndex = 4
        Me.lblConfirmPassword.Text = "Confirm Password:"
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNewPassword.Location = New System.Drawing.Point(180, 75)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtNewPassword.Size = New System.Drawing.Size(300, 27)
        Me.txtNewPassword.TabIndex = 3
        Me.txtNewPassword.UseSystemPasswordChar = True
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNewPassword.Location = New System.Drawing.Point(30, 78)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(107, 20)
        Me.lblNewPassword.TabIndex = 2
        Me.lblNewPassword.Text = "New Password:"
        '
        'txtCurrentPassword
        '
        Me.txtCurrentPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCurrentPassword.Location = New System.Drawing.Point(180, 35)
        Me.txtCurrentPassword.Name = "txtCurrentPassword"
        Me.txtCurrentPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtCurrentPassword.Size = New System.Drawing.Size(300, 27)
        Me.txtCurrentPassword.TabIndex = 1
        Me.txtCurrentPassword.UseSystemPasswordChar = True
        '
        'lblCurrentPassword
        '
        Me.lblCurrentPassword.AutoSize = True
        Me.lblCurrentPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCurrentPassword.Location = New System.Drawing.Point(30, 38)
        Me.lblCurrentPassword.Name = "lblCurrentPassword"
        Me.lblCurrentPassword.Size = New System.Drawing.Size(125, 20)
        Me.lblCurrentPassword.TabIndex = 0
        Me.lblCurrentPassword.Text = "Current Password:"
        '
        'grpUserInfo
        '
        Me.grpUserInfo.Controls.Add(Me.btnUpdateProfile)
        Me.grpUserInfo.Controls.Add(Me.txtPhone)
        Me.grpUserInfo.Controls.Add(Me.lblPhone)
        Me.grpUserInfo.Controls.Add(Me.txtEmail)
        Me.grpUserInfo.Controls.Add(Me.lblEmail)
        Me.grpUserInfo.Controls.Add(Me.txtDepartment)
        Me.grpUserInfo.Controls.Add(Me.lblDepartment)
        Me.grpUserInfo.Controls.Add(Me.txtRole)
        Me.grpUserInfo.Controls.Add(Me.lblRole)
        Me.grpUserInfo.Controls.Add(Me.txtFullName)
        Me.grpUserInfo.Controls.Add(Me.lblFullName)
        Me.grpUserInfo.Controls.Add(Me.txtUsername)
        Me.grpUserInfo.Controls.Add(Me.lblUsername)
        Me.grpUserInfo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpUserInfo.Location = New System.Drawing.Point(10, 10)
        Me.grpUserInfo.Name = "grpUserInfo"
        Me.grpUserInfo.Padding = New System.Windows.Forms.Padding(15)
        Me.grpUserInfo.Size = New System.Drawing.Size(880, 290)
        Me.grpUserInfo.TabIndex = 0
        Me.grpUserInfo.TabStop = False
        Me.grpUserInfo.Text = "User Information"
        '
        'btnUpdateProfile
        '
        Me.btnUpdateProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnUpdateProfile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdateProfile.FlatAppearance.BorderSize = 0
        Me.btnUpdateProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateProfile.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdateProfile.ForeColor = System.Drawing.Color.White
        Me.btnUpdateProfile.Location = New System.Drawing.Point(180, 235)
        Me.btnUpdateProfile.Name = "btnUpdateProfile"
        Me.btnUpdateProfile.Size = New System.Drawing.Size(150, 40)
        Me.btnUpdateProfile.TabIndex = 11
        Me.btnUpdateProfile.Text = "💾 Update Profile"
        Me.btnUpdateProfile.UseVisualStyleBackColor = False
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPhone.Location = New System.Drawing.Point(180, 195)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(300, 27)
        Me.txtPhone.TabIndex = 10
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPhone.Location = New System.Drawing.Point(30, 198)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(111, 20)
        Me.lblPhone.TabIndex = 9
        Me.lblPhone.Text = "Phone Number:"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmail.Location = New System.Drawing.Point(180, 160)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(300, 27)
        Me.txtEmail.TabIndex = 8
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmail.Location = New System.Drawing.Point(30, 163)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(49, 20)
        Me.lblEmail.TabIndex = 7
        Me.lblEmail.Text = "Email:"
        '
        'txtDepartment
        '
        Me.txtDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDepartment.Location = New System.Drawing.Point(180, 125)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.Size = New System.Drawing.Size(300, 27)
        Me.txtDepartment.TabIndex = 6
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartment.Location = New System.Drawing.Point(30, 128)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(92, 20)
        Me.lblDepartment.TabIndex = 5
        Me.lblDepartment.Text = "Department:"
        '
        'txtRole
        '
        Me.txtRole.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRole.Location = New System.Drawing.Point(180, 90)
        Me.txtRole.Name = "txtRole"
        Me.txtRole.ReadOnly = True
        Me.txtRole.Size = New System.Drawing.Size(300, 27)
        Me.txtRole.TabIndex = 4
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRole.Location = New System.Drawing.Point(30, 93)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(42, 20)
        Me.lblRole.TabIndex = 3
        Me.lblRole.Text = "Role:"
        '
        'txtFullName
        '
        Me.txtFullName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFullName.Location = New System.Drawing.Point(180, 55)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.ReadOnly = True
        Me.txtFullName.Size = New System.Drawing.Size(300, 27)
        Me.txtFullName.TabIndex = 2
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFullName.Location = New System.Drawing.Point(30, 58)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(79, 20)
        Me.lblFullName.TabIndex = 1
        Me.lblFullName.Text = "Full Name:"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUsername.Location = New System.Drawing.Point(180, 20)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.Size = New System.Drawing.Size(300, 27)
        Me.txtUsername.TabIndex = 0
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUsername.Location = New System.Drawing.Point(30, 23)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(78, 20)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username:"
        '
        'pnlAppearance
        '
        Me.pnlAppearance.Controls.Add(Me.grpColorScheme)
        Me.pnlAppearance.Controls.Add(Me.grpFontSettings)
        Me.pnlAppearance.Controls.Add(Me.grpTheme)
        Me.pnlAppearance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAppearance.Location = New System.Drawing.Point(20, 20)
        Me.pnlAppearance.Name = "pnlAppearance"
        Me.pnlAppearance.Size = New System.Drawing.Size(920, 550)
        Me.pnlAppearance.TabIndex = 1
        Me.pnlAppearance.Visible = False
        '
        'grpColorScheme
        '
        Me.grpColorScheme.Controls.Add(Me.btnApplyColors)
        Me.grpColorScheme.Controls.Add(Me.pnlAccentPreview)
        Me.grpColorScheme.Controls.Add(Me.lblAccentPreview)
        Me.grpColorScheme.Controls.Add(Me.btnAccentColor)
        Me.grpColorScheme.Controls.Add(Me.lblAccentColor)
        Me.grpColorScheme.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpColorScheme.Location = New System.Drawing.Point(10, 310)
        Me.grpColorScheme.Name = "grpColorScheme"
        Me.grpColorScheme.Padding = New System.Windows.Forms.Padding(15)
        Me.grpColorScheme.Size = New System.Drawing.Size(880, 180)
        Me.grpColorScheme.TabIndex = 2
        Me.grpColorScheme.TabStop = False
        Me.grpColorScheme.Text = "Color Scheme"
        '
        'btnApplyColors
        '
        Me.btnApplyColors.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnApplyColors.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplyColors.FlatAppearance.BorderSize = 0
        Me.btnApplyColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApplyColors.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnApplyColors.ForeColor = System.Drawing.Color.White
        Me.btnApplyColors.Location = New System.Drawing.Point(30, 125)
        Me.btnApplyColors.Name = "btnApplyColors"
        Me.btnApplyColors.Size = New System.Drawing.Size(150, 40)
        Me.btnApplyColors.TabIndex = 4
        Me.btnApplyColors.Text = "✓ Apply Colors"
        Me.btnApplyColors.UseVisualStyleBackColor = False
        '
        'pnlAccentPreview
        '
        Me.pnlAccentPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAccentPreview.Location = New System.Drawing.Point(280, 35)
        Me.pnlAccentPreview.Name = "pnlAccentPreview"
        Me.pnlAccentPreview.Size = New System.Drawing.Size(150, 70)
        Me.pnlAccentPreview.TabIndex = 3
        '
        'lblAccentPreview
        '
        Me.lblAccentPreview.AutoSize = True
        Me.lblAccentPreview.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAccentPreview.Location = New System.Drawing.Point(280, 15)
        Me.lblAccentPreview.Name = "lblAccentPreview"
        Me.lblAccentPreview.Size = New System.Drawing.Size(63, 20)
        Me.lblAccentPreview.TabIndex = 2
        Me.lblAccentPreview.Text = "Preview:"
        '
        'btnAccentColor
        '
        Me.btnAccentColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnAccentColor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAccentColor.FlatAppearance.BorderSize = 0
        Me.btnAccentColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccentColor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAccentColor.ForeColor = System.Drawing.Color.White
        Me.btnAccentColor.Location = New System.Drawing.Point(30, 65)
        Me.btnAccentColor.Name = "btnAccentColor"
        Me.btnAccentColor.Size = New System.Drawing.Size(150, 40)
        Me.btnAccentColor.TabIndex = 1
        Me.btnAccentColor.Text = "🎨 Choose Color"
        Me.btnAccentColor.UseVisualStyleBackColor = False
        '
        'lblAccentColor
        '
        Me.lblAccentColor.AutoSize = True
        Me.lblAccentColor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAccentColor.Location = New System.Drawing.Point(30, 35)
        Me.lblAccentColor.Name = "lblAccentColor"
        Me.lblAccentColor.Size = New System.Drawing.Size(97, 20)
        Me.lblAccentColor.TabIndex = 0
        Me.lblAccentColor.Text = "Accent Color:"
        '
        'grpFontSettings
        '
        Me.grpFontSettings.Controls.Add(Me.btnApplyFont)
        Me.grpFontSettings.Controls.Add(Me.cboFontSize)
        Me.grpFontSettings.Controls.Add(Me.lblFontSize)
        Me.grpFontSettings.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpFontSettings.Location = New System.Drawing.Point(10, 170)
        Me.grpFontSettings.Name = "grpFontSettings"
        Me.grpFontSettings.Padding = New System.Windows.Forms.Padding(15)
        Me.grpFontSettings.Size = New System.Drawing.Size(880, 130)
        Me.grpFontSettings.TabIndex = 1
        Me.grpFontSettings.TabStop = False
        Me.grpFontSettings.Text = "Font Settings"
        '
        'btnApplyFont
        '
        Me.btnApplyFont.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnApplyFont.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplyFont.FlatAppearance.BorderSize = 0
        Me.btnApplyFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApplyFont.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnApplyFont.ForeColor = System.Drawing.Color.White
        Me.btnApplyFont.Location = New System.Drawing.Point(280, 70)
        Me.btnApplyFont.Name = "btnApplyFont"
        Me.btnApplyFont.Size = New System.Drawing.Size(150, 40)
        Me.btnApplyFont.TabIndex = 2
        Me.btnApplyFont.Text = "✓ Apply Font Size"
        Me.btnApplyFont.UseVisualStyleBackColor = False
        '
        'cboFontSize
        '
        Me.cboFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFontSize.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboFontSize.FormattingEnabled = True
        Me.cboFontSize.Items.AddRange(New Object() {"Small (8pt)", "Medium (9pt)", "Large (10pt)", "Extra Large (11pt)"})
        Me.cboFontSize.Location = New System.Drawing.Point(30, 75)
        Me.cboFontSize.Name = "cboFontSize"
        Me.cboFontSize.Size = New System.Drawing.Size(200, 28)
        Me.cboFontSize.TabIndex = 1
        '
        'lblFontSize
        '
        Me.lblFontSize.AutoSize = True
        Me.lblFontSize.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFontSize.Location = New System.Drawing.Point(30, 45)
        Me.lblFontSize.Name = "lblFontSize"
        Me.lblFontSize.Size = New System.Drawing.Size(72, 20)
        Me.lblFontSize.TabIndex = 0
        Me.lblFontSize.Text = "Font Size:"
        '
        'grpTheme
        '
        Me.grpTheme.Controls.Add(Me.btnApplyTheme)
        Me.grpTheme.Controls.Add(Me.rbDarkTheme)
        Me.grpTheme.Controls.Add(Me.rbLightTheme)
        Me.grpTheme.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpTheme.Location = New System.Drawing.Point(10, 10)
        Me.grpTheme.Name = "grpTheme"
        Me.grpTheme.Padding = New System.Windows.Forms.Padding(15)
        Me.grpTheme.Size = New System.Drawing.Size(880, 150)
        Me.grpTheme.TabIndex = 0
        Me.grpTheme.TabStop = False
        Me.grpTheme.Text = "Application Theme"
        '
        'btnApplyTheme
        '
        Me.btnApplyTheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnApplyTheme.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplyTheme.FlatAppearance.BorderSize = 0
        Me.btnApplyTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApplyTheme.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnApplyTheme.ForeColor = System.Drawing.Color.White
        Me.btnApplyTheme.Location = New System.Drawing.Point(30, 95)
        Me.btnApplyTheme.Name = "btnApplyTheme"
        Me.btnApplyTheme.Size = New System.Drawing.Size(150, 40)
        Me.btnApplyTheme.TabIndex = 2
        Me.btnApplyTheme.Text = "✓ Apply Theme"
        Me.btnApplyTheme.UseVisualStyleBackColor = False
        '
        'rbDarkTheme
        '
        Me.rbDarkTheme.AutoSize = True
        Me.rbDarkTheme.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbDarkTheme.Location = New System.Drawing.Point(30, 65)
        Me.rbDarkTheme.Name = "rbDarkTheme"
        Me.rbDarkTheme.Size = New System.Drawing.Size(135, 24)
        Me.rbDarkTheme.TabIndex = 1
        Me.rbDarkTheme.Text = "🌙 Dark Theme"
        Me.rbDarkTheme.UseVisualStyleBackColor = True
        '
        'rbLightTheme
        '
        Me.rbLightTheme.AutoSize = True
        Me.rbLightTheme.Checked = True
        Me.rbLightTheme.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbLightTheme.Location = New System.Drawing.Point(30, 35)
        Me.rbLightTheme.Name = "rbLightTheme"
        Me.rbLightTheme.Size = New System.Drawing.Size(137, 24)
        Me.rbLightTheme.TabIndex = 0
        Me.rbLightTheme.TabStop = True
        Me.rbLightTheme.Text = "☀️ Light Theme"
        Me.rbLightTheme.UseVisualStyleBackColor = True
        '
        'pnlPreferences
        '
        Me.pnlPreferences.Controls.Add(Me.grpNotifications)
        Me.pnlPreferences.Controls.Add(Me.grpDisplay)
        Me.pnlPreferences.Controls.Add(Me.grpAutoRefresh)
        Me.pnlPreferences.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPreferences.Location = New System.Drawing.Point(20, 20)
        Me.pnlPreferences.Name = "pnlPreferences"
        Me.pnlPreferences.Size = New System.Drawing.Size(920, 550)
        Me.pnlPreferences.TabIndex = 2
        Me.pnlPreferences.Visible = False
        '
        'grpNotifications
        '
        Me.grpNotifications.Controls.Add(Me.chkShowNotifications)
        Me.grpNotifications.Controls.Add(Me.chkSoundAlerts)
        Me.grpNotifications.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpNotifications.Location = New System.Drawing.Point(10, 350)
        Me.grpNotifications.Name = "grpNotifications"
        Me.grpNotifications.Padding = New System.Windows.Forms.Padding(15)
        Me.grpNotifications.Size = New System.Drawing.Size(880, 130)
        Me.grpNotifications.TabIndex = 2
        Me.grpNotifications.TabStop = False
        Me.grpNotifications.Text = "Notifications"
        '
        'chkShowNotifications
        '
        Me.chkShowNotifications.AutoSize = True
        Me.chkShowNotifications.Checked = True
        Me.chkShowNotifications.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowNotifications.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkShowNotifications.Location = New System.Drawing.Point(30, 40)
        Me.chkShowNotifications.Name = "chkShowNotifications"
        Me.chkShowNotifications.Size = New System.Drawing.Size(202, 24)
        Me.chkShowNotifications.TabIndex = 0
        Me.chkShowNotifications.Text = "Show system notifications"
        Me.chkShowNotifications.UseVisualStyleBackColor = True
        '
        'chkSoundAlerts
        '
        Me.chkSoundAlerts.AutoSize = True
        Me.chkSoundAlerts.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkSoundAlerts.Location = New System.Drawing.Point(30, 75)
        Me.chkSoundAlerts.Name = "chkSoundAlerts"
        Me.chkSoundAlerts.Size = New System.Drawing.Size(160, 24)
        Me.chkSoundAlerts.TabIndex = 1
        Me.chkSoundAlerts.Text = "Enable sound alerts"
        Me.chkSoundAlerts.UseVisualStyleBackColor = True
        '
        'grpDisplay
        '
        Me.grpDisplay.Controls.Add(Me.btnApplyPreferences)
        Me.grpDisplay.Controls.Add(Me.numItemsPerPage)
        Me.grpDisplay.Controls.Add(Me.lblItemsPerPage)
        Me.grpDisplay.Controls.Add(Me.cboDateFormat)
        Me.grpDisplay.Controls.Add(Me.lblDateFormat)
        Me.grpDisplay.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpDisplay.Location = New System.Drawing.Point(10, 180)
        Me.grpDisplay.Name = "grpDisplay"
        Me.grpDisplay.Padding = New System.Windows.Forms.Padding(15)
        Me.grpDisplay.Size = New System.Drawing.Size(880, 160)
        Me.grpDisplay.TabIndex = 1
        Me.grpDisplay.TabStop = False
        Me.grpDisplay.Text = "Display Settings"
        '
        'btnApplyPreferences
        '
        Me.btnApplyPreferences.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnApplyPreferences.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplyPreferences.FlatAppearance.BorderSize = 0
        Me.btnApplyPreferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApplyPreferences.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnApplyPreferences.ForeColor = System.Drawing.Color.White
        Me.btnApplyPreferences.Location = New System.Drawing.Point(450, 40)
        Me.btnApplyPreferences.Name = "btnApplyPreferences"
        Me.btnApplyPreferences.Size = New System.Drawing.Size(150, 40)
        Me.btnApplyPreferences.TabIndex = 4
        Me.btnApplyPreferences.Text = "✓ Apply Settings"
        Me.btnApplyPreferences.UseVisualStyleBackColor = False
        '
        'numItemsPerPage
        '
        Me.numItemsPerPage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numItemsPerPage.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numItemsPerPage.Location = New System.Drawing.Point(180, 90)
        Me.numItemsPerPage.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.numItemsPerPage.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numItemsPerPage.Name = "numItemsPerPage"
        Me.numItemsPerPage.Size = New System.Drawing.Size(200, 27)
        Me.numItemsPerPage.TabIndex = 3
        Me.numItemsPerPage.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'lblItemsPerPage
        '
        Me.lblItemsPerPage.AutoSize = True
        Me.lblItemsPerPage.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblItemsPerPage.Location = New System.Drawing.Point(30, 92)
        Me.lblItemsPerPage.Name = "lblItemsPerPage"
        Me.lblItemsPerPage.Size = New System.Drawing.Size(108, 20)
        Me.lblItemsPerPage.TabIndex = 2
        Me.lblItemsPerPage.Text = "Items Per Page:"
        '
        'cboDateFormat
        '
        Me.cboDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDateFormat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboDateFormat.FormattingEnabled = True
        Me.cboDateFormat.Items.AddRange(New Object() {"MM/dd/yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "MMM dd, yyyy", "MMMM dd, yyyy"})
        Me.cboDateFormat.Location = New System.Drawing.Point(180, 45)
        Me.cboDateFormat.Name = "cboDateFormat"
        Me.cboDateFormat.Size = New System.Drawing.Size(200, 28)
        Me.cboDateFormat.TabIndex = 1
        '
        'lblDateFormat
        '
        Me.lblDateFormat.AutoSize = True
        Me.lblDateFormat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDateFormat.Location = New System.Drawing.Point(30, 48)
        Me.lblDateFormat.Name = "lblDateFormat"
        Me.lblDateFormat.Size = New System.Drawing.Size(95, 20)
        Me.lblDateFormat.TabIndex = 0
        Me.lblDateFormat.Text = "Date Format:"
        '
        'grpAutoRefresh
        '
        Me.grpAutoRefresh.Controls.Add(Me.numRefreshInterval)
        Me.grpAutoRefresh.Controls.Add(Me.lblRefreshInterval)
        Me.grpAutoRefresh.Controls.Add(Me.chkAutoRefresh)
        Me.grpAutoRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpAutoRefresh.Location = New System.Drawing.Point(10, 10)
        Me.grpAutoRefresh.Name = "grpAutoRefresh"
        Me.grpAutoRefresh.Padding = New System.Windows.Forms.Padding(15)
        Me.grpAutoRefresh.Size = New System.Drawing.Size(880, 160)
        Me.grpAutoRefresh.TabIndex = 0
        Me.grpAutoRefresh.TabStop = False
        Me.grpAutoRefresh.Text = "Auto-Refresh Dashboard"
        '
        'numRefreshInterval
        '
        Me.numRefreshInterval.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numRefreshInterval.Increment = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numRefreshInterval.Location = New System.Drawing.Point(180, 90)
        Me.numRefreshInterval.Maximum = New Decimal(New Integer() {600, 0, 0, 0})
        Me.numRefreshInterval.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numRefreshInterval.Name = "numRefreshInterval"
        Me.numRefreshInterval.Size = New System.Drawing.Size(200, 27)
        Me.numRefreshInterval.TabIndex = 2
        Me.numRefreshInterval.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'lblRefreshInterval
        '
        Me.lblRefreshInterval.AutoSize = True
        Me.lblRefreshInterval.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRefreshInterval.Location = New System.Drawing.Point(30, 92)
        Me.lblRefreshInterval.Name = "lblRefreshInterval"
        Me.lblRefreshInterval.Size = New System.Drawing.Size(144, 20)
        Me.lblRefreshInterval.TabIndex = 1
        Me.lblRefreshInterval.Text = "Interval (in seconds):"
        '
        'chkAutoRefresh
        '
        Me.chkAutoRefresh.AutoSize = True
        Me.chkAutoRefresh.Checked = True
        Me.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkAutoRefresh.Location = New System.Drawing.Point(30, 50)
        Me.chkAutoRefresh.Name = "chkAutoRefresh"
        Me.chkAutoRefresh.Size = New System.Drawing.Size(271, 24)
        Me.chkAutoRefresh.TabIndex = 0
        Me.chkAutoRefresh.Text = "Enable automatic dashboard refresh"
        Me.chkAutoRefresh.UseVisualStyleBackColor = True
        '
        'pnlSystemInfo
        '
        Me.pnlSystemInfo.Controls.Add(Me.grpStatistics)
        Me.pnlSystemInfo.Controls.Add(Me.grpDatabase)
        Me.pnlSystemInfo.Controls.Add(Me.grpAppInfo)
        Me.pnlSystemInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSystemInfo.Location = New System.Drawing.Point(20, 20)
        Me.pnlSystemInfo.Name = "pnlSystemInfo"
        Me.pnlSystemInfo.Size = New System.Drawing.Size(920, 550)
        Me.pnlSystemInfo.TabIndex = 3
        Me.pnlSystemInfo.Visible = False
        '
        'grpStatistics
        '
        Me.grpStatistics.Controls.Add(Me.lblTotalConsumablesValue)
        Me.grpStatistics.Controls.Add(Me.lblTotalConsumables)
        Me.grpStatistics.Controls.Add(Me.lblTotalAssetsValue)
        Me.grpStatistics.Controls.Add(Me.lblTotalAssets)
        Me.grpStatistics.Controls.Add(Me.lblTotalEmployeesValue)
        Me.grpStatistics.Controls.Add(Me.lblTotalEmployees)
        Me.grpStatistics.Controls.Add(Me.lblTotalUsersValue)
        Me.grpStatistics.Controls.Add(Me.lblTotalUsers)
        Me.grpStatistics.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpStatistics.Location = New System.Drawing.Point(10, 340)
        Me.grpStatistics.Name = "grpStatistics"
        Me.grpStatistics.Padding = New System.Windows.Forms.Padding(15)
        Me.grpStatistics.Size = New System.Drawing.Size(880, 180)
        Me.grpStatistics.TabIndex = 2
        Me.grpStatistics.TabStop = False
        Me.grpStatistics.Text = "System Statistics"
        '
        'lblTotalConsumablesValue
        '
        Me.lblTotalConsumablesValue.AutoSize = True
        Me.lblTotalConsumablesValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalConsumablesValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.lblTotalConsumablesValue.Location = New System.Drawing.Point(250, 135)
        Me.lblTotalConsumablesValue.Name = "lblTotalConsumablesValue"
        Me.lblTotalConsumablesValue.Size = New System.Drawing.Size(18, 20)
        Me.lblTotalConsumablesValue.TabIndex = 7
        Me.lblTotalConsumablesValue.Text = "0"
        '
        'lblTotalConsumables
        '
        Me.lblTotalConsumables.AutoSize = True
        Me.lblTotalConsumables.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotalConsumables.Location = New System.Drawing.Point(30, 135)
        Me.lblTotalConsumables.Name = "lblTotalConsumables"
        Me.lblTotalConsumables.Size = New System.Drawing.Size(137, 20)
        Me.lblTotalConsumables.TabIndex = 6
        Me.lblTotalConsumables.Text = "Total Consumables:"
        '
        'lblTotalAssetsValue
        '
        Me.lblTotalAssetsValue.AutoSize = True
        Me.lblTotalAssetsValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAssetsValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblTotalAssetsValue.Location = New System.Drawing.Point(250, 100)
        Me.lblTotalAssetsValue.Name = "lblTotalAssetsValue"
        Me.lblTotalAssetsValue.Size = New System.Drawing.Size(18, 20)
        Me.lblTotalAssetsValue.TabIndex = 5
        Me.lblTotalAssetsValue.Text = "0"
        '
        'lblTotalAssets
        '
        Me.lblTotalAssets.AutoSize = True
        Me.lblTotalAssets.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotalAssets.Location = New System.Drawing.Point(30, 100)
        Me.lblTotalAssets.Name = "lblTotalAssets"
        Me.lblTotalAssets.Size = New System.Drawing.Size(90, 20)
        Me.lblTotalAssets.TabIndex = 4
        Me.lblTotalAssets.Text = "Total Assets:"
        '
        'lblTotalEmployeesValue
        '
        Me.lblTotalEmployeesValue.AutoSize = True
        Me.lblTotalEmployeesValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalEmployeesValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.lblTotalEmployeesValue.Location = New System.Drawing.Point(250, 65)
        Me.lblTotalEmployeesValue.Name = "lblTotalEmployeesValue"
        Me.lblTotalEmployeesValue.Size = New System.Drawing.Size(18, 20)
        Me.lblTotalEmployeesValue.TabIndex = 3
        Me.lblTotalEmployeesValue.Text = "0"
        '
        'lblTotalEmployees
        '
        Me.lblTotalEmployees.AutoSize = True
        Me.lblTotalEmployees.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotalEmployees.Location = New System.Drawing.Point(30, 65)
        Me.lblTotalEmployees.Name = "lblTotalEmployees"
        Me.lblTotalEmployees.Size = New System.Drawing.Size(121, 20)
        Me.lblTotalEmployees.TabIndex = 2
        Me.lblTotalEmployees.Text = "Total Employees:"
        '
        'lblTotalUsersValue
        '
        Me.lblTotalUsersValue.AutoSize = True
        Me.lblTotalUsersValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalUsersValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblTotalUsersValue.Location = New System.Drawing.Point(250, 30)
        Me.lblTotalUsersValue.Name = "lblTotalUsersValue"
        Me.lblTotalUsersValue.Size = New System.Drawing.Size(18, 20)
        Me.lblTotalUsersValue.TabIndex = 1
        Me.lblTotalUsersValue.Text = "0"
        '
        'lblTotalUsers
        '
        Me.lblTotalUsers.AutoSize = True
        Me.lblTotalUsers.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotalUsers.Location = New System.Drawing.Point(30, 30)
        Me.lblTotalUsers.Name = "lblTotalUsers"
        Me.lblTotalUsers.Size = New System.Drawing.Size(84, 20)
        Me.lblTotalUsers.TabIndex = 0
        Me.lblTotalUsers.Text = "Total Users:"
        '
        'grpDatabase
        '
        Me.grpDatabase.Controls.Add(Me.lblDbStatusValue)
        Me.grpDatabase.Controls.Add(Me.lblDbStatus)
        Me.grpDatabase.Controls.Add(Me.lblDbNameValue)
        Me.grpDatabase.Controls.Add(Me.lblDbName)
        Me.grpDatabase.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpDatabase.Location = New System.Drawing.Point(10, 190)
        Me.grpDatabase.Name = "grpDatabase"
        Me.grpDatabase.Padding = New System.Windows.Forms.Padding(15)
        Me.grpDatabase.Size = New System.Drawing.Size(880, 140)
        Me.grpDatabase.TabIndex = 1
        Me.grpDatabase.TabStop = False
        Me.grpDatabase.Text = "Database Information"
        '
        'lblDbStatusValue
        '
        Me.lblDbStatusValue.AutoSize = True
        Me.lblDbStatusValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDbStatusValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblDbStatusValue.Location = New System.Drawing.Point(250, 75)
        Me.lblDbStatusValue.Name = "lblDbStatusValue"
        Me.lblDbStatusValue.Size = New System.Drawing.Size(83, 20)
        Me.lblDbStatusValue.TabIndex = 3
        Me.lblDbStatusValue.Text = "Connected"
        '
        'lblDbStatus
        '
        Me.lblDbStatus.AutoSize = True
        Me.lblDbStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDbStatus.Location = New System.Drawing.Point(30, 75)
        Me.lblDbStatus.Name = "lblDbStatus"
        Me.lblDbStatus.Size = New System.Drawing.Size(131, 20)
        Me.lblDbStatus.TabIndex = 2
        Me.lblDbStatus.Text = "Connection Status:"
        '
        'lblDbNameValue
        '
        Me.lblDbNameValue.AutoSize = True
        Me.lblDbNameValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDbNameValue.Location = New System.Drawing.Point(250, 40)
        Me.lblDbNameValue.Name = "lblDbNameValue"
        Me.lblDbNameValue.Size = New System.Drawing.Size(164, 20)
        Me.lblDbNameValue.TabIndex = 1
        Me.lblDbNameValue.Text = "asset_tracking_system"
        '
        'lblDbName
        '
        Me.lblDbName.AutoSize = True
        Me.lblDbName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDbName.Location = New System.Drawing.Point(30, 40)
        Me.lblDbName.Name = "lblDbName"
        Me.lblDbName.Size = New System.Drawing.Size(119, 20)
        Me.lblDbName.TabIndex = 0
        Me.lblDbName.Text = "Database Name:"
        '
        'grpAppInfo
        '
        Me.grpAppInfo.Controls.Add(Me.lblBuildDateValue)
        Me.grpAppInfo.Controls.Add(Me.lblBuildDate)
        Me.grpAppInfo.Controls.Add(Me.lblVersionValue)
        Me.grpAppInfo.Controls.Add(Me.lblVersion)
        Me.grpAppInfo.Controls.Add(Me.lblAppNameValue)
        Me.grpAppInfo.Controls.Add(Me.lblAppName)
        Me.grpAppInfo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpAppInfo.Location = New System.Drawing.Point(10, 10)
        Me.grpAppInfo.Name = "grpAppInfo"
        Me.grpAppInfo.Padding = New System.Windows.Forms.Padding(15)
        Me.grpAppInfo.Size = New System.Drawing.Size(880, 170)
        Me.grpAppInfo.TabIndex = 0
        Me.grpAppInfo.TabStop = False
        Me.grpAppInfo.Text = "Application Information"
        '
        'lblBuildDateValue
        '
        Me.lblBuildDateValue.AutoSize = True
        Me.lblBuildDateValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblBuildDateValue.Location = New System.Drawing.Point(250, 110)
        Me.lblBuildDateValue.Name = "lblBuildDateValue"
        Me.lblBuildDateValue.Size = New System.Drawing.Size(105, 20)
        Me.lblBuildDateValue.TabIndex = 5
        Me.lblBuildDateValue.Text = "October 2025"
        '
        'lblBuildDate
        '
        Me.lblBuildDate.AutoSize = True
        Me.lblBuildDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBuildDate.Location = New System.Drawing.Point(30, 110)
        Me.lblBuildDate.Name = "lblBuildDate"
        Me.lblBuildDate.Size = New System.Drawing.Size(82, 20)
        Me.lblBuildDate.TabIndex = 4
        Me.lblBuildDate.Text = "Build Date:"
        '
        'lblVersionValue
        '
        Me.lblVersionValue.AutoSize = True
        Me.lblVersionValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblVersionValue.Location = New System.Drawing.Point(250, 75)
        Me.lblVersionValue.Name = "lblVersionValue"
        Me.lblVersionValue.Size = New System.Drawing.Size(44, 20)
        Me.lblVersionValue.TabIndex = 3
        Me.lblVersionValue.Text = "1.0.0"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblVersion.Location = New System.Drawing.Point(30, 75)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(60, 20)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "Version:"
        '
        'lblAppNameValue
        '
        Me.lblAppNameValue.AutoSize = True
        Me.lblAppNameValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAppNameValue.Location = New System.Drawing.Point(250, 40)
        Me.lblAppNameValue.Name = "lblAppNameValue"
        Me.lblAppNameValue.Size = New System.Drawing.Size(200, 20)
        Me.lblAppNameValue.TabIndex = 1
        Me.lblAppNameValue.Text = "Asset Tracking System v1.0"
        '
        'lblAppName
        '
        Me.lblAppName.AutoSize = True
        Me.lblAppName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAppName.Location = New System.Drawing.Point(30, 40)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(133, 20)
        Me.lblAppName.TabIndex = 0
        Me.lblAppName.Text = "Application Name:"
        '
        'pnlSecurity
        '
        Me.pnlSecurity.Controls.Add(Me.grpBackup)
        Me.pnlSecurity.Controls.Add(Me.grpSessionSettings)
        Me.pnlSecurity.Controls.Add(Me.grpPasswordPolicy)
        Me.pnlSecurity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSecurity.Location = New System.Drawing.Point(20, 20)
        Me.pnlSecurity.Name = "pnlSecurity"
        Me.pnlSecurity.Size = New System.Drawing.Size(920, 550)
        Me.pnlSecurity.TabIndex = 4
        Me.pnlSecurity.Visible = False
        '
        'grpBackup
        '
        Me.grpBackup.Controls.Add(Me.btnBackupNow)
        Me.grpBackup.Controls.Add(Me.lblLastBackupValue)
        Me.grpBackup.Controls.Add(Me.lblLastBackup)
        Me.grpBackup.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpBackup.Location = New System.Drawing.Point(10, 370)
        Me.grpBackup.Name = "grpBackup"
        Me.grpBackup.Padding = New System.Windows.Forms.Padding(15)
        Me.grpBackup.Size = New System.Drawing.Size(880, 150)
        Me.grpBackup.TabIndex = 2
        Me.grpBackup.TabStop = False
        Me.grpBackup.Text = "Database Backup"
        '
        'btnBackupNow
        '
        Me.btnBackupNow.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnBackupNow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBackupNow.FlatAppearance.BorderSize = 0
        Me.btnBackupNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackupNow.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnBackupNow.ForeColor = System.Drawing.Color.White
        Me.btnBackupNow.Location = New System.Drawing.Point(30, 90)
        Me.btnBackupNow.Name = "btnBackupNow"
        Me.btnBackupNow.Size = New System.Drawing.Size(180, 40)
        Me.btnBackupNow.TabIndex = 2
        Me.btnBackupNow.Text = "💾 Backup Now"
        Me.btnBackupNow.UseVisualStyleBackColor = False
        '
        'lblLastBackupValue
        '
        Me.lblLastBackupValue.AutoSize = True
        Me.lblLastBackupValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLastBackupValue.Location = New System.Drawing.Point(250, 50)
        Me.lblLastBackupValue.Name = "lblLastBackupValue"
        Me.lblLastBackupValue.Size = New System.Drawing.Size(51, 20)
        Me.lblLastBackupValue.TabIndex = 1
        Me.lblLastBackupValue.Text = "Never"
        '
        'lblLastBackup
        '
        Me.lblLastBackup.AutoSize = True
        Me.lblLastBackup.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLastBackup.Location = New System.Drawing.Point(30, 50)
        Me.lblLastBackup.Name = "lblLastBackup"
        Me.lblLastBackup.Size = New System.Drawing.Size(90, 20)
        Me.lblLastBackup.TabIndex = 0
        Me.lblLastBackup.Text = "Last Backup:"
        '
        'grpSessionSettings
        '
        Me.grpSessionSettings.Controls.Add(Me.btnApplySecurity)
        Me.grpSessionSettings.Controls.Add(Me.numSessionTimeout)
        Me.grpSessionSettings.Controls.Add(Me.lblSessionTimeout)
        Me.grpSessionSettings.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpSessionSettings.Location = New System.Drawing.Point(10, 210)
        Me.grpSessionSettings.Name = "grpSessionSettings"
        Me.grpSessionSettings.Padding = New System.Windows.Forms.Padding(15)
        Me.grpSessionSettings.Size = New System.Drawing.Size(880, 150)
        Me.grpSessionSettings.TabIndex = 1
        Me.grpSessionSettings.TabStop = False
        Me.grpSessionSettings.Text = "Session Settings (Admin Only)"
        '
        'btnApplySecurity
        '
        Me.btnApplySecurity.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnApplySecurity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApplySecurity.FlatAppearance.BorderSize = 0
        Me.btnApplySecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApplySecurity.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnApplySecurity.ForeColor = System.Drawing.Color.White
        Me.btnApplySecurity.Location = New System.Drawing.Point(450, 50)
        Me.btnApplySecurity.Name = "btnApplySecurity"
        Me.btnApplySecurity.Size = New System.Drawing.Size(150, 40)
        Me.btnApplySecurity.TabIndex = 2
        Me.btnApplySecurity.Text = "✓ Apply Settings"
        Me.btnApplySecurity.UseVisualStyleBackColor = False
        '
        'numSessionTimeout
        '
        Me.numSessionTimeout.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.numSessionTimeout.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numSessionTimeout.Location = New System.Drawing.Point(250, 60)
        Me.numSessionTimeout.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.numSessionTimeout.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numSessionTimeout.Name = "numSessionTimeout"
        Me.numSessionTimeout.Size = New System.Drawing.Size(150, 27)
        Me.numSessionTimeout.TabIndex = 1
        Me.numSessionTimeout.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'lblSessionTimeout
        '
        Me.lblSessionTimeout.AutoSize = True
        Me.lblSessionTimeout.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSessionTimeout.Location = New System.Drawing.Point(30, 62)
        Me.lblSessionTimeout.Name = "lblSessionTimeout"
        Me.lblSessionTimeout.Size = New System.Drawing.Size(186, 20)
        Me.lblSessionTimeout.TabIndex = 0
        Me.lblSessionTimeout.Text = "Session Timeout (minutes):"
        '
        'grpPasswordPolicy
        '
        Me.grpPasswordPolicy.Controls.Add(Me.lblPolicyInfo)
        Me.grpPasswordPolicy.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpPasswordPolicy.Location = New System.Drawing.Point(10, 10)
        Me.grpPasswordPolicy.Name = "grpPasswordPolicy"
        Me.grpPasswordPolicy.Padding = New System.Windows.Forms.Padding(15)
        Me.grpPasswordPolicy.Size = New System.Drawing.Size(880, 190)
        Me.grpPasswordPolicy.TabIndex = 0
        Me.grpPasswordPolicy.TabStop = False
        Me.grpPasswordPolicy.Text = "Password Policy"
        '
        'lblPolicyInfo
        '
        Me.lblPolicyInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPolicyInfo.Location = New System.Drawing.Point(30, 40)
        Me.lblPolicyInfo.Name = "lblPolicyInfo"
        Me.lblPolicyInfo.Size = New System.Drawing.Size(820, 130)
        Me.lblPolicyInfo.TabIndex = 0
        Me.lblPolicyInfo.Text = resources.GetString("lblPolicyInfo.Text")
        '
        'pnlNavigation
        '
        Me.pnlNavigation.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.pnlNavigation.Controls.Add(Me.btnSecurity)
        Me.pnlNavigation.Controls.Add(Me.btnSystemInfo)
        Me.pnlNavigation.Controls.Add(Me.btnPreferences)
        Me.pnlNavigation.Controls.Add(Me.btnAppearance)
        Me.pnlNavigation.Controls.Add(Me.btnMyProfile)
        Me.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlNavigation.Location = New System.Drawing.Point(20, 20)
        Me.pnlNavigation.Name = "pnlNavigation"
        Me.pnlNavigation.Size = New System.Drawing.Size(200, 590)
        Me.pnlNavigation.TabIndex = 0
        '
        'btnSecurity
        '
        Me.btnSecurity.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnSecurity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSecurity.FlatAppearance.BorderSize = 0
        Me.btnSecurity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSecurity.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSecurity.ForeColor = System.Drawing.Color.White
        Me.btnSecurity.Location = New System.Drawing.Point(0, 160)
        Me.btnSecurity.Name = "btnSecurity"
        Me.btnSecurity.Size = New System.Drawing.Size(200, 50)
        Me.btnSecurity.TabIndex = 4
        Me.btnSecurity.Text = "🔐 Security"
        Me.btnSecurity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSecurity.UseVisualStyleBackColor = False
        '
        'btnSystemInfo
        '
        Me.btnSystemInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnSystemInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSystemInfo.FlatAppearance.BorderSize = 0
        Me.btnSystemInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSystemInfo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSystemInfo.ForeColor = System.Drawing.Color.White
        Me.btnSystemInfo.Location = New System.Drawing.Point(0, 120)
        Me.btnSystemInfo.Name = "btnSystemInfo"
        Me.btnSystemInfo.Size = New System.Drawing.Size(200, 50)
        Me.btnSystemInfo.TabIndex = 3
        Me.btnSystemInfo.Text = "ℹ️ System Info"
        Me.btnSystemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSystemInfo.UseVisualStyleBackColor = False
        '
        'btnPreferences
        '
        Me.btnPreferences.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnPreferences.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPreferences.FlatAppearance.BorderSize = 0
        Me.btnPreferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreferences.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPreferences.ForeColor = System.Drawing.Color.White
        Me.btnPreferences.Location = New System.Drawing.Point(0, 80)
        Me.btnPreferences.Name = "btnPreferences"
        Me.btnPreferences.Size = New System.Drawing.Size(200, 50)
        Me.btnPreferences.TabIndex = 2
        Me.btnPreferences.Text = "⚙️ Preferences"
        Me.btnPreferences.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreferences.UseVisualStyleBackColor = False
        '
        'btnAppearance
        '
        Me.btnAppearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnAppearance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAppearance.FlatAppearance.BorderSize = 0
        Me.btnAppearance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAppearance.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAppearance.ForeColor = System.Drawing.Color.White
        Me.btnAppearance.Location = New System.Drawing.Point(0, 40)
        Me.btnAppearance.Name = "btnAppearance"
        Me.btnAppearance.Size = New System.Drawing.Size(200, 50)
        Me.btnAppearance.TabIndex = 1
        Me.btnAppearance.Text = "🎨 Appearance"
        Me.btnAppearance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAppearance.UseVisualStyleBackColor = False
        '
        'btnMyProfile
        '
        Me.btnMyProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnMyProfile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMyProfile.FlatAppearance.BorderSize = 0
        Me.btnMyProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMyProfile.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnMyProfile.ForeColor = System.Drawing.Color.White
        Me.btnMyProfile.Location = New System.Drawing.Point(0, 0)
        Me.btnMyProfile.Name = "btnMyProfile"
        Me.btnMyProfile.Size = New System.Drawing.Size(200, 50)
        Me.btnMyProfile.TabIndex = 0
        Me.btnMyProfile.Text = "👤 My Profile"
        Me.btnMyProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMyProfile.UseVisualStyleBackColor = False
        '
        'SystemSettingsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SystemSettingsFrm"
        Me.Text = "System Settings"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.pnlMyProfile.ResumeLayout(False)
        Me.grpChangePassword.ResumeLayout(False)
        Me.grpChangePassword.PerformLayout()
        Me.grpUserInfo.ResumeLayout(False)
        Me.grpUserInfo.PerformLayout()
        Me.pnlAppearance.ResumeLayout(False)
        Me.grpColorScheme.ResumeLayout(False)
        Me.grpColorScheme.PerformLayout()
        Me.grpFontSettings.ResumeLayout(False)
        Me.grpFontSettings.PerformLayout()
        Me.grpTheme.ResumeLayout(False)
        Me.grpTheme.PerformLayout()
        Me.pnlPreferences.ResumeLayout(False)
        Me.grpNotifications.ResumeLayout(False)
        Me.grpNotifications.PerformLayout()
        Me.grpDisplay.ResumeLayout(False)
        Me.grpDisplay.PerformLayout()
        CType(Me.numItemsPerPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAutoRefresh.ResumeLayout(False)
        Me.grpAutoRefresh.PerformLayout()
        CType(Me.numRefreshInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSystemInfo.ResumeLayout(False)
        Me.grpStatistics.ResumeLayout(False)
        Me.grpStatistics.PerformLayout()
        Me.grpDatabase.ResumeLayout(False)
        Me.grpDatabase.PerformLayout()
        Me.grpAppInfo.ResumeLayout(False)
        Me.grpAppInfo.PerformLayout()
        Me.pnlSecurity.ResumeLayout(False)
        Me.grpBackup.ResumeLayout(False)
        Me.grpBackup.PerformLayout()
        Me.grpSessionSettings.ResumeLayout(False)
        Me.grpSessionSettings.PerformLayout()
        CType(Me.numSessionTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPasswordPolicy.ResumeLayout(False)
        Me.pnlNavigation.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlContent As Panel
    Friend WithEvents pnlNavigation As Panel
    Friend WithEvents btnMyProfile As Button
    Friend WithEvents btnAppearance As Button
    Friend WithEvents btnPreferences As Button
    Friend WithEvents btnSystemInfo As Button
    Friend WithEvents btnSecurity As Button
    Friend WithEvents pnlMyProfile As Panel
    Friend WithEvents grpUserInfo As GroupBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents lblFullName As Label
    Friend WithEvents txtRole As TextBox
    Friend WithEvents lblRole As Label
    Friend WithEvents txtDepartment As TextBox
    Friend WithEvents lblDepartment As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents btnUpdateProfile As Button
    Friend WithEvents grpChangePassword As GroupBox
    Friend WithEvents txtCurrentPassword As TextBox
    Friend WithEvents lblCurrentPassword As Label
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents lblConfirmPassword As Label
    Friend WithEvents btnSavePassword As Button
    Friend WithEvents pnlAppearance As Panel
    Friend WithEvents grpTheme As GroupBox
    Friend WithEvents rbLightTheme As RadioButton
    Friend WithEvents rbDarkTheme As RadioButton
    Friend WithEvents btnApplyTheme As Button
    Friend WithEvents grpFontSettings As GroupBox
    Friend WithEvents lblFontSize As Label
    Friend WithEvents cboFontSize As ComboBox
    Friend WithEvents btnApplyFont As Button
    Friend WithEvents grpColorScheme As GroupBox
    Friend WithEvents lblAccentColor As Label
    Friend WithEvents btnAccentColor As Button
    Friend WithEvents lblAccentPreview As Label
    Friend WithEvents pnlAccentPreview As Panel
    Friend WithEvents btnApplyColors As Button
    Friend WithEvents pnlPreferences As Panel
    Friend WithEvents grpAutoRefresh As GroupBox
    Friend WithEvents chkAutoRefresh As CheckBox
    Friend WithEvents lblRefreshInterval As Label
    Friend WithEvents numRefreshInterval As NumericUpDown
    Friend WithEvents grpDisplay As GroupBox
    Friend WithEvents lblDateFormat As Label
    Friend WithEvents cboDateFormat As ComboBox
    Friend WithEvents lblItemsPerPage As Label
    Friend WithEvents numItemsPerPage As NumericUpDown
    Friend WithEvents btnApplyPreferences As Button
    Friend WithEvents grpNotifications As GroupBox
    Friend WithEvents chkShowNotifications As CheckBox
    Friend WithEvents chkSoundAlerts As CheckBox
    Friend WithEvents pnlSystemInfo As Panel
    Friend WithEvents grpAppInfo As GroupBox
    Friend WithEvents lblAppName As Label
    Friend WithEvents lblAppNameValue As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblVersionValue As Label
    Friend WithEvents lblBuildDate As Label
    Friend WithEvents lblBuildDateValue As Label
    Friend WithEvents grpDatabase As GroupBox
    Friend WithEvents lblDbName As Label
    Friend WithEvents lblDbNameValue As Label
    Friend WithEvents lblDbStatus As Label
    Friend WithEvents lblDbStatusValue As Label
    Friend WithEvents grpStatistics As GroupBox
    Friend WithEvents lblTotalUsers As Label
    Friend WithEvents lblTotalUsersValue As Label
    Friend WithEvents lblTotalEmployeesValue As Label
    Friend WithEvents lblTotalAssets As Label
    Friend WithEvents lblTotalAssetsValue As Label
    Friend WithEvents lblTotalConsumables As Label
    Friend WithEvents lblTotalConsumablesValue As Label
    Friend WithEvents lblTotalEmployees As Label
    Friend WithEvents pnlSecurity As Panel
    Friend WithEvents grpBackup As GroupBox
    Friend WithEvents lblLastBackup As Label
    Friend WithEvents lblLastBackupValue As Label
    Friend WithEvents btnBackupNow As Button

    Friend WithEvents grpSessionSettings As GroupBox
    Friend WithEvents lblSessionTimeout As Label
    Friend WithEvents numSessionTimeout As NumericUpDown
    Friend WithEvents btnApplySecurity As Button

    Friend WithEvents grpPasswordPolicy As GroupBox
    Friend WithEvents lblPolicyInfo As Label

    Friend WithEvents colorDialog As ColorDialog
End Class