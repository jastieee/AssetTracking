<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsumableDetailsViewerFrm
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
        Me.grpStockMovement = New System.Windows.Forms.GroupBox()
        Me.dgvStockMovement = New System.Windows.Forms.DataGridView()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.grpActions = New System.Windows.Forms.GroupBox()
        Me.btnPrintLabel = New System.Windows.Forms.Button()
        Me.btnAdjustStock = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.grpStockStatus = New System.Windows.Forms.GroupBox()
        Me.pnlStockIndicator = New System.Windows.Forms.Panel()
        Me.lblStockStatusValue = New System.Windows.Forms.Label()
        Me.lblStockStatus = New System.Windows.Forms.Label()
        Me.lblReorderLevelValue = New System.Windows.Forms.Label()
        Me.lblReorderLevel = New System.Windows.Forms.Label()
        Me.lblMinStockValue = New System.Windows.Forms.Label()
        Me.lblMinStock = New System.Windows.Forms.Label()
        Me.lblCurrentStockValue = New System.Windows.Forms.Label()
        Me.lblCurrentStock = New System.Windows.Forms.Label()
        Me.grpConsumableInfo = New System.Windows.Forms.GroupBox()
        Me.lblDescriptionValue = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblUnitCostValue = New System.Windows.Forms.Label()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.lblUnitMeasureValue = New System.Windows.Forms.Label()
        Me.lblUnitMeasure = New System.Windows.Forms.Label()
        Me.lblSubcategoryValue = New System.Windows.Forms.Label()
        Me.lblSubcategory = New System.Windows.Forms.Label()
        Me.lblCategoryValue = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblConsumableNameValue = New System.Windows.Forms.Label()
        Me.lblConsumableName = New System.Windows.Forms.Label()
        Me.lblConsumableCodeValue = New System.Windows.Forms.Label()
        Me.lblConsumableCode = New System.Windows.Forms.Label()
        Me.pnlTop.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.grpIssuanceHistory.SuspendLayout()
        CType(Me.dgvIssuanceHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStockMovement.SuspendLayout()
        CType(Me.dgvStockMovement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeft.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.grpStockStatus.SuspendLayout()
        Me.grpConsumableInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
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
        Me.lblTitle.Size = New System.Drawing.Size(268, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "📦 Consumable Details"
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
        Me.pnlRight.Controls.Add(Me.grpStockMovement)
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
        'grpStockMovement
        '
        Me.grpStockMovement.Controls.Add(Me.dgvStockMovement)
        Me.grpStockMovement.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpStockMovement.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpStockMovement.Location = New System.Drawing.Point(0, 300)
        Me.grpStockMovement.Name = "grpStockMovement"
        Me.grpStockMovement.Padding = New System.Windows.Forms.Padding(10)
        Me.grpStockMovement.Size = New System.Drawing.Size(610, 300)
        Me.grpStockMovement.TabIndex = 0
        Me.grpStockMovement.TabStop = False
        Me.grpStockMovement.Text = "📊 Stock Movement / Request History"
        '
        'dgvStockMovement
        '
        Me.dgvStockMovement.AllowUserToAddRows = False
        Me.dgvStockMovement.AllowUserToDeleteRows = False
        Me.dgvStockMovement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStockMovement.BackgroundColor = System.Drawing.Color.White
        Me.dgvStockMovement.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvStockMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStockMovement.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStockMovement.Location = New System.Drawing.Point(10, 30)
        Me.dgvStockMovement.Name = "dgvStockMovement"
        Me.dgvStockMovement.ReadOnly = True
        Me.dgvStockMovement.RowHeadersVisible = False
        Me.dgvStockMovement.RowHeadersWidth = 51
        Me.dgvStockMovement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStockMovement.Size = New System.Drawing.Size(590, 260)
        Me.dgvStockMovement.TabIndex = 0
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.grpActions)
        Me.pnlLeft.Controls.Add(Me.grpStockStatus)
        Me.pnlLeft.Controls.Add(Me.grpConsumableInfo)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(20, 20)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(450, 600)
        Me.pnlLeft.TabIndex = 0
        '
        'grpActions
        '
        Me.grpActions.Controls.Add(Me.btnPrintLabel)
        Me.grpActions.Controls.Add(Me.btnAdjustStock)
        Me.grpActions.Controls.Add(Me.btnDelete)
        Me.grpActions.Controls.Add(Me.btnEdit)
        Me.grpActions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpActions.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpActions.Location = New System.Drawing.Point(0, 470)
        Me.grpActions.Name = "grpActions"
        Me.grpActions.Padding = New System.Windows.Forms.Padding(10)
        Me.grpActions.Size = New System.Drawing.Size(450, 130)
        Me.grpActions.TabIndex = 2
        Me.grpActions.TabStop = False
        Me.grpActions.Text = "⚙️ Actions"
        '
        'btnPrintLabel
        '
        Me.btnPrintLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btnPrintLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrintLabel.FlatAppearance.BorderSize = 0
        Me.btnPrintLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintLabel.ForeColor = System.Drawing.Color.White
        Me.btnPrintLabel.Location = New System.Drawing.Point(230, 70)
        Me.btnPrintLabel.Name = "btnPrintLabel"
        Me.btnPrintLabel.Size = New System.Drawing.Size(200, 40)
        Me.btnPrintLabel.TabIndex = 3
        Me.btnPrintLabel.Text = "🖨️ Print Label"
        Me.btnPrintLabel.UseVisualStyleBackColor = False
        '
        'btnAdjustStock
        '
        Me.btnAdjustStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.btnAdjustStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdjustStock.FlatAppearance.BorderSize = 0
        Me.btnAdjustStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdjustStock.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdjustStock.ForeColor = System.Drawing.Color.White
        Me.btnAdjustStock.Location = New System.Drawing.Point(20, 70)
        Me.btnAdjustStock.Name = "btnAdjustStock"
        Me.btnAdjustStock.Size = New System.Drawing.Size(200, 40)
        Me.btnAdjustStock.TabIndex = 2
        Me.btnAdjustStock.Text = "📊 Adjust Stock"
        Me.btnAdjustStock.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(230, 25)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(200, 40)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "🗑️ Delete Consumable"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(20, 25)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(200, 40)
        Me.btnEdit.TabIndex = 0
        Me.btnEdit.Text = "✏️ Edit Consumable"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'grpStockStatus
        '
        Me.grpStockStatus.Controls.Add(Me.pnlStockIndicator)
        Me.grpStockStatus.Controls.Add(Me.lblStockStatusValue)
        Me.grpStockStatus.Controls.Add(Me.lblStockStatus)
        Me.grpStockStatus.Controls.Add(Me.lblReorderLevelValue)
        Me.grpStockStatus.Controls.Add(Me.lblReorderLevel)
        Me.grpStockStatus.Controls.Add(Me.lblMinStockValue)
        Me.grpStockStatus.Controls.Add(Me.lblMinStock)
        Me.grpStockStatus.Controls.Add(Me.lblCurrentStockValue)
        Me.grpStockStatus.Controls.Add(Me.lblCurrentStock)
        Me.grpStockStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpStockStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpStockStatus.Location = New System.Drawing.Point(0, 310)
        Me.grpStockStatus.Name = "grpStockStatus"
        Me.grpStockStatus.Padding = New System.Windows.Forms.Padding(10)
        Me.grpStockStatus.Size = New System.Drawing.Size(450, 160)
        Me.grpStockStatus.TabIndex = 1
        Me.grpStockStatus.TabStop = False
        Me.grpStockStatus.Text = "📊 Stock Status"
        '
        'pnlStockIndicator
        '
        Me.pnlStockIndicator.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.pnlStockIndicator.Location = New System.Drawing.Point(180, 120)
        Me.pnlStockIndicator.Name = "pnlStockIndicator"
        Me.pnlStockIndicator.Size = New System.Drawing.Size(250, 25)
        Me.pnlStockIndicator.TabIndex = 8
        '
        'lblStockStatusValue
        '
        Me.lblStockStatusValue.AutoSize = True
        Me.lblStockStatusValue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockStatusValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblStockStatusValue.Location = New System.Drawing.Point(180, 95)
        Me.lblStockStatusValue.Name = "lblStockStatusValue"
        Me.lblStockStatusValue.Size = New System.Drawing.Size(86, 20)
        Me.lblStockStatusValue.TabIndex = 7
        Me.lblStockStatusValue.Text = "✓ Sufficient"
        '
        'lblStockStatus
        '
        Me.lblStockStatus.AutoSize = True
        Me.lblStockStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockStatus.Location = New System.Drawing.Point(20, 95)
        Me.lblStockStatus.Name = "lblStockStatus"
        Me.lblStockStatus.Size = New System.Drawing.Size(103, 20)
        Me.lblStockStatus.TabIndex = 6
        Me.lblStockStatus.Text = "Stock Status:"
        '
        'lblReorderLevelValue
        '
        Me.lblReorderLevelValue.AutoSize = True
        Me.lblReorderLevelValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReorderLevelValue.Location = New System.Drawing.Point(180, 70)
        Me.lblReorderLevelValue.Name = "lblReorderLevelValue"
        Me.lblReorderLevelValue.Size = New System.Drawing.Size(17, 20)
        Me.lblReorderLevelValue.TabIndex = 5
        Me.lblReorderLevelValue.Text = "-"
        '
        'lblReorderLevel
        '
        Me.lblReorderLevel.AutoSize = True
        Me.lblReorderLevel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblReorderLevel.Location = New System.Drawing.Point(20, 70)
        Me.lblReorderLevel.Name = "lblReorderLevel"
        Me.lblReorderLevel.Size = New System.Drawing.Size(112, 20)
        Me.lblReorderLevel.TabIndex = 4
        Me.lblReorderLevel.Text = "Reorder Level:"
        '
        'lblMinStockValue
        '
        Me.lblMinStockValue.AutoSize = True
        Me.lblMinStockValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMinStockValue.Location = New System.Drawing.Point(180, 45)
        Me.lblMinStockValue.Name = "lblMinStockValue"
        Me.lblMinStockValue.Size = New System.Drawing.Size(17, 20)
        Me.lblMinStockValue.TabIndex = 3
        Me.lblMinStockValue.Text = "-"
        '
        'lblMinStock
        '
        Me.lblMinStock.AutoSize = True
        Me.lblMinStock.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblMinStock.Location = New System.Drawing.Point(20, 45)
        Me.lblMinStock.Name = "lblMinStock"
        Me.lblMinStock.Size = New System.Drawing.Size(127, 20)
        Me.lblMinStock.TabIndex = 2
        Me.lblMinStock.Text = "Minimum Stock:"
        '
        'lblCurrentStockValue
        '
        Me.lblCurrentStockValue.AutoSize = True
        Me.lblCurrentStockValue.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentStockValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.lblCurrentStockValue.Location = New System.Drawing.Point(180, 20)
        Me.lblCurrentStockValue.Name = "lblCurrentStockValue"
        Me.lblCurrentStockValue.Size = New System.Drawing.Size(19, 25)
        Me.lblCurrentStockValue.TabIndex = 1
        Me.lblCurrentStockValue.Text = "-"
        '
        'lblCurrentStock
        '
        Me.lblCurrentStock.AutoSize = True
        Me.lblCurrentStock.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentStock.Location = New System.Drawing.Point(20, 20)
        Me.lblCurrentStock.Name = "lblCurrentStock"
        Me.lblCurrentStock.Size = New System.Drawing.Size(114, 20)
        Me.lblCurrentStock.TabIndex = 0
        Me.lblCurrentStock.Text = "Current Stock:"
        '
        'grpConsumableInfo
        '
        Me.grpConsumableInfo.Controls.Add(Me.lblDescriptionValue)
        Me.grpConsumableInfo.Controls.Add(Me.lblDescription)
        Me.grpConsumableInfo.Controls.Add(Me.lblUnitCostValue)
        Me.grpConsumableInfo.Controls.Add(Me.lblUnitCost)
        Me.grpConsumableInfo.Controls.Add(Me.lblUnitMeasureValue)
        Me.grpConsumableInfo.Controls.Add(Me.lblUnitMeasure)
        Me.grpConsumableInfo.Controls.Add(Me.lblSubcategoryValue)
        Me.grpConsumableInfo.Controls.Add(Me.lblSubcategory)
        Me.grpConsumableInfo.Controls.Add(Me.lblCategoryValue)
        Me.grpConsumableInfo.Controls.Add(Me.lblCategory)
        Me.grpConsumableInfo.Controls.Add(Me.lblConsumableNameValue)
        Me.grpConsumableInfo.Controls.Add(Me.lblConsumableName)
        Me.grpConsumableInfo.Controls.Add(Me.lblConsumableCodeValue)
        Me.grpConsumableInfo.Controls.Add(Me.lblConsumableCode)
        Me.grpConsumableInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpConsumableInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpConsumableInfo.Location = New System.Drawing.Point(0, 0)
        Me.grpConsumableInfo.Name = "grpConsumableInfo"
        Me.grpConsumableInfo.Padding = New System.Windows.Forms.Padding(10)
        Me.grpConsumableInfo.Size = New System.Drawing.Size(450, 310)
        Me.grpConsumableInfo.TabIndex = 0
        Me.grpConsumableInfo.TabStop = False
        Me.grpConsumableInfo.Text = "ℹ️ Consumable Information"
        '
        'lblDescriptionValue
        '
        Me.lblDescriptionValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescriptionValue.Location = New System.Drawing.Point(180, 220)
        Me.lblDescriptionValue.Name = "lblDescriptionValue"
        Me.lblDescriptionValue.Size = New System.Drawing.Size(250, 75)
        Me.lblDescriptionValue.TabIndex = 13
        Me.lblDescriptionValue.Text = "-"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDescription.Location = New System.Drawing.Point(20, 220)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(97, 20)
        Me.lblDescription.TabIndex = 12
        Me.lblDescription.Text = "Description:"
        '
        'lblUnitCostValue
        '
        Me.lblUnitCostValue.AutoSize = True
        Me.lblUnitCostValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnitCostValue.Location = New System.Drawing.Point(180, 190)
        Me.lblUnitCostValue.Name = "lblUnitCostValue"
        Me.lblUnitCostValue.Size = New System.Drawing.Size(17, 20)
        Me.lblUnitCostValue.TabIndex = 11
        Me.lblUnitCostValue.Text = "-"
        '
        'lblUnitCost
        '
        Me.lblUnitCost.AutoSize = True
        Me.lblUnitCost.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnitCost.Location = New System.Drawing.Point(20, 190)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(81, 20)
        Me.lblUnitCost.TabIndex = 10
        Me.lblUnitCost.Text = "Unit Cost:"
        '
        'lblUnitMeasureValue
        '
        Me.lblUnitMeasureValue.AutoSize = True
        Me.lblUnitMeasureValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnitMeasureValue.Location = New System.Drawing.Point(180, 160)
        Me.lblUnitMeasureValue.Name = "lblUnitMeasureValue"
        Me.lblUnitMeasureValue.Size = New System.Drawing.Size(17, 20)
        Me.lblUnitMeasureValue.TabIndex = 9
        Me.lblUnitMeasureValue.Text = "-"
        '
        'lblUnitMeasure
        '
        Me.lblUnitMeasure.AutoSize = True
        Me.lblUnitMeasure.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUnitMeasure.Location = New System.Drawing.Point(20, 160)
        Me.lblUnitMeasure.Name = "lblUnitMeasure"
        Me.lblUnitMeasure.Size = New System.Drawing.Size(135, 20)
        Me.lblUnitMeasure.TabIndex = 8
        Me.lblUnitMeasure.Text = "Unit of Measure:"
        '
        'lblSubcategoryValue
        '
        Me.lblSubcategoryValue.AutoSize = True
        Me.lblSubcategoryValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubcategoryValue.Location = New System.Drawing.Point(180, 130)
        Me.lblSubcategoryValue.Name = "lblSubcategoryValue"
        Me.lblSubcategoryValue.Size = New System.Drawing.Size(17, 20)
        Me.lblSubcategoryValue.TabIndex = 7
        Me.lblSubcategoryValue.Text = "-"
        '
        'lblSubcategory
        '
        Me.lblSubcategory.AutoSize = True
        Me.lblSubcategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSubcategory.Location = New System.Drawing.Point(20, 130)
        Me.lblSubcategory.Name = "lblSubcategory"
        Me.lblSubcategory.Size = New System.Drawing.Size(107, 20)
        Me.lblSubcategory.TabIndex = 6
        Me.lblSubcategory.Text = "Subcategory:"
        '
        'lblCategoryValue
        '
        Me.lblCategoryValue.AutoSize = True
        Me.lblCategoryValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategoryValue.Location = New System.Drawing.Point(180, 100)
        Me.lblCategoryValue.Name = "lblCategoryValue"
        Me.lblCategoryValue.Size = New System.Drawing.Size(17, 20)
        Me.lblCategoryValue.TabIndex = 5
        Me.lblCategoryValue.Text = "-"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCategory.Location = New System.Drawing.Point(20, 100)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(81, 20)
        Me.lblCategory.TabIndex = 4
        Me.lblCategory.Text = "Category:"
        '
        'lblConsumableNameValue
        '
        Me.lblConsumableNameValue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsumableNameValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.lblConsumableNameValue.Location = New System.Drawing.Point(20, 60)
        Me.lblConsumableNameValue.Name = "lblConsumableNameValue"
        Me.lblConsumableNameValue.Size = New System.Drawing.Size(410, 25)
        Me.lblConsumableNameValue.TabIndex = 3
        Me.lblConsumableNameValue.Text = "-"
        '
        'lblConsumableName
        '
        Me.lblConsumableName.AutoSize = True
        Me.lblConsumableName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsumableName.Location = New System.Drawing.Point(20, 35)
        Me.lblConsumableName.Name = "lblConsumableName"
        Me.lblConsumableName.Size = New System.Drawing.Size(149, 20)
        Me.lblConsumableName.TabIndex = 2
        Me.lblConsumableName.Text = "Consumable Name:"
        '
        'lblConsumableCodeValue
        '
        Me.lblConsumableCodeValue.AutoSize = True
        Me.lblConsumableCodeValue.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsumableCodeValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblConsumableCodeValue.Location = New System.Drawing.Point(300, 30)
        Me.lblConsumableCodeValue.Name = "lblConsumableCodeValue"
        Me.lblConsumableCodeValue.Size = New System.Drawing.Size(19, 25)
        Me.lblConsumableCodeValue.TabIndex = 1
        Me.lblConsumableCodeValue.Text = "-"
        '
        'lblConsumableCode
        '
        Me.lblConsumableCode.AutoSize = True
        Me.lblConsumableCode.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsumableCode.Location = New System.Drawing.Point(300, 10)
        Me.lblConsumableCode.Name = "lblConsumableCode"
        Me.lblConsumableCode.Size = New System.Drawing.Size(132, 19)
        Me.lblConsumableCode.TabIndex = 0
        Me.lblConsumableCode.Text = "Consumable Code:"
        '
        'ConsumableDetailsViewerFrm
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
        Me.Name = "ConsumableDetailsViewerFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consumable Details Viewer"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        Me.grpIssuanceHistory.ResumeLayout(False)
        CType(Me.dgvIssuanceHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStockMovement.ResumeLayout(False)
        CType(Me.dgvStockMovement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeft.ResumeLayout(False)
        Me.grpActions.ResumeLayout(False)
        Me.grpStockStatus.ResumeLayout(False)
        Me.grpStockStatus.PerformLayout()
        Me.grpConsumableInfo.ResumeLayout(False)
        Me.grpConsumableInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents grpConsumableInfo As GroupBox
    Friend WithEvents lblConsumableCode As Label
    Friend WithEvents lblConsumableCodeValue As Label
    Friend WithEvents lblConsumableName As Label
    Friend WithEvents lblConsumableNameValue As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblCategoryValue As Label
    Friend WithEvents lblSubcategory As Label
    Friend WithEvents lblSubcategoryValue As Label
    Friend WithEvents lblUnitMeasure As Label
    Friend WithEvents lblUnitMeasureValue As Label
    Friend WithEvents lblUnitCost As Label
    Friend WithEvents lblUnitCostValue As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblDescriptionValue As Label
    Friend WithEvents grpStockStatus As GroupBox
    Friend WithEvents lblCurrentStock As Label
    Friend WithEvents lblCurrentStockValue As Label
    Friend WithEvents lblMinStock As Label
    Friend WithEvents lblMinStockValue As Label
    Friend WithEvents lblReorderLevel As Label
    Friend WithEvents lblReorderLevelValue As Label
    Friend WithEvents lblStockStatus As Label
    Friend WithEvents lblStockStatusValue As Label
    Friend WithEvents pnlStockIndicator As Panel
    Friend WithEvents grpActions As GroupBox
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAdjustStock As Button
    Friend WithEvents btnPrintLabel As Button
    Friend WithEvents pnlRight As Panel
    Friend WithEvents grpStockMovement As GroupBox
    Friend WithEvents dgvStockMovement As DataGridView
    Friend WithEvents grpIssuanceHistory As GroupBox
    Friend WithEvents dgvIssuanceHistory As DataGridView
End Class