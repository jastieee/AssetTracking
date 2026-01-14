<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewDepartmentDetailsFrm
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
        Me.lblUpdatedDate = New System.Windows.Forms.Label()
        Me.lblCreatedDate = New System.Windows.Forms.Label()
        Me.lblEmployeeCount = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblDeptCode = New System.Windows.Forms.Label()
        Me.lblDeptName = New System.Windows.Forms.Label()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.pnlContent.SuspendLayout()
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
        Me.pnlMain.Size = New System.Drawing.Size(700, 500)
        Me.pnlMain.TabIndex = 0
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.lblUpdatedDate)
        Me.pnlContent.Controls.Add(Me.lblCreatedDate)
        Me.pnlContent.Controls.Add(Me.lblEmployeeCount)
        Me.pnlContent.Controls.Add(Me.lblStatus)
        Me.pnlContent.Controls.Add(Me.lblDescription)
        Me.pnlContent.Controls.Add(Me.lblDeptCode)
        Me.pnlContent.Controls.Add(Me.lblDeptName)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(20, 100)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(30)
        Me.pnlContent.Size = New System.Drawing.Size(660, 300)
        Me.pnlContent.TabIndex = 2
        '
        'lblUpdatedDate
        '
        Me.lblUpdatedDate.AutoSize = True
        Me.lblUpdatedDate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblUpdatedDate.Location = New System.Drawing.Point(30, 250)
        Me.lblUpdatedDate.MaximumSize = New System.Drawing.Size(600, 0)
        Me.lblUpdatedDate.Name = "lblUpdatedDate"
        Me.lblUpdatedDate.Size = New System.Drawing.Size(120, 23)
        Me.lblUpdatedDate.TabIndex = 6
        Me.lblUpdatedDate.Text = "Last Updated: "
        '
        'lblCreatedDate
        '
        Me.lblCreatedDate.AutoSize = True
        Me.lblCreatedDate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblCreatedDate.Location = New System.Drawing.Point(30, 210)
        Me.lblCreatedDate.MaximumSize = New System.Drawing.Size(600, 0)
        Me.lblCreatedDate.Name = "lblCreatedDate"
        Me.lblCreatedDate.Size = New System.Drawing.Size(79, 23)
        Me.lblCreatedDate.TabIndex = 5
        Me.lblCreatedDate.Text = "Created: "
        '
        'lblEmployeeCount
        '
        Me.lblEmployeeCount.AutoSize = True
        Me.lblEmployeeCount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblEmployeeCount.Location = New System.Drawing.Point(30, 170)
        Me.lblEmployeeCount.MaximumSize = New System.Drawing.Size(600, 0)
        Me.lblEmployeeCount.Name = "lblEmployeeCount"
        Me.lblEmployeeCount.Size = New System.Drawing.Size(141, 23)
        Me.lblEmployeeCount.TabIndex = 4
        Me.lblEmployeeCount.Text = "Total Employees: "
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblStatus.Location = New System.Drawing.Point(30, 130)
        Me.lblStatus.MaximumSize = New System.Drawing.Size(600, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(65, 23)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "Status: "
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDescription.Location = New System.Drawing.Point(30, 90)
        Me.lblDescription.MaximumSize = New System.Drawing.Size(600, 0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(105, 23)
        Me.lblDescription.TabIndex = 2
        Me.lblDescription.Text = "Description: "
        '
        'lblDeptCode
        '
        Me.lblDeptCode.AutoSize = True
        Me.lblDeptCode.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDeptCode.Location = New System.Drawing.Point(30, 50)
        Me.lblDeptCode.MaximumSize = New System.Drawing.Size(600, 0)
        Me.lblDeptCode.Name = "lblDeptCode"
        Me.lblDeptCode.Size = New System.Drawing.Size(156, 23)
        Me.lblDeptCode.TabIndex = 1
        Me.lblDeptCode.Text = "Department Code: "
        '
        'lblDeptName
        '
        Me.lblDeptName.AutoSize = True
        Me.lblDeptName.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDeptName.Location = New System.Drawing.Point(30, 10)
        Me.lblDeptName.MaximumSize = New System.Drawing.Size(600, 0)
        Me.lblDeptName.Name = "lblDeptName"
        Me.lblDeptName.Size = New System.Drawing.Size(162, 23)
        Me.lblDeptName.TabIndex = 0
        Me.lblDeptName.Text = "Department Name: "
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.White
        Me.pnlActions.Controls.Add(Me.btnClose)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActions.Location = New System.Drawing.Point(20, 400)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlActions.Size = New System.Drawing.Size(660, 80)
        Me.pnlActions.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(520, 20)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 40)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblFormTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(20, 20)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlHeader.Size = New System.Drawing.Size(660, 80)
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
        Me.lblFormTitle.Size = New System.Drawing.Size(315, 37)
        Me.lblFormTitle.TabIndex = 0
        Me.lblFormTitle.Text = "📋 Department Details"
        '
        'ViewDepartmentDetailsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 500)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViewDepartmentDetailsFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "View Department Details"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblFormTitle As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlContent As Panel
    Friend WithEvents lblDeptName As Label
    Friend WithEvents lblDeptCode As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblEmployeeCount As Label
    Friend WithEvents lblCreatedDate As Label
    Friend WithEvents lblUpdatedDate As Label
End Class