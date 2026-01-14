Imports System.Data.SqlClient
Imports System.IO
Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class OtherSuppliesMaterialsFrm
    Private currentUserId As Integer = 1 ' Should be passed from login

    Private Sub OtherSuppliesMaterialsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeFilters()
        LoadSuppliesData()
    End Sub

    Private Sub InitializeFilters()
        ' Set default values for filters
        cboStockAlert.SelectedIndex = 0 ' All Stock Levels
        cboStatus.SelectedIndex = 0 ' All Status
        txtSearch.Text = ""
    End Sub

    Private Sub LoadSuppliesData(Optional searchText As String = "", Optional stockAlert As String = "All Stock Levels", Optional status As String = "All Status")
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()


                Dim query As String = "SELECT 
                    id,
                    stock_no AS 'Stock No',
                    item_name AS 'Item Name',
                    description AS 'Description',
                    unit_of_measure AS 'Unit',
                    balance_qty_on_hand AS 'Qty On Hand',
                    balance_qty_per_card AS 'Qty Per Card',
                    minimum_stock_level AS 'Min Stock',
                    reorder_level AS 'Reorder Level',
                    unit_cost AS 'Unit Cost',
                    status AS 'Status',
                    CASE 
                        WHEN balance_qty_on_hand = 0 THEN 'Out of Stock'
                        WHEN balance_qty_on_hand <= minimum_stock_level THEN 'Critical'
                        WHEN balance_qty_on_hand <= reorder_level THEN 'Low Stock'
                        ELSE 'Sufficient'
                    END AS 'Stock Alert'
                FROM other_supplies_materials
                WHERE 1=1"

                ' Add search filter
                If Not String.IsNullOrEmpty(searchText) Then
                    query &= " AND (stock_no LIKE @search OR item_name LIKE @search)"
                End If

                ' Add stock alert filter
                If stockAlert <> "All Stock Levels" Then
                    Select Case stockAlert
                        Case "Out of Stock"
                            query &= " AND balance_qty_on_hand = 0"
                        Case "Critical"
                            query &= " AND balance_qty_on_hand > 0 AND balance_qty_on_hand <= minimum_stock_level"
                        Case "Low Stock"
                            query &= " AND balance_qty_on_hand > minimum_stock_level AND balance_qty_on_hand <= reorder_level"
                        Case "Sufficient"
                            query &= " AND balance_qty_on_hand > reorder_level"
                    End Select
                End If

                ' Add status filter
                If status <> "All Status" Then
                    query &= " AND status = @status"
                End If

                query &= " ORDER BY stock_no"

                Using cmd As New MySqlCommand(query, conn)
                    If Not String.IsNullOrEmpty(searchText) Then
                        cmd.Parameters.AddWithValue("@search", "%" & searchText & "%")
                    End If
                    If status <> "All Status" Then
                        cmd.Parameters.AddWithValue("@status", status)
                    End If

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    dgvSupplies.DataSource = dt

                    ' Hide the ID column
                    If dgvSupplies.Columns.Contains("id") Then
                        dgvSupplies.Columns("id").Visible = False
                    End If

                    ' Format currency column
                    If dgvSupplies.Columns.Contains("Unit Cost") Then
                        dgvSupplies.Columns("Unit Cost").DefaultCellStyle.Format = "N2"
                    End If

                    ' Color code stock alerts
                    ColorCodeStockAlerts()

                    lblRecordCount.Text = $"Total Supplies/Materials: {dt.Rows.Count}"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ColorCodeStockAlerts()
        For Each row As DataGridViewRow In dgvSupplies.Rows
            If row.Cells("Stock Alert").Value IsNot Nothing Then
                Dim stockAlert As String = row.Cells("Stock Alert").Value.ToString()

                Select Case stockAlert
                    Case "Out of Stock"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200) ' Light red
                    Case "Critical"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200) ' Light orange
                    Case "Low Stock"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200) ' Light yellow
                End Select
            End If
        Next
    End Sub

    ' Import Button Click
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Title = "Select Import File"
        openFileDialog.Filter = "Excel Files|*.xlsx;*.xls|CSV Files|*.csv"
        openFileDialog.FilterIndex = 1

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            Dim fileExtension As String = Path.GetExtension(filePath).ToLower()

            Try
                Dim importData As DataTable = Nothing

                If fileExtension = ".csv" Then
                    importData = ReadCSVFile(filePath)
                ElseIf fileExtension = ".xlsx" Or fileExtension = ".xls" Then
                    importData = ReadExcelFile(filePath)
                End If

                If importData IsNot Nothing AndAlso importData.Rows.Count > 0 Then
                    ' Show preview form
                    Dim previewForm As New ImportPreviewFrm(importData, Me)
                    previewForm.ShowDialog()
                Else
                    MessageBox.Show("No data found in the selected file.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show($"Error reading file: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function ReadCSVFile(filePath As String) As DataTable
        Dim dt As New DataTable()

        Using reader As New StreamReader(filePath)
            Dim firstLine As String = reader.ReadLine()
            If firstLine Is Nothing Then Return dt

            ' Add columns from header
            Dim headers As String() = firstLine.Split(","c)
            For Each header As String In headers
                dt.Columns.Add(header.Trim())
            Next

            ' Read data rows
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                Dim values As String() = line.Split(","c)

                ' Trim whitespace from values
                For i As Integer = 0 To values.Length - 1
                    values(i) = values(i).Trim()
                Next

                dt.Rows.Add(values)
            End While
        End Using

        Return ValidateImportData(dt)
    End Function

    Private Function ReadExcelFile(filePath As String) As DataTable
        Dim dt As New DataTable()

        Using workbook As New XLWorkbook(filePath)
            Dim worksheet As IXLWorksheet = workbook.Worksheet(1)

            ' Get the first row for headers
            Dim firstRow As IXLRow = worksheet.FirstRowUsed()

            ' Add columns
            For Each cell As IXLCell In firstRow.CellsUsed()
                dt.Columns.Add(cell.Value.ToString().Trim())
            Next

            ' Add data rows
            For Each row As IXLRow In worksheet.RowsUsed().Skip(1)
                Dim dr As DataRow = dt.NewRow()
                Dim cellIndex As Integer = 0

                For Each cell As IXLCell In row.CellsUsed()
                    If cellIndex < dt.Columns.Count Then
                        dr(cellIndex) = cell.Value.ToString().Trim()
                        cellIndex += 1
                    End If
                Next

                dt.Rows.Add(dr)
            Next
        End Using

        Return ValidateImportData(dt)
    End Function

    Private Function ValidateImportData(dt As DataTable) As DataTable
        ' Define required columns
        Dim requiredColumns As String() = {
            "stock_no", "item_name", "unit_of_measure",
            "balance_qty_on_hand", "minimum_stock_level", "reorder_level"
        }

        ' Check if all required columns exist
        For Each col As String In requiredColumns
            If Not dt.Columns.Contains(col) Then
                Throw New Exception($"Required column '{col}' not found in import file.")
            End If
        Next

        ' Add validation status column
        dt.Columns.Add("Validation_Status", GetType(String))
        dt.Columns.Add("Validation_Message", GetType(String))

        ' Validate each row
        For Each row As DataRow In dt.Rows
            Dim validationErrors As New List(Of String)

            ' Validate stock_no
            If String.IsNullOrWhiteSpace(row("stock_no").ToString()) Then
                validationErrors.Add("Stock No is required")
            End If

            ' Validate item_name
            If String.IsNullOrWhiteSpace(row("item_name").ToString()) Then
                validationErrors.Add("Item Name is required")
            End If

            ' Validate unit_of_measure
            If String.IsNullOrWhiteSpace(row("unit_of_measure").ToString()) Then
                validationErrors.Add("Unit of Measure is required")
            End If

            ' Validate numeric fields
            Dim balanceQty As Integer
            If Not Integer.TryParse(row("balance_qty_on_hand").ToString(), balanceQty) Then
                validationErrors.Add("Balance Qty must be a number")
            End If

            Dim minStock As Integer
            If Not Integer.TryParse(row("minimum_stock_level").ToString(), minStock) Then
                validationErrors.Add("Min Stock must be a number")
            End If

            Dim reorderLevel As Integer
            If Not Integer.TryParse(row("reorder_level").ToString(), reorderLevel) Then
                validationErrors.Add("Reorder Level must be a number")
            End If

            ' Validate unit_cost if provided
            If dt.Columns.Contains("unit_cost") AndAlso Not String.IsNullOrWhiteSpace(row("unit_cost").ToString()) Then
                Dim unitCost As Decimal
                If Not Decimal.TryParse(row("unit_cost").ToString(), unitCost) Then
                    validationErrors.Add("Unit Cost must be a valid number")
                End If
            End If

            ' Set validation status
            If validationErrors.Count = 0 Then
                row("Validation_Status") = "Valid"
                row("Validation_Message") = "OK"
            Else
                row("Validation_Status") = "Invalid"
                row("Validation_Message") = String.Join("; ", validationErrors)
            End If
        Next

        Return dt
    End Function

    Public Sub ImportValidatedData(dataToImport As DataTable)
        Dim successCount As Integer = 0
        Dim errorCount As Integer = 0
        Dim errors As New List(Of String)

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()


                For Each row As DataRow In dataToImport.Rows
                    ' Only import valid rows
                    If row("Validation_Status").ToString() = "Valid" Then
                        Try
                            Dim query As String = "INSERT INTO other_supplies_materials 
                                (stock_no, item_name, description, unit_of_measure, reference_number,
                                 balance_qty_on_hand, balance_qty_per_card, minimum_stock_level, 
                                 reorder_level, unit_cost, remarks, status, created_by) 
                                VALUES 
                                (@stock_no, @item_name, @description, @unit_of_measure, @reference_number,
                                 @balance_qty_on_hand, @balance_qty_per_card, @minimum_stock_level,
                                 @reorder_level, @unit_cost, @remarks, @status, @created_by)"

                            Using cmd As New MySqlCommand(query, conn)
                                cmd.Parameters.AddWithValue("@stock_no", row("stock_no").ToString())
                                cmd.Parameters.AddWithValue("@item_name", row("item_name").ToString())
                                cmd.Parameters.AddWithValue("@description", If(dataToImport.Columns.Contains("description"), row("description").ToString(), DBNull.Value))
                                cmd.Parameters.AddWithValue("@unit_of_measure", row("unit_of_measure").ToString())
                                cmd.Parameters.AddWithValue("@reference_number", If(dataToImport.Columns.Contains("reference_number"), row("reference_number").ToString(), DBNull.Value))

                                Dim balanceQty As Integer = Integer.Parse(row("balance_qty_on_hand").ToString())
                                cmd.Parameters.AddWithValue("@balance_qty_on_hand", balanceQty)
                                cmd.Parameters.AddWithValue("@balance_qty_per_card", balanceQty)
                                cmd.Parameters.AddWithValue("@minimum_stock_level", Integer.Parse(row("minimum_stock_level").ToString()))
                                cmd.Parameters.AddWithValue("@reorder_level", Integer.Parse(row("reorder_level").ToString()))

                                ' Unit cost
                                If dataToImport.Columns.Contains("unit_cost") AndAlso Not String.IsNullOrWhiteSpace(row("unit_cost").ToString()) Then
                                    cmd.Parameters.AddWithValue("@unit_cost", Decimal.Parse(row("unit_cost").ToString()))
                                Else
                                    cmd.Parameters.AddWithValue("@unit_cost", DBNull.Value)
                                End If

                                ' Calculate status
                                Dim status As String = "In Stock"
                                Dim minStock As Integer = Integer.Parse(row("minimum_stock_level").ToString())
                                Dim reorderLevel As Integer = Integer.Parse(row("reorder_level").ToString())

                                If balanceQty = 0 Then
                                    status = "Out of Stock"
                                ElseIf balanceQty <= minStock Then
                                    status = "Low Stock"
                                End If

                                cmd.Parameters.AddWithValue("@status", status)

                                ' Remarks
                                Dim remarks As String = ""
                                If balanceQty = 0 Then
                                    remarks = "OS"
                                ElseIf balanceQty <= minStock Then
                                    remarks = "PPR"
                                End If
                                cmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrEmpty(remarks), DBNull.Value, remarks))

                                cmd.Parameters.AddWithValue("@created_by", currentUserId)

                                cmd.ExecuteNonQuery()
                                successCount += 1
                            End Using

                        Catch ex As Exception
                            errorCount += 1
                            errors.Add($"Stock No {row("stock_no")}: {ex.Message}")
                        End Try
                    End If
                Next
            End Using

            ' Show results
            Dim message As String = $"Import completed:{Environment.NewLine}" &
                                  $"Successfully imported: {successCount} records{Environment.NewLine}" &
                                  $"Errors: {errorCount} records"

            If errors.Count > 0 Then
                message &= Environment.NewLine & Environment.NewLine & "Errors:" & Environment.NewLine &
                          String.Join(Environment.NewLine, errors.Take(10))
                If errors.Count > 10 Then
                    message &= Environment.NewLine & $"... and {errors.Count - 10} more errors"
                End If
            End If

            MessageBox.Show(message, "Import Results", MessageBoxButtons.OK,
                          If(errorCount = 0, MessageBoxIcon.Information, MessageBoxIcon.Warning))

            ' Reload data
            LoadSuppliesData()

        Catch ex As Exception
            MessageBox.Show($"Error during import: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Filter controls
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        ApplyFilters()
    End Sub

    Private Sub cboStockAlert_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStockAlert.SelectedIndexChanged
        If cboStockAlert.SelectedIndex >= 0 Then
            ApplyFilters()
        End If
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        If cboStatus.SelectedIndex >= 0 Then
            ApplyFilters()
        End If
    End Sub

    Private Sub ApplyFilters()
        LoadSuppliesData(
            txtSearch.Text.Trim(),
            cboStockAlert.SelectedItem?.ToString(),
            cboStatus.SelectedItem?.ToString()
        )
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        InitializeFilters()
        LoadSuppliesData()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadSuppliesData(
            txtSearch.Text.Trim(),
            cboStockAlert.SelectedItem?.ToString(),
            cboStatus.SelectedItem?.ToString()
        )
    End Sub

    Private Sub btnAddSupply_Click(sender As Object, e As EventArgs) Handles btnAddSupply.Click
        ' TODO: Implement add supply form
        MessageBox.Show("Add Supply functionality will be implemented later.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ' TODO: Implement export functionality
        MessageBox.Show("Export functionality will be implemented later.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
