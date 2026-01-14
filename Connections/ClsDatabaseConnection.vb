Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports Microsoft.Win32
Imports System.Security.Cryptography

Public Class ClsDatabaseConnection

    ' Registry constants for Asset Tracking System
    Private Const REGISTRY_KEY As String = "HKEY_CURRENT_USER\SOFTWARE\AssetTrackingSystem"
    Private Const SERVER_VALUE As String = "Server"
    Private Const DATABASE_VALUE As String = "Database"
    Private Const USER_VALUE As String = "User"
    Private Const PASSWORD_VALUE As String = "Password"
    Private Const PORT_VALUE As String = "Port"

    ' Shared connection string property
    Public Shared Property ConnectionString As String

    ' Encryption entropy
    Private Shared ReadOnly entropy As Byte() = {15, 45, 78, 92, 123}

    ' Form for connection settings
    Private Shared frmConnSettings As New Form()

    ' Controls for connection settings
    Private Shared WithEvents txtServer As New TextBox()
    Private Shared WithEvents txtPort As New TextBox()
    Private Shared WithEvents txtDatabaseName As New TextBox()
    Private Shared WithEvents txtUsername As New TextBox()
    Private Shared WithEvents txtPassword As New TextBox()
    Private Shared WithEvents btnOK As New Button()
    Private Shared WithEvents btnClose As New Button()
    Private Shared WithEvents btnTest As New Button()

    ''' <summary>
    ''' Initialize and test database connection on application startup
    ''' </summary>
    ''' <returns>True if connection successful, False otherwise</returns>
    Public Shared Function Initialize() As Boolean
        ' Load settings from registry
        Dim server As String = CStr(Registry.GetValue(REGISTRY_KEY, SERVER_VALUE, ""))
        Dim port As String = CStr(Registry.GetValue(REGISTRY_KEY, PORT_VALUE, ""))
        Dim db As String = CStr(Registry.GetValue(REGISTRY_KEY, DATABASE_VALUE, ""))
        Dim user As String = CStr(Registry.GetValue(REGISTRY_KEY, USER_VALUE, ""))
        Dim encryptedPass As String = CStr(Registry.GetValue(REGISTRY_KEY, PASSWORD_VALUE, ""))

        ' If essential settings are missing, return false
        If String.IsNullOrWhiteSpace(server) OrElse
           String.IsNullOrWhiteSpace(port) OrElse
           String.IsNullOrWhiteSpace(db) OrElse
           String.IsNullOrWhiteSpace(user) Then
            Return False
        End If

        ' Decrypt password
        Dim password As String = DecryptPassword(encryptedPass)

        ' Build connection string
        Dim loadedConnString As String = $"Server={server};Port={port};Database={db};Uid={user};Pwd={password};CharSet=utf8;"

        ' Test connection silently
        Using testConn As New MySqlConnection(loadedConnString)
            Try
                testConn.Open()
                ConnectionString = loadedConnString
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Get an open database connection
    ''' </summary>
    ''' <returns>Open MySqlConnection or Nothing on failure</returns>
    Public Shared Function GetConnection() As MySqlConnection
        If String.IsNullOrWhiteSpace(ConnectionString) Then
            MessageBox.Show("Database connection has not been initialized. Please configure the connection settings.",
                          "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End If

        Try
            Dim conn As New MySqlConnection(ConnectionString)
            conn.Open()
            Return conn
        Catch ex As Exception
            MessageBox.Show("Error opening database connection: " & ex.Message,
                          "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Show connection settings dialog
    ''' </summary>
    Public Shared Function ShowSettingsDialog() As DialogResult
        LoadFromRegistry()

        ' Create GroupBox
        Dim gbox As New GroupBox()
        gbox.Size = New Size(340, 260)
        gbox.Location = New Point(8, 2)
        gbox.Text = "Database Connection Settings"
        gbox.Font = New Font("Segoe UI", 9, FontStyle.Regular)

        ' Create Labels
        Dim lblServer As New Label()
        Dim lblPort As New Label()
        Dim lblDatabaseName As New Label()
        Dim lblUsername As New Label()
        Dim lblPassword As New Label()

        ' Server Label and TextBox
        With lblServer
            .Text = "Server IP:"
            .Location = New Point(10, 30)
            .AutoSize = True
            .Font = New Font("Segoe UI", 9)
        End With
        With txtServer
            .Location = New Point(100, 27)
            .Size = New Size(220, 23)
            .Font = New Font("Segoe UI", 9)
        End With

        ' Port Label and TextBox
        With lblPort
            .Text = "Port:"
            .Location = New Point(10, 60)
            .AutoSize = True
            .Font = New Font("Segoe UI", 9)
        End With
        With txtPort
            .Location = New Point(100, 57)
            .Size = New Size(220, 23)
            .Font = New Font("Segoe UI", 9)
        End With

        ' Database Label and TextBox
        With lblDatabaseName
            .Text = "Database:"
            .Location = New Point(10, 90)
            .AutoSize = True
            .Font = New Font("Segoe UI", 9)
        End With
        With txtDatabaseName
            .Location = New Point(100, 87)
            .Size = New Size(220, 23)
            .Font = New Font("Segoe UI", 9)
        End With

        ' Username Label and TextBox
        With lblUsername
            .Text = "Username:"
            .Location = New Point(10, 120)
            .AutoSize = True
            .Font = New Font("Segoe UI", 9)
        End With
        With txtUsername
            .Location = New Point(100, 117)
            .Size = New Size(220, 23)
            .Font = New Font("Segoe UI", 9)
        End With

        ' Password Label and TextBox
        With lblPassword
            .Text = "Password:"
            .Location = New Point(10, 150)
            .AutoSize = True
            .Font = New Font("Segoe UI", 9)
        End With
        With txtPassword
            .Location = New Point(100, 147)
            .Size = New Size(220, 23)
            .Font = New Font("Segoe UI", 9)
            .PasswordChar = "●"c
        End With

        ' Test Connection Button
        With btnTest
            .BackColor = Color.FromArgb(52, 152, 219)
            .ForeColor = Color.White
            .Text = "Test Connection"
            .Location = New Point(10, 190)
            .Size = New Size(150, 35)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .Cursor = Cursors.Hand
        End With

        ' OK Button
        With btnOK
            .BackColor = Color.FromArgb(46, 204, 113)
            .ForeColor = Color.White
            .Text = "Save"
            .Location = New Point(170, 190)
            .Size = New Size(75, 35)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .Cursor = Cursors.Hand
        End With

        ' Close Button
        With btnClose
            .BackColor = Color.FromArgb(231, 76, 60)
            .ForeColor = Color.White
            .Text = "Cancel"
            .Location = New Point(250, 190)
            .Size = New Size(75, 35)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .Cursor = Cursors.Hand
        End With

        ' Add controls to GroupBox
        With gbox.Controls
            .Add(lblServer)
            .Add(txtServer)
            .Add(lblPort)
            .Add(txtPort)
            .Add(lblDatabaseName)
            .Add(txtDatabaseName)
            .Add(lblUsername)
            .Add(txtUsername)
            .Add(lblPassword)
            .Add(txtPassword)
            .Add(btnTest)
            .Add(btnOK)
            .Add(btnClose)
        End With

        ' Configure Form
        With frmConnSettings
            .Controls.Clear()
            .Controls.Add(gbox)
            .Size = New Size(370, 310)
            .ControlBox = False
            .Text = "Database Connection Setup"
            .StartPosition = FormStartPosition.CenterScreen
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .Font = New Font("Segoe UI", 9)
            .BackColor = Color.WhiteSmoke
            Return .ShowDialog()
        End With
    End Function

    ''' <summary>
    ''' Test connection button click event
    ''' </summary>
    Private Shared Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        If String.IsNullOrWhiteSpace(txtServer.Text) OrElse
           String.IsNullOrWhiteSpace(txtPort.Text) OrElse
           String.IsNullOrWhiteSpace(txtDatabaseName.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please fill in Server, Port, Database, and Username fields.",
                          "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim testConnString As String = $"Server={txtServer.Text};Port={txtPort.Text};Database={txtDatabaseName.Text};Uid={txtUsername.Text};Pwd={txtPassword.Text};CharSet=utf8;"

        Using testConn As New MySqlConnection(testConnString)
            Try
                Cursor.Current = Cursors.WaitCursor
                testConn.Open()
                MessageBox.Show("Connection successful!" & vbCrLf & vbCrLf &
                              "Server: " & txtServer.Text & vbCrLf &
                              "Database: " & txtDatabaseName.Text,
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As MySqlException
                MessageBox.Show($"Failed to connect to MySQL server:{vbCrLf}{vbCrLf}{ex.Message}",
                              "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Save connection settings
    ''' </summary>
    Private Shared Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If String.IsNullOrWhiteSpace(txtServer.Text) OrElse
           String.IsNullOrWhiteSpace(txtPort.Text) OrElse
           String.IsNullOrWhiteSpace(txtDatabaseName.Text) OrElse
           String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Server, Port, Database, and Username are required.",
                          "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim testConnString As String = $"Server={txtServer.Text};Port={txtPort.Text};Database={txtDatabaseName.Text};Uid={txtUsername.Text};Pwd={txtPassword.Text};CharSet=utf8;"

        Using testConn As New MySqlConnection(testConnString)
            Try
                Cursor.Current = Cursors.WaitCursor
                testConn.Open()
                SaveToRegistry()
                ConnectionString = testConnString
                MessageBox.Show("Connection successful! Settings have been saved.",
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                frmConnSettings.DialogResult = DialogResult.OK
            Catch ex As MySqlException
                MessageBox.Show($"Failed to connect to MySQL server:{vbCrLf}{vbCrLf}{ex.Message}",
                              "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                frmConnSettings.DialogResult = DialogResult.Cancel
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Using
        frmConnSettings.Close()
    End Sub

    ''' <summary>
    ''' Cancel button click event
    ''' </summary>
    Private Shared Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        frmConnSettings.DialogResult = DialogResult.Cancel
        frmConnSettings.Close()
    End Sub

    ''' <summary>
    ''' Save connection details to registry with encrypted password
    ''' </summary>
    Private Shared Sub SaveToRegistry()
        Try
            Registry.SetValue(REGISTRY_KEY, SERVER_VALUE, txtServer.Text, RegistryValueKind.String)
            Registry.SetValue(REGISTRY_KEY, DATABASE_VALUE, txtDatabaseName.Text, RegistryValueKind.String)
            Registry.SetValue(REGISTRY_KEY, USER_VALUE, txtUsername.Text, RegistryValueKind.String)
            Registry.SetValue(REGISTRY_KEY, PORT_VALUE, txtPort.Text, RegistryValueKind.String)

            Dim encryptedPassword As String = EncryptPassword(txtPassword.Text)
            Registry.SetValue(REGISTRY_KEY, PASSWORD_VALUE, encryptedPassword, RegistryValueKind.String)

        Catch ex As Exception
            MessageBox.Show("Failed to save connection details: " & ex.Message,
                          "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load connection details from registry
    ''' </summary>
    Private Shared Sub LoadFromRegistry()
        ' Load from registry, if not found use default values
        Dim serverIP As String = CStr(Registry.GetValue(REGISTRY_KEY, SERVER_VALUE, ""))
        Dim dbName As String = CStr(Registry.GetValue(REGISTRY_KEY, DATABASE_VALUE, ""))
        Dim userName As String = CStr(Registry.GetValue(REGISTRY_KEY, USER_VALUE, ""))
        Dim portNum As String = CStr(Registry.GetValue(REGISTRY_KEY, PORT_VALUE, ""))
        Dim encryptedPass As String = CStr(Registry.GetValue(REGISTRY_KEY, PASSWORD_VALUE, ""))

        ' If registry is empty, use default values
        If String.IsNullOrWhiteSpace(serverIP) Then
            txtServer.Text = "192.168.2.121"
        Else
            txtServer.Text = serverIP
        End If

        If String.IsNullOrWhiteSpace(dbName) Then
            txtDatabaseName.Text = "asset_tracking_system"
        Else
            txtDatabaseName.Text = dbName
        End If

        If String.IsNullOrWhiteSpace(userName) Then
            txtUsername.Text = "root"
        Else
            txtUsername.Text = userName
        End If

        If String.IsNullOrWhiteSpace(portNum) Then
            txtPort.Text = "3306"
        Else
            txtPort.Text = portNum
        End If

        ' Decrypt password if exists, otherwise leave empty
        If Not String.IsNullOrWhiteSpace(encryptedPass) Then
            txtPassword.Text = DecryptPassword(encryptedPass)
        Else
            txtPassword.Text = ""
        End If
    End Sub

#Region "Encryption Methods"
    ''' <summary>
    ''' Encrypt password using ProtectedData
    ''' </summary>
    Private Shared Function EncryptPassword(plainText As String) As String
        If String.IsNullOrEmpty(plainText) Then Return ""
        Try
            Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)
            Dim encryptedBytes As Byte() = ProtectedData.Protect(plainTextBytes, entropy, DataProtectionScope.CurrentUser)
            Return Convert.ToBase64String(encryptedBytes)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Decrypt password using ProtectedData
    ''' </summary>
    Private Shared Function DecryptPassword(encryptedText As String) As String
        If String.IsNullOrEmpty(encryptedText) Then Return ""
        Try
            Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedText)
            Dim plainTextBytes As Byte() = ProtectedData.Unprotect(encryptedBytes, entropy, DataProtectionScope.CurrentUser)
            Return Encoding.UTF8.GetString(plainTextBytes)
        Catch ex As Exception
            Return ""
        End Try
    End Function
#End Region

End Class