Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Printing
Imports ZXing
Imports ZXing.QrCode

Public Class EmployeeDetailsViewFrm
    Private currentEmployeeId As Integer
    Private currentQRCodeData As String
    Private currentEmployeeNumber As String
    Private currentEmployeeName As String
    Private Const PRINTER_NAME As String = "Argox O4-250 PPLZ"

    ' Constructor with parameter
    Public Sub New(employeeId As Integer)
        InitializeComponent()
        currentEmployeeId = employeeId
    End Sub

    ' Property to set the employee ID before showing the form
    Public Property EmployeeId As Integer
        Get
            Return currentEmployeeId
        End Get
        Set(value As Integer)
            currentEmployeeId = value
        End Set
    End Property

    Private Sub EmployeeDetailsViewFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployeeDetails()
        LoadAssetHistory()
        LoadConsumableHistory()
    End Sub

    Private Sub LoadEmployeeDetails()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT e.*, 
                                       d.department_name, 
                                       p.position_name,
                                       CONCAT(s.first_name, ' ', s.last_name) as supervisor_name
                                       FROM employees e
                                       LEFT JOIN departments d ON e.department_id = d.department_id
                                       LEFT JOIN employee_positions p ON e.position_id = p.position_id
                                       LEFT JOIN employees s ON e.direct_supervisor_id = s.employee_id
                                       WHERE e.employee_id = @empId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@empId", currentEmployeeId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Store QR data for printing
                            currentQRCodeData = reader("qr_code_data").ToString()
                            currentEmployeeNumber = reader("employee_number").ToString()
                            currentEmployeeName = $"{reader("first_name")} {If(IsDBNull(reader("middle_name")), "", reader("middle_name").ToString())} {reader("last_name")}"

                            ' Basic Information
                            lblEmployeeNumberValue.Text = currentEmployeeNumber
                            lblFullNameValue.Text = currentEmployeeName
                            lblEmailValue.Text = If(IsDBNull(reader("email")), "-", reader("email").ToString())
                            lblPhoneValue.Text = If(IsDBNull(reader("phone_number")), "-", reader("phone_number").ToString())

                            ' Department and Position
                            lblDepartmentValue.Text = reader("department_name").ToString()
                            lblPositionValue.Text = reader("position_name").ToString()

                            ' Employment Details
                            lblHireDateValue.Text = Convert.ToDateTime(reader("hire_date")).ToString("MMMM dd, yyyy")
                            lblStatusValue.Text = reader("employment_status").ToString()
                            lblEmploymentTypeValue.Text = reader("employment_type").ToString()
                            lblSupervisorValue.Text = If(IsDBNull(reader("supervisor_name")), "-", reader("supervisor_name").ToString())

                            ' Generate QR Code using ZXing (same as EmployeeQRCodePrintFrm)
                            GenerateQRCode(currentQRCodeData)
                        Else
                            MessageBox.Show("Employee not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Me.Close()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading employee details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateQRCode(qrData As String)
        Try
            If String.IsNullOrEmpty(qrData) Then
                MessageBox.Show("No QR code data found for this employee.", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Use ZXing.Net library (same as EmployeeQRCodePrintFrm)
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

            Dim qrImage As Bitmap = writer.Write(qrData)

            If qrImage IsNot Nothing Then
                picQRCode.Image = qrImage
                picQRCode.SizeMode = PictureBoxSizeMode.Zoom
            Else
                MessageBox.Show("Failed to generate QR code image.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show($"Error generating QR code: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAssetHistory()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                                       a.asset_tag as 'Asset Tag',
                                       a.asset_name as 'Asset Name',
                                       ac.category_name as 'Category',
                                       ai.issue_date as 'Issue Date',
                                       ai.expected_return_date as 'Expected Return',
                                       ai.actual_return_date as 'Actual Return',
                                       ai.status as 'Status',
                                       ai.return_condition as 'Condition'
                                       FROM asset_issuance ai
                                       INNER JOIN assets a ON ai.asset_id = a.asset_id
                                       LEFT JOIN asset_categories ac ON a.category_id = ac.category_id
                                       WHERE ai.employee_id = @empId
                                       ORDER BY ai.issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@empId", currentEmployeeId)

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    dgvAssetHistory.DataSource = dt
                    FormatDataGridView(dgvAssetHistory)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading asset history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadConsumableHistory()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                                       c.consumable_code as 'Code',
                                       c.consumable_name as 'Consumable Name',
                                       cc.category_name as 'Category',
                                       ci.quantity_issued as 'Quantity',
                                       c.unit_of_measure as 'Unit',
                                       ci.issue_date as 'Issue Date',
                                       ci.purpose as 'Purpose'
                                       FROM consumable_issuance ci
                                       INNER JOIN consumables c ON ci.consumable_id = c.consumable_id
                                       LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id
                                       WHERE ci.employee_id = @empId
                                       ORDER BY ci.issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@empId", currentEmployeeId)

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    dgvConsumableHistory.DataSource = dt
                    FormatDataGridView(dgvConsumableHistory)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading consumable history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatDataGridView(dgv As DataGridView)
        ' Style the DataGridView
        dgv.DefaultCellStyle.Font = New Font("Segoe UI", 8)
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.EnableHeadersVisualStyles = False
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)

        ' Auto-size columns
        For Each col As DataGridViewColumn In dgv.Columns
            If col.Name.Contains("Date") Then
                col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
            End If
        Next
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            ' Open the Employee Edit Form
            Dim editForm As New AddEditEmployeeFrm(currentEmployeeId)

            If editForm.ShowDialog() = DialogResult.OK Then
                ' Refresh the details after edit
                LoadEmployeeDetails()
                LoadAssetHistory()
                LoadConsumableHistory()
                MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error opening edit form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim result As DialogResult = MessageBox.Show(
                $"Are you sure you want to delete employee {lblFullNameValue.Text}?" & vbCrLf & vbCrLf &
                "This action cannot be undone and will:" & vbCrLf &
                "• Remove all employee records" & vbCrLf &
                "• Maintain asset and consumable history for audit purposes",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    If conn Is Nothing Then Return

                    Using transaction As MySqlTransaction = conn.BeginTransaction()
                        Try
                            ' Delete employee
                            Dim query As String = "DELETE FROM employees WHERE employee_id = @empId"
                            Using cmd As New MySqlCommand(query, conn, transaction)
                                cmd.Parameters.AddWithValue("@empId", currentEmployeeId)
                                cmd.ExecuteNonQuery()
                            End Using

                            ' Log the activity
                            Dim logQuery As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description, ip_address) 
                                                     VALUES (@userId, 'Employee Deleted', 'employees', @empId, @desc, @ip)"
                            Using logCmd As New MySqlCommand(logQuery, conn, transaction)
                                logCmd.Parameters.AddWithValue("@userId", gCurrentUserId)
                                logCmd.Parameters.AddWithValue("@empId", currentEmployeeId)
                                logCmd.Parameters.AddWithValue("@desc", $"Deleted employee: {lblFullNameValue.Text}")
                                logCmd.Parameters.AddWithValue("@ip", GetLocalIPAddress())
                                logCmd.ExecuteNonQuery()
                            End Using

                            transaction.Commit()

                            MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                        Catch ex As Exception
                            transaction.Rollback()
                            Throw
                        End Try
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show($"Error deleting employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrintQR_Click(sender As Object, e As EventArgs) Handles btnPrintQR.Click
        Try
            ' Check if QR code data exists
            If String.IsNullOrEmpty(currentQRCodeData) Then
                MessageBox.Show("No QR code data available to print.", "No Data",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Check if Argox printer is available
            Dim argoxPrinter As String = Nothing
            For Each printerName As String In PrinterSettings.InstalledPrinters
                If printerName.Contains("Argox") AndAlso printerName.Contains("O4-250") Then
                    argoxPrinter = printerName
                    Exit For
                End If
            Next

            If argoxPrinter Is Nothing Then
                MessageBox.Show("Argox O4-250 PPLZ printer not found." & vbCrLf &
                              "Please install the printer driver and try again.",
                              "Printer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Print to Argox printer (same method as EmployeeQRCodePrintFrm)
            PrintToArgoxPrinter(argoxPrinter)

        Catch ex As Exception
            MessageBox.Show($"Error printing QR code: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintToArgoxPrinter(printerName As String)
        Try
            Dim printDoc As New PrintDocument()
            printDoc.PrinterSettings.PrinterName = printerName

            ' Set to 1.5" x 1" label size (in hundredths of an inch)
            printDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom Label", 150, 100)
            printDoc.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)

            ' Generate QR code for printing
            Dim qrImageForPrint As Bitmap = GenerateQRCodeForPrint(currentQRCodeData)

            If qrImageForPrint Is Nothing Then
                MessageBox.Show("Failed to generate QR code for printing.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            AddHandler printDoc.PrintPage, Sub(printSender As Object, printArgs As PrintPageEventArgs)
                                               PrintPureQR(printArgs.Graphics, qrImageForPrint)
                                               printArgs.HasMorePages = False
                                           End Sub

            printDoc.Print()

            MessageBox.Show("QR label sent to printer successfully!", "Print Complete",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show($"Error printing to Argox printer: {ex.Message}", "Print Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateQRCodeForPrint(qrData As String) As Bitmap
        Try
            If String.IsNullOrEmpty(qrData) Then
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

            Return writer.Write(qrData)

        Catch ex As Exception
            MessageBox.Show($"Error generating QR code: {ex.Message}", "QR Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Private Sub PrintPureQR(g As Graphics, qrImage As Bitmap)
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
        If qrImage IsNot Nothing Then
            ' Use high quality interpolation for crisp QR code
            g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
            g.PixelOffsetMode = Drawing2D.PixelOffsetMode.Half
            g.SmoothingMode = Drawing2D.SmoothingMode.None

            ' Draw the QR code
            g.DrawImage(qrImage, qrX, qrY, qrSize, qrSize)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function GetLocalIPAddress() As String
        Try
            Dim host As String = System.Net.Dns.GetHostName()
            Dim ip As System.Net.IPAddress = System.Net.Dns.GetHostEntry(host).AddressList.FirstOrDefault(Function(x) x.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)
            If ip IsNot Nothing Then
                Return ip.ToString()
            End If
        Catch ex As Exception
            ' Return default if error
        End Try
        Return "Unknown"
    End Function
End Class