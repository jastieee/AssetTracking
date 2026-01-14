Imports MySql.Data.MySqlClient

Public Class SecurityAccessManager

    ''' <summary>
    ''' Load user access permissions from database
    ''' </summary>
    Public Shared Function LoadUserAccessPermissions(userId As Integer) As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return False

                ' Clear existing permissions
                gUserAccessPermissions.Clear()

                ' Load user's security access
                Dim query As String = "SELECT module_id, access_flag 
                                      FROM security_access 
                                      WHERE user_id = @userId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim moduleId As Integer = Convert.ToInt32(reader("module_id"))
                            Dim accessFlag As Integer = Convert.ToInt32(reader("access_flag"))
                            gUserAccessPermissions(moduleId) = (accessFlag = 1)
                        End While
                    End Using
                End Using

                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading user permissions: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Get list of all modules with their access status for a user
    ''' </summary>
    Public Shared Function GetUserModuleAccess(userId As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return dt

                Dim query As String = "SELECT sm.module_id, sm.module_name,
                                      IFNULL(sa.access_flag, 0) as has_access
                                      FROM security_module sm
                                      LEFT JOIN security_access sa ON sm.module_id = sa.module_id 
                                          AND sa.user_id = @userId
                                      ORDER BY sm.module_id"

                Using adapter As New MySqlDataAdapter(query, conn)
                    adapter.SelectCommand.Parameters.AddWithValue("@userId", userId)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading module access: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Update user access for a specific module
    ''' </summary>
    Public Shared Function UpdateModuleAccess(userId As Integer, moduleId As Integer, hasAccess As Boolean) As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return False

                ' Check if record exists
                Dim checkQuery As String = "SELECT COUNT(*) FROM security_access 
                                           WHERE user_id = @userId AND module_id = @moduleId"
                Dim exists As Boolean = False

                Using checkCmd As New MySqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@userId", userId)
                    checkCmd.Parameters.AddWithValue("@moduleId", moduleId)
                    exists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0
                End Using

                Dim query As String
                If exists Then
                    ' Update existing record
                    query = "UPDATE security_access SET access_flag = @accessFlag 
                            WHERE user_id = @userId AND module_id = @moduleId"
                Else
                    ' Insert new record
                    query = "INSERT INTO security_access (user_id, module_id, access_flag) 
                            VALUES (@userId, @moduleId, @accessFlag)"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)
                    cmd.Parameters.AddWithValue("@moduleId", moduleId)
                    cmd.Parameters.AddWithValue("@accessFlag", If(hasAccess, 1, 0))
                    cmd.ExecuteNonQuery()
                End Using

                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating module access: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Grant full access to all modules for a user (typically for Admin role)
    ''' </summary>
    Public Shared Function GrantFullAccess(userId As Integer) As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return False

                ' Delete existing access records
                Dim deleteQuery As String = "DELETE FROM security_access WHERE user_id = @userId"
                Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                    deleteCmd.Parameters.AddWithValue("@userId", userId)
                    deleteCmd.ExecuteNonQuery()
                End Using

                ' Insert full access for all modules
                Dim insertQuery As String = "INSERT INTO security_access (user_id, module_id, access_flag)
                                            SELECT @userId, module_id, 1 FROM security_module"
                Using insertCmd As New MySqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@userId", userId)
                    insertCmd.ExecuteNonQuery()
                End Using

                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error granting full access: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class