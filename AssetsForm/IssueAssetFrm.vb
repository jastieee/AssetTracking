Imports System.Data
Imports System.Drawing
Imports System.Windows.Controls
Imports MySql.Data.MySqlClient

Public Class IssueAssetFrm
    Private employeeId As Integer
    Private employeeName As String

    Public Sub New(empId As Integer, empName As String)
        InitializeComponent()
        Me.employeeId = empId
        Me.employeeName = empName
    End Sub

    Private Sub IssueAssetFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        lblFormTitle.Text = $"Issue Asset to {employeeName}"

        ' Style DataGridView
        StyleDataGridView(dgvAssets)

        ' Load available assets
        LoadAvailableAssets()
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
    ''' Load available assets (In Stock only)
    ''' </summary>
    Private Sub LoadAvailableAssets()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    a.asset_id,
                    a.asset_tag AS 'Asset Tag',
                    a.asset_name AS 'Asset Name',
                    ac.category_name AS 'Category',
                    asub.subcategory_name AS 'Subcategory',
                    a.model AS 'Model',
                    a.manufacturer AS 'Manufacturer',
                    a.serial_number AS 'Serial Number',
                    a.condition_status AS 'Condition'
                    FROM assets a
                    LEFT JOIN asset_categories ac ON a.category_id = ac.category_id
                    LEFT JOIN asset_subcategories asub ON a.subcategory_id = asub.subcategory_id
                    WHERE a.status = 'In Stock'
                    ORDER BY a.asset_tag"

                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)
                        dgvAssets.DataSource = dt

                        ' Hide asset_id column
                        If dgvAssets.Columns.Contains("asset_id") Then
                            dgvAssets.Columns("asset_id").Visible = False
                        End If

                        ' Update count
                        lblAssetCount.Text = $"Total Available Assets: {dt.Rows.Count}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading available assets: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Issue button click
    ''' </summary>
    Private Sub btnIssue_Click(sender As Object, e As EventArgs) Handles btnIssue.Click
        If dgvAssets.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an asset to issue.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim assetId As Integer = Convert.ToInt32(dgvAssets.SelectedRows(0).Cells("asset_id").Value)
        Dim assetTag As String = dgvAssets.SelectedRows(0).Cells("Asset Tag").Value.ToString()
        Dim assetName As String = dgvAssets.SelectedRows(0).Cells("Asset Name").Value.ToString()

        ' Confirm issuance
        Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to issue this asset?" & vbCrLf & vbCrLf &
            $"Asset: {assetTag} - {assetName}" & vbCrLf &
            $"Employee: {employeeName}" & vbCrLf & vbCrLf &
            $"Notes: {txtNotes.Text}",
            "Confirm Asset Issuance",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            If IssueAssetToEmployee(assetId, employeeId, txtNotes.Text) Then
                MessageBox.Show($"Asset issued successfully!" & vbCrLf & vbCrLf &
                              $"Asset: {assetTag} - {assetName}" & vbCrLf &
                              $"Employee: {employeeName}",
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Issue asset to employee
    ''' </summary>
    Private Function IssueAssetToEmployee(assetId As Integer, empId As Integer, notes As String) As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return False

                ' Call stored procedure without expected_return_date
                Dim query As String = "CALL sp_issue_asset(@assetId, @employeeId, @issuedBy, NULL, @notes, @issuanceId)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@assetId", assetId)
                    cmd.Parameters.AddWithValue("@employeeId", empId)
                    cmd.Parameters.AddWithValue("@issuedBy", gCurrentUserId)
                    cmd.Parameters.AddWithValue("@notes", If(String.IsNullOrWhiteSpace(notes), DBNull.Value, CType(notes, Object)))

                    Dim issuanceIdParam As New MySqlParameter("@issuanceId", MySqlDbType.Int32)
                    issuanceIdParam.Direction = ParameterDirection.Output
                    cmd.Parameters.Add(issuanceIdParam)

                    cmd.ExecuteNonQuery()

                    Dim issuanceId As Integer = Convert.ToInt32(issuanceIdParam.Value)
                    Return issuanceId > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error issuing asset: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Cancel button click
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' Search text changed
    ''' </summary>
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If dgvAssets.DataSource IsNot Nothing Then
            Dim dt As DataTable = CType(dgvAssets.DataSource, DataTable)
            If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                dt.DefaultView.RowFilter = String.Format(
                    "[Asset Tag] LIKE '%{0}%' OR [Asset Name] LIKE '%{0}%' OR [Category] LIKE '%{0}%' OR [Serial Number] LIKE '%{0}%'",
                    txtSearch.Text.Replace("'", "''"))
            Else
                dt.DefaultView.RowFilter = ""
            End If
        End If
    End Sub
End Class