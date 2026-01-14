Imports System.Windows.Forms
Imports System.Threading

Module Main
    ''' <summary>
    ''' Main entry point for the Asset Tracking System
    ''' </summary>
    <STAThread()>
    Sub Main()
        ' Enable visual styles
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        ' Show splash screen
        Dim splash As New frmSplash()
        splash.Show()
        Application.DoEvents()

        ' Start the loading animation
        splash.StartLoading()

        ' Simulate initialization process with progress updates
        Dim initSuccess As Boolean = InitializeApplication(splash)

        ' Complete loading
        splash.CompleteLoading()
        Thread.Sleep(500) ' Brief pause to show 100%

        ' Close splash screen
        splash.Close()

        ' If initialization failed, show connection settings dialog
        If Not initSuccess Then
            MessageBox.Show("Unable to connect to the database." & vbCrLf & vbCrLf &
                          "Please configure the database connection settings.",
                          "Database Connection Required",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Warning)

            ' Show connection settings dialog
            Dim result As DialogResult = ClsDatabaseConnection.ShowSettingsDialog()

            ' If user cancelled or connection still fails, exit application
            If result = DialogResult.Cancel Then
                MessageBox.Show("Database connection is required to run the application.",
                              "Application Exit",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information)
                Application.Exit()
                Return
            End If
        End If

        ' Connection successful, show login form
        Dim loginForm As New loginFrm()
        If loginForm.ShowDialog() = DialogResult.OK Then
            ' Login successful, show main form
            Application.Run(New mainFrm())
        Else
            ' Login cancelled or failed
            Application.Exit()
        End If
    End Sub

    ''' <summary>
    ''' Initialize application with progress updates
    ''' </summary>
    Private Function InitializeApplication(splash As frmSplash) As Boolean
        Try
            ' Step 1: Initialize system (0-20%)
            splash.UpdateStatus("Initializing system...")
            Thread.Sleep(300)
            For i As Integer = 0 To 20
                splash.SetProgress(i)
                Thread.Sleep(20)
                Application.DoEvents()
            Next

            ' Step 2: Load database connection (21-40%)
            splash.UpdateStatus("Loading database connection...")
            Thread.Sleep(200)
            For i As Integer = 21 To 40
                splash.SetProgress(i)
                Thread.Sleep(25)
                Application.DoEvents()
            Next

            ' Try to connect to database
            Dim isConnected As Boolean = ClsDatabaseConnection.Initialize()

            If Not isConnected Then
                ' If connection fails, still show progress but will return false
                For i As Integer = 41 To 100
                    splash.SetProgress(i)
                    Thread.Sleep(10)
                    Application.DoEvents()
                Next
                Return False
            End If

            ' Step 3: Verify credentials system (41-60%)
            splash.UpdateStatus("Verifying user credentials system...")
            Thread.Sleep(200)
            For i As Integer = 41 To 60
                splash.SetProgress(i)
                Thread.Sleep(25)
                Application.DoEvents()
            Next

            ' Step 4: Load application modules (61-80%)
            splash.UpdateStatus("Loading application modules...")
            Thread.Sleep(300)
            For i As Integer = 61 To 80
                splash.SetProgress(i)
                Thread.Sleep(20)
                Application.DoEvents()
            Next

            ' Step 5: Finalize setup (81-95%)
            splash.UpdateStatus("Finalizing setup...")
            Thread.Sleep(200)
            For i As Integer = 81 To 95
                splash.SetProgress(i)
                Thread.Sleep(15)
                Application.DoEvents()
            Next

            ' Step 6: Ready (96-100%)
            splash.UpdateStatus("Ready! Starting application...")
            For i As Integer = 96 To 100
                splash.SetProgress(i)
                Thread.Sleep(30)
                Application.DoEvents()
            Next

            Return True

        Catch ex As Exception
            MessageBox.Show("Error during initialization: " & ex.Message,
                          "Initialization Error",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Module