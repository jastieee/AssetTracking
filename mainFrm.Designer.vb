<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainFrm
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
        Me.pnlTopBar = New System.Windows.Forms.Panel()
        Me.pnlUserInfo = New System.Windows.Forms.Panel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblSystemTitle = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnActivityLogs = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnDepartmentManagement = New System.Windows.Forms.Button()
        Me.btnUserManagement = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnRequestHistory = New System.Windows.Forms.Button()
        Me.btnApproveRequests = New System.Windows.Forms.Button()
        Me.btnDisposalRequests = New System.Windows.Forms.Button()
        Me.btnConsumableRequests = New System.Windows.Forms.Button()
        Me.btnAssetRequests = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEmployeeIssuedItems = New System.Windows.Forms.Button()
        Me.btnManageEmployees = New System.Windows.Forms.Button()
        Me.LabelEmployees = New System.Windows.Forms.Label()
        Me.btnConsumableIssuanceHistory = New System.Windows.Forms.Button()
        Me.btnIssueConsumable = New System.Windows.Forms.Button()
        Me.btnConsumableCategories = New System.Windows.Forms.Button()
        Me.btnManageConsumables = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMaintenance = New System.Windows.Forms.Button()
        Me.btnAssetIssuanceHistory = New System.Windows.Forms.Button()
        Me.btnIssueAsset = New System.Windows.Forms.Button()
        Me.btnAssetCategories = New System.Windows.Forms.Button()
        Me.btnManageAssets = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDashboard = New System.Windows.Forms.Button()
        Me.pnlMainContent = New System.Windows.Forms.Panel()
        Me.pnlWelcome = New System.Windows.Forms.Panel()
        Me.dgvRecentActivity = New System.Windows.Forms.DataGridView()
        Me.pnlRecentActivity = New System.Windows.Forms.Panel()
        Me.lblRecentActivityTitle = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.flowLayoutDashboard = New System.Windows.Forms.FlowLayoutPanel()
        Me.cardTotalAssets = New System.Windows.Forms.Panel()
        Me.lblCardLabel1 = New System.Windows.Forms.Label()
        Me.lblCardValue1 = New System.Windows.Forms.Label()
        Me.lblCardIcon1 = New System.Windows.Forms.Label()
        Me.cardTotalConsumables = New System.Windows.Forms.Panel()
        Me.lblCardLabel2 = New System.Windows.Forms.Label()
        Me.lblCardValue2 = New System.Windows.Forms.Label()
        Me.lblCardIcon2 = New System.Windows.Forms.Label()
        Me.cardAssetsIssued = New System.Windows.Forms.Panel()
        Me.lblCardLabel3 = New System.Windows.Forms.Label()
        Me.lblCardValue3 = New System.Windows.Forms.Label()
        Me.lblCardIcon3 = New System.Windows.Forms.Label()
        Me.cardPendingRequests = New System.Windows.Forms.Panel()
        Me.lblCardLabel4 = New System.Windows.Forms.Label()
        Me.lblCardValue4 = New System.Windows.Forms.Label()
        Me.lblCardIcon4 = New System.Windows.Forms.Label()
        Me.cardLowStock = New System.Windows.Forms.Panel()
        Me.lblCardLabel5 = New System.Windows.Forms.Label()
        Me.lblCardValue5 = New System.Windows.Forms.Label()
        Me.lblCardIcon5 = New System.Windows.Forms.Label()
        Me.cardEmployeesWithAssets = New System.Windows.Forms.Panel()
        Me.lblCardLabel6 = New System.Windows.Forms.Label()
        Me.lblCardValue6 = New System.Windows.Forms.Label()
        Me.lblCardIcon6 = New System.Windows.Forms.Label()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.pnlTopBar.SuspendLayout()
        Me.pnlUserInfo.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSidebar.SuspendLayout()
        Me.pnlMainContent.SuspendLayout()
        Me.pnlWelcome.SuspendLayout()
        CType(Me.dgvRecentActivity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRecentActivity.SuspendLayout()
        Me.flowLayoutDashboard.SuspendLayout()
        Me.cardTotalAssets.SuspendLayout()
        Me.cardTotalConsumables.SuspendLayout()
        Me.cardAssetsIssued.SuspendLayout()
        Me.cardPendingRequests.SuspendLayout()
        Me.cardLowStock.SuspendLayout()
        Me.cardEmployeesWithAssets.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTopBar
        '
        Me.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.pnlTopBar.Controls.Add(Me.pnlUserInfo)
        Me.pnlTopBar.Controls.Add(Me.lblSystemTitle)
        Me.pnlTopBar.Controls.Add(Me.picLogo)
        Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopBar.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlTopBar.Name = "pnlTopBar"
        Me.pnlTopBar.Size = New System.Drawing.Size(1707, 86)
        Me.pnlTopBar.TabIndex = 0
        '
        'pnlUserInfo
        '
        Me.pnlUserInfo.Controls.Add(Me.btnLogout)
        Me.pnlUserInfo.Controls.Add(Me.lblDepartment)
        Me.pnlUserInfo.Controls.Add(Me.lblUserName)
        Me.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlUserInfo.Location = New System.Drawing.Point(1174, 0)
        Me.pnlUserInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlUserInfo.Name = "pnlUserInfo"
        Me.pnlUserInfo.Size = New System.Drawing.Size(533, 86)
        Me.pnlUserInfo.TabIndex = 2
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(373, 21)
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(133, 43)
        Me.btnLogout.TabIndex = 2
        Me.btnLogout.Text = "🚪 Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.lblDepartment.Location = New System.Drawing.Point(13, 47)
        Me.lblDepartment.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(130, 20)
        Me.lblDepartment.TabIndex = 1
        Me.lblDepartment.Text = "🏢 IT Department"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblUserName.ForeColor = System.Drawing.Color.White
        Me.lblUserName.Location = New System.Drawing.Point(13, 18)
        Me.lblUserName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(145, 23)
        Me.lblUserName.TabIndex = 0
        Me.lblUserName.Text = "👤 Admin Name"
        '
        'lblSystemTitle
        '
        Me.lblSystemTitle.AutoSize = True
        Me.lblSystemTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblSystemTitle.ForeColor = System.Drawing.Color.White
        Me.lblSystemTitle.Location = New System.Drawing.Point(93, 25)
        Me.lblSystemTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystemTitle.Name = "lblSystemTitle"
        Me.lblSystemTitle.Size = New System.Drawing.Size(349, 37)
        Me.lblSystemTitle.TabIndex = 1
        Me.lblSystemTitle.Text = "ASSET TRACKING SYSTEM"
        '
        'picLogo
        '
        Me.picLogo.Location = New System.Drawing.Point(13, 12)
        Me.picLogo.Margin = New System.Windows.Forms.Padding(4)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(67, 62)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLogo.TabIndex = 0
        Me.picLogo.TabStop = False
        '
        'pnlSidebar
        '
        Me.pnlSidebar.AutoScroll = True
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.btnAbout)
        Me.pnlSidebar.Controls.Add(Me.btnActivityLogs)
        Me.pnlSidebar.Controls.Add(Me.Label5)
        Me.pnlSidebar.Controls.Add(Me.btnSettings)
        Me.pnlSidebar.Controls.Add(Me.btnReports)
        Me.pnlSidebar.Controls.Add(Me.btnDepartmentManagement)
        Me.pnlSidebar.Controls.Add(Me.btnUserManagement)
        Me.pnlSidebar.Controls.Add(Me.Label4)
        Me.pnlSidebar.Controls.Add(Me.btnRequestHistory)
        Me.pnlSidebar.Controls.Add(Me.btnApproveRequests)
        Me.pnlSidebar.Controls.Add(Me.btnDisposalRequests)
        Me.pnlSidebar.Controls.Add(Me.btnConsumableRequests)
        Me.pnlSidebar.Controls.Add(Me.btnAssetRequests)
        Me.pnlSidebar.Controls.Add(Me.Label3)
        Me.pnlSidebar.Controls.Add(Me.btnEmployeeIssuedItems)
        Me.pnlSidebar.Controls.Add(Me.btnManageEmployees)
        Me.pnlSidebar.Controls.Add(Me.LabelEmployees)
        Me.pnlSidebar.Controls.Add(Me.btnConsumableIssuanceHistory)
        Me.pnlSidebar.Controls.Add(Me.btnIssueConsumable)
        Me.pnlSidebar.Controls.Add(Me.btnConsumableCategories)
        Me.pnlSidebar.Controls.Add(Me.btnManageConsumables)
        Me.pnlSidebar.Controls.Add(Me.Label2)
        Me.pnlSidebar.Controls.Add(Me.btnMaintenance)
        Me.pnlSidebar.Controls.Add(Me.btnAssetIssuanceHistory)
        Me.pnlSidebar.Controls.Add(Me.btnIssueAsset)
        Me.pnlSidebar.Controls.Add(Me.btnAssetCategories)
        Me.pnlSidebar.Controls.Add(Me.btnManageAssets)
        Me.pnlSidebar.Controls.Add(Me.Label1)
        Me.pnlSidebar.Controls.Add(Me.btnDashboard)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 86)
        Me.pnlSidebar.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(333, 800)
        Me.pnlSidebar.TabIndex = 1
        '
        'btnAbout
        '
        Me.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbout.FlatAppearance.BorderSize = 0
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnAbout.ForeColor = System.Drawing.Color.White
        Me.btnAbout.Location = New System.Drawing.Point(0, 1457)
        Me.btnAbout.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnAbout.Size = New System.Drawing.Size(333, 49)
        Me.btnAbout.TabIndex = 28
        Me.btnAbout.Text = "ℹ️ About"
        Me.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'btnActivityLogs
        '
        Me.btnActivityLogs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnActivityLogs.FlatAppearance.BorderSize = 0
        Me.btnActivityLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActivityLogs.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnActivityLogs.ForeColor = System.Drawing.Color.White
        Me.btnActivityLogs.Location = New System.Drawing.Point(0, 1408)
        Me.btnActivityLogs.Margin = New System.Windows.Forms.Padding(4)
        Me.btnActivityLogs.Name = "btnActivityLogs"
        Me.btnActivityLogs.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnActivityLogs.Size = New System.Drawing.Size(333, 49)
        Me.btnActivityLogs.TabIndex = 27
        Me.btnActivityLogs.Text = "📖 Activity Logs"
        Me.btnActivityLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActivityLogs.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(20, 1377)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Label5.Size = New System.Drawing.Size(175, 31)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "━━━━━━━━━━━━━━━━━━━"
        '
        'btnSettings
        '
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Location = New System.Drawing.Point(0, 1303)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnSettings.Size = New System.Drawing.Size(333, 49)
        Me.btnSettings.TabIndex = 25
        Me.btnSettings.Text = "⚙️ System Settings"
        Me.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'btnReports
        '
        Me.btnReports.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReports.FlatAppearance.BorderSize = 0
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnReports.ForeColor = System.Drawing.Color.White
        Me.btnReports.Location = New System.Drawing.Point(0, 1254)
        Me.btnReports.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnReports.Size = New System.Drawing.Size(333, 49)
        Me.btnReports.TabIndex = 24
        Me.btnReports.Text = "📊 Reports and Analytics"
        Me.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReports.UseVisualStyleBackColor = True
        '
        'btnDepartmentManagement
        '
        Me.btnDepartmentManagement.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDepartmentManagement.FlatAppearance.BorderSize = 0
        Me.btnDepartmentManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDepartmentManagement.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnDepartmentManagement.ForeColor = System.Drawing.Color.White
        Me.btnDepartmentManagement.Location = New System.Drawing.Point(0, 1205)
        Me.btnDepartmentManagement.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDepartmentManagement.Name = "btnDepartmentManagement"
        Me.btnDepartmentManagement.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnDepartmentManagement.Size = New System.Drawing.Size(333, 49)
        Me.btnDepartmentManagement.TabIndex = 23
        Me.btnDepartmentManagement.Text = "🏢 Departments"
        Me.btnDepartmentManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDepartmentManagement.UseVisualStyleBackColor = True
        '
        'btnUserManagement
        '
        Me.btnUserManagement.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUserManagement.FlatAppearance.BorderSize = 0
        Me.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUserManagement.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnUserManagement.ForeColor = System.Drawing.Color.White
        Me.btnUserManagement.Location = New System.Drawing.Point(0, 1156)
        Me.btnUserManagement.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUserManagement.Name = "btnUserManagement"
        Me.btnUserManagement.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnUserManagement.Size = New System.Drawing.Size(333, 49)
        Me.btnUserManagement.TabIndex = 22
        Me.btnUserManagement.Text = "👥 User Management"
        Me.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUserManagement.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(20, 1119)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Label4.Size = New System.Drawing.Size(143, 31)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "ADMINISTRATION"
        '
        'btnRequestHistory
        '
        Me.btnRequestHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRequestHistory.FlatAppearance.BorderSize = 0
        Me.btnRequestHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequestHistory.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnRequestHistory.ForeColor = System.Drawing.Color.White
        Me.btnRequestHistory.Location = New System.Drawing.Point(0, 1051)
        Me.btnRequestHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRequestHistory.Name = "btnRequestHistory"
        Me.btnRequestHistory.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnRequestHistory.Size = New System.Drawing.Size(333, 49)
        Me.btnRequestHistory.TabIndex = 20
        Me.btnRequestHistory.Text = "📋 Request History"
        Me.btnRequestHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRequestHistory.UseVisualStyleBackColor = True
        '
        'btnApproveRequests
        '
        Me.btnApproveRequests.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApproveRequests.FlatAppearance.BorderSize = 0
        Me.btnApproveRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApproveRequests.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnApproveRequests.ForeColor = System.Drawing.Color.White
        Me.btnApproveRequests.Location = New System.Drawing.Point(0, 1002)
        Me.btnApproveRequests.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApproveRequests.Name = "btnApproveRequests"
        Me.btnApproveRequests.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnApproveRequests.Size = New System.Drawing.Size(333, 49)
        Me.btnApproveRequests.TabIndex = 19
        Me.btnApproveRequests.Text = "✅ Approve Requests"
        Me.btnApproveRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnApproveRequests.UseVisualStyleBackColor = True
        '
        'btnDisposalRequests
        '
        Me.btnDisposalRequests.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDisposalRequests.FlatAppearance.BorderSize = 0
        Me.btnDisposalRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisposalRequests.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnDisposalRequests.ForeColor = System.Drawing.Color.White
        Me.btnDisposalRequests.Location = New System.Drawing.Point(0, 953)
        Me.btnDisposalRequests.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDisposalRequests.Name = "btnDisposalRequests"
        Me.btnDisposalRequests.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnDisposalRequests.Size = New System.Drawing.Size(333, 49)
        Me.btnDisposalRequests.TabIndex = 18
        Me.btnDisposalRequests.Text = "🗑️ Disposal Requests"
        Me.btnDisposalRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDisposalRequests.UseVisualStyleBackColor = True
        '
        'btnConsumableRequests
        '
        Me.btnConsumableRequests.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsumableRequests.FlatAppearance.BorderSize = 0
        Me.btnConsumableRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsumableRequests.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnConsumableRequests.ForeColor = System.Drawing.Color.White
        Me.btnConsumableRequests.Location = New System.Drawing.Point(0, 904)
        Me.btnConsumableRequests.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsumableRequests.Name = "btnConsumableRequests"
        Me.btnConsumableRequests.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnConsumableRequests.Size = New System.Drawing.Size(333, 49)
        Me.btnConsumableRequests.TabIndex = 17
        Me.btnConsumableRequests.Text = "📝 Consumable Requests"
        Me.btnConsumableRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsumableRequests.UseVisualStyleBackColor = True
        '
        'btnAssetRequests
        '
        Me.btnAssetRequests.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAssetRequests.FlatAppearance.BorderSize = 0
        Me.btnAssetRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssetRequests.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnAssetRequests.ForeColor = System.Drawing.Color.White
        Me.btnAssetRequests.Location = New System.Drawing.Point(0, 855)
        Me.btnAssetRequests.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAssetRequests.Name = "btnAssetRequests"
        Me.btnAssetRequests.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnAssetRequests.Size = New System.Drawing.Size(333, 49)
        Me.btnAssetRequests.TabIndex = 16
        Me.btnAssetRequests.Text = "📝 Asset Requests"
        Me.btnAssetRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAssetRequests.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(20, 818)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Label3.Size = New System.Drawing.Size(91, 31)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "REQUESTS"
        '
        'btnEmployeeIssuedItems
        '
        Me.btnEmployeeIssuedItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEmployeeIssuedItems.FlatAppearance.BorderSize = 0
        Me.btnEmployeeIssuedItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmployeeIssuedItems.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnEmployeeIssuedItems.ForeColor = System.Drawing.Color.White
        Me.btnEmployeeIssuedItems.Location = New System.Drawing.Point(0, 750)
        Me.btnEmployeeIssuedItems.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEmployeeIssuedItems.Name = "btnEmployeeIssuedItems"
        Me.btnEmployeeIssuedItems.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnEmployeeIssuedItems.Size = New System.Drawing.Size(333, 49)
        Me.btnEmployeeIssuedItems.TabIndex = 14
        Me.btnEmployeeIssuedItems.Text = "📋 Employee Issued Items"
        Me.btnEmployeeIssuedItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmployeeIssuedItems.UseVisualStyleBackColor = True
        '
        'btnManageEmployees
        '
        Me.btnManageEmployees.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnManageEmployees.FlatAppearance.BorderSize = 0
        Me.btnManageEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManageEmployees.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnManageEmployees.ForeColor = System.Drawing.Color.White
        Me.btnManageEmployees.Location = New System.Drawing.Point(0, 701)
        Me.btnManageEmployees.Margin = New System.Windows.Forms.Padding(4)
        Me.btnManageEmployees.Name = "btnManageEmployees"
        Me.btnManageEmployees.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnManageEmployees.Size = New System.Drawing.Size(333, 49)
        Me.btnManageEmployees.TabIndex = 13
        Me.btnManageEmployees.Text = "👥 Manage Employees"
        Me.btnManageEmployees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnManageEmployees.UseVisualStyleBackColor = True
        '
        'LabelEmployees
        '
        Me.LabelEmployees.AutoSize = True
        Me.LabelEmployees.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.LabelEmployees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.LabelEmployees.Location = New System.Drawing.Point(20, 664)
        Me.LabelEmployees.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelEmployees.Name = "LabelEmployees"
        Me.LabelEmployees.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.LabelEmployees.Size = New System.Drawing.Size(197, 31)
        Me.LabelEmployees.TabIndex = 12
        Me.LabelEmployees.Text = "EMPLOYEE MANAGEMENT"
        '
        'btnConsumableIssuanceHistory
        '
        Me.btnConsumableIssuanceHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsumableIssuanceHistory.FlatAppearance.BorderSize = 0
        Me.btnConsumableIssuanceHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsumableIssuanceHistory.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnConsumableIssuanceHistory.ForeColor = System.Drawing.Color.White
        Me.btnConsumableIssuanceHistory.Location = New System.Drawing.Point(0, 596)
        Me.btnConsumableIssuanceHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsumableIssuanceHistory.Name = "btnConsumableIssuanceHistory"
        Me.btnConsumableIssuanceHistory.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnConsumableIssuanceHistory.Size = New System.Drawing.Size(333, 49)
        Me.btnConsumableIssuanceHistory.TabIndex = 11
        Me.btnConsumableIssuanceHistory.Text = "📜 Consumable Issuance History"
        Me.btnConsumableIssuanceHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsumableIssuanceHistory.UseVisualStyleBackColor = True
        '
        'btnIssueConsumable
        '
        Me.btnIssueConsumable.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIssueConsumable.FlatAppearance.BorderSize = 0
        Me.btnIssueConsumable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIssueConsumable.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnIssueConsumable.ForeColor = System.Drawing.Color.White
        Me.btnIssueConsumable.Location = New System.Drawing.Point(0, 547)
        Me.btnIssueConsumable.Margin = New System.Windows.Forms.Padding(4)
        Me.btnIssueConsumable.Name = "btnIssueConsumable"
        Me.btnIssueConsumable.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnIssueConsumable.Size = New System.Drawing.Size(333, 49)
        Me.btnIssueConsumable.TabIndex = 10
        Me.btnIssueConsumable.Text = "➡️ Issue Consumable"
        Me.btnIssueConsumable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIssueConsumable.UseVisualStyleBackColor = True
        '
        'btnConsumableCategories
        '
        Me.btnConsumableCategories.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConsumableCategories.FlatAppearance.BorderSize = 0
        Me.btnConsumableCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsumableCategories.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnConsumableCategories.ForeColor = System.Drawing.Color.White
        Me.btnConsumableCategories.Location = New System.Drawing.Point(0, 498)
        Me.btnConsumableCategories.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsumableCategories.Name = "btnConsumableCategories"
        Me.btnConsumableCategories.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnConsumableCategories.Size = New System.Drawing.Size(333, 49)
        Me.btnConsumableCategories.TabIndex = 9
        Me.btnConsumableCategories.Text = "📋 Consumable Categories"
        Me.btnConsumableCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsumableCategories.UseVisualStyleBackColor = True
        '
        'btnManageConsumables
        '
        Me.btnManageConsumables.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnManageConsumables.FlatAppearance.BorderSize = 0
        Me.btnManageConsumables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManageConsumables.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnManageConsumables.ForeColor = System.Drawing.Color.White
        Me.btnManageConsumables.Location = New System.Drawing.Point(0, 449)
        Me.btnManageConsumables.Margin = New System.Windows.Forms.Padding(4)
        Me.btnManageConsumables.Name = "btnManageConsumables"
        Me.btnManageConsumables.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnManageConsumables.Size = New System.Drawing.Size(333, 49)
        Me.btnManageConsumables.TabIndex = 8
        Me.btnManageConsumables.Text = "📦 Manage Consumables"
        Me.btnManageConsumables.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnManageConsumables.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(20, 412)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Label2.Size = New System.Drawing.Size(222, 31)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "CONSUMABLE MANAGEMENT"
        '
        'btnMaintenance
        '
        Me.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMaintenance.FlatAppearance.BorderSize = 0
        Me.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaintenance.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnMaintenance.ForeColor = System.Drawing.Color.White
        Me.btnMaintenance.Location = New System.Drawing.Point(0, 345)
        Me.btnMaintenance.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMaintenance.Name = "btnMaintenance"
        Me.btnMaintenance.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnMaintenance.Size = New System.Drawing.Size(333, 49)
        Me.btnMaintenance.TabIndex = 6
        Me.btnMaintenance.Text = "🔧 Maintenance Records"
        Me.btnMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMaintenance.UseVisualStyleBackColor = True
        '
        'btnAssetIssuanceHistory
        '
        Me.btnAssetIssuanceHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAssetIssuanceHistory.FlatAppearance.BorderSize = 0
        Me.btnAssetIssuanceHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssetIssuanceHistory.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnAssetIssuanceHistory.ForeColor = System.Drawing.Color.White
        Me.btnAssetIssuanceHistory.Location = New System.Drawing.Point(0, 296)
        Me.btnAssetIssuanceHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAssetIssuanceHistory.Name = "btnAssetIssuanceHistory"
        Me.btnAssetIssuanceHistory.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnAssetIssuanceHistory.Size = New System.Drawing.Size(333, 49)
        Me.btnAssetIssuanceHistory.TabIndex = 5
        Me.btnAssetIssuanceHistory.Text = "📜 Asset Issuance History"
        Me.btnAssetIssuanceHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAssetIssuanceHistory.UseVisualStyleBackColor = True
        '
        'btnIssueAsset
        '
        Me.btnIssueAsset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIssueAsset.FlatAppearance.BorderSize = 0
        Me.btnIssueAsset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIssueAsset.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnIssueAsset.ForeColor = System.Drawing.Color.White
        Me.btnIssueAsset.Location = New System.Drawing.Point(0, 247)
        Me.btnIssueAsset.Margin = New System.Windows.Forms.Padding(4)
        Me.btnIssueAsset.Name = "btnIssueAsset"
        Me.btnIssueAsset.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnIssueAsset.Size = New System.Drawing.Size(333, 49)
        Me.btnIssueAsset.TabIndex = 4
        Me.btnIssueAsset.Text = "➡️ Issue Asset to Employee"
        Me.btnIssueAsset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIssueAsset.UseVisualStyleBackColor = True
        '
        'btnAssetCategories
        '
        Me.btnAssetCategories.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAssetCategories.FlatAppearance.BorderSize = 0
        Me.btnAssetCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssetCategories.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnAssetCategories.ForeColor = System.Drawing.Color.White
        Me.btnAssetCategories.Location = New System.Drawing.Point(0, 198)
        Me.btnAssetCategories.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAssetCategories.Name = "btnAssetCategories"
        Me.btnAssetCategories.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnAssetCategories.Size = New System.Drawing.Size(333, 49)
        Me.btnAssetCategories.TabIndex = 3
        Me.btnAssetCategories.Text = "📋 Asset Categories"
        Me.btnAssetCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAssetCategories.UseVisualStyleBackColor = True
        '
        'btnManageAssets
        '
        Me.btnManageAssets.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnManageAssets.FlatAppearance.BorderSize = 0
        Me.btnManageAssets.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManageAssets.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnManageAssets.ForeColor = System.Drawing.Color.White
        Me.btnManageAssets.Location = New System.Drawing.Point(0, 149)
        Me.btnManageAssets.Margin = New System.Windows.Forms.Padding(4)
        Me.btnManageAssets.Name = "btnManageAssets"
        Me.btnManageAssets.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnManageAssets.Size = New System.Drawing.Size(333, 49)
        Me.btnManageAssets.TabIndex = 2
        Me.btnManageAssets.Text = "📦 Manage Assets"
        Me.btnManageAssets.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnManageAssets.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(20, 112)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.Label1.Size = New System.Drawing.Size(168, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ASSET MANAGEMENT"
        '
        'btnDashboard
        '
        Me.btnDashboard.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDashboard.FlatAppearance.BorderSize = 0
        Me.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDashboard.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnDashboard.ForeColor = System.Drawing.Color.White
        Me.btnDashboard.Location = New System.Drawing.Point(0, 14)
        Me.btnDashboard.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDashboard.Name = "btnDashboard"
        Me.btnDashboard.Padding = New System.Windows.Forms.Padding(27, 0, 0, 0)
        Me.btnDashboard.Size = New System.Drawing.Size(333, 80)
        Me.btnDashboard.TabIndex = 0
        Me.btnDashboard.Text = "📊 DASHBOARD"
        Me.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDashboard.UseVisualStyleBackColor = False
        '
        'pnlMainContent
        '
        Me.pnlMainContent.AutoScroll = True
        Me.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlMainContent.Controls.Add(Me.pnlWelcome)
        Me.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainContent.Location = New System.Drawing.Point(333, 86)
        Me.pnlMainContent.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlMainContent.Name = "pnlMainContent"
        Me.pnlMainContent.Padding = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.pnlMainContent.Size = New System.Drawing.Size(1374, 800)
        Me.pnlMainContent.TabIndex = 2
        '
        'pnlWelcome
        '
        Me.pnlWelcome.BackColor = System.Drawing.Color.White
        Me.pnlWelcome.Controls.Add(Me.dgvRecentActivity)
        Me.pnlWelcome.Controls.Add(Me.pnlRecentActivity)
        Me.pnlWelcome.Controls.Add(Me.lblDateTime)
        Me.pnlWelcome.Controls.Add(Me.flowLayoutDashboard)
        Me.pnlWelcome.Controls.Add(Me.lblWelcome)
        Me.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlWelcome.Location = New System.Drawing.Point(27, 25)
        Me.pnlWelcome.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlWelcome.Name = "pnlWelcome"
        Me.pnlWelcome.Padding = New System.Windows.Forms.Padding(40, 37, 40, 37)
        Me.pnlWelcome.Size = New System.Drawing.Size(1320, 750)
        Me.pnlWelcome.TabIndex = 0
        '
        'dgvRecentActivity
        '
        Me.dgvRecentActivity.AllowUserToAddRows = False
        Me.dgvRecentActivity.AllowUserToDeleteRows = False
        Me.dgvRecentActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRecentActivity.BackgroundColor = System.Drawing.Color.White
        Me.dgvRecentActivity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRecentActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecentActivity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRecentActivity.Location = New System.Drawing.Point(40, 587)
        Me.dgvRecentActivity.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvRecentActivity.Name = "dgvRecentActivity"
        Me.dgvRecentActivity.ReadOnly = True
        Me.dgvRecentActivity.RowHeadersVisible = False
        Me.dgvRecentActivity.RowHeadersWidth = 51
        Me.dgvRecentActivity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvRecentActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecentActivity.Size = New System.Drawing.Size(1240, 126)
        Me.dgvRecentActivity.TabIndex = 4
        '
        'pnlRecentActivity
        '
        Me.pnlRecentActivity.Controls.Add(Me.lblRecentActivityTitle)
        Me.pnlRecentActivity.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRecentActivity.Location = New System.Drawing.Point(40, 525)
        Me.pnlRecentActivity.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlRecentActivity.Name = "pnlRecentActivity"
        Me.pnlRecentActivity.Size = New System.Drawing.Size(1240, 62)
        Me.pnlRecentActivity.TabIndex = 3
        '
        'lblRecentActivityTitle
        '
        Me.lblRecentActivityTitle.AutoSize = True
        Me.lblRecentActivityTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecentActivityTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblRecentActivityTitle.Location = New System.Drawing.Point(0, 12)
        Me.lblRecentActivityTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRecentActivityTitle.Name = "lblRecentActivityTitle"
        Me.lblRecentActivityTitle.Size = New System.Drawing.Size(230, 41)
        Me.lblRecentActivityTitle.TabIndex = 0
        Me.lblRecentActivityTitle.Text = "Recent Activity"
        '
        'lblDateTime
        '
        Me.lblDateTime.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblDateTime.Location = New System.Drawing.Point(40, 500)
        Me.lblDateTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(1240, 25)
        Me.lblDateTime.TabIndex = 2
        Me.lblDateTime.Text = "DATE TIME"
        Me.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'flowLayoutDashboard
        '
        Me.flowLayoutDashboard.Controls.Add(Me.cardTotalAssets)
        Me.flowLayoutDashboard.Controls.Add(Me.cardTotalConsumables)
        Me.flowLayoutDashboard.Controls.Add(Me.cardAssetsIssued)
        Me.flowLayoutDashboard.Controls.Add(Me.cardPendingRequests)
        Me.flowLayoutDashboard.Controls.Add(Me.cardLowStock)
        Me.flowLayoutDashboard.Controls.Add(Me.cardEmployeesWithAssets)
        Me.flowLayoutDashboard.Dock = System.Windows.Forms.DockStyle.Top
        Me.flowLayoutDashboard.Location = New System.Drawing.Point(40, 95)
        Me.flowLayoutDashboard.Margin = New System.Windows.Forms.Padding(4)
        Me.flowLayoutDashboard.Name = "flowLayoutDashboard"
        Me.flowLayoutDashboard.Size = New System.Drawing.Size(1240, 405)
        Me.flowLayoutDashboard.TabIndex = 1
        '
        'cardTotalAssets
        '
        Me.cardTotalAssets.BackColor = System.Drawing.Color.White
        Me.cardTotalAssets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardTotalAssets.Controls.Add(Me.lblCardLabel1)
        Me.cardTotalAssets.Controls.Add(Me.lblCardValue1)
        Me.cardTotalAssets.Controls.Add(Me.lblCardIcon1)
        Me.cardTotalAssets.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardTotalAssets.Location = New System.Drawing.Point(10, 10)
        Me.cardTotalAssets.Margin = New System.Windows.Forms.Padding(10)
        Me.cardTotalAssets.Name = "cardTotalAssets"
        Me.cardTotalAssets.Padding = New System.Windows.Forms.Padding(20)
        Me.cardTotalAssets.Size = New System.Drawing.Size(280, 180)
        Me.cardTotalAssets.TabIndex = 0
        '
        'lblCardLabel1
        '
        Me.lblCardLabel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCardLabel1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblCardLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblCardLabel1.Location = New System.Drawing.Point(20, 132)
        Me.lblCardLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardLabel1.Name = "lblCardLabel1"
        Me.lblCardLabel1.Size = New System.Drawing.Size(238, 26)
        Me.lblCardLabel1.TabIndex = 2
        Me.lblCardLabel1.Text = "Total Assets in Stock"
        Me.lblCardLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardValue1
        '
        Me.lblCardValue1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCardValue1.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardValue1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblCardValue1.Location = New System.Drawing.Point(20, 60)
        Me.lblCardValue1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardValue1.Name = "lblCardValue1"
        Me.lblCardValue1.Size = New System.Drawing.Size(238, 98)
        Me.lblCardValue1.TabIndex = 1
        Me.lblCardValue1.Text = "0"
        Me.lblCardValue1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardIcon1
        '
        'Me.lblCardIcon1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardIcon1.Font = New System.Drawing.Font("Segoe UI", 32.0!)
        Me.lblCardIcon1.Location = New System.Drawing.Point(20, 20)
        Me.lblCardIcon1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardIcon1.Name = "lblCardIcon1"
        Me.lblCardIcon1.Size = New System.Drawing.Size(238, 40)
        Me.lblCardIcon1.TabIndex = 0
        Me.lblCardIcon1.Text = "📦"
        Me.lblCardIcon1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cardTotalConsumables
        '
        Me.cardTotalConsumables.BackColor = System.Drawing.Color.White
        Me.cardTotalConsumables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardTotalConsumables.Controls.Add(Me.lblCardLabel2)
        Me.cardTotalConsumables.Controls.Add(Me.lblCardValue2)
        Me.cardTotalConsumables.Controls.Add(Me.lblCardIcon2)
        Me.cardTotalConsumables.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardTotalConsumables.Location = New System.Drawing.Point(310, 10)
        Me.cardTotalConsumables.Margin = New System.Windows.Forms.Padding(10)
        Me.cardTotalConsumables.Name = "cardTotalConsumables"
        Me.cardTotalConsumables.Padding = New System.Windows.Forms.Padding(20)
        Me.cardTotalConsumables.Size = New System.Drawing.Size(280, 180)
        Me.cardTotalConsumables.TabIndex = 1
        '
        'lblCardLabel2
        '
        Me.lblCardLabel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCardLabel2.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblCardLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblCardLabel2.Location = New System.Drawing.Point(20, 132)
        Me.lblCardLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardLabel2.Name = "lblCardLabel2"
        Me.lblCardLabel2.Size = New System.Drawing.Size(238, 26)
        Me.lblCardLabel2.TabIndex = 2
        Me.lblCardLabel2.Text = "Total Consumables"
        Me.lblCardLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardValue2
        '
        Me.lblCardValue2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCardValue2.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardValue2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblCardValue2.Location = New System.Drawing.Point(20, 60)
        Me.lblCardValue2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardValue2.Name = "lblCardValue2"
        Me.lblCardValue2.Size = New System.Drawing.Size(238, 98)
        Me.lblCardValue2.TabIndex = 1
        Me.lblCardValue2.Text = "0"
        Me.lblCardValue2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardIcon2
        '
        'Me.lblCardIcon2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardIcon2.Font = New System.Drawing.Font("Segoe UI", 32.0!)
        Me.lblCardIcon2.Location = New System.Drawing.Point(20, 20)
        Me.lblCardIcon2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardIcon2.Name = "lblCardIcon2"
        Me.lblCardIcon2.Size = New System.Drawing.Size(238, 40)
        Me.lblCardIcon2.TabIndex = 0
        Me.lblCardIcon2.Text = "🧃"
        Me.lblCardIcon2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cardAssetsIssued
        '
        Me.cardAssetsIssued.BackColor = System.Drawing.Color.White
        Me.cardAssetsIssued.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardAssetsIssued.Controls.Add(Me.lblCardLabel3)
        Me.cardAssetsIssued.Controls.Add(Me.lblCardValue3)
        Me.cardAssetsIssued.Controls.Add(Me.lblCardIcon3)
        Me.cardAssetsIssued.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardAssetsIssued.Location = New System.Drawing.Point(610, 10)
        Me.cardAssetsIssued.Margin = New System.Windows.Forms.Padding(10)
        Me.cardAssetsIssued.Name = "cardAssetsIssued"
        Me.cardAssetsIssued.Padding = New System.Windows.Forms.Padding(20)
        Me.cardAssetsIssued.Size = New System.Drawing.Size(280, 180)
        Me.cardAssetsIssued.TabIndex = 2
        '
        'lblCardLabel3
        '
        Me.lblCardLabel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCardLabel3.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblCardLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblCardLabel3.Location = New System.Drawing.Point(20, 132)
        Me.lblCardLabel3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardLabel3.Name = "lblCardLabel3"
        Me.lblCardLabel3.Size = New System.Drawing.Size(238, 26)
        Me.lblCardLabel3.TabIndex = 2
        Me.lblCardLabel3.Text = "Assets Currently Issued"
        Me.lblCardLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardValue3
        '
        Me.lblCardValue3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCardValue3.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardValue3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lblCardValue3.Location = New System.Drawing.Point(20, 60)
        Me.lblCardValue3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardValue3.Name = "lblCardValue3"
        Me.lblCardValue3.Size = New System.Drawing.Size(238, 98)
        Me.lblCardValue3.TabIndex = 1
        Me.lblCardValue3.Text = "0"
        Me.lblCardValue3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardIcon3
        '
        'Me.lblCardIcon3.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardIcon3.Font = New System.Drawing.Font("Segoe UI", 32.0!)
        Me.lblCardIcon3.Location = New System.Drawing.Point(20, 20)
        Me.lblCardIcon3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardIcon3.Name = "lblCardIcon3"
        Me.lblCardIcon3.Size = New System.Drawing.Size(238, 40)
        Me.lblCardIcon3.TabIndex = 0
        Me.lblCardIcon3.Text = "➡️"
        Me.lblCardIcon3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cardPendingRequests
        '
        Me.cardPendingRequests.BackColor = System.Drawing.Color.White
        Me.cardPendingRequests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardPendingRequests.Controls.Add(Me.lblCardLabel4)
        Me.cardPendingRequests.Controls.Add(Me.lblCardValue4)
        Me.cardPendingRequests.Controls.Add(Me.lblCardIcon4)
        Me.cardPendingRequests.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardPendingRequests.Location = New System.Drawing.Point(910, 10)
        Me.cardPendingRequests.Margin = New System.Windows.Forms.Padding(10)
        Me.cardPendingRequests.Name = "cardPendingRequests"
        Me.cardPendingRequests.Padding = New System.Windows.Forms.Padding(20)
        Me.cardPendingRequests.Size = New System.Drawing.Size(280, 180)
        Me.cardPendingRequests.TabIndex = 3
        '
        'lblCardLabel4
        '
        Me.lblCardLabel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCardLabel4.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblCardLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblCardLabel4.Location = New System.Drawing.Point(20, 132)
        Me.lblCardLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardLabel4.Name = "lblCardLabel4"
        Me.lblCardLabel4.Size = New System.Drawing.Size(238, 26)
        Me.lblCardLabel4.TabIndex = 2
        Me.lblCardLabel4.Text = "Pending Requests"
        Me.lblCardLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardValue4
        '
        Me.lblCardValue4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCardValue4.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardValue4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.lblCardValue4.Location = New System.Drawing.Point(20, 60)
        Me.lblCardValue4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardValue4.Name = "lblCardValue4"
        Me.lblCardValue4.Size = New System.Drawing.Size(238, 98)
        Me.lblCardValue4.TabIndex = 1
        Me.lblCardValue4.Text = "0"
        Me.lblCardValue4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardIcon4
        '
        'Me.lblCardIcon4.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardIcon4.Font = New System.Drawing.Font("Segoe UI", 32.0!)
        Me.lblCardIcon4.Location = New System.Drawing.Point(20, 20)
        Me.lblCardIcon4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardIcon4.Name = "lblCardIcon4"
        Me.lblCardIcon4.Size = New System.Drawing.Size(238, 40)
        Me.lblCardIcon4.TabIndex = 0
        Me.lblCardIcon4.Text = "⏳"
        Me.lblCardIcon4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cardLowStock
        '
        Me.cardLowStock.BackColor = System.Drawing.Color.White
        Me.cardLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardLowStock.Controls.Add(Me.lblCardLabel5)
        Me.cardLowStock.Controls.Add(Me.lblCardValue5)
        Me.cardLowStock.Controls.Add(Me.lblCardIcon5)
        Me.cardLowStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardLowStock.Location = New System.Drawing.Point(10, 210)
        Me.cardLowStock.Margin = New System.Windows.Forms.Padding(10)
        Me.cardLowStock.Name = "cardLowStock"
        Me.cardLowStock.Padding = New System.Windows.Forms.Padding(20)
        Me.cardLowStock.Size = New System.Drawing.Size(280, 180)
        Me.cardLowStock.TabIndex = 4
        '
        'lblCardLabel5
        '
        Me.lblCardLabel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCardLabel5.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblCardLabel5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblCardLabel5.Location = New System.Drawing.Point(20, 132)
        Me.lblCardLabel5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardLabel5.Name = "lblCardLabel5"
        Me.lblCardLabel5.Size = New System.Drawing.Size(238, 26)
        Me.lblCardLabel5.TabIndex = 2
        Me.lblCardLabel5.Text = "Low Stock Alerts"
        Me.lblCardLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardValue5
        '
        Me.lblCardValue5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCardValue5.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardValue5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblCardValue5.Location = New System.Drawing.Point(20, 60)
        Me.lblCardValue5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardValue5.Name = "lblCardValue5"
        Me.lblCardValue5.Size = New System.Drawing.Size(238, 98)
        Me.lblCardValue5.TabIndex = 1
        Me.lblCardValue5.Text = "0"
        Me.lblCardValue5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardIcon5
        '
        'Me.lblCardIcon5.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardIcon5.Font = New System.Drawing.Font("Segoe UI", 32.0!)
        Me.lblCardIcon5.Location = New System.Drawing.Point(20, 20)
        Me.lblCardIcon5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardIcon5.Name = "lblCardIcon5"
        Me.lblCardIcon5.Size = New System.Drawing.Size(238, 40)
        Me.lblCardIcon5.TabIndex = 0
        Me.lblCardIcon5.Text = "!"
        Me.lblCardIcon5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cardEmployeesWithAssets
        '
        Me.cardEmployeesWithAssets.BackColor = System.Drawing.Color.White
        Me.cardEmployeesWithAssets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cardEmployeesWithAssets.Controls.Add(Me.lblCardLabel6)
        Me.cardEmployeesWithAssets.Controls.Add(Me.lblCardValue6)
        Me.cardEmployeesWithAssets.Controls.Add(Me.lblCardIcon6)
        Me.cardEmployeesWithAssets.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cardEmployeesWithAssets.Location = New System.Drawing.Point(310, 210)
        Me.cardEmployeesWithAssets.Margin = New System.Windows.Forms.Padding(10)
        Me.cardEmployeesWithAssets.Name = "cardEmployeesWithAssets"
        Me.cardEmployeesWithAssets.Padding = New System.Windows.Forms.Padding(20)
        Me.cardEmployeesWithAssets.Size = New System.Drawing.Size(280, 180)
        Me.cardEmployeesWithAssets.TabIndex = 5
        '
        'lblCardLabel6
        '
        Me.lblCardLabel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCardLabel6.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblCardLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblCardLabel6.Location = New System.Drawing.Point(20, 132)
        Me.lblCardLabel6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardLabel6.Name = "lblCardLabel6"
        Me.lblCardLabel6.Size = New System.Drawing.Size(238, 26)
        Me.lblCardLabel6.TabIndex = 2
        Me.lblCardLabel6.Text = "Employees with Items"
        Me.lblCardLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardValue6
        '
        Me.lblCardValue6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCardValue6.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.lblCardValue6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.lblCardValue6.Location = New System.Drawing.Point(20, 60)
        Me.lblCardValue6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardValue6.Name = "lblCardValue6"
        Me.lblCardValue6.Size = New System.Drawing.Size(238, 98)
        Me.lblCardValue6.TabIndex = 1
        Me.lblCardValue6.Text = "0"
        Me.lblCardValue6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardIcon6
        '
        'Me.lblCardIcon6.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCardIcon6.Font = New System.Drawing.Font("Segoe UI", 32.0!)
        Me.lblCardIcon6.Location = New System.Drawing.Point(20, 20)
        Me.lblCardIcon6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCardIcon6.Name = "lblCardIcon6"
        Me.lblCardIcon6.Size = New System.Drawing.Size(238, 40)
        Me.lblCardIcon6.TabIndex = 0
        Me.lblCardIcon6.Text = "👥"
        Me.lblCardIcon6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblWelcome.Location = New System.Drawing.Point(40, 37)
        Me.lblWelcome.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Padding = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.lblWelcome.Size = New System.Drawing.Size(352, 58)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "Welcome back, User!"
        '
        'mainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1707, 886)
        Me.Controls.Add(Me.pnlMainContent)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Controls.Add(Me.pnlTopBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(1365, 738)
        Me.Name = "mainFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asset Tracking System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTopBar.ResumeLayout(False)
        Me.pnlTopBar.PerformLayout()
        Me.pnlUserInfo.ResumeLayout(False)
        Me.pnlUserInfo.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout()
        Me.pnlMainContent.ResumeLayout(False)
        Me.pnlWelcome.ResumeLayout(False)
        Me.pnlWelcome.PerformLayout()
        CType(Me.dgvRecentActivity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRecentActivity.ResumeLayout(False)
        Me.pnlRecentActivity.PerformLayout()
        Me.flowLayoutDashboard.ResumeLayout(False)
        Me.cardTotalAssets.ResumeLayout(False)
        Me.cardTotalConsumables.ResumeLayout(False)
        Me.cardAssetsIssued.ResumeLayout(False)
        Me.cardPendingRequests.ResumeLayout(False)
        Me.cardLowStock.ResumeLayout(False)
        Me.cardEmployeesWithAssets.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTopBar As Panel
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents lblSystemTitle As Label
    Friend WithEvents pnlUserInfo As Panel
    Friend WithEvents lblUserName As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnActivityLogs As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnDepartmentManagement As Button
    Friend WithEvents btnUserManagement As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnRequestHistory As Button
    Friend WithEvents btnApproveRequests As Button
    Friend WithEvents btnDisposalRequests As Button
    Friend WithEvents btnConsumableRequests As Button
    Friend WithEvents btnAssetRequests As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnEmployeeIssuedItems As Button
    Friend WithEvents btnManageEmployees As Button
    Friend WithEvents LabelEmployees As Label
    Friend WithEvents btnConsumableIssuanceHistory As Button
    Friend WithEvents btnIssueConsumable As Button
    Friend WithEvents btnConsumableCategories As Button
    Friend WithEvents btnManageConsumables As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnMaintenance As Button
    Friend WithEvents btnAssetIssuanceHistory As Button
    Friend WithEvents btnIssueAsset As Button
    Friend WithEvents btnAssetCategories As Button
    Friend WithEvents btnManageAssets As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDashboard As Button
    Friend WithEvents pnlMainContent As Panel
    Friend WithEvents pnlWelcome As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents flowLayoutDashboard As FlowLayoutPanel
    Friend WithEvents cardTotalAssets As Panel
    Friend WithEvents lblCardIcon1 As Label
    Friend WithEvents lblCardLabel1 As Label
    Friend WithEvents lblCardValue1 As Label
    Friend WithEvents cardTotalConsumables As Panel
    Friend WithEvents lblCardLabel2 As Label
    Friend WithEvents lblCardValue2 As Label
    Friend WithEvents lblCardIcon2 As Label
    Friend WithEvents cardAssetsIssued As Panel
    Friend WithEvents lblCardLabel3 As Label
    Friend WithEvents lblCardValue3 As Label
    Friend WithEvents lblCardIcon3 As Label
    Friend WithEvents cardPendingRequests As Panel
    Friend WithEvents lblCardLabel4 As Label
    Friend WithEvents lblCardValue4 As Label
    Friend WithEvents lblCardIcon4 As Label
    Friend WithEvents cardLowStock As Panel
    Friend WithEvents lblCardLabel5 As Label
    Friend WithEvents lblCardValue5 As Label
    Friend WithEvents lblCardIcon5 As Label
    Friend WithEvents cardEmployeesWithAssets As Panel
    Friend WithEvents lblCardLabel6 As Label
    Friend WithEvents lblCardValue6 As Label
    Friend WithEvents lblCardIcon6 As Label
    Friend WithEvents lblDateTime As Label
    Friend WithEvents pnlRecentActivity As Panel
    Friend WithEvents lblRecentActivityTitle As Label
    Friend WithEvents dgvRecentActivity As DataGridView

End Class