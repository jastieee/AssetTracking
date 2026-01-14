<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeDetailsViewFrm
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
        Me.grpAssetHistory = New System.Windows.Forms.GroupBox()
        Me.dgvAssetHistory = New System.Windows.Forms.DataGridView()
        Me.grpConsumableHistory = New System.Windows.Forms.GroupBox()
        Me.dgvConsumableHistory = New System.Windows.Forms.DataGridView()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.grpActions = New System.Windows.Forms.GroupBox()
        Me.btnPrintQR = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.grpQRCode = New System.Windows.Forms.GroupBox()
        Me.picQRCode = New System.Windows.Forms.PictureBox()
        Me.grpEmployeeInfo = New System.Windows.Forms.GroupBox()
        Me.lblSupervisorValue = New System.Windows.Forms.Label()
        Me.lblSupervisor = New System.Windows.Forms.Label()
        Me.lblEmploymentTypeValue = New System.Windows.Forms.Label()
        Me.lblEmploymentType = New System.Windows.Forms.Label()
        Me.lblStatusValue = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblHireDateValue = New System.Windows.Forms.Label()
        Me.lblHireDate = New System.Windows.Forms.Label()
        Me.lblPositionValue = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblDepartmentValue = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblPhoneValue = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblEmailValue = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblFullNameValue = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblEmployeeNumberValue = New System.Windows.Forms.Label()
        Me.lblEmployeeNumber = New System.Windows.Forms.Label()
        Me.pnlTop.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.grpAssetHistory.SuspendLayout()
        CType(Me.dgvAssetHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpConsumableHistory.SuspendLayout()
        CType(Me.dgvConsumableHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLeft.SuspendLayout()
        Me.grpActions.SuspendLayout()
        Me.grpQRCode.SuspendLayout()
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpEmployeeInfo.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(247, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "👤 Employee Details"
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
        Me.pnlRight.Controls.Add(Me.grpAssetHistory)
        Me.pnlRight.Controls.Add(Me.grpConsumableHistory)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRight.Location = New System.Drawing.Point(470, 20)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(610, 600)
        Me.pnlRight.TabIndex = 1
        '
        'grpAssetHistory
        '
        Me.grpAssetHistory.Controls.Add(Me.dgvAssetHistory)
        Me.grpAssetHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpAssetHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpAssetHistory.Location = New System.Drawing.Point(0, 0)
        Me.grpAssetHistory.Name = "grpAssetHistory"
        Me.grpAssetHistory.Padding = New System.Windows.Forms.Padding(10)
        Me.grpAssetHistory.Size = New System.Drawing.Size(610, 300)
        Me.grpAssetHistory.TabIndex = 1
        Me.grpAssetHistory.TabStop = False
        Me.grpAssetHistory.Text = "📦 Asset Issuance History"
        '
        'dgvAssetHistory
        '
        Me.dgvAssetHistory.AllowUserToAddRows = False
        Me.dgvAssetHistory.AllowUserToDeleteRows = False
        Me.dgvAssetHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAssetHistory.BackgroundColor = System.Drawing.Color.White
        Me.dgvAssetHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAssetHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAssetHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAssetHistory.Location = New System.Drawing.Point(10, 30)
        Me.dgvAssetHistory.Name = "dgvAssetHistory"
        Me.dgvAssetHistory.ReadOnly = True
        Me.dgvAssetHistory.RowHeadersVisible = False
        Me.dgvAssetHistory.RowHeadersWidth = 51
        Me.dgvAssetHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAssetHistory.Size = New System.Drawing.Size(590, 260)
        Me.dgvAssetHistory.TabIndex = 0
        '
        'grpConsumableHistory
        '
        Me.grpConsumableHistory.Controls.Add(Me.dgvConsumableHistory)
        Me.grpConsumableHistory.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpConsumableHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpConsumableHistory.Location = New System.Drawing.Point(0, 300)
        Me.grpConsumableHistory.Name = "grpConsumableHistory"
        Me.grpConsumableHistory.Padding = New System.Windows.Forms.Padding(10)
        Me.grpConsumableHistory.Size = New System.Drawing.Size(610, 300)
        Me.grpConsumableHistory.TabIndex = 0
        Me.grpConsumableHistory.TabStop = False
        Me.grpConsumableHistory.Text = "📋 Consumable Issuance History"
        '
        'dgvConsumableHistory
        '
        Me.dgvConsumableHistory.AllowUserToAddRows = False
        Me.dgvConsumableHistory.AllowUserToDeleteRows = False
        Me.dgvConsumableHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvConsumableHistory.BackgroundColor = System.Drawing.Color.White
        Me.dgvConsumableHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvConsumableHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsumableHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumableHistory.Location = New System.Drawing.Point(10, 30)
        Me.dgvConsumableHistory.Name = "dgvConsumableHistory"
        Me.dgvConsumableHistory.ReadOnly = True
        Me.dgvConsumableHistory.RowHeadersVisible = False
        Me.dgvConsumableHistory.RowHeadersWidth = 51
        Me.dgvConsumableHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConsumableHistory.Size = New System.Drawing.Size(590, 260)
        Me.dgvConsumableHistory.TabIndex = 0
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.grpActions)
        Me.pnlLeft.Controls.Add(Me.grpQRCode)
        Me.pnlLeft.Controls.Add(Me.grpEmployeeInfo)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(20, 20)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(450, 600)
        Me.pnlLeft.TabIndex = 0
        '
        'grpActions
        '
        Me.grpActions.Controls.Add(Me.btnPrintQR)
        Me.grpActions.Controls.Add(Me.btnDelete)
        Me.grpActions.Controls.Add(Me.btnEdit)
        Me.grpActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpActions.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpActions.Location = New System.Drawing.Point(0, 520)
        Me.grpActions.Name = "grpActions"
        Me.grpActions.Padding = New System.Windows.Forms.Padding(10)
        Me.grpActions.Size = New System.Drawing.Size(450, 80)
        Me.grpActions.TabIndex = 2
        Me.grpActions.TabStop = False
        Me.grpActions.Text = "⚙️ Actions"
        '
        'btnPrintQR
        '
        Me.btnPrintQR.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btnPrintQR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrintQR.FlatAppearance.BorderSize = 0
        Me.btnPrintQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintQR.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintQR.ForeColor = System.Drawing.Color.White
        Me.btnPrintQR.Location = New System.Drawing.Point(300, 30)
        Me.btnPrintQR.Name = "btnPrintQR"
        Me.btnPrintQR.Size = New System.Drawing.Size(130, 35)
        Me.btnPrintQR.TabIndex = 2
        Me.btnPrintQR.Text = "🖨️ Print QR"
        Me.btnPrintQR.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(155, 30)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(130, 35)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "🗑️ Delete"
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
        Me.btnEdit.Location = New System.Drawing.Point(10, 30)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(130, 35)
        Me.btnEdit.TabIndex = 0
        Me.btnEdit.Text = "✏️ Edit Employee"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'grpQRCode
        '
        Me.grpQRCode.Controls.Add(Me.picQRCode)
        Me.grpQRCode.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpQRCode.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpQRCode.Location = New System.Drawing.Point(0, 320)
        Me.grpQRCode.Name = "grpQRCode"
        Me.grpQRCode.Padding = New System.Windows.Forms.Padding(10)
        Me.grpQRCode.Size = New System.Drawing.Size(450, 190)
        Me.grpQRCode.TabIndex = 1
        Me.grpQRCode.TabStop = False
        Me.grpQRCode.Text = "📱 QR Code"
        '
        'picQRCode
        '
        Me.picQRCode.BackColor = System.Drawing.Color.White
        Me.picQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picQRCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picQRCode.Location = New System.Drawing.Point(10, 30)
        Me.picQRCode.Name = "picQRCode"
        Me.picQRCode.Size = New System.Drawing.Size(430, 150)
        Me.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picQRCode.TabIndex = 0
        Me.picQRCode.TabStop = False
        '
        'grpEmployeeInfo
        '
        Me.grpEmployeeInfo.Controls.Add(Me.lblSupervisorValue)
        Me.grpEmployeeInfo.Controls.Add(Me.lblSupervisor)
        Me.grpEmployeeInfo.Controls.Add(Me.lblEmploymentTypeValue)
        Me.grpEmployeeInfo.Controls.Add(Me.lblEmploymentType)
        Me.grpEmployeeInfo.Controls.Add(Me.lblStatusValue)
        Me.grpEmployeeInfo.Controls.Add(Me.lblStatus)
        Me.grpEmployeeInfo.Controls.Add(Me.lblHireDateValue)
        Me.grpEmployeeInfo.Controls.Add(Me.lblHireDate)
        Me.grpEmployeeInfo.Controls.Add(Me.lblPositionValue)
        Me.grpEmployeeInfo.Controls.Add(Me.lblPosition)
        Me.grpEmployeeInfo.Controls.Add(Me.lblDepartmentValue)
        Me.grpEmployeeInfo.Controls.Add(Me.lblDepartment)
        Me.grpEmployeeInfo.Controls.Add(Me.lblPhoneValue)
        Me.grpEmployeeInfo.Controls.Add(Me.lblPhone)
        Me.grpEmployeeInfo.Controls.Add(Me.lblEmailValue)
        Me.grpEmployeeInfo.Controls.Add(Me.lblEmail)
        Me.grpEmployeeInfo.Controls.Add(Me.lblFullNameValue)
        Me.grpEmployeeInfo.Controls.Add(Me.lblFullName)
        Me.grpEmployeeInfo.Controls.Add(Me.lblEmployeeNumberValue)
        Me.grpEmployeeInfo.Controls.Add(Me.lblEmployeeNumber)
        Me.grpEmployeeInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpEmployeeInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpEmployeeInfo.Location = New System.Drawing.Point(0, 0)
        Me.grpEmployeeInfo.Name = "grpEmployeeInfo"
        Me.grpEmployeeInfo.Padding = New System.Windows.Forms.Padding(10)
        Me.grpEmployeeInfo.Size = New System.Drawing.Size(450, 320)
        Me.grpEmployeeInfo.TabIndex = 0
        Me.grpEmployeeInfo.TabStop = False
        Me.grpEmployeeInfo.Text = "ℹ️ Employee Information"
        '
        'lblSupervisorValue
        '
        Me.lblSupervisorValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblSupervisorValue.Location = New System.Drawing.Point(160, 280)
        Me.lblSupervisorValue.Name = "lblSupervisorValue"
        Me.lblSupervisorValue.Size = New System.Drawing.Size(280, 20)
        Me.lblSupervisorValue.TabIndex = 19
        Me.lblSupervisorValue.Text = "-"
        '
        'lblSupervisor
        '
        Me.lblSupervisor.AutoSize = True
        Me.lblSupervisor.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSupervisor.Location = New System.Drawing.Point(15, 280)
        Me.lblSupervisor.Name = "lblSupervisor"
        Me.lblSupervisor.Size = New System.Drawing.Size(80, 19)
        Me.lblSupervisor.TabIndex = 18
        Me.lblSupervisor.Text = "Supervisor:"
        '
        'lblEmploymentTypeValue
        '
        Me.lblEmploymentTypeValue.AutoSize = True
        Me.lblEmploymentTypeValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblEmploymentTypeValue.Location = New System.Drawing.Point(160, 255)
        Me.lblEmploymentTypeValue.Name = "lblEmploymentTypeValue"
        Me.lblEmploymentTypeValue.Size = New System.Drawing.Size(15, 19)
        Me.lblEmploymentTypeValue.TabIndex = 17
        Me.lblEmploymentTypeValue.Text = "-"
        '
        'lblEmploymentType
        '
        Me.lblEmploymentType.AutoSize = True
        Me.lblEmploymentType.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmploymentType.Location = New System.Drawing.Point(15, 255)
        Me.lblEmploymentType.Name = "lblEmploymentType"
        Me.lblEmploymentType.Size = New System.Drawing.Size(133, 19)
        Me.lblEmploymentType.TabIndex = 16
        Me.lblEmploymentType.Text = "Employment Type:"
        '
        'lblStatusValue
        '
        Me.lblStatusValue.AutoSize = True
        Me.lblStatusValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblStatusValue.Location = New System.Drawing.Point(160, 230)
        Me.lblStatusValue.Name = "lblStatusValue"
        Me.lblStatusValue.Size = New System.Drawing.Size(15, 19)
        Me.lblStatusValue.TabIndex = 15
        Me.lblStatusValue.Text = "-"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.Location = New System.Drawing.Point(15, 230)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(53, 19)
        Me.lblStatus.TabIndex = 14
        Me.lblStatus.Text = "Status:"
        '
        'lblHireDateValue
        '
        Me.lblHireDateValue.AutoSize = True
        Me.lblHireDateValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblHireDateValue.Location = New System.Drawing.Point(160, 205)
        Me.lblHireDateValue.Name = "lblHireDateValue"
        Me.lblHireDateValue.Size = New System.Drawing.Size(15, 19)
        Me.lblHireDateValue.TabIndex = 13
        Me.lblHireDateValue.Text = "-"
        '
        'lblHireDate
        '
        Me.lblHireDate.AutoSize = True
        Me.lblHireDate.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblHireDate.Location = New System.Drawing.Point(15, 205)
        Me.lblHireDate.Name = "lblHireDate"
        Me.lblHireDate.Size = New System.Drawing.Size(75, 19)
        Me.lblHireDate.TabIndex = 12
        Me.lblHireDate.Text = "Hire Date:"
        '
        'lblPositionValue
        '
        Me.lblPositionValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblPositionValue.Location = New System.Drawing.Point(160, 180)
        Me.lblPositionValue.Name = "lblPositionValue"
        Me.lblPositionValue.Size = New System.Drawing.Size(280, 20)
        Me.lblPositionValue.TabIndex = 11
        Me.lblPositionValue.Text = "-"
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = True
        Me.lblPosition.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPosition.Location = New System.Drawing.Point(15, 180)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(67, 19)
        Me.lblPosition.TabIndex = 10
        Me.lblPosition.Text = "Position:"
        '
        'lblDepartmentValue
        '
        Me.lblDepartmentValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblDepartmentValue.Location = New System.Drawing.Point(160, 155)
        Me.lblDepartmentValue.Name = "lblDepartmentValue"
        Me.lblDepartmentValue.Size = New System.Drawing.Size(280, 20)
        Me.lblDepartmentValue.TabIndex = 9
        Me.lblDepartmentValue.Text = "-"
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepartment.Location = New System.Drawing.Point(15, 155)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(93, 19)
        Me.lblDepartment.TabIndex = 8
        Me.lblDepartment.Text = "Department:"
        '
        'lblPhoneValue
        '
        Me.lblPhoneValue.AutoSize = True
        Me.lblPhoneValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblPhoneValue.Location = New System.Drawing.Point(160, 130)
        Me.lblPhoneValue.Name = "lblPhoneValue"
        Me.lblPhoneValue.Size = New System.Drawing.Size(15, 19)
        Me.lblPhoneValue.TabIndex = 7
        Me.lblPhoneValue.Text = "-"
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPhone.Location = New System.Drawing.Point(15, 130)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(54, 19)
        Me.lblPhone.TabIndex = 6
        Me.lblPhone.Text = "Phone:"
        '
        'lblEmailValue
        '
        Me.lblEmailValue.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblEmailValue.Location = New System.Drawing.Point(160, 105)
        Me.lblEmailValue.Name = "lblEmailValue"
        Me.lblEmailValue.Size = New System.Drawing.Size(280, 20)
        Me.lblEmailValue.TabIndex = 5
        Me.lblEmailValue.Text = "-"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmail.Location = New System.Drawing.Point(15, 105)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(49, 19)
        Me.lblEmail.TabIndex = 4
        Me.lblEmail.Text = "Email:"
        '
        'lblFullNameValue
        '
        Me.lblFullNameValue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblFullNameValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblFullNameValue.Location = New System.Drawing.Point(160, 75)
        Me.lblFullNameValue.Name = "lblFullNameValue"
        Me.lblFullNameValue.Size = New System.Drawing.Size(280, 25)
        Me.lblFullNameValue.TabIndex = 3
        Me.lblFullNameValue.Text = "-"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblFullName.Location = New System.Drawing.Point(15, 80)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(80, 19)
        Me.lblFullName.TabIndex = 2
        Me.lblFullName.Text = "Full Name:"
        '
        'lblEmployeeNumberValue
        '
        Me.lblEmployeeNumberValue.AutoSize = True
        Me.lblEmployeeNumberValue.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeNumberValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblEmployeeNumberValue.Location = New System.Drawing.Point(160, 35)
        Me.lblEmployeeNumberValue.Name = "lblEmployeeNumberValue"
        Me.lblEmployeeNumberValue.Size = New System.Drawing.Size(19, 28)
        Me.lblEmployeeNumberValue.TabIndex = 1
        Me.lblEmployeeNumberValue.Text = "-"
        '
        'lblEmployeeNumber
        '
        Me.lblEmployeeNumber.AutoSize = True
        Me.lblEmployeeNumber.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeNumber.Location = New System.Drawing.Point(15, 40)
        Me.lblEmployeeNumber.Name = "lblEmployeeNumber"
        Me.lblEmployeeNumber.Size = New System.Drawing.Size(77, 19)
        Me.lblEmployeeNumber.TabIndex = 0
        Me.lblEmployeeNumber.Text = "Emp. No.:"
        '
        'EmployeeDetailsViewFrm
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
        Me.Name = "EmployeeDetailsViewFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Employee Details"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        Me.grpAssetHistory.ResumeLayout(False)
        CType(Me.dgvAssetHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpConsumableHistory.ResumeLayout(False)
        CType(Me.dgvConsumableHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLeft.ResumeLayout(False)
        Me.grpActions.ResumeLayout(False)
        Me.grpQRCode.ResumeLayout(False)
        CType(Me.picQRCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpEmployeeInfo.ResumeLayout(False)
        Me.grpEmployeeInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents grpEmployeeInfo As GroupBox
    Friend WithEvents lblEmployeeNumber As Label
    Friend WithEvents lblEmployeeNumberValue As Label
    Friend WithEvents lblFullName As Label
    Friend WithEvents lblFullNameValue As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblEmailValue As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblPhoneValue As Label
    Friend WithEvents lblDepartment As Label
    Friend WithEvents lblDepartmentValue As Label
    Friend WithEvents lblPosition As Label
    Friend WithEvents lblPositionValue As Label
    Friend WithEvents lblHireDate As Label
    Friend WithEvents lblHireDateValue As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblStatusValue As Label
    Friend WithEvents lblEmploymentType As Label
    Friend WithEvents lblEmploymentTypeValue As Label
    Friend WithEvents lblSupervisor As Label
    Friend WithEvents lblSupervisorValue As Label
    Friend WithEvents grpQRCode As GroupBox
    Friend WithEvents picQRCode As PictureBox
    Friend WithEvents grpActions As GroupBox
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnPrintQR As Button
    Friend WithEvents pnlRight As Panel
    Friend WithEvents grpConsumableHistory As GroupBox
    Friend WithEvents dgvConsumableHistory As DataGridView
    Friend WithEvents grpAssetHistory As GroupBox
    Friend WithEvents dgvAssetHistory As DataGridView
End Class