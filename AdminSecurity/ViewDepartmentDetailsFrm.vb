Imports MySql.Data.MySqlClient

Public Class ViewDepartmentDetailsFrm
    Private departmentId As Integer

    Public Sub New(deptId As Integer)
        InitializeComponent()
        departmentId = deptId
    End Sub

    Private Sub ViewDepartmentDetailsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDepartmentDetails()
    End Sub

    Private Sub LoadDepartmentDetails()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Load department data with employee count
                Dim query As String = "SELECT d.*, " &
                                     "(SELECT COUNT(*) FROM employees WHERE department_id = d.department_id) as emp_count " &
                                     "FROM departments d WHERE d.department_id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", departmentId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblDeptName.Text = "Department Name: " & reader("department_name").ToString()
                            lblDeptCode.Text = "Department Code: " & reader("department_code").ToString()
                            lblDescription.Text = "Description: " & If(IsDBNull(reader("description")), "N/A", reader("description").ToString())
                            lblStatus.Text = "Status: " & reader("status").ToString()
                            lblEmployeeCount.Text = "Total Employees: " & reader("emp_count").ToString()
                            lblCreatedDate.Text = "Created: " & Convert.ToDateTime(reader("created_at")).ToString("MMM dd, yyyy hh:mm tt")
                            lblUpdatedDate.Text = "Last Updated: " & Convert.ToDateTime(reader("updated_at")).ToString("MMM dd, yyyy hh:mm tt")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading department details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class