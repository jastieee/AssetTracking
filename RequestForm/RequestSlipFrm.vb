Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Public Class RequestSlipFrm
    ' Request properties
    Private currentUserId As Integer
    Private currentEmployeeId As Integer
    Private requestType As String ' "Asset" or "Consumable"
    Private requestedItems As New DataTable()
    Private requestNumber As String

    ' Constructor
    Public Sub New(userId As Integer, employeeId As Integer, reqType As String)
        InitializeComponent()

        currentUserId = userId
        currentEmployeeId = employeeId
        requestType = reqType

        InitializeForm()
    End Sub

    Private Sub InitializeForm()
        ' Set form title based on request type
        If requestType = "Asset" Then
            lblFormTitle.Text = "📝 New Asset Request"
            lblSlipTitle.Text = "ASSET REQUEST SLIP"
        Else
            lblFormTitle.Text = "📝 New Consumable Request"
            lblSlipTitle.Text = "CONSUMABLE REQUEST SLIP"
        End If

        ' Generate request number
        requestNumber = GenerateRequestNumber()
        lblRequestNumber.Text = $"Request No: {requestNumber}"

        ' Set current date
        lblRequestDate.Text = $"Date: {DateTime.Now.ToString("MMMM dd, yyyy")}"

        ' Set default priority
        cmbPriority.SelectedIndex = 1 ' Medium

        ' Load employee information
        LoadEmployeeInfo()

        ' Initialize DataTable for requested items
        InitializeItemsDataTable()

        ' Setup DataGridView
        SetupDataGridView()
    End Sub

    'Private Sub AddViewRequestsButton()
    '    ' Create a button to view request status
    '    Dim btnViewRequests As New Button()
    '    btnViewRequests.Text = "📋 View My Requests"
    '    btnViewRequests.Size = New Size(150, 35)
    '    btnViewRequests.Location = New Point(Me.Width - 170, 10) ' Top right
    '    btnViewRequests.BackColor = Color.FromArgb(41, 128, 185)
    '    btnViewRequests.ForeColor = Color.White
    '    btnViewRequests.FlatStyle = FlatStyle.Flat
    '    btnViewRequests.FlatAppearance.BorderSize = 0
    '    btnViewRequests.Font = New Font("Segoe UI", 9, FontStyle.Regular)
    '    btnViewRequests.Cursor = Cursors.Hand

    '    ' Add click handler
    '    AddHandler btnViewRequests.Click, AddressOf btnViewRequests_Click

    '    ' Add to form
    '    Me.Controls.Add(btnViewRequests)
    '    btnViewRequests.BringToFront()
    'End Sub

    'Private Sub btnViewRequests_Click(sender As Object, e As EventArgs)
    '    ' Create and show status form as a child panel
    '    Dim statusForm As New RequestStatusFrm(currentUserId, requestType)
    '    statusForm.TopLevel = False
    '    statusForm.FormBorderStyle = FormBorderStyle.None
    '    statusForm.Dock = DockStyle.Fill

    '    ' Create overlay panel
    '    Dim overlay As New Panel()
    '    overlay.BackColor = Color.White
    '    overlay.Dock = DockStyle.Fill
    '    overlay.Controls.Add(statusForm)

    '    ' Add close button to overlay
    '    Dim btnCloseOverlay As New Button()
    '    btnCloseOverlay.Text = "✕ Close"
    '    btnCloseOverlay.Size = New Size(100, 35)
    '    btnCloseOverlay.Location = New Point(overlay.Width - 120, 10)
    '    btnCloseOverlay.BackColor = Color.FromArgb(231, 76, 60)
    '    btnCloseOverlay.ForeColor = Color.White
    '    btnCloseOverlay.FlatStyle = FlatStyle.Flat
    '    btnCloseOverlay.FlatAppearance.BorderSize = 0
    '    btnCloseOverlay.Anchor = AnchorStyles.Top Or AnchorStyles.Right
    '    btnCloseOverlay.Cursor = Cursors.Hand

    '    AddHandler btnCloseOverlay.Click, Sub()
    '                                          Me.Controls.Remove(overlay)
    '                                          overlay.Dispose()
    '                                      End Sub

    '    overlay.Controls.Add(btnCloseOverlay)
    '    btnCloseOverlay.BringToFront()

    '    ' Add overlay to form
    '    Me.Controls.Add(overlay)
    '    overlay.BringToFront()

    '    ' Show status form
    '    statusForm.Show()
    'End Sub
    Private Function GenerateRequestNumber() As String
        Dim prefix As String = If(requestType = "Asset", "AR", "CR")
        Dim year As String = DateTime.Now.Year.ToString()
        Dim sequence As String = GetNextSequenceNumber().ToString("D4")
        Return $"{prefix}-{year}-{sequence}"
    End Function

    Private Function GetNextSequenceNumber() As Integer
        Dim sequence As Integer = 1
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()


                Dim tableName As String = If(requestType = "Asset", "asset_requests", "consumable_requests")
                ' FIXED: MySQL uses IFNULL instead of ISNULL
                Dim query As String = $"SELECT IFNULL(MAX(request_id), 0) + 1 FROM {tableName}"

                Using cmd As New MySqlCommand(query, conn)
                    sequence = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error generating sequence: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return sequence
    End Function

    Private Sub LoadEmployeeInfo()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()


                ' FIXED: MySQL uses IFNULL, not ISNULL, and CONCAT works differently
                Dim query As String = "SELECT e.employee_number, CONCAT(e.first_name, ' ', IFNULL(e.middle_name, ''), ' ', e.last_name) AS full_name, " &
                                    "ep.position_name, d.department_name, d.department_code " &
                                    "FROM employees e " &
                                    "INNER JOIN employee_positions ep ON e.position_id = ep.position_id " &
                                    "INNER JOIN departments d ON e.department_id = d.department_id " &
                                    "WHERE e.employee_id = @employeeId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId)

                    ' FIXED: Changed SqlDataReader to MySqlDataReader
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblEmployeeNumValue.Text = reader("employee_number").ToString()
                            lblEmployeeNameValue.Text = reader("full_name").ToString()
                            lblPositionValue.Text = reader("position_name").ToString()
                            lblDepartmentValue.Text = $"{reader("department_name")} ({reader("department_code")})"
                            lblCompanyName.Text = "[YOUR COMPANY NAME]"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading employee info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeItemsDataTable()
        If requestType = "Asset" Then
            requestedItems.Columns.Add("ItemID", GetType(Integer))
            requestedItems.Columns.Add("Asset Tag", GetType(String))
            requestedItems.Columns.Add("Asset Name", GetType(String))
            requestedItems.Columns.Add("Category", GetType(String))
            requestedItems.Columns.Add("Quantity", GetType(Integer))
            requestedItems.Columns.Add("Specifications", GetType(String))
        Else
            requestedItems.Columns.Add("ItemID", GetType(Integer))
            requestedItems.Columns.Add("Consumable Code", GetType(String))
            requestedItems.Columns.Add("Consumable Name", GetType(String))
            requestedItems.Columns.Add("Category", GetType(String))
            requestedItems.Columns.Add("Unit", GetType(String))
            requestedItems.Columns.Add("Quantity", GetType(Integer))
        End If

        dgvRequestedItems.DataSource = requestedItems
    End Sub

    Private Sub SetupDataGridView()
        With dgvRequestedItems
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False

            ' Hide ItemID column
            If .Columns.Count > 0 Then
                .Columns(0).Visible = False
            End If

            ' Style headers
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .ColumnHeadersHeight = 35

            ' Alternating row colors
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)
        End With
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If requestType = "Asset" Then
            ShowAssetSelectionDialog()
        Else
            ShowConsumableSelectionDialog()
        End If
    End Sub

    Private Sub ShowAssetSelectionDialog()
        ' Create a dialog to select assets
        Dim selectForm As New Form()
        selectForm.Text = "Select Asset"
        selectForm.Size = New Size(800, 600)
        selectForm.StartPosition = FormStartPosition.CenterParent
        selectForm.FormBorderStyle = FormBorderStyle.FixedDialog
        selectForm.MaximizeBox = False
        selectForm.MinimizeBox = False

        ' DataGridView for assets
        Dim dgvAssets As New DataGridView()
        dgvAssets.Dock = DockStyle.Fill
        dgvAssets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAssets.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAssets.MultiSelect = False
        dgvAssets.ReadOnly = True
        dgvAssets.AllowUserToAddRows = False

        ' Panel for controls
        Dim pnlControls As New Panel()
        pnlControls.Dock = DockStyle.Bottom
        pnlControls.Height = 100

        ' Quantity input
        Dim lblQty As New Label()
        lblQty.Text = "Quantity:"
        lblQty.Location = New Point(20, 20)
        lblQty.AutoSize = True

        Dim numQty As New NumericUpDown()
        numQty.Location = New Point(100, 18)
        numQty.Width = 100
        numQty.Minimum = 1
        numQty.Maximum = 100
        numQty.Value = 1

        ' Specifications input
        Dim lblSpecs As New Label()
        lblSpecs.Text = "Specs:"
        lblSpecs.Location = New Point(220, 20)
        lblSpecs.AutoSize = True

        Dim txtSpecs As New TextBox()
        txtSpecs.Location = New Point(280, 18)
        txtSpecs.Width = 300

        ' Buttons
        Dim btnAdd As New Button()
        btnAdd.Text = "Add"
        btnAdd.Location = New Point(500, 60)
        btnAdd.Size = New Size(100, 30)
        btnAdd.BackColor = Color.FromArgb(39, 174, 96)
        btnAdd.ForeColor = Color.White
        btnAdd.FlatStyle = FlatStyle.Flat

        Dim btnCancelDialog As New Button()
        btnCancelDialog.Text = "Cancel"
        btnCancelDialog.Location = New Point(610, 60)
        btnCancelDialog.Size = New Size(100, 30)
        btnCancelDialog.BackColor = Color.FromArgb(231, 76, 60)
        btnCancelDialog.ForeColor = Color.White
        btnCancelDialog.FlatStyle = FlatStyle.Flat

        ' Add controls
        pnlControls.Controls.AddRange({lblQty, numQty, lblSpecs, txtSpecs, btnAdd, btnCancelDialog})
        selectForm.Controls.Add(dgvAssets)
        selectForm.Controls.Add(pnlControls)

        ' Load available assets
        LoadAvailableAssets(dgvAssets)

        ' Button events
        AddHandler btnAdd.Click, Sub()
                                     If dgvAssets.SelectedRows.Count > 0 Then
                                         Dim row As DataGridViewRow = dgvAssets.SelectedRows(0)
                                         requestedItems.Rows.Add(
                                             row.Cells("asset_id").Value,
                                             row.Cells("asset_tag").Value,
                                             row.Cells("asset_name").Value,
                                             row.Cells("category_name").Value,
                                             numQty.Value,
                                             txtSpecs.Text
                                         )
                                         selectForm.Close()
                                     End If
                                 End Sub

        AddHandler btnCancelDialog.Click, Sub() selectForm.Close()

        selectForm.ShowDialog()
    End Sub

    Private Sub ShowConsumableSelectionDialog()
        ' Similar to ShowAssetSelectionDialog but for consumables
        Dim selectForm As New Form()
        selectForm.Text = "Select Consumable"
        selectForm.Size = New Size(800, 600)
        selectForm.StartPosition = FormStartPosition.CenterParent
        selectForm.FormBorderStyle = FormBorderStyle.FixedDialog
        selectForm.MaximizeBox = False
        selectForm.MinimizeBox = False

        Dim dgvConsumables As New DataGridView()
        dgvConsumables.Dock = DockStyle.Fill
        dgvConsumables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvConsumables.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvConsumables.MultiSelect = False
        dgvConsumables.ReadOnly = True
        dgvConsumables.AllowUserToAddRows = False

        Dim pnlControls As New Panel()
        pnlControls.Dock = DockStyle.Bottom
        pnlControls.Height = 80

        Dim lblQty As New Label()
        lblQty.Text = "Quantity:"
        lblQty.Location = New Point(20, 20)
        lblQty.AutoSize = True

        Dim numQty As New NumericUpDown()
        numQty.Location = New Point(100, 18)
        numQty.Width = 100
        numQty.Minimum = 1
        numQty.Maximum = 10000
        numQty.Value = 1

        Dim btnAdd As New Button()
        btnAdd.Text = "Add"
        btnAdd.Location = New Point(500, 40)
        btnAdd.Size = New Size(100, 30)
        btnAdd.BackColor = Color.FromArgb(39, 174, 96)
        btnAdd.ForeColor = Color.White
        btnAdd.FlatStyle = FlatStyle.Flat

        Dim btnCancelDialog As New Button()
        btnCancelDialog.Text = "Cancel"
        btnCancelDialog.Location = New Point(610, 40)
        btnCancelDialog.Size = New Size(100, 30)
        btnCancelDialog.BackColor = Color.FromArgb(231, 76, 60)
        btnCancelDialog.ForeColor = Color.White
        btnCancelDialog.FlatStyle = FlatStyle.Flat

        pnlControls.Controls.AddRange({lblQty, numQty, btnAdd, btnCancelDialog})
        selectForm.Controls.Add(dgvConsumables)
        selectForm.Controls.Add(pnlControls)

        LoadAvailableConsumables(dgvConsumables)

        AddHandler btnAdd.Click, Sub()
                                     If dgvConsumables.SelectedRows.Count > 0 Then
                                         Dim row As DataGridViewRow = dgvConsumables.SelectedRows(0)
                                         requestedItems.Rows.Add(
                                             row.Cells("consumable_id").Value,
                                             row.Cells("consumable_code").Value,
                                             row.Cells("consumable_name").Value,
                                             row.Cells("category_name").Value,
                                             row.Cells("unit_of_measure").Value,
                                             numQty.Value
                                         )
                                         selectForm.Close()
                                     End If
                                 End Sub

        AddHandler btnCancelDialog.Click, Sub() selectForm.Close()

        selectForm.ShowDialog()
    End Sub

    Private Sub LoadAvailableAssets(dgv As DataGridView)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()


                Dim query As String = "SELECT a.asset_id, a.asset_tag, a.asset_name, ac.category_name, a.status " &
                                    "FROM assets a " &
                                    "LEFT JOIN asset_categories ac ON a.category_id = ac.category_id " &
                                    "WHERE a.status = 'In Stock' " &
                                    "ORDER BY a.asset_name"

                Using adapter As New MySqlDataAdapter(query, conn)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgv.DataSource = dt

                    ' Hide ID column
                    If dgv.Columns.Count > 0 Then
                        dgv.Columns("asset_id").Visible = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading assets: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAvailableConsumables(dgv As DataGridView)
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()


                Dim query As String = "SELECT c.consumable_id, c.consumable_code, c.consumable_name, " &
                                    "cc.category_name, c.unit_of_measure, c.total_quantity_in_stock " &
                                    "FROM consumables c " &
                                    "LEFT JOIN consumable_categories cc ON c.category_id = cc.consumable_category_id " &
                                    "WHERE c.total_quantity_in_stock > 0 " &
                                    "ORDER BY c.consumable_name"

                Using adapter As New MySqlDataAdapter(query, conn)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgv.DataSource = dt

                    If dgv.Columns.Count > 0 Then
                        dgv.Columns("consumable_id").Visible = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading consumables: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If dgvRequestedItems.SelectedRows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Remove selected item?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                dgvRequestedItems.Rows.Remove(dgvRequestedItems.SelectedRows(0))
            End If
        Else
            MessageBox.Show("Please select an item to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If ValidateRequest() Then
            If SubmitRequest() Then
                MessageBox.Show("Request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Function ValidateRequest() As Boolean
        If String.IsNullOrWhiteSpace(txtReason.Text) Then
            MessageBox.Show("Please provide a reason for this request.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtReason.Focus()
            Return False
        End If

        If requestedItems.Rows.Count = 0 Then
            MessageBox.Show("Please add at least one item to the request.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbPriority.SelectedIndex = -1 Then
            MessageBox.Show("Please select a priority level.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbPriority.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function SubmitRequest() As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()


                ' FIXED: Changed SqlTransaction to MySqlTransaction
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        For Each row As DataRow In requestedItems.Rows
                            If requestType = "Asset" Then
                                InsertAssetRequest(conn, transaction, row)
                            Else
                                InsertConsumableRequest(conn, transaction, row)
                            End If
                        Next

                        transaction.Commit()
                        Return True
                    Catch ex As Exception
                        transaction.Rollback()
                        Throw ex
                    End Try
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error submitting request: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' FIXED: Changed SqlConnection and SqlTransaction to MySqlConnection and MySqlTransaction
    Private Sub InsertAssetRequest(conn As MySqlConnection, transaction As MySqlTransaction, row As DataRow)
        Dim query As String = "INSERT INTO asset_requests (asset_id, requested_by, quantity, reason, purpose, priority, status) " &
                            "VALUES (@assetId, @requestedBy, @quantity, @reason, @purpose, @priority, 'Pending')"

        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@assetId", row("ItemID"))
            cmd.Parameters.AddWithValue("@requestedBy", currentUserId)
            cmd.Parameters.AddWithValue("@quantity", row("Quantity"))
            cmd.Parameters.AddWithValue("@reason", txtReason.Text)
            cmd.Parameters.AddWithValue("@purpose", If(String.IsNullOrWhiteSpace(txtPurpose.Text), DBNull.Value, CType(txtPurpose.Text, Object)))
            cmd.Parameters.AddWithValue("@priority", cmbPriority.SelectedItem.ToString())
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' FIXED: Changed SqlConnection and SqlTransaction to MySqlConnection and MySqlTransaction
    Private Sub InsertConsumableRequest(conn As MySqlConnection, transaction As MySqlTransaction, row As DataRow)
        ' Get department_id for the employee
        Dim deptId As Integer = GetEmployeeDepartmentId(conn, transaction)

        Dim query As String = "INSERT INTO consumable_requests (consumable_id, department_id, requested_by, " &
                            "quantity_requested, reason, purpose, priority, status) " &
                            "VALUES (@consumableId, @deptId, @requestedBy, @quantity, @reason, @purpose, @priority, 'Pending')"

        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@consumableId", row("ItemID"))
            cmd.Parameters.AddWithValue("@deptId", deptId)
            cmd.Parameters.AddWithValue("@requestedBy", currentUserId)
            cmd.Parameters.AddWithValue("@quantity", row("Quantity"))
            cmd.Parameters.AddWithValue("@reason", txtReason.Text)
            cmd.Parameters.AddWithValue("@purpose", If(String.IsNullOrWhiteSpace(txtPurpose.Text), DBNull.Value, CType(txtPurpose.Text, Object)))
            cmd.Parameters.AddWithValue("@priority", cmbPriority.SelectedItem.ToString())
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' FIXED: Changed SqlConnection and SqlTransaction to MySqlConnection and MySqlTransaction
    Private Function GetEmployeeDepartmentId(conn As MySqlConnection, transaction As MySqlTransaction) As Integer
        Dim query As String = "SELECT department_id FROM employees WHERE employee_id = @employeeId"
        Using cmd As New MySqlCommand(query, conn, transaction)
            cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel this request?",
                                                    "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        btnCancel_Click(sender, e)
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintRequestSlip()
    End Sub

    Private Sub PrintRequestSlip()
        Try
            Dim printDoc As New PrintDocument()
            AddHandler printDoc.PrintPage, AddressOf PrintPage

            Dim printDialog As New PrintDialog()
            printDialog.Document = printDoc

            If printDialog.ShowDialog() = DialogResult.OK Then
                printDoc.Print()
            End If
        Catch ex As Exception
            MessageBox.Show($"Error printing: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim font As New Font("Segoe UI", 10)
        Dim boldFont As New Font("Segoe UI", 10, FontStyle.Bold)
        Dim titleFont As New Font("Segoe UI", 16, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim lineHeight As Integer = 25

        ' Title
        e.Graphics.DrawString(lblSlipTitle.Text, titleFont, brush, x, y)
        y += 40

        ' Company Name
        e.Graphics.DrawString(lblCompanyName.Text, boldFont, brush, x, y)
        y += lineHeight

        ' Request Number and Date
        e.Graphics.DrawString(lblRequestNumber.Text, font, brush, x, y)
        e.Graphics.DrawString(lblRequestDate.Text, font, brush, 500, y)
        y += lineHeight * 2

        ' Requester Information
        e.Graphics.DrawString("REQUESTER INFORMATION", boldFont, brush, x, y)
        y += lineHeight
        e.Graphics.DrawString($"Employee No: {lblEmployeeNumValue.Text}", font, brush, x + 20, y)
        e.Graphics.DrawString($"Name: {lblEmployeeNameValue.Text}", font, brush, x + 250, y)
        y += lineHeight
        e.Graphics.DrawString($"Position: {lblPositionValue.Text}", font, brush, x + 20, y)
        e.Graphics.DrawString($"Department: {lblDepartmentValue.Text}", font, brush, x + 250, y)
        y += lineHeight * 2

        ' Request Information
        e.Graphics.DrawString("REQUEST INFORMATION", boldFont, brush, x, y)
        y += lineHeight
        e.Graphics.DrawString($"Reason: {txtReason.Text}", font, brush, x + 20, y)
        y += lineHeight
        If Not String.IsNullOrWhiteSpace(txtPurpose.Text) Then
            e.Graphics.DrawString($"Purpose: {txtPurpose.Text}", font, brush, x + 20, y)
            y += lineHeight
        End If
        e.Graphics.DrawString($"Priority: {cmbPriority.SelectedItem}", font, brush, x + 20, y)
        y += lineHeight * 2

        ' Items
        e.Graphics.DrawString("REQUESTED ITEMS", boldFont, brush, x, y)
        y += lineHeight

        For Each row As DataRow In requestedItems.Rows
            If requestType = "Asset" Then
                e.Graphics.DrawString($"- {row("Asset Tag")} | {row("Asset Name")} | Qty: {row("Quantity")}", font, brush, x + 20, y)
            Else
                e.Graphics.DrawString($"- {row("Consumable Code")} | {row("Consumable Name")} | Qty: {row("Quantity")} {row("Unit")}", font, brush, x + 20, y)
            End If
            y += lineHeight
        Next

        y += lineHeight * 2

        ' Signatures
        e.Graphics.DrawString("_________________________", font, brush, x, y)
        e.Graphics.DrawString("_________________________", font, brush, 400, y)
        y += lineHeight
        e.Graphics.DrawString("Requested By", font, brush, x + 20, y)
        e.Graphics.DrawString("Approved By", font, brush, 420, y)
    End Sub

End Class