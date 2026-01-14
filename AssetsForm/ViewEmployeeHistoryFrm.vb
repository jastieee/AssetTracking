Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Drawing

Public Class ViewEmployeeHistoryFrm
    Private employeeId As Integer
    Private employeeName As String

    Public Sub New(empId As Integer, empName As String)
        InitializeComponent()
        Me.employeeId = empId
        Me.employeeName = empName
    End Sub

    Private Sub ViewEmployeeHistoryFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        lblFormTitle.Text = $"Complete Issuance History - {employeeName}"

        ' Style DataGridView
        StyleDataGridView(dgvHistory)

        ' Load history data
        LoadHistory()
    End Sub

    ''' <summary>
    ''' Style DataGridView
    ''' </summary>
    Private Sub StyleDataGridView(dgv As DataGridView)
        With dgv
            ' Header style
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 40
            .EnableHeadersVisualStyles = False

            ' Row style
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.FromArgb(52, 73, 94)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)

            ' Grid style
            .GridColor = Color.FromArgb(189, 195, 199)
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        End With
    End Sub

    ''' <summary>
    ''' Load history data
    ''' </summary>
    Private Sub LoadHistory()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    a.asset_tag AS 'Asset Tag',
                    a.asset_name AS 'Asset Name',
                    ac.category_name AS 'Category',
                    asub.subcategory_name AS 'Subcategory',
                    DATE_FORMAT(ai.issue_date, '%Y-%m-%d %H:%i') AS 'Issued Date',
                    DATE_FORMAT(ai.actual_return_date, '%Y-%m-%d %H:%i') AS 'Returned Date',
                    ai.status AS 'Status',
                    ai.return_condition AS 'Return Condition',
                    CONCAT(u.first_name, ' ', u.last_name) AS 'Issued By',
                    ai.issue_notes AS 'Issue Notes',
                    ai.return_notes AS 'Return Notes'
                FROM asset_issuance ai
                INNER JOIN assets a ON ai.asset_id = a.asset_id
                LEFT JOIN asset_categories ac ON a.category_id = ac.category_id
                LEFT JOIN asset_subcategories asub ON a.subcategory_id = asub.subcategory_id
                INNER JOIN users u ON ai.issued_by = u.user_id
                WHERE ai.employee_id = @employeeId
                ORDER BY ai.issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@employeeId", employeeId)

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvHistory.DataSource = dt

                        ' Update statistics
                        lblTotalRecords.Text = $"Total Records: {dt.Rows.Count}"

                        ' Count active and returned
                        Dim activeCount As Integer = dt.Select("Status = 'Active'").Length
                        Dim returnedCount As Integer = dt.Select("Status = 'Returned'").Length

                        lblActiveCount.Text = $"Active: {activeCount}"
                        lblReturnedCount.Text = $"Returned: {returnedCount}"

                        ' Color code rows based on status
                        For Each row As DataGridViewRow In dgvHistory.Rows
                            If Not row.IsNewRow Then
                                Dim status As String = row.Cells("Status").Value?.ToString()
                                Select Case status
                                    Case "Active"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 230) ' Light green
                                    Case "Returned"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 240, 255) ' Light blue
                                    Case "Lost"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230) ' Light red
                                    Case "Damaged"
                                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 230) ' Light orange
                                End Select
                            End If
                        Next
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading history: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Close button click
    ''' </summary>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Export to CSV button click
    ''' </summary>
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If dgvHistory.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Create SaveFileDialog
            Using sfd As New SaveFileDialog()
                sfd.Filter = "CSV files (*.csv)|*.csv"
                sfd.FileName = $"Asset_History_{employeeName.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}.csv"

                If sfd.ShowDialog() = DialogResult.OK Then
                    ' Export to CSV
                    Dim dt As DataTable = CType(dgvHistory.DataSource, DataTable)
                    Dim csv As New System.Text.StringBuilder()

                    ' Add headers
                    Dim headers = dt.Columns.Cast(Of DataColumn)().Select(Function(col) col.ColumnName)
                    csv.AppendLine(String.Join(",", headers))

                    ' Add rows
                    For Each row As DataRow In dt.Rows
                        Dim fields = row.ItemArray.Select(Function(field)
                                                              If field Is Nothing OrElse IsDBNull(field) Then
                                                                  Return ""
                                                              Else
                                                                  Return """" & field.ToString().Replace("""", """""") & """"
                                                              End If
                                                          End Function)
                        csv.AppendLine(String.Join(",", fields))
                    Next


                    ' Write to file
                    System.IO.File.WriteAllText(sfd.FileName, csv.ToString())

                    MessageBox.Show("History exported successfully!", "Export Complete",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error exporting history: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Filter status changed
    ''' </summary>
    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        If dgvHistory.DataSource IsNot Nothing Then
            Dim dt As DataTable = CType(dgvHistory.DataSource, DataTable)

            Select Case cboStatusFilter.SelectedIndex
                Case 0 ' All
                    dt.DefaultView.RowFilter = ""
                Case 1 ' Active
                    dt.DefaultView.RowFilter = "Status = 'Active'"
                Case 2 ' Returned
                    dt.DefaultView.RowFilter = "Status = 'Returned'"
                Case 3 ' Lost
                    dt.DefaultView.RowFilter = "Status = 'Lost'"
                Case 4 ' Damaged
                    dt.DefaultView.RowFilter = "Status = 'Damaged'"
            End Select
        End If
    End Sub

    ''' <summary>
    ''' Initialize filter combo box
    ''' </summary>
    Private Sub InitializeFilters()
        cboStatusFilter.Items.Clear()
        cboStatusFilter.Items.Add("All Records")
        cboStatusFilter.Items.Add("Active Only")
        cboStatusFilter.Items.Add("Returned Only")
        cboStatusFilter.Items.Add("Lost Only")
        cboStatusFilter.Items.Add("Damaged Only")
        cboStatusFilter.SelectedIndex = 0
    End Sub

    Private Sub ViewEmployeeHistoryFrm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        InitializeFilters()
    End Sub
End Class