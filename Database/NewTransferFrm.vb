Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class NewTransferFrm

    Private selectedAssetId As Integer = 0

    ''' <summary>
    ''' Form Load - Initialize
    ''' </summary>
    Private Sub NewTransferFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAvailableAssets()
        LoadDepartments()
        ClearCurrentInfo()
    End Sub

    ''' <summary>
    ''' Load available assets - UPDATED TO SHOW EMPLOYEES
    ''' </summary>
    Private Sub LoadAvailableAssets()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT a.asset_id, 
                                             CONCAT(a.asset_tag, ' - ', a.asset_name) as asset_display,
                                             a.current_department_id,
                                             a.assigned_to_employee_id
                                      FROM assets a
                                      WHERE a.status != 'Disposed' 
                                      AND a.asset_id NOT IN (
                                          SELECT asset_id FROM asset_transfers WHERE status = 'Pending'
                                      )
                                      ORDER BY a.asset_tag"

                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        Dim emptyRow As DataRow = dt.NewRow()
                        emptyRow("asset_id") = 0
                        emptyRow("asset_display") = "-- Select Asset --"
                        emptyRow("current_department_id") = DBNull.Value
                        emptyRow("assigned_to_employee_id") = DBNull.Value
                        dt.Rows.InsertAt(emptyRow, 0)

                        cboAsset.DataSource = dt
                        cboAsset.DisplayMember = "asset_display"
                        cboAsset.ValueMember = "asset_id"
                        cboAsset.SelectedIndex = 0
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading assets: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load departments into dropdown
    ''' </summary>
    Private Sub LoadDepartments()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT department_id, department_name FROM departments WHERE is_active = 1 ORDER BY department_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        Dim emptyRow As DataRow = dt.NewRow()
                        emptyRow("department_id") = 0
                        emptyRow("department_name") = "-- Select Department --"
                        dt.Rows.InsertAt(emptyRow, 0)

                        cboDepartment.DataSource = dt
                        cboDepartment.DisplayMember = "department_name"
                        cboDepartment.ValueMember = "department_id"
                        cboDepartment.SelectedIndex = 0
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load employees by department - UPDATED TO USE EMPLOYEES
    ''' </summary>
    Private Sub LoadEmployeesByDepartment(departmentId As Integer)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT e.employee_id, 
                                             CONCAT(e.first_name, ' ', e.last_name, ' (', ep.position_name, ')') as full_name_with_position
                                      FROM employees e
                                      INNER JOIN employee_positions ep ON e.position_id = ep.position_id
                                      WHERE e.employment_status = 'Active' AND e.department_id = @deptId
                                      ORDER BY ep.position_level, e.first_name, e.last_name"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@deptId", departmentId)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        Dim emptyRow As DataRow = dt.NewRow()
                        emptyRow("employee_id") = 0
                        emptyRow("full_name_with_position") = "-- Not Assigned --"
                        dt.Rows.InsertAt(emptyRow, 0)

                        cboUser.DataSource = dt
                        cboUser.DisplayMember = "full_name_with_position"
                        cboUser.ValueMember = "employee_id"
                        cboUser.SelectedIndex = 0
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading employees: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Asset selection changed
    ''' </summary>
    Private Sub cboAsset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAsset.SelectedIndexChanged
        If cboAsset.SelectedValue IsNot Nothing AndAlso IsNumeric(cboAsset.SelectedValue) Then
            Dim assetId As Integer = Convert.ToInt32(cboAsset.SelectedValue)

            If assetId > 0 Then
                selectedAssetId = assetId
                LoadCurrentAssetInfo(assetId)
            Else
                selectedAssetId = 0
                ClearCurrentInfo()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Load current asset information - UPDATED TO USE EMPLOYEES
    ''' </summary>
    Private Sub LoadCurrentAssetInfo(assetId As Integer)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                                        IFNULL(d.department_name, 'Not Assigned') as dept_name,
                                        IFNULL(CONCAT(e.first_name, ' ', e.last_name), 'Not Assigned') as employee_name,
                                        IFNULL(ep.position_name, '') as position_name
                                      FROM assets a
                                      LEFT JOIN departments d ON a.current_department_id = d.department_id
                                      LEFT JOIN employees e ON a.assigned_to_employee_id = e.employee_id
                                      LEFT JOIN employee_positions ep ON e.position_id = ep.position_id
                                      WHERE a.asset_id = @assetId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@assetId", assetId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblCurrentDept.Text = "Department: " & reader("dept_name").ToString()

                            Dim employeeName As String = reader("employee_name").ToString()
                            Dim positionName As String = reader("position_name").ToString()

                            If employeeName = "Not Assigned" Then
                                lblCurrentUser.Text = "Assigned To: Not Assigned"
                            ElseIf String.IsNullOrEmpty(positionName) Then
                                lblCurrentUser.Text = "Assigned To: " & employeeName
                            Else
                                lblCurrentUser.Text = $"Assigned To: {employeeName} ({positionName})"
                            End If

                            pnlCurrentInfo.Visible = True
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading asset info: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Clear current info panel
    ''' </summary>
    Private Sub ClearCurrentInfo()
        lblCurrentDept.Text = "Department: N/A"
        lblCurrentUser.Text = "Assigned To: N/A"
        pnlCurrentInfo.Visible = False
    End Sub

    ''' <summary>
    ''' Department selection changed
    ''' </summary>
    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged
        If cboDepartment.SelectedValue IsNot Nothing AndAlso IsNumeric(cboDepartment.SelectedValue) Then
            Dim deptId As Integer = Convert.ToInt32(cboDepartment.SelectedValue)

            If deptId > 0 Then
                LoadEmployeesByDepartment(deptId)
            Else
                cboUser.DataSource = Nothing
            End If
        End If
    End Sub

    ''' <summary>
    ''' Validate input
    ''' </summary>
    Private Function ValidateInput() As Boolean
        If selectedAssetId = 0 Then
            MessageBox.Show("Please select an asset to transfer", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboAsset.Focus()
            Return False
        End If

        If cboDepartment.SelectedIndex <= 0 Then
            MessageBox.Show("Please select a destination department", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboDepartment.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtReason.Text) Then
            MessageBox.Show("Please enter a reason for transfer", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReason.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Submit button click - UPDATED TO USE EMPLOYEES
    ''' </summary>
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If Not ValidateInput() Then
            Return
        End If

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Get current asset info (employee instead of user)
                Dim fromDeptId As Object = Nothing
                Dim fromEmployeeId As Object = Nothing

                Dim queryAsset As String = "SELECT current_department_id, assigned_to_employee_id FROM assets WHERE asset_id = @assetId"
                Using cmd As New MySqlCommand(queryAsset, conn)
                    cmd.Parameters.AddWithValue("@assetId", selectedAssetId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            fromDeptId = If(IsDBNull(reader("current_department_id")), Nothing, reader("current_department_id"))
                            fromEmployeeId = If(IsDBNull(reader("assigned_to_employee_id")), Nothing, reader("assigned_to_employee_id"))
                        End If
                    End Using
                End Using

                ' Insert transfer request
                Dim toDeptId As Integer = 0
                If cboDepartment.SelectedValue IsNot Nothing AndAlso IsNumeric(cboDepartment.SelectedValue) Then
                    toDeptId = Convert.ToInt32(cboDepartment.SelectedValue)
                End If

                Dim toEmployeeId As Integer = 0
                If cboUser.SelectedValue IsNot Nothing AndAlso IsNumeric(cboUser.SelectedValue) Then
                    toEmployeeId = Convert.ToInt32(cboUser.SelectedValue)
                End If

                Dim queryInsert As String = "INSERT INTO asset_transfers " &
                                           "(asset_id, from_department_id, to_department_id, from_employee_id, to_employee_id, " &
                                           "requested_by, reason, status, notes) " &
                                           "VALUES (@assetId, @fromDeptId, @toDeptId, @fromEmployeeId, @toEmployeeId, " &
                                           "@requestedBy, @reason, 'Pending', @notes)"

                Using cmdInsert As New MySqlCommand(queryInsert, conn)
                    cmdInsert.Parameters.AddWithValue("@assetId", selectedAssetId)
                    cmdInsert.Parameters.AddWithValue("@fromDeptId", If(fromDeptId, DBNull.Value))
                    cmdInsert.Parameters.AddWithValue("@toDeptId", toDeptId)
                    cmdInsert.Parameters.AddWithValue("@fromEmployeeId", If(fromEmployeeId, DBNull.Value))
                    cmdInsert.Parameters.AddWithValue("@toEmployeeId", If(toEmployeeId > 0, CType(toEmployeeId, Object), DBNull.Value))
                    cmdInsert.Parameters.AddWithValue("@requestedBy", gCurrentUserId)
                    cmdInsert.Parameters.AddWithValue("@reason", txtReason.Text.Trim())
                    cmdInsert.Parameters.AddWithValue("@notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, txtNotes.Text.Trim()))

                    cmdInsert.ExecuteNonQuery()
                End Using

                ' Log activity
                LogActivity(gCurrentUserId, "Transfer Request Created", "asset_transfers", 0,
                           $"Created transfer request for asset ID: {selectedAssetId}")

                MessageBox.Show("Transfer request submitted successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.DialogResult = DialogResult.OK
                Me.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error submitting transfer request: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Cancel button click
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
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