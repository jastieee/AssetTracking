Imports System.Data

Public Class ImportPreviewFrm
    Private importData As DataTable
    Private parentForm As OtherSuppliesMaterialsFrm

    ' Constructor
    Public Sub New(data As DataTable, parent As OtherSuppliesMaterialsFrm)
        ' This call is required by the designer
        InitializeComponent()

        ' Store the passed parameters
        Me.importData = data
        Me.parentForm = parent
    End Sub

    ' Form Load Event
    Private Sub ImportPreviewFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Display preview data in DataGridView
            dgvPreview.DataSource = importData

            ' Apply color coding based on validation status
            ColorCodeValidationStatus()

            ' Count and display valid/invalid records
            DisplayRecordCounts()

        Catch ex As Exception
            MessageBox.Show($"Error loading preview: {ex.Message}",
                          "Preview Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try
    End Sub

    ' Color code rows based on validation status
    Private Sub ColorCodeValidationStatus()
        Try
            For Each row As DataGridViewRow In dgvPreview.Rows
                If row.Cells("Validation_Status").Value IsNot Nothing Then
                    Dim validationStatus As String = row.Cells("Validation_Status").Value.ToString()

                    If validationStatus = "Invalid" Then
                        ' Red background for invalid records
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200)
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(139, 0, 0) ' Dark red text
                    Else
                        ' Green background for valid records
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200)
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 100, 0) ' Dark green text
                    End If
                End If
            Next
        Catch ex As Exception
            ' Silently handle color coding errors
            Debug.WriteLine($"Error in color coding: {ex.Message}")
        End Try
    End Sub

    ' Display record counts
    Private Sub DisplayRecordCounts()
        Try
            Dim validCount As Integer = 0
            Dim invalidCount As Integer = 0

            ' Count valid and invalid records using LINQ
            If importData IsNot Nothing AndAlso importData.Rows.Count > 0 Then
                validCount = importData.AsEnumerable().Count(Function(r) r("Validation_Status").ToString() = "Valid")
                invalidCount = importData.Rows.Count - validCount
            End If

            ' Update label with counts
            lblPreviewInfo.Text = $"Total Records: {importData.Rows.Count} | Valid: {validCount} | Invalid: {invalidCount}"

            ' Change label color based on validation results
            If invalidCount = 0 Then
                lblPreviewInfo.ForeColor = Color.FromArgb(46, 204, 113) ' Green
            ElseIf validCount = 0 Then
                lblPreviewInfo.ForeColor = Color.FromArgb(231, 76, 60) ' Red
            Else
                lblPreviewInfo.ForeColor = Color.FromArgb(243, 156, 18) ' Orange
            End If

        Catch ex As Exception
            lblPreviewInfo.Text = $"Error counting records: {ex.Message}"
            lblPreviewInfo.ForeColor = Color.FromArgb(231, 76, 60)
        End Try
    End Sub

    ' Import Button Click Event
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Try
            ' Count valid records
            Dim validCount As Integer = importData.AsEnumerable().Count(Function(r) r("Validation_Status").ToString() = "Valid")

            ' Check if there are any valid records to import
            If validCount = 0 Then
                MessageBox.Show("No valid records to import.",
                              "Import",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning)
                Return
            End If

            ' Confirm import with user
            Dim confirmMessage As String = $"Are you sure you want to import {validCount} valid record(s)?{Environment.NewLine}{Environment.NewLine}"

            Dim invalidCount As Integer = importData.Rows.Count - validCount
            If invalidCount > 0 Then
                confirmMessage &= $"⚠ {invalidCount} invalid record(s) will be skipped."
            End If

            Dim result As DialogResult = MessageBox.Show(
                confirmMessage,
                "Confirm Import",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            ' Proceed with import if user confirms
            If result = DialogResult.Yes Then
                ' Call parent form's import method
                parentForm.ImportValidatedData(importData)

                ' Close preview form
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show($"Error during import: {ex.Message}",
                          "Import Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
        End Try
    End Sub

    ' Cancel Button Click Event
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Close the form without importing
        Me.Close()
    End Sub

    ' Optional: Double-click on row to see full validation message
    Private Sub dgvPreview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPreview.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso e.RowIndex < dgvPreview.Rows.Count Then
                Dim row As DataGridViewRow = dgvPreview.Rows(e.RowIndex)

                If row.Cells("Validation_Message").Value IsNot Nothing Then
                    Dim validationMessage As String = row.Cells("Validation_Message").Value.ToString()
                    Dim stockNo As String = If(row.Cells("stock_no").Value IsNot Nothing,
                                               row.Cells("stock_no").Value.ToString(),
                                               "N/A")

                    Dim status As String = If(row.Cells("Validation_Status").Value IsNot Nothing,
                                             row.Cells("Validation_Status").Value.ToString(),
                                             "Unknown")

                    MessageBox.Show($"Stock No: {stockNo}{Environment.NewLine}" &
                                  $"Status: {status}{Environment.NewLine}{Environment.NewLine}" &
                                  $"Message: {validationMessage}",
                                  "Validation Details",
                                  MessageBoxButtons.OK,
                                  If(status = "Valid", MessageBoxIcon.Information, MessageBoxIcon.Warning))
                End If
            End If
        Catch ex As Exception
            ' Silently handle any errors in displaying validation details
            Debug.WriteLine($"Error displaying validation details: {ex.Message}")
        End Try
    End Sub

    ' Optional: Format columns on data binding
    Private Sub dgvPreview_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvPreview.DataBindingComplete
        Try
            ' Auto-size columns to fit content
            dgvPreview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

            ' Make validation message column wider
            If dgvPreview.Columns.Contains("Validation_Message") Then
                dgvPreview.Columns("Validation_Message").Width = 250
            End If

            ' Format validation status column
            If dgvPreview.Columns.Contains("Validation_Status") Then
                dgvPreview.Columns("Validation_Status").Width = 80
                dgvPreview.Columns("Validation_Status").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

        Catch ex As Exception
            ' Silently handle formatting errors
            Debug.WriteLine($"Error formatting columns: {ex.Message}")
        End Try
    End Sub
End Class