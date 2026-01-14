<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsumableIssuedEmployeeFrm
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
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.splitContainer = New System.Windows.Forms.SplitContainer()
        Me.pnlEmployeeList = New System.Windows.Forms.Panel()
        Me.dgvEmployees = New System.Windows.Forms.DataGridView()
        Me.pnlEmployeeSearch = New System.Windows.Forms.Panel()
        Me.txtSearchEmployee = New System.Windows.Forms.TextBox()
        Me.lblSearchEmployee = New System.Windows.Forms.Label()
        Me.cboDepartmentFilter = New System.Windows.Forms.ComboBox()
        Me.lblDepartmentFilter = New System.Windows.Forms.Label()
        Me.lblEmployeeListTitle = New System.Windows.Forms.Label()
        Me.pnlEmployeeDetails = New System.Windows.Forms.Panel()
        Me.dgvIssuedConsumables = New System.Windows.Forms.DataGridView()
        Me.pnlItemsHeader = New System.Windows.Forms.Panel()
        Me.lblTotalItemsValue = New System.Windows.Forms.Label()
        Me.lblTotalItemsLabel = New System.Windows.Forms.Label()
        Me.lblItemsTitle = New System.Windows.Forms.Label()
        Me.pnlEmployeeInfo = New System.Windows.Forms.Panel()
        Me.lblEmployeeEmail = New System.Windows.Forms.Label()
        Me.lblEmployeePhone = New System.Windows.Forms.Label()
        Me.lblEmployeePosition = New System.Windows.Forms.Label()
        Me.lblEmployeeDepartment = New System.Windows.Forms.Label()
        Me.lblEmployeeNumber = New System.Windows.Forms.Label()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.picQRCode = New System.Windows.Forms.PictureBox()
        Me.lblEmployeeInfoTitle = New System.Windows.Forms.Label()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnIssueConsumable = New System.Windows.Forms.Button()
        Me.btnViewHistory = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer.Panel1.SuspendLayout()
        Me.splitContainer.Panel2.SuspendLayout()
        Me.splitContainer.SuspendLayout()
        Me.pnlEmployeeList.SuspendLayout()
        CType(Me.dgvEmployees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEmployeeSearch.SuspendLayout()
        Me.pnlEmployeeDetails.SuspendLayout()
        CType(Me.dgvIssuedConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlItemsHeader.SuspendLayout()
        Me.pnlEmployeeInfo.SuspendLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlActions.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlContent)
        Me.pnlMain.Controls.Add(Me.pnlActions)
        Me.pnlMain.Controls.Add(Me.pnlHeader)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.pnlMain.Size = New System.Drawing.Size(1400, 800)
        Me.pnlMain.TabIndex = 0
        '
        'pnlContent
        '
        Me.pnlContent.Controls.Add(Me.splitContainer)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(27, 130)
        Me.pnlContent.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(1346, 575)
        Me.pnlContent.TabIndex = 3
        '
        'splitContainer
        '
        Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer.Margin = New System.Windows.Forms.Padding(4)
        Me.splitContainer.Name = "splitContainer"
        '
        'splitContainer.Panel1
        '
        Me.splitContainer.Panel1.Controls.Add(Me.pnlEmployeeList)
        '
        'splitContainer.Panel2
        '
        Me.splitContainer.Panel2.Controls.Add(Me.pnlEmployeeDetails)
        Me.splitContainer.Size = New System.Drawing.Size(1346, 575)
        Me.splitContainer.SplitterDistance = 448
        Me.splitContainer.SplitterWidth = 5
        Me.splitContainer.TabIndex = 0
        '
        'pnlEmployeeList
        '
        Me.pnlEmployeeList.BackColor = System.Drawing.Color.White
        Me.pnlEmployeeList.Controls.Add(Me.dgvEmployees)
        Me.pnlEmployeeList.Controls.Add(Me.pnlEmployeeSearch)
        Me.pnlEmployeeList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEmployeeList.Location = New System.Drawing.Point(0, 0)
        Me.pnlEmployeeList.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlEmployeeList.Name = "pnlEmployeeList"
        Me.pnlEmployeeList.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlEmployeeList.Size = New System.Drawing.Size(448, 575)
        Me.pnlEmployeeList.TabIndex = 0
        '
        'dgvEmployees
        '
        Me.dgvEmployees.AllowUserToAddRows = False
        Me.dgvEmployees.AllowUserToDeleteRows = False
        Me.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEmployees.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmployees.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmployees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvEmployees.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvEmployees.ColumnHeadersHeight = 40
        Me.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEmployees.EnableHeadersVisualStyles = False
        Me.dgvEmployees.GridColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.dgvEmployees.Location = New System.Drawing.Point(20, 173)
        Me.dgvEmployees.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvEmployees.MultiSelect = False
        Me.dgvEmployees.Name = "dgvEmployees"
        Me.dgvEmployees.ReadOnly = True
        Me.dgvEmployees.RowHeadersVisible = False
        Me.dgvEmployees.RowHeadersWidth = 51
        Me.dgvEmployees.RowTemplate.Height = 40
        Me.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmployees.Size = New System.Drawing.Size(408, 382)
        Me.dgvEmployees.TabIndex = 1
        '
        'pnlEmployeeSearch
        '
        Me.pnlEmployeeSearch.Controls.Add(Me.txtSearchEmployee)
        Me.pnlEmployeeSearch.Controls.Add(Me.lblSearchEmployee)
        Me.pnlEmployeeSearch.Controls.Add(Me.cboDepartmentFilter)
        Me.pnlEmployeeSearch.Controls.Add(Me.lblDepartmentFilter)
        Me.pnlEmployeeSearch.Controls.Add(Me.lblEmployeeListTitle)
        Me.pnlEmployeeSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEmployeeSearch.Location = New System.Drawing.Point(20, 20)
        Me.pnlEmployeeSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlEmployeeSearch.Name = "pnlEmployeeSearch"
        Me.pnlEmployeeSearch.Size = New System.Drawing.Size(408, 153)
        Me.pnlEmployeeSearch.TabIndex = 0
        '
        'txtSearchEmployee
        '
        Me.txtSearchEmployee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchEmployee.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtSearchEmployee.Location = New System.Drawing.Point(5, 115)
        Me.txtSearchEmployee.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearchEmployee.Name = "txtSearchEmployee"
        Me.txtSearchEmployee.Size = New System.Drawing.Size(398, 29)
        Me.txtSearchEmployee.TabIndex = 4
        '
        'lblSearchEmployee
        '
        Me.lblSearchEmployee.AutoSize = True
        Me.lblSearchEmployee.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSearchEmployee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblSearchEmployee.Location = New System.Drawing.Point(0, 90)
        Me.lblSearchEmployee.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearchEmployee.Name = "lblSearchEmployee"
        Me.lblSearchEmployee.Size = New System.Drawing.Size(173, 20)
        Me.lblSearchEmployee.TabIndex = 3
        Me.lblSearchEmployee.Text = "Search Employee Name"
        '
        'cboDepartmentFilter
        '
        Me.cboDepartmentFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDepartmentFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartmentFilter.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboDepartmentFilter.FormattingEnabled = True
        Me.cboDepartmentFilter.Location = New System.Drawing.Point(5, 50)
        Me.cboDepartmentFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDepartmentFilter.Name = "cboDepartmentFilter"
        Me.cboDepartmentFilter.Size = New System.Drawing.Size(398, 29)
        Me.cboDepartmentFilter.TabIndex = 2
        '
        'lblDepartmentFilter
        '
        Me.lblDepartmentFilter.AutoSize = True
        Me.lblDepartmentFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepartmentFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblDepartmentFilter.Location = New System.Drawing.Point(0, 25)
        Me.lblDepartmentFilter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDepartmentFilter.Name = "lblDepartmentFilter"
        Me.lblDepartmentFilter.Size = New System.Drawing.Size(134, 20)
        Me.lblDepartmentFilter.TabIndex = 1
        Me.lblDepartmentFilter.Text = "Filter Department"
        '
        'lblEmployeeListTitle
        '
        Me.lblEmployeeListTitle.AutoSize = True
        Me.lblEmployeeListTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEmployeeListTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeListTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblEmployeeListTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblEmployeeListTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 15)
        Me.lblEmployeeListTitle.Name = "lblEmployeeListTitle"
        Me.lblEmployeeListTitle.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblEmployeeListTitle.Size = New System.Drawing.Size(213, 38)
        Me.lblEmployeeListTitle.TabIndex = 0
        Me.lblEmployeeListTitle.Text = "👥 Active Employees"
        '
        'pnlEmployeeDetails
        '
        Me.pnlEmployeeDetails.BackColor = System.Drawing.Color.White
        Me.pnlEmployeeDetails.Controls.Add(Me.dgvIssuedConsumables)
        Me.pnlEmployeeDetails.Controls.Add(Me.pnlItemsHeader)
        Me.pnlEmployeeDetails.Controls.Add(Me.pnlEmployeeInfo)
        Me.pnlEmployeeDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEmployeeDetails.Location = New System.Drawing.Point(0, 0)
        Me.pnlEmployeeDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlEmployeeDetails.Name = "pnlEmployeeDetails"
        Me.pnlEmployeeDetails.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlEmployeeDetails.Size = New System.Drawing.Size(893, 575)
        Me.pnlEmployeeDetails.TabIndex = 0
        '
        'dgvIssuedConsumables
        '
        Me.dgvIssuedConsumables.AllowUserToAddRows = False
        Me.dgvIssuedConsumables.AllowUserToDeleteRows = False
        Me.dgvIssuedConsumables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvIssuedConsumables.BackgroundColor = System.Drawing.Color.White
        Me.dgvIssuedConsumables.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIssuedConsumables.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvIssuedConsumables.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvIssuedConsumables.ColumnHeadersHeight = 40
        Me.dgvIssuedConsumables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIssuedConsumables.EnableHeadersVisualStyles = False
        Me.dgvIssuedConsumables.GridColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.dgvIssuedConsumables.Location = New System.Drawing.Point(20, 321)
        Me.dgvIssuedConsumables.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvIssuedConsumables.MultiSelect = False
        Me.dgvIssuedConsumables.Name = "dgvIssuedConsumables"
        Me.dgvIssuedConsumables.ReadOnly = True
        Me.dgvIssuedConsumables.RowHeadersVisible = False
        Me.dgvIssuedConsumables.RowHeadersWidth = 51
        Me.dgvIssuedConsumables.RowTemplate.Height = 35
        Me.dgvIssuedConsumables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIssuedConsumables.Size = New System.Drawing.Size(853, 234)
        Me.dgvIssuedConsumables.TabIndex = 2
        '
        'pnlItemsHeader
        '
        Me.pnlItemsHeader.Controls.Add(Me.lblTotalItemsValue)
        Me.pnlItemsHeader.Controls.Add(Me.lblTotalItemsLabel)
        Me.pnlItemsHeader.Controls.Add(Me.lblItemsTitle)
        Me.pnlItemsHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlItemsHeader.Location = New System.Drawing.Point(20, 261)
        Me.pnlItemsHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlItemsHeader.Name = "pnlItemsHeader"
        Me.pnlItemsHeader.Size = New System.Drawing.Size(853, 60)
        Me.pnlItemsHeader.TabIndex = 1
        '
        'lblTotalItemsValue
        '
        Me.lblTotalItemsValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalItemsValue.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalItemsValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.lblTotalItemsValue.Location = New System.Drawing.Point(685, 15)
        Me.lblTotalItemsValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalItemsValue.Name = "lblTotalItemsValue"
        Me.lblTotalItemsValue.Size = New System.Drawing.Size(155, 32)
        Me.lblTotalItemsValue.TabIndex = 2
        Me.lblTotalItemsValue.Text = "0"
        Me.lblTotalItemsValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalItemsLabel
        '
        Me.lblTotalItemsLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalItemsLabel.AutoSize = True
        Me.lblTotalItemsLabel.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblTotalItemsLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblTotalItemsLabel.Location = New System.Drawing.Point(525, 21)
        Me.lblTotalItemsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalItemsLabel.Name = "lblTotalItemsLabel"
        Me.lblTotalItemsLabel.Size = New System.Drawing.Size(157, 23)
        Me.lblTotalItemsLabel.TabIndex = 1
        Me.lblTotalItemsLabel.Text = "Total Consumables:"
        '
        'lblItemsTitle
        '
        Me.lblItemsTitle.AutoSize = True
        Me.lblItemsTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblItemsTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblItemsTitle.Location = New System.Drawing.Point(0, 15)
        Me.lblItemsTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemsTitle.Name = "lblItemsTitle"
        Me.lblItemsTitle.Size = New System.Drawing.Size(376, 28)
        Me.lblItemsTitle.TabIndex = 0
        Me.lblItemsTitle.Text = "📦 Recently Issued Consumables to ID"
        '
        'pnlEmployeeInfo
        '
        Me.pnlEmployeeInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeeEmail)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeePhone)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeePosition)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeeDepartment)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeeNumber)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeeName)
        Me.pnlEmployeeInfo.Controls.Add(Me.picQRCode)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeeInfoTitle)
        Me.pnlEmployeeInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEmployeeInfo.Location = New System.Drawing.Point(20, 20)
        Me.pnlEmployeeInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlEmployeeInfo.Name = "pnlEmployeeInfo"
        Me.pnlEmployeeInfo.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlEmployeeInfo.Size = New System.Drawing.Size(853, 241)
        Me.pnlEmployeeInfo.TabIndex = 0
        '
        'lblEmployeeEmail
        '
        Me.lblEmployeeEmail.AutoSize = True
        Me.lblEmployeeEmail.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblEmployeeEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblEmployeeEmail.Location = New System.Drawing.Point(20, 200)
        Me.lblEmployeeEmail.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeeEmail.Name = "lblEmployeeEmail"
        Me.lblEmployeeEmail.Size = New System.Drawing.Size(206, 23)
        Me.lblEmployeeEmail.TabIndex = 7
        Me.lblEmployeeEmail.Text = "📧 employee@email.com"
        '
        'lblEmployeePhone
        '
        Me.lblEmployeePhone.AutoSize = True
        Me.lblEmployeePhone.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblEmployeePhone.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblEmployeePhone.Location = New System.Drawing.Point(20, 170)
        Me.lblEmployeePhone.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeePhone.Name = "lblEmployeePhone"
        Me.lblEmployeePhone.Size = New System.Drawing.Size(164, 23)
        Me.lblEmployeePhone.TabIndex = 6
        Me.lblEmployeePhone.Text = "📞 +63 123 456 789"
        '
        'lblEmployeePosition
        '
        Me.lblEmployeePosition.AutoSize = True
        Me.lblEmployeePosition.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblEmployeePosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblEmployeePosition.Location = New System.Drawing.Point(20, 140)
        Me.lblEmployeePosition.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeePosition.Name = "lblEmployeePosition"
        Me.lblEmployeePosition.Size = New System.Drawing.Size(128, 23)
        Me.lblEmployeePosition.TabIndex = 5
        Me.lblEmployeePosition.Text = "💼 Position: ---"
        '
        'lblEmployeeDepartment
        '
        Me.lblEmployeeDepartment.AutoSize = True
        Me.lblEmployeeDepartment.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblEmployeeDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblEmployeeDepartment.Location = New System.Drawing.Point(20, 110)
        Me.lblEmployeeDepartment.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeeDepartment.Name = "lblEmployeeDepartment"
        Me.lblEmployeeDepartment.Size = New System.Drawing.Size(160, 23)
        Me.lblEmployeeDepartment.TabIndex = 4
        Me.lblEmployeeDepartment.Text = "🏢 Department: ---"
        '
        'lblEmployeeNumber
        '
        Me.lblEmployeeNumber.AutoSize = True
        Me.lblEmployeeNumber.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblEmployeeNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblEmployeeNumber.Location = New System.Drawing.Point(20, 80)
        Me.lblEmployeeNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeeNumber.Name = "lblEmployeeNumber"
        Me.lblEmployeeNumber.Size = New System.Drawing.Size(131, 23)
        Me.lblEmployeeNumber.TabIndex = 3
        Me.lblEmployeeNumber.Text = "ID: EMP-000000"
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.AutoSize = True
        Me.lblEmployeeName.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblEmployeeName.Location = New System.Drawing.Point(20, 45)
        Me.lblEmployeeName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Size = New System.Drawing.Size(324, 32)
        Me.lblEmployeeName.TabIndex = 2
        Me.lblEmployeeName.Text = "Select an employee to view"
        '
        'picQRCode
        '
        Me.picQRCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picQRCode.Location = New System.Drawing.Point(660, 45)
        Me.picQRCode.Margin = New System.Windows.Forms.Padding(4)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(170, 170)
        Me.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picQRCode.TabIndex = 1
        Me.picQRCode.TabStop = False
        '
        'lblEmployeeInfoTitle
        '
        Me.lblEmployeeInfoTitle.AutoSize = True
        Me.lblEmployeeInfoTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblEmployeeInfoTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeInfoTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblEmployeeInfoTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblEmployeeInfoTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeeInfoTitle.Name = "lblEmployeeInfoTitle"
        Me.lblEmployeeInfoTitle.Size = New System.Drawing.Size(189, 25)
        Me.lblEmployeeInfoTitle.TabIndex = 0
        Me.lblEmployeeInfoTitle.Text = "👤 Employee Details"
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.White
        Me.pnlActions.Controls.Add(Me.btnIssueConsumable)
        Me.pnlActions.Controls.Add(Me.btnViewHistory)
        Me.pnlActions.Controls.Add(Me.btnRefresh)
        Me.pnlActions.Controls.Add(Me.lblRecordCount)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActions.Location = New System.Drawing.Point(27, 705)
        Me.pnlActions.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlActions.Size = New System.Drawing.Size(1346, 70)
        Me.pnlActions.TabIndex = 1
        '
        'btnIssueConsumable
        '
        Me.btnIssueConsumable.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIssueConsumable.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnIssueConsumable.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIssueConsumable.FlatAppearance.BorderSize = 0
        Me.btnIssueConsumable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIssueConsumable.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnIssueConsumable.ForeColor = System.Drawing.Color.White
        Me.btnIssueConsumable.Location = New System.Drawing.Point(1114, 15)
        Me.btnIssueConsumable.Margin = New System.Windows.Forms.Padding(4)
        Me.btnIssueConsumable.Name = "btnIssueConsumable"
        Me.btnIssueConsumable.Size = New System.Drawing.Size(212, 40)
        Me.btnIssueConsumable.TabIndex = 3
        Me.btnIssueConsumable.Text = "📦 Issue Consumable"
        Me.btnIssueConsumable.UseVisualStyleBackColor = False
        '
        'btnViewHistory
        '
        Me.btnViewHistory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btnViewHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewHistory.FlatAppearance.BorderSize = 0
        Me.btnViewHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewHistory.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnViewHistory.ForeColor = System.Drawing.Color.White
        Me.btnViewHistory.Location = New System.Drawing.Point(934, 15)
        Me.btnViewHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewHistory.Name = "btnViewHistory"
        Me.btnViewHistory.Size = New System.Drawing.Size(160, 40)
        Me.btnViewHistory.TabIndex = 2
        Me.btnViewHistory.Text = "📜 View History"
        Me.btnViewHistory.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(25, 15)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(130, 40)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "🔄 Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblRecordCount.Location = New System.Drawing.Point(170, 25)
        Me.lblRecordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(159, 23)
        Me.lblRecordCount.TabIndex = 0
        Me.lblRecordCount.Text = "Total Employees: 0"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(27, 25)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.pnlHeader.Size = New System.Drawing.Size(1346, 105)
        Me.pnlHeader.TabIndex = 0
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(27, 71)
        Me.lblSubtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(433, 23)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Issue consumables to employees and track issued items"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(27, 25)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(600, 46)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "📦 Issue Consumables to Employees"
        '
        'ConsumableIssuedEmployeeFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1400, 800)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ConsumableIssuedEmployeeFrm"
        Me.Text = "Issue Consumables to Employees"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.splitContainer.Panel1.ResumeLayout(False)
        Me.splitContainer.Panel2.ResumeLayout(False)
        CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer.ResumeLayout(False)
        Me.pnlEmployeeList.ResumeLayout(False)
        CType(Me.dgvEmployees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEmployeeSearch.ResumeLayout(False)
        Me.pnlEmployeeSearch.PerformLayout()
        Me.pnlEmployeeDetails.ResumeLayout(False)
        CType(Me.dgvIssuedConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlItemsHeader.ResumeLayout(False)
        Me.pnlItemsHeader.PerformLayout()
        Me.pnlEmployeeInfo.ResumeLayout(False)
        Me.pnlEmployeeInfo.PerformLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlActions.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblRecordCount As Label
    Friend WithEvents btnViewHistory As Button
    Friend WithEvents btnIssueConsumable As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents splitContainer As SplitContainer
    Friend WithEvents pnlEmployeeList As Panel
    Friend WithEvents dgvEmployees As DataGridView
    Friend WithEvents pnlEmployeeSearch As Panel
    Friend WithEvents lblEmployeeListTitle As Label
    Friend WithEvents cboDepartmentFilter As ComboBox
    Friend WithEvents lblDepartmentFilter As Label
    Friend WithEvents txtSearchEmployee As TextBox
    Friend WithEvents lblSearchEmployee As Label
    Friend WithEvents pnlEmployeeDetails As Panel
    Friend WithEvents pnlEmployeeInfo As Panel
    Friend WithEvents lblEmployeeInfoTitle As Label
    Friend WithEvents picQRCode As PictureBox
    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents lblEmployeeNumber As Label
    Friend WithEvents lblEmployeeDepartment As Label
    Friend WithEvents lblEmployeePosition As Label
    Friend WithEvents lblEmployeePhone As Label
    Friend WithEvents lblEmployeeEmail As Label
    Friend WithEvents pnlItemsHeader As Panel
    Friend WithEvents lblItemsTitle As Label
    Friend WithEvents lblTotalItemsLabel As Label
    Friend WithEvents lblTotalItemsValue As Label
    Friend WithEvents dgvIssuedConsumables As DataGridView

End Class