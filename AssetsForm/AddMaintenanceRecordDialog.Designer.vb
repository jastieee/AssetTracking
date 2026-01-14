<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddMaintenanceRecordDialog
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
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.grpNextMaintenance = New System.Windows.Forms.GroupBox()
        Me.chkScheduleNext = New System.Windows.Forms.CheckBox()
        Me.dtpNextMaintenance = New System.Windows.Forms.DateTimePicker()
        Me.lblNextMaintenance = New System.Windows.Forms.Label()
        Me.grpMaintenanceDetails = New System.Windows.Forms.GroupBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.lblCost = New System.Windows.Forms.Label()
        Me.txtPerformedBy = New System.Windows.Forms.TextBox()
        Me.lblPerformedBy = New System.Windows.Forms.Label()
        Me.dtpMaintenanceDate = New System.Windows.Forms.DateTimePicker()
        Me.lblMaintenanceDate = New System.Windows.Forms.Label()
        Me.cboMaintenanceType = New System.Windows.Forms.ComboBox()
        Me.lblMaintenanceType = New System.Windows.Forms.Label()
        Me.grpAssetSelection = New System.Windows.Forms.GroupBox()
        Me.lblAssetInfo = New System.Windows.Forms.Label()
        Me.btnSearchAsset = New System.Windows.Forms.Button()
        Me.txtAssetTag = New System.Windows.Forms.TextBox()
        Me.lblAssetTag = New System.Windows.Forms.Label()
        Me.pnlButtons = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.grpNextMaintenance.SuspendLayout()
        Me.grpMaintenanceDetails.SuspendLayout()
        Me.grpAssetSelection.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlContent)
        Me.pnlMain.Controls.Add(Me.pnlButtons)
        Me.pnlMain.Controls.Add(Me.pnlHeader)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlMain.Size = New System.Drawing.Size(700, 750)
        Me.pnlMain.TabIndex = 0
        '
        'pnlContent
        '
        Me.pnlContent.AutoScroll = True
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.grpNextMaintenance)
        Me.pnlContent.Controls.Add(Me.grpMaintenanceDetails)
        Me.pnlContent.Controls.Add(Me.grpAssetSelection)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(3, 103)
        Me.pnlContent.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(694, 574)
        Me.pnlContent.TabIndex = 2
        '
        'grpNextMaintenance
        '
        Me.grpNextMaintenance.Controls.Add(Me.chkScheduleNext)
        Me.grpNextMaintenance.Controls.Add(Me.dtpNextMaintenance)
        Me.grpNextMaintenance.Controls.Add(Me.lblNextMaintenance)
        Me.grpNextMaintenance.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpNextMaintenance.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpNextMaintenance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grpNextMaintenance.Location = New System.Drawing.Point(20, 470)
        Me.grpNextMaintenance.Margin = New System.Windows.Forms.Padding(4)
        Me.grpNextMaintenance.Name = "grpNextMaintenance"
        Me.grpNextMaintenance.Padding = New System.Windows.Forms.Padding(15)
        Me.grpNextMaintenance.Size = New System.Drawing.Size(633, 130)
        Me.grpNextMaintenance.TabIndex = 2
        Me.grpNextMaintenance.TabStop = False
        Me.grpNextMaintenance.Text = "📅 Schedule Next Maintenance"
        '
        'chkScheduleNext
        '
        Me.chkScheduleNext.AutoSize = True
        Me.chkScheduleNext.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.chkScheduleNext.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.chkScheduleNext.Location = New System.Drawing.Point(20, 35)
        Me.chkScheduleNext.Margin = New System.Windows.Forms.Padding(4)
        Me.chkScheduleNext.Name = "chkScheduleNext"
        Me.chkScheduleNext.Size = New System.Drawing.Size(251, 27)
        Me.chkScheduleNext.TabIndex = 0
        Me.chkScheduleNext.Text = "Schedule next maintenance?"
        Me.chkScheduleNext.UseVisualStyleBackColor = True
        '
        'dtpNextMaintenance
        '
        Me.dtpNextMaintenance.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpNextMaintenance.Enabled = False
        Me.dtpNextMaintenance.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpNextMaintenance.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNextMaintenance.Location = New System.Drawing.Point(240, 82)
        Me.dtpNextMaintenance.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpNextMaintenance.Name = "dtpNextMaintenance"
        Me.dtpNextMaintenance.Size = New System.Drawing.Size(380, 29)
        Me.dtpNextMaintenance.TabIndex = 2
        '
        'lblNextMaintenance
        '
        Me.lblNextMaintenance.AutoSize = True
        Me.lblNextMaintenance.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblNextMaintenance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblNextMaintenance.Location = New System.Drawing.Point(20, 86)
        Me.lblNextMaintenance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNextMaintenance.Name = "lblNextMaintenance"
        Me.lblNextMaintenance.Size = New System.Drawing.Size(195, 23)
        Me.lblNextMaintenance.TabIndex = 1
        Me.lblNextMaintenance.Text = "Next Maintenance Date:"
        '
        'grpMaintenanceDetails
        '
        Me.grpMaintenanceDetails.Controls.Add(Me.txtDescription)
        Me.grpMaintenanceDetails.Controls.Add(Me.lblDescription)
        Me.grpMaintenanceDetails.Controls.Add(Me.txtCost)
        Me.grpMaintenanceDetails.Controls.Add(Me.lblCost)
        Me.grpMaintenanceDetails.Controls.Add(Me.txtPerformedBy)
        Me.grpMaintenanceDetails.Controls.Add(Me.lblPerformedBy)
        Me.grpMaintenanceDetails.Controls.Add(Me.dtpMaintenanceDate)
        Me.grpMaintenanceDetails.Controls.Add(Me.lblMaintenanceDate)
        Me.grpMaintenanceDetails.Controls.Add(Me.cboMaintenanceType)
        Me.grpMaintenanceDetails.Controls.Add(Me.lblMaintenanceType)
        Me.grpMaintenanceDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpMaintenanceDetails.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpMaintenanceDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grpMaintenanceDetails.Location = New System.Drawing.Point(20, 150)
        Me.grpMaintenanceDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.grpMaintenanceDetails.Name = "grpMaintenanceDetails"
        Me.grpMaintenanceDetails.Padding = New System.Windows.Forms.Padding(15)
        Me.grpMaintenanceDetails.Size = New System.Drawing.Size(633, 320)
        Me.grpMaintenanceDetails.TabIndex = 1
        Me.grpMaintenanceDetails.TabStop = False
        Me.grpMaintenanceDetails.Text = "🔧 Maintenance Information"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtDescription.Location = New System.Drawing.Point(20, 240)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(600, 60)
        Me.txtDescription.TabIndex = 9
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblDescription.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblDescription.Location = New System.Drawing.Point(20, 215)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(174, 23)
        Me.lblDescription.TabIndex = 8
        Me.lblDescription.Text = "Description / Notes: *"
        '
        'txtCost
        '
        Me.txtCost.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtCost.Location = New System.Drawing.Point(350, 170)
        Me.txtCost.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(270, 29)
        Me.txtCost.TabIndex = 7
        '
        'lblCost
        '
        Me.lblCost.AutoSize = True
        Me.lblCost.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblCost.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblCost.Location = New System.Drawing.Point(345, 145)
        Me.lblCost.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(163, 23)
        Me.lblCost.TabIndex = 6
        Me.lblCost.Text = "Cost (PHP): optional"
        '
        'txtPerformedBy
        '
        Me.txtPerformedBy.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtPerformedBy.Location = New System.Drawing.Point(20, 170)
        Me.txtPerformedBy.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPerformedBy.Name = "txtPerformedBy"
        Me.txtPerformedBy.Size = New System.Drawing.Size(310, 29)
        Me.txtPerformedBy.TabIndex = 5
        '
        'lblPerformedBy
        '
        Me.lblPerformedBy.AutoSize = True
        Me.lblPerformedBy.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblPerformedBy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblPerformedBy.Location = New System.Drawing.Point(20, 145)
        Me.lblPerformedBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPerformedBy.Name = "lblPerformedBy"
        Me.lblPerformedBy.Size = New System.Drawing.Size(257, 23)
        Me.lblPerformedBy.TabIndex = 4
        Me.lblPerformedBy.Text = "Performed By (Name/Company):"
        '
        'dtpMaintenanceDate
        '
        Me.dtpMaintenanceDate.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpMaintenanceDate.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpMaintenanceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMaintenanceDate.Location = New System.Drawing.Point(350, 100)
        Me.dtpMaintenanceDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpMaintenanceDate.Name = "dtpMaintenanceDate"
        Me.dtpMaintenanceDate.Size = New System.Drawing.Size(270, 29)
        Me.dtpMaintenanceDate.TabIndex = 3
        '
        'lblMaintenanceDate
        '
        Me.lblMaintenanceDate.AutoSize = True
        Me.lblMaintenanceDate.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblMaintenanceDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblMaintenanceDate.Location = New System.Drawing.Point(345, 75)
        Me.lblMaintenanceDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMaintenanceDate.Name = "lblMaintenanceDate"
        Me.lblMaintenanceDate.Size = New System.Drawing.Size(166, 23)
        Me.lblMaintenanceDate.TabIndex = 2
        Me.lblMaintenanceDate.Text = "Maintenance Date: *"
        '
        'cboMaintenanceType
        '
        Me.cboMaintenanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaintenanceType.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboMaintenanceType.FormattingEnabled = True
        Me.cboMaintenanceType.Items.AddRange(New Object() {"Preventive Maintenance", "Corrective Maintenance", "Inspection", "Repair", "Replacement", "Calibration", "Cleaning", "Testing", "Upgrade", "Emergency Repair", "Other"})
        Me.cboMaintenanceType.Location = New System.Drawing.Point(20, 100)
        Me.cboMaintenanceType.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMaintenanceType.Name = "cboMaintenanceType"
        Me.cboMaintenanceType.Size = New System.Drawing.Size(310, 29)
        Me.cboMaintenanceType.TabIndex = 1
        '
        'lblMaintenanceType
        '
        Me.lblMaintenanceType.AutoSize = True
        Me.lblMaintenanceType.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblMaintenanceType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblMaintenanceType.Location = New System.Drawing.Point(20, 75)
        Me.lblMaintenanceType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMaintenanceType.Name = "lblMaintenanceType"
        Me.lblMaintenanceType.Size = New System.Drawing.Size(165, 23)
        Me.lblMaintenanceType.TabIndex = 0
        Me.lblMaintenanceType.Text = "Maintenance Type: *"
        '
        'grpAssetSelection
        '
        Me.grpAssetSelection.Controls.Add(Me.lblAssetInfo)
        Me.grpAssetSelection.Controls.Add(Me.btnSearchAsset)
        Me.grpAssetSelection.Controls.Add(Me.txtAssetTag)
        Me.grpAssetSelection.Controls.Add(Me.lblAssetTag)
        Me.grpAssetSelection.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpAssetSelection.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpAssetSelection.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.grpAssetSelection.Location = New System.Drawing.Point(20, 20)
        Me.grpAssetSelection.Margin = New System.Windows.Forms.Padding(4)
        Me.grpAssetSelection.Name = "grpAssetSelection"
        Me.grpAssetSelection.Padding = New System.Windows.Forms.Padding(15)
        Me.grpAssetSelection.Size = New System.Drawing.Size(633, 130)
        Me.grpAssetSelection.TabIndex = 0
        Me.grpAssetSelection.TabStop = False
        Me.grpAssetSelection.Text = "📦 Asset Selection"
        '
        'lblAssetInfo
        '
        Me.lblAssetInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblAssetInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblAssetInfo.Location = New System.Drawing.Point(20, 95)
        Me.lblAssetInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAssetInfo.Name = "lblAssetInfo"
        Me.lblAssetInfo.Size = New System.Drawing.Size(600, 23)
        Me.lblAssetInfo.TabIndex = 3
        Me.lblAssetInfo.Text = "Asset info will appear here after selection..."
        '
        'btnSearchAsset
        '
        Me.btnSearchAsset.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSearchAsset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearchAsset.FlatAppearance.BorderSize = 0
        Me.btnSearchAsset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchAsset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSearchAsset.ForeColor = System.Drawing.Color.White
        Me.btnSearchAsset.Location = New System.Drawing.Point(475, 55)
        Me.btnSearchAsset.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearchAsset.Name = "btnSearchAsset"
        Me.btnSearchAsset.Size = New System.Drawing.Size(145, 32)
        Me.btnSearchAsset.TabIndex = 2
        Me.btnSearchAsset.Text = "🔍 Search Asset"
        Me.btnSearchAsset.UseVisualStyleBackColor = False
        '
        'txtAssetTag
        '
        Me.txtAssetTag.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtAssetTag.Location = New System.Drawing.Point(20, 57)
        Me.txtAssetTag.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAssetTag.Name = "txtAssetTag"
        Me.txtAssetTag.Size = New System.Drawing.Size(440, 29)
        Me.txtAssetTag.TabIndex = 1
        '
        'lblAssetTag
        '
        Me.lblAssetTag.AutoSize = True
        Me.lblAssetTag.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblAssetTag.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblAssetTag.Location = New System.Drawing.Point(20, 32)
        Me.lblAssetTag.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAssetTag.Name = "lblAssetTag"
        Me.lblAssetTag.Size = New System.Drawing.Size(214, 23)
        Me.lblAssetTag.TabIndex = 0
        Me.lblAssetTag.Text = "Asset Tag or Asset Name: *"
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.White
        Me.pnlButtons.Controls.Add(Me.btnCancel)
        Me.pnlButtons.Controls.Add(Me.btnSave)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(3, 677)
        Me.pnlButtons.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlButtons.Size = New System.Drawing.Size(694, 70)
        Me.pnlButtons.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(524, 15)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "✖️ Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(360, 15)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 40)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "💾 Save Record"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(3, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.pnlHeader.Size = New System.Drawing.Size(694, 100)
        Me.pnlHeader.TabIndex = 0
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.White
        Me.lblSubtitle.Location = New System.Drawing.Point(20, 52)
        Me.lblSubtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(381, 23)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Record maintenance activities and schedule next"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(450, 37)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "➕ Add New Maintenance Record"
        '
        'AddMaintenanceRecordDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 750)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddMaintenanceRecordDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Maintenance Record"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.grpNextMaintenance.ResumeLayout(False)
        Me.grpNextMaintenance.PerformLayout()
        Me.grpMaintenanceDetails.ResumeLayout(False)
        Me.grpMaintenanceDetails.PerformLayout()
        Me.grpAssetSelection.ResumeLayout(False)
        Me.grpAssetSelection.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlButtons As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents grpAssetSelection As GroupBox
    Friend WithEvents lblAssetTag As Label
    Friend WithEvents txtAssetTag As TextBox
    Friend WithEvents btnSearchAsset As Button
    Friend WithEvents lblAssetInfo As Label
    Friend WithEvents grpMaintenanceDetails As GroupBox
    Friend WithEvents lblMaintenanceType As Label
    Friend WithEvents cboMaintenanceType As ComboBox
    Friend WithEvents lblMaintenanceDate As Label
    Friend WithEvents dtpMaintenanceDate As DateTimePicker
    Friend WithEvents lblPerformedBy As Label
    Friend WithEvents txtPerformedBy As TextBox
    Friend WithEvents lblCost As Label
    Friend WithEvents txtCost As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents grpNextMaintenance As GroupBox
    Friend WithEvents chkScheduleNext As CheckBox
    Friend WithEvents lblNextMaintenance As Label
    Friend WithEvents dtpNextMaintenance As DateTimePicker

End Class