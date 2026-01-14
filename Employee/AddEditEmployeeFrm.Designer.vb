<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddEditEmployeeFrm
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
        Me.grpEmployeeDetails = New System.Windows.Forms.GroupBox()
        Me.cboSupervisor = New System.Windows.Forms.ComboBox()
        Me.lblSupervisor = New System.Windows.Forms.Label()
        Me.cboEmploymentType = New System.Windows.Forms.ComboBox()
        Me.lblEmploymentType = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.dtpHireDate = New System.Windows.Forms.DateTimePicker()
        Me.lblHireDate = New System.Windows.Forms.Label()
        Me.cboPosition = New System.Windows.Forms.ComboBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtEmployeeNumber = New System.Windows.Forms.TextBox()
        Me.lblEmployeeNumber = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlTop.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.grpEmployeeDetails.SuspendLayout()
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
        Me.pnlTop.Size = New System.Drawing.Size(750, 60)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(210, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "➕ Add Employee"
        '
        'pnlContent
        '
        Me.pnlContent.AutoScroll = True
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.grpEmployeeDetails)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 60)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(750, 590)
        Me.pnlContent.TabIndex = 1
        '
        'grpEmployeeDetails
        '
        Me.grpEmployeeDetails.BackColor = System.Drawing.Color.White
        Me.grpEmployeeDetails.Controls.Add(Me.cboSupervisor)
        Me.grpEmployeeDetails.Controls.Add(Me.lblSupervisor)
        Me.grpEmployeeDetails.Controls.Add(Me.cboEmploymentType)
        Me.grpEmployeeDetails.Controls.Add(Me.lblEmploymentType)
        Me.grpEmployeeDetails.Controls.Add(Me.cboStatus)
        Me.grpEmployeeDetails.Controls.Add(Me.lblStatus)
        Me.grpEmployeeDetails.Controls.Add(Me.dtpHireDate)
        Me.grpEmployeeDetails.Controls.Add(Me.lblHireDate)
        Me.grpEmployeeDetails.Controls.Add(Me.cboPosition)
        Me.grpEmployeeDetails.Controls.Add(Me.lblPosition)
        Me.grpEmployeeDetails.Controls.Add(Me.cboDepartment)
        Me.grpEmployeeDetails.Controls.Add(Me.lblDepartment)
        Me.grpEmployeeDetails.Controls.Add(Me.txtPhone)
        Me.grpEmployeeDetails.Controls.Add(Me.lblPhone)
        Me.grpEmployeeDetails.Controls.Add(Me.txtEmail)
        Me.grpEmployeeDetails.Controls.Add(Me.lblEmail)
        Me.grpEmployeeDetails.Controls.Add(Me.txtLastName)
        Me.grpEmployeeDetails.Controls.Add(Me.lblLastName)
        Me.grpEmployeeDetails.Controls.Add(Me.txtMiddleName)
        Me.grpEmployeeDetails.Controls.Add(Me.lblMiddleName)
        Me.grpEmployeeDetails.Controls.Add(Me.txtFirstName)
        Me.grpEmployeeDetails.Controls.Add(Me.lblFirstName)
        Me.grpEmployeeDetails.Controls.Add(Me.txtEmployeeNumber)
        Me.grpEmployeeDetails.Controls.Add(Me.lblEmployeeNumber)
        Me.grpEmployeeDetails.Controls.Add(Me.lblNote)
        Me.grpEmployeeDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpEmployeeDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpEmployeeDetails.Location = New System.Drawing.Point(20, 20)
        Me.grpEmployeeDetails.Name = "grpEmployeeDetails"
        Me.grpEmployeeDetails.Padding = New System.Windows.Forms.Padding(15)
        Me.grpEmployeeDetails.Size = New System.Drawing.Size(710, 550)
        Me.grpEmployeeDetails.TabIndex = 0
        Me.grpEmployeeDetails.TabStop = False
        Me.grpEmployeeDetails.Text = "👤 Employee Details"
        '
        'cboSupervisor
        '
        Me.cboSupervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupervisor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboSupervisor.FormattingEnabled = True
        Me.cboSupervisor.Location = New System.Drawing.Point(200, 470)
        Me.cboSupervisor.Name = "cboSupervisor"
        Me.cboSupervisor.Size = New System.Drawing.Size(490, 28)
        Me.cboSupervisor.TabIndex = 24
        '
        'lblSupervisor
        '
        Me.lblSupervisor.AutoSize = True
        Me.lblSupervisor.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSupervisor.Location = New System.Drawing.Point(20, 473)
        Me.lblSupervisor.Name = "lblSupervisor"
        Me.lblSupervisor.Size = New System.Drawing.Size(127, 20)
        Me.lblSupervisor.TabIndex = 23
        Me.lblSupervisor.Text = "Direct Supervisor:"
        '
        'cboEmploymentType
        '
        Me.cboEmploymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmploymentType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboEmploymentType.FormattingEnabled = True
        Me.cboEmploymentType.Items.AddRange(New Object() {"Regular", "Contractual", "Part-time", "Probationary"})
        Me.cboEmploymentType.Location = New System.Drawing.Point(460, 430)
        Me.cboEmploymentType.Name = "cboEmploymentType"
        Me.cboEmploymentType.Size = New System.Drawing.Size(230, 28)
        Me.cboEmploymentType.TabIndex = 22
        '
        'lblEmploymentType
        '
        Me.lblEmploymentType.AutoSize = True
        Me.lblEmploymentType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmploymentType.Location = New System.Drawing.Point(300, 433)
        Me.lblEmploymentType.Name = "lblEmploymentType"
        Me.lblEmploymentType.Size = New System.Drawing.Size(146, 20)
        Me.lblEmploymentType.TabIndex = 21
        Me.lblEmploymentType.Text = "Employment Type: *"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Active", "On Leave", "Resigned", "Terminated", "Retired"})
        Me.cboStatus.Location = New System.Drawing.Point(200, 430)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(180, 28)
        Me.cboStatus.TabIndex = 20
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStatus.Location = New System.Drawing.Point(20, 433)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(135, 20)
        Me.lblStatus.TabIndex = 19
        Me.lblStatus.Text = "Employment Status:"
        '
        'dtpHireDate
        '
        Me.dtpHireDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHireDate.Location = New System.Drawing.Point(200, 390)
        Me.dtpHireDate.Name = "dtpHireDate"
        Me.dtpHireDate.Size = New System.Drawing.Size(200, 27)
        Me.dtpHireDate.TabIndex = 18
        '
        'lblHireDate
        '
        Me.lblHireDate.AutoSize = True
        Me.lblHireDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHireDate.Location = New System.Drawing.Point(20, 393)
        Me.lblHireDate.Name = "lblHireDate"
        Me.lblHireDate.Size = New System.Drawing.Size(86, 20)
        Me.lblHireDate.TabIndex = 17
        Me.lblHireDate.Text = "Hire Date: *"
        '
        'cboPosition
        '
        Me.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPosition.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboPosition.FormattingEnabled = True
        Me.cboPosition.Location = New System.Drawing.Point(200, 350)
        Me.cboPosition.Name = "cboPosition"
        Me.cboPosition.Size = New System.Drawing.Size(490, 28)
        Me.cboPosition.TabIndex = 16
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPosition.Location = New System.Drawing.Point(20, 353)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(73, 20)
        Me.lblPosition.TabIndex = 15
        Me.lblPosition.Text = "Position: *"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(200, 310)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(490, 28)
        Me.cboDepartment.TabIndex = 14
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartment.Location = New System.Drawing.Point(20, 313)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(101, 20)
        Me.lblDepartment.TabIndex = 13
        Me.lblDepartment.Text = "Department: *"
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtPhone.Location = New System.Drawing.Point(200, 270)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(300, 27)
        Me.txtPhone.TabIndex = 12
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPhone.Location = New System.Drawing.Point(20, 273)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(116, 20)
        Me.lblPhone.TabIndex = 11
        Me.lblPhone.Text = "Phone Number:"
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmail.Location = New System.Drawing.Point(200, 230)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(490, 27)
        Me.txtEmail.TabIndex = 10
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmail.Location = New System.Drawing.Point(20, 233)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(104, 20)
        Me.lblEmail.TabIndex = 9
        Me.lblEmail.Text = "Email Address:"
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtLastName.Location = New System.Drawing.Point(200, 190)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(490, 27)
        Me.txtLastName.TabIndex = 8
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLastName.Location = New System.Drawing.Point(20, 193)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(89, 20)
        Me.lblLastName.TabIndex = 7
        Me.lblLastName.Text = "Last Name: *"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMiddleName.Location = New System.Drawing.Point(200, 150)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(490, 27)
        Me.txtMiddleName.TabIndex = 6
        '
        'lblMiddleName
        '
        Me.lblMiddleName.AutoSize = True
        Me.lblMiddleName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMiddleName.Location = New System.Drawing.Point(20, 153)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(102, 20)
        Me.lblMiddleName.TabIndex = 5
        Me.lblMiddleName.Text = "Middle Name:"
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtFirstName.Location = New System.Drawing.Point(200, 110)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(490, 27)
        Me.txtFirstName.TabIndex = 4
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFirstName.Location = New System.Drawing.Point(20, 113)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(91, 20)
        Me.lblFirstName.TabIndex = 3
        Me.lblFirstName.Text = "First Name: *"
        '
        'txtEmployeeNumber
        '
        Me.txtEmployeeNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtEmployeeNumber.Location = New System.Drawing.Point(200, 70)
        Me.txtEmployeeNumber.Name = "txtEmployeeNumber"
        Me.txtEmployeeNumber.Size = New System.Drawing.Size(300, 27)
        Me.txtEmployeeNumber.TabIndex = 2
        '
        'lblEmployeeNumber
        '
        Me.lblEmployeeNumber.AutoSize = True
        Me.lblEmployeeNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmployeeNumber.Location = New System.Drawing.Point(20, 73)
        Me.lblEmployeeNumber.Name = "lblEmployeeNumber"
        Me.lblEmployeeNumber.Size = New System.Drawing.Size(142, 20)
        Me.lblEmployeeNumber.TabIndex = 1
        Me.lblEmployeeNumber.Text = "Employee Number: *"
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic)
        Me.lblNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblNote.Location = New System.Drawing.Point(20, 35)
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
        Me.pnlBottom.Size = New System.Drawing.Size(750, 60)
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
        Me.btnCancel.Location = New System.Drawing.Point(530, 10)
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
        Me.btnSave.Text = "💾 Save Employee"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'AddEditEmployeeFrm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(750, 710)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddEditEmployeeFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add/Edit Employee"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.grpEmployeeDetails.ResumeLayout(False)
        Me.grpEmployeeDetails.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents grpEmployeeDetails As GroupBox
    Friend WithEvents lblNote As Label
    Friend WithEvents txtEmployeeNumber As TextBox
    Friend WithEvents lblEmployeeNumber As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblFirstName As Label
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents lblMiddleName As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents lblLastName As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents lblDepartment As Label
    Friend WithEvents cboPosition As ComboBox
    Friend WithEvents lblPosition As Label
    Friend WithEvents dtpHireDate As DateTimePicker
    Friend WithEvents lblHireDate As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents cboEmploymentType As ComboBox
    Friend WithEvents lblEmploymentType As Label
    Friend WithEvents cboSupervisor As ComboBox
    Friend WithEvents lblSupervisor As Label
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class