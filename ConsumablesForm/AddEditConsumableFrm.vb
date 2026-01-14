'----- AddEditConsumableFrm.vb (Enhanced with Auto-Generated Tags) -----
Imports MySql.Data.MySqlClient

Public Class AddEditConsumableFrm
    Private consumableId As Integer = 0
    Private isEditMode As Boolean = False

    Public Sub New()
        InitializeComponent()
        isEditMode = False
    End Sub

    Public Sub New(id As Integer)
        InitializeComponent()
        consumableId = id
        isEditMode = True
    End Sub

    Private Sub AddEditConsumableFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()

        If isEditMode Then
            lblTitle.Text = "✏️ Edit Consumable"
            btnSave.Text = "💾 Update Consumable"
            LoadConsumableData()
        Else
            lblTitle.Text = "➕ Add Consumable"
            btnSave.Text = "💾 Save Consumable"
            ' Auto-generate code when both category and subcategory are selected
            txtConsumableCode.ReadOnly = True
            txtConsumableCode.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub LoadCategories()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT consumable_category_id, category_name FROM consumable_categories ORDER BY category_name"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboCategory.Items.Clear()

                        While reader.Read()
                            cboCategory.Items.Add(New KeyValuePair(Of Integer, String)(
                                reader.GetInt32("consumable_category_id"),
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
            MessageBox.Show("Error loading categories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        Try
            If cboCategory.SelectedIndex = -1 Then Return

            Dim selectedItem = DirectCast(cboCategory.SelectedItem, KeyValuePair(Of Integer, String))
            Dim categoryId As Integer = selectedItem.Key

            cboSubcategory.Items.Clear()
            cboSubcategory.Enabled = True

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT subcategory_id, subcategory_name FROM consumable_subcategories 
                                      WHERE category_id = @categoryId ORDER BY subcategory_name"

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

            ' Generate code when category changes (in add mode)
            If Not isEditMode Then
                GenerateConsumableCode()
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading subcategories: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboSubcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubcategory.SelectedIndexChanged
        ' Generate code when subcategory changes (in add mode)
        If Not isEditMode AndAlso cboSubcategory.SelectedIndex >= 0 Then
            GenerateConsumableCode()
        End If
    End Sub

    Private Sub GenerateConsumableCode()
        Try
            If cboCategory.SelectedIndex = -1 OrElse cboSubcategory.SelectedIndex = -1 Then
                txtConsumableCode.Text = ""
                Return
            End If

            Dim categoryId As Integer = DirectCast(cboCategory.SelectedItem, KeyValuePair(Of Integer, String)).Key
            Dim subcategoryId As Integer = DirectCast(cboSubcategory.SelectedItem, KeyValuePair(Of Integer, String)).Key

            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                ' Get category and subcategory codes/prefixes
                Dim query As String = "SELECT 
                    cc.category_name,
                    cs.subcategory_name
                    FROM consumable_categories cc
                    INNER JOIN consumable_subcategories cs ON cc.consumable_category_id = cs.category_id
                    WHERE cc.consumable_category_id = @categoryId 
                    AND cs.subcategory_id = @subcategoryId"

                Dim categoryPrefix As String = ""
                Dim subcategoryPrefix As String = ""

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@categoryId", categoryId)
                    cmd.Parameters.AddWithValue("@subcategoryId", subcategoryId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            categoryPrefix = GetCategoryPrefix(reader("category_name").ToString())
                            subcategoryPrefix = GetSubcategoryPrefix(reader("subcategory_name").ToString())
                        End If
                    End Using
                End Using

                ' Get next sequence number for this category-subcategory combination
                Dim countQuery As String = "SELECT COUNT(*) FROM consumables 
                                           WHERE category_id = @categoryId 
                                           AND subcategory_id = @subcategoryId"

                Dim nextNumber As Integer = 1
                Using cmd As New MySqlCommand(countQuery, conn)
                    cmd.Parameters.AddWithValue("@categoryId", categoryId)
                    cmd.Parameters.AddWithValue("@subcategoryId", subcategoryId)
                    nextNumber = Convert.ToInt32(cmd.ExecuteScalar()) + 1
                End Using

                ' Generate the code: PREFIX-NUMBER (e.g., PPR-001, PEN-001, etc.)
                Dim generatedCode As String = $"{subcategoryPrefix}-{nextNumber.ToString("000")}"
                txtConsumableCode.Text = generatedCode

            End Using

        Catch ex As Exception
            MessageBox.Show("Error generating consumable code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetCategoryPrefix(categoryName As String) As String
        ' Map category names to prefixes based on your database
        Select Case categoryName.ToLower()
            Case "office supplies"
                Return "OFF"
            Case "it supplies"
                Return "ITS"
            Case "cleaning supplies"
                Return "CLN"
            Case "printing supplies"
                Return "PRT"
            Case "pantry supplies"
                Return "PAN"
            Case "safety supplies"
                Return "SAF"
            Case Else
                ' Generate from first 3 letters
                Return categoryName.Substring(0, Math.Min(3, categoryName.Length)).ToUpper()
        End Select
    End Function

    Private Function GetSubcategoryPrefix(subcategoryName As String) As String
        ' Map common subcategory names to prefixes based on your database
        Select Case subcategoryName.ToLower()
            Case "paper products"
                Return "PPR"
            Case "writing instruments"
                Return "PEN"
            Case "filing supplies"
                Return "FLD"
            Case "adhesives"
                Return "ADH"
            Case "staplers & clips"
                Return "STP"
            Case "notebooks"
                Return "NTB"
            Case "cables & connectors"
                Return "CBL"
            Case "storage media"
                Return "USB"
            Case "computer accessories"
                Return "ACC"
            Case "adapters"
                Return "ADP"
            Case "batteries"
                Return "BAT"
            Case "disinfectants"
                Return "DIS"
            Case "paper hygiene"
                Return "HYG"
            Case "cleaning solutions"
                Return "CLN"
            Case "cleaning tools"
                Return "CTL"
            Case "ink cartridges"
                Return "INK"
            Case "toner cartridges"
                Return "TNR"
            Case "specialty paper"
                Return "SPP"
            Case "beverages"
                Return "BEV"
            Case "snacks"
                Return "SNK"
            Case "condiments"
                Return "CND"
            Case "disposables"
                Return "DSP"
            Case "first aid"
                Return "AID"
            Case "personal protective equipment"
                Return "PPE"
            Case "emergency supplies"
                Return "EMG"
            Case Else
                ' Generate from first 3 letters
                Dim words = subcategoryName.Split(" "c)
                If words.Length > 1 Then
                    ' Use first letter of each word (up to 3 letters)
                    Return String.Join("", words.Take(3).Select(Function(w) w(0))).ToUpper()
                Else
                    Return subcategoryName.Substring(0, Math.Min(3, subcategoryName.Length)).ToUpper()
                End If
        End Select
    End Function

    Private Sub LoadConsumableData()
        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String = "SELECT * FROM consumables WHERE consumable_id = @consumableId"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@consumableId", consumableId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtConsumableCode.Text = reader("consumable_code").ToString()
                            txtConsumableCode.ReadOnly = True
                            txtConsumableCode.BackColor = Color.LightGray
                            txtConsumableName.Text = reader("consumable_name").ToString()

                            Dim categoryId As Integer = Convert.ToInt32(reader("category_id"))
                            For i As Integer = 0 To cboCategory.Items.Count - 1
                                Dim item = DirectCast(cboCategory.Items(i), KeyValuePair(Of Integer, String))
                                If item.Key = categoryId Then
                                    cboCategory.SelectedIndex = i
                                    Exit For
                                End If
                            Next

                            If Not IsDBNull(reader("subcategory_id")) Then
                                Dim subcategoryId As Integer = Convert.ToInt32(reader("subcategory_id"))
                                For i As Integer = 0 To cboSubcategory.Items.Count - 1
                                    Dim item = DirectCast(cboSubcategory.Items(i), KeyValuePair(Of Integer, String))
                                    If item.Key = subcategoryId Then
                                        cboSubcategory.SelectedIndex = i
                                        Exit For
                                    End If
                                Next
                            End If

                            txtUnitMeasure.Text = reader("unit_of_measure").ToString()
                            nudInitialStock.Value = Convert.ToDecimal(reader("total_quantity_in_stock"))
                            nudInitialStock.ReadOnly = True
                            txtUnitCost.Text = reader("unit_cost").ToString()
                            nudMinStock.Value = Convert.ToDecimal(reader("minimum_stock_level"))
                            nudReorderLevel.Value = Convert.ToDecimal(reader("reorder_level"))
                            txtDescription.Text = reader("description").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading consumable data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then Return

        Try
            Using conn As MySqlConnection = ClsDatabaseConnection.GetConnection()
                If conn Is Nothing Then Return

                Dim query As String
                If isEditMode Then
                    query = "UPDATE consumables SET 
                            consumable_name = @name,
                            category_id = @categoryId,
                            subcategory_id = @subcategoryId,
                            unit_of_measure = @unitMeasure,
                            unit_cost = @unitCost,
                            minimum_stock_level = @minStock,
                            reorder_level = @reorderLevel,
                            description = @description
                            WHERE consumable_id = @consumableId"
                Else
                    query = "INSERT INTO consumables 
                            (consumable_code, consumable_name, category_id, subcategory_id, unit_of_measure, 
                             total_quantity_in_stock, unit_cost, minimum_stock_level, reorder_level, description, created_by)
                            VALUES 
                            (@code, @name, @categoryId, @subcategoryId, @unitMeasure, @initialStock, 
                             @unitCost, @minStock, @reorderLevel, @description, @createdBy)"
                End If

                Using cmd As New MySqlCommand(query, conn)
                    If Not isEditMode Then
                        cmd.Parameters.AddWithValue("@code", txtConsumableCode.Text.Trim())
                        cmd.Parameters.AddWithValue("@initialStock", nudInitialStock.Value)
                        cmd.Parameters.AddWithValue("@createdBy", gCurrentUserId)
                    Else
                        cmd.Parameters.AddWithValue("@consumableId", consumableId)
                    End If

                    cmd.Parameters.AddWithValue("@name", txtConsumableName.Text.Trim())
                    cmd.Parameters.AddWithValue("@categoryId", DirectCast(cboCategory.SelectedItem, KeyValuePair(Of Integer, String)).Key)
                    cmd.Parameters.AddWithValue("@subcategoryId", If(cboSubcategory.SelectedIndex >= 0, DirectCast(cboSubcategory.SelectedItem, KeyValuePair(Of Integer, String)).Key, DBNull.Value))
                    cmd.Parameters.AddWithValue("@unitMeasure", txtUnitMeasure.Text.Trim())
                    cmd.Parameters.AddWithValue("@unitCost", Decimal.Parse(txtUnitCost.Text))
                    cmd.Parameters.AddWithValue("@minStock", nudMinStock.Value)
                    cmd.Parameters.AddWithValue("@reorderLevel", nudReorderLevel.Value)
                    cmd.Parameters.AddWithValue("@description", txtDescription.Text.Trim())

                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show(If(isEditMode, "Consumable updated successfully!", "Consumable added successfully!"),
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("A consumable with this code already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving consumable: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtConsumableCode.Text) Then
            MessageBox.Show("Please ensure a consumable code is generated. Select category and subcategory.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtConsumableName.Text) Then
            MessageBox.Show("Please enter a consumable name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtConsumableName.Focus()
            Return False
        End If

        If cboCategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboCategory.Focus()
            Return False
        End If

        If cboSubcategory.SelectedIndex = -1 Then
            MessageBox.Show("Please select a subcategory.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSubcategory.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtUnitMeasure.Text) Then
            MessageBox.Show("Please enter a unit of measure.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitMeasure.Focus()
            Return False
        End If

        Dim unitCost As Decimal
        If Not Decimal.TryParse(txtUnitCost.Text, unitCost) OrElse unitCost < 0 Then
            MessageBox.Show("Please enter a valid unit cost.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUnitCost.Focus()
            Return False
        End If

        If nudReorderLevel.Value < nudMinStock.Value Then
            MessageBox.Show("Reorder level must be greater than or equal to minimum stock level.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            nudReorderLevel.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class