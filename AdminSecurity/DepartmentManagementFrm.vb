Imports MySql.Data.MySqlClient

Public Class DepartmentManagementFrm
    Private Sub DepartmentManagementFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set default filter
        cboStatusFilter.SelectedIndex = 0

        ' Load departments
        LoadDepartments()

        ' Disable action buttons initially
        EnableActionButtons(False)
    End Sub

    Private Sub LoadDepartments()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT department_id, department_name, department_code, description, status, created_at 
                                      FROM departments WHERE 1=1"

                ' Apply status filter
                If cboStatusFilter.SelectedIndex > 0 Then
                    query &= " AND status = '" & cboStatusFilter.Text & "'"
                End If

                ' Apply search filter
                If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                    query &= " AND (department_name LIKE @search OR department_code LIKE @search)"
                End If

                query &= " ORDER BY department_name"

                Using cmd As New MySqlCommand(query, conn)
                    If Not String.IsNullOrWhiteSpace(txtSearch.Text) Then
                        cmd.Parameters.AddWithValue("@search", "%" & txtSearch.Text & "%")
                    End If

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    dgvDepartments.DataSource = dt

                    ' Format DataGridView
                    If dgvDepartments.Columns.Count > 0 Then
                        dgvDepartments.Columns("department_id").HeaderText = "ID"
                        dgvDepartments.Columns("department_id").Width = 50
                        dgvDepartments.Columns("department_name").HeaderText = "Department Name"
                        dgvDepartments.Columns("department_name").Width = 200
                        dgvDepartments.Columns("department_code").HeaderText = "Code"
                        dgvDepartments.Columns("department_code").Width = 100
                        dgvDepartments.Columns("description").HeaderText = "Description"
                        dgvDepartments.Columns("description").Width = 250
                        dgvDepartments.Columns("status").HeaderText = "Status"
                        dgvDepartments.Columns("status").Width = 80
                        dgvDepartments.Columns("created_at").HeaderText = "Created Date"
                        dgvDepartments.Columns("created_at").Width = 150
                    End If

                    ' Update total count
                    lblTotalDepartments.Text = "Total Departments: " & dt.Rows.Count.ToString()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddDepartment_Click(sender As Object, e As EventArgs) Handles btnAddDepartment.Click
        Dim addForm As New AddEditDepartmentFrm()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadDepartments()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadDepartments()
    End Sub

    Private Sub btnClearSearch_Click(sender As Object, e As EventArgs) Handles btnClearSearch.Click
        txtSearch.Clear()
        cboStatusFilter.SelectedIndex = 0
        LoadDepartments()
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        LoadDepartments()
    End Sub

    Private Sub dgvDepartments_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDepartments.SelectionChanged
        EnableActionButtons(dgvDepartments.SelectedRows.Count > 0)
    End Sub

    Private Sub EnableActionButtons(enabled As Boolean)
        btnViewDetails.Enabled = enabled
        btnEdit.Enabled = enabled
        btnDeactivate.Enabled = enabled
        btnDelete.Enabled = enabled
    End Sub

    Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
        If dgvDepartments.SelectedRows.Count > 0 Then
            Dim row = dgvDepartments.SelectedRows(0)
            Dim deptId As Integer = Convert.ToInt32(row.Cells("department_id").Value)

            Dim viewForm As New ViewDepartmentDetailsFrm(deptId)
            viewForm.ShowDialog()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvDepartments.SelectedRows.Count > 0 Then
            Dim row = dgvDepartments.SelectedRows(0)
            Dim deptId As Integer = Convert.ToInt32(row.Cells("department_id").Value)

            Dim editForm As New AddEditDepartmentFrm(deptId)
            If editForm.ShowDialog() = DialogResult.OK Then
                LoadDepartments()
            End If
        End If
    End Sub

    Private Sub btnDeactivate_Click(sender As Object, e As EventArgs) Handles btnDeactivate.Click
        If dgvDepartments.SelectedRows.Count > 0 Then
            Dim row = dgvDepartments.SelectedRows(0)
            Dim deptId As Integer = Convert.ToInt32(row.Cells("department_id").Value)
            Dim deptName As String = row.Cells("department_name").Value.ToString()
            Dim currentStatus As String = row.Cells("status").Value.ToString()

            Dim newStatus As String = If(currentStatus = "Active", "Inactive", "Active")
            Dim action As String = If(currentStatus = "Active", "deactivate", "activate")

            If MessageBox.Show($"Are you sure you want to {action} '{deptName}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                        If conn Is Nothing Then Return

                        Dim query As String = "UPDATE departments SET status = @status, updated_at = NOW() WHERE department_id = @id"
                        Using cmd As New MySqlCommand(query, conn)
                            cmd.Parameters.AddWithValue("@status", newStatus)
                            cmd.Parameters.AddWithValue("@id", deptId)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using

                    MessageBox.Show($"Department {action}d successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadDepartments()
                Catch ex As Exception
                    MessageBox.Show("Error updating department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvDepartments.SelectedRows.Count > 0 Then
            Dim row = dgvDepartments.SelectedRows(0)
            Dim deptId As Integer = Convert.ToInt32(row.Cells("department_id").Value)
            Dim deptName As String = row.Cells("department_name").Value.ToString()

            If MessageBox.Show($"Are you sure you want to DELETE '{deptName}'? This action cannot be undone!", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                        If conn Is Nothing Then Return

                        ' Check if department has employees
                        Dim checkQuery As String = "SELECT COUNT(*) FROM employees WHERE department_id = @id"
                        Using checkCmd As New MySqlCommand(checkQuery, conn)
                            checkCmd.Parameters.AddWithValue("@id", deptId)
                            Dim empCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                            If empCount > 0 Then
                                MessageBox.Show($"Cannot delete this department. It has {empCount} employee(s) assigned to it.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return
                            End If
                        End Using

                        ' Delete department
                        Dim deleteQuery As String = "DELETE FROM departments WHERE department_id = @id"
                        Using cmd As New MySqlCommand(deleteQuery, conn)
                            cmd.Parameters.AddWithValue("@id", deptId)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using

                    MessageBox.Show("Department deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadDepartments()
                Catch ex As Exception
                    MessageBox.Show("Error deleting department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub
End Class