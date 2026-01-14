<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewTransferFrm
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
        Me.lblSelectAsset = New System.Windows.Forms.Label()
        Me.cboAsset = New System.Windows.Forms.ComboBox()
        Me.pnlCurrentInfo = New System.Windows.Forms.Panel()
        Me.lblCurrentInfoTitle = New System.Windows.Forms.Label()
        Me.lblCurrentLocation = New System.Windows.Forms.Label()
        Me.lblCurrentDept = New System.Windows.Forms.Label()
        Me.lblCurrentUser = New System.Windows.Forms.Label()
        Me.lblTransferTo = New System.Windows.Forms.Label()
        Me.lblToDepartment = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.lblToUser = New System.Windows.Forms.Label()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.blReason = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlForm.SuspendLayout()
        Me.pnlCurrentInfo.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(203, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "New Asset Transfer"
        '
        'pnlForm
        '
        Me.pnlForm.AutoScroll = True
        Me.pnlForm.BackColor = System.Drawing.Color.White
        Me.pnlForm.Controls.Add(Me.txtNotes)
        Me.pnlForm.Controls.Add(Me.lblNotes)
        Me.pnlForm.Controls.Add(Me.txtReason)
        Me.pnlForm.Controls.Add(Me.blReason)
        Me.pnlForm.Controls.Add(Me.cboUser)
        Me.pnlForm.Controls.Add(Me.lblToUser)
        Me.pnlForm.Controls.Add(Me.cboDepartment)
        Me.pnlForm.Controls.Add(Me.lblToDepartment)
        Me.pnlForm.Controls.Add(Me.lblTransferTo)
        Me.pnlForm.Controls.Add(Me.pnlCurrentInfo)
        Me.pnlForm.Controls.Add(Me.cboAsset)
        Me.pnlForm.Controls.Add(Me.lblSelectAsset)
        Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlForm.Location = New System.Drawing.Point(0, 60)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Padding = New System.Windows.Forms.Padding(30, 20, 30, 20)
        Me.pnlForm.Size = New System.Drawing.Size(600, 540)
        Me.pnlForm.TabIndex = 1
        '
        'lblSelectAsset
        '
        Me.lblSelectAsset.AutoSize = True
        Me.lblSelectAsset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblSelectAsset.Location = New System.Drawing.Point(30, 20)
        Me.lblSelectAsset.Name = "lblSelectAsset"
        Me.lblSelectAsset.Size = New System.Drawing.Size(92, 17)
        Me.lblSelectAsset.TabIndex = 0
        Me.lblSelectAsset.Text = "Select Asset:"
        '
        'cboAsset
        '
        Me.cboAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAsset.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboAsset.FormattingEnabled = True
        Me.cboAsset.Location = New System.Drawing.Point(30, 40)
        Me.cboAsset.Name = "cboAsset"
        Me.cboAsset.Size = New System.Drawing.Size(540, 25)
        Me.cboAsset.TabIndex = 1
        '
        'pnlCurrentInfo
        '
        Me.pnlCurrentInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlCurrentInfo.Controls.Add(Me.lblCurrentUser)
        Me.pnlCurrentInfo.Controls.Add(Me.lblCurrentDept)
        Me.pnlCurrentInfo.Controls.Add(Me.lblCurrentLocation)
        Me.pnlCurrentInfo.Controls.Add(Me.lblCurrentInfoTitle)
        Me.pnlCurrentInfo.Location = New System.Drawing.Point(30, 80)
        Me.pnlCurrentInfo.Name = "pnlCurrentInfo"
        Me.pnlCurrentInfo.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
        Me.pnlCurrentInfo.Size = New System.Drawing.Size(540, 100)
        Me.pnlCurrentInfo.TabIndex = 2
        '
        'lblCurrentInfoTitle
        '
        Me.lblCurrentInfoTitle.AutoSize = True
        Me.lblCurrentInfoTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentInfoTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblCurrentInfoTitle.Location = New System.Drawing.Point(15, 10)
        Me.lblCurrentInfoTitle.Name = "lblCurrentInfoTitle"
        Me.lblCurrentInfoTitle.Size = New System.Drawing.Size(132, 17)
        Me.lblCurrentInfoTitle.TabIndex = 0
        Me.lblCurrentInfoTitle.Text = "Current Assignment"
        '
        'lblCurrentLocation
        '
        Me.lblCurrentLocation.AutoSize = True
        Me.lblCurrentLocation.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblCurrentLocation.Location = New System.Drawing.Point(15, 35)
        Me.lblCurrentLocation.Name = "lblCurrentLocation"
        Me.lblCurrentLocation.Size = New System.Drawing.Size(113, 17)
        Me.lblCurrentLocation.TabIndex = 1
        Me.lblCurrentLocation.Text = "Location: [Empty]"
        '
        'lblCurrentDept
        '
        Me.lblCurrentDept.AutoSize = True
        Me.lblCurrentDept.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblCurrentDept.Location = New System.Drawing.Point(15, 55)
        Me.lblCurrentDept.Name = "lblCurrentDept"
        Me.lblCurrentDept.Size = New System.Drawing.Size(127, 17)
        Me.lblCurrentDept.TabIndex = 2
        Me.lblCurrentDept.Text = "Department: [Empty]"
        '
        'lblCurrentUser
        '
        Me.lblCurrentUser.AutoSize = True
        Me.lblCurrentUser.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblCurrentUser.Location = New System.Drawing.Point(15, 75)
        Me.lblCurrentUser.Name = "lblCurrentUser"
        Me.lblCurrentUser.Size = New System.Drawing.Size(130, 17)
        Me.lblCurrentUser.TabIndex = 3
        Me.lblCurrentUser.Text = "Assigned To: [Empty]"
        '
        'lblTransferTo
        '
        Me.lblTransferTo.AutoSize = True
        Me.lblTransferTo.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblTransferTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblTransferTo.Location = New System.Drawing.Point(30, 195)
        Me.lblTransferTo.Name = "lblTransferTo"
        Me.lblTransferTo.Size = New System.Drawing.Size(93, 20)
        Me.lblTransferTo.TabIndex = 3
        Me.lblTransferTo.Text = "Transfer To"
        '
        'lblToDepartment
        '
        Me.lblToDepartment.AutoSize = True
        Me.lblToDepartment.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblToDepartment.Location = New System.Drawing.Point(30, 225)
        Me.lblToDepartment.Name = "lblToDepartment"
        Me.lblToDepartment.Size = New System.Drawing.Size(88, 17)
        Me.lblToDepartment.TabIndex = 4
        Me.lblToDepartment.Text = "Department:"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(30, 245)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(540, 25)
        Me.cboDepartment.TabIndex = 5
        '
        'lblToUser
        '
        Me.lblToUser.AutoSize = True
        Me.lblToUser.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblToUser.Location = New System.Drawing.Point(30, 280)
        Me.lblToUser.Name = "lblToUser"
        Me.lblToUser.Size = New System.Drawing.Size(74, 17)
        Me.lblToUser.TabIndex = 6
        Me.lblToUser.Text = "Assign To:"
        '
        'cboUser
        '
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboUser.FormattingEnabled = True
        Me.cboUser.Location = New System.Drawing.Point(30, 300)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(540, 25)
        Me.cboUser.TabIndex = 7
        '
        'blReason
        '
        Me.blReason.AutoSize = True
        Me.blReason.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.blReason.Location = New System.Drawing.Point(30, 335)
        Me.blReason.Name = "blReason"
        Me.blReason.Size = New System.Drawing.Size(144, 17)
        Me.blReason.TabIndex = 8
        Me.blReason.Text = "Reason For Transfer:"
        '
        'txtReason
        '
        Me.txtReason.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtReason.Location = New System.Drawing.Point(30, 355)
        Me.txtReason.MaxLength = 500
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReason.Size = New System.Drawing.Size(540, 60)
        Me.txtReason.TabIndex = 9
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblNotes.Location = New System.Drawing.Point(30, 425)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(50, 17)
        Me.lblNotes.TabIndex = 10
        Me.lblNotes.Text = "Notes:"
        '
        'txtNotes
        '
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtNotes.Location = New System.Drawing.Point(30, 445)
        Me.txtNotes.MaxLength = 500
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(540, 60)
        Me.txtNotes.TabIndex = 11
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Controls.Add(Me.btnSubmit)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 600)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(600, 70)
        Me.pnlButtons.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
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
        'btnSubmit
        '
        Me.btnSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(450, 15)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(120, 40)
        Me.btnSubmit.TabIndex = 0
        Me.btnSubmit.Text = "✅ Submit"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'NewTransferFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 670)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NewTransferFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Asset Transfer"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlForm.ResumeLayout(False)
        Me.pnlForm.PerformLayout()
        Me.pnlCurrentInfo.ResumeLayout(False)
        Me.pnlCurrentInfo.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlForm As Panel
    Friend WithEvents lblSelectAsset As Label
    Friend WithEvents cboAsset As ComboBox
    Friend WithEvents pnlCurrentInfo As Panel
    Friend WithEvents lblCurrentInfoTitle As Label
    Friend WithEvents lblCurrentDept As Label
    Friend WithEvents lblCurrentLocation As Label
    Friend WithEvents lblCurrentUser As Label
    Friend WithEvents lblTransferTo As Label
    Friend WithEvents lblToDepartment As Label
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents lblToUser As Label
    Friend WithEvents cboUser As ComboBox
    Friend WithEvents blReason As Label
    Friend WithEvents txtReason As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSubmit As Button
End Class