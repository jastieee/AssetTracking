<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class loginFrm
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
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.pnlUsername = New System.Windows.Forms.Panel()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.pnlPassword = New System.Windows.Forms.Panel()
        Me.btnShowPassword = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.chkRememberMe = New System.Windows.Forms.CheckBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblFooter = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlUsername.SuspendLayout()
        Me.pnlPassword.SuspendLayout()
        Me.SuspendLayout()
        '
        'picLogo
        '
        Me.picLogo.Image = Global.AssetTracking.My.Resources.Resources.NDAS_short_logo
        Me.picLogo.Location = New System.Drawing.Point(160, 40)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(80, 80)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo.TabIndex = 0
        Me.picLogo.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(0, 135)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(400, 30)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "ASSET TRACKING SYSTEM"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSubtitle
        '
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(0, 170)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(400, 23)
        Me.lblSubtitle.TabIndex = 2
        Me.lblSubtitle.Text = "Login Portal"
        Me.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlUsername
        '
        Me.pnlUsername.BackColor = System.Drawing.Color.White
        Me.pnlUsername.Controls.Add(Me.txtUsername)
        Me.pnlUsername.Controls.Add(Me.lblUsername)
        Me.pnlUsername.Location = New System.Drawing.Point(50, 220)
        Me.pnlUsername.Name = "pnlUsername"
        Me.pnlUsername.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
        Me.pnlUsername.Size = New System.Drawing.Size(300, 70)
        Me.pnlUsername.TabIndex = 3
        '
        'txtUsername
        '
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtUsername.Location = New System.Drawing.Point(15, 35)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(270, 20)
        Me.txtUsername.TabIndex = 1
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblUsername.Location = New System.Drawing.Point(15, 10)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(92, 15)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "👤 USERNAME"
        '
        'pnlPassword
        '
        Me.pnlPassword.BackColor = System.Drawing.Color.White
        Me.pnlPassword.Controls.Add(Me.btnShowPassword)
        Me.pnlPassword.Controls.Add(Me.txtPassword)
        Me.pnlPassword.Controls.Add(Me.lblPassword)
        Me.pnlPassword.Location = New System.Drawing.Point(50, 300)
        Me.pnlPassword.Name = "pnlPassword"
        Me.pnlPassword.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
        Me.pnlPassword.Size = New System.Drawing.Size(300, 70)
        Me.pnlPassword.TabIndex = 4
        '
        'btnShowPassword
        '
        Me.btnShowPassword.BackColor = System.Drawing.Color.Transparent
        Me.btnShowPassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShowPassword.FlatAppearance.BorderSize = 0
        Me.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnShowPassword.Location = New System.Drawing.Point(255, 30)
        Me.btnShowPassword.Name = "btnShowPassword"
        Me.btnShowPassword.Size = New System.Drawing.Size(30, 30)
        Me.btnShowPassword.TabIndex = 3
        Me.btnShowPassword.TabStop = False
        Me.btnShowPassword.Text = "👁"
        Me.btnShowPassword.UseVisualStyleBackColor = False
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.txtPassword.Location = New System.Drawing.Point(15, 35)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(235, 20)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblPassword.Location = New System.Drawing.Point(15, 10)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(89, 15)
        Me.lblPassword.TabIndex = 0
        Me.lblPassword.Text = "🔒 PASSWORD"
        '
        'chkRememberMe
        '
        Me.chkRememberMe.AutoSize = True
        Me.chkRememberMe.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkRememberMe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.chkRememberMe.Location = New System.Drawing.Point(50, 380)
        Me.chkRememberMe.Name = "chkRememberMe"
        Me.chkRememberMe.Size = New System.Drawing.Size(104, 19)
        Me.chkRememberMe.TabIndex = 5
        Me.chkRememberMe.Text = "Remember Me"
        Me.chkRememberMe.UseVisualStyleBackColor = True
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(50, 415)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(300, 45)
        Me.btnLogin.TabIndex = 6
        Me.btnLogin.Text = "LOGIN"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'lblFooter
        '
        Me.lblFooter.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblFooter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblFooter.Location = New System.Drawing.Point(0, 470)
        Me.lblFooter.Name = "lblFooter"
        Me.lblFooter.Size = New System.Drawing.Size(400, 20)
        Me.lblFooter.TabIndex = 7
        Me.lblFooter.Text = "© 2025 NDAS Phils Inc."
        Me.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'loginFrm
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(400, 500)
        Me.Controls.Add(Me.lblFooter)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.chkRememberMe)
        Me.Controls.Add(Me.pnlPassword)
        Me.Controls.Add(Me.pnlUsername)
        Me.Controls.Add(Me.lblSubtitle)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.picLogo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "loginFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login - Asset Tracking System"
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlUsername.ResumeLayout(False)
        Me.pnlUsername.PerformLayout()
        Me.pnlPassword.ResumeLayout(False)
        Me.pnlPassword.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClose.Location = New System.Drawing.Point(360, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 30)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "×"
        Me.btnClose.UseVisualStyleBackColor = False
        Me.Controls.Add(Me.btnClose)
    End Sub

    Friend WithEvents picLogo As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents pnlUsername As Panel
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents pnlPassword As Panel
    Friend WithEvents btnShowPassword As Button
    Friend WithEvents chkRememberMe As CheckBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblFooter As Label
    Friend WithEvents btnClose As Button

End Class