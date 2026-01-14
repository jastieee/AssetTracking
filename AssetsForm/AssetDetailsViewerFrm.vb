Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class AssetDetailsViewerFrm
    Private assetId As Integer = 0
    Private currentAssetTag As String = ""
    Private currentAssetName As String = ""
    Private currentStatus As String = ""

    ' Constructor
    Public Sub New(assetIdToView As Integer)
        InitializeComponent()
        assetId = assetIdToView
    End Sub

    Private Sub AssetDetailsViewerFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAssetDetails()
        LoadIssuanceHistory()
        LoadMaintenanceHistory()
        StyleDataGridViews()
    End Sub

    ''' <summary>
    ''' Style DataGridViews
    ''' </summary>
    Private Sub StyleDataGridViews()
        StyleDataGridView(dgvIssuanceHistory)
        StyleDataGridView(dgvMaintenanceHistory)
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
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
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
    ''' Load asset details
    ''' </summary>
    Private Sub LoadAssetDetails()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    a.asset_tag, a.asset_name, a.description,
                    ac.category_name, asub.subcategory_name,
                    a.status, a.condition_status,
                    a.serial_number, a.model, a.manufacturer,
                    DATE_FORMAT(a.purchase_date, '%Y-%m-%d') AS purchase_date,
                    d.department_name
                    FROM assets a
                    LEFT JOIN asset_categories ac ON a.category_id = ac.category_id
                    LEFT JOIN asset_subcategories asub ON a.subcategory_id = asub.subcategory_id
                    LEFT JOIN departments d ON a.current_department_id = d.department_id
                    WHERE a.asset_id = @assetId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@assetId", assetId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Store for later use
                            currentAssetTag = reader("asset_tag").ToString()
                            currentAssetName = reader("asset_name").ToString()
                            currentStatus = reader("status").ToString()

                            ' Basic information
                            lblAssetTagValue.Text = currentAssetTag
                            lblAssetNameValue.Text = currentAssetName

                            ' Category information
                            lblCategoryValue.Text = If(IsDBNull(reader("category_name")), "-", reader("category_name").ToString())
                            lblSubcategoryValue.Text = If(IsDBNull(reader("subcategory_name")), "-", reader("subcategory_name").ToString())

                            ' Status with color coding
                            Dim status As String = reader("status").ToString()
                            lblStatusValue.Text = status
                            SetStatusColor(lblStatusValue, status)

                            ' Condition with color coding
                            Dim condition As String = reader("condition_status").ToString()
                            lblConditionValue.Text = condition
                            SetConditionColor(lblConditionValue, condition)

                            ' Additional details
                            lblSerialValue.Text = If(IsDBNull(reader("serial_number")), "-", reader("serial_number").ToString())
                            lblModelValue.Text = If(IsDBNull(reader("model")), "-", reader("model").ToString())
                            lblManufacturerValue.Text = If(IsDBNull(reader("manufacturer")), "-", reader("manufacturer").ToString())
                            lblPurchaseDateValue.Text = If(IsDBNull(reader("purchase_date")), "-", reader("purchase_date").ToString())
                            lblDepartmentValue.Text = If(IsDBNull(reader("department_name")), "-", reader("department_name").ToString())
                            lblDescriptionValue.Text = If(IsDBNull(reader("description")), "-", reader("description").ToString())

                            ' Update form title
                            lblTitle.Text = $"📦 Asset Details - {currentAssetTag}"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading asset details: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Set status label color
    ''' </summary>
    Private Sub SetStatusColor(lbl As Label, status As String)
        Select Case status.ToUpper()
            Case "IN STOCK"
                lbl.ForeColor = Color.FromArgb(46, 204, 113) ' Green
            Case "ISSUED"
                lbl.ForeColor = Color.FromArgb(52, 152, 219) ' Blue
            Case "UNDER MAINTENANCE"
                lbl.ForeColor = Color.FromArgb(243, 156, 18) ' Orange
            Case "DISPOSED"
                lbl.ForeColor = Color.FromArgb(127, 140, 141) ' Gray
            Case "LOST"
                lbl.ForeColor = Color.FromArgb(231, 76, 60) ' Red
            Case Else
                lbl.ForeColor = Color.FromArgb(52, 73, 94) ' Default
        End Select
    End Sub

    ''' <summary>
    ''' Set condition label color
    ''' </summary>
    Private Sub SetConditionColor(lbl As Label, condition As String)
        Select Case condition.ToUpper()
            Case "EXCELLENT"
                lbl.ForeColor = Color.FromArgb(46, 204, 113) ' Green
            Case "GOOD"
                lbl.ForeColor = Color.FromArgb(52, 152, 219) ' Blue
            Case "FAIR"
                lbl.ForeColor = Color.FromArgb(243, 156, 18) ' Orange
            Case "POOR"
                lbl.ForeColor = Color.FromArgb(231, 76, 60) ' Red
            Case Else
                lbl.ForeColor = Color.FromArgb(52, 73, 94) ' Default
        End Select
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
                    DATE_FORMAT(ai.issue_date, '%Y-%m-%d') AS 'Issue Date',
                    DATE_FORMAT(ai.expected_return_date, '%Y-%m-%d') AS 'Expected Return',
                    DATE_FORMAT(ai.actual_return_date, '%Y-%m-%d') AS 'Actual Return',
                    ai.status AS 'Status',
                    ai.return_condition AS 'Return Condition',
                    CONCAT(u.first_name, ' ', u.last_name) AS 'Issued By'
                    FROM asset_issuance ai
                    INNER JOIN employees e ON ai.employee_id = e.employee_id
                    INNER JOIN departments d ON e.department_id = d.department_id
                    INNER JOIN users u ON ai.issued_by = u.user_id
                    WHERE ai.asset_id = @assetId
                    ORDER BY ai.issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@assetId", assetId)

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
    ''' Load maintenance history
    ''' </summary>
    Private Sub LoadMaintenanceHistory()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    am.maintenance_type AS 'Type',
                    DATE_FORMAT(am.maintenance_date, '%Y-%m-%d') AS 'Date',
                    am.performed_by AS 'Performed By',
                    CONCAT('₱', FORMAT(am.cost, 2)) AS 'Cost',
                    am.description AS 'Description',
                    DATE_FORMAT(am.next_maintenance_date, '%Y-%m-%d') AS 'Next Maintenance',
                    CONCAT(u.first_name, ' ', u.last_name) AS 'Recorded By'
                    FROM asset_maintenance am
                    LEFT JOIN users u ON am.created_by = u.user_id
                    WHERE am.asset_id = @assetId
                    ORDER BY am.maintenance_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@assetId", assetId)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvMaintenanceHistory.DataSource = dt

                        If dt.Rows.Count = 0 Then
                            dgvMaintenanceHistory.DataSource = Nothing
                            ' Show message in grid
                            Dim emptyDt As New DataTable()
                            emptyDt.Columns.Add("Message")
                            emptyDt.Rows.Add("No maintenance history found")
                            dgvMaintenanceHistory.DataSource = emptyDt
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error loading maintenance history: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Edit asset button
    ''' </summary>
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Dim editForm As New AddEditAssetFrm(assetId)
            If editForm.ShowDialog() = DialogResult.OK Then
                ' Reload asset details
                LoadAssetDetails()
                LoadIssuanceHistory()
                LoadMaintenanceHistory()

                MessageBox.Show("Asset updated successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening edit form: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Delete asset button
    ''' </summary>
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result = MessageBox.Show($"Are you sure you want to delete this asset?" & vbCrLf & vbCrLf &
                                    $"Asset Tag: {currentAssetTag}" & vbCrLf &
                                    $"Asset Name: {currentAssetName}" & vbCrLf & vbCrLf &
                                    "This action cannot be undone!",
                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    If conn Is Nothing Then Return

                    ' Check if asset has been issued
                    Dim checkQuery As String = "SELECT COUNT(*) FROM asset_issuance WHERE asset_id = @assetId"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@assetId", assetId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("This asset cannot be deleted because it has issuance history." & vbCrLf &
                                          "Please use the disposal request feature instead.",
                                          "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Delete asset
                    Dim deleteQuery As String = "DELETE FROM assets WHERE asset_id = @assetId"
                    Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@assetId", assetId)
                        deleteCmd.ExecuteNonQuery()
                    End Using

                    ' Log activity
                    LogActivity(gCurrentUserId, "Asset Deleted", "assets", assetId,
                               $"Deleted asset: {currentAssetTag} - {currentAssetName}")

                    MessageBox.Show("Asset deleted successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting asset: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Add maintenance record button
    ''' </summary>
    Private Sub btnAddMaintenance_Click(sender As Object, e As EventArgs) Handles btnAddMaintenance.Click
        ' Check if asset is available for maintenance
        If currentStatus = "Disposed" OrElse currentStatus = "Lost" Then
            MessageBox.Show($"Cannot add maintenance record for {currentStatus} assets.",
                          "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show("Add Maintenance Record form will be opened here." & vbCrLf & vbCrLf &
                       $"Asset: {currentAssetTag} - {currentAssetName}",
                       "Add Maintenance", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' TODO: Open AddEditMaintenanceRecordFrm
        ' Dim maintenanceForm As New AddEditMaintenanceRecordFrm(assetId)
        ' If maintenanceForm.ShowDialog() = DialogResult.OK Then
        '     LoadMaintenanceHistory()
        ' End If
    End Sub

    ''' <summary>
    ''' Request disposal button
    ''' </summary>
    Private Sub btnRequestDisposal_Click(sender As Object, e As EventArgs) Handles btnRequestDisposal.Click
        ' Check if asset is eligible for disposal request
        If currentStatus = "Issued" Then
            MessageBox.Show("This asset is currently issued. Please return it before requesting disposal.",
                          "Cannot Request Disposal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If currentStatus = "Disposed" Then
            MessageBox.Show("This asset has already been disposed.",
                          "Already Disposed", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim result = MessageBox.Show($"Request disposal for this asset?" & vbCrLf & vbCrLf &
                                    $"Asset: {currentAssetTag} - {currentAssetName}" & vbCrLf & vbCrLf &
                                    "A disposal request will be created for approval.",
                                    "Request Disposal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            MessageBox.Show("Disposal Request form will be opened here.",
                          "Request Disposal", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' TODO: Open DisposalRequestFrm
            ' Dim disposalForm As New DisposalRequestFrm(assetId)
            ' disposalForm.ShowDialog()
        End If
    End Sub

    ''' <summary>
    ''' Print QR code button
    ''' </summary>
    Private Sub btnPrintQR_Click(sender As Object, e As EventArgs)
        Try
            MessageBox.Show($"Print QR Code for: {currentAssetTag}" & vbCrLf & vbCrLf &
                           "QR Code printing functionality will be implemented here." & vbCrLf &
                           "This will print a label with the QR code and asset details.",
                           "Print QR Code", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' TODO: Implement QR code printing
            ' PrintQRCode()

        Catch ex As Exception
            MessageBox.Show("Error printing QR code: " & ex.Message, "Error",
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