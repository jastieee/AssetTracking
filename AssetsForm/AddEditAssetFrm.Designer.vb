<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddEditAssetFrm
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
        Me.grpAssetDetails = New System.Windows.Forms.GroupBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.dtpPurchaseDate = New System.Windows.Forms.DateTimePicker()
        Me.lblPurchaseDate = New System.Windows.Forms.Label()
        Me.txtManufacturer = New System.Windows.Forms.TextBox()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.cboCondition = New System.Windows.Forms.ComboBox()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cboSubcategory = New System.Windows.Forms.ComboBox()
        Me.lblSubcategory = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.txtAssetName = New System.Windows.Forms.TextBox()
        Me.lblAssetName = New System.Windows.Forms.Label()
        Me.txtAssetTag = New System.Windows.Forms.TextBox()
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlTop.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.grpAssetDetails.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(170, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "➕ Add Asset"
        '
        'pnlContent
        '
        Me.pnlContent.AutoScroll = True
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.grpAssetDetails)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 60)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(700, 590)
        Me.pnlContent.TabIndex = 1
        '
        'grpAssetDetails
        '
        Me.grpAssetDetails.BackColor = System.Drawing.Color.White
        Me.grpAssetDetails.Controls.Add(Me.txtDescription)
        Me.grpAssetDetails.Controls.Add(Me.lblDescription)
        Me.grpAssetDetails.Controls.Add(Me.cboDepartment)
        Me.grpAssetDetails.Controls.Add(Me.lblDepartment)
        Me.grpAssetDetails.Controls.Add(Me.dtpPurchaseDate)
        Me.grpAssetDetails.Controls.Add(Me.lblPurchaseDate)
        Me.grpAssetDetails.Controls.Add(Me.txtManufacturer)
        Me.grpAssetDetails.Controls.Add(Me.lblManufacturer)
        Me.grpAssetDetails.Controls.Add(Me.txtModel)
        Me.grpAssetDetails.Controls.Add(Me.lblModel)
        Me.grpAssetDetails.Controls.Add(Me.txtSerialNumber)
        Me.grpAssetDetails.Controls.Add(Me.lblSerialNumber)
        Me.grpAssetDetails.Controls.Add(Me.cboCondition)
        Me.grpAssetDetails.Controls.Add(Me.lblCondition)
        Me.grpAssetDetails.Controls.Add(Me.cboStatus)
        Me.grpAssetDetails.Controls.Add(Me.lblStatus)
        Me.grpAssetDetails.Controls.Add(Me.cboSubcategory)
        Me.grpAssetDetails.Controls.Add(Me.lblSubcategory)
        Me.grpAssetDetails.Controls.Add(Me.cboCategory)
        Me.grpAssetDetails.Controls.Add(Me.lblCategory)
        Me.grpAssetDetails.Controls.Add(Me.txtAssetName)
        Me.grpAssetDetails.Controls.Add(Me.lblAssetName)
        Me.grpAssetDetails.Controls.Add(Me.txtAssetTag)
        Me.grpAssetDetails.Controls.Add(Me.lblAssetTag)
        Me.grpAssetDetails.Controls.Add(Me.lblNote)
        Me.grpAssetDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpAssetDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpAssetDetails.Location = New System.Drawing.Point(20, 20)
        Me.grpAssetDetails.Name = "grpAssetDetails"
        Me.grpAssetDetails.Padding = New System.Windows.Forms.Padding(15)
        Me.grpAssetDetails.Size = New System.Drawing.Size(660, 550)
        Me.grpAssetDetails.TabIndex = 0
        Me.grpAssetDetails.TabStop = False
        Me.grpAssetDetails.Text = "📝 Asset Details"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescription.Location = New System.Drawing.Point(180, 450)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(460, 60)
        Me.txtDescription.TabIndex = 24
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescription.Location = New System.Drawing.Point(20, 450)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(88, 20)
        Me.lblDescription.TabIndex = 23
        Me.lblDescription.Text = "Description:"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(180, 410)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(300, 28)
        Me.cboDepartment.TabIndex = 22
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartment.Location = New System.Drawing.Point(20, 413)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(144, 20)
        Me.lblDepartment.TabIndex = 21
        Me.lblDepartment.Text = "Current Department:"
        '
        'dtpPurchaseDate
        '
        Me.dtpPurchaseDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPurchaseDate.Location = New System.Drawing.Point(180, 370)
        Me.dtpPurchaseDate.Name = "dtpPurchaseDate"
        Me.dtpPurchaseDate.Size = New System.Drawing.Size(200, 27)
        Me.dtpPurchaseDate.TabIndex = 20
        '
        'lblPurchaseDate
        '
        Me.lblPurchaseDate.AutoSize = True
        Me.lblPurchaseDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPurchaseDate.Location = New System.Drawing.Point(20, 373)
        Me.lblPurchaseDate.Name = "lblPurchaseDate"
        Me.lblPurchaseDate.Size = New System.Drawing.Size(106, 20)
        Me.lblPurchaseDate.TabIndex = 19
        Me.lblPurchaseDate.Text = "Purchase Date:"
        '
        'txtManufacturer
        '
        Me.txtManufacturer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtManufacturer.Location = New System.Drawing.Point(180, 330)
        Me.txtManufacturer.Name = "txtManufacturer"
        Me.txtManufacturer.Size = New System.Drawing.Size(300, 27)
        Me.txtManufacturer.TabIndex = 18
        '
        'lblManufacturer
        '
        Me.lblManufacturer.AutoSize = True
        Me.lblManufacturer.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblManufacturer.Location = New System.Drawing.Point(20, 333)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(100, 20)
        Me.lblManufacturer.TabIndex = 17
        Me.lblManufacturer.Text = "Manufacturer:"
        '
        'txtModel
        '
        Me.txtModel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtModel.Location = New System.Drawing.Point(180, 290)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Size = New System.Drawing.Size(300, 27)
        Me.txtModel.TabIndex = 16
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblModel.Location = New System.Drawing.Point(20, 293)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(55, 20)
        Me.lblModel.TabIndex = 15
        Me.lblModel.Text = "Model:"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSerialNumber.Location = New System.Drawing.Point(180, 250)
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.Size = New System.Drawing.Size(300, 27)
        Me.txtSerialNumber.TabIndex = 14
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSerialNumber.Location = New System.Drawing.Point(20, 253)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(107, 20)
        Me.lblSerialNumber.TabIndex = 13
        Me.lblSerialNumber.Text = "Serial Number:"
        '
        'cboCondition
        '
        Me.cboCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondition.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboCondition.FormattingEnabled = True
        Me.cboCondition.Items.AddRange(New Object() {"Excellent", "Good", "Fair", "Poor"})
        Me.cboCondition.Location = New System.Drawing.Point(480, 210)
        Me.cboCondition.Name = "cboCondition"
        Me.cboCondition.Size = New System.Drawing.Size(160, 28)
        Me.cboCondition.TabIndex = 12
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCondition.Location = New System.Drawing.Point(350, 213)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(77, 20)
        Me.lblCondition.TabIndex = 11
        Me.lblCondition.Text = "Condition:"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"In Stock", "Issued", "Under Maintenance", "Disposed", "Lost"})
        Me.cboStatus.Location = New System.Drawing.Point(180, 210)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(160, 28)
        Me.cboStatus.TabIndex = 10
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus.Location = New System.Drawing.Point(20, 213)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(62, 20)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Status: *"
        '
        'cboSubcategory
        '
        Me.cboSubcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubcategory.Enabled = False
        Me.cboSubcategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboSubcategory.FormattingEnabled = True
        Me.cboSubcategory.Location = New System.Drawing.Point(180, 170)
        Me.cboSubcategory.Name = "cboSubcategory"
        Me.cboSubcategory.Size = New System.Drawing.Size(300, 28)
        Me.cboSubcategory.TabIndex = 8
        '
        'lblSubcategory
        '
        Me.lblSubcategory.AutoSize = True
        Me.lblSubcategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubcategory.Location = New System.Drawing.Point(20, 173)
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
        Me.cboCategory.Location = New System.Drawing.Point(180, 130)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(300, 28)
        Me.cboCategory.TabIndex = 6
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategory.Location = New System.Drawing.Point(20, 133)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(82, 20)
        Me.lblCategory.TabIndex = 5
        Me.lblCategory.Text = "Category: *"
        '
        'txtAssetName
        '
        Me.txtAssetName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAssetName.Location = New System.Drawing.Point(180, 90)
        Me.txtAssetName.Name = "txtAssetName"
        Me.txtAssetName.Size = New System.Drawing.Size(460, 27)
        Me.txtAssetName.TabIndex = 4
        '
        'lblAssetName
        '
        Me.lblAssetName.AutoSize = True
        Me.lblAssetName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAssetName.Location = New System.Drawing.Point(20, 93)
        Me.lblAssetName.Name = "lblAssetName"
        Me.lblAssetName.Size = New System.Drawing.Size(101, 20)
        Me.lblAssetName.TabIndex = 3
        Me.lblAssetName.Text = "Asset Name: *"
        '
        'txtAssetTag
        '
        Me.txtAssetTag.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtAssetTag.Location = New System.Drawing.Point(180, 50)
        Me.txtAssetTag.Name = "txtAssetTag"
        Me.txtAssetTag.Size = New System.Drawing.Size(300, 27)
        Me.txtAssetTag.TabIndex = 2
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAssetTag.Location = New System.Drawing.Point(20, 53)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(84, 20)
        Me.lblAssetTag.TabIndex = 1
        Me.lblAssetTag.Text = "Asset Tag: *"
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
        Me.btnSave.Text = "💾 Save Asset"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'AddEditAssetFrm
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
        Me.Name = "AddEditAssetFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add/Edit Asset"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.grpAssetDetails.ResumeLayout(False)
        Me.grpAssetDetails.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents grpAssetDetails As GroupBox
    Friend WithEvents lblNote As Label
    Friend WithEvents txtAssetTag As TextBox
    Friend WithEvents lblAssetTag As Label
    Friend WithEvents txtAssetName As TextBox
    Friend WithEvents lblAssetName As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents cboSubcategory As ComboBox
    Friend WithEvents lblSubcategory As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents cboCondition As ComboBox
    Friend WithEvents lblCondition As Label
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents txtModel As TextBox
    Friend WithEvents lblModel As Label
    Friend WithEvents txtManufacturer As TextBox
    Friend WithEvents lblManufacturer As Label
    Friend WithEvents dtpPurchaseDate As DateTimePicker
    Friend WithEvents lblPurchaseDate As Label
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents lblDepartment As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class