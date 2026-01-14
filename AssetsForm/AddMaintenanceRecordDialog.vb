Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class AddMaintenanceRecordDialog
    Private dbConnection As MySqlConnection
    Private selectedAssetId As Integer = 0
    Private isEditMode As Boolean = False
    Private maintenanceId As Integer = 0
    Private currentUserId As Integer = 1 ' Get from session/login

    ' Constructor for Add Mode
    Public Sub New()
        InitializeComponent()
        InitializeDatabase()
        ConfigureForm()
    End Sub

    ' Constructor for Edit Mode
    Public Sub New(maintId As Integer)
        InitializeComponent()
        InitializeDatabase()
        isEditMode = True
        maintenanceId = maintId
        ConfigureForm()
        LoadMaintenanceRecord()
    End Sub

    Private Sub InitializeDatabase()
        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("MySQLDB").ConnectionString
            dbConnection = New MySqlConnection(connString)
        Catch ex As Exception
            MessageBox.Show("Database connection error: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigureForm()
        ' Set form properties
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        ' Update title based on mode
        If isEditMode Then
            lblTitle.Text = "✏️ Edit Maintenance Record"
            lblSubtitle.Text = "Update maintenance record details"
            btnSave.Text = "💾 Update Record"
        Else
            lblTitle.Text = "➕ Add New Maintenance Record"
            lblSubtitle.Text = "Record maintenance activities and schedule next"
            btnSave.Text = "💾 Save Record"
        End If

        ' Set default values
        dtpMaintenanceDate.Value = DateTime.Now
        dtpNextMaintenance.Value = DateTime.Now.AddMonths(3) ' Default 3 months
        cboMaintenanceType.SelectedIndex = 0

        ' Disable next maintenance date initially
        dtpNextMaintenance.Enabled = False

        ' Configure numeric input for cost
        AddHandler txtCost.KeyPress, AddressOf ValidateNumericInput
    End Sub

    Private Sub LoadMaintenanceRecord()
        Try
            If dbConnection.State = ConnectionState.Closed Then
                dbConnection.Open()
            End If

            Dim query As String = "SELECT m.*, a.asset_tag, a.asset_name, a.category_id, 
                                  ac.category_name, a.model, a.manufacturer 
                                  FROM asset_maintenance m
                                  INNER JOIN assets a ON m.asset_id = a.asset_id
                                  LEFT JOIN asset_categories ac ON a.category_id = ac.category_id
                                  WHERE m.maintenance_id = @maintenanceId"

            Using cmd As New MySqlCommand(query, dbConnection)
                cmd.Parameters.AddWithValue("@maintenanceId", maintenanceId)

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Load asset information
                        selectedAssetId = Convert.ToInt32(reader("asset_id"))
                        txtAssetTag.Text = reader("asset_tag").ToString()
                        txtAssetTag.Enabled = False
                        btnSearchAsset.Enabled = False

                        ' Display asset info
                        lblAssetInfo.Text = $"Asset: {reader("asset_name")} | Category: {reader("category_name")} | " &
                                          $"Model: {If(IsDBNull(reader("model")), "N/A", reader("model"))} | " &
                                          $"Manufacturer: {If(IsDBNull(reader("manufacturer")), "N/A", reader("manufacturer"))}"
                        lblAssetInfo.ForeColor = Color.FromArgb(39, 174, 96)

                        ' Load maintenance details
                        If Not IsDBNull(reader("maintenance_type")) Then
                            cboMaintenanceType.Text = reader("maintenance_type").ToString()
                        End If

                        dtpMaintenanceDate.Value = Convert.ToDateTime(reader("maintenance_date"))

                        If Not IsDBNull(reader("performed_by")) Then
                            txtPerformedBy.Text = reader("performed_by").ToString()
                        End If

                        If Not IsDBNull(reader("cost")) Then
                            txtCost.Text = Convert.ToDecimal(reader("cost")).ToString("N2")
                        End If

                        If Not IsDBNull(reader("description")) Then
                            txtDescription.Text = reader("description").ToString()
                        End If

                        ' Load next maintenance date if exists
                        If Not IsDBNull(reader("next_maintenance_date")) Then
                            chkScheduleNext.Checked = True
                            dtpNextMaintenance.Value = Convert.ToDateTime(reader("next_maintenance_date"))
                        End If
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading maintenance record: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConnection.State = ConnectionState.Open Then
                dbConnection.Close()
            End If
        End Try
    End Sub

    Private Sub btnSearchAsset_Click(sender As Object, e As EventArgs) Handles btnSearchAsset.Click
        Try
            If String.IsNullOrWhiteSpace(txtAssetTag.Text) Then
                MessageBox.Show("Please enter an asset tag or name to search.", "Input Required",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAssetTag.Focus()
                Return
            End If

            If dbConnection.State = ConnectionState.Closed Then
                dbConnection.Open()
            End If

            Dim query As String = "SELECT a.asset_id, a.asset_tag, a.asset_name, a.serial_number, 
                                  a.model, a.manufacturer, a.status, a.condition_status,
                                  ac.category_name, sub.subcategory_name
                                  FROM assets a
                                  LEFT JOIN asset_categories ac ON a.category_id = ac.category_id
                                  LEFT JOIN asset_subcategories sub ON a.subcategory_id = sub.subcategory_id
                                  WHERE (a.asset_tag LIKE @search OR a.asset_name LIKE @search)
                                  LIMIT 1"

            Using cmd As New MySqlCommand(query, dbConnection)
                cmd.Parameters.AddWithValue("@search", "%" & txtAssetTag.Text.Trim() & "%")

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        selectedAssetId = Convert.ToInt32(reader("asset_id"))

                        ' Display asset information
                        Dim assetInfo As String = $"Asset: {reader("asset_name")} | " &
                                                 $"Tag: {reader("asset_tag")} | " &
                                                 $"Category: {If(IsDBNull(reader("category_name")), "N/A", reader("category_name"))} | " &
                                                 $"Status: {reader("status")}"

                        If Not IsDBNull(reader("model")) Then
                            assetInfo &= $" | Model: {reader("model")}"
                        End If

                        If Not IsDBNull(reader("manufacturer")) Then
                            assetInfo &= $" | Manufacturer: {reader("manufacturer")}"
                        End If

                        lblAssetInfo.Text = assetInfo
                        lblAssetInfo.ForeColor = Color.FromArgb(39, 174, 96) ' Green for success

                        MessageBox.Show("Asset found successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        selectedAssetId = 0
                        lblAssetInfo.Text = "Asset not found. Please check the asset tag or name."
                        lblAssetInfo.ForeColor = Color.FromArgb(231, 76, 60) ' Red for error
                        MessageBox.Show("No asset found with the specified tag or name.", "Not Found",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error searching for asset: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConnection.State = ConnectionState.Open Then
                dbConnection.Close()
            End If
        End Try
    End Sub

    Private Sub chkScheduleNext_CheckedChanged(sender As Object, e As EventArgs) Handles chkScheduleNext.CheckedChanged
        dtpNextMaintenance.Enabled = chkScheduleNext.Checked
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ValidateInputs() Then
            If isEditMode Then
                UpdateMaintenanceRecord()
            Else
                SaveMaintenanceRecord()
            End If
        End If
    End Sub

    Private Function ValidateInputs() As Boolean
        ' Validate asset selection
        If selectedAssetId <= 0 Then
            MessageBox.Show("Please search and select an asset first.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAssetTag.Focus()
            Return False
        End If

        ' Validate maintenance type
        If cboMaintenanceType.SelectedIndex < 0 Then
            MessageBox.Show("Please select a maintenance type.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMaintenanceType.Focus()
            Return False
        End If

        ' Validate maintenance date
        If dtpMaintenanceDate.Value > DateTime.Now Then
            Dim result = MessageBox.Show("The maintenance date is in the future. Continue?", "Confirm",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.No Then
                dtpMaintenanceDate.Focus()
                Return False
            End If
        End If

        ' Validate description
        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            MessageBox.Show("Please enter a description for the maintenance activity.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDescription.Focus()
            Return False
        End If

        ' Validate cost format if provided
        If Not String.IsNullOrWhiteSpace(txtCost.Text) Then
            Dim cost As Decimal
            If Not Decimal.TryParse(txtCost.Text, cost) OrElse cost < 0 Then
                MessageBox.Show("Please enter a valid cost amount (positive number).", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCost.Focus()
                Return False
            End If
        End If

        ' Validate next maintenance date if scheduled
        If chkScheduleNext.Checked Then
            If dtpNextMaintenance.Value <= dtpMaintenanceDate.Value Then
                MessageBox.Show("Next maintenance date must be after the current maintenance date.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                dtpNextMaintenance.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub SaveMaintenanceRecord()
        Try
            If dbConnection.State = ConnectionState.Closed Then
                dbConnection.Open()
            End If

            Dim query As String = "INSERT INTO asset_maintenance 
                                  (asset_id, maintenance_type, maintenance_date, performed_by, 
                                   cost, description, next_maintenance_date, created_by, created_at)
                                  VALUES 
                                  (@assetId, @maintenanceType, @maintenanceDate, @performedBy, 
                                   @cost, @description, @nextMaintenanceDate, @createdBy, NOW())"

            Using cmd As New MySqlCommand(query, dbConnection)
                cmd.Parameters.AddWithValue("@assetId", selectedAssetId)
                cmd.Parameters.AddWithValue("@maintenanceType", cboMaintenanceType.Text)
                cmd.Parameters.AddWithValue("@maintenanceDate", dtpMaintenanceDate.Value.Date)
                cmd.Parameters.AddWithValue("@performedBy", If(String.IsNullOrWhiteSpace(txtPerformedBy.Text), DBNull.Value, txtPerformedBy.Text))

                ' Handle cost
                If String.IsNullOrWhiteSpace(txtCost.Text) Then
                    cmd.Parameters.AddWithValue("@cost", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@cost", Convert.ToDecimal(txtCost.Text))
                End If

                cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim())

                ' Handle next maintenance date
                If chkScheduleNext.Checked Then
                    cmd.Parameters.AddWithValue("@nextMaintenanceDate", dtpNextMaintenance.Value.Date)
                Else
                    cmd.Parameters.AddWithValue("@nextMaintenanceDate", DBNull.Value)
                End If

                cmd.Parameters.AddWithValue("@createdBy", currentUserId)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    ' Log activity
                    Dim maintId As Long = cmd.LastInsertedId
                    LogActivity("Maintenance Record Created", "asset_maintenance", maintId,
                               $"Added maintenance record for asset ID {selectedAssetId}: {cboMaintenanceType.Text}")

                    MessageBox.Show("Maintenance record saved successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Failed to save maintenance record.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving maintenance record: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConnection.State = ConnectionState.Open Then
                dbConnection.Close()
            End If
        End Try
    End Sub

    Private Sub UpdateMaintenanceRecord()
        Try
            If dbConnection.State = ConnectionState.Closed Then
                dbConnection.Open()
            End If

            Dim query As String = "UPDATE asset_maintenance 
                                  SET maintenance_type = @maintenanceType,
                                      maintenance_date = @maintenanceDate,
                                      performed_by = @performedBy,
                                      cost = @cost,
                                      description = @description,
                                      next_maintenance_date = @nextMaintenanceDate
                                  WHERE maintenance_id = @maintenanceId"

            Using cmd As New MySqlCommand(query, dbConnection)
                cmd.Parameters.AddWithValue("@maintenanceId", maintenanceId)
                cmd.Parameters.AddWithValue("@maintenanceType", cboMaintenanceType.Text)
                cmd.Parameters.AddWithValue("@maintenanceDate", dtpMaintenanceDate.Value.Date)
                cmd.Parameters.AddWithValue("@performedBy", If(String.IsNullOrWhiteSpace(txtPerformedBy.Text), DBNull.Value, txtPerformedBy.Text))

                ' Handle cost
                If String.IsNullOrWhiteSpace(txtCost.Text) Then
                    cmd.Parameters.AddWithValue("@cost", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@cost", Convert.ToDecimal(txtCost.Text))
                End If

                cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim())

                ' Handle next maintenance date
                If chkScheduleNext.Checked Then
                    cmd.Parameters.AddWithValue("@nextMaintenanceDate", dtpNextMaintenance.Value.Date)
                Else
                    cmd.Parameters.AddWithValue("@nextMaintenanceDate", DBNull.Value)
                End If

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    ' Log activity
                    LogActivity("Maintenance Record Updated", "asset_maintenance", maintenanceId,
                               $"Updated maintenance record for asset ID {selectedAssetId}")

                    MessageBox.Show("Maintenance record updated successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Failed to update maintenance record.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating maintenance record: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConnection.State = ConnectionState.Open Then
                dbConnection.Close()
            End If
        End Try
    End Sub

    Private Sub LogActivity(actionType As String, tableName As String, recordId As Long, description As String)
        Try
            Dim query As String = "INSERT INTO activity_logs 
                                  (user_id, action_type, table_name, record_id, description, created_at)
                                  VALUES (@userId, @actionType, @tableName, @recordId, @description, NOW())"

            Using cmd As New MySqlCommand(query, dbConnection)
                cmd.Parameters.AddWithValue("@userId", currentUserId)
                cmd.Parameters.AddWithValue("@actionType", actionType)
                cmd.Parameters.AddWithValue("@tableName", tableName)
                cmd.Parameters.AddWithValue("@recordId", recordId)
                cmd.Parameters.AddWithValue("@description", description)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            ' Log errors silently - don't interrupt the main operation
            Debug.WriteLine("Error logging activity: " & ex.Message)
        End Try
    End Sub

    Private Sub ValidateNumericInput(sender As Object, e As KeyPressEventArgs)
        ' Allow digits, decimal point, backspace, and delete
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If

        ' Allow only one decimal point
        Dim textBox As TextBox = CType(sender, TextBox)
        If e.KeyChar = "."c AndAlso textBox.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtAssetTag_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAssetTag.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            btnSearchAsset.PerformClick()
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        If dbConnection IsNot Nothing AndAlso dbConnection.State = ConnectionState.Open Then
            dbConnection.Close()
        End If
    End Sub

End Class