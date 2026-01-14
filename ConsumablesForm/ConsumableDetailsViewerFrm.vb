Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class ConsumableDetailsViewerFrm
    Private consumableId As Integer = 0
    Private currentConsumableCode As String = ""
    Private currentConsumableName As String = ""
    Private currentStock As Integer = 0
    Private currentMinStock As Integer = 0
    Private currentReorderLevel As Integer = 0

    ' Constructor
    Public Sub New(consumableIdToView As Integer)
        InitializeComponent()
        consumableId = consumableIdToView
    End Sub

    Private Sub ConsumableDetailsViewerFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadConsumableDetails()
        LoadIssuanceHistory()
        LoadStockMovement()
        StyleDataGridViews()
    End Sub

    ''' <summary>
    ''' Style DataGridViews
    ''' </summary>
    Private Sub StyleDataGridViews()
        StyleDataGridView(dgvIssuanceHistory)
        StyleDataGridView(dgvStockMovement)
    End Sub

    ''' <summary>
    ''' Style a DataGridView
    ''' </summary>
    Private Sub StyleDataGridView(dgv As DataGridView)
        With dgv
            ' Header style
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 35
            .EnableHeadersVisualStyles = False

            ' Row style
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.FromArgb(52, 73, 94)
            .DefaultCellStyle.Font = New Font("Segoe UI", 8)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(142, 68, 173)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .RowTemplate.Height = 30
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)

            ' Grid style
            .GridColor = Color.FromArgb(189, 195, 199)
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        End With
    End Sub

    ''' <summary>
    ''' Load consumable details
    ''' </summary>
    Private Sub LoadConsumableDetails()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    c.consumable_code, c.consumable_name, c.description,
                    cc.category_name, cs.subcategory_name,
                    c.unit_of_measure, c.unit_cost,
                    c.total_quantity_in_stock, c.minimum_stock_level, c.reorder_level
                    FROM consumables c
                    LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id
                    LEFT JOIN consumable_subcategories cs ON c.subcategory_id = cs.subcategory_id
                    WHERE c.consumable_id = @consumableId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@consumableId", consumableId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Store for later use
                            currentConsumableCode = reader("consumable_code").ToString()
                            currentConsumableName = reader("consumable_name").ToString()
                            currentStock = If(IsDBNull(reader("total_quantity_in_stock")), 0, Convert.ToInt32(reader("total_quantity_in_stock")))
                            currentMinStock = If(IsDBNull(reader("minimum_stock_level")), 0, Convert.ToInt32(reader("minimum_stock_level")))
                            currentReorderLevel = If(IsDBNull(reader("reorder_level")), 0, Convert.ToInt32(reader("reorder_level")))

                            ' Basic information
                            lblConsumableCodeValue.Text = currentConsumableCode
                            lblConsumableNameValue.Text = currentConsumableName

                            ' Category information
                            lblCategoryValue.Text = If(IsDBNull(reader("category_name")), "-", reader("category_name").ToString())
                            lblSubcategoryValue.Text = If(IsDBNull(reader("subcategory_name")), "-", reader("subcategory_name").ToString())

                            ' Unit and cost
                            lblUnitMeasureValue.Text = If(IsDBNull(reader("unit_of_measure")), "-", reader("unit_of_measure").ToString())

                            Dim unitCost As Decimal = If(IsDBNull(reader("unit_cost")), 0D, Convert.ToDecimal(reader("unit_cost")))
                            lblUnitCostValue.Text = $"₱{unitCost:N2}"

                            ' Description
                            lblDescriptionValue.Text = If(IsDBNull(reader("description")), "-", reader("description").ToString())

                            ' Stock information
                            lblCurrentStockValue.Text = $"{currentStock} {lblUnitMeasureValue.Text}"
                            lblMinStockValue.Text = $"{currentMinStock} {lblUnitMeasureValue.Text}"
                            lblReorderLevelValue.Text = $"{currentReorderLevel} {lblUnitMeasureValue.Text}"

                            ' Stock status with color coding
                            UpdateStockStatus()

                            ' Update form title
                            lblTitle.Text = $"📦 Consumable Details - {currentConsumableCode}"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading consumable details: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Update stock status display
    ''' </summary>
    Private Sub UpdateStockStatus()
        Dim status As String = ""
        Dim statusColor As Color = Color.FromArgb(46, 204, 113) ' Default green

        If currentStock <= currentMinStock Then
            status = "⛔ Critical"
            statusColor = Color.FromArgb(231, 76, 60) ' Red
        ElseIf currentStock <= currentReorderLevel Then
            status = "⚠ Low Stock"
            statusColor = Color.FromArgb(241, 196, 15) ' Yellow
        Else
            status = "✓ Sufficient"
            statusColor = Color.FromArgb(46, 204, 113) ' Green
        End If

        lblStockStatusValue.Text = status
        lblStockStatusValue.ForeColor = statusColor
        pnlStockIndicator.BackColor = statusColor
    End Sub

    ''' <summary>
    ''' Load issuance history
    ''' </summary>
    Private Sub LoadIssuanceHistory()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    CONCAT(e.first_name, ' ', e.last_name) AS 'Employee',
                    e.employee_number AS 'Employee No.',
                    d.department_name AS 'Department',
                    ci.quantity_issued AS 'Quantity',
                    DATE_FORMAT(ci.issue_date, '%Y-%m-%d %H:%i') AS 'Issue Date',
                    ci.purpose AS 'Purpose',
                    CONCAT(u.first_name, ' ', u.last_name) AS 'Issued By'
                    FROM consumable_issuance ci
                    INNER JOIN employees e ON ci.employee_id = e.employee_id
                    INNER JOIN departments d ON ci.department_id = d.department_id
                    INNER JOIN users u ON ci.issued_by = u.user_id
                    WHERE ci.consumable_id = @consumableId
                    ORDER BY ci.issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@consumableId", consumableId)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvIssuanceHistory.DataSource = dt

                        If dt.Rows.Count = 0 Then
                            dgvIssuanceHistory.DataSource = Nothing
                            ' Show message in grid
                            Dim emptyDt As New DataTable()
                            emptyDt.Columns.Add("Message")
                            emptyDt.Rows.Add("No issuance history found")
                            dgvIssuanceHistory.DataSource = emptyDt
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error loading issuance history: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Load stock movement / request history
    ''' </summary>
    Private Sub LoadStockMovement()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    'Request' AS 'Type',
                    cr.quantity_requested AS 'Quantity',
                    cr.status AS 'Status',
                    cr.priority AS 'Priority',
                    cr.reason AS 'Reason',
                    DATE_FORMAT(cr.request_date, '%Y-%m-%d') AS 'Date',
                    CONCAT(u.first_name, ' ', u.last_name) AS 'Requested By',
                    d.department_name AS 'Department'
                    FROM consumable_requests cr
                    INNER JOIN users u ON cr.requested_by = u.user_id
                    INNER JOIN departments d ON cr.department_id = d.department_id
                    WHERE cr.consumable_id = @consumableId
                    ORDER BY cr.request_date DESC
                    LIMIT 50"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@consumableId", consumableId)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvStockMovement.DataSource = dt

                        If dt.Rows.Count = 0 Then
                            dgvStockMovement.DataSource = Nothing
                            ' Show message in grid
                            Dim emptyDt As New DataTable()
                            emptyDt.Columns.Add("Message")
                            emptyDt.Rows.Add("No request history found")
                            dgvStockMovement.DataSource = emptyDt
                        Else
                            ' Color code status column
                            If dgvStockMovement.Columns.Contains("Status") Then
                                For Each row As DataGridViewRow In dgvStockMovement.Rows
                                    If Not row.IsNewRow AndAlso row.Cells("Status").Value IsNot Nothing Then
                                        Dim status As String = row.Cells("Status").Value.ToString()
                                        Select Case status.ToUpper()
                                            Case "PENDING"
                                                row.Cells("Status").Style.BackColor = Color.FromArgb(241, 196, 15)
                                                row.Cells("Status").Style.ForeColor = Color.White
                                            Case "APPROVED"
                                                row.Cells("Status").Style.BackColor = Color.FromArgb(46, 204, 113)
                                                row.Cells("Status").Style.ForeColor = Color.White
                                            Case "REJECTED"
                                                row.Cells("Status").Style.BackColor = Color.FromArgb(231, 76, 60)
                                                row.Cells("Status").Style.ForeColor = Color.White
                                            Case "FULFILLED"
                                                row.Cells("Status").Style.BackColor = Color.FromArgb(52, 152, 219)
                                                row.Cells("Status").Style.ForeColor = Color.White
                                        End Select
                                    End If
                                Next
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error loading stock movement: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Edit consumable button
    ''' </summary>
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Dim editForm As New AddEditConsumableFrm(consumableId)
            If editForm.ShowDialog() = DialogResult.OK Then
                ' Reload consumable details
                LoadConsumableDetails()
                LoadIssuanceHistory()
                LoadStockMovement()

                MessageBox.Show("Consumable updated successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening edit form: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Delete consumable button
    ''' </summary>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result = MessageBox.Show($"Are you sure you want to delete this consumable?" & vbCrLf & vbCrLf &
                                    $"Code: {currentConsumableCode}" & vbCrLf &
                                    $"Name: {currentConsumableName}" & vbCrLf & vbCrLf &
                                    "This action cannot be undone!",
                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    If conn Is Nothing Then Return

                    ' Check if consumable has been issued
                    Dim checkQuery As String = "SELECT COUNT(*) FROM consumable_issuance WHERE consumable_id = @consumableId"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@consumableId", consumableId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("This consumable cannot be deleted because it has issuance history.",
                                          "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Delete consumable
                    Dim deleteQuery As String = "DELETE FROM consumables WHERE consumable_id = @consumableId"
                    Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@consumableId", consumableId)
                        deleteCmd.ExecuteNonQuery()
                    End Using

                    ' Log activity
                    LogActivity(gCurrentUserId, "Consumable Deleted", "consumables", consumableId,
                               $"Deleted consumable: {currentConsumableCode} - {currentConsumableName}")

                    MessageBox.Show("Consumable deleted successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting consumable: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Adjust stock button
    ''' </summary>
    Private Sub btnAdjustStock_Click(sender As Object, e As EventArgs) Handles btnAdjustStock.Click
        Try
            ' Prompt for stock adjustment
            Dim input As String = InputBox($"Current Stock: {currentStock} {lblUnitMeasureValue.Text}" & vbCrLf & vbCrLf &
                                          "Enter adjustment amount:" & vbCrLf &
                                          "(Use negative numbers to decrease stock)" & vbCrLf & vbCrLf &
                                          "Example: +50 or -20",
                                          "Adjust Stock", "")

            If String.IsNullOrWhiteSpace(input) Then Return

            Dim adjustment As Integer = 0
            If Not Integer.TryParse(input, adjustment) Then
                MessageBox.Show("Please enter a valid number.", "Invalid Input",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim newStock As Integer = currentStock + adjustment

            If newStock < 0 Then
                MessageBox.Show("Stock cannot be negative.", "Invalid Adjustment",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Confirm adjustment
            Dim confirmMsg As String = $"Current Stock: {currentStock}" & vbCrLf &
                                      $"Adjustment: {If(adjustment > 0, "+", "")}{adjustment}" & vbCrLf &
                                      $"New Stock: {newStock}" & vbCrLf & vbCrLf &
                                      "Confirm stock adjustment?"

            Dim confirm = MessageBox.Show(confirmMsg, "Confirm Adjustment",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirm = DialogResult.Yes Then
                UpdateStock(newStock, adjustment)
            End If

        Catch ex As Exception
            MessageBox.Show("Error adjusting stock: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Update stock in database
    ''' </summary>
    Private Sub UpdateStock(newStock As Integer, adjustment As Integer)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "UPDATE consumables SET total_quantity_in_stock = @newStock WHERE consumable_id = @consumableId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@newStock", newStock)
                    cmd.Parameters.AddWithValue("@consumableId", consumableId)
                    cmd.ExecuteNonQuery()
                End Using

                ' Log activity
                Dim adjustmentType As String = If(adjustment > 0, "increased", "decreased")
                LogActivity(gCurrentUserId, "Stock Adjusted", "consumables", consumableId,
                           $"Stock {adjustmentType} by {Math.Abs(adjustment)} for {currentConsumableCode}")

                MessageBox.Show("Stock adjusted successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Reload details
                LoadConsumableDetails()
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' Print label button
    ''' </summary>
    Private Sub btnPrintLabel_Click(sender As Object, e As EventArgs) Handles btnPrintLabel.Click
        Try
            MessageBox.Show($"Print Label for: {currentConsumableCode}" & vbCrLf & vbCrLf &
                           "Label printing functionality will be implemented here." & vbCrLf &
                           "This will print a label with barcode and consumable details.",
                           "Print Label", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' TODO: Implement label printing

        Catch ex As Exception
            MessageBox.Show("Error printing label: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Close button
    ''' </summary>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Log activity to database
    ''' </summary>
    Private Sub LogActivity(userId As Integer, actionType As String, tableName As String, recordId As Integer, description As String)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description, ip_address) 
                                       VALUES (@userId, @actionType, @tableName, @recordId, @description, @ipAddress)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)
                    cmd.Parameters.AddWithValue("@actionType", actionType)
                    cmd.Parameters.AddWithValue("@tableName", tableName)
                    cmd.Parameters.AddWithValue("@recordId", recordId)
                    cmd.Parameters.AddWithValue("@description", description)
                    cmd.Parameters.AddWithValue("@ipAddress", GetLocalIPAddress())
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error logging activity: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Get local IP address
    ''' </summary>
    Private Function GetLocalIPAddress() As String
        Try
            Dim host As String = System.Net.Dns.GetHostName()
            Dim ip As System.Net.IPAddress = System.Net.Dns.GetHostEntry(host).AddressList.FirstOrDefault(Function(x) x.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)
            If ip IsNot Nothing Then
                Return ip.ToString()
            End If
        Catch ex As Exception
        End Try
        Return "Unknown"
    End Function
End Class