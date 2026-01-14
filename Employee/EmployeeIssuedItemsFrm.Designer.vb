<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeIssuedItemsFrm
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
        Me.btnPrintReport = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.cboItemType = New System.Windows.Forms.ComboBox()
        Me.lblItemType = New System.Windows.Forms.Label()
        Me.cboEmployee = New System.Windows.Forms.TextBox()
        Me.lblEmployee = New System.Windows.Forms.Label()
        Me.pnlEmployeeInfo = New System.Windows.Forms.Panel()
        Me.lblPositionValue = New System.Windows.Forms.Label()
        Me.lblPositionLabel = New System.Windows.Forms.Label()
        Me.lblDepartmentValue = New System.Windows.Forms.Label()
        Me.lblDepartmentLabel = New System.Windows.Forms.Label()
        Me.lblEmployeeNumberValue = New System.Windows.Forms.Label()
        Me.lblEmployeeNumberLabel = New System.Windows.Forms.Label()
        Me.lblEmployeeNameValue = New System.Windows.Forms.Label()
        Me.lblEmployeeNameLabel = New System.Windows.Forms.Label()
        Me.pnlDataGrid = New System.Windows.Forms.Panel()
        Me.dgvIssuedItems = New System.Windows.Forms.DataGridView()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.lblTotalConsumables = New System.Windows.Forms.Label()
        Me.lblTotalAssets = New System.Windows.Forms.Label()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.pnlTop.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        Me.pnlEmployeeInfo.SuspendLayout()
        Me.pnlDataGrid.SuspendLayout()
        CType(Me.dgvIssuedItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(388, 41)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "📦 Employee Issued Items"
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.White
        Me.pnlActions.Controls.Add(Me.btnExport)
        Me.pnlActions.Controls.Add(Me.btnPrintReport)
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
        'btnPrintReport
        '
        Me.btnPrintReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btnPrintReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrintReport.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrintReport.FlatAppearance.BorderSize = 0
        Me.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintReport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrintReport.ForeColor = System.Drawing.Color.White
        Me.btnPrintReport.Location = New System.Drawing.Point(140, 10)
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(120, 40)
        Me.btnPrintReport.TabIndex = 1
        Me.btnPrintReport.Text = "🖨️ Print"
        Me.btnPrintReport.UseVisualStyleBackColor = False
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
        Me.pnlFilters.Controls.Add(Me.btnClearFilter)
        Me.pnlFilters.Controls.Add(Me.cboItemType)
        Me.pnlFilters.Controls.Add(Me.lblItemType)
        Me.pnlFilters.Controls.Add(Me.cboEmployee)
        Me.pnlFilters.Controls.Add(Me.lblEmployee)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 130)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlFilters.Size = New System.Drawing.Size(1200, 80)
        Me.pnlFilters.TabIndex = 2
        '
        'btnClearFilter
        '
        Me.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearFilter.FlatAppearance.BorderSize = 0
        Me.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearFilter.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearFilter.ForeColor = System.Drawing.Color.White
        Me.btnClearFilter.Location = New System.Drawing.Point(650, 32)
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Size = New System.Drawing.Size(100, 30)
        Me.btnClearFilter.TabIndex = 4
        Me.btnClearFilter.Text = "✖ Clear"
        Me.btnClearFilter.UseVisualStyleBackColor = False
        '
        'cboItemType
        '
        Me.cboItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboItemType.FormattingEnabled = True
        Me.cboItemType.Items.AddRange(New Object() {"All Items", "Assets Only", "Consumables Only"})
        Me.cboItemType.Location = New System.Drawing.Point(450, 34)
        Me.cboItemType.Name = "cboItemType"
        Me.cboItemType.Size = New System.Drawing.Size(190, 28)
        Me.cboItemType.TabIndex = 3
        '
        'lblItemType
        '
        Me.lblItemType.AutoSize = True
        Me.lblItemType.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblItemType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblItemType.Location = New System.Drawing.Point(450, 12)
        Me.lblItemType.Name = "lblItemType"
        Me.lblItemType.Size = New System.Drawing.Size(75, 19)
        Me.lblItemType.TabIndex = 2
        Me.lblItemType.Text = "Item Type"
        '
        'cboEmployee
        '
        Me.cboEmployee.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboEmployee.Location = New System.Drawing.Point(20, 34)
        Me.cboEmployee.Name = "cboEmployee"
        Me.cboEmployee.Size = New System.Drawing.Size(420, 27)
        Me.cboEmployee.TabIndex = 1
        '
        'lblEmployee
        '
        Me.lblEmployee.AutoSize = True
        Me.lblEmployee.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblEmployee.Location = New System.Drawing.Point(20, 12)
        Me.lblEmployee.Name = "lblEmployee"
        Me.lblEmployee.Size = New System.Drawing.Size(290, 19)
        Me.lblEmployee.TabIndex = 0
        Me.lblEmployee.Text = "🔍 Filter by Employee (Name or Emp. No.)"
        '
        'pnlEmployeeInfo
        '
        Me.pnlEmployeeInfo.BackColor = System.Drawing.Color.White
        Me.pnlEmployeeInfo.Controls.Add(Me.lblPositionValue)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblPositionLabel)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblDepartmentValue)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblDepartmentLabel)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeeNumberValue)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeeNumberLabel)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeeNameValue)
        Me.pnlEmployeeInfo.Controls.Add(Me.lblEmployeeNameLabel)
        Me.pnlEmployeeInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEmployeeInfo.Location = New System.Drawing.Point(0, 210)
        Me.pnlEmployeeInfo.Name = "pnlEmployeeInfo"
        Me.pnlEmployeeInfo.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.pnlEmployeeInfo.Size = New System.Drawing.Size(1200, 90)
        Me.pnlEmployeeInfo.TabIndex = 3
        Me.pnlEmployeeInfo.Visible = False
        '
        'lblPositionValue
        '
        Me.lblPositionValue.AutoSize = True
        Me.lblPositionValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPositionValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblPositionValue.Location = New System.Drawing.Point(720, 50)
        Me.lblPositionValue.Name = "lblPositionValue"
        Me.lblPositionValue.Size = New System.Drawing.Size(19, 20)
        Me.lblPositionValue.TabIndex = 7
        Me.lblPositionValue.Text = "- "
        '
        'lblPositionLabel
        '
        Me.lblPositionLabel.AutoSize = True
        Me.lblPositionLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPositionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblPositionLabel.Location = New System.Drawing.Point(720, 20)
        Me.lblPositionLabel.Name = "lblPositionLabel"
        Me.lblPositionLabel.Size = New System.Drawing.Size(70, 20)
        Me.lblPositionLabel.TabIndex = 6
        Me.lblPositionLabel.Text = "Position:"
        '
        'lblDepartmentValue
        '
        Me.lblDepartmentValue.AutoSize = True
        Me.lblDepartmentValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartmentValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblDepartmentValue.Location = New System.Drawing.Point(480, 50)
        Me.lblDepartmentValue.Name = "lblDepartmentValue"
        Me.lblDepartmentValue.Size = New System.Drawing.Size(19, 20)
        Me.lblDepartmentValue.TabIndex = 5
        Me.lblDepartmentValue.Text = "- "
        '
        'lblDepartmentLabel
        '
        Me.lblDepartmentLabel.AutoSize = True
        Me.lblDepartmentLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepartmentLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblDepartmentLabel.Location = New System.Drawing.Point(480, 20)
        Me.lblDepartmentLabel.Name = "lblDepartmentLabel"
        Me.lblDepartmentLabel.Size = New System.Drawing.Size(98, 20)
        Me.lblDepartmentLabel.TabIndex = 4
        Me.lblDepartmentLabel.Text = "Department:"
        '
        'lblEmployeeNumberValue
        '
        Me.lblEmployeeNumberValue.AutoSize = True
        Me.lblEmployeeNumberValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmployeeNumberValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblEmployeeNumberValue.Location = New System.Drawing.Point(240, 50)
        Me.lblEmployeeNumberValue.Name = "lblEmployeeNumberValue"
        Me.lblEmployeeNumberValue.Size = New System.Drawing.Size(19, 20)
        Me.lblEmployeeNumberValue.TabIndex = 3
        Me.lblEmployeeNumberValue.Text = "- "
        '
        'lblEmployeeNumberLabel
        '
        Me.lblEmployeeNumberLabel.AutoSize = True
        Me.lblEmployeeNumberLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblEmployeeNumberLabel.Location = New System.Drawing.Point(240, 20)
        Me.lblEmployeeNumberLabel.Name = "lblEmployeeNumberLabel"
        Me.lblEmployeeNumberLabel.Size = New System.Drawing.Size(73, 20)
        Me.lblEmployeeNumberLabel.TabIndex = 2
        Me.lblEmployeeNumberLabel.Text = "Emp. No:"
        '
        'lblEmployeeNameValue
        '
        Me.lblEmployeeNameValue.AutoSize = True
        Me.lblEmployeeNameValue.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEmployeeNameValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblEmployeeNameValue.Location = New System.Drawing.Point(20, 50)
        Me.lblEmployeeNameValue.Name = "lblEmployeeNameValue"
        Me.lblEmployeeNameValue.Size = New System.Drawing.Size(19, 20)
        Me.lblEmployeeNameValue.TabIndex = 1
        Me.lblEmployeeNameValue.Text = "- "
        '
        'lblEmployeeNameLabel
        '
        Me.lblEmployeeNameLabel.AutoSize = True
        Me.lblEmployeeNameLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblEmployeeNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblEmployeeNameLabel.Location = New System.Drawing.Point(20, 20)
        Me.lblEmployeeNameLabel.Name = "lblEmployeeNameLabel"
        Me.lblEmployeeNameLabel.Size = New System.Drawing.Size(55, 20)
        Me.lblEmployeeNameLabel.TabIndex = 0
        Me.lblEmployeeNameLabel.Text = "Name:"
        '
        'pnlDataGrid
        '
        Me.pnlDataGrid.BackColor = System.Drawing.Color.White
        Me.pnlDataGrid.Controls.Add(Me.dgvIssuedItems)
        Me.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDataGrid.Location = New System.Drawing.Point(0, 300)
        Me.pnlDataGrid.Name = "pnlDataGrid"
        Me.pnlDataGrid.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlDataGrid.Size = New System.Drawing.Size(1200, 340)
        Me.pnlDataGrid.TabIndex = 4
        '
        'dgvIssuedItems
        '
        Me.dgvIssuedItems.AllowUserToAddRows = False
        Me.dgvIssuedItems.AllowUserToDeleteRows = False
        Me.dgvIssuedItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvIssuedItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvIssuedItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIssuedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIssuedItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIssuedItems.Location = New System.Drawing.Point(20, 10)
        Me.dgvIssuedItems.MultiSelect = False
        Me.dgvIssuedItems.Name = "dgvIssuedItems"
        Me.dgvIssuedItems.ReadOnly = True
        Me.dgvIssuedItems.RowHeadersVisible = False
        Me.dgvIssuedItems.RowHeadersWidth = 51
        Me.dgvIssuedItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIssuedItems.Size = New System.Drawing.Size(1160, 320)
        Me.dgvIssuedItems.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.Controls.Add(Me.lblTotalConsumables)
        Me.pnlBottom.Controls.Add(Me.lblTotalAssets)
        Me.pnlBottom.Controls.Add(Me.lblRecordCount)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 640)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlBottom.Size = New System.Drawing.Size(1200, 60)
        Me.pnlBottom.TabIndex = 5
        '
        'lblTotalConsumables
        '
        Me.lblTotalConsumables.AutoSize = True
        Me.lblTotalConsumables.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalConsumables.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.lblTotalConsumables.Location = New System.Drawing.Point(500, 20)
        Me.lblTotalConsumables.Name = "lblTotalConsumables"
        Me.lblTotalConsumables.Size = New System.Drawing.Size(168, 20)
        Me.lblTotalConsumables.TabIndex = 2
        Me.lblTotalConsumables.Text = "Consumables Issued: 0"
        '
        'lblTotalAssets
        '
        Me.lblTotalAssets.AutoSize = True
        Me.lblTotalAssets.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAssets.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblTotalAssets.Location = New System.Drawing.Point(270, 20)
        Me.lblTotalAssets.Name = "lblTotalAssets"
        Me.lblTotalAssets.Size = New System.Drawing.Size(121, 20)
        Me.lblTotalAssets.TabIndex = 1
        Me.lblTotalAssets.Text = "Assets Issued: 0"
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblRecordCount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRecordCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblRecordCount.Location = New System.Drawing.Point(20, 10)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(105, 20)
        Me.lblRecordCount.TabIndex = 0
        Me.lblRecordCount.Text = "Total Items: 0"
        '
        'EmployeeIssuedItemsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 700)
        Me.Controls.Add(Me.pnlDataGrid)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlEmployeeInfo)
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.pnlActions)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EmployeeIssuedItemsFrm"
        Me.Text = "Employee Issued Items"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.pnlEmployeeInfo.ResumeLayout(False)
        Me.pnlEmployeeInfo.PerformLayout()
        Me.pnlDataGrid.ResumeLayout(False)
        CType(Me.dgvIssuedItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnExport As Button
    Friend WithEvents btnPrintReport As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents btnClearFilter As Button
    Friend WithEvents cboItemType As ComboBox
    Friend WithEvents lblItemType As Label
    Friend WithEvents cboEmployee As TextBox
    Friend WithEvents lblEmployee As Label
    Friend WithEvents pnlEmployeeInfo As Panel
    Friend WithEvents lblPositionValue As Label
    Friend WithEvents lblPositionLabel As Label
    Friend WithEvents lblDepartmentValue As Label
    Friend WithEvents lblDepartmentLabel As Label
    Friend WithEvents lblEmployeeNumberValue As Label
    Friend WithEvents lblEmployeeNumberLabel As Label
    Friend WithEvents lblEmployeeNameValue As Label
    Friend WithEvents lblEmployeeNameLabel As Label
    Friend WithEvents pnlDataGrid As Panel
    Friend WithEvents dgvIssuedItems As DataGridView
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblTotalConsumables As Label
    Friend WithEvents lblTotalAssets As Label
    Friend WithEvents lblRecordCount As Label
End Class