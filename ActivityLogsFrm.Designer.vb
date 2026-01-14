<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ActivityLogsFrm
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
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnClearLogs = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.btnClearFilters = New System.Windows.Forms.Button()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.cboTableName = New System.Windows.Forms.ComboBox()
        Me.lblTableName = New System.Windows.Forms.Label()
        Me.cboActionType = New System.Windows.Forms.ComboBox()
        Me.lblActionType = New System.Windows.Forms.Label()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.pnlDataGrid = New System.Windows.Forms.Panel()
        Me.dgvActivityLogs = New System.Windows.Forms.DataGridView()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnViewDetails = New System.Windows.Forms.Button()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.pnlTop.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        Me.pnlDataGrid.SuspendLayout()
        CType(Me.dgvActivityLogs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.White
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.pnlTop.Size = New System.Drawing.Size(1200, 70)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(250, 41)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "📋 Activity Logs"
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.White
        Me.pnlActions.Controls.Add(Me.btnExport)
        Me.pnlActions.Controls.Add(Me.btnClearLogs)
        Me.pnlActions.Controls.Add(Me.btnRefresh)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlActions.Location = New System.Drawing.Point(0, 70)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlActions.Size = New System.Drawing.Size(1200, 60)
        Me.pnlActions.TabIndex = 1
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(260, 10)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(120, 40)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "📊 Export"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'btnClearLogs
        '
        Me.btnClearLogs.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnClearLogs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearLogs.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnClearLogs.FlatAppearance.BorderSize = 0
        Me.btnClearLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearLogs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearLogs.ForeColor = System.Drawing.Color.White
        Me.btnClearLogs.Location = New System.Drawing.Point(140, 10)
        Me.btnClearLogs.Name = "btnClearLogs"
        Me.btnClearLogs.Size = New System.Drawing.Size(120, 40)
        Me.btnClearLogs.TabIndex = 1
        Me.btnClearLogs.Text = "🗑️ Clear Old"
        Me.btnClearLogs.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(20, 10)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 40)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Text = "🔄 Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'pnlFilters
        '
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlFilters.Controls.Add(Me.btnClearFilters)
        Me.pnlFilters.Controls.Add(Me.dtpEndDate)
        Me.pnlFilters.Controls.Add(Me.lblEndDate)
        Me.pnlFilters.Controls.Add(Me.dtpStartDate)
        Me.pnlFilters.Controls.Add(Me.lblStartDate)
        Me.pnlFilters.Controls.Add(Me.cboTableName)
        Me.pnlFilters.Controls.Add(Me.lblTableName)
        Me.pnlFilters.Controls.Add(Me.cboActionType)
        Me.pnlFilters.Controls.Add(Me.lblActionType)
        Me.pnlFilters.Controls.Add(Me.cboUser)
        Me.pnlFilters.Controls.Add(Me.lblUser)
        Me.pnlFilters.Controls.Add(Me.txtSearch)
        Me.pnlFilters.Controls.Add(Me.lblSearch)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 130)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlFilters.Size = New System.Drawing.Size(1200, 160)
        Me.pnlFilters.TabIndex = 2
        '
        'btnClearFilters
        '
        Me.btnClearFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnClearFilters.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearFilters.FlatAppearance.BorderSize = 0
        Me.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearFilters.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearFilters.ForeColor = System.Drawing.Color.White
        Me.btnClearFilters.Location = New System.Drawing.Point(700, 110)
        Me.btnClearFilters.Name = "btnClearFilters"
        Me.btnClearFilters.Size = New System.Drawing.Size(100, 30)
        Me.btnClearFilters.TabIndex = 12
        Me.btnClearFilters.Text = "✖ Clear"
        Me.btnClearFilters.UseVisualStyleBackColor = False
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(530, 112)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(160, 27)
        Me.dtpEndDate.TabIndex = 11
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEndDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblEndDate.Location = New System.Drawing.Point(530, 90)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(68, 19)
        Me.lblEndDate.TabIndex = 10
        Me.lblEndDate.Text = "End Date"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(360, 112)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(160, 27)
        Me.dtpStartDate.TabIndex = 9
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblStartDate.Location = New System.Drawing.Point(360, 90)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(76, 19)
        Me.lblStartDate.TabIndex = 8
        Me.lblStartDate.Text = "Start Date"
        '
        'cboTableName
        '
        Me.cboTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTableName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboTableName.FormattingEnabled = True
        Me.cboTableName.Items.AddRange(New Object() {"All Tables", "users", "employees", "assets", "asset_issuance", "consumables", "consumable_issuance", "asset_requests", "consumable_requests", "departments", "security_access"})
        Me.cboTableName.Location = New System.Drawing.Point(190, 112)
        Me.cboTableName.Name = "cboTableName"
        Me.cboTableName.Size = New System.Drawing.Size(160, 28)
        Me.cboTableName.TabIndex = 7
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTableName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTableName.Location = New System.Drawing.Point(190, 90)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(89, 19)
        Me.lblTableName.TabIndex = 6
        Me.lblTableName.Text = "Table Name"
        '
        'cboActionType
        '
        Me.cboActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActionType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboActionType.FormattingEnabled = True
        Me.cboActionType.Items.AddRange(New Object() {"All Actions", "User Login", "User Logout", "User Created", "User Updated", "User Deleted", "Employee Created", "Employee Updated", "Employee Deleted", "Asset Created", "Asset Updated", "Asset Issued", "Asset Returned", "Consumable Created", "Consumable Updated", "Consumable Issued", "Stock Adjusted", "Request Approved", "Request Rejected", "Access Rights Updated"})
        Me.cboActionType.Location = New System.Drawing.Point(20, 112)
        Me.cboActionType.Name = "cboActionType"
        Me.cboActionType.Size = New System.Drawing.Size(160, 28)
        Me.cboActionType.TabIndex = 5
        '
        'lblActionType
        '
        Me.lblActionType.AutoSize = True
        Me.lblActionType.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblActionType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblActionType.Location = New System.Drawing.Point(20, 90)
        Me.lblActionType.Name = "lblActionType"
        Me.lblActionType.Size = New System.Drawing.Size(88, 19)
        Me.lblActionType.TabIndex = 4
        Me.lblActionType.Text = "Action Type"
        '
        'cboUser
        '
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboUser.FormattingEnabled = True
        Me.cboUser.Items.AddRange(New Object() {"All Users"})
        Me.cboUser.Location = New System.Drawing.Point(230, 52)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(200, 28)
        Me.cboUser.TabIndex = 3
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblUser.Location = New System.Drawing.Point(230, 30)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(39, 19)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "User"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSearch.Location = New System.Drawing.Point(20, 52)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(200, 27)
        Me.txtSearch.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(20, 30)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(168, 19)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "🔍 Search (Description)"
        '
        'pnlDataGrid
        '
        Me.pnlDataGrid.BackColor = System.Drawing.Color.White
        Me.pnlDataGrid.Controls.Add(Me.dgvActivityLogs)
        Me.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDataGrid.Location = New System.Drawing.Point(0, 290)
        Me.pnlDataGrid.Name = "pnlDataGrid"
        Me.pnlDataGrid.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlDataGrid.Size = New System.Drawing.Size(1200, 350)
        Me.pnlDataGrid.TabIndex = 3
        '
        'dgvActivityLogs
        '
        Me.dgvActivityLogs.AllowUserToAddRows = False
        Me.dgvActivityLogs.AllowUserToDeleteRows = False
        Me.dgvActivityLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvActivityLogs.BackgroundColor = System.Drawing.Color.White
        Me.dgvActivityLogs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvActivityLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActivityLogs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvActivityLogs.Location = New System.Drawing.Point(20, 10)
        Me.dgvActivityLogs.MultiSelect = False
        Me.dgvActivityLogs.Name = "dgvActivityLogs"
        Me.dgvActivityLogs.ReadOnly = True
        Me.dgvActivityLogs.RowHeadersVisible = False
        Me.dgvActivityLogs.RowHeadersWidth = 51
        Me.dgvActivityLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvActivityLogs.Size = New System.Drawing.Size(1160, 330)
        Me.dgvActivityLogs.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.Controls.Add(Me.btnViewDetails)
        Me.pnlBottom.Controls.Add(Me.lblRecordCount)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 640)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlBottom.Size = New System.Drawing.Size(1200, 60)
        Me.pnlBottom.TabIndex = 4
        '
        'btnViewDetails
        '
        Me.btnViewDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnViewDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewDetails.Enabled = False
        Me.btnViewDetails.FlatAppearance.BorderSize = 0
        Me.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnViewDetails.ForeColor = System.Drawing.Color.White
        Me.btnViewDetails.Location = New System.Drawing.Point(1050, 10)
        Me.btnViewDetails.Name = "btnViewDetails"
        Me.btnViewDetails.Size = New System.Drawing.Size(130, 40)
        Me.btnViewDetails.TabIndex = 1
        Me.btnViewDetails.Text = "👁️ View Details"
        Me.btnViewDetails.UseVisualStyleBackColor = False
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblRecordCount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblRecordCount.Location = New System.Drawing.Point(20, 10)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(98, 20)
        Me.lblRecordCount.TabIndex = 0
        Me.lblRecordCount.Text = "Total Logs: 0"
        '
        'ActivityLogsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.pnlDataGrid)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.pnlActions)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ActivityLogsFrm"
        Me.Text = "Activity Logs"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.pnlDataGrid.ResumeLayout(False)
        CType(Me.dgvActivityLogs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnClearLogs As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents cboUser As ComboBox
    Friend WithEvents lblUser As Label
    Friend WithEvents cboActionType As ComboBox
    Friend WithEvents lblActionType As Label
    Friend WithEvents cboTableName As ComboBox
    Friend WithEvents lblTableName As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblStartDate As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents lblEndDate As Label
    Friend WithEvents btnClearFilters As Button
    Friend WithEvents pnlDataGrid As Panel
    Friend WithEvents dgvActivityLogs As DataGridView
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblRecordCount As Label
    Friend WithEvents btnViewDetails As Button
End Class