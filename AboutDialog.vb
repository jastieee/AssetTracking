'Imports System.Drawing.Drawing2D

'Public Class AboutDialog
'    Inherits Form

'    Private pnlHeader As Panel
'    Private pnlContent As Panel
'    Private pnlFooter As Panel
'    Private lblAppName As Label
'    Private lblVersion As Label
'    Private lblDescription As Label
'    Private lblCopyright As Label
'    Private lblFeatures As Label
'    Private lblMobileApp As Label
'    Private picLogo As PictureBox
'    Private btnClose As Button
'    Private btnVisitWebsite As Button

'    Public Sub New()
'        SetupDialogControls()
'        SetupDialog()
'    End Sub

'    Private Sub SetupDialogControls()
'        Me.SuspendLayout()

'        ' Form settings
'        Me.Text = "About Asset Tracking System"
'        Me.Size = New Size(600, 700)
'        Me.FormBorderStyle = FormBorderStyle.None
'        Me.StartPosition = FormStartPosition.CenterParent
'        Me.BackColor = Color.White
'        Me.Font = New Font("Segoe UI", 9.0F)

'        ' Enable double buffering for smooth rendering
'        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
'        Me.UpdateStyles()

'        Me.ResumeLayout(False)
'    End Sub

'    Private Sub SetupDialog()
'        ' Header Panel
'        pnlHeader = New Panel()
'        pnlHeader.Dock = DockStyle.Top
'        pnlHeader.Height = 180
'        pnlHeader.BackColor = Color.FromArgb(41, 128, 185)
'        Me.Controls.Add(pnlHeader)

'        ' Logo (You can replace this with an actual logo)
'        picLogo = New PictureBox()
'        picLogo.Size = New Size(80, 80)
'        picLogo.Location = New Point((pnlHeader.Width - 80) \ 2, 25)
'        picLogo.BackColor = Color.White
'        picLogo.SizeMode = PictureBoxSizeMode.CenterImage
'        AddHandler pnlHeader.Resize, Sub() picLogo.Location = New Point((pnlHeader.Width - 80) \ 2, 25)
'        pnlHeader.Controls.Add(picLogo)

'        ' Draw a simple icon in the logo
'        Dim bmp As New Bitmap(80, 80)
'        Using g As Graphics = Graphics.FromImage(bmp)
'            g.SmoothingMode = SmoothingMode.AntiAlias
'            ' Draw a box/package icon
'            Using boxBrush As New SolidBrush(Color.FromArgb(41, 128, 185))
'                g.FillRectangle(boxBrush, 15, 25, 50, 40)
'            End Using
'            Using boxPen As New Pen(Color.FromArgb(31, 97, 141), 3)
'                g.DrawRectangle(boxPen, 15, 25, 50, 40)
'                g.DrawLine(boxPen, 15, 25, 40, 10)
'                g.DrawLine(boxPen, 65, 25, 40, 10)
'                g.DrawLine(boxPen, 40, 10, 40, 25)
'            End Using
'        End Using
'        picLogo.Image = bmp

'        ' App Name
'        lblAppName = New Label()
'        lblAppName.Text = "Asset Tracking System"
'        lblAppName.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
'        lblAppName.ForeColor = Color.White
'        lblAppName.AutoSize = False
'        lblAppName.TextAlign = ContentAlignment.MiddleCenter
'        lblAppName.Width = pnlHeader.Width
'        lblAppName.Height = 40
'        lblAppName.Location = New Point(0, 115)
'        AddHandler pnlHeader.Resize, Sub() lblAppName.Width = pnlHeader.Width
'        pnlHeader.Controls.Add(lblAppName)

'        ' Version
'        lblVersion = New Label()
'        lblVersion.Text = "Version 1.0.0 - Desktop Edition"
'        lblVersion.Font = New Font("Segoe UI", 10.0F)
'        lblVersion.ForeColor = Color.FromArgb(236, 240, 241)
'        lblVersion.AutoSize = False
'        lblVersion.TextAlign = ContentAlignment.MiddleCenter
'        lblVersion.Width = pnlHeader.Width
'        lblVersion.Height = 25
'        lblVersion.Location = New Point(0, 150)
'        AddHandler pnlHeader.Resize, Sub() lblVersion.Width = pnlHeader.Width
'        pnlHeader.Controls.Add(lblVersion)

'        ' Content Panel
'        pnlContent = New Panel()
'        pnlContent.Dock = DockStyle.Fill
'        pnlContent.Padding = New Padding(40, 30, 40, 30)
'        pnlContent.AutoScroll = True
'        Me.Controls.Add(pnlContent)

'        ' Description
'        lblDescription = New Label()
'        lblDescription.Text = "A comprehensive solution for managing organizational assets, consumables, and equipment tracking with real-time monitoring and reporting capabilities."
'        lblDescription.Font = New Font("Segoe UI", 9.5F)
'        lblDescription.ForeColor = Color.FromArgb(52, 73, 94)
'        lblDescription.AutoSize = False
'        lblDescription.Width = 500
'        lblDescription.Height = 60
'        lblDescription.Location = New Point(40, 20)
'        pnlContent.Controls.Add(lblDescription)

'        ' Features Section
'        lblFeatures = New Label()
'        lblFeatures.Text = "📋 Key Features:" & vbCrLf & vbCrLf &
'                          "   • Asset & Consumable Management" & vbCrLf &
'                          "   • Employee Tracking & Assignment" & vbCrLf &
'                          "   • Request & Approval Workflow" & vbCrLf &
'                          "   • QR Code Scanning Integration" & vbCrLf &
'                          "   • Real-time Reports & Analytics" & vbCrLf &
'                          "   • Activity Logging & Audit Trail" & vbCrLf &
'                          "   • Multi-user Access Control" & vbCrLf &
'                          "   • Database Backup & Security"
'        lblFeatures.Font = New Font("Segoe UI", 9.0F)
'        lblFeatures.ForeColor = Color.FromArgb(52, 73, 94)
'        lblFeatures.AutoSize = False
'        lblFeatures.Width = 500
'        lblFeatures.Height = 200
'        lblFeatures.Location = New Point(40, 90)
'        pnlContent.Controls.Add(lblFeatures)

'        ' Mobile App Section
'        lblMobileApp = New Label()
'        lblMobileApp.Text = "📱 Mobile Scanner App:" & vbCrLf & vbCrLf &
'                           "   A companion Android application designed for" & vbCrLf &
'                           "   quick asset scanning and verification using QR codes." & vbCrLf & vbCrLf &
'                           "   • Scan employee and asset QR codes" & vbCrLf &
'                           "   • Instant information lookup" & vbCrLf &
'                           "   • Offline capability" & vbCrLf &
'                           "   • Synchronized with desktop system"
'        lblMobileApp.Font = New Font("Segoe UI", 9.0F)
'        lblMobileApp.ForeColor = Color.FromArgb(52, 73, 94)
'        lblMobileApp.AutoSize = False
'        lblMobileApp.Width = 500
'        lblMobileApp.Height = 160
'        lblMobileApp.Location = New Point(40, 300)

'        ' Add border to mobile section
'        AddHandler lblMobileApp.Paint, Sub(s As Object, e As PaintEventArgs)
'                                           Dim rect As New Rectangle(0, 0, lblMobileApp.Width - 1, lblMobileApp.Height - 1)
'                                           Using pen As New Pen(Color.FromArgb(189, 195, 199), 2)
'                                               pen.DashStyle = DashStyle.Dash
'                                               e.Graphics.DrawRectangle(pen, rect)
'                                           End Using
'                                       End Sub
'        pnlContent.Controls.Add(lblMobileApp)

'        ' Copyright
'        lblCopyright = New Label()
'        lblCopyright.Text = "© 2025 Your Company Name" & vbCrLf &
'                           "All rights reserved." & vbCrLf & vbCrLf &
'                           "Built with ❤ for efficient asset management"
'        lblCopyright.Font = New Font("Segoe UI", 8.5F)
'        lblCopyright.ForeColor = Color.FromArgb(127, 140, 141)
'        lblCopyright.AutoSize = False
'        lblCopyright.Width = 500
'        lblCopyright.Height = 80
'        lblCopyright.Location = New Point(40, 470)
'        lblCopyright.TextAlign = ContentAlignment.TopCenter
'        pnlContent.Controls.Add(lblCopyright)

'        ' Footer Panel
'        pnlFooter = New Panel()
'        pnlFooter.Dock = DockStyle.Bottom
'        pnlFooter.Height = 70
'        pnlFooter.BackColor = Color.FromArgb(236, 240, 241)
'        Me.Controls.Add(pnlFooter)

'        ' Visit Website Button
'        btnVisitWebsite = New Button()
'        btnVisitWebsite.Text = "🌐 Visit Website"
'        btnVisitWebsite.Size = New Size(150, 40)
'        btnVisitWebsite.Location = New Point(220, 15)
'        btnVisitWebsite.BackColor = Color.FromArgb(52, 152, 219)
'        btnVisitWebsite.ForeColor = Color.White
'        btnVisitWebsite.FlatStyle = FlatStyle.Flat
'        btnVisitWebsite.FlatAppearance.BorderSize = 0
'        btnVisitWebsite.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
'        btnVisitWebsite.Cursor = Cursors.Hand
'        AddHandler btnVisitWebsite.Click, AddressOf btnVisitWebsite_Click
'        AddHandler btnVisitWebsite.MouseEnter, Sub() btnVisitWebsite.BackColor = Color.FromArgb(41, 128, 185)
'        AddHandler btnVisitWebsite.MouseLeave, Sub() btnVisitWebsite.BackColor = Color.FromArgb(52, 152, 219)
'        pnlFooter.Controls.Add(btnVisitWebsite)

'        ' Close Button
'        btnClose = New Button()
'        btnClose.Text = "✓ Close"
'        btnClose.Size = New Size(120, 40)
'        btnClose.Location = New Point(380, 15)
'        btnClose.BackColor = Color.FromArgb(46, 204, 113)
'        btnClose.ForeColor = Color.White
'        btnClose.FlatStyle = FlatStyle.Flat
'        btnClose.FlatAppearance.BorderSize = 0
'        btnClose.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
'        btnClose.Cursor = Cursors.Hand
'        AddHandler btnClose.Click, AddressOf btnClose_Click
'        AddHandler btnClose.MouseEnter, Sub() btnClose.BackColor = Color.FromArgb(39, 174, 96)
'        AddHandler btnClose.MouseLeave, Sub() btnClose.BackColor = Color.FromArgb(46, 204, 113)
'        pnlFooter.Controls.Add(btnClose)

'        ' Add shadow effect to form
'        AddHandler Me.Paint, AddressOf OnFormPaint
'    End Sub

'    Private Sub OnFormPaint(sender As Object, e As PaintEventArgs)
'        ' Draw border
'        Using pen As New Pen(Color.FromArgb(189, 195, 199), 2)
'            e.Graphics.DrawRectangle(pen, 0, 0, Me.Width - 1, Me.Height - 1)
'        End Using
'    End Sub

'    Private Sub btnClose_Click(sender As Object, e As EventArgs)
'        Me.DialogResult = DialogResult.OK
'        Me.Close()
'    End Sub

'    Private Sub btnVisitWebsite_Click(sender As Object, e As EventArgs)
'        Try
'            ' Replace with your actual website URL
'            System.Diagnostics.Process.Start("https://yourcompany.com")
'        Catch ex As Exception
'            MessageBox.Show("Could not open website. Please visit: https://yourcompany.com", 
'                          "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        End Try
'    End Sub

'    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
'        MyBase.OnMouseDown(e)
'        If e.Button = MouseButtons.Left Then
'            ' Allow dragging the form
'            ReleaseCapture()
'            SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
'        End If
'    End Sub

'    ' Windows API for dragging
'    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
'    Private Const HT_CAPTION As Integer = &H2

'    <System.Runtime.InteropServices.DllImport("user32.dll")>
'    Private Shared Function ReleaseCapture() As Boolean
'    End Function

'    <System.Runtime.InteropServices.DllImport("user32.dll")>
'    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, lParam As Integer) As Integer
'    End Function
'End Class

'' Update your button click event to use the new dialog:
'' Private Sub btnAbout_Click(sender As Object, e As EventArgs)
''     SetActiveButton(btnAbout)
''     Using aboutDialog As New AboutDialog()
''         aboutDialog.ShowDialog(Me)
''     End Using
'' End Sub