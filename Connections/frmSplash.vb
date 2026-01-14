Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class frmSplash
    Inherits Form

    Private pnlTop As Panel
    Private pnlBottom As Panel
    Private lblTitle As Label
    Private lblSubtitle As Label
    Private lblVersion As Label
    Private lblLoading As Label
    Private lblPercentage As Label
    Private progressBar As ProgressBar
    Private picLogo As PictureBox
    Private loadingTimer As Timer
    Private currentProgress As Integer = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        ' Form properties
        Me.Size = New Size(600, 400)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.White
        Me.ShowInTaskbar = False

        ' Enable double buffering
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        Me.UpdateStyles()

        ' Top Panel (Header)
        pnlTop = New Panel()
        pnlTop.Dock = DockStyle.Top
        pnlTop.Height = 200
        pnlTop.BackColor = Color.FromArgb(52, 152, 219) ' Blue
        Me.Controls.Add(pnlTop)

        ' Logo PictureBox
        picLogo = New PictureBox()
        picLogo.Size = New Size(80, 80)
        picLogo.Location = New Point((pnlTop.Width - 80) \ 2, 30)
        picLogo.BackColor = Color.White
        picLogo.SizeMode = PictureBoxSizeMode.CenterImage
        AddHandler pnlTop.Resize, Sub() picLogo.Location = New Point((pnlTop.Width - 80) \ 2, 30)
        pnlTop.Controls.Add(picLogo)

        ' Create logo icon
        CreateLogoIcon()

        ' Title Label
        lblTitle = New Label()
        With lblTitle
            .Text = "ASSET TRACKING SYSTEM"
            .Font = New Font("Segoe UI", 18, FontStyle.Bold)
            .ForeColor = Color.White
            .AutoSize = False
            .Size = New Size(580, 40)
            .Location = New Point(10, 120)
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        pnlTop.Controls.Add(lblTitle)

        ' Subtitle
        lblSubtitle = New Label()
        With lblSubtitle
            .Text = "Comprehensive Asset & Inventory Management"
            .Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .ForeColor = Color.FromArgb(236, 240, 241)
            .AutoSize = False
            .Size = New Size(580, 25)
            .Location = New Point(10, 165)
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        pnlTop.Controls.Add(lblSubtitle)

        ' Bottom Panel (Content)
        pnlBottom = New Panel()
        pnlBottom.Dock = DockStyle.Fill
        pnlBottom.BackColor = Color.White
        Me.Controls.Add(pnlBottom)

        ' Version Label
        lblVersion = New Label()
        With lblVersion
            .Text = "Version 1.0.0 - Desktop Edition"
            .Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .ForeColor = Color.FromArgb(127, 140, 141)
            .AutoSize = False
            .Size = New Size(580, 25)
            .Location = New Point(10, 20)
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        pnlBottom.Controls.Add(lblVersion)

        ' Loading Label
        lblLoading = New Label()
        With lblLoading
            .Text = "Initializing system..."
            .Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .ForeColor = Color.FromArgb(52, 73, 94)
            .AutoSize = False
            .Size = New Size(500, 25)
            .Location = New Point(50, 70)
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        pnlBottom.Controls.Add(lblLoading)

        ' Percentage Label
        lblPercentage = New Label()
        With lblPercentage
            .Text = "0%"
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ForeColor = Color.FromArgb(52, 152, 219)
            .AutoSize = False
            .Size = New Size(60, 25)
            .Location = New Point(520, 70)
            .TextAlign = ContentAlignment.MiddleRight
        End With
        pnlBottom.Controls.Add(lblPercentage)

        ' Custom Progress Bar Panel (container)
        Dim pnlProgressContainer As New Panel()
        pnlProgressContainer.Size = New Size(500, 25)
        pnlProgressContainer.Location = New Point(50, 110)
        pnlProgressContainer.BorderStyle = BorderStyle.FixedSingle
        pnlProgressContainer.BackColor = Color.FromArgb(236, 240, 241) ' Light gray background
        pnlBottom.Controls.Add(pnlProgressContainer)

        ' Progress Bar (the actual colored bar)
        progressBar = New ProgressBar()
        With progressBar
            .Size = New Size(0, 23) ' Start with 0 width
            .Location = New Point(1, 1)
            .Style = ProgressBarStyle.Continuous
            .Minimum = 0
            .Maximum = 100
            .Value = 0
        End With

        ' Paint the progress bar with custom color
        AddHandler progressBar.Paint, Sub(s As Object, e As PaintEventArgs)
                                          Dim rect As New Rectangle(0, 0, progressBar.Width, progressBar.Height)
                                          Using brush As New SolidBrush(Color.FromArgb(52, 152, 219))
                                              e.Graphics.FillRectangle(brush, rect)
                                          End Using
                                      End Sub

        pnlProgressContainer.Controls.Add(progressBar)

        ' Copyright Label
        Dim lblCopyright As New Label()
        With lblCopyright
            .Text = "© 2025 Your Company. All rights reserved."
            .Font = New Font("Segoe UI", 8, FontStyle.Regular)
            .ForeColor = Color.FromArgb(189, 195, 199)
            .AutoSize = False
            .Size = New Size(580, 20)
            .Location = New Point(10, 160)
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        pnlBottom.Controls.Add(lblCopyright)

        ' Add border effect
        AddHandler Me.Paint, AddressOf frmSplash_Paint

        ' Initialize timer
        loadingTimer = New Timer()
        loadingTimer.Interval = 30 ' Update every 30ms for smooth animation
        AddHandler loadingTimer.Tick, AddressOf LoadingTimer_Tick
    End Sub

    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StartLoading()
    End Sub

    Private Sub CreateLogoIcon()
        Dim bmp As New Bitmap(80, 80)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias

            ' Draw a box/package icon
            Using boxBrush As New SolidBrush(Color.FromArgb(52, 152, 219))
                g.FillRectangle(boxBrush, 15, 25, 50, 40)
            End Using

            ' Draw box outline and top
            Using boxPen As New Pen(Color.FromArgb(41, 128, 185), 3)
                g.DrawRectangle(boxPen, 15, 25, 50, 40)
                ' Top of box
                Dim topPoints() As Point = {
                    New Point(15, 25),
                    New Point(40, 10),
                    New Point(65, 25)
                }
                g.DrawLines(boxPen, topPoints)
                g.DrawLine(boxPen, 40, 10, 40, 25)
            End Using

            ' Add checkmark
            Using checkPen As New Pen(Color.White, 3)
                checkPen.StartCap = LineCap.Round
                checkPen.EndCap = LineCap.Round
                g.DrawLine(checkPen, 30, 45, 37, 52)
                g.DrawLine(checkPen, 37, 52, 52, 37)
            End Using
        End Using
        picLogo.Image = bmp
    End Sub

    Private Sub frmSplash_Paint(sender As Object, e As PaintEventArgs)
        ' Draw border
        Using pen As New Pen(Color.FromArgb(52, 152, 219), 3)
            e.Graphics.DrawRectangle(pen, 1, 1, Me.Width - 3, Me.Height - 3)
        End Using
    End Sub

    Private Sub LoadingTimer_Tick(sender As Object, e As EventArgs)
        If currentProgress < 100 Then
            currentProgress += 1
            SetProgress(currentProgress)
        Else
            loadingTimer.Stop()
            CompleteLoading()
        End If

    End Sub


    Private Sub UpdateLoadingMessage(progress As Integer)
        Select Case progress
            Case 0 To 20
                lblLoading.Text = "Initializing system..."
            Case 21 To 40
                lblLoading.Text = "Loading database connection..."
            Case 41 To 60
                lblLoading.Text = "Verifying user credentials..."
            Case 61 To 80
                lblLoading.Text = "Loading application modules..."
            Case 81 To 95
                lblLoading.Text = "Finalizing setup..."
            Case 96 To 100
                lblLoading.Text = "Ready! Starting application..."
        End Select
    End Sub

    Public Sub UpdateStatus(message As String)
        If lblLoading IsNot Nothing Then
            lblLoading.Text = message
            Me.Refresh()
        End If
    End Sub

    Public Sub StartLoading()
        currentProgress = 0
        progressBar.Value = 0
        lblPercentage.Text = "0%"
        loadingTimer.Start()
    End Sub

    Public Sub SetProgress(value As Integer)
        If value >= 0 AndAlso value <= 100 Then
            currentProgress = value
            progressBar.Value = value
            lblPercentage.Text = value.ToString() & "%"

            ' Update progress bar width to show visual progress
            Dim maxWidth As Integer = 498 ' Container width minus borders
            Dim newWidth As Integer = CInt((value / 100.0) * maxWidth)
            progressBar.Width = newWidth

            UpdateLoadingMessage(value)
            Me.Refresh()
        End If
    End Sub

    Public Sub CompleteLoading()
        currentProgress = 100
        progressBar.Value = 100
        lblPercentage.Text = "100%"
        lblLoading.Text = "Ready! Starting application..."
        System.Threading.Thread.Sleep(500)
        Me.Refresh()

    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If loadingTimer IsNot Nothing Then
                loadingTimer.Stop()
                loadingTimer.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
