Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class ProvisionRecordsFrm

    ''' <summary>
    ''' Form Load - Initialize everything
    ''' </summary>
    Private Sub ProvisionRecordsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load filters
        LoadDepartmentFilter()

        ' Set default date range (last 30 days)
        dtpStartDate.Value = DateTime.Now.AddDays(-30)
        dtpEndDate.Value = DateTime.Now

        ' Load provision records
        LoadProvisionRecords()

        ' Disable action buttons initially
        btnViewDetails.Enabled = False
    End Sub

    ''' <summary>
    ''' Load department filter dropdown
    ''' </summary>
    Private Sub LoadDepartmentFilter()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT department_id, department_name FROM departments WHERE is_active = 1 ORDER BY department_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        ' Add "All Departments" option
                        Dim allRow As DataRow = dt.NewRow()
                        allRow("department_id") = 0
                        allRow("department_name") = "All Departments"
                        dt.Rows.InsertAt(allRow, 0)

                        cboFilterDepartment.DataSource = dt
                        cboFilterDepartment.DisplayMember = "department_name"
                        cboFilterDepartment.ValueMember = "department_id"
                        cboFilterDepartment.SelectedIndex = 0
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load provision records
    ''' </summary>
    Private Sub LoadProvisionRecords(Optional departmentId As Integer = 0, Optional startDate As Date? = Nothing, Optional endDate As Date? = Nothing)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT cp.provision_id, cp.provision_date, c.consumable_code, c.consumable_name, " &
                                     "cp.quantity, d.department_name, " &
                                     "CONCAT(u1.first_name, ' ', u1.last_name) as requested_by_name, " &
                                     "IFNULL(CONCAT(u2.first_name, ' ', u2.last_name), 'N/A') as approved_by_name, " &
                                     "cp.purpose, cp.status, cp.notes " &
                                     "FROM consumable_provisions cp " &
                                     "INNER JOIN consumables c ON cp.consumable_id = c.consumable_id " &
                                     "INNER JOIN departments d ON cp.department_id = d.department_id " &
                                     "INNER JOIN users u1 ON cp.requested_by = u1.user_id " &
                                     "LEFT JOIN users u2 ON cp.approved_by = u2.user_id " &
                                     "WHERE cp.status = 'Completed'"

                ' Add department filter
                If departmentId > 0 Then
                    query &= " AND cp.department_id = @deptId"
                End If

                ' Add date range filter
                If startDate.HasValue Then
                    query &= " AND DATE(cp.provision_date) >= @startDate"
                End If

                If endDate.HasValue Then
                    query &= " AND DATE(cp.provision_date) <= @endDate"
                End If

                query &= " ORDER BY cp.provision_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    If departmentId > 0 Then
                        cmd.Parameters.AddWithValue("@deptId", departmentId)
                    End If

                    If startDate.HasValue Then
                        cmd.Parameters.AddWithValue("@startDate", startDate.Value.Date)
                    End If

                    If endDate.HasValue Then
                        cmd.Parameters.AddWithValue("@endDate", endDate.Value.Date)
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        ' Clear existing rows
                        dgvProvisions.Rows.Clear()

                        ' Add rows to DataGridView
                        For Each row As DataRow In dt.Rows
                            Dim idx As Integer = dgvProvisions.Rows.Add()
                            dgvProvisions.Rows(idx).Cells("colProvisionId").Value = row("provision_id")
                            dgvProvisions.Rows(idx).Cells("colProvisionDate").Value = Convert.ToDateTime(row("provision_date")).ToString("yyyy-MM-dd")
                            dgvProvisions.Rows(idx).Cells("colItemCode").Value = row("consumable_code")
                            dgvProvisions.Rows(idx).Cells("colItemName").Value = row("consumable_name")
                            dgvProvisions.Rows(idx).Cells("colQuantity").Value = row("quantity")
                            dgvProvisions.Rows(idx).Cells("colDepartment").Value = row("department_name")
                            dgvProvisions.Rows(idx).Cells("colProvidedBy").Value = row("approved_by_name")
                            dgvProvisions.Rows(idx).Cells("colRemarks").Value = If(IsDBNull(row("purpose")), "", row("purpose").ToString())
                        Next
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading provision records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Search button click
    ''' </summary>
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim departmentId As Integer = If(cboFilterDepartment.SelectedIndex > 0, Convert.ToInt32(cboFilterDepartment.SelectedValue), 0)
        LoadProvisionRecords(departmentId, dtpStartDate.Value, dtpEndDate.Value)
    End Sub

    ''' <summary>
    ''' DataGridView selection changed
    ''' </summary>
    Private Sub dgvProvisions_SelectionChanged(sender As Object, e As EventArgs) Handles dgvProvisions.SelectionChanged
        btnViewDetails.Enabled = dgvProvisions.SelectedRows.Count > 0
    End Sub

    ''' <summary>
    ''' View Details button click
    ''' </summary>
    Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        If dgvProvisions.SelectedRows.Count = 0 Then Return

        Dim provisionId As Integer = Convert.ToInt32(dgvProvisions.SelectedRows(0).Cells("colProvisionId").Value)
        ShowProvisionDetails(provisionId)
    End Sub

    ''' <summary>
    ''' Show provision details
    ''' </summary>
    Private Sub ShowProvisionDetails(provisionId As Integer)
        Try
            Dim details As New System.Text.StringBuilder()

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT cp.*, c.consumable_code, c.consumable_name, c.unit_of_measure, " &
                                     "d.department_name, " &
                                     "CONCAT(u1.first_name, ' ', u1.last_name) as requested_by_name, " &
                                     "IFNULL(CONCAT(u2.first_name, ' ', u2.last_name), 'N/A') as approved_by_name " &
                                     "FROM consumable_provisions cp " &
                                     "INNER JOIN consumables c ON cp.consumable_id = c.consumable_id " &
                                     "INNER JOIN departments d ON cp.department_id = d.department_id " &
                                     "INNER JOIN users u1 ON cp.requested_by = u1.user_id " &
                                     "LEFT JOIN users u2 ON cp.approved_by = u2.user_id " &
                                     "WHERE cp.provision_id = @id"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", provisionId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            details.AppendLine("PROVISION DETAILS")
                            details.AppendLine(New String("="c, 50))
                            details.AppendLine($"Provision ID: {provisionId}")
                            details.AppendLine($"Date: {Convert.ToDateTime(reader("provision_date")):yyyy-MM-dd HH:mm}")
                            details.AppendLine()
                            details.AppendLine("ITEM INFORMATION")
                            details.AppendLine(New String("-"c, 50))
                            details.AppendLine($"Code: {reader("consumable_code")}")
                            details.AppendLine($"Name: {reader("consumable_name")}")
                            details.AppendLine($"Quantity: {reader("quantity")} {reader("unit_of_measure")}")
                            details.AppendLine()
                            details.AppendLine("DEPARTMENT & PERSONNEL")
                            details.AppendLine(New String("-"c, 50))
                            details.AppendLine($"Department: {reader("department_name")}")
                            details.AppendLine($"Requested By: {reader("requested_by_name")}")
                            details.AppendLine($"Approved By: {reader("approved_by_name")}")
                            details.AppendLine()
                            details.AppendLine("PURPOSE")
                            details.AppendLine(New String("-"c, 50))
                            details.AppendLine(If(IsDBNull(reader("purpose")), "N/A", reader("purpose").ToString()))

                            If Not IsDBNull(reader("notes")) AndAlso Not String.IsNullOrWhiteSpace(reader("notes").ToString()) Then
                                details.AppendLine()
                                details.AppendLine("NOTES")
                                details.AppendLine(New String("-"c, 50))
                                details.AppendLine(reader("notes").ToString())
                            End If

                            details.AppendLine()
                            details.AppendLine($"Status: {reader("status")}")
                        End If
                    End Using
                End Using
            End Using

            MessageBox.Show(details.ToString(), "Provision Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error loading provision details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Export button click
    ''' </summary>
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' TODO: Implement export to Excel
        MessageBox.Show("Export functionality coming soon!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class