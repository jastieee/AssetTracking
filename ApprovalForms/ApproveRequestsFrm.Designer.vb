<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ApproveRequestsFrm
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
        Me.dgvRequests = New System.Windows.Forms.DataGridView()
        Me.pnlRequestDetails = New System.Windows.Forms.Panel()
        Me.grpRequestDetails = New System.Windows.Forms.GroupBox()
        Me.txtRejectionReason = New System.Windows.Forms.TextBox()
        Me.lblRejectionReason = New System.Windows.Forms.Label()
        Me.txtApprovalNotes = New System.Windows.Forms.TextBox()
        Me.lblApprovalNotes = New System.Windows.Forms.Label()
        Me.lblPurpose = New System.Windows.Forms.Label()
        Me.lblReason = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.lblRequester = New System.Windows.Forms.Label()
        Me.lblRequestType = New System.Windows.Forms.Label()
        Me.lblRequestId = New System.Windows.Forms.Label()
        Me.lblRequestDate = New System.Windows.Forms.Label()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.cboTypeFilter = New System.Windows.Forms.ComboBox()
        Me.lblTypeFilter = New System.Windows.Forms.Label()
        Me.cboStatusFilter = New System.Windows.Forms.ComboBox()
        Me.lblStatusFilter = New System.Windows.Forms.Label()
        Me.lblTotalRequests = New System.Windows.Forms.Label()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnIssue = New System.Windows.Forms.Button()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        CType(Me.dgvRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRequestDetails.SuspendLayout()
        Me.grpRequestDetails.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlMain.Controls.Add(Me.pnlContent)
        Me.pnlMain.Controls.Add(Me.pnlActions)
        Me.pnlMain.Controls.Add(Me.pnlHeader)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlMain.Size = New System.Drawing.Size(1400, 800)
        Me.pnlMain.TabIndex = 0
        '
        'pnlContent
        '
        Me.pnlContent.Controls.Add(Me.dgvRequests)
        Me.pnlContent.Controls.Add(Me.pnlRequestDetails)
        Me.pnlContent.Controls.Add(Me.pnlFilter)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(15, 75)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(1370, 640)
        Me.pnlContent.TabIndex = 2
        '
        'dgvRequests
        '
        Me.dgvRequests.AllowUserToAddRows = False
        Me.dgvRequests.AllowUserToDeleteRows = False
        Me.dgvRequests.AllowUserToResizeRows = False
        Me.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRequests.BackgroundColor = System.Drawing.Color.White
        Me.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRequests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvRequests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvRequests.ColumnHeadersHeight = 45
        Me.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRequests.EnableHeadersVisualStyles = False
        Me.dgvRequests.GridColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvRequests.Location = New System.Drawing.Point(0, 65)
        Me.dgvRequests.Margin = New System.Windows.Forms.Padding(0, 10, 10, 0)
        Me.dgvRequests.MultiSelect = False
        Me.dgvRequests.Name = "dgvRequests"
        Me.dgvRequests.ReadOnly = True
        Me.dgvRequests.RowHeadersVisible = False
        Me.dgvRequests.RowHeadersWidth = 51
        Me.dgvRequests.RowTemplate.Height = 40
        Me.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRequests.Size = New System.Drawing.Size(920, 575)
        Me.dgvRequests.TabIndex = 2
        '
        'pnlRequestDetails
        '
        Me.pnlRequestDetails.BackColor = System.Drawing.Color.White
        Me.pnlRequestDetails.Controls.Add(Me.grpRequestDetails)
        Me.pnlRequestDetails.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRequestDetails.Location = New System.Drawing.Point(920, 65)
        Me.pnlRequestDetails.Margin = New System.Windows.Forms.Padding(10, 10, 0, 0)
        Me.pnlRequestDetails.Name = "pnlRequestDetails"
        Me.pnlRequestDetails.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlRequestDetails.Size = New System.Drawing.Size(450, 575)
        Me.pnlRequestDetails.TabIndex = 1
        '
        'grpRequestDetails
        '
        Me.grpRequestDetails.Controls.Add(Me.lblDepartment)
        Me.grpRequestDetails.Controls.Add(Me.lblRequestDate)
        Me.grpRequestDetails.Controls.Add(Me.txtRejectionReason)
        Me.grpRequestDetails.Controls.Add(Me.lblRejectionReason)
        Me.grpRequestDetails.Controls.Add(Me.txtApprovalNotes)
        Me.grpRequestDetails.Controls.Add(Me.lblApprovalNotes)
        Me.grpRequestDetails.Controls.Add(Me.lblPurpose)
        Me.grpRequestDetails.Controls.Add(Me.lblReason)
        Me.grpRequestDetails.Controls.Add(Me.lblQuantity)
        Me.grpRequestDetails.Controls.Add(Me.lblItem)
        Me.grpRequestDetails.Controls.Add(Me.lblRequester)
        Me.grpRequestDetails.Controls.Add(Me.lblRequestType)
        Me.grpRequestDetails.Controls.Add(Me.lblRequestId)
        Me.grpRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpRequestDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpRequestDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.grpRequestDetails.Location = New System.Drawing.Point(12, 12)
        Me.grpRequestDetails.Name = "grpRequestDetails"
        Me.grpRequestDetails.Padding = New System.Windows.Forms.Padding(15)
        Me.grpRequestDetails.Size = New System.Drawing.Size(426, 551)
        Me.grpRequestDetails.TabIndex = 0
        Me.grpRequestDetails.TabStop = False
        Me.grpRequestDetails.Text = "Request Details"
        '
        'txtRejectionReason
        '
        Me.txtRejectionReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRejectionReason.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtRejectionReason.Location = New System.Drawing.Point(18, 430)
        Me.txtRejectionReason.Multiline = True
        Me.txtRejectionReason.Name = "txtRejectionReason"
        Me.txtRejectionReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRejectionReason.Size = New System.Drawing.Size(390, 70)
        Me.txtRejectionReason.TabIndex = 10
        Me.txtRejectionReason.Visible = False
        '
        'lblRejectionReason
        '
        Me.lblRejectionReason.AutoSize = True
        Me.lblRejectionReason.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRejectionReason.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.lblRejectionReason.Location = New System.Drawing.Point(18, 405)
        Me.lblRejectionReason.Name = "lblRejectionReason"
        Me.lblRejectionReason.Size = New System.Drawing.Size(165, 20)
        Me.lblRejectionReason.TabIndex = 9
        Me.lblRejectionReason.Text = "Rejection Reason (if any)"
        Me.lblRejectionReason.Visible = False
        '
        'txtApprovalNotes
        '
        Me.txtApprovalNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApprovalNotes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtApprovalNotes.Location = New System.Drawing.Point(18, 355)
        Me.txtApprovalNotes.Multiline = True
        Me.txtApprovalNotes.Name = "txtApprovalNotes"
        Me.txtApprovalNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtApprovalNotes.Size = New System.Drawing.Size(390, 40)
        Me.txtApprovalNotes.TabIndex = 8
        '
        'lblApprovalNotes
        '
        Me.lblApprovalNotes.AutoSize = True
        Me.lblApprovalNotes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblApprovalNotes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblApprovalNotes.Location = New System.Drawing.Point(18, 330)
        Me.lblApprovalNotes.Name = "lblApprovalNotes"
        Me.lblApprovalNotes.Size = New System.Drawing.Size(165, 20)
        Me.lblApprovalNotes.TabIndex = 7
        Me.lblApprovalNotes.Text = "Approval Notes (optional)"
        '
        'lblPurpose
        '
        Me.lblPurpose.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPurpose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblPurpose.Location = New System.Drawing.Point(18, 260)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(390, 60)
        Me.lblPurpose.TabIndex = 6
        Me.lblPurpose.Text = "Purpose:"
        '
        'lblReason
        '
        Me.lblReason.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReason.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblReason.Location = New System.Drawing.Point(18, 200)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(390, 50)
        Me.lblReason.TabIndex = 5
        Me.lblReason.Text = "Reason:"
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblQuantity.Location = New System.Drawing.Point(18, 175)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(68, 20)
        Me.lblQuantity.TabIndex = 4
        Me.lblQuantity.Text = "Quantity:"
        '
        'lblItem
        '
        Me.lblItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblItem.Location = New System.Drawing.Point(18, 145)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(390, 25)
        Me.lblItem.TabIndex = 3
        Me.lblItem.Text = "Item:"
        '
        'lblRequester
        '
        Me.lblRequester.AutoSize = True
        Me.lblRequester.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRequester.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblRequester.Location = New System.Drawing.Point(18, 95)
        Me.lblRequester.Name = "lblRequester"
        Me.lblRequester.Size = New System.Drawing.Size(78, 20)
        Me.lblRequester.TabIndex = 2
        Me.lblRequester.Text = "Requester:"
        '
        'lblRequestType
        '
        Me.lblRequestType.AutoSize = True
        Me.lblRequestType.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblRequestType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblRequestType.Location = New System.Drawing.Point(18, 70)
        Me.lblRequestType.Name = "lblRequestType"
        Me.lblRequestType.Size = New System.Drawing.Size(43, 20)
        Me.lblRequestType.TabIndex = 1
        Me.lblRequestType.Text = "Type:"
        '
        'lblRequestId
        '
        Me.lblRequestId.AutoSize = True
        Me.lblRequestId.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequestId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblRequestId.Location = New System.Drawing.Point(13, 30)
        Me.lblRequestId.Name = "lblRequestId"
        Me.lblRequestId.Size = New System.Drawing.Size(118, 28)
        Me.lblRequestId.TabIndex = 0
        Me.lblRequestId.Text = "Request ID"
        '
        'lblRequestDate
        '
        Me.lblRequestDate.AutoSize = True
        Me.lblRequestDate.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblRequestDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblRequestDate.Location = New System.Drawing.Point(18, 120)
        Me.lblRequestDate.Name = "lblRequestDate"
        Me.lblRequestDate.Size = New System.Drawing.Size(42, 20)
        Me.lblRequestDate.TabIndex = 11
        Me.lblRequestDate.Text = "Date:"
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblDepartment.Location = New System.Drawing.Point(200, 120)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(89, 20)
        Me.lblDepartment.TabIndex = 12
        Me.lblDepartment.Text = "Department:"
        '
        'pnlFilter
        '
        Me.pnlFilter.BackColor = System.Drawing.Color.White
        Me.pnlFilter.Controls.Add(Me.btnRefresh)
        Me.pnlFilter.Controls.Add(Me.cboTypeFilter)
        Me.pnlFilter.Controls.Add(Me.lblTypeFilter)
        Me.pnlFilter.Controls.Add(Me.cboStatusFilter)
        Me.pnlFilter.Controls.Add(Me.lblStatusFilter)
        Me.pnlFilter.Controls.Add(Me.lblTotalRequests)
        Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
        Me.pnlFilter.Size = New System.Drawing.Size(1370, 65)
        Me.pnlFilter.TabIndex = 0
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(670, 15)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 35)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'cboTypeFilter
        '
        Me.cboTypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboTypeFilter.FormattingEnabled = True
        Me.cboTypeFilter.Items.AddRange(New Object() {"All Types", "Asset Request", "Consumable Request"})
        Me.cboTypeFilter.Location = New System.Drawing.Point(450, 18)
        Me.cboTypeFilter.Name = "cboTypeFilter"
        Me.cboTypeFilter.Size = New System.Drawing.Size(200, 28)
        Me.cboTypeFilter.TabIndex = 4
        '
        'lblTypeFilter
        '
        Me.lblTypeFilter.AutoSize = True
        Me.lblTypeFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTypeFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblTypeFilter.Location = New System.Drawing.Point(395, 22)
        Me.lblTypeFilter.Name = "lblTypeFilter"
        Me.lblTypeFilter.Size = New System.Drawing.Size(46, 20)
        Me.lblTypeFilter.TabIndex = 3
        Me.lblTypeFilter.Text = "Type:"
        '
        'cboStatusFilter
        '
        Me.cboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboStatusFilter.FormattingEnabled = True
        Me.cboStatusFilter.Items.AddRange(New Object() {"Pending", "Approved", "Rejected", "Fulfilled", "All"})
        Me.cboStatusFilter.Location = New System.Drawing.Point(85, 18)
        Me.cboStatusFilter.Name = "cboStatusFilter"
        Me.cboStatusFilter.Size = New System.Drawing.Size(280, 28)
        Me.cboStatusFilter.TabIndex = 2
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.AutoSize = True
        Me.lblStatusFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatusFilter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStatusFilter.Location = New System.Drawing.Point(15, 22)
        Me.lblStatusFilter.Name = "lblStatusFilter"
        Me.lblStatusFilter.Size = New System.Drawing.Size(56, 20)
        Me.lblStatusFilter.TabIndex = 1
        Me.lblStatusFilter.Text = "Status:"
        '
        'lblTotalRequests
        '
        Me.lblTotalRequests.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRequests.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalRequests.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblTotalRequests.Location = New System.Drawing.Point(1185, 22)
        Me.lblTotalRequests.Name = "lblTotalRequests"
        Me.lblTotalRequests.Size = New System.Drawing.Size(170, 20)
        Me.lblTotalRequests.TabIndex = 0
        Me.lblTotalRequests.Text = "Total Requests: 0"
        Me.lblTotalRequests.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.White
        Me.pnlActions.Controls.Add(Me.btnIssue)
        Me.pnlActions.Controls.Add(Me.btnReject)
        Me.pnlActions.Controls.Add(Me.btnApprove)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActions.Location = New System.Drawing.Point(15, 715)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlActions.Size = New System.Drawing.Size(1370, 70)
        Me.pnlActions.TabIndex = 1
        '
        'btnIssue
        '
        Me.btnIssue.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.btnIssue.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIssue.Enabled = False
        Me.btnIssue.FlatAppearance.BorderSize = 0
        Me.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIssue.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnIssue.ForeColor = System.Drawing.Color.White
        Me.btnIssue.Location = New System.Drawing.Point(310, 15)
        Me.btnIssue.Name = "btnIssue"
        Me.btnIssue.Size = New System.Drawing.Size(140, 40)
        Me.btnIssue.TabIndex = 2
        Me.btnIssue.Text = "Issue Item"
        Me.btnIssue.UseVisualStyleBackColor = False
        '
        'btnReject
        '
        Me.btnReject.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnReject.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReject.Enabled = False
        Me.btnReject.FlatAppearance.BorderSize = 0
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnReject.ForeColor = System.Drawing.Color.White
        Me.btnReject.Location = New System.Drawing.Point(160, 15)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(140, 40)
        Me.btnReject.TabIndex = 1
        Me.btnReject.Text = "Reject"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'btnApprove
        '
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApprove.Enabled = False
        Me.btnApprove.FlatAppearance.BorderSize = 0
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnApprove.ForeColor = System.Drawing.Color.White
        Me.btnApprove.Location = New System.Drawing.Point(15, 15)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(140, 40)
        Me.btnApprove.TabIndex = 0
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(15, 15)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(15, 15, 15, 10)
        Me.pnlHeader.Size = New System.Drawing.Size(1370, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(268, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Approve/Issue Requests"
        '
        'ApproveRequestsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1400, 800)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ApproveRequestsFrm"
        Me.Text = "Approve Requests"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        CType(Me.dgvRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRequestDetails.ResumeLayout(False)
        Me.grpRequestDetails.ResumeLayout(False)
        Me.grpRequestDetails.PerformLayout()
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnApprove As Button
    Friend WithEvents btnReject As Button
    Friend WithEvents btnIssue As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents pnlFilter As Panel
    Friend WithEvents lblStatusFilter As Label
    Friend WithEvents cboStatusFilter As ComboBox
    Friend WithEvents lblTotalRequests As Label
    Friend WithEvents dgvRequests As DataGridView
    Friend WithEvents pnlRequestDetails As Panel
    Friend WithEvents grpRequestDetails As GroupBox
    Friend WithEvents lblRequestId As Label
    Friend WithEvents lblRequestType As Label
    Friend WithEvents lblRequester As Label
    Friend WithEvents lblItem As Label
    Friend WithEvents lblQuantity As Label
    Friend WithEvents lblReason As Label
    Friend WithEvents lblPurpose As Label
    Friend WithEvents txtApprovalNotes As TextBox
    Friend WithEvents lblApprovalNotes As Label
    Friend WithEvents txtRejectionReason As TextBox
    Friend WithEvents lblRejectionReason As Label
    Friend WithEvents cboTypeFilter As ComboBox
    Friend WithEvents lblTypeFilter As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblRequestDate As Label
    Friend WithEvents lblDepartment As Label
End Class