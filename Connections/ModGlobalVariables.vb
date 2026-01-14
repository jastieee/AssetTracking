Module ModGlobalVariables
    ''' <summary>
    ''' Global connection details for MySQL database (Asset Tracking System)
    ''' </summary>
    Public gMySQLServer As String = "192.168.2.121"
    Public gMySQLPort As String = "3306"
    Public gMySQLDBName As String = "asset_tracking_system"
    Public gMySQLUser As String = "root"
    Public gMySQLPassword As String = ""

    ''' <summary>
    ''' Application name prefix for registry
    ''' </summary>
    Public connPrefix As String = "AssetTracking"

    ''' <summary>
    ''' Current logged-in user information
    ''' </summary>
' Current user session information
    Public gCurrentUserId As Integer = 0
    Public gCurrentUserName As String = ""
    Public gCurrentUserRole As String = ""
    Public gCurrentUserDepartment As String = ""
    Public gCurrentUserFullName As String = ""
    Public gCurrentRoleId As Integer = 0

    ' User access permissions (module_id -> has_access)
    Public gUserAccessPermissions As New Dictionary(Of Integer, Boolean)

    ' Module IDs (from security_module table)
    Public Const MODULE_MANAGE_ASSETS As Integer = 1
    Public Const MODULE_ASSET_CATEGORIES As Integer = 2
    Public Const MODULE_ISSUE_ASSET As Integer = 3
    Public Const MODULE_ASSET_ISSUANCE_HISTORY As Integer = 4
    Public Const MODULE_MAINTENANCE_RECORDS As Integer = 5
    Public Const MODULE_MANAGE_CONSUMABLES As Integer = 6
    Public Const MODULE_CONSUMABLE_CATEGORIES As Integer = 7
    Public Const MODULE_ISSUE_CONSUMABLE As Integer = 8
    Public Const MODULE_CONSUMABLE_ISSUANCE_HISTORY As Integer = 9
    Public Const MODULE_MANAGE_EMPLOYEES As Integer = 10
    Public Const MODULE_EMPLOYEE_ISSUED_ITEMS As Integer = 11
    Public Const MODULE_ASSET_REQUESTS As Integer = 12
    Public Const MODULE_CONSUMABLE_REQUESTS As Integer = 13
    Public Const MODULE_DISPOSAL_REQUESTS As Integer = 14
    Public Const MODULE_APPROVE_REQUESTS As Integer = 15
    Public Const MODULE_REQUEST_HISTORY As Integer = 16
    Public Const MODULE_USER_MANAGEMENT As Integer = 17
    Public Const MODULE_DEPARTMENTS As Integer = 18
    Public Const MODULE_REPORTS_ANALYTICS As Integer = 19
    Public Const MODULE_SYSTEM_SETTINGS As Integer = 20
    Public Const MODULE_ACTIVITY_LOGS As Integer = 21

    ''' <summary>
    ''' Check if current user has access to a specific module
    ''' </summary>
    Public Function HasAccess(moduleId As Integer) As Boolean
        If gUserAccessPermissions.ContainsKey(moduleId) Then
            Return gUserAccessPermissions(moduleId)
        End If
        Return False
    End Function

    ''' <summary>
    ''' Clear user session data on logout
    ''' </summary>
    Public Sub ClearUserSession()
        gCurrentUserId = 0
        gCurrentUserName = ""
        gCurrentUserRole = ""
        gCurrentUserDepartment = ""
        gCurrentUserFullName = ""
        gCurrentRoleId = 0
        gUserAccessPermissions.Clear()
    End Sub

    ''' <summary>
    ''' Application settings
    ''' </summary>
    Public gApplicationName As String = "Asset Tracking System"
    Public gApplicationVersion As String = "1.0.0"

End Module