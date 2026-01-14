Imports MySql.Data.MySqlClient

Public Class EmployeeIssuedItemsFrm
    Private dtAllIssuedItems As DataTable

    Private Sub EmployeeIssuedItemsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConfigureDataGridView()
            cboItemType.SelectedIndex = 0 ' Default to "All Items"
            LoadAllIssuedItems() ' Load all items by default
        Catch ex As Exception
            MessageBox.Show("Error loading form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigureDataGridView()
        ' Configure DataGridView appearance
        With dgvIssuedItems
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells ' Changed from Fill to AllCells
            .RowHeadersVisible = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True ' Enable word wrap
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250)
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .ColumnHeadersHeight = 40
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells ' Allow rows to auto-size based on content
            .RowTemplate.Height = 35
        End With
    End Sub

    Private Sub LoadAllIssuedItems()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                Dim query As String = "SELECT * FROM vw_employee_issued_items ORDER BY issue_date DESC"

                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        dtAllIssuedItems = New DataTable()
                        adapter.Fill(dtAllIssuedItems)
                        ApplyFilters()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading issued items: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyFilters()
        If dtAllIssuedItems Is Nothing Then Return

        Dim dv As New DataView(dtAllIssuedItems)
        Dim filterList As New List(Of String)

        ' Apply employee search filter
        If Not String.IsNullOrWhiteSpace(cboEmployee.Text) Then
            Dim searchText As String = cboEmployee.Text.Replace("'", "''") ' Escape single quotes
            filterList.Add($"(employee_name LIKE '%{searchText}%' OR employee_number LIKE '%{searchText}%')")
        End If

        ' Apply item type filter
        Select Case cboItemType.SelectedIndex
            Case 1 ' Assets Only
                filterList.Add("item_type = 'Asset'")
            Case 2 ' Consumables Only
                filterList.Add("item_type = 'Consumable'")
        End Select

        ' Combine filters
        If filterList.Count > 0 Then
            dv.RowFilter = String.Join(" AND ", filterList)
        End If

        dgvIssuedItems.DataSource = dv

        ' Format DataGridView columns
        FormatDataGridViewColumns()

        ' Update counters
        UpdateCounters(dv)
    End Sub

    Private Sub FormatDataGridViewColumns()
        If dgvIssuedItems.Columns.Count = 0 Then Return

        ' Hide unnecessary columns
        Dim columnsToHide() As String = {"employee_id", "qr_code_data", "email", "phone_number"}
        For Each colName As String In columnsToHide
            If dgvIssuedItems.Columns.Contains(colName) Then
                dgvIssuedItems.Columns(colName).Visible = False
            End If
        Next

        ' Set column headers and configure wrapping
        If dgvIssuedItems.Columns.Contains("employee_number") Then
            dgvIssuedItems.Columns("employee_number").HeaderText = "Emp. No"
            dgvIssuedItems.Columns("employee_number").DisplayIndex = 0
        End If

        If dgvIssuedItems.Columns.Contains("employee_name") Then
            dgvIssuedItems.Columns("employee_name").HeaderText = "Employee Name"
            dgvIssuedItems.Columns("employee_name").DisplayIndex = 1
        End If

        If dgvIssuedItems.Columns.Contains("department_name") Then
            dgvIssuedItems.Columns("department_name").HeaderText = "Department"
            dgvIssuedItems.Columns("department_name").DisplayIndex = 2
        End If

        If dgvIssuedItems.Columns.Contains("position_name") Then
            dgvIssuedItems.Columns("position_name").HeaderText = "Position"
            dgvIssuedItems.Columns("position_name").DisplayIndex = 3
        End If

        If dgvIssuedItems.Columns.Contains("item_type") Then
            dgvIssuedItems.Columns("item_type").HeaderText = "Type"
            dgvIssuedItems.Columns("item_type").DisplayIndex = 4
        End If

        If dgvIssuedItems.Columns.Contains("item_code") Then
            dgvIssuedItems.Columns("item_code").HeaderText = "Item Code"
            dgvIssuedItems.Columns("item_code").DisplayIndex = 5
        End If

        If dgvIssuedItems.Columns.Contains("item_name") Then
            dgvIssuedItems.Columns("item_name").HeaderText = "Item Name"
            dgvIssuedItems.Columns("item_name").DisplayIndex = 6
        End If

        If dgvIssuedItems.Columns.Contains("category") Then
            dgvIssuedItems.Columns("category").HeaderText = "Category"
            dgvIssuedItems.Columns("category").DisplayIndex = 7
        End If

        If dgvIssuedItems.Columns.Contains("subcategory") Then
            dgvIssuedItems.Columns("subcategory").HeaderText = "Subcategory"
            dgvIssuedItems.Columns("subcategory").DisplayIndex = 8
        End If

        If dgvIssuedItems.Columns.Contains("issue_date") Then
            dgvIssuedItems.Columns("issue_date").HeaderText = "Issue Date"
            dgvIssuedItems.Columns("issue_date").DefaultCellStyle.Format = "MM/dd/yyyy"
            dgvIssuedItems.Columns("issue_date").DisplayIndex = 9
        End If

        If dgvIssuedItems.Columns.Contains("expected_return_date") Then
            dgvIssuedItems.Columns("expected_return_date").HeaderText = "Expected Return"
            dgvIssuedItems.Columns("expected_return_date").DefaultCellStyle.Format = "MM/dd/yyyy"
            dgvIssuedItems.Columns("expected_return_date").DisplayIndex = 10
        End If

        If dgvIssuedItems.Columns.Contains("issuance_status") Then
            dgvIssuedItems.Columns("issuance_status").HeaderText = "Status"
            dgvIssuedItems.Columns("issuance_status").DisplayIndex = 11
        End If

        If dgvIssuedItems.Columns.Contains("quantity") Then
            dgvIssuedItems.Columns("quantity").HeaderText = "Qty"
            dgvIssuedItems.Columns("quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvIssuedItems.Columns("quantity").DisplayIndex = 12
        End If

        ' Color code item types
        For Each row As DataGridViewRow In dgvIssuedItems.Rows
            If row.Cells("item_type").Value IsNot Nothing Then
                If row.Cells("item_type").Value.ToString() = "Asset" Then
                    row.Cells("item_type").Style.BackColor = Color.FromArgb(52, 152, 219)
                    row.Cells("item_type").Style.ForeColor = Color.White
                    row.Cells("item_type").Style.Font = New Font("Segoe UI", 8, FontStyle.Bold)
                Else
                    row.Cells("item_type").Style.BackColor = Color.FromArgb(142, 68, 173)
                    row.Cells("item_type").Style.ForeColor = Color.White
                    row.Cells("item_type").Style.Font = New Font("Segoe UI", 8, FontStyle.Bold)
                End If
            End If

            ' Color code status
            If row.Cells("issuance_status").Value IsNot Nothing Then
                Dim status As String = row.Cells("issuance_status").Value.ToString()
                Select Case status
                    Case "Active"
                        row.Cells("issuance_status").Style.BackColor = Color.FromArgb(46, 204, 113)
                        row.Cells("issuance_status").Style.ForeColor = Color.White
                        row.Cells("issuance_status").Style.Font = New Font("Segoe UI", 8, FontStyle.Bold)
                    Case "Returned"
                        row.Cells("issuance_status").Style.BackColor = Color.FromArgb(149, 165, 166)
                        row.Cells("issuance_status").Style.ForeColor = Color.White
                        row.Cells("issuance_status").Style.Font = New Font("Segoe UI", 8, FontStyle.Bold)
                    Case "Issued"
                        row.Cells("issuance_status").Style.BackColor = Color.FromArgb(52, 152, 219)
                        row.Cells("issuance_status").Style.ForeColor = Color.White
                        row.Cells("issuance_status").Style.Font = New Font("Segoe UI", 8, FontStyle.Bold)
                End Select
            End If
        Next
    End Sub

    Private Sub UpdateCounters(dv As DataView)
        Dim totalItems As Integer = dv.Count
        Dim assetCount As Integer = 0
        Dim consumableCount As Integer = 0

        For Each row As DataRowView In dv
            If row("item_type").ToString() = "Asset" Then
                assetCount += 1
            Else
                consumableCount += 1
            End If
        Next

        lblRecordCount.Text = $"Total Items: {totalItems}"
        lblTotalAssets.Text = $"Assets Issued: {assetCount}"
        lblTotalConsumables.Text = $"Consumables Issued: {consumableCount}"
    End Sub

    Private Sub cboEmployee_TextChanged(sender As Object, e As EventArgs) Handles cboEmployee.TextChanged
        ' Apply filters as user types
        ApplyFilters()
    End Sub

    Private Sub cboItemType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemType.SelectedIndexChanged
        ApplyFilters()
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        cboEmployee.Text = ""
        cboItemType.SelectedIndex = 0
        pnlEmployeeInfo.Visible = False
        ApplyFilters()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadAllIssuedItems()
        MessageBox.Show("Data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If dgvIssuedItems.Rows.Count = 0 Then
            MessageBox.Show("No data to export!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "CSV File|*.csv"
            saveFileDialog.Title = "Export to CSV"
            saveFileDialog.FileName = $"Employee_Issued_Items_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Using writer As New IO.StreamWriter(saveFileDialog.FileName)
                    ' Write headers
                    Dim headers As New List(Of String)
                    For Each column As DataGridViewColumn In dgvIssuedItems.Columns
                        If column.Visible Then
                            headers.Add(column.HeaderText)
                        End If
                    Next
                    writer.WriteLine(String.Join(",", headers))

                    ' Write data
                    For Each row As DataGridViewRow In dgvIssuedItems.Rows
                        Dim cells As New List(Of String)
                        For Each column As DataGridViewColumn In dgvIssuedItems.Columns
                            If column.Visible Then
                                Dim cellValue As String = If(row.Cells(column.Index).Value Is Nothing, "", row.Cells(column.Index).Value.ToString())
                                ' Escape commas and quotes
                                If cellValue.Contains(",") Or cellValue.Contains("""") Then
                                    cellValue = """" & cellValue.Replace("""", """""") & """"
                                End If
                                cells.Add(cellValue)
                            End If
                        Next
                        writer.WriteLine(String.Join(",", cells))
                    Next
                End Using

                MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error exporting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrintReport_Click(sender As Object, e As EventArgs) Handles btnPrintReport.Click
        If dgvIssuedItems.Rows.Count = 0 Then
            MessageBox.Show("No data to print!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        MessageBox.Show("Print functionality will be implemented with a reporting tool.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' TODO: Implement printing functionality using Crystal Reports or another reporting tool
    End Sub

    Private Sub dgvIssuedItems_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvIssuedItems.CellDoubleClick
        If e.RowIndex >= 0 Then
            ' Get the selected row
            Dim row As DataGridViewRow = dgvIssuedItems.Rows(e.RowIndex)

            ' Show employee info panel with selected employee's details
            If row.Cells("employee_name").Value IsNot Nothing Then
                lblEmployeeNameValue.Text = row.Cells("employee_name").Value.ToString()
                lblEmployeeNumberValue.Text = row.Cells("employee_number").Value.ToString()
                lblDepartmentValue.Text = row.Cells("department_name").Value.ToString()
                lblPositionValue.Text = row.Cells("position_name").Value.ToString()
                pnlEmployeeInfo.Visible = True
            End If
        End If
    End Sub
End Class