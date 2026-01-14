<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddEditConsumableFrm
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
        Me.grpConsumableDetails = New System.Windows.Forms.GroupBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.nudReorderLevel = New System.Windows.Forms.NumericUpDown()
        Me.lblReorderLevel = New System.Windows.Forms.Label()
        Me.nudMinStock = New System.Windows.Forms.NumericUpDown()
        Me.lblMinStock = New System.Windows.Forms.Label()
        Me.txtUnitCost = New System.Windows.Forms.TextBox()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.nudInitialStock = New System.Windows.Forms.NumericUpDown()
        Me.lblInitialStock = New System.Windows.Forms.Label()
        Me.txtUnitMeasure = New System.Windows.Forms.TextBox()
        Me.lblUnitMeasure = New System.Windows.Forms.Label()
        Me.cboSubcategory = New System.Windows.Forms.ComboBox()
        Me.lblSubcategory = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.txtConsumableName = New System.Windows.Forms.TextBox()
        Me.lblConsumableName = New System.Windows.Forms.Label()
        Me.txtConsumableCode = New System.Windows.Forms.TextBox()
        Me.lblConsumableCode = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlTop.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.grpConsumableDetails.SuspendLayout()
        CType(Me.nudReorderLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudInitialStock, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(242, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "➕ Add Consumable"
        '
        'pnlContent
        '
        Me.pnlContent.AutoScroll = True
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.grpConsumableDetails)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 60)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(700, 590)
        Me.pnlContent.TabIndex = 1
        '
        'grpConsumableDetails
        '
        Me.grpConsumableDetails.BackColor = System.Drawing.Color.White
        Me.grpConsumableDetails.Controls.Add(Me.txtDescription)
        Me.grpConsumableDetails.Controls.Add(Me.lblDescription)
        Me.grpConsumableDetails.Controls.Add(Me.nudReorderLevel)
        Me.grpConsumableDetails.Controls.Add(Me.lblReorderLevel)
        Me.grpConsumableDetails.Controls.Add(Me.nudMinStock)
        Me.grpConsumableDetails.Controls.Add(Me.lblMinStock)
        Me.grpConsumableDetails.Controls.Add(Me.txtUnitCost)
        Me.grpConsumableDetails.Controls.Add(Me.lblUnitCost)
        Me.grpConsumableDetails.Controls.Add(Me.nudInitialStock)
        Me.grpConsumableDetails.Controls.Add(Me.lblInitialStock)
        Me.grpConsumableDetails.Controls.Add(Me.txtUnitMeasure)
        Me.grpConsumableDetails.Controls.Add(Me.lblUnitMeasure)
        Me.grpConsumableDetails.Controls.Add(Me.cboSubcategory)
        Me.grpConsumableDetails.Controls.Add(Me.lblSubcategory)
        Me.grpConsumableDetails.Controls.Add(Me.cboCategory)
        Me.grpConsumableDetails.Controls.Add(Me.lblCategory)
        Me.grpConsumableDetails.Controls.Add(Me.txtConsumableName)
        Me.grpConsumableDetails.Controls.Add(Me.lblConsumableName)
        Me.grpConsumableDetails.Controls.Add(Me.txtConsumableCode)
        Me.grpConsumableDetails.Controls.Add(Me.lblConsumableCode)
        Me.grpConsumableDetails.Controls.Add(Me.lblNote)
        Me.grpConsumableDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpConsumableDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpConsumableDetails.Location = New System.Drawing.Point(20, 20)
        Me.grpConsumableDetails.Name = "grpConsumableDetails"
        Me.grpConsumableDetails.Padding = New System.Windows.Forms.Padding(15)
        Me.grpConsumableDetails.Size = New System.Drawing.Size(660, 550)
        Me.grpConsumableDetails.TabIndex = 0
        Me.grpConsumableDetails.TabStop = False
        Me.grpConsumableDetails.Text = "📝 Consumable Details"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescription.Location = New System.Drawing.Point(180, 450)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(460, 60)
        Me.txtDescription.TabIndex = 20
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescription.Location = New System.Drawing.Point(20, 450)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(88, 20)
        Me.lblDescription.TabIndex = 19
        Me.lblDescription.Text = "Description:"
        '
        'nudReorderLevel
        '
        Me.nudReorderLevel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nudReorderLevel.Location = New System.Drawing.Point(180, 410)
        Me.nudReorderLevel.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudReorderLevel.Name = "nudReorderLevel"
        Me.nudReorderLevel.Size = New System.Drawing.Size(200, 27)
        Me.nudReorderLevel.TabIndex = 18
        '
        'lblReorderLevel
        '
        Me.lblReorderLevel.AutoSize = True
        Me.lblReorderLevel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReorderLevel.Location = New System.Drawing.Point(20, 413)
        Me.lblReorderLevel.Name = "lblReorderLevel"
        Me.lblReorderLevel.Size = New System.Drawing.Size(105, 20)
        Me.lblReorderLevel.TabIndex = 17
        Me.lblReorderLevel.Text = "Reorder Level:"
        '
        'nudMinStock
        '
        Me.nudMinStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nudMinStock.Location = New System.Drawing.Point(180, 370)
        Me.nudMinStock.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudMinStock.Name = "nudMinStock"
        Me.nudMinStock.Size = New System.Drawing.Size(200, 27)
        Me.nudMinStock.TabIndex = 16
        '
        'lblMinStock
        '
        Me.lblMinStock.AutoSize = True
        Me.lblMinStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMinStock.Location = New System.Drawing.Point(20, 373)
        Me.lblMinStock.Name = "lblMinStock"
        Me.lblMinStock.Size = New System.Drawing.Size(148, 20)
        Me.lblMinStock.TabIndex = 15
        Me.lblMinStock.Text = "Minimum Stock Level:"
        '
        'txtUnitCost
        '
        Me.txtUnitCost.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUnitCost.Location = New System.Drawing.Point(180, 330)
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.Size = New System.Drawing.Size(200, 27)
        Me.txtUnitCost.TabIndex = 14
        Me.txtUnitCost.Text = "0.00"
        '
        'lblUnitCost
        '
        Me.lblUnitCost.AutoSize = True
        Me.lblUnitCost.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnitCost.Location = New System.Drawing.Point(20, 333)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(74, 20)
        Me.lblUnitCost.TabIndex = 13
        Me.lblUnitCost.Text = "Unit Cost:"
        '
        'nudInitialStock
        '
        Me.nudInitialStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.nudInitialStock.Location = New System.Drawing.Point(180, 290)
        Me.nudInitialStock.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudInitialStock.Name = "nudInitialStock"
        Me.nudInitialStock.Size = New System.Drawing.Size(200, 27)
        Me.nudInitialStock.TabIndex = 12
        '
        'lblInitialStock
        '
        Me.lblInitialStock.AutoSize = True
        Me.lblInitialStock.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblInitialStock.Location = New System.Drawing.Point(20, 293)
        Me.lblInitialStock.Name = "lblInitialStock"
        Me.lblInitialStock.Size = New System.Drawing.Size(161, 20)
        Me.lblInitialStock.TabIndex = 11
        Me.lblInitialStock.Text = "Initial Stock Quantity: *"
        '
        'txtUnitMeasure
        '
        Me.txtUnitMeasure.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUnitMeasure.Location = New System.Drawing.Point(180, 250)
        Me.txtUnitMeasure.Name = "txtUnitMeasure"
        Me.txtUnitMeasure.Size = New System.Drawing.Size(300, 27)
        Me.txtUnitMeasure.TabIndex = 10
        '
        'lblUnitMeasure
        '
        Me.lblUnitMeasure.AutoSize = True
        Me.lblUnitMeasure.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblUnitMeasure.Location = New System.Drawing.Point(20, 253)
        Me.lblUnitMeasure.Name = "lblUnitMeasure"
        Me.lblUnitMeasure.Size = New System.Drawing.Size(140, 20)
        Me.lblUnitMeasure.TabIndex = 9
        Me.lblUnitMeasure.Text = "Unit of Measure: *"
        '
        'cboSubcategory
        '
        Me.cboSubcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubcategory.Enabled = False
        Me.cboSubcategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboSubcategory.FormattingEnabled = True
        Me.cboSubcategory.Location = New System.Drawing.Point(180, 210)
        Me.cboSubcategory.Name = "cboSubcategory"
        Me.cboSubcategory.Size = New System.Drawing.Size(300, 28)
        Me.cboSubcategory.TabIndex = 8
        '
        'lblSubcategory
        '
        Me.lblSubcategory.AutoSize = True
        Me.lblSubcategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubcategory.Location = New System.Drawing.Point(20, 213)
        Me.lblSubcategory.Name = "lblSubcategory"
        Me.lblSubcategory.Size = New System.Drawing.Size(105, 20)
        Me.lblSubcategory.TabIndex = 7
        Me.lblSubcategory.Text = "Subcategory: *"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(180, 170)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(300, 28)
        Me.cboCategory.TabIndex = 6
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategory.Location = New System.Drawing.Point(20, 173)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(82, 20)
        Me.lblCategory.TabIndex = 5
        Me.lblCategory.Text = "Category: *"
        '
        'txtConsumableName
        '
        Me.txtConsumableName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtConsumableName.Location = New System.Drawing.Point(180, 130)
        Me.txtConsumableName.Name = "txtConsumableName"
        Me.txtConsumableName.Size = New System.Drawing.Size(460, 27)
        Me.txtConsumableName.TabIndex = 4
        '
        'lblConsumableName
        '
        Me.lblConsumableName.AutoSize = True
        Me.lblConsumableName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblConsumableName.Location = New System.Drawing.Point(20, 133)
        Me.lblConsumableName.Name = "lblConsumableName"
        Me.lblConsumableName.Size = New System.Drawing.Size(160, 20)
        Me.lblConsumableName.TabIndex = 3
        Me.lblConsumableName.Text = "Consumable Name: *"
        '
        'txtConsumableCode
        '
        Me.txtConsumableCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtConsumableCode.Location = New System.Drawing.Point(180, 90)
        Me.txtConsumableCode.Name = "txtConsumableCode"
        Me.txtConsumableCode.Size = New System.Drawing.Size(300, 27)
        Me.txtConsumableCode.TabIndex = 2
        '
        'lblConsumableCode
        '
        Me.lblConsumableCode.AutoSize = True
        Me.lblConsumableCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblConsumableCode.Location = New System.Drawing.Point(20, 93)
        Me.lblConsumableCode.Name = "lblConsumableCode"
        Me.lblConsumableCode.Size = New System.Drawing.Size(156, 20)
        Me.lblConsumableCode.TabIndex = 1
        Me.lblConsumableCode.Text = "Consumable Code: *"
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic)
        Me.lblNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblNote.Location = New System.Drawing.Point(20, 520)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(288, 19)
        Me.lblNote.TabIndex = 0
        Me.lblNote.Text = "* Required fields must be filled before saving"
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Controls.Add(Me.btnSave)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 650)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlBottom.Size = New System.Drawing.Size(700, 60)
        Me.pnlBottom.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(480, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(200, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "✖ Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(20, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(200, 40)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "💾 Save Consumable"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'AddEditConsumableFrm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(700, 710)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddEditConsumableFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add/Edit Consumable"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.grpConsumableDetails.ResumeLayout(False)
        Me.grpConsumableDetails.PerformLayout()
        CType(Me.nudReorderLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudInitialStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents grpConsumableDetails As GroupBox
    Friend WithEvents lblNote As Label
    Friend WithEvents txtConsumableCode As TextBox
    Friend WithEvents lblConsumableCode As Label
    Friend WithEvents txtConsumableName As TextBox
    Friend WithEvents lblConsumableName As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents cboSubcategory As ComboBox
    Friend WithEvents lblSubcategory As Label
    Friend WithEvents txtUnitMeasure As TextBox
    Friend WithEvents lblUnitMeasure As Label
    Friend WithEvents nudInitialStock As NumericUpDown
    Friend WithEvents lblInitialStock As Label
    Friend WithEvents txtUnitCost As TextBox
    Friend WithEvents lblUnitCost As Label
    Friend WithEvents nudMinStock As NumericUpDown
    Friend WithEvents lblMinStock As Label
    Friend WithEvents nudReorderLevel As NumericUpDown
    Friend WithEvents lblReorderLevel As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class