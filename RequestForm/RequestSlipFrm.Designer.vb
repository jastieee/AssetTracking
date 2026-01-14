<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RequestSlipFrm
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
        Me.pnlSlipContainer = New System.Windows.Forms.Panel()
        Me.pnlSlipContent = New System.Windows.Forms.Panel()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.pnlItemDetails = New System.Windows.Forms.Panel()
        Me.dgvRequestedItems = New System.Windows.Forms.DataGridView()
        Me.btnRemoveItem = New System.Windows.Forms.Button()
        Me.btnAddItem = New System.Windows.Forms.Button()
        Me.lblItemDetails = New System.Windows.Forms.Label()
        Me.pnlRequestInfo = New System.Windows.Forms.Panel()
        Me.cmbPriority = New System.Windows.Forms.ComboBox()
        Me.lblPriority = New System.Windows.Forms.Label()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.lblPurpose = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.lblRequestInfo = New System.Windows.Forms.Label()
        Me.pnlRequesterInfo = New System.Windows.Forms.Panel()
        Me.lblDepartmentValue = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblPositionValue = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblEmployeeNameValue = New System.Windows.Forms.Label()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.lblEmployeeNumValue = New System.Windows.Forms.Label()
        Me.lblEmployeeNum = New System.Windows.Forms.Label()
        Me.lblRequesterInfo = New System.Windows.Forms.Label()
        Me.pnlSlipHeader = New System.Windows.Forms.Panel()
        Me.lblRequestDate = New System.Windows.Forms.Label()
        Me.lblRequestNumber = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.lblSlipTitle = New System.Windows.Forms.Label()
        Me.pnlTopBar = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlSlipContainer.SuspendLayout()
        Me.pnlSlipContent.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.pnlItemDetails.SuspendLayout()
        CType(Me.dgvRequestedItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRequestInfo.SuspendLayout()
        Me.pnlRequesterInfo.SuspendLayout()
        Me.pnlSlipHeader.SuspendLayout()
        Me.pnlTopBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlSlipContainer)
        Me.pnlMain.Controls.Add(Me.pnlTopBar)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(900, 800)
        Me.pnlMain.TabIndex = 0
        '
        'pnlSlipContainer
        '
        Me.pnlSlipContainer.AutoScroll = True
        Me.pnlSlipContainer.Controls.Add(Me.pnlSlipContent)
        Me.pnlSlipContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSlipContainer.Location = New System.Drawing.Point(0, 60)
        Me.pnlSlipContainer.Name = "pnlSlipContainer"
        Me.pnlSlipContainer.Padding = New System.Windows.Forms.Padding(30)
        Me.pnlSlipContainer.Size = New System.Drawing.Size(900, 740)
        Me.pnlSlipContainer.TabIndex = 1
        '
        'pnlSlipContent
        '
        Me.pnlSlipContent.BackColor = System.Drawing.Color.White
        Me.pnlSlipContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSlipContent.Controls.Add(Me.pnlButtons)
        Me.pnlSlipContent.Controls.Add(Me.pnlItemDetails)
        Me.pnlSlipContent.Controls.Add(Me.pnlRequestInfo)
        Me.pnlSlipContent.Controls.Add(Me.pnlRequesterInfo)
        Me.pnlSlipContent.Controls.Add(Me.pnlSlipHeader)
        Me.pnlSlipContent.Location = New System.Drawing.Point(30, 30)
        Me.pnlSlipContent.Name = "pnlSlipContent"
        Me.pnlSlipContent.Size = New System.Drawing.Size(820, 1050)
        Me.pnlSlipContent.TabIndex = 0
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnPrint)
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Controls.Add(Me.btnSubmit)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 988)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Padding = New System.Windows.Forms.Padding(40, 20, 40, 30)
        Me.pnlButtons.Size = New System.Drawing.Size(818, 60)
        Me.pnlButtons.TabIndex = 4
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(40, 20)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(150, 10)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "🖨️ Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(628, 20)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 10)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "❌ Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(468, 20)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(160, 10)
        Me.btnSubmit.TabIndex = 0
        Me.btnSubmit.Text = "✅ Submit Request"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'pnlItemDetails
        '
        Me.pnlItemDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlItemDetails.Controls.Add(Me.dgvRequestedItems)
        Me.pnlItemDetails.Controls.Add(Me.btnRemoveItem)
        Me.pnlItemDetails.Controls.Add(Me.btnAddItem)
        Me.pnlItemDetails.Controls.Add(Me.lblItemDetails)
        Me.pnlItemDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlItemDetails.Location = New System.Drawing.Point(0, 568)
        Me.pnlItemDetails.Name = "pnlItemDetails"
        Me.pnlItemDetails.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlItemDetails.Size = New System.Drawing.Size(818, 400)
        Me.pnlItemDetails.TabIndex = 3
        '
        'dgvRequestedItems
        '
        Me.dgvRequestedItems.AllowUserToAddRows = False
        Me.dgvRequestedItems.AllowUserToDeleteRows = False
        Me.dgvRequestedItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRequestedItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvRequestedItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRequestedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRequestedItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRequestedItems.Location = New System.Drawing.Point(20, 65)
        Me.dgvRequestedItems.Name = "dgvRequestedItems"
        Me.dgvRequestedItems.ReadOnly = True
        Me.dgvRequestedItems.RowHeadersVisible = False
        Me.dgvRequestedItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRequestedItems.Size = New System.Drawing.Size(776, 263)
        Me.dgvRequestedItems.TabIndex = 3
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnRemoveItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveItem.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnRemoveItem.FlatAppearance.BorderSize = 0
        Me.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRemoveItem.ForeColor = System.Drawing.Color.White
        Me.btnRemoveItem.Location = New System.Drawing.Point(20, 328)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Size = New System.Drawing.Size(776, 25)
        Me.btnRemoveItem.TabIndex = 2
        Me.btnRemoveItem.Text = "➖ Remove Selected Item"
        Me.btnRemoveItem.UseVisualStyleBackColor = False
        '
        'btnAddItem
        '
        Me.btnAddItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddItem.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnAddItem.FlatAppearance.BorderSize = 0
        Me.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddItem.ForeColor = System.Drawing.Color.White
        Me.btnAddItem.Location = New System.Drawing.Point(20, 353)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(776, 25)
        Me.btnAddItem.TabIndex = 1
        Me.btnAddItem.Text = "➕ Add Item to Request"
        Me.btnAddItem.UseVisualStyleBackColor = False
        '
        'lblItemDetails
        '
        Me.lblItemDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblItemDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblItemDetails.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblItemDetails.ForeColor = System.Drawing.Color.White
        Me.lblItemDetails.Location = New System.Drawing.Point(20, 20)
        Me.lblItemDetails.Name = "lblItemDetails"
        Me.lblItemDetails.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.lblItemDetails.Size = New System.Drawing.Size(776, 45)
        Me.lblItemDetails.TabIndex = 0
        Me.lblItemDetails.Text = "📦 ITEM DETAILS"
        '
        'pnlRequestInfo
        '
        Me.pnlRequestInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRequestInfo.Controls.Add(Me.cmbPriority)
        Me.pnlRequestInfo.Controls.Add(Me.lblPriority)
        Me.pnlRequestInfo.Controls.Add(Me.txtPurpose)
        Me.pnlRequestInfo.Controls.Add(Me.lblPurpose)
        Me.pnlRequestInfo.Controls.Add(Me.txtReason)
        Me.pnlRequestInfo.Controls.Add(Me.lblReason)
        Me.pnlRequestInfo.Controls.Add(Me.lblRequestInfo)
        Me.pnlRequestInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRequestInfo.Location = New System.Drawing.Point(0, 308)
        Me.pnlRequestInfo.Name = "pnlRequestInfo"
        Me.pnlRequestInfo.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlRequestInfo.Size = New System.Drawing.Size(818, 260)
        Me.pnlRequestInfo.TabIndex = 2
        '
        'cmbPriority
        '
        Me.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPriority.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbPriority.FormattingEnabled = True
        Me.cmbPriority.Items.AddRange(New Object() {"Low", "Medium", "High", "Urgent"})
        Me.cmbPriority.Location = New System.Drawing.Point(180, 205)
        Me.cmbPriority.Name = "cmbPriority"
        Me.cmbPriority.Size = New System.Drawing.Size(200, 25)
        Me.cmbPriority.TabIndex = 6
        '
        'lblPriority
        '
        Me.lblPriority.AutoSize = True
        Me.lblPriority.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPriority.Location = New System.Drawing.Point(30, 208)
        Me.lblPriority.Name = "lblPriority"
        Me.lblPriority.Size = New System.Drawing.Size(67, 19)
        Me.lblPriority.TabIndex = 5
        Me.lblPriority.Text = "Priority:"
        '
        'txtPurpose
        '
        Me.txtPurpose.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtPurpose.Location = New System.Drawing.Point(180, 145)
        Me.txtPurpose.Multiline = True
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPurpose.Size = New System.Drawing.Size(600, 45)
        Me.txtPurpose.TabIndex = 4
        '
        'lblPurpose
        '
        Me.lblPurpose.AutoSize = True
        Me.lblPurpose.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPurpose.Location = New System.Drawing.Point(30, 148)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(71, 19)
        Me.lblPurpose.TabIndex = 3
        Me.lblPurpose.Text = "Purpose:"
        '
        'txtReason
        '
        Me.txtReason.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtReason.Location = New System.Drawing.Point(180, 65)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReason.Size = New System.Drawing.Size(600, 65)
        Me.txtReason.TabIndex = 2
        '
        'lblReason
        '
        Me.lblReason.AutoSize = True
        Me.lblReason.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblReason.Location = New System.Drawing.Point(30, 68)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(144, 19)
        Me.lblReason.TabIndex = 1
        Me.lblReason.Text = "Reason for Request:"
        '
        'lblRequestInfo
        '
        Me.lblRequestInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblRequestInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRequestInfo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequestInfo.ForeColor = System.Drawing.Color.White
        Me.lblRequestInfo.Location = New System.Drawing.Point(20, 20)
        Me.lblRequestInfo.Name = "lblRequestInfo"
        Me.lblRequestInfo.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.lblRequestInfo.Size = New System.Drawing.Size(776, 45)
        Me.lblRequestInfo.TabIndex = 0
        Me.lblRequestInfo.Text = "📝 REQUEST INFORMATION"
        '
        'pnlRequesterInfo
        '
        Me.pnlRequesterInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRequesterInfo.Controls.Add(Me.lblDepartmentValue)
        Me.pnlRequesterInfo.Controls.Add(Me.lblDepartment)
        Me.pnlRequesterInfo.Controls.Add(Me.lblPositionValue)
        Me.pnlRequesterInfo.Controls.Add(Me.lblPosition)
        Me.pnlRequesterInfo.Controls.Add(Me.lblEmployeeNameValue)
        Me.pnlRequesterInfo.Controls.Add(Me.lblEmployeeName)
        Me.pnlRequesterInfo.Controls.Add(Me.lblEmployeeNumValue)
        Me.pnlRequesterInfo.Controls.Add(Me.lblEmployeeNum)
        Me.pnlRequesterInfo.Controls.Add(Me.lblRequesterInfo)
        Me.pnlRequesterInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRequesterInfo.Location = New System.Drawing.Point(0, 158)
        Me.pnlRequesterInfo.Name = "pnlRequesterInfo"
        Me.pnlRequesterInfo.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlRequesterInfo.Size = New System.Drawing.Size(818, 150)
        Me.pnlRequesterInfo.TabIndex = 1
        '
        'lblDepartmentValue
        '
        Me.lblDepartmentValue.AutoSize = True
        Me.lblDepartmentValue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDepartmentValue.Location = New System.Drawing.Point(590, 103)
        Me.lblDepartmentValue.Name = "lblDepartmentValue"
        Me.lblDepartmentValue.Size = New System.Drawing.Size(106, 19)
        Me.lblDepartmentValue.TabIndex = 8
        Me.lblDepartmentValue.Text = "[Department]"
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepartment.Location = New System.Drawing.Point(450, 103)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(97, 19)
        Me.lblDepartment.TabIndex = 7
        Me.lblDepartment.Text = "Department:"
        '
        'lblPositionValue
        '
        Me.lblPositionValue.AutoSize = True
        Me.lblPositionValue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblPositionValue.Location = New System.Drawing.Point(180, 103)
        Me.lblPositionValue.Name = "lblPositionValue"
        Me.lblPositionValue.Size = New System.Drawing.Size(74, 19)
        Me.lblPositionValue.TabIndex = 6
        Me.lblPositionValue.Text = "[Position]"
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPosition.Location = New System.Drawing.Point(30, 103)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(69, 19)
        Me.lblPosition.TabIndex = 5
        Me.lblPosition.Text = "Position:"
        '
        'lblEmployeeNameValue
        '
        Me.lblEmployeeNameValue.AutoSize = True
        Me.lblEmployeeNameValue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblEmployeeNameValue.Location = New System.Drawing.Point(590, 68)
        Me.lblEmployeeNameValue.Name = "lblEmployeeNameValue"
        Me.lblEmployeeNameValue.Size = New System.Drawing.Size(130, 19)
        Me.lblEmployeeNameValue.TabIndex = 4
        Me.lblEmployeeNameValue.Text = "[Employee Name]"
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.AutoSize = True
        Me.lblEmployeeName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeName.Location = New System.Drawing.Point(450, 68)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Size = New System.Drawing.Size(125, 19)
        Me.lblEmployeeName.TabIndex = 3
        Me.lblEmployeeName.Text = "Employee Name:"
        '
        'lblEmployeeNumValue
        '
        Me.lblEmployeeNumValue.AutoSize = True
        Me.lblEmployeeNumValue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblEmployeeNumValue.Location = New System.Drawing.Point(180, 68)
        Me.lblEmployeeNumValue.Name = "lblEmployeeNumValue"
        Me.lblEmployeeNumValue.Size = New System.Drawing.Size(89, 19)
        Me.lblEmployeeNumValue.TabIndex = 2
        Me.lblEmployeeNumValue.Text = "[Emp. No.]"
        '
        'lblEmployeeNum
        '
        Me.lblEmployeeNum.AutoSize = True
        Me.lblEmployeeNum.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeNum.Location = New System.Drawing.Point(30, 68)
        Me.lblEmployeeNum.Name = "lblEmployeeNum"
        Me.lblEmployeeNum.Size = New System.Drawing.Size(78, 19)
        Me.lblEmployeeNum.TabIndex = 1
        Me.lblEmployeeNum.Text = "Emp. No.:"
        '
        'lblRequesterInfo
        '
        Me.lblRequesterInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblRequesterInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRequesterInfo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequesterInfo.ForeColor = System.Drawing.Color.White
        Me.lblRequesterInfo.Location = New System.Drawing.Point(20, 20)
        Me.lblRequesterInfo.Name = "lblRequesterInfo"
        Me.lblRequesterInfo.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.lblRequesterInfo.Size = New System.Drawing.Size(776, 45)
        Me.lblRequesterInfo.TabIndex = 0
        Me.lblRequesterInfo.Text = "👤 REQUESTER INFORMATION"
        '
        'pnlSlipHeader
        '
        Me.pnlSlipHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSlipHeader.Controls.Add(Me.lblRequestDate)
        Me.pnlSlipHeader.Controls.Add(Me.lblRequestNumber)
        Me.pnlSlipHeader.Controls.Add(Me.lblCompanyName)
        Me.pnlSlipHeader.Controls.Add(Me.lblSlipTitle)
        Me.pnlSlipHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSlipHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlSlipHeader.Name = "pnlSlipHeader"
        Me.pnlSlipHeader.Padding = New System.Windows.Forms.Padding(30, 20, 30, 20)
        Me.pnlSlipHeader.Size = New System.Drawing.Size(818, 158)
        Me.pnlSlipHeader.TabIndex = 0
        '
        'lblRequestDate
        '
        Me.lblRequestDate.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRequestDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRequestDate.Location = New System.Drawing.Point(30, 118)
        Me.lblRequestDate.Name = "lblRequestDate"
        Me.lblRequestDate.Size = New System.Drawing.Size(756, 20)
        Me.lblRequestDate.TabIndex = 3
        Me.lblRequestDate.Text = "Date: October 24, 2025"
        Me.lblRequestDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRequestNumber
        '
        Me.lblRequestNumber.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRequestNumber.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequestNumber.Location = New System.Drawing.Point(30, 90)
        Me.lblRequestNumber.Name = "lblRequestNumber"
        Me.lblRequestNumber.Size = New System.Drawing.Size(756, 28)
        Me.lblRequestNumber.TabIndex = 2
        Me.lblRequestNumber.Text = "Request No: REQ-2025-0001"
        Me.lblRequestNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCompanyName.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCompanyName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblCompanyName.Location = New System.Drawing.Point(30, 55)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(756, 35)
        Me.lblCompanyName.TabIndex = 1
        Me.lblCompanyName.Text = "[COMPANY NAME]"
        Me.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSlipTitle
        '
        Me.lblSlipTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblSlipTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSlipTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblSlipTitle.ForeColor = System.Drawing.Color.White
        Me.lblSlipTitle.Location = New System.Drawing.Point(30, 20)
        Me.lblSlipTitle.Name = "lblSlipTitle"
        Me.lblSlipTitle.Size = New System.Drawing.Size(756, 35)
        Me.lblSlipTitle.TabIndex = 0
        Me.lblSlipTitle.Text = "ASSET / CONSUMABLE REQUEST SLIP"
        Me.lblSlipTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTopBar
        '
        Me.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.pnlTopBar.Controls.Add(Me.btnClose)
        Me.pnlTopBar.Controls.Add(Me.lblFormTitle)
        Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopBar.Name = "pnlTopBar"
        Me.pnlTopBar.Size = New System.Drawing.Size(900, 60)
        Me.pnlTopBar.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(840, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(60, 60)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "✕"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblFormTitle
        '
        Me.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblFormTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblFormTitle.ForeColor = System.Drawing.Color.White
        Me.lblFormTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblFormTitle.Name = "lblFormTitle"
        Me.lblFormTitle.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblFormTitle.Size = New System.Drawing.Size(500, 60)
        Me.lblFormTitle.TabIndex = 0
        Me.lblFormTitle.Text = "📝 New Request"
        Me.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RequestSlipFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 800)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RequestSlipFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request Slip"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlSlipContainer.ResumeLayout(False)
        Me.pnlSlipContent.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlItemDetails.ResumeLayout(False)
        CType(Me.dgvRequestedItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRequestInfo.ResumeLayout(False)
        Me.pnlRequestInfo.PerformLayout()
        Me.pnlRequesterInfo.ResumeLayout(False)
        Me.pnlRequesterInfo.PerformLayout()
        Me.pnlSlipHeader.ResumeLayout(False)
        Me.pnlTopBar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlTopBar As Panel
    Friend WithEvents lblFormTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlSlipContainer As Panel
    Friend WithEvents pnlSlipContent As Panel
    Friend WithEvents pnlSlipHeader As Panel
    Friend WithEvents lblSlipTitle As Label
    Friend WithEvents lblCompanyName As Label
    Friend WithEvents lblRequestNumber As Label
    Friend WithEvents lblRequestDate As Label
    Friend WithEvents pnlRequesterInfo As Panel
    Friend WithEvents lblRequesterInfo As Label
    Friend WithEvents lblEmployeeNum As Label
    Friend WithEvents lblEmployeeNumValue As Label
    Friend WithEvents lblEmployeeName As Label
    Friend WithEvents lblEmployeeNameValue As Label
    Friend WithEvents lblPosition As Label
    Friend WithEvents lblPositionValue As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents lblDepartmentValue As Label
    Friend WithEvents pnlRequestInfo As Panel
    Friend WithEvents lblRequestInfo As Label
    Friend WithEvents lblReason As Label
    Friend WithEvents txtReason As TextBox
    Friend WithEvents lblPurpose As Label
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents lblPriority As Label
    Friend WithEvents cmbPriority As ComboBox
    Friend WithEvents pnlItemDetails As Panel
    Friend WithEvents lblItemDetails As Label
    Friend WithEvents btnAddItem As Button
    Friend WithEvents btnRemoveItem As Button
    Friend WithEvents dgvRequestedItems As DataGridView
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnPrint As Button

End Class