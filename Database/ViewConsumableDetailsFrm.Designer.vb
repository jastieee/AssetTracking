<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewConsumableDetailsFrm
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.grpStockInfo = New System.Windows.Forms.GroupBox()
        Me.lblStockStatusValue = New System.Windows.Forms.Label()
        Me.lblStockStatus = New System.Windows.Forms.Label()
        Me.lblReorderLevelValue = New System.Windows.Forms.Label()
        Me.lblReorderLevel = New System.Windows.Forms.Label()
        Me.lblMinStockValue = New System.Windows.Forms.Label()
        Me.lblMinStock = New System.Windows.Forms.Label()
        Me.lblCurrentStockValue = New System.Windows.Forms.Label()
        Me.lblCurrentStock = New System.Windows.Forms.Label()
        Me.lblUnitCostValue = New System.Windows.Forms.Label()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.lblUnitMeasureValue = New System.Windows.Forms.Label()
        Me.lblUnitMeasure = New System.Windows.Forms.Label()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblSubcategoryValue = New System.Windows.Forms.Label()
        Me.lblSubcategory = New System.Windows.Forms.Label()
        Me.lblCategoryValue = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblConsumableNameValue = New System.Windows.Forms.Label()
        Me.lblConsumableName = New System.Windows.Forms.Label()
        Me.lblConsumableCodeValue = New System.Windows.Forms.Label()
        Me.lblConsumableCode = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.pnlTop.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.grpStockInfo.SuspendLayout()
        Me.grpDetails.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(700, 60)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(284, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "📋 Consumable Details"
        '
        'pnlContent
        '
        Me.pnlContent.AutoScroll = True
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.grpStockInfo)
        Me.pnlContent.Controls.Add(Me.grpDetails)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 60)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(700, 560)
        Me.pnlContent.TabIndex = 1
        '
        'grpStockInfo
        '
        Me.grpStockInfo.BackColor = System.Drawing.Color.White
        Me.grpStockInfo.Controls.Add(Me.lblStockStatusValue)
        Me.grpStockInfo.Controls.Add(Me.lblStockStatus)
        Me.grpStockInfo.Controls.Add(Me.lblReorderLevelValue)
        Me.grpStockInfo.Controls.Add(Me.lblReorderLevel)
        Me.grpStockInfo.Controls.Add(Me.lblMinStockValue)
        Me.grpStockInfo.Controls.Add(Me.lblMinStock)
        Me.grpStockInfo.Controls.Add(Me.lblCurrentStockValue)
        Me.grpStockInfo.Controls.Add(Me.lblCurrentStock)
        Me.grpStockInfo.Controls.Add(Me.lblUnitCostValue)
        Me.grpStockInfo.Controls.Add(Me.lblUnitCost)
        Me.grpStockInfo.Controls.Add(Me.lblUnitMeasureValue)
        Me.grpStockInfo.Controls.Add(Me.lblUnitMeasure)
        Me.grpStockInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpStockInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpStockInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grpStockInfo.Location = New System.Drawing.Point(20, 310)
        Me.grpStockInfo.Name = "grpStockInfo"
        Me.grpStockInfo.Padding = New System.Windows.Forms.Padding(15)
        Me.grpStockInfo.Size = New System.Drawing.Size(660, 270)
        Me.grpStockInfo.TabIndex = 1
        Me.grpStockInfo.TabStop = False
        Me.grpStockInfo.Text = "📊 Stock Information"
        '
        'lblStockStatusValue
        '
        Me.lblStockStatusValue.AutoSize = True
        Me.lblStockStatusValue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblStockStatusValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblStockStatusValue.Location = New System.Drawing.Point(220, 225)
        Me.lblStockStatusValue.Name = "lblStockStatusValue"
        Me.lblStockStatusValue.Size = New System.Drawing.Size(92, 23)
        Me.lblStockStatusValue.TabIndex = 11
        Me.lblStockStatusValue.Text = "Sufficient"
        '
        'lblStockStatus
        '
        Me.lblStockStatus.AutoSize = True
        Me.lblStockStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStockStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblStockStatus.Location = New System.Drawing.Point(20, 225)
        Me.lblStockStatus.Name = "lblStockStatus"
        Me.lblStockStatus.Size = New System.Drawing.Size(97, 20)
        Me.lblStockStatus.TabIndex = 10
        Me.lblStockStatus.Text = "Stock Status:"
        '
        'lblReorderLevelValue
        '
        Me.lblReorderLevelValue.AutoSize = True
        Me.lblReorderLevelValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReorderLevelValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblReorderLevelValue.Location = New System.Drawing.Point(220, 190)
        Me.lblReorderLevelValue.Name = "lblReorderLevelValue"
        Me.lblReorderLevelValue.Size = New System.Drawing.Size(17, 20)
        Me.lblReorderLevelValue.TabIndex = 9
        Me.lblReorderLevelValue.Text = "0"
        '
        'lblReorderLevel
        '
        Me.lblReorderLevel.AutoSize = True
        Me.lblReorderLevel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReorderLevel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblReorderLevel.Location = New System.Drawing.Point(20, 190)
        Me.lblReorderLevel.Name = "lblReorderLevel"
        Me.lblReorderLevel.Size = New System.Drawing.Size(105, 20)
        Me.lblReorderLevel.TabIndex = 8
        Me.lblReorderLevel.Text = "Reorder Level:"
        '
        'lblMinStockValue
        '
        Me.lblMinStockValue.AutoSize = True
        Me.lblMinStockValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMinStockValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblMinStockValue.Location = New System.Drawing.Point(220, 155)
        Me.lblMinStockValue.Name = "lblMinStockValue"
        Me.lblMinStockValue.Size = New System.Drawing.Size(17, 20)
        Me.lblMinStockValue.TabIndex = 7
        Me.lblMinStockValue.Text = "0"
        '
        'lblMinStock
        '
        Me.lblMinStock.AutoSize = True
        Me.lblMinStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMinStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblMinStock.Location = New System.Drawing.Point(20, 155)
        Me.lblMinStock.Name = "lblMinStock"
        Me.lblMinStock.Size = New System.Drawing.Size(148, 20)
        Me.lblMinStock.TabIndex = 6
        Me.lblMinStock.Text = "Minimum Stock Level:"
        '
        'lblCurrentStockValue
        '
        Me.lblCurrentStockValue.AutoSize = True
        Me.lblCurrentStockValue.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentStockValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblCurrentStockValue.Location = New System.Drawing.Point(220, 115)
        Me.lblCurrentStockValue.Name = "lblCurrentStockValue"
        Me.lblCurrentStockValue.Size = New System.Drawing.Size(22, 25)
        Me.lblCurrentStockValue.TabIndex = 5
        Me.lblCurrentStockValue.Text = "0"
        '
        'lblCurrentStock
        '
        Me.lblCurrentStock.AutoSize = True
        Me.lblCurrentStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCurrentStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblCurrentStock.Location = New System.Drawing.Point(20, 120)
        Me.lblCurrentStock.Name = "lblCurrentStock"
        Me.lblCurrentStock.Size = New System.Drawing.Size(106, 20)
        Me.lblCurrentStock.TabIndex = 4
        Me.lblCurrentStock.Text = "Current Stock:"
        '
        'lblUnitCostValue
        '
        Me.lblUnitCostValue.AutoSize = True
        Me.lblUnitCostValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnitCostValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblUnitCostValue.Location = New System.Drawing.Point(220, 75)
        Me.lblUnitCostValue.Name = "lblUnitCostValue"
        Me.lblUnitCostValue.Size = New System.Drawing.Size(45, 20)
        Me.lblUnitCostValue.TabIndex = 3
        Me.lblUnitCostValue.Text = "₱0.00"
        '
        'lblUnitCost
        '
        Me.lblUnitCost.AutoSize = True
        Me.lblUnitCost.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnitCost.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblUnitCost.Location = New System.Drawing.Point(20, 75)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(74, 20)
        Me.lblUnitCost.TabIndex = 2
        Me.lblUnitCost.Text = "Unit Cost:"
        '
        'lblUnitMeasureValue
        '
        Me.lblUnitMeasureValue.AutoSize = True
        Me.lblUnitMeasureValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnitMeasureValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblUnitMeasureValue.Location = New System.Drawing.Point(220, 40)
        Me.lblUnitMeasureValue.Name = "lblUnitMeasureValue"
        Me.lblUnitMeasureValue.Size = New System.Drawing.Size(24, 20)
        Me.lblUnitMeasureValue.TabIndex = 1
        Me.lblUnitMeasureValue.Text = "--"
        '
        'lblUnitMeasure
        '
        Me.lblUnitMeasure.AutoSize = True
        Me.lblUnitMeasure.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnitMeasure.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblUnitMeasure.Location = New System.Drawing.Point(20, 40)
        Me.lblUnitMeasure.Name = "lblUnitMeasure"
        Me.lblUnitMeasure.Size = New System.Drawing.Size(122, 20)
        Me.lblUnitMeasure.TabIndex = 0
        Me.lblUnitMeasure.Text = "Unit of Measure:"
        '
        'grpDetails
        '
        Me.grpDetails.BackColor = System.Drawing.Color.White
        Me.grpDetails.Controls.Add(Me.txtDescription)
        Me.grpDetails.Controls.Add(Me.lblDescription)
        Me.grpDetails.Controls.Add(Me.lblSubcategoryValue)
        Me.grpDetails.Controls.Add(Me.lblSubcategory)
        Me.grpDetails.Controls.Add(Me.lblCategoryValue)
        Me.grpDetails.Controls.Add(Me.lblCategory)
        Me.grpDetails.Controls.Add(Me.lblConsumableNameValue)
        Me.grpDetails.Controls.Add(Me.lblConsumableName)
        Me.grpDetails.Controls.Add(Me.lblConsumableCodeValue)
        Me.grpDetails.Controls.Add(Me.lblConsumableCode)
        Me.grpDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grpDetails.Location = New System.Drawing.Point(20, 20)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Padding = New System.Windows.Forms.Padding(15)
        Me.grpDetails.Size = New System.Drawing.Size(660, 290)
        Me.grpDetails.TabIndex = 0
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "📝 Basic Information"
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescription.Location = New System.Drawing.Point(20, 200)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(620, 70)
        Me.txtDescription.TabIndex = 9
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblDescription.Location = New System.Drawing.Point(20, 175)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(88, 20)
        Me.lblDescription.TabIndex = 8
        Me.lblDescription.Text = "Description:"
        '
        'lblSubcategoryValue
        '
        Me.lblSubcategoryValue.AutoSize = True
        Me.lblSubcategoryValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubcategoryValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblSubcategoryValue.Location = New System.Drawing.Point(220, 145)
        Me.lblSubcategoryValue.Name = "lblSubcategoryValue"
        Me.lblSubcategoryValue.Size = New System.Drawing.Size(24, 20)
        Me.lblSubcategoryValue.TabIndex = 7
        Me.lblSubcategoryValue.Text = "--"
        '
        'lblSubcategory
        '
        Me.lblSubcategory.AutoSize = True
        Me.lblSubcategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubcategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblSubcategory.Location = New System.Drawing.Point(20, 145)
        Me.lblSubcategory.Name = "lblSubcategory"
        Me.lblSubcategory.Size = New System.Drawing.Size(95, 20)
        Me.lblSubcategory.TabIndex = 6
        Me.lblSubcategory.Text = "Subcategory:"
        '
        'lblCategoryValue
        '
        Me.lblCategoryValue.AutoSize = True
        Me.lblCategoryValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategoryValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblCategoryValue.Location = New System.Drawing.Point(220, 110)
        Me.lblCategoryValue.Name = "lblCategoryValue"
        Me.lblCategoryValue.Size = New System.Drawing.Size(24, 20)
        Me.lblCategoryValue.TabIndex = 5
        Me.lblCategoryValue.Text = "--"
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblCategory.Location = New System.Drawing.Point(20, 110)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(72, 20)
        Me.lblCategory.TabIndex = 4
        Me.lblCategory.Text = "Category:"
        '
        'lblConsumableNameValue
        '
        Me.lblConsumableNameValue.AutoSize = True
        Me.lblConsumableNameValue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsumableNameValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblConsumableNameValue.Location = New System.Drawing.Point(220, 70)
        Me.lblConsumableNameValue.Name = "lblConsumableNameValue"
        Me.lblConsumableNameValue.Size = New System.Drawing.Size(27, 23)
        Me.lblConsumableNameValue.TabIndex = 3
        Me.lblConsumableNameValue.Text = "--"
        '
        'lblConsumableName
        '
        Me.lblConsumableName.AutoSize = True
        Me.lblConsumableName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblConsumableName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblConsumableName.Location = New System.Drawing.Point(20, 75)
        Me.lblConsumableName.Name = "lblConsumableName"
        Me.lblConsumableName.Size = New System.Drawing.Size(141, 20)
        Me.lblConsumableName.TabIndex = 2
        Me.lblConsumableName.Text = "Consumable Name:"
        '
        'lblConsumableCodeValue
        '
        Me.lblConsumableCodeValue.AutoSize = True
        Me.lblConsumableCodeValue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsumableCodeValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblConsumableCodeValue.Location = New System.Drawing.Point(220, 35)
        Me.lblConsumableCodeValue.Name = "lblConsumableCodeValue"
        Me.lblConsumableCodeValue.Size = New System.Drawing.Size(27, 23)
        Me.lblConsumableCodeValue.TabIndex = 1
        Me.lblConsumableCodeValue.Text = "--"
        '
        'lblConsumableCode
        '
        Me.lblConsumableCode.AutoSize = True
        Me.lblConsumableCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblConsumableCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblConsumableCode.Location = New System.Drawing.Point(20, 40)
        Me.lblConsumableCode.Name = "lblConsumableCode"
        Me.lblConsumableCode.Size = New System.Drawing.Size(138, 20)
        Me.lblConsumableCode.TabIndex = 0
        Me.lblConsumableCode.Text = "Consumable Code:"
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.Controls.Add(Me.btnDelete)
        Me.pnlBottom.Controls.Add(Me.btnEdit)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 620)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlBottom.Size = New System.Drawing.Size(700, 60)
        Me.pnlBottom.TabIndex = 2
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(480, 10)
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
        Me.btnEdit.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(20, 10)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(200, 40)
        Me.btnEdit.TabIndex = 0
        Me.btnEdit.Text = "✏️ Edit Consumable"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'ViewConsumableDetailsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 680)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewConsumableDetailsFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "View Consumable Details"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.grpStockInfo.ResumeLayout(False)
        Me.grpStockInfo.PerformLayout()
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents grpDetails As GroupBox
    Friend WithEvents lblConsumableCode As Label
    Friend WithEvents lblConsumableCodeValue As Label
    Friend WithEvents lblConsumableName As Label
    Friend WithEvents lblConsumableNameValue As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblCategoryValue As Label
    Friend WithEvents lblSubcategory As Label
    Friend WithEvents lblSubcategoryValue As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents grpStockInfo As GroupBox
    Friend WithEvents lblUnitMeasure As Label
    Friend WithEvents lblUnitMeasureValue As Label
    Friend WithEvents lblUnitCost As Label
    Friend WithEvents lblUnitCostValue As Label
    Friend WithEvents lblCurrentStock As Label
    Friend WithEvents lblCurrentStockValue As Label
    Friend WithEvents lblMinStock As Label
    Friend WithEvents lblMinStockValue As Label
    Friend WithEvents lblReorderLevel As Label
    Friend WithEvents lblReorderLevelValue As Label
    Friend WithEvents lblStockStatus As Label
    Friend WithEvents lblStockStatusValue As Label
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
End Class