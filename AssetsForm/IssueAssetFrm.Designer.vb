<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IssueAssetFrm
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
        Me.dgvAssets = New System.Windows.Forms.DataGridView()
        Me.pnlNotesSection = New System.Windows.Forms.Panel()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.lblAssetCount = New System.Windows.Forms.Label()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnIssue = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        CType(Me.dgvAssets, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlMain.Size = New System.Drawing.Size(1000, 700)
        Me.pnlMain.TabIndex = 0
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.dgvAssets)
        Me.pnlContent.Controls.Add(Me.pnlNotesSection)
        Me.pnlContent.Controls.Add(Me.pnlSearch)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(20, 100)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(960, 500)
        Me.pnlContent.TabIndex = 2
        '
        'dgvAssets
        '
        Me.dgvAssets.AllowUserToAddRows = False
        Me.dgvAssets.AllowUserToDeleteRows = False
        Me.dgvAssets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAssets.BackgroundColor = System.Drawing.Color.White
        Me.dgvAssets.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAssets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvAssets.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvAssets.ColumnHeadersHeight = 40
        Me.dgvAssets.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAssets.EnableHeadersVisualStyles = False
        Me.dgvAssets.GridColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.dgvAssets.Location = New System.Drawing.Point(20, 85)
        Me.dgvAssets.MultiSelect = False
        Me.dgvAssets.Name = "dgvAssets"
        Me.dgvAssets.ReadOnly = True
        Me.dgvAssets.RowHeadersVisible = False
        Me.dgvAssets.RowHeadersWidth = 51
        Me.dgvAssets.RowTemplate.Height = 35
        Me.dgvAssets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAssets.Size = New System.Drawing.Size(920, 295)
        Me.dgvAssets.TabIndex = 2
        '
        'pnlNotesSection
        '
        Me.pnlNotesSection.Controls.Add(Me.txtNotes)
        Me.pnlNotesSection.Controls.Add(Me.lblNotes)
        Me.pnlNotesSection.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlNotesSection.Location = New System.Drawing.Point(20, 380)
        Me.pnlNotesSection.Name = "pnlNotesSection"
        Me.pnlNotesSection.Size = New System.Drawing.Size(920, 100)
        Me.pnlNotesSection.TabIndex = 1
        '
        'txtNotes
        '
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtNotes.Location = New System.Drawing.Point(0, 28)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(920, 72)
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
        Me.pnlSearch.Controls.Add(Me.lblAssetCount)
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
        Me.lblSearch.Size = New System.Drawing.Size(171, 23)
        Me.lblSearch.TabIndex = 0
        Me.lblSearch.Text = "🔍 Search Available"
        '
        'lblAssetCount
        '
        Me.lblAssetCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAssetCount.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAssetCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.lblAssetCount.Location = New System.Drawing.Point(650, 32)
        Me.lblAssetCount.Name = "lblAssetCount"
        Me.lblAssetCount.Size = New System.Drawing.Size(270, 23)
        Me.lblAssetCount.TabIndex = 2
        Me.lblAssetCount.Text = "Total Available Assets: 0"
        Me.lblAssetCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.White
        Me.pnlActions.Controls.Add(Me.btnCancel)
        Me.pnlActions.Controls.Add(Me.btnIssue)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActions.Location = New System.Drawing.Point(20, 600)
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
        Me.btnIssue.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIssue.FlatAppearance.BorderSize = 0
        Me.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIssue.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnIssue.ForeColor = System.Drawing.Color.White
        Me.btnIssue.Location = New System.Drawing.Point(670, 20)
        Me.btnIssue.Name = "btnIssue"
        Me.btnIssue.Size = New System.Drawing.Size(140, 40)
        Me.btnIssue.TabIndex = 0
        Me.btnIssue.Text = "✓ Issue Asset"
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
        Me.lblFormTitle.Size = New System.Drawing.Size(370, 37)
        Me.lblFormTitle.TabIndex = 0
        Me.lblFormTitle.Text = "🏷️ Issue Asset to Employee"
        '
        'IssueAssetFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IssueAssetFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Issue Asset to Employee"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        CType(Me.dgvAssets, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblAssetCount As Label
    Friend WithEvents dgvAssets As DataGridView
    Friend WithEvents pnlNotesSection As Panel
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents lblNotes As Label

End Class