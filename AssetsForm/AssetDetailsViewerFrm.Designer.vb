<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AssetDetailsViewerFrm
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
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.grpIssuanceHistory = New System.Windows.Forms.GroupBox()
        Me.dgvIssuanceHistory = New System.Windows.Forms.DataGridView()
        Me.grpMaintenanceHistory = New System.Windows.Forms.GroupBox()
        Me.dgvMaintenanceHistory = New System.Windows.Forms.DataGridView()
        Me.grpAssetInfo = New System.Windows.Forms.GroupBox()
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.lblAssetTagValue = New System.Windows.Forms.Label()
        Me.lblAssetName = New System.Windows.Forms.Label()
        Me.lblAssetNameValue = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblCategoryValue = New System.Windows.Forms.Label()
        Me.lblSubcategory = New System.Windows.Forms.Label()
        Me.lblSubcategoryValue = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblStatusValue = New System.Windows.Forms.Label()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.lblConditionValue = New System.Windows.Forms.Label()
        Me.lblSerial = New System.Windows.Forms.Label()
        Me.lblSerialValue = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.lblModelValue = New System.Windows.Forms.Label()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.lblManufacturerValue = New System.Windows.Forms.Label()
        Me.lblPurchaseDate = New System.Windows.Forms.Label()
        Me.lblPurchaseDateValue = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblDepartmentValue = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblDescriptionValue = New System.Windows.Forms.Label()
        Me.grpActions = New System.Windows.Forms.GroupBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddMaintenance = New System.Windows.Forms.Button()
        Me.btnRequestDisposal = New System.Windows.Forms.Button()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.pnlTop.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.grpIssuanceHistory.SuspendLayout()
        CType(Me.dgvIssuanceHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMaintenanceHistory.SuspendLayout()
        CType(Me.dgvMaintenanceHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAssetInfo.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.pnlTop.Controls.Add(Me.btnClose)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1100, 60)
        Me.pnlTop.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(1000, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 60)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "✖ Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(201, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "📦 Asset Details"
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.pnlRight)
        Me.pnlContent.Controls.Add(Me.pnlLeft)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 60)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(1100, 640)
        Me.pnlContent.TabIndex = 1
        '
        'pnlRight
        '
        Me.pnlRight.Controls.Add(Me.grpIssuanceHistory)
        Me.pnlRight.Controls.Add(Me.grpMaintenanceHistory)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRight.Location = New System.Drawing.Point(470, 20)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(610, 600)
        Me.pnlRight.TabIndex = 1
        '
        'grpIssuanceHistory
        '
        Me.grpIssuanceHistory.Controls.Add(Me.dgvIssuanceHistory)
        Me.grpIssuanceHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpIssuanceHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpIssuanceHistory.Location = New System.Drawing.Point(0, 0)
        Me.grpIssuanceHistory.Name = "grpIssuanceHistory"
        Me.grpIssuanceHistory.Padding = New System.Windows.Forms.Padding(10)
        Me.grpIssuanceHistory.Size = New System.Drawing.Size(610, 300)
        Me.grpIssuanceHistory.TabIndex = 1
        Me.grpIssuanceHistory.TabStop = False
        Me.grpIssuanceHistory.Text = "📋 Issuance History"
        '
        'dgvIssuanceHistory
        '
        Me.dgvIssuanceHistory.AllowUserToAddRows = False
        Me.dgvIssuanceHistory.AllowUserToDeleteRows = False
        Me.dgvIssuanceHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvIssuanceHistory.BackgroundColor = System.Drawing.Color.White
        Me.dgvIssuanceHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIssuanceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIssuanceHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIssuanceHistory.Location = New System.Drawing.Point(10, 30)
        Me.dgvIssuanceHistory.Name = "dgvIssuanceHistory"
        Me.dgvIssuanceHistory.ReadOnly = True
        Me.dgvIssuanceHistory.RowHeadersVisible = False
        Me.dgvIssuanceHistory.RowHeadersWidth = 51
        Me.dgvIssuanceHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIssuanceHistory.Size = New System.Drawing.Size(590, 260)
        Me.dgvIssuanceHistory.TabIndex = 0
        '
        'grpMaintenanceHistory
        '
        Me.grpMaintenanceHistory.Controls.Add(Me.dgvMaintenanceHistory)
        Me.grpMaintenanceHistory.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpMaintenanceHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpMaintenanceHistory.Location = New System.Drawing.Point(0, 300)
        Me.grpMaintenanceHistory.Name = "grpMaintenanceHistory"
        Me.grpMaintenanceHistory.Padding = New System.Windows.Forms.Padding(10)
        Me.grpMaintenanceHistory.Size = New System.Drawing.Size(610, 300)
        Me.grpMaintenanceHistory.TabIndex = 0
        Me.grpMaintenanceHistory.TabStop = False
        Me.grpMaintenanceHistory.Text = "🔧 Maintenance History"
        '
        'dgvMaintenanceHistory
        '
        Me.dgvMaintenanceHistory.AllowUserToAddRows = False
        Me.dgvMaintenanceHistory.AllowUserToDeleteRows = False
        Me.dgvMaintenanceHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMaintenanceHistory.BackgroundColor = System.Drawing.Color.White
        Me.dgvMaintenanceHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvMaintenanceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaintenanceHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaintenanceHistory.Location = New System.Drawing.Point(10, 30)
        Me.dgvMaintenanceHistory.Name = "dgvMaintenanceHistory"
        Me.dgvMaintenanceHistory.ReadOnly = True
        Me.dgvMaintenanceHistory.RowHeadersVisible = False
        Me.dgvMaintenanceHistory.RowHeadersWidth = 51
        Me.dgvMaintenanceHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaintenanceHistory.Size = New System.Drawing.Size(590, 260)
        Me.dgvMaintenanceHistory.TabIndex = 0
        '
        'grpAssetInfo
        '
        Me.grpAssetInfo.Controls.Add(Me.lblDescriptionValue)
        Me.grpAssetInfo.Controls.Add(Me.lblDescription)
        Me.grpAssetInfo.Controls.Add(Me.lblDepartmentValue)
        Me.grpAssetInfo.Controls.Add(Me.lblDepartment)
        Me.grpAssetInfo.Controls.Add(Me.lblPurchaseDateValue)
        Me.grpAssetInfo.Controls.Add(Me.lblPurchaseDate)
        Me.grpAssetInfo.Controls.Add(Me.lblManufacturerValue)
        Me.grpAssetInfo.Controls.Add(Me.lblManufacturer)
        Me.grpAssetInfo.Controls.Add(Me.lblModelValue)
        Me.grpAssetInfo.Controls.Add(Me.lblModel)
        Me.grpAssetInfo.Controls.Add(Me.lblSerialValue)
        Me.grpAssetInfo.Controls.Add(Me.lblSerial)
        Me.grpAssetInfo.Controls.Add(Me.lblConditionValue)
        Me.grpAssetInfo.Controls.Add(Me.lblCondition)
        Me.grpAssetInfo.Controls.Add(Me.lblStatusValue)
        Me.grpAssetInfo.Controls.Add(Me.lblStatus)
        Me.grpAssetInfo.Controls.Add(Me.lblSubcategoryValue)
        Me.grpAssetInfo.Controls.Add(Me.lblSubcategory)
        Me.grpAssetInfo.Controls.Add(Me.lblCategoryValue)
        Me.grpAssetInfo.Controls.Add(Me.lblCategory)
        Me.grpAssetInfo.Controls.Add(Me.lblAssetNameValue)
        Me.grpAssetInfo.Controls.Add(Me.lblAssetName)
        Me.grpAssetInfo.Controls.Add(Me.lblAssetTagValue)
        Me.grpAssetInfo.Controls.Add(Me.lblAssetTag)
        Me.grpAssetInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpAssetInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpAssetInfo.Location = New System.Drawing.Point(0, 0)
        Me.grpAssetInfo.Name = "grpAssetInfo"
        Me.grpAssetInfo.Padding = New System.Windows.Forms.Padding(10)
        Me.grpAssetInfo.Size = New System.Drawing.Size(450, 340)
        Me.grpAssetInfo.TabIndex = 0
        Me.grpAssetInfo.TabStop = False
        Me.grpAssetInfo.Text = "ℹ️ Asset Information"
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblAssetTag.Location = New System.Drawing.Point(300, 10)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(76, 19)
        Me.lblAssetTag.TabIndex = 0
        Me.lblAssetTag.Text = "Asset Tag:"
        '
        'lblAssetTagValue
        '
        Me.lblAssetTagValue.AutoSize = True
        Me.lblAssetTagValue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblAssetTagValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblAssetTagValue.Location = New System.Drawing.Point(300, 30)
        Me.lblAssetTagValue.Name = "lblAssetTagValue"
        Me.lblAssetTagValue.Size = New System.Drawing.Size(17, 23)
        Me.lblAssetTagValue.TabIndex = 1
        Me.lblAssetTagValue.Text = "-"
        '
        'lblAssetName
        '
        Me.lblAssetName.AutoSize = True
        Me.lblAssetName.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblAssetName.Location = New System.Drawing.Point(15, 30)
        Me.lblAssetName.Name = "lblAssetName"
        Me.lblAssetName.Size = New System.Drawing.Size(92, 19)
        Me.lblAssetName.TabIndex = 2
        Me.lblAssetName.Text = "Asset Name:"
        '
        'lblAssetNameValue
        '
        Me.lblAssetNameValue.AutoSize = True
        Me.lblAssetNameValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAssetNameValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblAssetNameValue.Location = New System.Drawing.Point(130, 30)
        Me.lblAssetNameValue.Name = "lblAssetNameValue"
        Me.lblAssetNameValue.Size = New System.Drawing.Size(15, 20)
        Me.lblAssetNameValue.TabIndex = 3
        Me.lblAssetNameValue.Text = "-"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCategory.Location = New System.Drawing.Point(15, 55)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(76, 19)
        Me.lblCategory.TabIndex = 4
        Me.lblCategory.Text = "Category:"
        '
        'lblCategoryValue
        '
        Me.lblCategoryValue.AutoSize = True
        Me.lblCategoryValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblCategoryValue.Location = New System.Drawing.Point(130, 55)
        Me.lblCategoryValue.Name = "lblCategoryValue"
        Me.lblCategoryValue.Size = New System.Drawing.Size(15, 19)
        Me.lblCategoryValue.TabIndex = 5
        Me.lblCategoryValue.Text = "-"
        '
        'lblSubcategory
        '
        Me.lblSubcategory.AutoSize = True
        Me.lblSubcategory.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSubcategory.Location = New System.Drawing.Point(15, 80)
        Me.lblSubcategory.Name = "lblSubcategory"
        Me.lblSubcategory.Size = New System.Drawing.Size(99, 19)
        Me.lblSubcategory.TabIndex = 6
        Me.lblSubcategory.Text = "Subcategory:"
        '
        'lblSubcategoryValue
        '
        Me.lblSubcategoryValue.AutoSize = True
        Me.lblSubcategoryValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblSubcategoryValue.Location = New System.Drawing.Point(130, 80)
        Me.lblSubcategoryValue.Name = "lblSubcategoryValue"
        Me.lblSubcategoryValue.Size = New System.Drawing.Size(15, 19)
        Me.lblSubcategoryValue.TabIndex = 7
        Me.lblSubcategoryValue.Text = "-"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.Location = New System.Drawing.Point(15, 105)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(53, 19)
        Me.lblStatus.TabIndex = 8
        Me.lblStatus.Text = "Status:"
        '
        'lblStatusValue
        '
        Me.lblStatusValue.AutoSize = True
        Me.lblStatusValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblStatusValue.Location = New System.Drawing.Point(130, 105)
        Me.lblStatusValue.Name = "lblStatusValue"
        Me.lblStatusValue.Size = New System.Drawing.Size(15, 19)
        Me.lblStatusValue.TabIndex = 9
        Me.lblStatusValue.Text = "-"
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCondition.Location = New System.Drawing.Point(15, 130)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(78, 19)
        Me.lblCondition.TabIndex = 10
        Me.lblCondition.Text = "Condition:"
        '
        'lblConditionValue
        '
        Me.lblConditionValue.AutoSize = True
        Me.lblConditionValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblConditionValue.Location = New System.Drawing.Point(130, 130)
        Me.lblConditionValue.Name = "lblConditionValue"
        Me.lblConditionValue.Size = New System.Drawing.Size(15, 19)
        Me.lblConditionValue.TabIndex = 11
        Me.lblConditionValue.Text = "-"
        '
        'lblSerial
        '
        Me.lblSerial.AutoSize = True
        Me.lblSerial.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSerial.Location = New System.Drawing.Point(15, 155)
        Me.lblSerial.Name = "lblSerial"
        Me.lblSerial.Size = New System.Drawing.Size(111, 19)
        Me.lblSerial.TabIndex = 12
        Me.lblSerial.Text = "Serial Number:"
        '
        'lblSerialValue
        '
        Me.lblSerialValue.AutoSize = True
        Me.lblSerialValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblSerialValue.Location = New System.Drawing.Point(130, 155)
        Me.lblSerialValue.Name = "lblSerialValue"
        Me.lblSerialValue.Size = New System.Drawing.Size(15, 19)
        Me.lblSerialValue.TabIndex = 13
        Me.lblSerialValue.Text = "-"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblModel.Location = New System.Drawing.Point(15, 180)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(56, 19)
        Me.lblModel.TabIndex = 14
        Me.lblModel.Text = "Model:"
        '
        'lblModelValue
        '
        Me.lblModelValue.AutoSize = True
        Me.lblModelValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblModelValue.Location = New System.Drawing.Point(130, 180)
        Me.lblModelValue.Name = "lblModelValue"
        Me.lblModelValue.Size = New System.Drawing.Size(15, 19)
        Me.lblModelValue.TabIndex = 15
        Me.lblModelValue.Text = "-"
        '
        'lblManufacturer
        '
        Me.lblManufacturer.AutoSize = True
        Me.lblManufacturer.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblManufacturer.Location = New System.Drawing.Point(15, 205)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(104, 19)
        Me.lblManufacturer.TabIndex = 16
        Me.lblManufacturer.Text = "Manufacturer:"
        '
        'lblManufacturerValue
        '
        Me.lblManufacturerValue.AutoSize = True
        Me.lblManufacturerValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblManufacturerValue.Location = New System.Drawing.Point(130, 205)
        Me.lblManufacturerValue.Name = "lblManufacturerValue"
        Me.lblManufacturerValue.Size = New System.Drawing.Size(15, 19)
        Me.lblManufacturerValue.TabIndex = 17
        Me.lblManufacturerValue.Text = "-"
        '
        'lblPurchaseDate
        '
        Me.lblPurchaseDate.AutoSize = True
        Me.lblPurchaseDate.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPurchaseDate.Location = New System.Drawing.Point(15, 230)
        Me.lblPurchaseDate.Name = "lblPurchaseDate"
        Me.lblPurchaseDate.Size = New System.Drawing.Size(108, 19)
        Me.lblPurchaseDate.TabIndex = 18
        Me.lblPurchaseDate.Text = "Purchase Date:"
        '
        'lblPurchaseDateValue
        '
        Me.lblPurchaseDateValue.AutoSize = True
        Me.lblPurchaseDateValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblPurchaseDateValue.Location = New System.Drawing.Point(130, 230)
        Me.lblPurchaseDateValue.Name = "lblPurchaseDateValue"
        Me.lblPurchaseDateValue.Size = New System.Drawing.Size(15, 19)
        Me.lblPurchaseDateValue.TabIndex = 19
        Me.lblPurchaseDateValue.Text = "-"
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepartment.Location = New System.Drawing.Point(15, 255)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(93, 19)
        Me.lblDepartment.TabIndex = 20
        Me.lblDepartment.Text = "Department:"
        '
        'lblDepartmentValue
        '
        Me.lblDepartmentValue.AutoSize = True
        Me.lblDepartmentValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblDepartmentValue.Location = New System.Drawing.Point(130, 255)
        Me.lblDepartmentValue.Name = "lblDepartmentValue"
        Me.lblDepartmentValue.Size = New System.Drawing.Size(15, 19)
        Me.lblDepartmentValue.TabIndex = 21
        Me.lblDepartmentValue.Text = "-"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescription.Location = New System.Drawing.Point(15, 280)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(89, 19)
        Me.lblDescription.TabIndex = 22
        Me.lblDescription.Text = "Description:"
        '
        'lblDescriptionValue
        '
        Me.lblDescriptionValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblDescriptionValue.Location = New System.Drawing.Point(130, 280)
        Me.lblDescriptionValue.Name = "lblDescriptionValue"
        Me.lblDescriptionValue.Size = New System.Drawing.Size(310, 50)
        Me.lblDescriptionValue.TabIndex = 23
        Me.lblDescriptionValue.Text = "-"
        '
        'grpActions
        '
        Me.grpActions.Controls.Add(Me.btnRequestDisposal)
        Me.grpActions.Controls.Add(Me.btnAddMaintenance)
        Me.grpActions.Controls.Add(Me.btnDelete)
        Me.grpActions.Controls.Add(Me.btnEdit)
        Me.grpActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpActions.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpActions.Location = New System.Drawing.Point(0, 340)
        Me.grpActions.Name = "grpActions"
        Me.grpActions.Padding = New System.Windows.Forms.Padding(10)
        Me.grpActions.Size = New System.Drawing.Size(450, 260)
        Me.grpActions.TabIndex = 2
        Me.grpActions.TabStop = False
        Me.grpActions.Text = "⚙️ Actions"
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(8, 69)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(200, 62)
        Me.btnEdit.TabIndex = 0
        Me.btnEdit.Text = "✏️ Edit Asset"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(228, 69)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(200, 62)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "🗑️ Delete Asset"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnAddMaintenance
        '
        Me.btnAddMaintenance.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.btnAddMaintenance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddMaintenance.FlatAppearance.BorderSize = 0
        Me.btnAddMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddMaintenance.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddMaintenance.ForeColor = System.Drawing.Color.White
        Me.btnAddMaintenance.Location = New System.Drawing.Point(8, 136)
        Me.btnAddMaintenance.Name = "btnAddMaintenance"
        Me.btnAddMaintenance.Size = New System.Drawing.Size(200, 62)
        Me.btnAddMaintenance.TabIndex = 2
        Me.btnAddMaintenance.Text = "🔧 Add Maintenance"
        Me.btnAddMaintenance.UseVisualStyleBackColor = False
        '
        'btnRequestDisposal
        '
        Me.btnRequestDisposal.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnRequestDisposal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRequestDisposal.FlatAppearance.BorderSize = 0
        Me.btnRequestDisposal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequestDisposal.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnRequestDisposal.ForeColor = System.Drawing.Color.White
        Me.btnRequestDisposal.Location = New System.Drawing.Point(228, 136)
        Me.btnRequestDisposal.Name = "btnRequestDisposal"
        Me.btnRequestDisposal.Size = New System.Drawing.Size(200, 62)
        Me.btnRequestDisposal.TabIndex = 3
        Me.btnRequestDisposal.Text = "🗑️ Request Disposal"
        Me.btnRequestDisposal.UseVisualStyleBackColor = False
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.grpActions)
        Me.pnlLeft.Controls.Add(Me.grpAssetInfo)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(20, 20)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(450, 600)
        Me.pnlLeft.TabIndex = 0
        '
        'AssetDetailsViewerFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1100, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AssetDetailsViewerFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Asset Details Viewer"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        Me.grpIssuanceHistory.ResumeLayout(False)
        CType(Me.dgvIssuanceHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMaintenanceHistory.ResumeLayout(False)
        CType(Me.dgvMaintenanceHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAssetInfo.ResumeLayout(False)
        Me.grpAssetInfo.PerformLayout()
        Me.grpActions.ResumeLayout(False)
        Me.pnlLeft.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents pnlRight As Panel
    Friend WithEvents grpMaintenanceHistory As GroupBox
    Friend WithEvents dgvMaintenanceHistory As DataGridView
    Friend WithEvents grpIssuanceHistory As GroupBox
    Friend WithEvents dgvIssuanceHistory As DataGridView
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents grpActions As GroupBox
    Friend WithEvents btnRequestDisposal As Button
    Friend WithEvents btnAddMaintenance As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents grpAssetInfo As GroupBox
    Friend WithEvents lblDescriptionValue As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblDepartmentValue As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents lblPurchaseDateValue As Label
    Friend WithEvents lblPurchaseDate As Label
    Friend WithEvents lblManufacturerValue As Label
    Friend WithEvents lblManufacturer As Label
    Friend WithEvents lblModelValue As Label
    Friend WithEvents lblModel As Label
    Friend WithEvents lblSerialValue As Label
    Friend WithEvents lblSerial As Label
    Friend WithEvents lblConditionValue As Label
    Friend WithEvents lblCondition As Label
    Friend WithEvents lblStatusValue As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblSubcategoryValue As Label
    Friend WithEvents lblSubcategory As Label
    Friend WithEvents lblCategoryValue As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblAssetNameValue As Label
    Friend WithEvents lblAssetName As Label
    Friend WithEvents lblAssetTagValue As Label
    Friend WithEvents lblAssetTag As Label
End Class