Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class InventoryStatusFrm

    ''' <summary>
    ''' Form Load - Initialize everything
    ''' </summary>
    Private Sub InventoryStatusFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load filters
        LoadDepartmentFilter()
        LoadStatusFilter()

        ' Load inventory data
        LoadInventoryStatus()
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
    ''' Load status filter dropdown
    ''' </summary>
    Private Sub LoadStatusFilter()
        cboFilterStatus.Items.Clear()
        cboFilterStatus.Items.Add("All Status")
        cboFilterStatus.Items.Add("Low Stock")
        cboFilterStatus.Items.Add("Reorder")
        cboFilterStatus.Items.Add("Sufficient")
        cboFilterStatus.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Load inventory status data
    ''' </summary>
    Private Sub LoadInventoryStatus(Optional departmentId As Integer = 0, Optional statusFilter As String = "")
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Use the view for inventory status
                Dim query As String = "SELECT consumable_code, consumable_name, category_name, department_name, " &
                                     "quantity_on_hand, minimum_stock_level, stock_status " &
                                     "FROM vw_consumable_inventory_status WHERE 1=1"

                ' Add department filter
                If departmentId > 0 Then
                    query &= " AND department_name = (SELECT department_name FROM departments WHERE department_id = @deptId)"
                End If

                ' Add status filter
                If Not String.IsNullOrWhiteSpace(statusFilter) AndAlso statusFilter <> "All Status" Then
                    query &= " AND stock_status = @status"
                End If

                query &= " ORDER BY stock_status DESC, consumable_code"

                Using cmd As New MySqlCommand(query, conn)
                    If departmentId > 0 Then
                        cmd.Parameters.AddWithValue("@deptId", departmentId)
                    End If

                    If Not String.IsNullOrWhiteSpace(statusFilter) AndAlso statusFilter <> "All Status" Then
                        cmd.Parameters.AddWithValue("@status", statusFilter)
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        ' Clear existing rows
                        dgvInventory.Rows.Clear()

                        ' Add rows to DataGridView
                        For Each row As DataRow In dt.Rows
                            Dim idx As Integer = dgvInventory.Rows.Add()
                            dgvInventory.Rows(idx).Cells("colItemCode").Value = row("consumable_code")
                            dgvInventory.Rows(idx).Cells("colItemName").Value = row("consumable_name")
                            dgvInventory.Rows(idx).Cells("colDepartment").Value = row("department_name")
                            dgvInventory.Rows(idx).Cells("colCurrentStock").Value = row("quantity_on_hand")
                            dgvInventory.Rows(idx).Cells("colMinStock").Value = row("minimum_stock_level")
                            dgvInventory.Rows(idx).Cells("colStatus").Value = row("stock_status")
                        Next

                        ' Apply row colors based on status
                        ApplyStatusColors()

                        ' Update summary counts
                        UpdateSummaryCounts(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading inventory status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Apply color coding to rows based on stock status
    ''' </summary>
    Private Sub ApplyStatusColors()
        For Each row As DataGridViewRow In dgvInventory.Rows
            If row.Cells("colStatus").Value IsNot Nothing Then
                Dim status As String = row.Cells("colStatus").Value.ToString()

                Select Case status
                    Case "Low Stock"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226) ' Light red
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28)
                    Case "Reorder"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199) ' Light yellow
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(146, 64, 14)
                    Case "Sufficient"
                        row.DefaultCellStyle.BackColor = Color.FromArgb(220, 252, 231) ' Light green
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(21, 128, 61)
                End Select
            End If
        Next
    End Sub

    ''' <summary>
    ''' Update summary counts at the bottom
    ''' </summary>
    Private Sub UpdateSummaryCounts(dt As DataTable)
        Dim normalCount As Integer = 0
        Dim lowStockCount As Integer = 0
        Dim criticalCount As Integer = 0

        For Each row As DataRow In dt.Rows
            Dim status As String = row("stock_status").ToString()
            Select Case status
                Case "Sufficient"
                    normalCount += 1
                Case "Reorder"
                    lowStockCount += 1
                Case "Low Stock"
                    criticalCount += 1
            End Select
        Next

        lblNormalCount.Text = $"🟢 Normal: {normalCount}"
        lblLowStockCount.Text = $"🟡 Low Stock: {lowStockCount}"
        lblCriticalCount.Text = $"🔴 Critical: {criticalCount}"
    End Sub

    ''' <summary>
    ''' Refresh button click
    ''' </summary>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Dim departmentId As Integer = If(cboFilterDepartment.SelectedIndex > 0, Convert.ToInt32(cboFilterDepartment.SelectedValue), 0)
        Dim statusFilter As String = cboFilterStatus.Text

        LoadInventoryStatus(departmentId, statusFilter)
    End Sub

    ''' <summary>
    ''' Department filter changed
    ''' </summary>
    Private Sub cboFilterDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterDepartment.SelectedIndexChanged
        If cboFilterDepartment.SelectedValue IsNot Nothing AndAlso IsNumeric(cboFilterDepartment.SelectedValue) Then
            Dim departmentId As Integer = CInt(cboFilterDepartment.SelectedValue)
            Dim statusFilter As String = cboFilterStatus.Text
            LoadInventoryStatus(departmentId, statusFilter)
        End If
    End Sub

    ''' <summary>
    ''' Status filter changed
    ''' </summary>
    Private Sub cboFilterStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterStatus.SelectedIndexChanged
        Dim departmentId As Integer = If(cboFilterDepartment.SelectedIndex > 0, Convert.ToInt32(cboFilterDepartment.SelectedValue), 0)
        Dim statusFilter As String = cboFilterStatus.Text
        LoadInventoryStatus(departmentId, statusFilter)
    End Sub

End Class