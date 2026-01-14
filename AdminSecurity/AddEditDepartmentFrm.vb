Imports MySql.Data.MySqlClient

Public Class AddEditDepartmentFrm
    Private departmentId As Integer = 0
    Private isEditMode As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(deptId As Integer)
        InitializeComponent()
        departmentId = deptId
        isEditMode = True
    End Sub

    Private Sub AddEditDepartmentFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        lblTitle.Text = If(isEditMode, "✏️ Edit Department", "➕ Add Department")

        ' Set default status
        cboStatus.SelectedIndex = 0

        ' Load data if edit mode
        If isEditMode Then
            LoadDepartmentData()
        End If
    End Sub

    Private Sub LoadDepartmentData()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT * FROM departments WHERE department_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", departmentId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtDepartmentName.Text = reader("department_name").ToString()
                            txtDepartmentCode.Text = reader("department_code").ToString()
                            txtDescription.Text = If(IsDBNull(reader("description")), "", reader("description").ToString())
                            cboStatus.SelectedItem = reader("status").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation
        If String.IsNullOrWhiteSpace(txtDepartmentName.Text) Then
            MessageBox.Show("Please enter department name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDepartmentName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtDepartmentCode.Text) Then
            MessageBox.Show("Please enter department code.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDepartmentCode.Focus()
            Return
        End If

        If cboStatus.SelectedIndex = -1 Then
            MessageBox.Show("Please select status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboStatus.Focus()
            Return
        End If

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String

                If isEditMode Then
                    query = "UPDATE departments SET department_name = @name, department_code = @code, 
                            description = @desc, status = @status, updated_at = NOW() WHERE department_id = @id"
                Else
                    query = "INSERT INTO departments (department_name, department_code, description, status) 
                            VALUES (@name, @code, @desc, @status)"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtDepartmentName.Text.Trim())
                    cmd.Parameters.AddWithValue("@code", txtDepartmentCode.Text.Trim().ToUpper())
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim())
                    cmd.Parameters.AddWithValue("@status", cboStatus.SelectedItem.ToString())

                    If isEditMode Then
                        cmd.Parameters.AddWithValue("@id", departmentId)
                    End If

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show(If(isEditMode, "Department updated", "Department added") & " successfully!",
                          "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("Department name or code already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Error saving department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving department: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class