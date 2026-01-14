<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AssetIssuanceHistoryFrm
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
        Me.dgvIssuanceHistory = New System.Windows.Forms.DataGridView()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.btnClearFilters = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.cboDepartment = New System.Windows.Forms.ComboBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.txtSearchEmployee = New System.Windows.Forms.TextBox()
        Me.lblSearchEmployee = New System.Windows.Forms.Label()
        Me.txtSearchAsset = New System.Windows.Forms.TextBox()
        Me.lblSearchAsset = New System.Windows.Forms.Label()
        Me.lblFilterTitle = New System.Windows.Forms.Label()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnReturnAsset = New System.Windows.Forms.Button()
        Me.btnViewDetails = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        CType(Me.dgvIssuanceHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFilters.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlContent)
        Me.pnlMain.Controls.Add(Me.pnlFilters)
        Me.pnlMain.Controls.Add(Me.pnlActions)
        Me.pnlMain.Controls.Add(Me.pnlHeader)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.pnlMain.Size = New System.Drawing.Size(1400, 800)
        Me.pnlMain.TabIndex = 0
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.dgvIssuanceHistory)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(27, 360)
        Me.pnlContent.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(1346, 345)
        Me.pnlContent.TabIndex = 3
        '
        'dgvIssuanceHistory
        '
        Me.dgvIssuanceHistory.AllowUserToAddRows = False
        Me.dgvIssuanceHistory.AllowUserToDeleteRows = False
        Me.dgvIssuanceHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvIssuanceHistory.BackgroundColor = System.Drawing.Color.White
        Me.dgvIssuanceHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIssuanceHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvIssuanceHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvIssuanceHistory.ColumnHeadersHeight = 40
        Me.dgvIssuanceHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIssuanceHistory.EnableHeadersVisualStyles = False
        Me.dgvIssuanceHistory.GridColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.dgvIssuanceHistory.Location = New System.Drawing.Point(20, 20)
        Me.dgvIssuanceHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvIssuanceHistory.MultiSelect = False
        Me.dgvIssuanceHistory.Name = "dgvIssuanceHistory"
        Me.dgvIssuanceHistory.ReadOnly = True
        Me.dgvIssuanceHistory.RowHeadersVisible = False
        Me.dgvIssuanceHistory.RowHeadersWidth = 51
        Me.dgvIssuanceHistory.RowTemplate.Height = 35
        Me.dgvIssuanceHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIssuanceHistory.Size = New System.Drawing.Size(1306, 305)
        Me.dgvIssuanceHistory.TabIndex = 0
        '
        'pnlFilters
        '
        Me.pnlFilters.BackColor = System.Drawing.Color.White
        Me.pnlFilters.Controls.Add(Me.btnClearFilters)
        Me.pnlFilters.Controls.Add(Me.btnSearch)
        Me.pnlFilters.Controls.Add(Me.dtpEndDate)
        Me.pnlFilters.Controls.Add(Me.lblEndDate)
        Me.pnlFilters.Controls.Add(Me.dtpStartDate)
        Me.pnlFilters.Controls.Add(Me.lblStartDate)
        Me.pnlFilters.Controls.Add(Me.cboStatus)
        Me.pnlFilters.Controls.Add(Me.lblStatus)
        Me.pnlFilters.Controls.Add(Me.cboDepartment)
        Me.pnlFilters.Controls.Add(Me.lblDepartment)
        Me.pnlFilters.Controls.Add(Me.cboCategory)
        Me.pnlFilters.Controls.Add(Me.lblCategory)
        Me.pnlFilters.Controls.Add(Me.txtSearchEmployee)
        Me.pnlFilters.Controls.Add(Me.lblSearchEmployee)
        Me.pnlFilters.Controls.Add(Me.txtSearchAsset)
        Me.pnlFilters.Controls.Add(Me.lblSearchAsset)
        Me.pnlFilters.Controls.Add(Me.lblFilterTitle)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(27, 155)
        Me.pnlFilters.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlFilters.Size = New System.Drawing.Size(1346, 205)
        Me.pnlFilters.TabIndex = 2
        '
        'btnClearFilters
        '
        Me.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnClearFilters.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearFilters.FlatAppearance.BorderSize = 0
        Me.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearFilters.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnClearFilters.ForeColor = System.Drawing.Color.White
        Me.btnClearFilters.Location = New System.Drawing.Point(1135, 145)
        Me.btnClearFilters.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearFilters.Name = "btnClearFilters"
        Me.btnClearFilters.Size = New System.Drawing.Size(150, 40)
        Me.btnClearFilters.TabIndex = 16
        Me.btnClearFilters.Text = "🔄 Clear Filters"
        Me.btnClearFilters.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(970, 145)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(150, 40)
        Me.btnSearch.TabIndex = 15
        Me.btnSearch.Text = "🔍 Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpEndDate.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(570, 155)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(180, 29)
        Me.dtpEndDate.TabIndex = 14
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblEndDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblEndDate.Location = New System.Drawing.Point(565, 130)
        Me.lblEndDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(80, 23)
        Me.lblEndDate.TabIndex = 13
        Me.lblEndDate.Text = "End Date"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpStartDate.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(375, 155)
        Me.dtpStartDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(180, 29)
        Me.dtpStartDate.TabIndex = 12
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblStartDate.Location = New System.Drawing.Point(370, 130)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(86, 23)
        Me.lblStartDate.TabIndex = 11
        Me.lblStartDate.Text = "Start Date"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(180, 155)
        Me.cboStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(180, 29)
        Me.cboStatus.TabIndex = 10
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(175, 130)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(56, 23)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "Status"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(765, 88)
        Me.cboDepartment.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(240, 29)
        Me.cboDepartment.TabIndex = 8
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblDepartment.Location = New System.Drawing.Point(760, 63)
        Me.lblDepartment.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(102, 23)
        Me.lblDepartment.TabIndex = 7
        Me.lblDepartment.Text = "Department"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(510, 88)
        Me.cboCategory.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(240, 29)
        Me.cboCategory.TabIndex = 6
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblCategory.Location = New System.Drawing.Point(505, 63)
        Me.lblCategory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(124, 23)
        Me.lblCategory.TabIndex = 5
        Me.lblCategory.Text = "Asset Category"
        '
        'txtSearchEmployee
        '
        Me.txtSearchEmployee.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtSearchEmployee.Location = New System.Drawing.Point(255, 88)
        Me.txtSearchEmployee.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearchEmployee.Name = "txtSearchEmployee"
        Me.txtSearchEmployee.Size = New System.Drawing.Size(240, 29)
        Me.txtSearchEmployee.TabIndex = 4
        '
        'lblSearchEmployee
        '
        Me.lblSearchEmployee.AutoSize = True
        Me.lblSearchEmployee.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblSearchEmployee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblSearchEmployee.Location = New System.Drawing.Point(250, 63)
        Me.lblSearchEmployee.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearchEmployee.Name = "lblSearchEmployee"
        Me.lblSearchEmployee.Size = New System.Drawing.Size(135, 23)
        Me.lblSearchEmployee.TabIndex = 3
        Me.lblSearchEmployee.Text = "Employee Name"
        '
        'txtSearchAsset
        '
        Me.txtSearchAsset.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtSearchAsset.Location = New System.Drawing.Point(25, 88)
        Me.txtSearchAsset.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSearchAsset.Name = "txtSearchAsset"
        Me.txtSearchAsset.Size = New System.Drawing.Size(215, 29)
        Me.txtSearchAsset.TabIndex = 2
        '
        'lblSearchAsset
        '
        Me.lblSearchAsset.AutoSize = True
        Me.lblSearchAsset.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblSearchAsset.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblSearchAsset.Location = New System.Drawing.Point(20, 63)
        Me.lblSearchAsset.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearchAsset.Name = "lblSearchAsset"
        Me.lblSearchAsset.Size = New System.Drawing.Size(134, 23)
        Me.lblSearchAsset.TabIndex = 1
        Me.lblSearchAsset.Text = "Asset Tag/Name"
        '
        'lblFilterTitle
        '
        Me.lblFilterTitle.AutoSize = True
        Me.lblFilterTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFilterTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblFilterTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblFilterTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblFilterTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 10)
        Me.lblFilterTitle.Name = "lblFilterTitle"
        Me.lblFilterTitle.Size = New System.Drawing.Size(196, 28)
        Me.lblFilterTitle.TabIndex = 0
        Me.lblFilterTitle.Text = "🔍 Search && Filters"
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.White
        Me.pnlActions.Controls.Add(Me.btnPrint)
        Me.pnlActions.Controls.Add(Me.btnExport)
        Me.pnlActions.Controls.Add(Me.btnReturnAsset)
        Me.pnlActions.Controls.Add(Me.btnViewDetails)
        Me.pnlActions.Controls.Add(Me.btnRefresh)
        Me.pnlActions.Controls.Add(Me.lblRecordCount)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActions.Location = New System.Drawing.Point(27, 705)
        Me.pnlActions.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlActions.Size = New System.Drawing.Size(1346, 70)
        Me.pnlActions.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(1195, 15)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(130, 40)
        Me.btnPrint.TabIndex = 5
        Me.btnPrint.Text = "🖨️ Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(1050, 15)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(130, 40)
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "📥 Export"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'btnReturnAsset
        '
        Me.btnReturnAsset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReturnAsset.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnReturnAsset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReturnAsset.FlatAppearance.BorderSize = 0
        Me.btnReturnAsset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturnAsset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnReturnAsset.ForeColor = System.Drawing.Color.White
        Me.btnReturnAsset.Location = New System.Drawing.Point(855, 15)
        Me.btnReturnAsset.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReturnAsset.Name = "btnReturnAsset"
        Me.btnReturnAsset.Size = New System.Drawing.Size(180, 40)
        Me.btnReturnAsset.TabIndex = 3
        Me.btnReturnAsset.Text = "↩️ Return Asset"
        Me.btnReturnAsset.UseVisualStyleBackColor = False
        '
        'btnViewDetails
        '
        Me.btnViewDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnViewDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewDetails.FlatAppearance.BorderSize = 0
        Me.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewDetails.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnViewDetails.ForeColor = System.Drawing.Color.White
        Me.btnViewDetails.Location = New System.Drawing.Point(710, 15)
        Me.btnViewDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewDetails.Name = "btnViewDetails"
        Me.btnViewDetails.Size = New System.Drawing.Size(130, 40)
        Me.btnViewDetails.TabIndex = 2
        Me.btnViewDetails.Text = "👁️ Details"
        Me.btnViewDetails.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(25, 15)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(130, 40)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "🔄 Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblRecordCount.Location = New System.Drawing.Point(170, 25)
        Me.lblRecordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(137, 23)
        Me.lblRecordCount.TabIndex = 0
        Me.lblRecordCount.Text = "Total Records: 0"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblSubtitle)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(27, 25)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(27, 25, 27, 25)
        Me.pnlHeader.Size = New System.Drawing.Size(1346, 130)
        Me.pnlHeader.TabIndex = 0
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(27, 71)
        Me.lblSubtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(592, 23)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "View complete history of asset issuances including active and returned items"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(27, 25)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(433, 46)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "📜 Asset Issuance History"
        '
        'AssetIssuanceHistoryFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1400, 800)
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AssetIssuanceHistoryFrm"
        Me.Text = "Asset Issuance History"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        CType(Me.dgvIssuanceHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlActions.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblRecordCount As Label
    Friend WithEvents btnViewDetails As Button
    Friend WithEvents btnReturnAsset As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents lblFilterTitle As Label
    Friend WithEvents txtSearchAsset As TextBox
    Friend WithEvents lblSearchAsset As Label
    Friend WithEvents txtSearchEmployee As TextBox
    Friend WithEvents lblSearchEmployee As Label
    Friend WithEvents cboCategory As ComboBox
    Friend WithEvents lblCategory As Label
    Friend WithEvents cboDepartment As ComboBox
    Friend WithEvents lblDepartment As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblStartDate As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents lblEndDate As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnClearFilters As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents dgvIssuanceHistory As DataGridView

End Class