<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddEditDepartmentFrm
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
        Me.grpDepartmentDetails = New System.Windows.Forms.GroupBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtDepartmentCode = New System.Windows.Forms.TextBox()
        Me.lblDepartmentCode = New System.Windows.Forms.Label()
        Me.txtDepartmentName = New System.Windows.Forms.TextBox()
        Me.lblDepartmentName = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlTop.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.grpDepartmentDetails.SuspendLayout()
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
        Me.pnlTop.Size = New System.Drawing.Size(600, 60)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(226, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "➕ Add Department"
        '
        'pnlContent
        '
        Me.pnlContent.AutoScroll = True
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.grpDepartmentDetails)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 60)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(600, 380)
        Me.pnlContent.TabIndex = 1
        '
        'grpDepartmentDetails
        '
        Me.grpDepartmentDetails.BackColor = System.Drawing.Color.White
        Me.grpDepartmentDetails.Controls.Add(Me.txtDescription)
        Me.grpDepartmentDetails.Controls.Add(Me.lblDescription)
        Me.grpDepartmentDetails.Controls.Add(Me.cboStatus)
        Me.grpDepartmentDetails.Controls.Add(Me.lblStatus)
        Me.grpDepartmentDetails.Controls.Add(Me.txtDepartmentCode)
        Me.grpDepartmentDetails.Controls.Add(Me.lblDepartmentCode)
        Me.grpDepartmentDetails.Controls.Add(Me.txtDepartmentName)
        Me.grpDepartmentDetails.Controls.Add(Me.lblDepartmentName)
        Me.grpDepartmentDetails.Controls.Add(Me.lblNote)
        Me.grpDepartmentDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDepartmentDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpDepartmentDetails.Location = New System.Drawing.Point(20, 20)
        Me.grpDepartmentDetails.Name = "grpDepartmentDetails"
        Me.grpDepartmentDetails.Padding = New System.Windows.Forms.Padding(15)
        Me.grpDepartmentDetails.Size = New System.Drawing.Size(560, 340)
        Me.grpDepartmentDetails.TabIndex = 0
        Me.grpDepartmentDetails.TabStop = False
        Me.grpDepartmentDetails.Text = "📝 Department Details"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDescription.Location = New System.Drawing.Point(200, 117)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(340, 80)
        Me.txtDescription.TabIndex = 8
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDescription.Location = New System.Drawing.Point(20, 120)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(88, 20)
        Me.lblDescription.TabIndex = 7
        Me.lblDescription.Text = "Description:"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Active", "Inactive"})
        Me.cboStatus.Location = New System.Drawing.Point(200, 207)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(150, 28)
        Me.cboStatus.TabIndex = 6
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus.Location = New System.Drawing.Point(20, 210)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(62, 20)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Status: *"
        '
        'txtDepartmentCode
        '
        Me.txtDepartmentCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartmentCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDepartmentCode.Location = New System.Drawing.Point(200, 77)
        Me.txtDepartmentCode.MaxLength = 20
        Me.txtDepartmentCode.Name = "txtDepartmentCode"
        Me.txtDepartmentCode.Size = New System.Drawing.Size(200, 27)
        Me.txtDepartmentCode.TabIndex = 4
        '
        'lblDepartmentCode
        '
        Me.lblDepartmentCode.AutoSize = True
        Me.lblDepartmentCode.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartmentCode.Location = New System.Drawing.Point(20, 80)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(148, 20)
        Me.lblDepartmentCode.TabIndex = 3
        Me.lblDepartmentCode.Text = "Department Code: *"
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtDepartmentName.Location = New System.Drawing.Point(200, 37)
        Me.txtDepartmentName.MaxLength = 100
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.Size = New System.Drawing.Size(340, 27)
        Me.txtDepartmentName.TabIndex = 2
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.AutoSize = True
        Me.lblDepartmentName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartmentName.Location = New System.Drawing.Point(20, 40)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(154, 20)
        Me.lblDepartmentName.TabIndex = 1
        Me.lblDepartmentName.Text = "Department Name: *"
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic)
        Me.lblNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblNote.Location = New System.Drawing.Point(20, 300)
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
        Me.pnlBottom.Location = New System.Drawing.Point(0, 440)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlBottom.Size = New System.Drawing.Size(600, 60)
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
        Me.btnCancel.Location = New System.Drawing.Point(380, 10)
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
        Me.btnSave.Text = "💾 Save Department"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'AddEditDepartmentFrm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(600, 500)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddEditDepartmentFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add/Edit Department"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.grpDepartmentDetails.ResumeLayout(False)
        Me.grpDepartmentDetails.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents grpDepartmentDetails As GroupBox
    Friend WithEvents lblNote As Label
    Friend WithEvents txtDepartmentName As TextBox
    Friend WithEvents lblDepartmentName As Label
    Friend WithEvents txtDepartmentCode As TextBox
    Friend WithEvents lblDepartmentCode As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class