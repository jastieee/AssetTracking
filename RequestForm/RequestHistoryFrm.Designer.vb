<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RequestHistoryFrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnViewDetails = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.lblRequestCount = New System.Windows.Forms.Label()
        Me.cmbTypeFilter = New System.Windows.Forms.ComboBox()
        Me.lblTypeFilter = New System.Windows.Forms.Label()
        Me.cmbStatusFilter = New System.Windows.Forms.ComboBox()
        Me.lblStatusFilter = New System.Windows.Forms.Label()
        Me.pnlDataGrid = New System.Windows.Forms.Panel()
        Me.dgvRequests = New System.Windows.Forms.DataGridView()
        Me.pnlTop.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        Me.pnlDataGrid.SuspendLayout()
        CType(Me.dgvRequests, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.Size = New System.Drawing.Size(437, 41)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "📜 Complete Request History"
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.White
        Me.pnlActions.Controls.Add(Me.btnExport)
        Me.pnlActions.Controls.Add(Me.btnViewDetails)
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
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(315, 10)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(150, 40)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "📊 Export to CSV"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'btnViewDetails
        '
        Me.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnViewDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewDetails.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnViewDetails.FlatAppearance.BorderSize = 0
        Me.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnViewDetails.ForeColor = System.Drawing.Color.White
        Me.btnViewDetails.Location = New System.Drawing.Point(175, 10)
        Me.btnViewDetails.Name = "btnViewDetails"
        Me.btnViewDetails.Size = New System.Drawing.Size(140, 40)
        Me.btnViewDetails.TabIndex = 1
        Me.btnViewDetails.Text = "👁 View Details"
        Me.btnViewDetails.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(20, 10)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(155, 40)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Text = "🔄 Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'pnlFilters
        '
        Me.pnlFilters.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlFilters.Controls.Add(Me.lblRequestCount)
        Me.pnlFilters.Controls.Add(Me.cmbTypeFilter)
        Me.pnlFilters.Controls.Add(Me.lblTypeFilter)
        Me.pnlFilters.Controls.Add(Me.cmbStatusFilter)
        Me.pnlFilters.Controls.Add(Me.lblStatusFilter)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 130)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Padding = New System.Windows.Forms.Padding(20, 10, 20, 10)
        Me.pnlFilters.Size = New System.Drawing.Size(1200, 80)
        Me.pnlFilters.TabIndex = 2
        '
        'lblRequestCount
        '
        Me.lblRequestCount.AutoSize = True
        Me.lblRequestCount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequestCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblRequestCount.Location = New System.Drawing.Point(580, 40)
        Me.lblRequestCount.Name = "lblRequestCount"
        Me.lblRequestCount.Size = New System.Drawing.Size(129, 20)
        Me.lblRequestCount.TabIndex = 4
        Me.lblRequestCount.Text = "Total Requests: 0"
        '
        'cmbTypeFilter
        '
        Me.cmbTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbTypeFilter.FormattingEnabled = True
        Me.cmbTypeFilter.Location = New System.Drawing.Point(300, 37)
        Me.cmbTypeFilter.Name = "cmbTypeFilter"
        Me.cmbTypeFilter.Size = New System.Drawing.Size(250, 28)
        Me.cmbTypeFilter.TabIndex = 3
        '
        'lblTypeFilter
        '
        Me.lblTypeFilter.AutoSize = True
        Me.lblTypeFilter.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTypeFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTypeFilter.Location = New System.Drawing.Point(300, 15)
        Me.lblTypeFilter.Name = "lblTypeFilter"
        Me.lblTypeFilter.Size = New System.Drawing.Size(124, 19)
        Me.lblTypeFilter.TabIndex = 2
        Me.lblTypeFilter.Text = "🏷 Filter by Type"
        '
        'cmbStatusFilter
        '
        Me.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatusFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbStatusFilter.FormattingEnabled = True
        Me.cmbStatusFilter.Location = New System.Drawing.Point(20, 37)
        Me.cmbStatusFilter.Name = "cmbStatusFilter"
        Me.cmbStatusFilter.Size = New System.Drawing.Size(250, 28)
        Me.cmbStatusFilter.TabIndex = 1
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.AutoSize = True
        Me.lblStatusFilter.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatusFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblStatusFilter.Location = New System.Drawing.Point(20, 15)
        Me.lblStatusFilter.Name = "lblStatusFilter"
        Me.lblStatusFilter.Size = New System.Drawing.Size(132, 19)
        Me.lblStatusFilter.TabIndex = 0
        Me.lblStatusFilter.Text = "🔍 Filter by Status"
        '
        'pnlDataGrid
        '
        Me.pnlDataGrid.BackColor = System.Drawing.Color.White
        Me.pnlDataGrid.Controls.Add(Me.dgvRequests)
        Me.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDataGrid.Location = New System.Drawing.Point(0, 210)
        Me.pnlDataGrid.Name = "pnlDataGrid"
        Me.pnlDataGrid.Padding = New System.Windows.Forms.Padding(20, 10, 20, 20)
        Me.pnlDataGrid.Size = New System.Drawing.Size(1200, 540)
        Me.pnlDataGrid.TabIndex = 3
        '
        'dgvRequests
        '
        Me.dgvRequests.AllowUserToAddRows = False
        Me.dgvRequests.AllowUserToDeleteRows = False
        Me.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRequests.BackgroundColor = System.Drawing.Color.White
        Me.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRequests.Location = New System.Drawing.Point(20, 10)
        Me.dgvRequests.MultiSelect = False
        Me.dgvRequests.Name = "dgvRequests"
        Me.dgvRequests.ReadOnly = True
        Me.dgvRequests.RowHeadersVisible = False
        Me.dgvRequests.RowHeadersWidth = 51
        Me.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRequests.Size = New System.Drawing.Size(1160, 510)
        Me.dgvRequests.TabIndex = 0
        '
        'RequestHistoryFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 750)
        Me.Controls.Add(Me.pnlDataGrid)
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.pnlActions)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RequestHistoryFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request History"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        Me.pnlDataGrid.ResumeLayout(False)
        CType(Me.dgvRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnViewDetails As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents cmbStatusFilter As ComboBox
    Friend WithEvents lblStatusFilter As Label
    Friend WithEvents cmbTypeFilter As ComboBox
    Friend WithEvents lblTypeFilter As Label
    Friend WithEvents lblRequestCount As Label
    Friend WithEvents pnlDataGrid As Panel
    Friend WithEvents dgvRequests As DataGridView
End Class