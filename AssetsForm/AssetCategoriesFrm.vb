Imports MySql.Data.MySqlClient
Imports System.Data

Public Class AssetCategoriesFrm
    ' Track current category/subcategory being edited
    Private currentCategoryId As Integer = 0
    Private currentSubcategoryId As Integer = 0
    Private isEditMode As Boolean = False

    Private Sub AssetCategoriesFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadCategories()
        LoadCategoriesForComboBoxes()
        LoadSubcategories()
    End Sub

    ''' <summary>
    ''' Initialize form settings and styles
    ''' </summary>
    Private Sub InitializeForm()
        ' Style Categories DataGridView
        StyleDataGridView(dgvCategories)

        ' Style Subcategories DataGridView
        StyleDataGridView(dgvSubcategories)

        ' Set initial button states
        btnEditCategory.Enabled = False
        btnDeleteCategory.Enabled = False
        btnEditSubcategory.Enabled = False
        btnDeleteSubcategory.Enabled = False

        ' Initialize filter combo box
        cboFilterCategory.DisplayMember = "Value"
        cboFilterCategory.ValueMember = "Key"
        If cboFilterCategory.Items.Count = 0 Then
            cboFilterCategory.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Categories"))
        End If
        cboFilterCategory.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Style DataGridView
    ''' </summary>
    Private Sub StyleDataGridView(dgv As DataGridView)
        With dgv
            ' Header style
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 40
            .EnableHeadersVisualStyles = False

            ' Row style
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.FromArgb(52, 73, 94)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .RowTemplate.Height = 35
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)

            ' Grid style
            .GridColor = Color.FromArgb(189, 195, 199)
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        End With
    End Sub

#Region "Category Management"

    ''' <summary>
    ''' Load all categories into the DataGridView
    ''' </summary>
    Private Sub LoadCategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    category_id AS 'ID',
                    category_name AS 'Category Name',
                    description AS 'Description',
                    DATE_FORMAT(created_at, '%Y-%m-%d %H:%i') AS 'Created At'
                    FROM asset_categories
                    ORDER BY category_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvCategories.DataSource = dt

                        ' Hide ID column
                        If dgvCategories.Columns.Contains("ID") Then
                            dgvCategories.Columns("ID").Visible = False
                        End If

                        ' Update count
                        lblCategoryCount.Text = $"Total Categories: {dt.Rows.Count}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Save or update category
    ''' </summary>
    Private Sub btnSaveCategory_Click(sender As Object, e As EventArgs) Handles btnSaveCategory.Click
        ' Validate input
        If String.IsNullOrWhiteSpace(txtCategoryName.Text) Then
            MessageBox.Show("Please enter a category name.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryName.Focus()
            Return
        End If

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String
                Dim actionType As String

                If isEditMode AndAlso currentCategoryId > 0 Then
                    ' Update existing category
                    query = "UPDATE asset_categories 
                            SET category_name = @categoryName, 
                                description = @description
                            WHERE category_id = @categoryId"
                    actionType = "Category Updated"
                Else
                    ' Check for duplicate category name
                    Dim checkQuery As String = "SELECT COUNT(*) FROM asset_categories WHERE category_name = @categoryName"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@categoryName", txtCategoryName.Text.Trim())
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("A category with this name already exists.", "Duplicate",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtCategoryName.Focus()
                            Return
                        End If
                    End Using

                    ' Insert new category
                    query = "INSERT INTO asset_categories (category_name, description) 
                            VALUES (@categoryName, @description)"
                    actionType = "Category Created"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@categoryName", txtCategoryName.Text.Trim())
                    cmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(txtCategoryDescription.Text), DBNull.Value, txtCategoryDescription.Text.Trim()))

                    If isEditMode AndAlso currentCategoryId > 0 Then
                        cmd.Parameters.AddWithValue("@categoryId", currentCategoryId)
                    End If

                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Category saved successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Log activity
                    LogActivity(gCurrentUserId, actionType, "asset_categories",
                               If(isEditMode, currentCategoryId, 0),
                               $"Category: {txtCategoryName.Text.Trim()}")

                    ' Refresh and clear
                    LoadCategories()
                    LoadCategoriesForComboBoxes()
                    ClearCategoryForm()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving category: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Clear category form
    ''' </summary>
    Private Sub btnClearCategory_Click(sender As Object, e As EventArgs) Handles btnClearCategory.Click
        ClearCategoryForm()
    End Sub

    Private Sub ClearCategoryForm()
        txtCategoryName.Clear()
        txtCategoryDescription.Clear()
        currentCategoryId = 0
        isEditMode = False
        grpCategoryForm.Text = "➕ Add/Edit Category"
        btnSaveCategory.Text = "💾 Save Category"
        txtCategoryName.Focus()
    End Sub

    ''' <summary>
    ''' Edit selected category
    ''' </summary>
    Private Sub btnEditCategory_Click(sender As Object, e As EventArgs) Handles btnEditCategory.Click
        If dgvCategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a category to edit.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim categoryId As Integer = Convert.ToInt32(dgvCategories.SelectedRows(0).Cells("ID").Value)

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT category_name, description FROM asset_categories WHERE category_id = @categoryId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@categoryId", categoryId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            currentCategoryId = categoryId
                            isEditMode = True
                            txtCategoryName.Text = reader.GetString("category_name")
                            txtCategoryDescription.Text = If(reader.IsDBNull(reader.GetOrdinal("description")), "", reader.GetString("description"))
                            grpCategoryForm.Text = "✏️ Edit Category"
                            btnSaveCategory.Text = "💾 Update Category"
                            txtCategoryName.Focus()
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading category details: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Delete selected category
    ''' </summary>
    Private Sub btnDeleteCategory_Click(sender As Object, e As EventArgs) Handles btnDeleteCategory.Click
        If dgvCategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a category to delete.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim categoryId As Integer = Convert.ToInt32(dgvCategories.SelectedRows(0).Cells("ID").Value)
        Dim categoryName As String = dgvCategories.SelectedRows(0).Cells("Category Name").Value.ToString()

        Dim result = MessageBox.Show($"Are you sure you want to delete this category?" & vbCrLf & vbCrLf &
                                    $"Category: {categoryName}" & vbCrLf & vbCrLf &
                                    "This will also delete all associated subcategories!",
                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    If conn Is Nothing Then Return

                    ' Check if category is being used by assets
                    Dim checkQuery As String = "SELECT COUNT(*) FROM assets WHERE category_id = @categoryId"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@categoryId", categoryId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("This category cannot be deleted because it is being used by existing assets.",
                                          "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Delete category (subcategories will be deleted by CASCADE)
                    Dim deleteQuery As String = "DELETE FROM asset_categories WHERE category_id = @categoryId"
                    Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@categoryId", categoryId)
                        deleteCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Category deleted successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LogActivity(gCurrentUserId, "Category Deleted", "asset_categories", categoryId,
                               $"Deleted category: {categoryName}")

                    LoadCategories()
                    LoadCategoriesForComboBoxes()
                    LoadSubcategories()
                    ClearCategoryForm()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting category: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Refresh categories
    ''' </summary>
    Private Sub btnRefreshCategories_Click(sender As Object, e As EventArgs) Handles btnRefreshCategories.Click
        LoadCategories()
    End Sub

    ''' <summary>
    ''' Enable/disable edit and delete buttons based on selection
    ''' </summary>
    Private Sub dgvCategories_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCategories.SelectionChanged
        Dim hasSelection As Boolean = dgvCategories.SelectedRows.Count > 0
        btnEditCategory.Enabled = hasSelection
        btnDeleteCategory.Enabled = hasSelection
    End Sub

#End Region

#Region "Subcategory Management"

    ''' <summary>
    ''' Load categories for combo boxes
    ''' </summary>
    Private Sub LoadCategoriesForComboBoxes()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT category_id, category_name FROM asset_categories ORDER BY category_name"

                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        ' Load for parent category combo in form
                        cboParentCategory.Items.Clear()

                        ' Load for filter combo
                        cboFilterCategory.Items.Clear()
                        cboFilterCategory.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Categories"))

                        While reader.Read()
                            Dim item As New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("category_id"),
                                reader.GetString("category_name")
                            )
                            cboParentCategory.Items.Add(item)
                            cboFilterCategory.Items.Add(item)
                        End While
                    End Using
                End Using

                cboParentCategory.DisplayMember = "Value"
                cboParentCategory.ValueMember = "Key"

                If cboParentCategory.Items.Count > 0 Then
                    cboParentCategory.SelectedIndex = 0
                End If

                If cboFilterCategory.Items.Count > 0 Then
                    cboFilterCategory.SelectedIndex = 0
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Load subcategories with optional filter
    ''' </summary>
    Private Sub LoadSubcategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    sub.subcategory_id AS 'ID',
                    cat.category_name AS 'Parent Category',
                    sub.subcategory_name AS 'Subcategory Name',
                    sub.description AS 'Description',
                    DATE_FORMAT(sub.created_at, '%Y-%m-%d %H:%i') AS 'Created At'
                    FROM asset_subcategories sub
                    INNER JOIN asset_categories cat ON sub.category_id = cat.category_id"

                ' Apply filter if selected
                If cboFilterCategory.SelectedIndex > 0 Then
                    Dim selectedCategory = DirectCast(cboFilterCategory.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " WHERE sub.category_id = @categoryId"
                End If

                query &= " ORDER BY cat.category_name, sub.subcategory_name"

                Using cmd As New MySqlCommand(query, conn)
                    If cboFilterCategory.SelectedIndex > 0 Then
                        Dim selectedCategory = DirectCast(cboFilterCategory.SelectedItem, KeyValuePair(Of Integer, String))
                        cmd.Parameters.AddWithValue("@categoryId", selectedCategory.Key)
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvSubcategories.DataSource = dt

                        ' Hide ID column
                        If dgvSubcategories.Columns.Contains("ID") Then
                            dgvSubcategories.Columns("ID").Visible = False
                        End If

                        ' Update count
                        lblSubcategoryCount.Text = $"Total Subcategories: {dt.Rows.Count}"
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading subcategories: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Filter subcategories by category
    ''' </summary>
    Private Sub cboFilterCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterCategory.SelectedIndexChanged
        LoadSubcategories()
    End Sub

    ''' <summary>
    ''' Save or update subcategory
    ''' </summary>
    Private Sub btnSaveSubcategory_Click(sender As Object, e As EventArgs) Handles btnSaveSubcategory.Click
        ' Validate input
        If cboParentCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a parent category.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboParentCategory.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtSubcategoryName.Text) Then
            MessageBox.Show("Please enter a subcategory name.", "Validation Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSubcategoryName.Focus()
            Return
        End If

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim selectedCategory = DirectCast(cboParentCategory.SelectedItem, KeyValuePair(Of Integer, String))
                Dim categoryId As Integer = selectedCategory.Key

                Dim query As String
                Dim actionType As String

                If isEditMode AndAlso currentSubcategoryId > 0 Then
                    ' Update existing subcategory
                    query = "UPDATE asset_subcategories 
                            SET category_id = @categoryId,
                                subcategory_name = @subcategoryName, 
                                description = @description
                            WHERE subcategory_id = @subcategoryId"
                    actionType = "Subcategory Updated"
                Else
                    ' Check for duplicate subcategory name within the same category
                    Dim checkQuery As String = "SELECT COUNT(*) FROM asset_subcategories 
                                               WHERE category_id = @categoryId 
                                               AND subcategory_name = @subcategoryName"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@categoryId", categoryId)
                        checkCmd.Parameters.AddWithValue("@subcategoryName", txtSubcategoryName.Text.Trim())
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("A subcategory with this name already exists in this category.", "Duplicate",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSubcategoryName.Focus()
                            Return
                        End If
                    End Using

                    ' Insert new subcategory
                    query = "INSERT INTO asset_subcategories (category_id, subcategory_name, description) 
                            VALUES (@categoryId, @subcategoryName, @description)"
                    actionType = "Subcategory Created"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@categoryId", categoryId)
                    cmd.Parameters.AddWithValue("@subcategoryName", txtSubcategoryName.Text.Trim())
                    cmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(txtSubcategoryDescription.Text), DBNull.Value, txtSubcategoryDescription.Text.Trim()))

                    If isEditMode AndAlso currentSubcategoryId > 0 Then
                        cmd.Parameters.AddWithValue("@subcategoryId", currentSubcategoryId)
                    End If

                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Subcategory saved successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Log activity
                    LogActivity(gCurrentUserId, actionType, "asset_subcategories",
                               If(isEditMode, currentSubcategoryId, 0),
                               $"Subcategory: {txtSubcategoryName.Text.Trim()} under {selectedCategory.Value}")

                    ' Refresh and clear
                    LoadSubcategories()
                    ClearSubcategoryForm()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saving subcategory: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Clear subcategory form
    ''' </summary>
    Private Sub btnClearSubcategory_Click(sender As Object, e As EventArgs) Handles btnClearSubcategory.Click
        ClearSubcategoryForm()
    End Sub

    Private Sub ClearSubcategoryForm()
        If cboParentCategory.Items.Count > 0 Then
            cboParentCategory.SelectedIndex = 0
        End If
        txtSubcategoryName.Clear()
        txtSubcategoryDescription.Clear()
        currentSubcategoryId = 0
        isEditMode = False
        grpSubcategoryForm.Text = "➕ Add/Edit Subcategory"
        btnSaveSubcategory.Text = "💾 Save Subcategory"
        cboParentCategory.Focus()
    End Sub

    ''' <summary>
    ''' Edit selected subcategory
    ''' </summary>
    Private Sub btnEditSubcategory_Click(sender As Object, e As EventArgs) Handles btnEditSubcategory.Click
        If dgvSubcategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a subcategory to edit.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Dim subcategoryId As Integer = Convert.ToInt32(dgvSubcategories.SelectedRows(0).Cells("ID").Value)

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT category_id, subcategory_name, description 
                                      FROM asset_subcategories 
                                      WHERE subcategory_id = @subcategoryId"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@subcategoryId", subcategoryId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            currentSubcategoryId = subcategoryId
                            isEditMode = True

                            ' Select the parent category
                            Dim categoryId As Integer = reader.GetInt32("category_id")
                            For i As Integer = 0 To cboParentCategory.Items.Count - 1
                                Dim item = DirectCast(cboParentCategory.Items(i), KeyValuePair(Of Integer, String))
                                If item.Key = categoryId Then
                                    cboParentCategory.SelectedIndex = i
                                    Exit For
                                End If
                            Next

                            txtSubcategoryName.Text = reader.GetString("subcategory_name")
                            txtSubcategoryDescription.Text = If(reader.IsDBNull(reader.GetOrdinal("description")), "", reader.GetString("description"))
                            grpSubcategoryForm.Text = "✏️ Edit Subcategory"
                            btnSaveSubcategory.Text = "💾 Update Subcategory"
                            txtSubcategoryName.Focus()
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading subcategory details: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Delete selected subcategory
    ''' </summary>
    Private Sub btnDeleteSubcategory_Click(sender As Object, e As EventArgs) Handles btnDeleteSubcategory.Click
        If dgvSubcategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a subcategory to delete.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim subcategoryId As Integer = Convert.ToInt32(dgvSubcategories.SelectedRows(0).Cells("ID").Value)
        Dim subcategoryName As String = dgvSubcategories.SelectedRows(0).Cells("Subcategory Name").Value.ToString()
        Dim categoryName As String = dgvSubcategories.SelectedRows(0).Cells("Parent Category").Value.ToString()

        Dim result = MessageBox.Show($"Are you sure you want to delete this subcategory?" & vbCrLf & vbCrLf &
                                    $"Category: {categoryName}" & vbCrLf &
                                    $"Subcategory: {subcategoryName}" & vbCrLf & vbCrLf &
                                    "This action cannot be undone!",
                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    If conn Is Nothing Then Return

                    ' Check if subcategory is being used by assets
                    Dim checkQuery As String = "SELECT COUNT(*) FROM assets WHERE subcategory_id = @subcategoryId"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@subcategoryId", subcategoryId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("This subcategory cannot be deleted because it is being used by existing assets.",
                                          "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Delete subcategory
                    Dim deleteQuery As String = "DELETE FROM asset_subcategories WHERE subcategory_id = @subcategoryId"
                    Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@subcategoryId", subcategoryId)
                        deleteCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Subcategory deleted successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LogActivity(gCurrentUserId, "Subcategory Deleted", "asset_subcategories", subcategoryId,
                               $"Deleted subcategory: {subcategoryName} from {categoryName}")

                    LoadSubcategories()
                    ClearSubcategoryForm()
                End Using

            Catch ex As Exception
                MessageBox.Show("Error deleting subcategory: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Refresh subcategories
    ''' </summary>
    Private Sub btnRefreshSubcategories_Click(sender As Object, e As EventArgs) Handles btnRefreshSubcategories.Click
        LoadSubcategories()
    End Sub

    ''' <summary>
    ''' Enable/disable edit and delete buttons based on selection
    ''' </summary>
    Private Sub dgvSubcategories_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSubcategories.SelectionChanged
        Dim hasSelection As Boolean = dgvSubcategories.SelectedRows.Count > 0
        btnEditSubcategory.Enabled = hasSelection
        btnDeleteSubcategory.Enabled = hasSelection
    End Sub

#End Region

#Region "Utility Functions"

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

#End Region

End Class