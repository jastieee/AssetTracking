<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserManagementFrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlUserManagement = New System.Windows.Forms.Panel()
        Me.splitContainer = New System.Windows.Forms.SplitContainer()
        Me.tabUserDetails = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnClearForm = New System.Windows.Forms.Button()
        Me.btnsaveUser = New System.Windows.Forms.Button()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.cboRole = New System.Windows.Forms.ComboBox()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblFisrtName = New System.Windows.Forms.Label()
        Me.btnShowPassword = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pnlAccessRights = New System.Windows.Forms.Panel()
        Me.pnlModuleActions = New System.Windows.Forms.Panel()
        Me.btnSaveAccessRights = New System.Windows.Forms.Button()
        Me.lblAccessSummary = New System.Windows.Forms.Label()
        Me.btnClearAllModules = New System.Windows.Forms.Button()
        Me.btnSelectAllModules = New System.Windows.Forms.Button()
        Me.pnlModuleGroups = New System.Windows.Forms.Panel()
        Me.grpSystemSettings = New System.Windows.Forms.GroupBox()
        Me.chkActivityLogs = New System.Windows.Forms.CheckBox()
        Me.chkSystemSettings = New System.Windows.Forms.CheckBox()
        Me.grpReports = New System.Windows.Forms.GroupBox()
        Me.chkReportsAnalytics = New System.Windows.Forms.CheckBox()
        Me.chkDepartments = New System.Windows.Forms.CheckBox()
        Me.grpUserManagement = New System.Windows.Forms.GroupBox()
        Me.chkUserManagement = New System.Windows.Forms.CheckBox()
        Me.grpRequests = New System.Windows.Forms.GroupBox()
        Me.chkRequestHistory = New System.Windows.Forms.CheckBox()
        Me.chkApproveRequests = New System.Windows.Forms.CheckBox()
        Me.chkDisposalRequests = New System.Windows.Forms.CheckBox()
        Me.chkConsumableRequests = New System.Windows.Forms.CheckBox()
        Me.chkAssetRequests = New System.Windows.Forms.CheckBox()
        Me.grpEmployees = New System.Windows.Forms.GroupBox()
        Me.chkEmployeeIssuedItems = New System.Windows.Forms.CheckBox()
        Me.chkManageEmployees = New System.Windows.Forms.CheckBox()
        Me.grpConsumables = New System.Windows.Forms.GroupBox()
        Me.chkConsumableIssuanceHistory = New System.Windows.Forms.CheckBox()
        Me.chkIssueConsumable = New System.Windows.Forms.CheckBox()
        Me.chkConsumableCategories = New System.Windows.Forms.CheckBox()
        Me.chkManageConsumables = New System.Windows.Forms.CheckBox()
        Me.grpAssets = New System.Windows.Forms.GroupBox()
        Me.chkMaintenanceRecords = New System.Windows.Forms.CheckBox()
        Me.chkAssetIssuanceHistory = New System.Windows.Forms.CheckBox()
        Me.chkIssueAsset = New System.Windows.Forms.CheckBox()
        Me.chkAssetCategories = New System.Windows.Forms.CheckBox()
        Me.chkManageAssets = New System.Windows.Forms.CheckBox()
        Me.pnlAccessHeader = New System.Windows.Forms.Panel()
        Me.txtSearchModule = New System.Windows.Forms.TextBox()
        Me.lblAccessRightsTitle = New System.Windows.Forms.Label()
        Me.pnlUserList = New System.Windows.Forms.Panel()
        Me.dgvUserList = New System.Windows.Forms.DataGridView()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearchUser = New System.Windows.Forms.TextBox()
        Me.lblUserListTitle = New System.Windows.Forms.Label()
        Me.pnlUserMgmtHeader = New System.Windows.Forms.Panel()
        Me.btnAddNewUser = New System.Windows.Forms.Button()
        Me.lblUserMgmtTitle = New System.Windows.Forms.Label()
        Me.pnlUserManagement.SuspendLayout()
        CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer.Panel1.SuspendLayout()
        Me.splitContainer.Panel2.SuspendLayout()
        Me.splitContainer.SuspendLayout()
        Me.tabUserDetails.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.pnlAccessRights.SuspendLayout()
        Me.pnlModuleActions.SuspendLayout()
        Me.pnlModuleGroups.SuspendLayout()
        Me.grpSystemSettings.SuspendLayout()
        Me.grpReports.SuspendLayout()
        Me.grpUserManagement.SuspendLayout()
        Me.grpRequests.SuspendLayout()
        Me.grpEmployees.SuspendLayout()
        Me.grpConsumables.SuspendLayout()
        Me.grpAssets.SuspendLayout()
        Me.pnlAccessHeader.SuspendLayout()
        Me.pnlUserList.SuspendLayout()
        CType(Me.dgvUserList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearch.SuspendLayout()
        Me.pnlUserMgmtHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlUserManagement
        '
        Me.pnlUserManagement.AutoScroll = True
        Me.pnlUserManagement.Controls.Add(Me.splitContainer)
        Me.pnlUserManagement.Controls.Add(Me.pnlUserMgmtHeader)
        Me.pnlUserManagement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlUserManagement.Location = New System.Drawing.Point(0, 0)
        Me.pnlUserManagement.Name = "pnlUserManagement"
        Me.pnlUserManagement.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlUserManagement.Size = New System.Drawing.Size(1200, 700)
        Me.pnlUserManagement.TabIndex = 0
        '
        'splitContainer
        '
        Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer.Location = New System.Drawing.Point(20, 90)
        Me.splitContainer.Name = "splitContainer"
        '
        'splitContainer.Panel1
        '
        Me.splitContainer.Panel1.AutoScroll = True
        Me.splitContainer.Panel1.BackColor = System.Drawing.Color.White
        Me.splitContainer.Panel1.Controls.Add(Me.tabUserDetails)
        Me.splitContainer.Panel1.Padding = New System.Windows.Forms.Padding(20)
        '
        'splitContainer.Panel2
        '
        Me.splitContainer.Panel2.Controls.Add(Me.pnlUserList)
        Me.splitContainer.Size = New System.Drawing.Size(1160, 590)
        Me.splitContainer.SplitterDistance = 350
        Me.splitContainer.SplitterWidth = 5
        Me.splitContainer.TabIndex = 1
        '
        'tabUserDetails
        '
        Me.tabUserDetails.Controls.Add(Me.TabPage1)
        Me.tabUserDetails.Controls.Add(Me.TabPage2)
        Me.tabUserDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabUserDetails.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabUserDetails.Location = New System.Drawing.Point(20, 20)
        Me.tabUserDetails.Name = "tabUserDetails"
        Me.tabUserDetails.SelectedIndex = 0
        Me.tabUserDetails.Size = New System.Drawing.Size(310, 550)
        Me.tabUserDetails.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.Controls.Add(Me.btnClearForm)
        Me.TabPage1.Controls.Add(Me.btnsaveUser)
        Me.TabPage1.Controls.Add(Me.chkActive)
        Me.TabPage1.Controls.Add(Me.cboRole)
        Me.TabPage1.Controls.Add(Me.lblRole)
        Me.TabPage1.Controls.Add(Me.cboDepartment)
        Me.TabPage1.Controls.Add(Me.lblDepartment)
        Me.TabPage1.Controls.Add(Me.txtPhone)
        Me.TabPage1.Controls.Add(Me.lblPhone)
        Me.TabPage1.Controls.Add(Me.txtEmail)
        Me.TabPage1.Controls.Add(Me.lblEmail)
        Me.TabPage1.Controls.Add(Me.txtLastName)
        Me.TabPage1.Controls.Add(Me.lblLastName)
        Me.TabPage1.Controls.Add(Me.txtMiddleName)
        Me.TabPage1.Controls.Add(Me.lblMiddleName)
        Me.TabPage1.Controls.Add(Me.txtFirstName)
        Me.TabPage1.Controls.Add(Me.lblFisrtName)
        Me.TabPage1.Controls.Add(Me.btnShowPassword)
        Me.TabPage1.Controls.Add(Me.txtPassword)
        Me.TabPage1.Controls.Add(Me.lblPassword)
        Me.TabPage1.Controls.Add(Me.txtUsername)
        Me.TabPage1.Controls.Add(Me.lblUsername)
        Me.TabPage1.Location = New System.Drawing.Point(4, 32)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(20)
        Me.TabPage1.Size = New System.Drawing.Size(302, 514)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "User Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnClearForm
        '
        Me.btnClearForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnClearForm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearForm.FlatAppearance.BorderSize = 0
        Me.btnClearForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearForm.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearForm.ForeColor = System.Drawing.Color.White
        Me.btnClearForm.Location = New System.Drawing.Point(180, 440)
        Me.btnClearForm.Name = "btnClearForm"
        Me.btnClearForm.Size = New System.Drawing.Size(150, 45)
        Me.btnClearForm.TabIndex = 21
        Me.btnClearForm.Text = "🗑️ Clear Form"
        Me.btnClearForm.UseVisualStyleBackColor = False
        '
        'btnsaveUser
        '
        Me.btnsaveUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnsaveUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnsaveUser.FlatAppearance.BorderSize = 0
        Me.btnsaveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsaveUser.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsaveUser.ForeColor = System.Drawing.Color.White
        Me.btnsaveUser.Location = New System.Drawing.Point(20, 440)
        Me.btnsaveUser.Name = "btnsaveUser"
        Me.btnsaveUser.Size = New System.Drawing.Size(150, 45)
        Me.btnsaveUser.TabIndex = 20
        Me.btnsaveUser.Text = "💾 Save User"
        Me.btnsaveUser.UseVisualStyleBackColor = False
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Location = New System.Drawing.Point(20, 400)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(117, 27)
        Me.chkActive.TabIndex = 19
        Me.chkActive.Text = "Active User"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'cboRole
        '
        Me.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRole.FormattingEnabled = True
        Me.cboRole.Location = New System.Drawing.Point(310, 355)
        Me.cboRole.Name = "cboRole"
        Me.cboRole.Size = New System.Drawing.Size(280, 31)
        Me.cboRole.TabIndex = 18
        '
        'lblRole
        '
        Me.lblRole.AutoSize = True
        Me.lblRole.Location = New System.Drawing.Point(310, 330)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(43, 23)
        Me.lblRole.TabIndex = 17
        Me.lblRole.Text = "Role"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(20, 355)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(280, 31)
        Me.cboDepartment.TabIndex = 16
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Location = New System.Drawing.Point(20, 330)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(102, 23)
        Me.lblDepartment.TabIndex = 15
        Me.lblDepartment.Text = "Department"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(310, 285)
        Me.txtPhone.MaxLength = 20
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(280, 30)
        Me.txtPhone.TabIndex = 14
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(310, 260)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(127, 23)
        Me.lblPhone.TabIndex = 13
        Me.lblPhone.Text = "Phone Number"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(20, 285)
        Me.txtEmail.MaxLength = 100
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(280, 30)
        Me.txtEmail.TabIndex = 12
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(20, 260)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(51, 23)
        Me.lblEmail.TabIndex = 11
        Me.lblEmail.Text = "Email"
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(410, 215)
        Me.txtLastName.MaxLength = 50
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(180, 30)
        Me.txtLastName.TabIndex = 10
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(410, 190)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(91, 23)
        Me.lblLastName.TabIndex = 9
        Me.lblLastName.Text = "Last Name"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Location = New System.Drawing.Point(215, 215)
        Me.txtMiddleName.MaxLength = 50
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(180, 30)
        Me.txtMiddleName.TabIndex = 8
        '
        'lblMiddleName
        '
        Me.lblMiddleName.AutoSize = True
        Me.lblMiddleName.Location = New System.Drawing.Point(215, 190)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(113, 23)
        Me.lblMiddleName.TabIndex = 7
        Me.lblMiddleName.Text = "Middle Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(20, 215)
        Me.txtFirstName.MaxLength = 50
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(180, 30)
        Me.txtFirstName.TabIndex = 6
        '
        'lblFisrtName
        '
        Me.lblFisrtName.AutoSize = True
        Me.lblFisrtName.Location = New System.Drawing.Point(20, 190)
        Me.lblFisrtName.Name = "lblFisrtName"
        Me.lblFisrtName.Size = New System.Drawing.Size(92, 23)
        Me.lblFisrtName.TabIndex = 5
        Me.lblFisrtName.Text = "First Name"
        '
        'btnShowPassword
        '
        Me.btnShowPassword.BackColor = System.Drawing.Color.White
        Me.btnShowPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowPassword.Location = New System.Drawing.Point(560, 145)
        Me.btnShowPassword.Name = "btnShowPassword"
        Me.btnShowPassword.Size = New System.Drawing.Size(30, 30)
        Me.btnShowPassword.TabIndex = 4
        Me.btnShowPassword.Text = "👁"
        Me.btnShowPassword.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(310, 145)
        Me.txtPassword.MaxLength = 100
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(240, 30)
        Me.txtPassword.TabIndex = 3
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(310, 120)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(80, 23)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(20, 145)
        Me.txtUsername.MaxLength = 50
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(280, 30)
        Me.txtUsername.TabIndex = 1
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblUsername.Location = New System.Drawing.Point(20, 20)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(201, 31)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Login Credentials"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.pnlAccessRights)
        Me.TabPage2.Location = New System.Drawing.Point(4, 32)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(302, 514)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Access Rights"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'pnlAccessRights
        '
        Me.pnlAccessRights.AutoScroll = True
        Me.pnlAccessRights.BackColor = System.Drawing.Color.White
        Me.pnlAccessRights.Controls.Add(Me.pnlModuleActions)
        Me.pnlAccessRights.Controls.Add(Me.pnlModuleGroups)
        Me.pnlAccessRights.Controls.Add(Me.pnlAccessHeader)
        Me.pnlAccessRights.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAccessRights.Location = New System.Drawing.Point(3, 3)
        Me.pnlAccessRights.Name = "pnlAccessRights"
        Me.pnlAccessRights.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlAccessRights.Size = New System.Drawing.Size(296, 508)
        Me.pnlAccessRights.TabIndex = 0
        '
        'pnlModuleActions
        '
        Me.pnlModuleActions.Controls.Add(Me.btnSaveAccessRights)
        Me.pnlModuleActions.Controls.Add(Me.lblAccessSummary)
        Me.pnlModuleActions.Controls.Add(Me.btnClearAllModules)
        Me.pnlModuleActions.Controls.Add(Me.btnSelectAllModules)
        Me.pnlModuleActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlModuleActions.Location = New System.Drawing.Point(20, 1060)
        Me.pnlModuleActions.Name = "pnlModuleActions"
        Me.pnlModuleActions.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.pnlModuleActions.Size = New System.Drawing.Size(235, 148)
        Me.pnlModuleActions.TabIndex = 2
        '
        'btnSaveAccessRights
        '
        Me.btnSaveAccessRights.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnSaveAccessRights.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveAccessRights.FlatAppearance.BorderSize = 0
        Me.btnSaveAccessRights.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAccessRights.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAccessRights.ForeColor = System.Drawing.Color.White
        Me.btnSaveAccessRights.Location = New System.Drawing.Point(3, 90)
        Me.btnSaveAccessRights.Name = "btnSaveAccessRights"
        Me.btnSaveAccessRights.Size = New System.Drawing.Size(580, 45)
        Me.btnSaveAccessRights.TabIndex = 3
        Me.btnSaveAccessRights.Text = "💾 Save Access Rights"
        Me.btnSaveAccessRights.UseVisualStyleBackColor = False
        '
        'lblAccessSummary
        '
        Me.lblAccessSummary.AutoSize = True
        Me.lblAccessSummary.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccessSummary.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblAccessSummary.Location = New System.Drawing.Point(3, 60)
        Me.lblAccessSummary.Name = "lblAccessSummary"
        Me.lblAccessSummary.Size = New System.Drawing.Size(166, 20)
        Me.lblAccessSummary.TabIndex = 2
        Me.lblAccessSummary.Text = "0 of 21 modules selected"
        '
        'btnClearAllModules
        '
        Me.btnClearAllModules.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnClearAllModules.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearAllModules.FlatAppearance.BorderSize = 0
        Me.btnClearAllModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearAllModules.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAllModules.ForeColor = System.Drawing.Color.White
        Me.btnClearAllModules.Location = New System.Drawing.Point(463, 13)
        Me.btnClearAllModules.Name = "btnClearAllModules"
        Me.btnClearAllModules.Size = New System.Drawing.Size(120, 35)
        Me.btnClearAllModules.TabIndex = 1
        Me.btnClearAllModules.Text = "❌ Clear All"
        Me.btnClearAllModules.UseVisualStyleBackColor = False
        '
        'btnSelectAllModules
        '
        Me.btnSelectAllModules.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnSelectAllModules.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSelectAllModules.FlatAppearance.BorderSize = 0
        Me.btnSelectAllModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectAllModules.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectAllModules.ForeColor = System.Drawing.Color.White
        Me.btnSelectAllModules.Location = New System.Drawing.Point(337, 13)
        Me.btnSelectAllModules.Name = "btnSelectAllModules"
        Me.btnSelectAllModules.Size = New System.Drawing.Size(120, 35)
        Me.btnSelectAllModules.TabIndex = 0
        Me.btnSelectAllModules.Text = "✅ Select All"
        Me.btnSelectAllModules.UseVisualStyleBackColor = False
        '
        'pnlModuleGroups
        '
        Me.pnlModuleGroups.AutoSize = True
        Me.pnlModuleGroups.Controls.Add(Me.grpSystemSettings)
        Me.pnlModuleGroups.Controls.Add(Me.grpReports)
        Me.pnlModuleGroups.Controls.Add(Me.grpUserManagement)
        Me.pnlModuleGroups.Controls.Add(Me.grpRequests)
        Me.pnlModuleGroups.Controls.Add(Me.grpEmployees)
        Me.pnlModuleGroups.Controls.Add(Me.grpConsumables)
        Me.pnlModuleGroups.Controls.Add(Me.grpAssets)
        Me.pnlModuleGroups.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlModuleGroups.Location = New System.Drawing.Point(20, 110)
        Me.pnlModuleGroups.Name = "pnlModuleGroups"
        Me.pnlModuleGroups.Size = New System.Drawing.Size(235, 970)
        Me.pnlModuleGroups.TabIndex = 1
        '
        'grpSystemSettings
        '
        Me.grpSystemSettings.Controls.Add(Me.chkActivityLogs)
        Me.grpSystemSettings.Controls.Add(Me.chkSystemSettings)
        Me.grpSystemSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpSystemSettings.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSystemSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.grpSystemSettings.Location = New System.Drawing.Point(0, 860)
        Me.grpSystemSettings.Name = "grpSystemSettings"
        Me.grpSystemSettings.Padding = New System.Windows.Forms.Padding(15, 10, 15, 15)
        Me.grpSystemSettings.Size = New System.Drawing.Size(235, 110)
        Me.grpSystemSettings.TabIndex = 6
        Me.grpSystemSettings.TabStop = False
        Me.grpSystemSettings.Text = "⚙️ System Settings"
        '
        'chkActivityLogs
        '
        Me.chkActivityLogs.AutoSize = True
        Me.chkActivityLogs.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivityLogs.Location = New System.Drawing.Point(25, 70)
        Me.chkActivityLogs.Name = "chkActivityLogs"
        Me.chkActivityLogs.Size = New System.Drawing.Size(127, 27)
        Me.chkActivityLogs.TabIndex = 1
        Me.chkActivityLogs.Tag = "21"
        Me.chkActivityLogs.Text = "Activity Logs"
        Me.chkActivityLogs.UseVisualStyleBackColor = True
        '
        'chkSystemSettings
        '
        Me.chkSystemSettings.AutoSize = True
        Me.chkSystemSettings.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSystemSettings.Location = New System.Drawing.Point(25, 35)
        Me.chkSystemSettings.Name = "chkSystemSettings"
        Me.chkSystemSettings.Size = New System.Drawing.Size(152, 27)
        Me.chkSystemSettings.TabIndex = 0
        Me.chkSystemSettings.Tag = "20"
        Me.chkSystemSettings.Text = "System Settings"
        Me.chkSystemSettings.UseVisualStyleBackColor = True
        '
        'grpReports
        '
        Me.grpReports.Controls.Add(Me.chkReportsAnalytics)
        Me.grpReports.Controls.Add(Me.chkDepartments)
        Me.grpReports.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpReports.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpReports.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.grpReports.Location = New System.Drawing.Point(0, 750)
        Me.grpReports.Name = "grpReports"
        Me.grpReports.Padding = New System.Windows.Forms.Padding(15, 10, 15, 15)
        Me.grpReports.Size = New System.Drawing.Size(235, 110)
        Me.grpReports.TabIndex = 5
        Me.grpReports.TabStop = False
        Me.grpReports.Text = "📊 Reports && Analytics"
        '
        'chkReportsAnalytics
        '
        Me.chkReportsAnalytics.AutoSize = True
        Me.chkReportsAnalytics.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReportsAnalytics.Location = New System.Drawing.Point(25, 35)
        Me.chkReportsAnalytics.Name = "chkReportsAnalytics"
        Me.chkReportsAnalytics.Size = New System.Drawing.Size(181, 27)
        Me.chkReportsAnalytics.TabIndex = 0
        Me.chkReportsAnalytics.Tag = "19"
        Me.chkReportsAnalytics.Text = "Reports && Analytics"
        Me.chkReportsAnalytics.UseVisualStyleBackColor = True
        '
        'chkDepartments
        '
        Me.chkDepartments.AutoSize = True
        Me.chkDepartments.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDepartments.Location = New System.Drawing.Point(25, 70)
        Me.chkDepartments.Name = "chkDepartments"
        Me.chkDepartments.Size = New System.Drawing.Size(131, 27)
        Me.chkDepartments.TabIndex = 1
        Me.chkDepartments.Tag = "18"
        Me.chkDepartments.Text = "Departments"
        Me.chkDepartments.UseVisualStyleBackColor = True
        '
        'grpUserManagement
        '
        Me.grpUserManagement.Controls.Add(Me.chkUserManagement)
        Me.grpUserManagement.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpUserManagement.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpUserManagement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.grpUserManagement.Location = New System.Drawing.Point(0, 670)
        Me.grpUserManagement.Name = "grpUserManagement"
        Me.grpUserManagement.Padding = New System.Windows.Forms.Padding(15, 10, 15, 15)
        Me.grpUserManagement.Size = New System.Drawing.Size(235, 80)
        Me.grpUserManagement.TabIndex = 4
        Me.grpUserManagement.TabStop = False
        Me.grpUserManagement.Text = "👥 User Management"
        '
        'chkUserManagement
        '
        Me.chkUserManagement.AutoSize = True
        Me.chkUserManagement.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUserManagement.Location = New System.Drawing.Point(25, 35)
        Me.chkUserManagement.Name = "chkUserManagement"
        Me.chkUserManagement.Size = New System.Drawing.Size(173, 27)
        Me.chkUserManagement.TabIndex = 0
        Me.chkUserManagement.Tag = "17"
        Me.chkUserManagement.Text = "User Management"
        Me.chkUserManagement.UseVisualStyleBackColor = True
        '
        'grpRequests
        '
        Me.grpRequests.Controls.Add(Me.chkRequestHistory)
        Me.grpRequests.Controls.Add(Me.chkApproveRequests)
        Me.grpRequests.Controls.Add(Me.chkDisposalRequests)
        Me.grpRequests.Controls.Add(Me.chkConsumableRequests)
        Me.grpRequests.Controls.Add(Me.chkAssetRequests)
        Me.grpRequests.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpRequests.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRequests.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.grpRequests.Location = New System.Drawing.Point(0, 460)
        Me.grpRequests.Name = "grpRequests"
        Me.grpRequests.Padding = New System.Windows.Forms.Padding(15, 10, 15, 15)
        Me.grpRequests.Size = New System.Drawing.Size(235, 210)
        Me.grpRequests.TabIndex = 3
        Me.grpRequests.TabStop = False
        Me.grpRequests.Text = "📝 Requests Management"
        '
        'chkRequestHistory
        '
        Me.chkRequestHistory.AutoSize = True
        Me.chkRequestHistory.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRequestHistory.Location = New System.Drawing.Point(25, 175)
        Me.chkRequestHistory.Name = "chkRequestHistory"
        Me.chkRequestHistory.Size = New System.Drawing.Size(151, 27)
        Me.chkRequestHistory.TabIndex = 4
        Me.chkRequestHistory.Tag = "16"
        Me.chkRequestHistory.Text = "Request History"
        Me.chkRequestHistory.UseVisualStyleBackColor = True
        '
        'chkApproveRequests
        '
        Me.chkApproveRequests.AutoSize = True
        Me.chkApproveRequests.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkApproveRequests.Location = New System.Drawing.Point(25, 140)
        Me.chkApproveRequests.Name = "chkApproveRequests"
        Me.chkApproveRequests.Size = New System.Drawing.Size(169, 27)
        Me.chkApproveRequests.TabIndex = 3
        Me.chkApproveRequests.Tag = "15"
        Me.chkApproveRequests.Text = "Approve Requests"
        Me.chkApproveRequests.UseVisualStyleBackColor = True
        '
        'chkDisposalRequests
        '
        Me.chkDisposalRequests.AutoSize = True
        Me.chkDisposalRequests.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDisposalRequests.Location = New System.Drawing.Point(25, 105)
        Me.chkDisposalRequests.Name = "chkDisposalRequests"
        Me.chkDisposalRequests.Size = New System.Drawing.Size(168, 27)
        Me.chkDisposalRequests.TabIndex = 2
        Me.chkDisposalRequests.Tag = "14"
        Me.chkDisposalRequests.Text = "Disposal Requests"
        Me.chkDisposalRequests.UseVisualStyleBackColor = True
        '
        'chkConsumableRequests
        '
        Me.chkConsumableRequests.AutoSize = True
        Me.chkConsumableRequests.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConsumableRequests.Location = New System.Drawing.Point(25, 70)
        Me.chkConsumableRequests.Name = "chkConsumableRequests"
        Me.chkConsumableRequests.Size = New System.Drawing.Size(200, 27)
        Me.chkConsumableRequests.TabIndex = 1
        Me.chkConsumableRequests.Tag = "13"
        Me.chkConsumableRequests.Text = "Consumable Requests"
        Me.chkConsumableRequests.UseVisualStyleBackColor = True
        '
        'chkAssetRequests
        '
        Me.chkAssetRequests.AutoSize = True
        Me.chkAssetRequests.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAssetRequests.Location = New System.Drawing.Point(25, 35)
        Me.chkAssetRequests.Name = "chkAssetRequests"
        Me.chkAssetRequests.Size = New System.Drawing.Size(145, 27)
        Me.chkAssetRequests.TabIndex = 0
        Me.chkAssetRequests.Tag = "12"
        Me.chkAssetRequests.Text = "Asset Requests"
        Me.chkAssetRequests.UseVisualStyleBackColor = True
        '
        'grpEmployees
        '
        Me.grpEmployees.Controls.Add(Me.chkEmployeeIssuedItems)
        Me.grpEmployees.Controls.Add(Me.chkManageEmployees)
        Me.grpEmployees.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpEmployees.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpEmployees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.grpEmployees.Location = New System.Drawing.Point(0, 350)
        Me.grpEmployees.Name = "grpEmployees"
        Me.grpEmployees.Padding = New System.Windows.Forms.Padding(15, 10, 15, 15)
        Me.grpEmployees.Size = New System.Drawing.Size(235, 110)
        Me.grpEmployees.TabIndex = 2
        Me.grpEmployees.TabStop = False
        Me.grpEmployees.Text = "👔 Employee Management"
        '
        'chkEmployeeIssuedItems
        '
        Me.chkEmployeeIssuedItems.AutoSize = True
        Me.chkEmployeeIssuedItems.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmployeeIssuedItems.Location = New System.Drawing.Point(25, 70)
        Me.chkEmployeeIssuedItems.Name = "chkEmployeeIssuedItems"
        Me.chkEmployeeIssuedItems.Size = New System.Drawing.Size(206, 27)
        Me.chkEmployeeIssuedItems.TabIndex = 1
        Me.chkEmployeeIssuedItems.Tag = "11"
        Me.chkEmployeeIssuedItems.Text = "Employee Issued Items"
        Me.chkEmployeeIssuedItems.UseVisualStyleBackColor = True
        '
        'chkManageEmployees
        '
        Me.chkManageEmployees.AutoSize = True
        Me.chkManageEmployees.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkManageEmployees.Location = New System.Drawing.Point(25, 35)
        Me.chkManageEmployees.Name = "chkManageEmployees"
        Me.chkManageEmployees.Size = New System.Drawing.Size(180, 27)
        Me.chkManageEmployees.TabIndex = 0
        Me.chkManageEmployees.Tag = "10"
        Me.chkManageEmployees.Text = "Manage Employees"
        Me.chkManageEmployees.UseVisualStyleBackColor = True
        '
        'grpConsumables
        '
        Me.grpConsumables.Controls.Add(Me.chkConsumableIssuanceHistory)
        Me.grpConsumables.Controls.Add(Me.chkIssueConsumable)
        Me.grpConsumables.Controls.Add(Me.chkConsumableCategories)
        Me.grpConsumables.Controls.Add(Me.chkManageConsumables)
        Me.grpConsumables.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpConsumables.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpConsumables.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.grpConsumables.Location = New System.Drawing.Point(0, 190)
        Me.grpConsumables.Name = "grpConsumables"
        Me.grpConsumables.Padding = New System.Windows.Forms.Padding(15, 10, 15, 15)
        Me.grpConsumables.Size = New System.Drawing.Size(235, 160)
        Me.grpConsumables.TabIndex = 1
        Me.grpConsumables.TabStop = False
        Me.grpConsumables.Text = "📦 Consumables Management"
        '
        'chkConsumableIssuanceHistory
        '
        Me.chkConsumableIssuanceHistory.AutoSize = True
        Me.chkConsumableIssuanceHistory.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConsumableIssuanceHistory.Location = New System.Drawing.Point(25, 120)
        Me.chkConsumableIssuanceHistory.Name = "chkConsumableIssuanceHistory"
        Me.chkConsumableIssuanceHistory.Size = New System.Drawing.Size(255, 27)
        Me.chkConsumableIssuanceHistory.TabIndex = 3
        Me.chkConsumableIssuanceHistory.Tag = "9"
        Me.chkConsumableIssuanceHistory.Text = "Consumable Issuance History"
        Me.chkConsumableIssuanceHistory.UseVisualStyleBackColor = True
        '
        'chkIssueConsumable
        '
        Me.chkIssueConsumable.AutoSize = True
        Me.chkIssueConsumable.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIssueConsumable.Location = New System.Drawing.Point(25, 85)
        Me.chkIssueConsumable.Name = "chkIssueConsumable"
        Me.chkIssueConsumable.Size = New System.Drawing.Size(170, 27)
        Me.chkIssueConsumable.TabIndex = 2
        Me.chkIssueConsumable.Tag = "8"
        Me.chkIssueConsumable.Text = "Issue Consumable"
        Me.chkIssueConsumable.UseVisualStyleBackColor = True
        '
        'chkConsumableCategories
        '
        Me.chkConsumableCategories.AutoSize = True
        Me.chkConsumableCategories.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConsumableCategories.Location = New System.Drawing.Point(25, 52)
        Me.chkConsumableCategories.Name = "chkConsumableCategories"
        Me.chkConsumableCategories.Size = New System.Drawing.Size(213, 27)
        Me.chkConsumableCategories.TabIndex = 1
        Me.chkConsumableCategories.Tag = "7"
        Me.chkConsumableCategories.Text = "Consumable Categories"
        Me.chkConsumableCategories.UseVisualStyleBackColor = True
        '
        'chkManageConsumables
        '
        Me.chkManageConsumables.AutoSize = True
        Me.chkManageConsumables.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkManageConsumables.Location = New System.Drawing.Point(25, 19)
        Me.chkManageConsumables.Name = "chkManageConsumables"
        Me.chkManageConsumables.Size = New System.Drawing.Size(201, 27)
        Me.chkManageConsumables.TabIndex = 0
        Me.chkManageConsumables.Tag = "6"
        Me.chkManageConsumables.Text = "Manage Consumables"
        Me.chkManageConsumables.UseVisualStyleBackColor = True
        '
        'grpAssets
        '
        Me.grpAssets.Controls.Add(Me.chkMaintenanceRecords)
        Me.grpAssets.Controls.Add(Me.chkAssetIssuanceHistory)
        Me.grpAssets.Controls.Add(Me.chkIssueAsset)
        Me.grpAssets.Controls.Add(Me.chkAssetCategories)
        Me.grpAssets.Controls.Add(Me.chkManageAssets)
        Me.grpAssets.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpAssets.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAssets.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.grpAssets.Location = New System.Drawing.Point(0, 0)
        Me.grpAssets.Name = "grpAssets"
        Me.grpAssets.Padding = New System.Windows.Forms.Padding(15, 10, 15, 15)
        Me.grpAssets.Size = New System.Drawing.Size(235, 190)
        Me.grpAssets.TabIndex = 0
        Me.grpAssets.TabStop = False
        Me.grpAssets.Text = "💼 Asset Management"
        '
        'chkMaintenanceRecords
        '
        Me.chkMaintenanceRecords.AutoSize = True
        Me.chkMaintenanceRecords.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMaintenanceRecords.Location = New System.Drawing.Point(25, 150)
        Me.chkMaintenanceRecords.Name = "chkMaintenanceRecords"
        Me.chkMaintenanceRecords.Size = New System.Drawing.Size(196, 27)
        Me.chkMaintenanceRecords.TabIndex = 4
        Me.chkMaintenanceRecords.Tag = "5"
        Me.chkMaintenanceRecords.Text = "Maintenance Records"
        Me.chkMaintenanceRecords.UseVisualStyleBackColor = True
        '
        'chkAssetIssuanceHistory
        '
        Me.chkAssetIssuanceHistory.AutoSize = True
        Me.chkAssetIssuanceHistory.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAssetIssuanceHistory.Location = New System.Drawing.Point(25, 117)
        Me.chkAssetIssuanceHistory.Name = "chkAssetIssuanceHistory"
        Me.chkAssetIssuanceHistory.Size = New System.Drawing.Size(200, 27)
        Me.chkAssetIssuanceHistory.TabIndex = 3
        Me.chkAssetIssuanceHistory.Tag = "4"
        Me.chkAssetIssuanceHistory.Text = "Asset Issuance History"
        Me.chkAssetIssuanceHistory.UseVisualStyleBackColor = True
        '
        'chkIssueAsset
        '
        Me.chkIssueAsset.AutoSize = True
        Me.chkIssueAsset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIssueAsset.Location = New System.Drawing.Point(25, 84)
        Me.chkIssueAsset.Name = "chkIssueAsset"
        Me.chkIssueAsset.Size = New System.Drawing.Size(215, 27)
        Me.chkIssueAsset.TabIndex = 2
        Me.chkIssueAsset.Tag = "3"
        Me.chkIssueAsset.Text = "Issue Asset to Employee"
        Me.chkIssueAsset.UseVisualStyleBackColor = True
        '
        'chkAssetCategories
        '
        Me.chkAssetCategories.AutoSize = True
        Me.chkAssetCategories.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAssetCategories.Location = New System.Drawing.Point(25, 51)
        Me.chkAssetCategories.Name = "chkAssetCategories"
        Me.chkAssetCategories.Size = New System.Drawing.Size(158, 27)
        Me.chkAssetCategories.TabIndex = 1
        Me.chkAssetCategories.Tag = "2"
        Me.chkAssetCategories.Text = "Asset Categories"
        Me.chkAssetCategories.UseVisualStyleBackColor = True
        '
        'chkManageAssets
        '
        Me.chkManageAssets.AutoSize = True
        Me.chkManageAssets.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkManageAssets.Location = New System.Drawing.Point(25, 18)
        Me.chkManageAssets.Name = "chkManageAssets"
        Me.chkManageAssets.Size = New System.Drawing.Size(146, 27)
        Me.chkManageAssets.TabIndex = 0
        Me.chkManageAssets.Tag = "1"
        Me.chkManageAssets.Text = "Manage Assets"
        Me.chkManageAssets.UseVisualStyleBackColor = True
        '
        'pnlAccessHeader
        '
        Me.pnlAccessHeader.Controls.Add(Me.txtSearchModule)
        Me.pnlAccessHeader.Controls.Add(Me.lblAccessRightsTitle)
        Me.pnlAccessHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAccessHeader.Location = New System.Drawing.Point(20, 20)
        Me.pnlAccessHeader.Name = "pnlAccessHeader"
        Me.pnlAccessHeader.Size = New System.Drawing.Size(235, 90)
        Me.pnlAccessHeader.TabIndex = 0
        '
        'txtSearchModule
        '
        Me.txtSearchModule.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchModule.Location = New System.Drawing.Point(3, 50)
        Me.txtSearchModule.Name = "txtSearchModule"
        Me.txtSearchModule.Size = New System.Drawing.Size(580, 30)
        Me.txtSearchModule.TabIndex = 1
        Me.txtSearchModule.Text = "🔍 Search modules..."
        '
        'lblAccessRightsTitle
        '
        Me.lblAccessRightsTitle.AutoSize = True
        Me.lblAccessRightsTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAccessRightsTitle.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccessRightsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblAccessRightsTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblAccessRightsTitle.Name = "lblAccessRightsTitle"
        Me.lblAccessRightsTitle.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblAccessRightsTitle.Size = New System.Drawing.Size(306, 41)
        Me.lblAccessRightsTitle.TabIndex = 0
        Me.lblAccessRightsTitle.Text = "Module Access Permissions"
        '
        'pnlUserList
        '
        Me.pnlUserList.AutoScroll = True
        Me.pnlUserList.BackColor = System.Drawing.Color.White
        Me.pnlUserList.Controls.Add(Me.dgvUserList)
        Me.pnlUserList.Controls.Add(Me.pnlSearch)
        Me.pnlUserList.Controls.Add(Me.lblUserListTitle)
        Me.pnlUserList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlUserList.ForeColor = System.Drawing.Color.Black
        Me.pnlUserList.Location = New System.Drawing.Point(0, 0)
        Me.pnlUserList.Name = "pnlUserList"
        Me.pnlUserList.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlUserList.Size = New System.Drawing.Size(805, 590)
        Me.pnlUserList.TabIndex = 0
        '
        'dgvUserList
        '
        Me.dgvUserList.AllowUserToAddRows = False
        Me.dgvUserList.AllowUserToDeleteRows = False
        Me.dgvUserList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUserList.BackgroundColor = System.Drawing.Color.White
        Me.dgvUserList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUserList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUserList.Location = New System.Drawing.Point(20, 121)
        Me.dgvUserList.MultiSelect = False
        Me.dgvUserList.Name = "dgvUserList"
        Me.dgvUserList.ReadOnly = True
        Me.dgvUserList.RowHeadersWidth = 51
        Me.dgvUserList.RowTemplate.Height = 35
        Me.dgvUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUserList.Size = New System.Drawing.Size(765, 449)
        Me.dgvUserList.TabIndex = 2
        '
        'pnlSearch
        '
        Me.pnlSearch.Controls.Add(Me.btnSearch)
        Me.pnlSearch.Controls.Add(Me.txtSearchUser)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearch.Location = New System.Drawing.Point(20, 51)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.pnlSearch.Size = New System.Drawing.Size(765, 70)
        Me.pnlSearch.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(310, 15)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 40)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "🔍 Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearchUser
        '
        Me.txtSearchUser.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchUser.Location = New System.Drawing.Point(3, 18)
        Me.txtSearchUser.Name = "txtSearchUser"
        Me.txtSearchUser.Size = New System.Drawing.Size(300, 30)
        Me.txtSearchUser.TabIndex = 0
        '
        'lblUserListTitle
        '
        Me.lblUserListTitle.AutoSize = True
        Me.lblUserListTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblUserListTitle.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserListTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblUserListTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblUserListTitle.Name = "lblUserListTitle"
        Me.lblUserListTitle.Size = New System.Drawing.Size(164, 31)
        Me.lblUserListTitle.TabIndex = 0
        Me.lblUserListTitle.Text = "Existing Users"
        Me.lblUserListTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlUserMgmtHeader
        '
        Me.pnlUserMgmtHeader.BackColor = System.Drawing.Color.White
        Me.pnlUserMgmtHeader.Controls.Add(Me.btnAddNewUser)
        Me.pnlUserMgmtHeader.Controls.Add(Me.lblUserMgmtTitle)
        Me.pnlUserMgmtHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlUserMgmtHeader.Location = New System.Drawing.Point(20, 20)
        Me.pnlUserMgmtHeader.Name = "pnlUserMgmtHeader"
        Me.pnlUserMgmtHeader.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlUserMgmtHeader.Size = New System.Drawing.Size(1160, 70)
        Me.pnlUserMgmtHeader.TabIndex = 0
        '
        'btnAddNewUser
        '
        Me.btnAddNewUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnAddNewUser.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddNewUser.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAddNewUser.FlatAppearance.BorderSize = 0
        Me.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddNewUser.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNewUser.ForeColor = System.Drawing.Color.White
        Me.btnAddNewUser.Location = New System.Drawing.Point(970, 20)
        Me.btnAddNewUser.Name = "btnAddNewUser"
        Me.btnAddNewUser.Size = New System.Drawing.Size(170, 30)
        Me.btnAddNewUser.TabIndex = 1
        Me.btnAddNewUser.Text = "+ Add New User"
        Me.btnAddNewUser.UseVisualStyleBackColor = False
        '
        'lblUserMgmtTitle
        '
        Me.lblUserMgmtTitle.AutoSize = True
        Me.lblUserMgmtTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblUserMgmtTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserMgmtTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblUserMgmtTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblUserMgmtTitle.Name = "lblUserMgmtTitle"
        Me.lblUserMgmtTitle.Size = New System.Drawing.Size(320, 41)
        Me.lblUserMgmtTitle.TabIndex = 0
        Me.lblUserMgmtTitle.Text = "USER MANAGEMENT"
        '
        'UserManagementFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlUserManagement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "UserManagementFrm"
        Me.Text = "UserManagementFrm"
        Me.pnlUserManagement.ResumeLayout(False)
        Me.splitContainer.Panel1.ResumeLayout(False)
        Me.splitContainer.Panel2.ResumeLayout(False)
        CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer.ResumeLayout(False)
        Me.tabUserDetails.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.pnlAccessRights.ResumeLayout(False)
        Me.pnlAccessRights.PerformLayout()
        Me.pnlModuleActions.ResumeLayout(False)
        Me.pnlModuleActions.PerformLayout()
        Me.pnlModuleGroups.ResumeLayout(False)
        Me.grpSystemSettings.ResumeLayout(False)
        Me.grpSystemSettings.PerformLayout()
        Me.grpReports.ResumeLayout(False)
        Me.grpReports.PerformLayout()
        Me.grpUserManagement.ResumeLayout(False)
        Me.grpUserManagement.PerformLayout()
        Me.grpRequests.ResumeLayout(False)
        Me.grpRequests.PerformLayout()
        Me.grpEmployees.ResumeLayout(False)
        Me.grpEmployees.PerformLayout()
        Me.grpConsumables.ResumeLayout(False)
        Me.grpConsumables.PerformLayout()
        Me.grpAssets.ResumeLayout(False)
        Me.grpAssets.PerformLayout()
        Me.pnlAccessHeader.ResumeLayout(False)
        Me.pnlAccessHeader.PerformLayout()
        Me.pnlUserList.ResumeLayout(False)
        Me.pnlUserList.PerformLayout()
        CType(Me.dgvUserList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.pnlUserMgmtHeader.ResumeLayout(False)
        Me.pnlUserMgmtHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlUserManagement As Panel
    Friend WithEvents splitContainer As SplitContainer
    Friend WithEvents pnlUserMgmtHeader As Panel
    Friend WithEvents btnAddNewUser As Button
    Friend WithEvents lblUserMgmtTitle As Label
    Friend WithEvents tabUserDetails As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblFisrtName As Label
    Friend WithEvents btnShowPassword As Button
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents lblLastName As Label
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents lblMiddleName As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblRole As Label
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents cboRole As ComboBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents btnClearForm As Button
    Friend WithEvents btnsaveUser As Button
    Friend WithEvents pnlAccessRights As Panel
    Friend WithEvents pnlUserList As Panel
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearchUser As TextBox
    Friend WithEvents lblUserListTitle As Label
    Friend WithEvents dgvUserList As DataGridView
    Friend WithEvents pnlAccessHeader As Panel
    Friend WithEvents txtSearchModule As TextBox
    Friend WithEvents lblAccessRightsTitle As Label
    Friend WithEvents pnlModuleGroups As Panel
    Friend WithEvents grpAssets As GroupBox
    Friend WithEvents chkManageAssets As CheckBox
    Friend WithEvents chkAssetCategories As CheckBox
    Friend WithEvents chkIssueAsset As CheckBox
    Friend WithEvents chkAssetIssuanceHistory As CheckBox
    Friend WithEvents chkMaintenanceRecords As CheckBox
    Friend WithEvents grpConsumables As GroupBox
    Friend WithEvents chkManageConsumables As CheckBox
    Friend WithEvents chkConsumableCategories As CheckBox
    Friend WithEvents chkIssueConsumable As CheckBox
    Friend WithEvents chkConsumableIssuanceHistory As CheckBox
    Friend WithEvents grpEmployees As GroupBox
    Friend WithEvents chkManageEmployees As CheckBox
    Friend WithEvents chkEmployeeIssuedItems As CheckBox
    Friend WithEvents grpRequests As GroupBox
    Friend WithEvents chkAssetRequests As CheckBox
    Friend WithEvents chkConsumableRequests As CheckBox
    Friend WithEvents chkDisposalRequests As CheckBox
    Friend WithEvents chkApproveRequests As CheckBox
    Friend WithEvents chkRequestHistory As CheckBox
    Friend WithEvents grpUserManagement As GroupBox
    Friend WithEvents chkUserManagement As CheckBox
    Friend WithEvents grpReports As GroupBox
    Friend WithEvents chkReportsAnalytics As CheckBox
    Friend WithEvents chkDepartments As CheckBox
    Friend WithEvents grpSystemSettings As GroupBox
    Friend WithEvents chkSystemSettings As CheckBox
    Friend WithEvents chkActivityLogs As CheckBox
    Friend WithEvents pnlModuleActions As Panel
    Friend WithEvents btnSelectAllModules As Button
    Friend WithEvents btnClearAllModules As Button
    Friend WithEvents lblAccessSummary As Label
    Friend WithEvents btnSaveAccessRights As Button
End Class