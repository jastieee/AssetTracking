Imports MySql.Data.MySqlClient

Public Class AddEditAssetFrm
    Private assetId As Integer = 0
    Private isEditMode As Boolean = False

    ' Constructor for Add mode
    Public Sub New()
        InitializeComponent()
        isEditMode = False
        lblTitle.Text = "➕ Add Asset"
    End Sub

    ' Constructor for Edit mode
    Public Sub New(assetIdToEdit As Integer)
        InitializeComponent()
        assetId = assetIdToEdit
        isEditMode = True
        lblTitle.Text = "✏️ Edit Asset"
    End Sub

    Private Sub AddEditAssetFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        SetDefaultValues()

        If isEditMode Then
            LoadDepartments()
            LoadAssetData()
        Else
            ' Hide department field for new assets
            lblDepartment.Visible = False
            cboDepartment.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Set default values for new assets
    ''' </summary>
    Private Sub SetDefaultValues()
        If Not isEditMode Then
            ' Set default status and condition
            cboStatus.SelectedIndex = 0 ' In Stock
            cboCondition.SelectedIndex = 1 ' Good
            dtpPurchaseDate.Value = DateTime.Now

            ' Hide department field for new assets (will be assigned during issuance)
            lblDepartment.Visible = False
            cboDepartment.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Load asset categories
    ''' </summary>
    Private Sub LoadCategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT category_id, category_name FROM asset_categories ORDER BY category_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboCategory.Items.Clear()

                        While reader.Read()
                            cboCategory.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("category_id"),
                                reader.GetString("category_name")
                            ))
                        End While
                    End Using
                End Using

                cboCategory.DisplayMember = "Value"
                cboCategory.ValueMember = "Key"

                If cboCategory.Items.Count > 0 Then
                    cboCategory.SelectedIndex = 0
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load subcategories based on selected category
    ''' </summary>
    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        Try
            If cboCategory.SelectedIndex = -1 Then Return

            Dim selectedItem = DirectCast(cboCategory.SelectedItem, KeyValuePair(Of Integer, String))
            Dim categoryId As Integer = selectedItem.Key

            cboSubcategory.Items.Clear()
            cboSubcategory.Enabled = True

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT subcategory_id, subcategory_name 
                                      FROM asset_subcategories 
                                      WHERE category_id = @categoryId 
                                      ORDER BY subcategory_name"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@categoryId", categoryId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cboSubcategory.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("subcategory_id"),
                                reader.GetString("subcategory_name")
                            ))
                        End While
                    End Using
                End Using
            End Using

            cboSubcategory.DisplayMember = "Value"
            cboSubcategory.ValueMember = "Key"

            If cboSubcategory.Items.Count > 0 Then
                cboSubcategory.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading subcategories: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generate asset tag when subcategory changes
    ''' </summary>
    Private Sub cboSubcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubcategory.SelectedIndexChanged
        ' Only auto-generate for new assets, not when editing
        If Not isEditMode AndAlso cboSubcategory.SelectedIndex >= 0 Then
            GenerateAssetTag()
        End If
    End Sub

    ''' <summary>
    ''' Generate asset tag based on subcategory
    ''' </summary>
    Private Sub GenerateAssetTag()
        Try
            If cboSubcategory.SelectedIndex = -1 Then Return

            Dim selectedSubcategory = DirectCast(cboSubcategory.SelectedItem, KeyValuePair(Of Integer, String))
            Dim subcategoryName As String = selectedSubcategory.Value
            Dim subcategoryId As Integer = selectedSubcategory.Key

            ' Generate prefix from subcategory name (first 3 letters, uppercase)
            Dim prefix As String = ""
            Dim words = subcategoryName.Split(" "c)

            If words.Length > 1 Then
                ' Multi-word: take first letter of each word (max 3)
                For i = 0 To Math.Min(words.Length - 1, 2)
                    If words(i).Length > 0 Then
                        prefix &= words(i)(0)
                    End If
                Next
            Else
                ' Single word: take first 3 letters
                prefix = subcategoryName.Substring(0, Math.Min(3, subcategoryName.Length))
            End If

            prefix = prefix.ToUpper()

            ' Get next sequence number for this subcategory
            Dim nextNumber As Integer = GetNextAssetNumber(subcategoryId, prefix)

            ' Generate asset tag: PREFIX + sequence number (3 digits)
            Dim assetTag As String = $"{prefix}{nextNumber:D3}"

            ' Set the asset tag
            txtAssetTag.Text = assetTag
            txtAssetTag.ReadOnly = True ' Make it read-only for auto-generated tags

        Catch ex As Exception
            Debug.WriteLine("Error generating asset tag: " & ex.Message)
            txtAssetTag.ReadOnly = False ' Allow manual entry if generation fails
        End Try
    End Sub

    ''' <summary>
    ''' Get next asset number for subcategory
    ''' </summary>
    Private Function GetNextAssetNumber(subcategoryId As Integer, prefix As String) As Integer
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return 1

                ' Get the highest number for this prefix
                Dim query As String = "SELECT asset_tag FROM assets 
                                      WHERE subcategory_id = @subcategoryId 
                                      AND asset_tag LIKE @prefix 
                                      ORDER BY asset_tag DESC 
                                      LIMIT 1"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@subcategoryId", subcategoryId)
                    cmd.Parameters.AddWithValue("@prefix", prefix & "%")

                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing Then
                        Dim lastTag As String = result.ToString()
                        ' Extract number from tag (remove prefix)
                        Dim numberPart As String = lastTag.Replace(prefix, "")
                        Dim lastNumber As Integer

                        If Integer.TryParse(numberPart, lastNumber) Then
                            Return lastNumber + 1
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error getting next asset number: " & ex.Message)
        End Try

        ' Default to 1 if no previous assets or error
        Return 1
    End Function

    ''' <summary>
    ''' Load departments
    ''' </summary>
    Private Sub LoadDepartments()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT department_id, department_name 
                                      FROM departments 
                                      WHERE status = 'Active'
                                      ORDER BY department_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboDepartment.Items.Clear()

                        While reader.Read()
                            cboDepartment.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("department_id"),
                                reader.GetString("department_name")
                            ))
                        End While
                    End Using
                End Using

                cboDepartment.DisplayMember = "Value"
                cboDepartment.ValueMember = "Key"

                If cboDepartment.Items.Count > 0 Then
                    cboDepartment.SelectedIndex = 0
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load asset data for edit mode
    ''' </summary>
    Private Sub LoadAssetData()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT asset_tag, asset_name, category_id, subcategory_id, 
                                      description, serial_number, model, manufacturer, 
                                      purchase_date, current_department_id, status, condition_status
                                      FROM assets 
                                      WHERE asset_id = @assetId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@assetId", assetId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Basic info
                            txtAssetTag.Text = reader("asset_tag").ToString()
                            txtAssetTag.ReadOnly = True ' Asset tag cannot be changed in edit mode
                            txtAssetName.Text = reader("asset_name").ToString()
                            txtDescription.Text = If(IsDBNull(reader("description")), "", reader("description").ToString())

                            ' Category and Subcategory
                            If Not IsDBNull(reader("category_id")) Then
                                Dim categoryId As Integer = reader.GetInt32("category_id")
                                For i As Integer = 0 To cboCategory.Items.Count - 1
                                    Dim item = DirectCast(cboCategory.Items(i), KeyValuePair(Of Integer, String))
                                    If item.Key = categoryId Then
                                        cboCategory.SelectedIndex = i
                                        Exit For
                                    End If
                                Next

                                ' Wait for subcategories to load, then select
                                If Not IsDBNull(reader("subcategory_id")) Then
                                    Dim subcategoryId As Integer = reader.GetInt32("subcategory_id")
                                    Application.DoEvents() ' Allow subcategories to load
                                    For i As Integer = 0 To cboSubcategory.Items.Count - 1
                                        Dim item = DirectCast(cboSubcategory.Items(i), KeyValuePair(Of Integer, String))
                                        If item.Key = subcategoryId Then
                                            cboSubcategory.SelectedIndex = i
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If

                            ' Status and Condition
                            cboStatus.SelectedItem = reader("status").ToString()
                            cboCondition.SelectedItem = reader("condition_status").ToString()

                            ' Details
                            txtSerialNumber.Text = If(IsDBNull(reader("serial_number")), "", reader("serial_number").ToString())
                            txtModel.Text = If(IsDBNull(reader("model")), "", reader("model").ToString())
                            txtManufacturer.Text = If(IsDBNull(reader("manufacturer")), "", reader("manufacturer").ToString())

                            ' Purchase date
                            If Not IsDBNull(reader("purchase_date")) Then
                                dtpPurchaseDate.Value = reader.GetDateTime("purchase_date")
                            End If

                            ' Department
                            If Not IsDBNull(reader("current_department_id")) Then
                                Dim departmentId As Integer = reader.GetInt32("current_department_id")
                                For i As Integer = 0 To cboDepartment.Items.Count - 1
                                    Dim item = DirectCast(cboDepartment.Items(i), KeyValuePair(Of Integer, String))
                                    If item.Key = departmentId Then
                                        cboDepartment.SelectedIndex = i
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading asset data: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Validate form inputs
    ''' </summary>
    Private Function ValidateInputs() As Boolean
        ' Required fields
        If String.IsNullOrWhiteSpace(txtAssetTag.Text) Then
            MessageBox.Show("Asset Tag is required.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAssetTag.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtAssetName.Text) Then
            MessageBox.Show("Asset Name is required.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAssetName.Focus()
            Return False
        End If

        If cboCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a category.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return False
        End If

        If cboSubcategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a subcategory.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSubcategory.Focus()
            Return False
        End If

        If cboStatus.SelectedIndex = -1 Then
            MessageBox.Show("Please select a status.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboStatus.Focus()
            Return False
        End If

        ' Check for duplicate asset tag (only in add mode or if tag changed)
        If Not isEditMode OrElse Not txtAssetTag.Text.Equals(GetOriginalAssetTag(), StringComparison.OrdinalIgnoreCase) Then
            If AssetTagExists(txtAssetTag.Text) Then
                MessageBox.Show("This Asset Tag already exists. Please use a unique tag.", "Duplicate Asset Tag",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAssetTag.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' Check if asset tag already exists
    ''' </summary>
    Private Function AssetTagExists(assetTag As String) As Boolean
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return False

                Dim query As String = "SELECT COUNT(*) FROM assets WHERE asset_tag = @assetTag AND asset_id != @assetId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@assetTag", assetTag.Trim())
                    cmd.Parameters.AddWithValue("@assetId", assetId)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error checking asset tag: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Get original asset tag (for edit mode validation)
    ''' </summary>
    Private Function GetOriginalAssetTag() As String
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return ""

                Dim query As String = "SELECT asset_tag FROM assets WHERE asset_id = @assetId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@assetId", assetId)
                    Dim result = cmd.ExecuteScalar()
                    Return If(result IsNot Nothing, result.ToString(), "")
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error getting original asset tag: " & ex.Message)
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' Save button click handler
    ''' </summary>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then Return

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String
                If isEditMode Then
                    query = "UPDATE assets SET 
                            asset_tag = @assetTag,
                            asset_name = @assetName,
                            category_id = @categoryId,
                            subcategory_id = @subcategoryId,
                            description = @description,
                            serial_number = @serialNumber,
                            model = @model,
                            manufacturer = @manufacturer,
                            purchase_date = @purchaseDate,
                            current_department_id = @departmentId,
                            status = @status,
                            condition_status = @condition
                            WHERE asset_id = @assetId"
                Else
                    query = "INSERT INTO assets 
                            (asset_tag, asset_name, category_id, subcategory_id, description, 
                             serial_number, model, manufacturer, purchase_date, current_department_id, 
                             status, condition_status, created_by)
                            VALUES 
                            (@assetTag, @assetName, @categoryId, @subcategoryId, @description,
                             @serialNumber, @model, @manufacturer, @purchaseDate, @departmentId,
                             @status, @condition, @createdBy)"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters
                    cmd.Parameters.AddWithValue("@assetTag", txtAssetTag.Text.Trim())
                    cmd.Parameters.AddWithValue("@assetName", txtAssetName.Text.Trim())

                    Dim selectedCategory = DirectCast(cboCategory.SelectedItem, KeyValuePair(Of Integer, String))
                    cmd.Parameters.AddWithValue("@categoryId", selectedCategory.Key)

                    Dim selectedSubcategory = DirectCast(cboSubcategory.SelectedItem, KeyValuePair(Of Integer, String))
                    cmd.Parameters.AddWithValue("@subcategoryId", selectedSubcategory.Key)

                    cmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(txtDescription.Text), DBNull.Value, txtDescription.Text.Trim()))
                    cmd.Parameters.AddWithValue("@serialNumber", If(String.IsNullOrWhiteSpace(txtSerialNumber.Text), DBNull.Value, txtSerialNumber.Text.Trim()))
                    cmd.Parameters.AddWithValue("@model", If(String.IsNullOrWhiteSpace(txtModel.Text), DBNull.Value, txtModel.Text.Trim()))
                    cmd.Parameters.AddWithValue("@manufacturer", If(String.IsNullOrWhiteSpace(txtManufacturer.Text), DBNull.Value, txtManufacturer.Text.Trim()))
                    cmd.Parameters.AddWithValue("@purchaseDate", dtpPurchaseDate.Value.Date)

                    ' Department handling
                    If isEditMode AndAlso cboDepartment.Visible AndAlso cboDepartment.SelectedIndex >= 0 Then
                        Dim selectedDepartment = DirectCast(cboDepartment.SelectedItem, KeyValuePair(Of Integer, String))
                        cmd.Parameters.AddWithValue("@departmentId", selectedDepartment.Key)
                    Else
                        ' For new assets or when department is hidden, set to NULL (unassigned)
                        cmd.Parameters.AddWithValue("@departmentId", DBNull.Value)
                    End If

                    cmd.Parameters.AddWithValue("@status", cboStatus.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@condition", If(cboCondition.SelectedIndex >= 0, cboCondition.SelectedItem.ToString(), "Good"))

                    If isEditMode Then
                        cmd.Parameters.AddWithValue("@assetId", assetId)
                    Else
                        cmd.Parameters.AddWithValue("@createdBy", gCurrentUserId)
                    End If

                    cmd.ExecuteNonQuery()

                    ' Get the asset ID for new assets
                    If Not isEditMode Then
                        assetId = Convert.ToInt32(cmd.LastInsertedId)
                    End If
                End Using

                ' Log activity
                Dim action As String = If(isEditMode, "Asset Updated", "Asset Created")
                LogActivity(gCurrentUserId, action, "assets", assetId,
                           $"{If(isEditMode, "Updated", "Created")} asset: {txtAssetTag.Text} - {txtAssetName.Text}")

                MessageBox.Show($"Asset {If(isEditMode, "updated", "created")} successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.DialogResult = DialogResult.OK
                Me.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error {If(isEditMode, "updating", "creating")} asset: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Cancel button click handler
    ''' </summary>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
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
        End Try
        Return "Unknown"
    End Function
End Class