Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class mainFrm
    Private isLoggingOut As Boolean = False

    Private Sub mainFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form
        InitializeUserInterface()
        LoadDashboardData()
        ApplySecurityAccess()
        StartDateTime()
    End Sub

    ''' <summary>
    ''' Apply security access based on user permissions
    ''' </summary>
    Private Sub ApplySecurityAccess()
        Try
            ' Update user info display
            lblUserName.Text = "👤 " & gCurrentUserFullName
            lblDepartment.Text = "🏢 " & gCurrentUserDepartment & " | " & gCurrentUserRole
            lblWelcome.Text = $"Welcome back, {gCurrentUserFullName.Split(" ")(0)}!"

            ' Dashboard is ALWAYS visible and positioned first
            btnDashboard.Visible = True
            btnAbout.Visible = True ' About is always accessible

            ' Asset Management Section
            btnManageAssets.Visible = HasAccess(MODULE_MANAGE_ASSETS)
            btnAssetCategories.Visible = HasAccess(MODULE_ASSET_CATEGORIES)
            btnIssueAsset.Visible = HasAccess(MODULE_ISSUE_ASSET)
            btnAssetIssuanceHistory.Visible = HasAccess(MODULE_ASSET_ISSUANCE_HISTORY)
            btnMaintenance.Visible = HasAccess(MODULE_MAINTENANCE_RECORDS)

            ' Hide section header if no access to any asset module
            Label1.Visible = btnManageAssets.Visible Or btnAssetCategories.Visible Or
                    btnIssueAsset.Visible Or btnAssetIssuanceHistory.Visible Or
                    btnMaintenance.Visible

            ' Consumable Management Section
            btnManageConsumables.Visible = HasAccess(MODULE_MANAGE_CONSUMABLES)
            btnConsumableCategories.Visible = HasAccess(MODULE_CONSUMABLE_CATEGORIES)
            btnIssueConsumable.Visible = HasAccess(MODULE_ISSUE_CONSUMABLE)
            btnConsumableIssuanceHistory.Visible = HasAccess(MODULE_CONSUMABLE_ISSUANCE_HISTORY)

            Label2.Visible = btnManageConsumables.Visible Or btnConsumableCategories.Visible Or
                    btnIssueConsumable.Visible Or btnConsumableIssuanceHistory.Visible

            ' Employee Management Section
            btnManageEmployees.Visible = HasAccess(MODULE_MANAGE_EMPLOYEES)
            btnEmployeeIssuedItems.Visible = HasAccess(MODULE_EMPLOYEE_ISSUED_ITEMS)

            LabelEmployees.Visible = btnManageEmployees.Visible Or btnEmployeeIssuedItems.Visible

            ' Requests Section
            btnAssetRequests.Visible = HasAccess(MODULE_ASSET_REQUESTS)
            btnConsumableRequests.Visible = HasAccess(MODULE_CONSUMABLE_REQUESTS)
            btnDisposalRequests.Visible = HasAccess(MODULE_DISPOSAL_REQUESTS)
            btnApproveRequests.Visible = HasAccess(MODULE_APPROVE_REQUESTS)
            btnRequestHistory.Visible = HasAccess(MODULE_REQUEST_HISTORY)

            Label3.Visible = btnAssetRequests.Visible Or btnConsumableRequests.Visible Or
                    btnDisposalRequests.Visible Or btnApproveRequests.Visible Or
                    btnRequestHistory.Visible

            ' Administration Section
            btnUserManagement.Visible = HasAccess(MODULE_USER_MANAGEMENT)
            btnDepartmentManagement.Visible = HasAccess(MODULE_DEPARTMENTS)
            btnReports.Visible = HasAccess(MODULE_REPORTS_ANALYTICS)
            btnSettings.Visible = HasAccess(MODULE_SYSTEM_SETTINGS)

            Label4.Visible = btnUserManagement.Visible Or btnDepartmentManagement.Visible Or
                    btnReports.Visible Or btnSettings.Visible

            ' System Section
            btnActivityLogs.Visible = HasAccess(MODULE_ACTIVITY_LOGS)
            Label5.Visible = btnActivityLogs.Visible Or btnAbout.Visible

            ' ====== REPOSITION VISIBLE CONTROLS - This fixes the layout! ======
            RepositionSidebarControls()

        Catch ex As Exception
            MessageBox.Show("Error applying security access: " & ex.Message, "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Reposition sidebar controls to remove gaps from hidden buttons
    ''' </summary>
    Private Sub RepositionSidebarControls()
        Dim currentY As Integer = 14 ' Starting Y position (same as btnDashboard)
        Dim buttonHeight As Integer = 49 ' Standard button height
        Dim dashboardHeight As Integer = 80 ' Dashboard button is taller
        Dim spacing As Integer = 0 ' No spacing between buttons

        ' List of controls in order
        Dim controls As New List(Of Control) From {
        btnDashboard,
        Label1,
        btnManageAssets,
        btnAssetCategories,
        btnIssueAsset,
        btnAssetIssuanceHistory,
        btnMaintenance,
        Label2,
        btnManageConsumables,
        btnConsumableCategories,
        btnIssueConsumable,
        btnConsumableIssuanceHistory,
        LabelEmployees,
        btnManageEmployees,
        btnEmployeeIssuedItems,
        Label3,
        btnAssetRequests,
        btnConsumableRequests,
        btnDisposalRequests,
        btnApproveRequests,
        btnRequestHistory,
        Label4,
        btnUserManagement,
        btnDepartmentManagement,
        btnReports,
        btnSettings,
        Label5,
        btnActivityLogs,
        btnAbout
    }

        ' Reposition each visible control
        For Each ctrl As Control In controls
            If ctrl IsNot Nothing AndAlso ctrl.Visible Then
                ' Set the new Y position
                ctrl.Location = New Point(ctrl.Location.X, currentY)

                ' Increment Y position based on control type and size
                If TypeOf ctrl Is Button Then
                    If ctrl Is btnDashboard Then
                        currentY += dashboardHeight + spacing
                    Else
                        currentY += buttonHeight + spacing
                    End If
                ElseIf TypeOf ctrl Is Label Then
                    ' For section labels, use their actual height
                    currentY += ctrl.Height + spacing
                End If
            End If
        Next

        ' Optional: Enable auto-scroll if content exceeds panel height
        If pnlSidebar IsNot Nothing Then
            pnlSidebar.AutoScroll = True
        End If
    End Sub

    ''' <summary>
    ''' Initialize user interface elements
    ''' </summary>
    Private Sub InitializeUserInterface()
        ' Set default content to welcome panel
        ShowWelcomePanel()

        ' Style DataGridView
        StyleDataGridView(dgvRecentActivity)

        ' Set button click handlers
        AddButtonClickHandlers()
    End Sub

    ''' <summary>
    ''' Add click handlers for all menu buttons
    ''' </summary>
    Private Sub AddButtonClickHandlers()
        ' Dashboard
        AddHandler btnDashboard.Click, AddressOf btnDashboard_Click

        ' Asset Management
        AddHandler btnManageAssets.Click, AddressOf btnManageAssets_Click
        AddHandler btnAssetCategories.Click, AddressOf btnAssetCategories_Click
        AddHandler btnIssueAsset.Click, AddressOf btnIssueAsset_Click
        AddHandler btnAssetIssuanceHistory.Click, AddressOf btnAssetIssuanceHistory_Click
        AddHandler btnMaintenance.Click, AddressOf btnMaintenance_Click

        ' Consumable Management
        AddHandler btnManageConsumables.Click, AddressOf btnManageConsumables_Click
        AddHandler btnConsumableCategories.Click, AddressOf btnConsumableCategories_Click
        AddHandler btnIssueConsumable.Click, AddressOf btnIssueConsumable_Click
        AddHandler btnConsumableIssuanceHistory.Click, AddressOf btnConsumableIssuanceHistory_Click

        ' Employee Management
        AddHandler btnManageEmployees.Click, AddressOf btnManageEmployees_Click
        AddHandler btnEmployeeIssuedItems.Click, AddressOf btnEmployeeIssuedItems_Click

        ' Requests
        AddHandler btnAssetRequests.Click, AddressOf btnAssetRequests_Click
        AddHandler btnConsumableRequests.Click, AddressOf btnConsumableRequests_Click
        AddHandler btnDisposalRequests.Click, AddressOf btnDisposalRequests_Click
        AddHandler btnApproveRequests.Click, AddressOf btnApproveRequests_Click
        AddHandler btnRequestHistory.Click, AddressOf btnRequestHistory_Click

        ' Administration
        AddHandler btnUserManagement.Click, AddressOf btnUserManagement_Click
        AddHandler btnDepartmentManagement.Click, AddressOf btnDepartmentManagement_Click
        AddHandler btnReports.Click, AddressOf btnReports_Click
        AddHandler btnSettings.Click, AddressOf btnSettings_Click

        ' System
        AddHandler btnActivityLogs.Click, AddressOf btnActivityLogs_Click
        AddHandler btnAbout.Click, AddressOf btnAbout_Click

        ' Logout
        AddHandler btnLogout.Click, AddressOf btnLogout_Click
    End Sub

    ' ============================================================================
    ' MENU BUTTON CLICK HANDLERS
    ' ============================================================================

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs)
        SetActiveButton(btnDashboard)
        ShowWelcomePanel()
        LoadDashboardData()
    End Sub

    Private Sub btnManageAssets_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_MANAGE_ASSETS, "Manage Assets") Then Return
        SetActiveButton(btnManageAssets)
        LoadForm(New ManageAssetsFrm())
    End Sub

    Private Sub btnAssetCategories_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_ASSET_CATEGORIES, "Asset Categories") Then Return
        SetActiveButton(btnAssetCategories)
        LoadForm(New AssetCategoriesFrm())
    End Sub

    Private Sub btnIssueAsset_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_ISSUE_ASSET, "Issue Asset") Then Return
        SetActiveButton(btnIssueAsset)
        LoadForm(New AssetIssuedEmployeeFrm())
    End Sub

    Private Sub btnAssetIssuanceHistory_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_ASSET_ISSUANCE_HISTORY, "Asset Issuance History") Then Return
        SetActiveButton(btnAssetIssuanceHistory)
        LoadForm(New AssetIssuanceHistoryFrm())
    End Sub

    Private Sub btnMaintenance_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_MAINTENANCE_RECORDS, "Maintenance Records") Then Return
        SetActiveButton(btnMaintenance)
        LoadForm(New MaintenanceRecordsFrm())
    End Sub

    Private Sub btnManageConsumables_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_MANAGE_CONSUMABLES, "Manage Consumables") Then Return
        SetActiveButton(btnManageConsumables)
        LoadForm(New ManageConsumablesFrm())
    End Sub

    Private Sub btnConsumableCategories_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_CONSUMABLE_CATEGORIES, "Consumable Categories") Then Return
        SetActiveButton(btnConsumableCategories)
        LoadForm(New ConsumableCategoriesFrm())
    End Sub

    Private Sub btnIssueConsumable_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_ISSUE_CONSUMABLE, "Issue Consumable") Then Return
        SetActiveButton(btnIssueConsumable)
        LoadForm(New ConsumableIssuedEmployeeFrm())
    End Sub

    Private Sub btnConsumableIssuanceHistory_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_CONSUMABLE_ISSUANCE_HISTORY, "Consumable Issuance History") Then Return
        SetActiveButton(btnConsumableIssuanceHistory)
        LoadForm(New ConsumableIssuanceHistoryFrm())
    End Sub

    Private Sub btnManageEmployees_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_MANAGE_EMPLOYEES, "Manage Employees") Then Return
        SetActiveButton(btnManageEmployees)
        LoadForm(New EmployeeManagementFrm())
    End Sub

    Private Sub btnEmployeeIssuedItems_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_EMPLOYEE_ISSUED_ITEMS, "Employee Issued Items") Then Return
        SetActiveButton(btnEmployeeIssuedItems)
        LoadForm(New EmployeeIssuedItemsFrm())
    End Sub

    Private Sub btnAssetRequests_Click(sender As Object, e As EventArgs)
        ShowRequestForm("Asset")
    End Sub

    Private Sub btnConsumableRequests_Click(sender As Object, e As EventArgs)
        ShowRequestForm("Consumable")
    End Sub

    Private Sub btnDisposalRequests_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_DISPOSAL_REQUESTS, "Disposal Requests") Then Return
        SetActiveButton(btnDisposalRequests)
        MessageBox.Show("Disposal Requests form will be loaded here", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnApproveRequests_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_APPROVE_REQUESTS, "Approve Requests") Then Return
        SetActiveButton(btnApproveRequests)
        LoadForm(New ApproveRequestsFrm())
    End Sub

    Private Sub btnRequestHistory_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_REQUEST_HISTORY, "Request History") Then Return
        SetActiveButton(btnRequestHistory)
        LoadForm(New RequestHistoryFrm())
    End Sub

    Private Sub btnUserManagement_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_USER_MANAGEMENT, "User Management") Then Return
        SetActiveButton(btnUserManagement)
        LoadForm(New UserManagementFrm())
    End Sub

    Private Sub btnDepartmentManagement_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_DEPARTMENTS, "Department Management") Then Return
        SetActiveButton(btnDepartmentManagement)
        LoadForm(New DepartmentManagementFrm())
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_REPORTS_ANALYTICS, "Reports and Analytics") Then Return
        SetActiveButton(btnReports)
        LoadForm(New ReportsAnalyticsFrm())
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_SYSTEM_SETTINGS, "System Settings") Then Return
        SetActiveButton(btnSettings)
        LoadForm(New SystemSettingsFrm())
    End Sub

    Private Sub btnActivityLogs_Click(sender As Object, e As EventArgs)
        If Not CheckModuleAccess(MODULE_ACTIVITY_LOGS, "Activity Logs") Then Return
        SetActiveButton(btnActivityLogs)
        LoadForm(New ActivityLogsFrm())
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs)
        SetActiveButton(btnAbout)
        MessageBox.Show("Asset Tracking System v1.0" & vbCrLf & vbCrLf &
                       "© 2025 Your Company" & vbCrLf &
                       "All rights reserved.",
                       "About", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Check if user has access to a module and show message if not
    ''' </summary>
    Private Function CheckModuleAccess(moduleId As Integer, moduleName As String) As Boolean
        If Not HasAccess(moduleId) Then
            MessageBox.Show($"You do not have permission to access '{moduleName}'." & vbCrLf & vbCrLf &
                          "Please contact your administrator for access.",
                          "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    ' ============================================================================
    ' HELPER METHODS
    ' ============================================================================

    ''' <summary>
    ''' Load a child form into the main content panel
    ''' </summary>
    Private Sub LoadForm(childForm As Form)
        pnlMainContent.Controls.Clear()
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        pnlMainContent.Controls.Add(childForm)
        childForm.Show()
    End Sub

    ''' <summary>
    ''' Show the welcome/dashboard panel
    ''' </summary>
    Private Sub ShowWelcomePanel()
        pnlMainContent.Controls.Clear()
        pnlMainContent.Controls.Add(pnlWelcome)
        pnlWelcome.Dock = DockStyle.Fill
    End Sub

    ''' <summary>
    ''' Set active button styling
    ''' </summary>
    Private Sub SetActiveButton(activeButton As Button)
        ' Reset all buttons
        For Each ctrl As Control In pnlSidebar.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = CType(ctrl, Button)
                btn.BackColor = Color.FromArgb(52, 73, 94)
                btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular)
            End If
        Next

        ' Set active button
        activeButton.BackColor = Color.FromArgb(41, 128, 185)
        activeButton.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
    End Sub

    ''' <summary>
    ''' Load dashboard data and statistics
    ''' </summary>
    Private Sub LoadDashboardData()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Total Assets in Stock
                Dim queryAssets As String = "SELECT COUNT(*) FROM assets WHERE status = 'In Stock'"
                Using cmd As New MySqlCommand(queryAssets, conn)
                    lblCardValue1.Text = cmd.ExecuteScalar().ToString()
                End Using

                ' Total Consumables
                Dim queryConsumables As String = "SELECT COUNT(*) FROM consumables"
                Using cmd As New MySqlCommand(queryConsumables, conn)
                    lblCardValue2.Text = cmd.ExecuteScalar().ToString()
                End Using

                ' Assets Currently Issued
                Dim queryIssued As String = "SELECT COUNT(*) FROM asset_issuance WHERE status = 'Active'"
                Using cmd As New MySqlCommand(queryIssued, conn)
                    lblCardValue3.Text = cmd.ExecuteScalar().ToString()
                End Using

                ' Pending Requests
                Dim queryRequests As String = "SELECT COUNT(*) FROM 
                    (SELECT request_id FROM asset_requests WHERE status = 'Pending'
                     UNION ALL
                     SELECT request_id FROM consumable_requests WHERE status = 'Pending'
                     UNION ALL
                     SELECT disposal_id FROM disposal_requests WHERE status = 'Pending') as pending"
                Using cmd As New MySqlCommand(queryRequests, conn)
                    lblCardValue4.Text = cmd.ExecuteScalar().ToString()
                End Using

                ' Low Stock Alerts
                Dim queryLowStock As String = "SELECT COUNT(*) FROM consumables 
                                              WHERE total_quantity_in_stock <= reorder_level"
                Using cmd As New MySqlCommand(queryLowStock, conn)
                    lblCardValue5.Text = cmd.ExecuteScalar().ToString()
                End Using

                ' Employees with Assets
                Dim queryEmployees As String = "SELECT COUNT(DISTINCT employee_id) 
                                               FROM asset_issuance WHERE status = 'Active'"
                Using cmd As New MySqlCommand(queryEmployees, conn)
                    lblCardValue6.Text = cmd.ExecuteScalar().ToString()
                End Using

                ' Load Recent Activity
                LoadRecentActivity()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading dashboard data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load recent activity logs
    ''' </summary>
    Private Sub LoadRecentActivity()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    al.action_type as 'Action',
                    CONCAT(u.first_name, ' ', u.last_name) as 'User',
                    al.description as 'Description',
                    DATE_FORMAT(al.created_at, '%Y-%m-%d %H:%i:%s') as 'Date/Time'
                    FROM activity_logs al
                    LEFT JOIN users u ON al.user_id = u.user_id
                    ORDER BY al.created_at DESC
                    LIMIT 10"

                Using adapter As New MySqlDataAdapter(query, conn)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvRecentActivity.DataSource = dt

                    ' Auto-size columns after data is loaded
                    If dgvRecentActivity.Columns.Count > 0 Then
                        dgvRecentActivity.Columns("Action").Width = 150
                        dgvRecentActivity.Columns("User").Width = 150
                        dgvRecentActivity.Columns("Description").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                        dgvRecentActivity.Columns("Date/Time").Width = 180
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Silent fail for recent activity
            Debug.WriteLine("Error loading recent activity: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Style DataGridView
    ''' </summary>
    Private Sub StyleDataGridView(dgv As DataGridView)
        ' Header style
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgv.ColumnHeadersHeight = 40
        dgv.EnableHeadersVisualStyles = False

        ' Row style
        dgv.DefaultCellStyle.BackColor = Color.White
        dgv.DefaultCellStyle.ForeColor = Color.FromArgb(52, 73, 94)
        dgv.DefaultCellStyle.Font = New Font("Segoe UI", 9)
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.RowTemplate.Height = 35
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)

        ' Grid style
        dgv.GridColor = Color.FromArgb(189, 195, 199)
        dgv.BorderStyle = BorderStyle.None
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
    End Sub

    ''' <summary>
    ''' Start date/time display
    ''' </summary>
    Private Sub StartDateTime()
        Dim timer As New Timer()
        timer.Interval = 1000 ' Update every second
        AddHandler timer.Tick, Sub()
                                   lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy - hh:mm:ss tt")
                               End Sub
        timer.Start()
        lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy - hh:mm:ss tt")
    End Sub

    ''' <summary>
    ''' Handle logout - FIXED VERSION
    ''' </summary>
    Private Sub btnLogout_Click(sender As Object, e As EventArgs)
        If isLoggingOut Then Return ' Prevent multiple logout attempts

        Dim result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            isLoggingOut = True

            ' Log the logout activity
            If gCurrentUserId > 0 Then
                LogActivity(gCurrentUserId, "User Logout", "users", gCurrentUserId,
                           $"User {gCurrentUserName} logged out")
            End If

            ' Clear user session
            ClearUserSession()

            ' Close the CURRENT main form (important!)
            Me.Hide()

            ' Show login form
            Dim loginForm As New loginFrm()
            If loginForm.ShowDialog() = DialogResult.OK Then
                ' Create and show a NEW main form instance with the new user
                Dim newMainForm As New mainFrm()
                newMainForm.Show()
            Else
                ' User cancelled login, exit application
                Application.Exit()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Log activity to database
    ''' </summary>
    Private Sub LogActivity(userId As Integer, actionType As String, tableName As String, recordId As Integer, description As String)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "INSERT INTO activity_logs (user_id, action_type, table_name, record_id, description, ip_address) 
                                       VALUES (@userId, @actionType, @tableName, @recordId, @description, @ipAddress)"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)
                    cmd.Parameters.AddWithValue("@actionType", actionType)
                    cmd.Parameters.AddWithValue("@tableName", tableName)
                    cmd.Parameters.AddWithValue("@recordId", recordId)
                    cmd.Parameters.AddWithValue("@description", description)
                    cmd.Parameters.AddWithValue("@ipAddress", GetLocalIPAddress())
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Silent fail for logging
            Debug.WriteLine("Error logging activity: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Get local IP address
    ''' </summary>
    Private Function GetLocalIPAddress() As String
        Try
            Dim host As String = System.Net.Dns.GetHostName()
            Dim ip As System.Net.IPAddress = System.Net.Dns.GetHostEntry(host).AddressList.FirstOrDefault(Function(x) x.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)
            If ip IsNot Nothing Then
                Return ip.ToString()
            End If
        Catch ex As Exception
            ' Return default if error
        End Try
        Return "Unknown"
    End Function

    ''' <summary>
    ''' Handle form closing - FIXED VERSION
    ''' </summary>
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)

        ' Only show exit confirmation if NOT logging out and user clicked X
        If e.CloseReason = CloseReason.UserClosing AndAlso Not isLoggingOut Then
            Dim result = MessageBox.Show("Are you sure you want to exit the application?",
                                        "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.No Then
                e.Cancel = True
            Else
                ' Log the logout
                If gCurrentUserId > 0 Then
                    LogActivity(gCurrentUserId, "User Logout", "users", gCurrentUserId,
                               $"User {gCurrentUserName} logged out (application closed)")
                End If
                Application.Exit()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Show request form based on type
    ''' </summary>
    Private Sub ShowRequestForm(requestType As String)
        Try
            ' Get current user's employee_id from the database
            Dim employeeId As Integer = GetEmployeeIdForUser(gCurrentUserId)

            If employeeId = 0 Then
                MessageBox.Show("No employee record found for this user. Please contact administrator.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Open the RequestStatusFrm (main view) instead of RequestSlipFrm
            SetActiveButton(If(requestType = "Asset", btnAssetRequests, btnConsumableRequests))
            LoadForm(New RequestStatusFrm(gCurrentUserId, employeeId, requestType))

        Catch ex As Exception
            MessageBox.Show($"Error opening request form: {ex.Message}",
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Get employee ID for current user
    ''' </summary>
    Private Function GetEmployeeIdForUser(userId As Integer) As Integer
        Dim employeeId As Integer = 0

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return 0

                ' First try to get employee_id from users table if linked
                Dim query As String = "SELECT e.employee_id " &
                                    "FROM users u " &
                                    "INNER JOIN employees e ON u.user_id = e.user_id " &
                                    "WHERE u.user_id = @userId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userId", userId)

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        employeeId = Convert.ToInt32(result)
                    End If
                End Using

                ' If not found, try matching by email
                If employeeId = 0 Then
                    query = "SELECT e.employee_id " &
                           "FROM users u " &
                           "INNER JOIN employees e ON u.email = e.email " &
                           "WHERE u.user_id = @userId"

                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@userId", userId)

                        Dim result = cmd.ExecuteScalar()
                        If result IsNot Nothing Then
                            employeeId = Convert.ToInt32(result)
                        End If
                    End Using
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error getting employee ID: {ex.Message}",
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return employeeId
    End Function

End Class