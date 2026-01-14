Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Printing
Imports ZXing
Imports ZXing.QrCode

Public Class EmployeeQRCodePrintFrm

    Private employeeIds As List(Of Integer)
    Private employeeQRData As New List(Of EmployeeQRInfo)
    Private Const PRINTER_NAME As String = "Argox O4-250 PPLZ"

    ' Class to hold employee QR information
    Private Class EmployeeQRInfo
        Public Property EmployeeId As Integer
        Public Property EmployeeNumber As String
        Public Property EmployeeName As String
        Public Property Department As String
        Public Property Position As String
        Public Property QRCodeData As String
        Public Property QRImage As Bitmap
    End Class

    Public Sub New(selectedEmployeeIds As List(Of Integer))
        InitializeComponent()
        employeeIds = selectedEmployeeIds
    End Sub

    Private Sub EmployeeQRCodePrintFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployeeQRData()
        DisplayQRCodes()
        CheckPrinterAvailability()
    End Sub

    Private Sub CheckPrinterAvailability()
        Try
            Dim printerFound As Boolean = False
            Dim foundPrinterName As String = ""

            For Each printerName As String In PrinterSettings.InstalledPrinters
                If printerName.Contains("Argox") AndAlso printerName.Contains("O4-250") Then
                    printerFound = True
                    foundPrinterName = printerName
                    Exit For
                End If
            Next

            If printerFound Then
                lblPrinterStatus.Text = $"✓ Printer: {foundPrinterName}"
                lblPrinterStatus.ForeColor = Color.FromArgb(46, 204, 113)
            Else
                lblPrinterStatus.Text = $"✗ Printer: {PRINTER_NAME} (Not Found)"
                lblPrinterStatus.ForeColor = Color.FromArgb(231, 76, 60)
                btnPrint.Enabled = False
                MessageBox.Show($"Argox O4-250 PPLZ printer not found.{vbCrLf}Please install the printer driver and try again.",
                              "Printer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblPrinterStatus.ForeColor = Color.FromArgb(231, 76, 60)
            MessageBox.Show($"Error checking printer: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub LoadEmployeeQRData()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then
                    MessageBox.Show("Unable to connect to database.", "Connection Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                For Each empId As Integer In employeeIds
                    Dim query As String = "SELECT e.employee_id, e.employee_number, e.qr_code_data,
                                             CONCAT(e.first_name, ' ', COALESCE(e.middle_name, ''), ' ', e.last_name) as full_name,
                                             d.department_name,
                                             ep.position_name
                                      FROM employees e
                                      INNER JOIN departments d ON e.department_id = d.department_id
                                      INNER JOIN employee_positions ep ON e.position_id = ep.position_id
                                      WHERE e.employee_id = @empId"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@empId", empId)

                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim qrData As String = reader("qr_code_data").ToString()

                                ' Check if QR data exists
                                If String.IsNullOrEmpty(qrData) Then
                                    MessageBox.Show($"Warning: No QR data found for employee ID {empId}",
                                                  "Missing QR Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Continue For
                                End If

                                Dim qrInfo As New EmployeeQRInfo With {
                                    .EmployeeId = reader.GetInt32("employee_id"),
                                    .EmployeeNumber = reader("employee_number").ToString(),
                                    .EmployeeName = reader("full_name").ToString(),
                                    .Department = reader("department_name").ToString(),
                                    .Position = reader("position_name").ToString(),
                                    .QRCodeData = qrData
                                }

                                ' Generate QR Code Image for preview only
                                qrInfo.QRImage = GenerateQRCode(qrInfo.QRCodeData)

                                If qrInfo.QRImage Is Nothing Then
                                    MessageBox.Show($"Warning: Failed to generate QR code for {qrInfo.EmployeeNumber}",
                                                  "QR Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If

                                employeeQRData.Add(qrInfo)
                            End If
                        End Using
                    End Using
                Next

                If employeeQRData.Count = 0 Then
                    MessageBox.Show("No employee data loaded. Please check database records.",
                                  "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading employee data: {ex.Message}{vbCrLf}{vbCrLf}Stack Trace: {ex.StackTrace}",
                          "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateQRCode(data As String) As Bitmap
        Try
            If String.IsNullOrEmpty(data) Then
                Return Nothing
            End If

            Dim writer As New BarcodeWriter() With {
                .Format = BarcodeFormat.QR_CODE,
                .Options = New ZXing.QrCode.QrCodeEncodingOptions() With {
                    .Height = 300,
                    .Width = 300,
                    .Margin = 0,
                    .CharacterSet = "UTF-8",
                    .ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M
                }
            }

            Dim qrImage As Bitmap = writer.Write(data)
            Return qrImage

        Catch ex As Exception
            MessageBox.Show($"Error generating QR code: {ex.Message}", "QR Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Private Sub DisplayQRCodes()
        flpQRCodes.Controls.Clear()

        For Each qrInfo As EmployeeQRInfo In employeeQRData
            ' Create card panel for QR preview with modern design
            Dim panel As New Panel() With {
                .Width = 220,
                .Height = 280,
                .BorderStyle = BorderStyle.None,
                .Margin = New Padding(15),
                .BackColor = Color.White
            }

            ' Add subtle shadow effect with a border panel
            Dim borderPanel As New Panel() With {
                .Width = 220,
                .Height = 280,
                .BackColor = Color.FromArgb(230, 230, 230),
                .Location = New Point(2, 2)
            }

            ' Inner white panel
            Dim innerPanel As New Panel() With {
                .Width = 216,
                .Height = 276,
                .BackColor = Color.White,
                .Location = New Point(2, 2)
            }
            borderPanel.Controls.Add(innerPanel)

            ' QR Code container with centered QR
            Dim qrContainer As New Panel() With {
                .Width = 180,
                .Height = 180,
                .Left = 18,
                .Top = 15,
                .BackColor = Color.White,
                .BorderStyle = BorderStyle.FixedSingle
            }

            ' QR Code Preview - Centered and larger
            Dim picQR As New PictureBox() With {
                .Image = qrInfo.QRImage,
                .SizeMode = PictureBoxSizeMode.Zoom,
                .Width = 170,
                .Height = 170,
                .Left = 5,
                .Top = 5,
                .BackColor = Color.White
            }
            qrContainer.Controls.Add(picQR)
            innerPanel.Controls.Add(qrContainer)

            ' Employee Name label
            Dim lblName As New Label() With {
                .Text = qrInfo.EmployeeName,
                .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Width = 200,
                .Left = 8,
                .Top = 205,
                .ForeColor = Color.FromArgb(52, 73, 94),
                .AutoEllipsis = True
            }
            innerPanel.Controls.Add(lblName)

            ' Employee Number label
            Dim lblEmpNo As New Label() With {
                .Text = $"ID: {qrInfo.EmployeeNumber}",
                .Font = New Font("Segoe UI", 8, FontStyle.Regular),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Width = 200,
                .Left = 8,
                .Top = 228,
                .ForeColor = Color.FromArgb(127, 140, 141)
            }
            innerPanel.Controls.Add(lblEmpNo)

            ' Department/Position label
            Dim lblDept As New Label() With {
                .Text = $"{qrInfo.Department}",
                .Font = New Font("Segoe UI", 7.5, FontStyle.Italic),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Width = 200,
                .Left = 8,
                .Top = 248,
                .ForeColor = Color.FromArgb(149, 165, 166),
                .AutoEllipsis = True
            }
            innerPanel.Controls.Add(lblDept)

            panel.Controls.Add(borderPanel)
            flpQRCodes.Controls.Add(panel)
        Next

        ' Center the FlowLayoutPanel content
        flpQRCodes.FlowDirection = FlowDirection.LeftToRight
        flpQRCodes.WrapContents = True
        flpQRCodes.AutoScroll = True

        ' Update label count after loading data
        If employeeQRData.Count > 0 Then
            lblCount.Text = $"Total QR Labels: {employeeQRData.Count}"
            CheckPrinterAvailability()
        Else
            lblCount.Text = "Total QR Labels: 0"
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If employeeQRData.Count = 0 Then
            MessageBox.Show("No QR codes to print.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Print directly
            PrintToArgoxPrinter()

        Catch ex As Exception
            MessageBox.Show($"Error printing: {ex.Message}", "Print Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintToArgoxPrinter()
        Try
            ' Find Argox printer
            Dim argoxPrinter As String = Nothing
            For Each printerName As String In PrinterSettings.InstalledPrinters
                If printerName.Contains("Argox") AndAlso printerName.Contains("O4-250") Then
                    argoxPrinter = printerName
                    Exit For
                End If
            Next

            If argoxPrinter Is Nothing Then
                MessageBox.Show("Argox O4-250 PPLZ printer not found.", "Printer Not Found",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim printDoc As New PrintDocument()
            printDoc.PrinterSettings.PrinterName = argoxPrinter

            ' Set to 1.5" x 1" label size (in hundredths of an inch)
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom Label", 150, 100)
            printDoc.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

            Dim currentIndex As Integer = 0

            AddHandler printDoc.PrintPage, Sub(printSender As Object, printArgs As PrintPageEventArgs)
                                               If currentIndex < employeeQRData.Count Then
                                                   ' Print pure QR code only (no text, no borders)
                                                   PrintPureQR(printArgs.Graphics, employeeQRData(currentIndex))
                                                   currentIndex += 1
                                                   printArgs.HasMorePages = (currentIndex < employeeQRData.Count)
                                               End If
                                           End Sub

            printDoc.Print()

            MessageBox.Show($"{employeeQRData.Count} QR label(s) sent to printer successfully!", "Print Complete",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show($"Error printing to Argox printer: {ex.Message}", "Print Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintPureQR(g As Graphics, qrInfo As EmployeeQRInfo)
        ' Label size: 1.5" x 1" at 100 DPI = 150 x 100 pixels
        Dim labelWidth As Integer = 150
        Dim labelHeight As Integer = 100

        ' QR code fills the entire label with small margin for scanning reliability
        Dim margin As Integer = 5
        Dim qrSize As Integer = Math.Min(labelWidth, labelHeight) - (margin * 2)

        ' Center the QR code
        Dim qrX As Integer = (labelWidth - qrSize) \ 2
        Dim qrY As Integer = (labelHeight - qrSize) \ 2

        ' Fill background with white
        g.Clear(Color.White)
        g.FillRectangle(Brushes.White, 0, 0, labelWidth, labelHeight)

        ' Draw ONLY the QR Code - centered, no text, no borders
        If qrInfo.QRImage IsNot Nothing Then
            ' Use high quality interpolation for crisp QR code
            g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
            g.SmoothingMode = Drawing2D.SmoothingMode.None

            ' Draw the QR code
            g.DrawImage(qrInfo.QRImage, qrX, qrY, qrSize, qrSize)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class