Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.IO
Imports QRCoder ' Install-Package QRCoder via NuGet

Public Class QRCodeGeneratorFrm
    Private assetTag As String
    Private assetName As String
    Private qrImage As Bitmap
    Private WithEvents printDoc As New PrintDocument()

    Public Sub New(tag As String, name As String)
        InitializeComponent()
        Me.assetTag = tag
        Me.assetName = name
    End Sub

    Private Sub QRCodeGeneratorFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Display asset information
        lblAssetTag.Text = assetTag
        lblAssetName.Text = assetName

        ' Generate QR Code
        GenerateQRCode()
    End Sub

    ''' <summary>
    ''' Generate QR Code image
    ''' </summary>
    Private Sub GenerateQRCode()
        Try
            ' Create QR Code generator
            Dim qrGenerator As New QRCodeGenerator()
            Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(assetTag, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode As New QRCode(qrCodeData)

            ' Generate QR Code image (500x500 pixels, white background)
            qrImage = qrCode.GetGraphic(20, Color.Black, Color.White, True)

            ' Display in PictureBox
            picQRCode.Image = qrImage
            picQRCode.SizeMode = PictureBoxSizeMode.Zoom

            lblStatus.Text = "QR Code generated successfully!"
            lblStatus.ForeColor = Color.Green

        Catch ex As Exception
            MessageBox.Show("Error generating QR Code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = "Failed to generate QR Code"
            lblStatus.ForeColor = Color.Red
        End Try
    End Sub

    ''' <summary>
    ''' Print QR code directly to Argox O4-250 PPLZ (no text)
    ''' </summary>
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            ' Ensure QR exists
            If qrImage Is Nothing Then
                MessageBox.Show("No QR Code to print!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Configure printer directly
            printDoc.PrinterSettings = New PrinterSettings()
            printDoc.PrinterSettings.PrinterName = "Argox O4-250 PPLZ"

            ' Check if printer exists
            If Not printDoc.PrinterSettings.IsValid Then
                MessageBox.Show("Printer 'Argox O4-250 PPLZ' not found!", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Set paper size to 1.5 x 1 inches
            Dim paperWidthInches As Single = 1.5F
            Dim paperHeightInches As Single = 1.0F
            Dim hundredthsOfInch As Integer = 100

            Dim paperSize As New PaperSize("Sticker 1.5x1",
                                       CInt(paperWidthInches * hundredthsOfInch),
                                       CInt(paperHeightInches * hundredthsOfInch))
            printDoc.DefaultPageSettings.PaperSize = paperSize
            printDoc.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

            ' Print directly (no dialog)
            printDoc.Print()

        Catch ex As Exception
            MessageBox.Show("Error printing: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' What gets printed - QR only, centered on the sticker
    ''' </summary>
    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles printDoc.PrintPage
        Try
            Dim pageBounds As Rectangle = e.PageBounds

            ' Determine size (fit within sticker with a bit of padding)
            Dim padding As Integer = 5
            Dim qrWidth As Integer = pageBounds.Width - (padding * 2)
            Dim qrHeight As Integer = pageBounds.Height - (padding * 2)

            ' Center coordinates
            Dim qrX As Integer = (pageBounds.Width - qrWidth) \ 2
            Dim qrY As Integer = (pageBounds.Height - qrHeight) \ 2

            ' Draw only the QR code image
            e.Graphics.DrawImage(qrImage, qrX, qrY, qrWidth, qrHeight)

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show("Error during print: " & ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Save QR Code button click
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If qrImage Is Nothing Then
                MessageBox.Show("No QR Code to save!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Create save file dialog
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp"
            saveDialog.Title = "Save QR Code"
            saveDialog.FileName = $"QR_{assetTag}_{DateTime.Now:yyyyMMdd_HHmmss}"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                ' Determine image format based on extension
                Dim format As ImageFormat = ImageFormat.Png

                Select Case Path.GetExtension(saveDialog.FileName).ToLower()
                    Case ".jpg", ".jpeg"
                        format = ImageFormat.Jpeg
                    Case ".bmp"
                        format = ImageFormat.Bmp
                End Select

                ' Save the image
                qrImage.Save(saveDialog.FileName, format)

                MessageBox.Show("QR Code saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error saving QR Code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Copy to Clipboard button click
    ''' </summary>
    Private Sub btnCopyClipboard_Click(sender As Object, e As EventArgs) Handles btnCopyClipboard.Click
        Try
            If qrImage IsNot Nothing Then
                Clipboard.SetImage(qrImage)
                MessageBox.Show("QR Code copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No QR Code to copy!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error copying to clipboard: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Close button click
    ''' </summary>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Form closing - cleanup
    ''' </summary>
    Private Sub QRCodeGeneratorFrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If qrImage IsNot Nothing Then
            qrImage.Dispose()
        End If
    End Sub

End Class