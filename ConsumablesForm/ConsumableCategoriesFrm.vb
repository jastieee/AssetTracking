'----- ConsumableCategoriesFrm.vb -----
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class ConsumableCategoriesFrm
    Private selectedCategoryId As Integer = 0
    Private selectedSubcategoryId As Integer = 0
    Private isEditingCategory As Boolean = False
    Private isEditingSubcategory As Boolean = False

    Private Sub ConsumableCategoriesFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        LoadCategories()
        LoadParentCategories()
        LoadFilterCategories()
    End Sub

    Private Sub InitializeForm()
        ' Style Categories DataGridView
        StyleDataGridView(dgvCategories)
        ' Style Subcategories DataGridView
        StyleDataGridView(dgvSubcategories)

        ' Set initial state
        btnEditCategory.Enabled = False
        btnDeleteCategory.Enabled = False
        btnEditSubcategory.Enabled = False
        btnDeleteSubcategory.Enabled = False
    End Sub

    Private Sub StyleDataGridView(dgv As DataGridView)
        With dgv
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 40
            .EnableHeadersVisualStyles = False

            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.ForeColor = Color.FromArgb(52, 73, 94)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 128, 185)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .RowTemplate.Height = 35
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)

            .GridColor = Color.FromArgb(189, 195, 199)
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        End With
    End Sub

#Region "Categories Management"

    Private Sub LoadCategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    consumable_category_id AS 'ID',
                    category_name AS 'Category Name',
                    description AS 'Description',
                    created_at AS 'Created Date'
                    FROM consumable_categories 
                    ORDER BY category_name"

                Using adapter As New MySqlDataAdapter(query, conn)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    dgvCategories.DataSource = dt

                    If dgvCategories.Columns.Contains("ID") Then
                        dgvCategories.Columns("ID").Visible = False
                    End If

                    If dgvCategories.Columns.Contains("Created Date") Then
                        dgvCategories.Columns("Created Date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                    End If

                    lblCategoryCount.Text = $"Total Categories: {dt.Rows.Count}"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSaveCategory_Click(sender As Object, e As EventArgs) Handles btnSaveCategory.Click
        If Not ValidateCategoryInputs() Then Return

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String
                If isEditingCategory Then
                    query = "UPDATE consumable_categories SET 
                            category_name = @name,
                            description = @description
                            WHERE consumable_category_id = @categoryId"
                Else
                    query = "INSERT INTO consumable_categories (category_name, description)
                            VALUES (@name, @description)"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtCategoryName.Text.Trim())
                    cmd.Parameters.AddWithValue("@description", txtCategoryDescription.Text.Trim())

                    If isEditingCategory Then
                        cmd.Parameters.AddWithValue("@categoryId", selectedCategoryId)
                    End If

                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show(If(isEditingCategory, "Category updated successfully!", "Category created successfully!"),
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LogActivity(gCurrentUserId, If(isEditingCategory, "Category Updated", "Category Created"),
                          "consumable_categories", If(isEditingCategory, selectedCategoryId, 0),
                          $"{If(isEditingCategory, "Updated", "Created")} category: {txtCategoryName.Text.Trim()}")

                ClearCategoryForm()
                LoadCategories()
                LoadParentCategories()
                LoadFilterCategories()
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("A category with this name already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving category: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateCategoryInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtCategoryName.Text) Then
            MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCategoryName.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnClearCategory_Click(sender As Object, e As EventArgs) Handles btnClearCategory.Click
        ClearCategoryForm()
    End Sub

    Private Sub ClearCategoryForm()
        txtCategoryName.Clear()
        txtCategoryDescription.Clear()
        selectedCategoryId = 0
        isEditingCategory = False
        grpCategoryForm.Text = "➕ Add/Edit Category"
        btnSaveCategory.Text = "💾 Save Category"
        btnEditCategory.Enabled = False
        btnDeleteCategory.Enabled = False
    End Sub

    Private Sub dgvCategories_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCategories.SelectionChanged
        If dgvCategories.SelectedRows.Count > 0 Then
            btnEditCategory.Enabled = True
            btnDeleteCategory.Enabled = True
        Else
            btnEditCategory.Enabled = False
            btnDeleteCategory.Enabled = False
        End If
    End Sub

    Private Sub btnEditCategory_Click(sender As Object, e As EventArgs) Handles btnEditCategory.Click
        If dgvCategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a category to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            selectedCategoryId = Convert.ToInt32(dgvCategories.SelectedRows(0).Cells("ID").Value)

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT * FROM consumable_categories WHERE consumable_category_id = @categoryId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@categoryId", selectedCategoryId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtCategoryName.Text = reader("category_name").ToString()
                            txtCategoryDescription.Text = If(IsDBNull(reader("description")), "", reader("description").ToString())

                            isEditingCategory = True
                            grpCategoryForm.Text = "✏️ Edit Category"
                            btnSaveCategory.Text = "💾 Update Category"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading category data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeleteCategory_Click(sender As Object, e As EventArgs) Handles btnDeleteCategory.Click
        If dgvCategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a category to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim categoryId As Integer = Convert.ToInt32(dgvCategories.SelectedRows(0).Cells("ID").Value)
        Dim categoryName As String = dgvCategories.SelectedRows(0).Cells("Category Name").Value.ToString()

        Dim result = MessageBox.Show($"Are you sure you want to delete this category?" & vbCrLf & vbCrLf &
                                    $"Category: {categoryName}" & vbCrLf & vbCrLf &
                                    "This will also delete all subcategories under this category!" & vbCrLf &
                                    "This action cannot be undone!",
                                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                    If conn Is Nothing Then Return

                    ' Check if category is used by consumables
                    Dim checkQuery As String = "SELECT COUNT(*) FROM consumables WHERE category_id = @categoryId"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@categoryId", categoryId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("This category cannot be deleted because it is assigned to consumables.",
                                          "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Delete category (subcategories will be deleted by CASCADE)
                    Dim deleteQuery As String = "DELETE FROM consumable_categories WHERE consumable_category_id = @categoryId"
                    Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@categoryId", categoryId)
                        deleteCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LogActivity(gCurrentUserId, "Category Deleted", "consumable_categories", categoryId,
                              $"Deleted category: {categoryName}")

                    ClearCategoryForm()
                    LoadCategories()
                    LoadParentCategories()
                    LoadFilterCategories()
                    LoadSubcategories()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error deleting category: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnRefreshCategories_Click(sender As Object, e As EventArgs) Handles btnRefreshCategories.Click
        LoadCategories()
        ClearCategoryForm()
    End Sub

#End Region

#Region "Subcategories Management"

    Private Sub LoadParentCategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT consumable_category_id, category_name FROM consumable_categories ORDER BY category_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboParentCategory.Items.Clear()

                        While reader.Read()
                            cboParentCategory.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("consumable_category_id"),
                                reader.GetString("category_name")
                            ))
                        End While
                    End Using
                End Using

                cboParentCategory.DisplayMember = "Value"
                cboParentCategory.ValueMember = "Key"

                If cboParentCategory.Items.Count > 0 Then
                    cboParentCategory.SelectedIndex = 0
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading parent categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadFilterCategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT consumable_category_id, category_name FROM consumable_categories ORDER BY category_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboFilterCategory.Items.Clear()
                        cboFilterCategory.Items.Add(New KeyValuePair(Of Integer, String)(0, "All Categories"))

                        While reader.Read()
                            cboFilterCategory.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("consumable_category_id"),
                                reader.GetString("category_name")
                            ))
                        End While
                    End Using
                End Using

                cboFilterCategory.DisplayMember = "Value"
                cboFilterCategory.ValueMember = "Key"
                cboFilterCategory.SelectedIndex = 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading filter categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSubcategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT 
                    cs.subcategory_id AS 'ID',
                    cc.category_name AS 'Parent Category',
                    cs.subcategory_name AS 'Subcategory Name',
                    cs.description AS 'Description',
                    cs.created_at AS 'Created Date'
                    FROM consumable_subcategories cs
                    INNER JOIN consumable_categories cc ON cs.category_id = cc.consumable_category_id
                    WHERE 1=1"

                If cboFilterCategory.SelectedIndex > 0 Then
                    Dim selectedCategory = DirectCast(cboFilterCategory.SelectedItem, KeyValuePair(Of Integer, String))
                    query &= " AND cs.category_id = @categoryId"
                End If

                query &= " ORDER BY cc.category_name, cs.subcategory_name"

                Using cmd As New MySqlCommand(query, conn)
                    If cboFilterCategory.SelectedIndex > 0 Then
                        Dim selectedCategory = DirectCast(cboFilterCategory.SelectedItem, KeyValuePair(Of Integer, String))
                        cmd.Parameters.AddWithValue("@categoryId", selectedCategory.Key)
                    End If

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        dgvSubcategories.DataSource = dt

                        If dgvSubcategories.Columns.Contains("ID") Then
                            dgvSubcategories.Columns("ID").Visible = False
                        End If

                        If dgvSubcategories.Columns.Contains("Created Date") Then
                            dgvSubcategories.Columns("Created Date").DefaultCellStyle.Format = "yyyy-MM-dd HH:mm"
                        End If

                        lblSubcategoryCount.Text = $"Total Subcategories: {dt.Rows.Count}"
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading subcategories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboFilterCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterCategory.SelectedIndexChanged
        If cboFilterCategory.SelectedIndex <> -1 Then
            LoadSubcategories()
        End If
    End Sub

    Private Sub btnSaveSubcategory_Click(sender As Object, e As EventArgs) Handles btnSaveSubcategory.Click
        If Not ValidateSubcategoryInputs() Then Return

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String
                If isEditingSubcategory Then
                    query = "UPDATE consumable_subcategories SET 
                            category_id = @categoryId,
                            subcategory_name = @name,
                            description = @description
                            WHERE subcategory_id = @subcategoryId"
                Else
                    query = "INSERT INTO consumable_subcategories (category_id, subcategory_name, description)
                            VALUES (@categoryId, @name, @description)"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    Dim selectedCategory = DirectCast(cboParentCategory.SelectedItem, KeyValuePair(Of Integer, String))
                    cmd.Parameters.AddWithValue("@categoryId", selectedCategory.Key)
                    cmd.Parameters.AddWithValue("@name", txtSubcategoryName.Text.Trim())
                    cmd.Parameters.AddWithValue("@description", txtSubcategoryDescription.Text.Trim())

                    If isEditingSubcategory Then
                        cmd.Parameters.AddWithValue("@subcategoryId", selectedSubcategoryId)
                    End If

                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show(If(isEditingSubcategory, "Subcategory updated successfully!", "Subcategory created successfully!"),
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LogActivity(gCurrentUserId, If(isEditingSubcategory, "Subcategory Updated", "Subcategory Created"),
                          "consumable_subcategories", If(isEditingSubcategory, selectedSubcategoryId, 0),
                          $"{If(isEditingSubcategory, "Updated", "Created")} subcategory: {txtSubcategoryName.Text.Trim()} under {DirectCast(cboParentCategory.SelectedItem, KeyValuePair(Of Integer, String)).Value}")

                ClearSubcategoryForm()
                LoadSubcategories()
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("A subcategory with this name already exists in the selected category.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving subcategory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateSubcategoryInputs() As Boolean
        If cboParentCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a parent category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboParentCategory.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtSubcategoryName.Text) Then
            MessageBox.Show("Please enter a subcategory name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSubcategoryName.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnClearSubcategory_Click(sender As Object, e As EventArgs) Handles btnClearSubcategory.Click
        ClearSubcategoryForm()
    End Sub

    Private Sub ClearSubcategoryForm()
        If cboParentCategory.Items.Count > 0 Then
            cboParentCategory.SelectedIndex = 0
        End If
        txtSubcategoryName.Clear()
        txtSubcategoryDescription.Clear()
        selectedSubcategoryId = 0
        isEditingSubcategory = False
        grpSubcategoryForm.Text = "➕ Add/Edit Subcategory"
        btnSaveSubcategory.Text = "💾 Save Subcategory"
        btnEditSubcategory.Enabled = False
        btnDeleteSubcategory.Enabled = False
    End Sub

    Private Sub dgvSubcategories_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSubcategories.SelectionChanged
        If dgvSubcategories.SelectedRows.Count > 0 Then
            btnEditSubcategory.Enabled = True
            btnDeleteSubcategory.Enabled = True
        Else
            btnEditSubcategory.Enabled = False
            btnDeleteSubcategory.Enabled = False
        End If
    End Sub

    Private Sub btnEditSubcategory_Click(sender As Object, e As EventArgs) Handles btnEditSubcategory.Click
        If dgvSubcategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a subcategory to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            selectedSubcategoryId = Convert.ToInt32(dgvSubcategories.SelectedRows(0).Cells("ID").Value)

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT * FROM consumable_subcategories WHERE subcategory_id = @subcategoryId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@subcategoryId", selectedSubcategoryId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim categoryId As Integer = Convert.ToInt32(reader("category_id"))

                            ' Select the parent category
                            For i As Integer = 0 To cboParentCategory.Items.Count - 1
                                Dim item = DirectCast(cboParentCategory.Items(i), KeyValuePair(Of Integer, String))
                                If item.Key = categoryId Then
                                    cboParentCategory.SelectedIndex = i
                                    Exit For
                                End If
                            Next

                            txtSubcategoryName.Text = reader("subcategory_name").ToString()
                            txtSubcategoryDescription.Text = If(IsDBNull(reader("description")), "", reader("description").ToString())

                            isEditingSubcategory = True
                            grpSubcategoryForm.Text = "✏️ Edit Subcategory"
                            btnSaveSubcategory.Text = "💾 Update Subcategory"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading subcategory data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDeleteSubcategory_Click(sender As Object, e As EventArgs) Handles btnDeleteSubcategory.Click
        If dgvSubcategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a subcategory to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                    ' Check if subcategory is used by consumables
                    Dim checkQuery As String = "SELECT COUNT(*) FROM consumables WHERE subcategory_id = @subcategoryId"
                    Using checkCmd As New MySqlCommand(checkQuery, conn)
                        checkCmd.Parameters.AddWithValue("@subcategoryId", subcategoryId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("This subcategory cannot be deleted because it is assigned to consumables.",
                                          "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Delete subcategory
                    Dim deleteQuery As String = "DELETE FROM consumable_subcategories WHERE subcategory_id = @subcategoryId"
                    Using deleteCmd As New MySqlCommand(deleteQuery, conn)
                        deleteCmd.Parameters.AddWithValue("@subcategoryId", subcategoryId)
                        deleteCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Subcategory deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LogActivity(gCurrentUserId, "Subcategory Deleted", "consumable_subcategories", subcategoryId,
                              $"Deleted subcategory: {subcategoryName} from {categoryName}")

                    ClearSubcategoryForm()
                    LoadSubcategories()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error deleting subcategory: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnRefreshSubcategories_Click(sender As Object, e As EventArgs) Handles btnRefreshSubcategories.Click
        LoadSubcategories()
        ClearSubcategoryForm()
    End Sub

    Private Sub tabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControl.SelectedIndexChanged
        If tabControl.SelectedTab Is tabSubcategories Then
            LoadSubcategories()
        End If
    End Sub

#End Region

#Region "Activity Logging"

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

    Private Function GetLocalIPAddress() As String
        Try
            Dim host As String = System.Net.Dns.GetHostName()
            Dim ip As System.Net.IPAddress = System.Net.Dns.GetHostEntry(host).AddressList.FirstOrDefault(Function(x) x.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork)
            If ip IsNot Nothing Then Return ip.ToString()
        Catch ex As Exception
        End Try
        Return "Unknown"
    End Function

#End Region

End Class