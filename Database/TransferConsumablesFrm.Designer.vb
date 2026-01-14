<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TransferConsumablesFrm
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
        Me.btnNewTransfer = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlFilters = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.rbCompleted = New System.Windows.Forms.RadioButton()
        Me.rbRejected = New System.Windows.Forms.RadioButton()
        Me.rbApproved = New System.Windows.Forms.RadioButton()
        Me.rbPending = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.lblFilter = New System.Windows.Forms.Label()
        Me.dgvTransfers = New System.Windows.Forms.DataGridView()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.btnViewDetails = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlFilters.SuspendLayout()
        CType(Me.dgvTransfers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnNewTransfer)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1000, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'btnNewTransfer
        '
        Me.btnNewTransfer.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnNewTransfer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNewTransfer.FlatAppearance.BorderSize = 0
        Me.btnNewTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewTransfer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnNewTransfer.ForeColor = System.Drawing.Color.White
        Me.btnNewTransfer.Location = New System.Drawing.Point(820, 15)
        Me.btnNewTransfer.Name = "btnNewTransfer"
        Me.btnNewTransfer.Size = New System.Drawing.Size(160, 40)
        Me.btnNewTransfer.TabIndex = 1
        Me.btnNewTransfer.Text = "+ New Transfer"
        Me.btnNewTransfer.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(359, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "CONSUMABLE TRANSFERS"
        '
        'pnlFilters
        '
        Me.pnlFilters.BackColor = System.Drawing.Color.White
        Me.pnlFilters.Controls.Add(Me.btnSearch)
        Me.pnlFilters.Controls.Add(Me.txtSearch)
        Me.pnlFilters.Controls.Add(Me.rbCompleted)
        Me.pnlFilters.Controls.Add(Me.rbRejected)
        Me.pnlFilters.Controls.Add(Me.rbApproved)
        Me.pnlFilters.Controls.Add(Me.rbPending)
        Me.pnlFilters.Controls.Add(Me.rbAll)
        Me.pnlFilters.Controls.Add(Me.lblFilter)
        Me.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilters.Location = New System.Drawing.Point(0, 70)
        Me.pnlFilters.Name = "pnlFilters"
        Me.pnlFilters.Size = New System.Drawing.Size(1000, 60)
        Me.pnlFilters.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(940, 18)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(40, 25)
        Me.btnSearch.TabIndex = 7
        Me.btnSearch.Text = "🔍"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSearch.Location = New System.Drawing.Point(720, 18)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(210, 23)
        Me.txtSearch.TabIndex = 6
        '
        'rbCompleted
        '
        Me.rbCompleted.AutoSize = True
        Me.rbCompleted.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbCompleted.Location = New System.Drawing.Point(620, 20)
        Me.rbCompleted.Name = "rbCompleted"
        Me.rbCompleted.Size = New System.Drawing.Size(90, 19)
        Me.rbCompleted.TabIndex = 5
        Me.rbCompleted.TabStop = True
        Me.rbCompleted.Text = "Completed"
        Me.rbCompleted.UseVisualStyleBackColor = True
        '
        'rbRejected
        '
        Me.rbRejected.AutoSize = True
        Me.rbRejected.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbRejected.Location = New System.Drawing.Point(540, 20)
        Me.rbRejected.Name = "rbRejected"
        Me.rbRejected.Size = New System.Drawing.Size(72, 19)
        Me.rbRejected.TabIndex = 4
        Me.rbRejected.TabStop = True
        Me.rbRejected.Text = "Rejected"
        Me.rbRejected.UseVisualStyleBackColor = True
        '
        'rbApproved
        '
        Me.rbApproved.AutoSize = True
        Me.rbApproved.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbApproved.Location = New System.Drawing.Point(450, 20)
        Me.rbApproved.Name = "rbApproved"
        Me.rbApproved.Size = New System.Drawing.Size(80, 19)
        Me.rbApproved.TabIndex = 3
        Me.rbApproved.TabStop = True
        Me.rbApproved.Text = "Approved"
        Me.rbApproved.UseVisualStyleBackColor = True
        '
        'rbPending
        '
        Me.rbPending.AutoSize = True
        Me.rbPending.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbPending.Location = New System.Drawing.Point(370, 20)
        Me.rbPending.Name = "rbPending"
        Me.rbPending.Size = New System.Drawing.Size(70, 19)
        Me.rbPending.TabIndex = 2
        Me.rbPending.TabStop = True
        Me.rbPending.Text = "Pending"
        Me.rbPending.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rbAll.Location = New System.Drawing.Point(310, 20)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(40, 19)
        Me.rbAll.TabIndex = 1
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'lblFilter
        '
        Me.lblFilter.AutoSize = True
        Me.lblFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblFilter.Location = New System.Drawing.Point(20, 22)
        Me.lblFilter.Name = "lblFilter"
        Me.lblFilter.Size = New System.Drawing.Size(97, 15)
        Me.lblFilter.TabIndex = 0
        Me.lblFilter.Text = "Filter by Status:"
        '
        'dgvTransfers
        '
        Me.dgvTransfers.AllowUserToAddRows = False
        Me.dgvTransfers.AllowUserToDeleteRows = False
        Me.dgvTransfers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTransfers.BackgroundColor = System.Drawing.Color.White
        Me.dgvTransfers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransfers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTransfers.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgvTransfers.Location = New System.Drawing.Point(0, 130)
        Me.dgvTransfers.Name = "dgvTransfers"
        Me.dgvTransfers.ReadOnly = True
        Me.dgvTransfers.RowHeadersVisible = False
        Me.dgvTransfers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransfers.Size = New System.Drawing.Size(1000, 500)
        Me.dgvTransfers.TabIndex = 2
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.White
        Me.pnlActions.Controls.Add(Me.btnExport)
        Me.pnlActions.Controls.Add(Me.btnReject)
        Me.pnlActions.Controls.Add(Me.btnApprove)
        Me.pnlActions.Controls.Add(Me.btnViewDetails)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActions.Location = New System.Drawing.Point(0, 630)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Size = New System.Drawing.Size(1000, 70)
        Me.pnlActions.TabIndex = 3
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(400, 15)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(110, 40)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "📊 Export"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'btnReject
        '
        Me.btnReject.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnReject.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReject.Enabled = False
        Me.btnReject.FlatAppearance.BorderSize = 0
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnReject.ForeColor = System.Drawing.Color.White
        Me.btnReject.Location = New System.Drawing.Point(270, 15)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(120, 40)
        Me.btnReject.TabIndex = 2
        Me.btnReject.Text = "❌ Reject"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'btnApprove
        '
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApprove.Enabled = False
        Me.btnApprove.FlatAppearance.BorderSize = 0
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnApprove.ForeColor = System.Drawing.Color.White
        Me.btnApprove.Location = New System.Drawing.Point(140, 15)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(120, 40)
        Me.btnApprove.TabIndex = 1
        Me.btnApprove.Text = "✅ Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'btnViewDetails
        '
        Me.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnViewDetails.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewDetails.Enabled = False
        Me.btnViewDetails.FlatAppearance.BorderSize = 0
        Me.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnViewDetails.ForeColor = System.Drawing.Color.White
        Me.btnViewDetails.Location = New System.Drawing.Point(10, 15)
        Me.btnViewDetails.Name = "btnViewDetails"
        Me.btnViewDetails.Size = New System.Drawing.Size(120, 40)
        Me.btnViewDetails.TabIndex = 0
        Me.btnViewDetails.Text = "📋 View Details"
        Me.btnViewDetails.UseVisualStyleBackColor = False
        '
        'TransferConsumablesFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1000, 700)
        Me.Controls.Add(Me.dgvTransfers)
        Me.Controls.Add(Me.pnlActions)
        Me.Controls.Add(Me.pnlFilters)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TransferConsumablesFrm"
        Me.Text = "Consumable Transfers"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlFilters.ResumeLayout(False)
        Me.pnlFilters.PerformLayout()
        CType(Me.dgvTransfers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlActions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnNewTransfer As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents lblFilter As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents rbCompleted As RadioButton
    Friend WithEvents rbRejected As RadioButton
    Friend WithEvents rbApproved As RadioButton
    Friend WithEvents rbPending As RadioButton
    Friend WithEvents rbAll As RadioButton
    Friend WithEvents dgvTransfers As DataGridView
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnExport As Button
    Friend WithEvents btnReject As Button
    Friend WithEvents btnApprove As Button
    Friend WithEvents btnViewDetails As Button
End Class