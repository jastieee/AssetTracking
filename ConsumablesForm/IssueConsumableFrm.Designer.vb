<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IssueConsumableFrm
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
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.pnlQuantitySection = New System.Windows.Forms.Panel()
        Me.lblAvailableStock = New System.Windows.Forms.Label()
        Me.nudQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.pnlPurposeSection = New System.Windows.Forms.Panel()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.lblPurpose = New System.Windows.Forms.Label()
        Me.pnlNotesSection = New System.Windows.Forms.Panel()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblConsumableCount = New System.Windows.Forms.Label()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnIssue = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlQuantitySection.SuspendLayout()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPurposeSection.SuspendLayout()
        Me.pnlNotesSection.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlContent)
        Me.pnlMain.Controls.Add(Me.pnlActions)
        Me.pnlMain.Controls.Add(Me.pnlHeader)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlMain.Size = New System.Drawing.Size(1000, 750)
        Me.pnlMain.TabIndex = 0
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.dgvConsumables)
        Me.pnlContent.Controls.Add(Me.pnlQuantitySection)
        Me.pnlContent.Controls.Add(Me.pnlPurposeSection)
        Me.pnlContent.Controls.Add(Me.pnlNotesSection)
        Me.pnlContent.Controls.Add(Me.pnlSearch)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(20, 100)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(960, 550)
        Me.pnlContent.TabIndex = 2
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToAddRows = False
        Me.dgvConsumables.AllowUserToDeleteRows = False
        Me.dgvConsumables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.White
        Me.dgvConsumables.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvConsumables.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvConsumables.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvConsumables.ColumnHeadersHeight = 40
        Me.dgvConsumables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.dgvConsumables.Location = New System.Drawing.Point(20, 85)
        Me.dgvConsumables.MultiSelect = False
        Me.dgvConsumables.Name = "dgvConsumables"
        Me.dgvConsumables.ReadOnly = True
        Me.dgvConsumables.RowHeadersVisible = False
        Me.dgvConsumables.RowHeadersWidth = 51
        Me.dgvConsumables.RowTemplate.Height = 35
        Me.dgvConsumables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConsumables.Size = New System.Drawing.Size(920, 205)
        Me.dgvConsumables.TabIndex = 4
        '
        'pnlQuantitySection
        '
        Me.pnlQuantitySection.Controls.Add(Me.lblAvailableStock)
        Me.pnlQuantitySection.Controls.Add(Me.nudQuantity)
        Me.pnlQuantitySection.Controls.Add(Me.lblQuantity)
        Me.pnlQuantitySection.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlQuantitySection.Location = New System.Drawing.Point(20, 290)
        Me.pnlQuantitySection.Name = "pnlQuantitySection"
        Me.pnlQuantitySection.Size = New System.Drawing.Size(920, 60)
        Me.pnlQuantitySection.TabIndex = 3
        '
        'lblAvailableStock
        '
        Me.lblAvailableStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAvailableStock.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAvailableStock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.lblAvailableStock.Location = New System.Drawing.Point(650, 27)
        Me.lblAvailableStock.Name = "lblAvailableStock"
        Me.lblAvailableStock.Size = New System.Drawing.Size(270, 23)
        Me.lblAvailableStock.TabIndex = 2
        Me.lblAvailableStock.Text = "Available Stock: 0"
        Me.lblAvailableStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudQuantity
        '
        Me.nudQuantity.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.nudQuantity.Location = New System.Drawing.Point(0, 25)
        Me.nudQuantity.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudQuantity.Name = "nudQuantity"
        Me.nudQuantity.Size = New System.Drawing.Size(200, 30)
        Me.nudQuantity.TabIndex = 1
        Me.nudQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblQuantity.Location = New System.Drawing.Point(0, 0)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(174, 23)
        Me.lblQuantity.TabIndex = 0
        Me.lblQuantity.Text = "📊 Quantity to Issue"
        '
        'pnlPurposeSection
        '
        Me.pnlPurposeSection.Controls.Add(Me.txtPurpose)
        Me.pnlPurposeSection.Controls.Add(Me.lblPurpose)
        Me.pnlPurposeSection.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPurposeSection.Location = New System.Drawing.Point(20, 350)
        Me.pnlPurposeSection.Name = "pnlPurposeSection"
        Me.pnlPurposeSection.Size = New System.Drawing.Size(920, 100)
        Me.pnlPurposeSection.TabIndex = 2
        '
        'txtPurpose
        '
        Me.txtPurpose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPurpose.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtPurpose.Location = New System.Drawing.Point(0, 28)
        Me.txtPurpose.Multiline = True
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(920, 72)
        Me.txtPurpose.TabIndex = 1
        '
        'lblPurpose
        '
        Me.lblPurpose.AutoSize = True
        Me.lblPurpose.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPurpose.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPurpose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblPurpose.Location = New System.Drawing.Point(0, 0)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.lblPurpose.Size = New System.Drawing.Size(103, 28)
        Me.lblPurpose.TabIndex = 0
        Me.lblPurpose.Text = "🎯 Purpose"
        '
        'pnlNotesSection
        '
        Me.pnlNotesSection.Controls.Add(Me.txtNotes)
        Me.pnlNotesSection.Controls.Add(Me.lblNotes)
        Me.pnlNotesSection.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlNotesSection.Location = New System.Drawing.Point(20, 450)
        Me.pnlNotesSection.Name = "pnlNotesSection"
        Me.pnlNotesSection.Size = New System.Drawing.Size(920, 80)
        Me.pnlNotesSection.TabIndex = 1
        '
        'txtNotes
        '
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtNotes.Location = New System.Drawing.Point(0, 28)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(920, 52)
        Me.txtNotes.TabIndex = 1
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNotes.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblNotes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblNotes.Location = New System.Drawing.Point(0, 0)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.lblNotes.Size = New System.Drawing.Size(172, 28)
        Me.lblNotes.TabIndex = 0
        Me.lblNotes.Text = "📝 Notes (Optional)"
        '
        'pnlSearch
        '
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.Controls.Add(Me.lblSearch)
        Me.pnlSearch.Controls.Add(Me.lblConsumableCount)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearch.Location = New System.Drawing.Point(20, 20)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(920, 65)
        Me.pnlSearch.TabIndex = 0
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtSearch.Location = New System.Drawing.Point(0, 30)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(450, 30)
        Me.txtSearch.TabIndex = 1
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.lblSearch.Location = New System.Drawing.Point(0, 5)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(221, 23)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "🔍 Search Available Stock"
        '
        'lblConsumableCount
        '
        Me.lblConsumableCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblConsumableCount.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblConsumableCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.lblConsumableCount.Location = New System.Drawing.Point(600, 32)
        Me.lblConsumableCount.Name = "lblConsumableCount"
        Me.lblConsumableCount.Size = New System.Drawing.Size(320, 23)
        Me.lblConsumableCount.TabIndex = 2
        Me.lblConsumableCount.Text = "Total Available Consumables: 0"
        Me.lblConsumableCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.White
        Me.pnlActions.Controls.Add(Me.btnCancel)
        Me.pnlActions.Controls.Add(Me.btnIssue)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActions.Location = New System.Drawing.Point(20, 650)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlActions.Size = New System.Drawing.Size(960, 80)
        Me.pnlActions.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(820, 20)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnIssue
        '
        Me.btnIssue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIssue.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIssue.FlatAppearance.BorderSize = 0
        Me.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIssue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnIssue.ForeColor = System.Drawing.Color.White
        Me.btnIssue.Location = New System.Drawing.Point(630, 20)
        Me.btnIssue.Name = "btnIssue"
        Me.btnIssue.Size = New System.Drawing.Size(180, 40)
        Me.btnIssue.TabIndex = 0
        Me.btnIssue.Text = "✓ Issue Consumable"
        Me.btnIssue.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblFormTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(20, 20)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlHeader.Size = New System.Drawing.Size(960, 80)
        Me.pnlHeader.TabIndex = 0
        '
        'lblFormTitle
        '
        Me.lblFormTitle.AutoSize = True
        Me.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblFormTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblFormTitle.Location = New System.Drawing.Point(20, 20)
        Me.lblFormTitle.Name = "lblFormTitle"
        Me.lblFormTitle.Size = New System.Drawing.Size(459, 37)
        Me.lblFormTitle.TabIndex = 0
        Me.lblFormTitle.Text = "📦 Issue Consumable to Employee"
        '
        'IssueConsumableFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 750)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IssueConsumableFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Issue Consumable to Employee"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlQuantitySection.ResumeLayout(False)
        Me.pnlQuantitySection.PerformLayout()
        CType(Me.nudQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPurposeSection.ResumeLayout(False)
        Me.pnlPurposeSection.PerformLayout()
        Me.pnlNotesSection.ResumeLayout(False)
        Me.pnlNotesSection.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblFormTitle As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnIssue As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents lblSearch As Label
    Friend WithEvents lblConsumableCount As Label
    Friend WithEvents dgvConsumables As DataGridView
    Friend WithEvents pnlNotesSection As Panel
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents pnlPurposeSection As Panel
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents lblPurpose As Label
    Friend WithEvents pnlQuantitySection As Panel
    Friend WithEvents nudQuantity As NumericUpDown
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblAvailableStock As Label

End Class