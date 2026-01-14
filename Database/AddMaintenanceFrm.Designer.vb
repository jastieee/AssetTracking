<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddMaintenanceFrm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.cboAsset = New System.Windows.Forms.ComboBox()
        Me.lblAsset = New System.Windows.Forms.Label()
        Me.txtMaintenanceType = New System.Windows.Forms.TextBox()
        Me.lblMaintenanceType = New System.Windows.Forms.Label()
        Me.dtpMaintenanceDate = New System.Windows.Forms.DateTimePicker()
        Me.lblMaintenanceDate = New System.Windows.Forms.Label()
        Me.txtPerformedBy = New System.Windows.Forms.TextBox()
        Me.lblPerformedBy = New System.Windows.Forms.Label()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.lblCost = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.dtpNextDate = New System.Windows.Forms.DateTimePicker()
        Me.lblNextDate = New System.Windows.Forms.Label()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlForm.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(600, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(550, 10)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "✕"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 18)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(254, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Add Maintenance Record"
        '
        'pnlForm
        '
        Me.pnlForm.AutoScroll = True
        Me.pnlForm.BackColor = System.Drawing.Color.White
        Me.pnlForm.Controls.Add(Me.dtpNextDate)
        Me.pnlForm.Controls.Add(Me.lblNextDate)
        Me.pnlForm.Controls.Add(Me.txtDescription)
        Me.pnlForm.Controls.Add(Me.lblDescription)
        Me.pnlForm.Controls.Add(Me.txtCost)
        Me.pnlForm.Controls.Add(Me.lblCost)
        Me.pnlForm.Controls.Add(Me.txtPerformedBy)
        Me.pnlForm.Controls.Add(Me.lblPerformedBy)
        Me.pnlForm.Controls.Add(Me.dtpMaintenanceDate)
        Me.pnlForm.Controls.Add(Me.lblMaintenanceDate)
        Me.pnlForm.Controls.Add(Me.txtMaintenanceType)
        Me.pnlForm.Controls.Add(Me.lblMaintenanceType)
        Me.pnlForm.Controls.Add(Me.cboAsset)
        Me.pnlForm.Controls.Add(Me.lblAsset)
        Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlForm.Location = New System.Drawing.Point(0, 60)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Padding = New System.Windows.Forms.Padding(30, 20, 30, 20)
        Me.pnlForm.Size = New System.Drawing.Size(600, 480)
        Me.pnlForm.TabIndex = 1
        '
        'cboAsset
        '
        Me.cboAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAsset.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboAsset.FormattingEnabled = True
        Me.cboAsset.Location = New System.Drawing.Point(30, 50)
        Me.cboAsset.Name = "cboAsset"
        Me.cboAsset.Size = New System.Drawing.Size(540, 25)
        Me.cboAsset.TabIndex = 1
        '
        'lblAsset
        '
        Me.lblAsset.AutoSize = True
        Me.lblAsset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAsset.Location = New System.Drawing.Point(30, 30)
        Me.lblAsset.Name = "lblAsset"
        Me.lblAsset.Size = New System.Drawing.Size(49, 17)
        Me.lblAsset.TabIndex = 0
        Me.lblAsset.Text = "Asset:"
        '
        'txtMaintenanceType
        '
        Me.txtMaintenanceType.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtMaintenanceType.Location = New System.Drawing.Point(30, 105)
        Me.txtMaintenanceType.Name = "txtMaintenanceType"
        Me.txtMaintenanceType.Size = New System.Drawing.Size(540, 25)
        Me.txtMaintenanceType.TabIndex = 3
        '
        'lblMaintenanceType
        '
        Me.lblMaintenanceType.AutoSize = True
        Me.lblMaintenanceType.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblMaintenanceType.Location = New System.Drawing.Point(30, 85)
        Me.lblMaintenanceType.Name = "lblMaintenanceType"
        Me.lblMaintenanceType.Size = New System.Drawing.Size(133, 17)
        Me.lblMaintenanceType.TabIndex = 2
        Me.lblMaintenanceType.Text = "Maintenance Type:"
        '
        'dtpMaintenanceDate
        '
        Me.dtpMaintenanceDate.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpMaintenanceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMaintenanceDate.Location = New System.Drawing.Point(30, 160)
        Me.dtpMaintenanceDate.Name = "dtpMaintenanceDate"
        Me.dtpMaintenanceDate.Size = New System.Drawing.Size(260, 25)
        Me.dtpMaintenanceDate.TabIndex = 5
        '
        'lblMaintenanceDate
        '
        Me.lblMaintenanceDate.AutoSize = True
        Me.lblMaintenanceDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblMaintenanceDate.Location = New System.Drawing.Point(30, 140)
        Me.lblMaintenanceDate.Name = "lblMaintenanceDate"
        Me.lblMaintenanceDate.Size = New System.Drawing.Size(133, 17)
        Me.lblMaintenanceDate.TabIndex = 4
        Me.lblMaintenanceDate.Text = "Maintenance Date:"
        '
        'txtPerformedBy
        '
        Me.txtPerformedBy.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtPerformedBy.Location = New System.Drawing.Point(30, 215)
        Me.txtPerformedBy.Name = "txtPerformedBy"
        Me.txtPerformedBy.Size = New System.Drawing.Size(540, 25)
        Me.txtPerformedBy.TabIndex = 7
        '
        'lblPerformedBy
        '
        Me.lblPerformedBy.AutoSize = True
        Me.lblPerformedBy.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblPerformedBy.Location = New System.Drawing.Point(30, 195)
        Me.lblPerformedBy.Name = "lblPerformedBy"
        Me.lblPerformedBy.Size = New System.Drawing.Size(105, 17)
        Me.lblPerformedBy.TabIndex = 6
        Me.lblPerformedBy.Text = "Performed By:"
        '
        'txtCost
        '
        Me.txtCost.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtCost.Location = New System.Drawing.Point(30, 270)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(260, 25)
        Me.txtCost.TabIndex = 9
        '
        'lblCost
        '
        Me.lblCost.AutoSize = True
        Me.lblCost.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCost.Location = New System.Drawing.Point(30, 250)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(40, 17)
        Me.lblCost.TabIndex = 8
        Me.lblCost.Text = "Cost:"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtDescription.Location = New System.Drawing.Point(30, 325)
        Me.txtDescription.MaxLength = 500
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(540, 80)
        Me.txtDescription.TabIndex = 11
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblDescription.Location = New System.Drawing.Point(30, 305)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(84, 17)
        Me.lblDescription.TabIndex = 10
        Me.lblDescription.Text = "Description:"
        '
        'dtpNextDate
        '
        Me.dtpNextDate.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpNextDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNextDate.Location = New System.Drawing.Point(30, 435)
        Me.dtpNextDate.Name = "dtpNextDate"
        Me.dtpNextDate.Size = New System.Drawing.Size(260, 25)
        Me.dtpNextDate.TabIndex = 13
        '
        'lblNextDate
        '
        Me.lblNextDate.AutoSize = True
        Me.lblNextDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblNextDate.Location = New System.Drawing.Point(30, 415)
        Me.lblNextDate.Name = "lblNextDate"
        Me.lblNextDate.Size = New System.Drawing.Size(168, 17)
        Me.lblNextDate.TabIndex = 12
        Me.lblNextDate.Text = "Next Maintenance Date:"
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Controls.Add(Me.btnSave)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 540)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(600, 70)
        Me.pnlButtons.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(320, 15)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(450, 15)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 40)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "💾 Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'AddMaintenanceFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 610)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddMaintenanceFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Maintenance Record"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlForm As Panel
    Friend WithEvents cboAsset As ComboBox
    Friend WithEvents lblAsset As Label
    Friend WithEvents txtMaintenanceType As TextBox
    Friend WithEvents lblMaintenanceType As Label
    Friend WithEvents dtpMaintenanceDate As DateTimePicker
    Friend WithEvents lblMaintenanceDate As Label
    Friend WithEvents txtPerformedBy As TextBox
    Friend WithEvents lblPerformedBy As Label
    Friend WithEvents txtCost As TextBox
    Friend WithEvents lblCost As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents dtpNextDate As DateTimePicker
    Friend WithEvents lblNextDate As Label
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
End Class