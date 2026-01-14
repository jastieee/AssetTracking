Imports MySql.Data.MySqlClient
Imports System.Data

Public Class ActivityLogsFrm
    Private originalData As DataTable
    Private currentUser As Integer ' Store logged-in user ID

    Private Sub ActivityLogsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize filters
            InitializeFilters()

            ' Set default date range (last 30 days)
            dtpStartDate.Value = DateTime.Now.AddDays(-30)
            dtpEndDate.Value = DateTime.Now

            ' Load initial data
            LoadActivityLogs()

            ' Configure DataGridView
            ConfigureDataGridView()

        Catch ex As Exception
            MessageBox.Show("Error loading form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeFilters()
        ' Set default selections
        cboActionType.SelectedIndex = 0 ' All Actions
        cboTableName.SelectedIndex = 0 ' All Tables
        cboUser.SelectedIndex = 0 ' All Users

        ' Load users into combo box
        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = "SELECT user_id, CONCAT(first_name, ' ', last_name) AS full_name FROM users WHERE is_active = 1 ORDER BY full_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboUser.Items.Clear()
                        cboUser.Items.Add("All Users")

                        While reader.Read()
                            cboUser.Items.Add(New UserItem With {
                                .UserId = Convert.ToInt32(reader("user_id")),
                                .DisplayName = reader("full_name").ToString()
                            })
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadActivityLogs()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()

                Dim query As String = "SELECT " &
                    "al.log_id, " &
                    "al.user_id, " &
                    "COALESCE(CONCAT(u.first_name, ' ', u.last_name), 'System') AS user_name, " &
                    "al.action_type, " &
                    "al.table_name, " &
                    "al.record_id, " &
                    "al.description, " &
                    "al.ip_address, " &
                    "al.created_at " &
                    "FROM activity_logs al " &
                    "LEFT JOIN users u ON al.user_id = u.user_id " &
                    "WHERE 1=1"

                ' Apply filters
                Dim parameters As New List(Of MySqlParameter)

                ' User filter
                If cboUser.SelectedIndex > 0 AndAlso TypeOf cboUser.SelectedItem Is UserItem Then
                    query &= " AND al.user_id = @userId"
                    parameters.Add(New MySqlParameter("@userId", DirectCast(cboUser.SelectedItem, UserItem).UserId))
                End If

                ' Action Type filter
                If cboActionType.SelectedIndex > 0 Then
                    query &= " AND al.action_type = @actionType"
                    parameters.Add(New MySqlParameter("@actionType", cboActionType.SelectedItem.ToString()))
                End If

                ' Table Name filter
                If cboTableName.SelectedIndex > 0 Then
                    query &= " AND al.table_name = @tableName"
                    parameters.Add(New MySqlParameter("@tableName", cboTableName.SelectedItem.ToString()))
                End If

                ' Date range filter
                query &= " AND DATE(al.created_at) BETWEEN @startDate AND @endDate"
                parameters.Add(New MySqlParameter("@startDate", dtpStartDate.Value.Date))
                parameters.Add(New MySqlParameter("@endDate", dtpEndDate.Value.Date))

                ' Search filter
                If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                    query &= " AND al.description LIKE @search"
                    parameters.Add(New MySqlParameter("@search", "%" & txtSearch.Text & "%"))
                End If

                query &= " ORDER BY al.created_at DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddRange(parameters.ToArray())

                    Using adapter As New MySqlDataAdapter(cmd)
                        originalData = New DataTable()
                        adapter.Fill(originalData)
                        dgvActivityLogs.DataSource = originalData

                        ' Update record count
                        lblRecordCount.Text = $"Total Logs: {originalData.Rows.Count}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading activity logs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigureDataGridView()
        With dgvActivityLogs
            .AutoGenerateColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False

            If .Columns.Count > 0 Then
                ' Hide columns
                If .Columns.Contains("log_id") Then .Columns("log_id").Visible = False
                If .Columns.Contains("user_id") Then .Columns("user_id").Visible = False
                If .Columns.Contains("record_id") Then .Columns("record_id").Visible = False
                If .Columns.Contains("ip_address") Then .Columns("ip_address").Visible = False

                ' Set column headers
                If .Columns.Contains("user_name") Then .Columns("user_name").HeaderText = "User"
                If .Columns.Contains("action_type") Then .Columns("action_type").HeaderText = "Action"
                If .Columns.Contains("table_name") Then .Columns("table_name").HeaderText = "Table"
                If .Columns.Contains("description") Then .Columns("description").HeaderText = "Description"
                If .Columns.Contains("created_at") Then
                    .Columns("created_at").HeaderText = "Date/Time"
                    .Columns("created_at").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"
                End If

                ' Set column widths
                If .Columns.Contains("user_name") Then .Columns("user_name").Width = 150
                If .Columns.Contains("action_type") Then .Columns("action_type").Width = 180
                If .Columns.Contains("table_name") Then .Columns("table_name").Width = 150
                If .Columns.Contains("description") Then .Columns("description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                If .Columns.Contains("created_at") Then .Columns("created_at").Width = 170
            End If
        End With
    End Sub

    ' Button Click Events
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadActivityLogs()
        MessageBox.Show("Activity logs refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClearLogs_Click(sender As Object, e As EventArgs) Handles btnClearLogs.Click
        Try
            Dim result As DialogResult = MessageBox.Show(
                "This will delete activity logs older than 90 days. Continue?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    Dim query As String = "DELETE FROM activity_logs WHERE created_at < DATE_SUB(NOW(), INTERVAL 90 DAY)"

                    Using cmd As New MySqlCommand(query, conn)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        MessageBox.Show($"Successfully deleted {rowsAffected} old log entries.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadActivityLogs()
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error clearing logs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If originalData Is Nothing OrElse originalData.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            saveDialog.FileName = $"ActivityLogs_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportToCSV(saveDialog.FileName)
                MessageBox.Show("Activity logs exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting logs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToCSV(filePath As String)
        Using writer As New IO.StreamWriter(filePath)
            ' Write headers
            Dim headers As New List(Of String)
            For Each column As DataColumn In originalData.Columns
                If column.ColumnName <> "log_id" AndAlso column.ColumnName <> "user_id" Then
                    headers.Add(column.ColumnName)
                End If
            Next
            writer.WriteLine(String.Join(",", headers))

            ' Write data rows
            For Each row As DataRow In originalData.Rows
                Dim values As New List(Of String)
                For Each column As DataColumn In originalData.Columns
                    If column.ColumnName <> "log_id" AndAlso column.ColumnName <> "user_id" Then
                        Dim value As String = row(column).ToString().Replace(",", ";").Replace(vbCrLf, " ")
                        values.Add($"""{value}""")
                    End If
                Next
                writer.WriteLine(String.Join(",", values))
            Next
        End Using
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        txtSearch.Clear()
        cboUser.SelectedIndex = 0
        cboActionType.SelectedIndex = 0
        cboTableName.SelectedIndex = 0
        dtpStartDate.Value = DateTime.Now.AddDays(-30)
        dtpEndDate.Value = DateTime.Now
        LoadActivityLogs()
    End Sub

    Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        If dgvActivityLogs.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgvActivityLogs.SelectedRows(0)

            Dim details As String = "Activity Log Details" & vbCrLf & vbCrLf &
                "User: " & selectedRow.Cells("user_name").Value.ToString() & vbCrLf &
                "Action: " & selectedRow.Cells("action_type").Value.ToString() & vbCrLf &
                "Table: " & If(IsDBNull(selectedRow.Cells("table_name").Value), "N/A", selectedRow.Cells("table_name").Value.ToString()) & vbCrLf &
                "Record ID: " & If(IsDBNull(selectedRow.Cells("record_id").Value), "N/A", selectedRow.Cells("record_id").Value.ToString()) & vbCrLf &
                "Description: " & selectedRow.Cells("description").Value.ToString() & vbCrLf &
                "IP Address: " & If(IsDBNull(selectedRow.Cells("ip_address").Value), "N/A", selectedRow.Cells("ip_address").Value.ToString()) & vbCrLf &
                "Date/Time: " & Convert.ToDateTime(selectedRow.Cells("created_at").Value).ToString("yyyy-MM-dd HH:mm:ss")

            MessageBox.Show(details, "Log Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Filter Change Events
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ' Optional: Implement real-time search with delay
    End Sub

    Private Sub cboUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUser.SelectedIndexChanged
        If cboUser.SelectedIndex >= 0 Then
            LoadActivityLogs()
        End If
    End Sub

    Private Sub cboActionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboActionType.SelectedIndexChanged
        If cboActionType.SelectedIndex >= 0 Then
            LoadActivityLogs()
        End If
    End Sub

    Private Sub cboTableName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTableName.SelectedIndexChanged
        If cboTableName.SelectedIndex >= 0 Then
            LoadActivityLogs()
        End If
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        If dtpStartDate.Value > dtpEndDate.Value Then
            MessageBox.Show("Start date cannot be greater than end date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpStartDate.Value = dtpEndDate.Value.AddDays(-1)
        Else
            LoadActivityLogs()
        End If
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        If dtpEndDate.Value < dtpStartDate.Value Then
            MessageBox.Show("End date cannot be less than start date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpEndDate.Value = dtpStartDate.Value.AddDays(1)
        Else
            LoadActivityLogs()
        End If
    End Sub

    Private Sub dgvActivityLogs_SelectionChanged(sender As Object, e As EventArgs) Handles dgvActivityLogs.SelectionChanged
        btnViewDetails.Enabled = dgvActivityLogs.SelectedRows.Count > 0
    End Sub

    ' Helper class for user combo box items
    Private Class UserItem
        Public Property UserId As Integer
        Public Property DisplayName As String

        Public Overrides Function ToString() As String
            Return DisplayName
        End Function
    End Class
End Class