Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class AddMaintenanceFrm

    Private _maintenanceId As Integer = 0
    Private _selectedAssetId As Integer = 0

    ''' <summary>
    ''' Property for Maintenance ID (0 for new, >0 for edit)
    ''' </summary>
    Public Property MaintenanceId As Integer
        Get
            Return _maintenanceId
        End Get
        Set(value As Integer)
            _maintenanceId = value
        End Set
    End Property

    ''' <summary>
    ''' Property for pre-selected Asset ID
    ''' </summary>
    Public Property SelectedAssetId As Integer
        Get
            Return _selectedAssetId
        End Get
        Set(value As Integer)
            _selectedAssetId = value
        End Set
    End Property

    ''' <summary>
    ''' Form Load - Initialize
    ''' </summary>
    Private Sub AddMaintenanceFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load assets dropdown
        LoadAssets()

        ' Set default date to today
        dtpMaintenanceDate.Value = DateTime.Now

        ' Clear next maintenance date initially
        dtpNextDate.Value = DateTime.Now.AddMonths(3) ' Default 3 months from now

        If _maintenanceId > 0 Then
            ' Edit mode
            lbltitle.Text = "EDIT MAINTENANCE RECORD"
            btnSave.Text = "💾 Update Record"
            LoadMaintenanceData()
        Else
            ' Add mode
            lbltitle.Text = "ADD MAINTENANCE RECORD"
            btnSave.Text = "💾 Save Record"

            ' Pre-select asset if provided
            If _selectedAssetId > 0 Then
                cboAsset.SelectedValue = _selectedAssetId
            End If
        End If

        ' Set focus to asset dropdown
        cboAsset.Focus()
    End Sub

    ''' <summary>
    ''' Load assets for dropdown
    ''' </summary>
    Private Sub LoadAssets()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT asset_id, CONCAT(asset_tag, ' - ', asset_name) as asset_display 
                                      FROM assets 
                                      WHERE status != 'Disposed' 
                                      ORDER BY asset_tag"

                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        cboAsset.DataSource = dt
                        cboAsset.DisplayMember = "asset_display"
                        cboAsset.ValueMember = "asset_id"
                        cboAsset.SelectedIndex = -1
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading assets: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load maintenance data for editing
    ''' </summary>
    Private Sub LoadMaintenanceData()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                                        asset_id,
                                        maintenance_type,
                                        maintenance_date,
                                        performed_by,
                                        cost,
                                        description,
                                        next_maintenance_date
                                      FROM asset_maintenance 
                                      WHERE maintenance_id = @maintenanceId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@maintenanceId", _maintenanceId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            cboAsset.SelectedValue = Convert.ToInt32(reader("asset_id"))
                            txtMaintenanceType.Text = If(IsDBNull(reader("maintenance_type")), "", reader("maintenance_type").ToString())
                            dtpMaintenanceDate.Value = Convert.ToDateTime(reader("maintenance_date"))
                            txtPerformedBy.Text = If(IsDBNull(reader("performed_by")), "", reader("performed_by").ToString())
                            txtCost.Text = If(IsDBNull(reader("cost")), "", Convert.ToDecimal(reader("cost")).ToString("0.00"))
                            txtDescription.Text = If(IsDBNull(reader("description")), "", reader("description").ToString())

                            If Not IsDBNull(reader("next_maintenance_date")) Then
                                dtpNextDate.Value = Convert.ToDateTime(reader("next_maintenance_date"))
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading maintenance data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Save button click
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validate inputs
        If Not ValidateInputs() Then Return

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String
                Dim assetId As Integer = Convert.ToInt32(cboAsset.SelectedValue)
                Dim maintenanceType As String = txtMaintenanceType.Text.Trim()
                Dim maintenanceDate As DateTime = dtpMaintenanceDate.Value.Date
                Dim performedBy As String = txtPerformedBy.Text.Trim()
                Dim cost As Decimal? = Nothing
                If Not String.IsNullOrWhiteSpace(txtCost.Text) Then
                    cost = Convert.ToDecimal(txtCost.Text)
                End If
                Dim description As String = txtDescription.Text.Trim()
                Dim nextDate As DateTime = dtpNextDate.Value.Date

                If _maintenanceId > 0 Then
                    ' Update existing record
                    query = "UPDATE asset_maintenance SET 
                            asset_id = @assetId,
                            maintenance_type = @maintenanceType,
                            maintenance_date = @maintenanceDate,
                            performed_by = @performedBy,
                            cost = @cost,
                            description = @description,
                            next_maintenance_date = @nextDate
                            WHERE maintenance_id = @maintenanceId"
                Else
                    ' Insert new record
                    query = "INSERT INTO asset_maintenance 
                            (asset_id, maintenance_type, maintenance_date, performed_by, cost, description, next_maintenance_date, created_by) 
                            VALUES 
                            (@assetId, @maintenanceType, @maintenanceDate, @performedBy, @cost, @description, @nextDate, @createdBy)"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@assetId", assetId)
                    cmd.Parameters.AddWithValue("@maintenanceType", maintenanceType)
                    cmd.Parameters.AddWithValue("@maintenanceDate", maintenanceDate)
                    cmd.Parameters.AddWithValue("@performedBy", If(String.IsNullOrWhiteSpace(performedBy), DBNull.Value, performedBy))
                    cmd.Parameters.AddWithValue("@cost", If(cost.HasValue, cost.Value, DBNull.Value))
                    cmd.Parameters.AddWithValue("@description", description)
                    cmd.Parameters.AddWithValue("@nextDate", nextDate)

                    If _maintenanceId > 0 Then
                        cmd.Parameters.AddWithValue("@maintenanceId", _maintenanceId)
                    Else
                        cmd.Parameters.AddWithValue("@createdBy", gCurrentUserId)
                    End If

                    cmd.ExecuteNonQuery()

                    ' Get the maintenance ID for logging
                    Dim maintenanceIdForLog As Integer = _maintenanceId
                    If _maintenanceId = 0 Then
                        maintenanceIdForLog = Convert.ToInt32(cmd.LastInsertedId)
                    End If

                    ' Get asset tag for logging
                    Dim assetTag As String = cboAsset.Text.Split("-"c)(0).Trim()

                    ' Log activity
                    If _maintenanceId > 0 Then
                        LogActivity(gCurrentUserId, "Maintenance Updated", "asset_maintenance", maintenanceIdForLog,
                                   $"Updated maintenance record for {assetTag}")
                    Else
                        LogActivity(gCurrentUserId, "Maintenance Added", "asset_maintenance", maintenanceIdForLog,
                                   $"Added maintenance record for {assetTag}")
                    End If

                    MessageBox.Show("Maintenance record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving maintenance record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Validate form inputs
    ''' </summary>
    Private Function ValidateInputs() As Boolean
        ' Validate asset selection
        If cboAsset.SelectedIndex < 0 Then
            MessageBox.Show("Please select an asset", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAsset.Focus()
            Return False
        End If

        ' Validate maintenance type
        If String.IsNullOrWhiteSpace(txtMaintenanceType.Text) Then
            MessageBox.Show("Please enter maintenance type", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMaintenanceType.Focus()
            Return False
        End If

        ' Validate maintenance date
        If dtpMaintenanceDate.Value.Date > DateTime.Now.Date Then
            Dim result As DialogResult = MessageBox.Show("Maintenance date is in the future. Continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                dtpMaintenanceDate.Focus()
                Return False
            End If
        End If

        ' Validate description
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            MessageBox.Show("Please enter a description", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDescription.Focus()
            Return False
        End If

        ' Validate cost if provided
        If Not String.IsNullOrWhiteSpace(txtCost.Text) Then
            Dim costValue As Decimal
            If Not Decimal.TryParse(txtCost.Text, costValue) Then
                MessageBox.Show("Please enter a valid cost amount", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCost.Focus()
                Return False
            End If

            If costValue < 0 Then
                MessageBox.Show("Cost cannot be negative", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCost.Focus()
                Return False
            End If
        End If

        ' Validate next maintenance date
        If dtpNextDate.Value.Date < dtpMaintenanceDate.Value.Date Then
            MessageBox.Show("Next maintenance date cannot be before maintenance date", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpNextDate.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Cancel button click
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' Cost textbox - allow only numbers and decimal
    ''' </summary>
    Private Sub txtCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCost.KeyPress
        ' Allow only numbers, one decimal point, and control keys
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Allow only one decimal point
        If e.KeyChar = "."c AndAlso txtCost.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Log activity to database
    ''' </summary>
    Private Sub LogActivity(userId As Integer, actionType As String, tableName As String, recordId As Integer, description As String)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description, ip_address) " &
                                     "VALUES (@userId, @actionType, @tableName, @recordId, @description, @ipAddress)"

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
            ' Silent fail for logging
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