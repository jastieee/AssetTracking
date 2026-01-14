<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventoryStatusFrm
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.cboFilterDepartment = New System.Windows.Forms.ComboBox()
        Me.lblFilterDept = New System.Windows.Forms.Label()
        Me.cboFilterStatus = New System.Windows.Forms.ComboBox()
        Me.lblFilterStatus = New System.Windows.Forms.Label()
        Me.dgvInventory = New System.Windows.Forms.DataGridView()
        Me.colItemId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepartment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCurrentStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMinStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReorderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlSummary = New System.Windows.Forms.Panel()
        Me.lblCriticalCount = New System.Windows.Forms.Label()
        Me.lblLowStockCount = New System.Windows.Forms.Label()
        Me.lblNormalCount = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSummary.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1000, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(368, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "INVENTORY STATUS BY DEPT"
        '
        'pnlFilters
        '
        Me.pnlFilters.BackColor = System.Drawing.Color.White
        Me.pnlFilters.Controls.Add(Me.btnRefresh)
        Me.pnlFilters.Controls.Add(Me.cboFilterDepartment)
        Me.pnlFilters.Controls.Add(Me.lblFilterDept)
        Me.pnlFilters.Controls.Add(Me.cboFilterStatus)
        Me.pnlFilters.Controls.Add(Me.lblFilterStatus)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 70)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(1000, 60)
        Me.pnlFilters.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(580, 18)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 25)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "🔄 Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'cboFilterDepartment
        '
        Me.cboFilterDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboFilterDepartment.FormattingEnabled = True
        Me.cboFilterDepartment.Location = New System.Drawing.Point(120, 18)
        Me.cboFilterDepartment.Name = "cboFilterDepartment"
        Me.cboFilterDepartment.Size = New System.Drawing.Size(200, 23)
        Me.cboFilterDepartment.TabIndex = 3
        '
        'lblFilterDept
        '
        Me.lblFilterDept.AutoSize = True
        Me.lblFilterDept.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblFilterDept.Location = New System.Drawing.Point(20, 21)
        Me.lblFilterDept.Name = "lblFilterDept"
        Me.lblFilterDept.Size = New System.Drawing.Size(80, 15)
        Me.lblFilterDept.TabIndex = 2
        Me.lblFilterDept.Text = "Department:"
        '
        'cboFilterStatus
        '
        Me.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboFilterStatus.FormattingEnabled = True
        Me.cboFilterStatus.Location = New System.Drawing.Point(400, 18)
        Me.cboFilterStatus.Name = "cboFilterStatus"
        Me.cboFilterStatus.Size = New System.Drawing.Size(160, 23)
        Me.cboFilterStatus.TabIndex = 1
        '
        'lblFilterStatus
        '
        Me.lblFilterStatus.AutoSize = True
        Me.lblFilterStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblFilterStatus.Location = New System.Drawing.Point(340, 21)
        Me.lblFilterStatus.Name = "lblFilterStatus"
        Me.lblFilterStatus.Size = New System.Drawing.Size(46, 15)
        Me.lblFilterStatus.TabIndex = 0
        Me.lblFilterStatus.Text = "Status:"
        '
        'dgvInventory
        '
        Me.dgvInventory.AllowUserToAddRows = False
        Me.dgvInventory.AllowUserToDeleteRows = False
        Me.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInventory.BackgroundColor = System.Drawing.Color.White
        Me.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInventory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemId, Me.colItemCode, Me.colItemName, Me.colDepartment, Me.colCurrentStock, Me.colMinStock, Me.colReorderLevel, Me.colStatus})
        Me.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInventory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgvInventory.Location = New System.Drawing.Point(0, 130)
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.ReadOnly = True
        Me.dgvInventory.RowHeadersVisible = False
        Me.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInventory.Size = New System.Drawing.Size(1000, 490)
        Me.dgvInventory.TabIndex = 2
        '
        'colItemId
        '
        Me.colItemId.HeaderText = "ID"
        Me.colItemId.Name = "colItemId"
        Me.colItemId.ReadOnly = True
        Me.colItemId.Visible = False
        '
        'colItemCode
        '
        Me.colItemCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colItemCode.HeaderText = "Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 100
        '
        'colItemName
        '
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        '
        'colDepartment
        '
        Me.colDepartment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colDepartment.HeaderText = "Department"
        Me.colDepartment.Name = "colDepartment"
        Me.colDepartment.ReadOnly = True
        Me.colDepartment.Width = 150
        '
        'colCurrentStock
        '
        Me.colCurrentStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colCurrentStock.HeaderText = "Current Stock"
        Me.colCurrentStock.Name = "colCurrentStock"
        Me.colCurrentStock.ReadOnly = True
        Me.colCurrentStock.Width = 110
        '
        'colMinStock
        '
        Me.colMinStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colMinStock.HeaderText = "Min Stock"
        Me.colMinStock.Name = "colMinStock"
        Me.colMinStock.ReadOnly = True
        Me.colMinStock.Width = 100
        '
        'colReorderLevel
        '
        Me.colReorderLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colReorderLevel.HeaderText = "Reorder Level"
        Me.colReorderLevel.Name = "colReorderLevel"
        Me.colReorderLevel.ReadOnly = True
        Me.colReorderLevel.Width = 110
        '
        'colStatus
        '
        Me.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        Me.colStatus.Width = 120
        '
        'pnlSummary
        '
        Me.pnlSummary.BackColor = System.Drawing.Color.White
        Me.pnlSummary.Controls.Add(Me.lblCriticalCount)
        Me.pnlSummary.Controls.Add(Me.lblLowStockCount)
        Me.pnlSummary.Controls.Add(Me.lblNormalCount)
        Me.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSummary.Location = New System.Drawing.Point(0, 620)
        Me.pnlSummary.Name = "pnlSummary"
        Me.pnlSummary.Size = New System.Drawing.Size(1000, 80)
        Me.pnlSummary.TabIndex = 3
        '
        'lblCriticalCount
        '
        Me.lblCriticalCount.AutoSize = True
        Me.lblCriticalCount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCriticalCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblCriticalCount.Location = New System.Drawing.Point(700, 30)
        Me.lblCriticalCount.Name = "lblCriticalCount"
        Me.lblCriticalCount.Size = New System.Drawing.Size(107, 21)
        Me.lblCriticalCount.TabIndex = 2
        Me.lblCriticalCount.Text = "🔴 Critical: 0"
        '
        'lblLowStockCount
        '
        Me.lblLowStockCount.AutoSize = True
        Me.lblLowStockCount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblLowStockCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.lblLowStockCount.Location = New System.Drawing.Point(350, 30)
        Me.lblLowStockCount.Name = "lblLowStockCount"
        Me.lblLowStockCount.Size = New System.Drawing.Size(131, 21)
        Me.lblLowStockCount.TabIndex = 1
        Me.lblLowStockCount.Text = "🟡 Low Stock: 0"
        '
        'lblNormalCount
        '
        Me.lblNormalCount.AutoSize = True
        Me.lblNormalCount.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblNormalCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.lblNormalCount.Location = New System.Drawing.Point(20, 30)
        Me.lblNormalCount.Name = "lblNormalCount"
        Me.lblNormalCount.Size = New System.Drawing.Size(112, 21)
        Me.lblNormalCount.TabIndex = 0
        Me.lblNormalCount.Text = "🟢 Normal: 0"
        '
        'InventoryStatusFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 700)
        Me.Controls.Add(Me.dgvInventory)
        Me.Controls.Add(Me.pnlSummary)
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "InventoryStatusFrm"
        Me.Text = "Inventory Status"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSummary.ResumeLayout(False)
        Me.pnlSummary.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents cboFilterDepartment As ComboBox
    Friend WithEvents lblFilterDept As Label
    Friend WithEvents cboFilterStatus As ComboBox
    Friend WithEvents lblFilterStatus As Label
    Friend WithEvents dgvInventory As DataGridView
    Friend WithEvents colItemId As DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As DataGridViewTextBoxColumn
    Friend WithEvents colItemName As DataGridViewTextBoxColumn
    Friend WithEvents colDepartment As DataGridViewTextBoxColumn
    Friend WithEvents colCurrentStock As DataGridViewTextBoxColumn
    Friend WithEvents colMinStock As DataGridViewTextBoxColumn
    Friend WithEvents colReorderLevel As DataGridViewTextBoxColumn
    Friend WithEvents colStatus As DataGridViewTextBoxColumn
    Friend WithEvents pnlSummary As Panel
    Friend WithEvents lblCriticalCount As Label
    Friend WithEvents lblLowStockCount As Label
    Friend WithEvents lblNormalCount As Label
End Class