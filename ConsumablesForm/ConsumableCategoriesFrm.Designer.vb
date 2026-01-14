<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsumableCategoriesFrm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabCategories = New System.Windows.Forms.TabPage()
        Me.splitCategories = New System.Windows.Forms.SplitContainer()
        Me.pnlCategoryForm = New System.Windows.Forms.Panel()
        Me.grpCategoryForm = New System.Windows.Forms.GroupBox()
        Me.pnlCategoryButtons = New System.Windows.Forms.Panel()
        Me.btnClearCategory = New System.Windows.Forms.Button()
        Me.btnSaveCategory = New System.Windows.Forms.Button()
        Me.txtCategoryDescription = New System.Windows.Forms.TextBox()
        Me.lblCategoryDescription = New System.Windows.Forms.Label()
        Me.txtCategoryName = New System.Windows.Forms.TextBox()
        Me.lblCategoryName = New System.Windows.Forms.Label()
        Me.pnlCategoryList = New System.Windows.Forms.Panel()
        Me.dgvCategories = New System.Windows.Forms.DataGridView()
        Me.pnlCategoryActions = New System.Windows.Forms.Panel()
        Me.btnDeleteCategory = New System.Windows.Forms.Button()
        Me.btnEditCategory = New System.Windows.Forms.Button()
        Me.btnRefreshCategories = New System.Windows.Forms.Button()
        Me.lblCategoryCount = New System.Windows.Forms.Label()
        Me.lblCategoriesTitle = New System.Windows.Forms.Label()
        Me.tabSubcategories = New System.Windows.Forms.TabPage()
        Me.splitSubcategories = New System.Windows.Forms.SplitContainer()
        Me.pnlSubcategoryForm = New System.Windows.Forms.Panel()
        Me.grpSubcategoryForm = New System.Windows.Forms.GroupBox()
        Me.pnlSubcategoryButtons = New System.Windows.Forms.Panel()
        Me.btnClearSubcategory = New System.Windows.Forms.Button()
        Me.btnSaveSubcategory = New System.Windows.Forms.Button()
        Me.txtSubcategoryDescription = New System.Windows.Forms.TextBox()
        Me.lblSubcategoryDescription = New System.Windows.Forms.Label()
        Me.txtSubcategoryName = New System.Windows.Forms.TextBox()
        Me.lblSubcategoryName = New System.Windows.Forms.Label()
        Me.cboParentCategory = New System.Windows.Forms.ComboBox()
        Me.lblParentCategory = New System.Windows.Forms.Label()
        Me.lblSubcategoryNote = New System.Windows.Forms.Label()
        Me.pnlSubcategoryList = New System.Windows.Forms.Panel()
        Me.dgvSubcategories = New System.Windows.Forms.DataGridView()
        Me.pnlSubcategoryActions = New System.Windows.Forms.Panel()
        Me.btnDeleteSubcategory = New System.Windows.Forms.Button()
        Me.btnEditSubcategory = New System.Windows.Forms.Button()
        Me.btnRefreshSubcategories = New System.Windows.Forms.Button()
        Me.lblSubcategoryCount = New System.Windows.Forms.Label()
        Me.pnlSubcategoryFilter = New System.Windows.Forms.Panel()
        Me.cboFilterCategory = New System.Windows.Forms.ComboBox()
        Me.lblFilterCategory = New System.Windows.Forms.Label()
        Me.lblSubcategoriesTitle = New System.Windows.Forms.Label()
        Me.pnlTop.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tabCategories.SuspendLayout()
        CType(Me.splitCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitCategories.Panel1.SuspendLayout()
        Me.splitCategories.Panel2.SuspendLayout()
        Me.splitCategories.SuspendLayout()
        Me.pnlCategoryForm.SuspendLayout()
        Me.grpCategoryForm.SuspendLayout()
        Me.pnlCategoryButtons.SuspendLayout()
        Me.pnlCategoryList.SuspendLayout()
        CType(Me.dgvCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategoryActions.SuspendLayout()
        Me.tabSubcategories.SuspendLayout()
        CType(Me.splitSubcategories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitSubcategories.Panel1.SuspendLayout()
        Me.splitSubcategories.Panel2.SuspendLayout()
        Me.splitSubcategories.SuspendLayout()
        Me.pnlSubcategoryForm.SuspendLayout()
        Me.grpSubcategoryForm.SuspendLayout()
        Me.pnlSubcategoryButtons.SuspendLayout()
        Me.pnlSubcategoryList.SuspendLayout()
        CType(Me.dgvSubcategories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSubcategoryActions.SuspendLayout()
        Me.pnlSubcategoryFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.White
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Padding = New System.Windows.Forms.Padding(20, 15, 20, 15)
        Me.pnlTop.Size = New System.Drawing.Size(1200, 70)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(20, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(639, 41)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "📦 Consumable Categories && Subcategories"
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tabCategories)
        Me.tabControl.Controls.Add(Me.tabSubcategories)
        Me.tabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.tabControl.Location = New System.Drawing.Point(0, 70)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(1200, 680)
        Me.tabControl.TabIndex = 1
        '
        'tabCategories
        '
        Me.tabCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.tabCategories.Controls.Add(Me.splitCategories)
        Me.tabCategories.Location = New System.Drawing.Point(4, 32)
        Me.tabCategories.Name = "tabCategories"
        Me.tabCategories.Padding = New System.Windows.Forms.Padding(10)
        Me.tabCategories.Size = New System.Drawing.Size(1192, 644)
        Me.tabCategories.TabIndex = 0
        Me.tabCategories.Text = "📦 Categories"
        '
        'splitCategories
        '
        Me.splitCategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitCategories.Location = New System.Drawing.Point(10, 10)
        Me.splitCategories.Name = "splitCategories"
        '
        'splitCategories.Panel1
        '
        Me.splitCategories.Panel1.Controls.Add(Me.pnlCategoryForm)
        Me.splitCategories.Panel1MinSize = 350
        '
        'splitCategories.Panel2
        '
        Me.splitCategories.Panel2.Controls.Add(Me.pnlCategoryList)
        Me.splitCategories.Panel2MinSize = 500
        Me.splitCategories.Size = New System.Drawing.Size(1172, 624)
        Me.splitCategories.SplitterDistance = 400
        Me.splitCategories.TabIndex = 0
        '
        'pnlCategoryForm
        '
        Me.pnlCategoryForm.BackColor = System.Drawing.Color.White
        Me.pnlCategoryForm.Controls.Add(Me.grpCategoryForm)
        Me.pnlCategoryForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCategoryForm.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategoryForm.Name = "pnlCategoryForm"
        Me.pnlCategoryForm.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlCategoryForm.Size = New System.Drawing.Size(400, 624)
        Me.pnlCategoryForm.TabIndex = 0
        '
        'grpCategoryForm
        '
        Me.grpCategoryForm.Controls.Add(Me.pnlCategoryButtons)
        Me.grpCategoryForm.Controls.Add(Me.txtCategoryDescription)
        Me.grpCategoryForm.Controls.Add(Me.lblCategoryDescription)
        Me.grpCategoryForm.Controls.Add(Me.txtCategoryName)
        Me.grpCategoryForm.Controls.Add(Me.lblCategoryName)
        Me.grpCategoryForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCategoryForm.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpCategoryForm.Location = New System.Drawing.Point(15, 15)
        Me.grpCategoryForm.Name = "grpCategoryForm"
        Me.grpCategoryForm.Padding = New System.Windows.Forms.Padding(15)
        Me.grpCategoryForm.Size = New System.Drawing.Size(370, 594)
        Me.grpCategoryForm.TabIndex = 0
        Me.grpCategoryForm.TabStop = False
        Me.grpCategoryForm.Text = "➕ Add/Edit Category"
        '
        'pnlCategoryButtons
        '
        Me.pnlCategoryButtons.Controls.Add(Me.btnClearCategory)
        Me.pnlCategoryButtons.Controls.Add(Me.btnSaveCategory)
        Me.pnlCategoryButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCategoryButtons.Location = New System.Drawing.Point(15, 524)
        Me.pnlCategoryButtons.Name = "pnlCategoryButtons"
        Me.pnlCategoryButtons.Size = New System.Drawing.Size(340, 55)
        Me.pnlCategoryButtons.TabIndex = 4
        '
        'btnClearCategory
        '
        Me.btnClearCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnClearCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearCategory.FlatAppearance.BorderSize = 0
        Me.btnClearCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearCategory.ForeColor = System.Drawing.Color.White
        Me.btnClearCategory.Location = New System.Drawing.Point(175, 5)
        Me.btnClearCategory.Name = "btnClearCategory"
        Me.btnClearCategory.Size = New System.Drawing.Size(150, 40)
        Me.btnClearCategory.TabIndex = 1
        Me.btnClearCategory.Text = "🔄 Clear"
        Me.btnClearCategory.UseVisualStyleBackColor = False
        '
        'btnSaveCategory
        '
        Me.btnSaveCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnSaveCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveCategory.FlatAppearance.BorderSize = 0
        Me.btnSaveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveCategory.ForeColor = System.Drawing.Color.White
        Me.btnSaveCategory.Location = New System.Drawing.Point(15, 5)
        Me.btnSaveCategory.Name = "btnSaveCategory"
        Me.btnSaveCategory.Size = New System.Drawing.Size(150, 40)
        Me.btnSaveCategory.TabIndex = 0
        Me.btnSaveCategory.Text = "💾 Save Category"
        Me.btnSaveCategory.UseVisualStyleBackColor = False
        '
        'txtCategoryDescription
        '
        Me.txtCategoryDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCategoryDescription.Location = New System.Drawing.Point(15, 125)
        Me.txtCategoryDescription.Multiline = True
        Me.txtCategoryDescription.Name = "txtCategoryDescription"
        Me.txtCategoryDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCategoryDescription.Size = New System.Drawing.Size(340, 80)
        Me.txtCategoryDescription.TabIndex = 3
        '
        'lblCategoryDescription
        '
        Me.lblCategoryDescription.AutoSize = True
        Me.lblCategoryDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategoryDescription.Location = New System.Drawing.Point(15, 100)
        Me.lblCategoryDescription.Name = "lblCategoryDescription"
        Me.lblCategoryDescription.Size = New System.Drawing.Size(88, 20)
        Me.lblCategoryDescription.TabIndex = 2
        Me.lblCategoryDescription.Text = "Description:"
        '
        'txtCategoryName
        '
        Me.txtCategoryName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtCategoryName.Location = New System.Drawing.Point(15, 60)
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.Size = New System.Drawing.Size(340, 27)
        Me.txtCategoryName.TabIndex = 1
        '
        'lblCategoryName
        '
        Me.lblCategoryName.AutoSize = True
        Me.lblCategoryName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategoryName.Location = New System.Drawing.Point(15, 35)
        Me.lblCategoryName.Name = "lblCategoryName"
        Me.lblCategoryName.Size = New System.Drawing.Size(126, 20)
        Me.lblCategoryName.TabIndex = 0
        Me.lblCategoryName.Text = "Category Name: *"
        '
        'pnlCategoryList
        '
        Me.pnlCategoryList.BackColor = System.Drawing.Color.White
        Me.pnlCategoryList.Controls.Add(Me.dgvCategories)
        Me.pnlCategoryList.Controls.Add(Me.pnlCategoryActions)
        Me.pnlCategoryList.Controls.Add(Me.lblCategoriesTitle)
        Me.pnlCategoryList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCategoryList.Location = New System.Drawing.Point(0, 0)
        Me.pnlCategoryList.Name = "pnlCategoryList"
        Me.pnlCategoryList.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlCategoryList.Size = New System.Drawing.Size(768, 624)
        Me.pnlCategoryList.TabIndex = 0
        '
        'dgvCategories
        '
        Me.dgvCategories.AllowUserToAddRows = False
        Me.dgvCategories.AllowUserToDeleteRows = False
        Me.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCategories.BackgroundColor = System.Drawing.Color.White
        Me.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCategories.Location = New System.Drawing.Point(15, 50)
        Me.dgvCategories.Name = "dgvCategories"
        Me.dgvCategories.ReadOnly = True
        Me.dgvCategories.RowHeadersVisible = False
        Me.dgvCategories.RowHeadersWidth = 51
        Me.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCategories.Size = New System.Drawing.Size(738, 484)
        Me.dgvCategories.TabIndex = 2
        '
        'pnlCategoryActions
        '
        Me.pnlCategoryActions.Controls.Add(Me.btnDeleteCategory)
        Me.pnlCategoryActions.Controls.Add(Me.btnEditCategory)
        Me.pnlCategoryActions.Controls.Add(Me.btnRefreshCategories)
        Me.pnlCategoryActions.Controls.Add(Me.lblCategoryCount)
        Me.pnlCategoryActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCategoryActions.Location = New System.Drawing.Point(15, 534)
        Me.pnlCategoryActions.Name = "pnlCategoryActions"
        Me.pnlCategoryActions.Size = New System.Drawing.Size(738, 75)
        Me.pnlCategoryActions.TabIndex = 1
        '
        'btnDeleteCategory
        '
        Me.btnDeleteCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnDeleteCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteCategory.Enabled = False
        Me.btnDeleteCategory.FlatAppearance.BorderSize = 0
        Me.btnDeleteCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteCategory.ForeColor = System.Drawing.Color.White
        Me.btnDeleteCategory.Location = New System.Drawing.Point(165, 15)
        Me.btnDeleteCategory.Name = "btnDeleteCategory"
        Me.btnDeleteCategory.Size = New System.Drawing.Size(140, 40)
        Me.btnDeleteCategory.TabIndex = 3
        Me.btnDeleteCategory.Text = "🗑️ Delete"
        Me.btnDeleteCategory.UseVisualStyleBackColor = False
        '
        'btnEditCategory
        '
        Me.btnEditCategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnEditCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditCategory.Enabled = False
        Me.btnEditCategory.FlatAppearance.BorderSize = 0
        Me.btnEditCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEditCategory.ForeColor = System.Drawing.Color.White
        Me.btnEditCategory.Location = New System.Drawing.Point(15, 15)
        Me.btnEditCategory.Name = "btnEditCategory"
        Me.btnEditCategory.Size = New System.Drawing.Size(140, 40)
        Me.btnEditCategory.TabIndex = 2
        Me.btnEditCategory.Text = "✏️ Edit"
        Me.btnEditCategory.UseVisualStyleBackColor = False
        '
        'btnRefreshCategories
        '
        Me.btnRefreshCategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnRefreshCategories.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefreshCategories.FlatAppearance.BorderSize = 0
        Me.btnRefreshCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefreshCategories.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefreshCategories.ForeColor = System.Drawing.Color.White
        Me.btnRefreshCategories.Location = New System.Drawing.Point(315, 15)
        Me.btnRefreshCategories.Name = "btnRefreshCategories"
        Me.btnRefreshCategories.Size = New System.Drawing.Size(140, 40)
        Me.btnRefreshCategories.TabIndex = 1
        Me.btnRefreshCategories.Text = "🔄 Refresh"
        Me.btnRefreshCategories.UseVisualStyleBackColor = False
        '
        'lblCategoryCount
        '
        Me.lblCategoryCount.AutoSize = True
        Me.lblCategoryCount.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblCategoryCount.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCategoryCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblCategoryCount.Location = New System.Drawing.Point(606, 0)
        Me.lblCategoryCount.Name = "lblCategoryCount"
        Me.lblCategoryCount.Padding = New System.Windows.Forms.Padding(0, 25, 0, 0)
        Me.lblCategoryCount.Size = New System.Drawing.Size(132, 45)
        Me.lblCategoryCount.TabIndex = 0
        Me.lblCategoryCount.Text = "Total Categories: 0"
        Me.lblCategoryCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCategoriesTitle
        '
        Me.lblCategoriesTitle.AutoSize = True
        Me.lblCategoriesTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCategoriesTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblCategoriesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblCategoriesTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblCategoriesTitle.Name = "lblCategoriesTitle"
        Me.lblCategoriesTitle.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblCategoriesTitle.Size = New System.Drawing.Size(208, 35)
        Me.lblCategoriesTitle.TabIndex = 0
        Me.lblCategoriesTitle.Text = "📋 Existing Categories"
        '
        'tabSubcategories
        '
        Me.tabSubcategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.tabSubcategories.Controls.Add(Me.splitSubcategories)
        Me.tabSubcategories.Location = New System.Drawing.Point(4, 32)
        Me.tabSubcategories.Name = "tabSubcategories"
        Me.tabSubcategories.Padding = New System.Windows.Forms.Padding(10)
        Me.tabSubcategories.Size = New System.Drawing.Size(1192, 644)
        Me.tabSubcategories.TabIndex = 1
        Me.tabSubcategories.Text = "📑 Subcategories"
        '
        'splitSubcategories
        '
        Me.splitSubcategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitSubcategories.Location = New System.Drawing.Point(10, 10)
        Me.splitSubcategories.Name = "splitSubcategories"
        '
        'splitSubcategories.Panel1
        '
        Me.splitSubcategories.Panel1.Controls.Add(Me.pnlSubcategoryForm)
        Me.splitSubcategories.Panel1MinSize = 350
        '
        'splitSubcategories.Panel2
        '
        Me.splitSubcategories.Panel2.Controls.Add(Me.pnlSubcategoryList)
        Me.splitSubcategories.Panel2MinSize = 500
        Me.splitSubcategories.Size = New System.Drawing.Size(1172, 624)
        Me.splitSubcategories.SplitterDistance = 400
        Me.splitSubcategories.TabIndex = 0
        '
        'pnlSubcategoryForm
        '
        Me.pnlSubcategoryForm.BackColor = System.Drawing.Color.White
        Me.pnlSubcategoryForm.Controls.Add(Me.grpSubcategoryForm)
        Me.pnlSubcategoryForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSubcategoryForm.Location = New System.Drawing.Point(0, 0)
        Me.pnlSubcategoryForm.Name = "pnlSubcategoryForm"
        Me.pnlSubcategoryForm.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlSubcategoryForm.Size = New System.Drawing.Size(400, 624)
        Me.pnlSubcategoryForm.TabIndex = 0
        '
        'grpSubcategoryForm
        '
        Me.grpSubcategoryForm.Controls.Add(Me.pnlSubcategoryButtons)
        Me.grpSubcategoryForm.Controls.Add(Me.txtSubcategoryDescription)
        Me.grpSubcategoryForm.Controls.Add(Me.lblSubcategoryDescription)
        Me.grpSubcategoryForm.Controls.Add(Me.txtSubcategoryName)
        Me.grpSubcategoryForm.Controls.Add(Me.lblSubcategoryName)
        Me.grpSubcategoryForm.Controls.Add(Me.cboParentCategory)
        Me.grpSubcategoryForm.Controls.Add(Me.lblParentCategory)
        Me.grpSubcategoryForm.Controls.Add(Me.lblSubcategoryNote)
        Me.grpSubcategoryForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpSubcategoryForm.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpSubcategoryForm.Location = New System.Drawing.Point(15, 15)
        Me.grpSubcategoryForm.Name = "grpSubcategoryForm"
        Me.grpSubcategoryForm.Padding = New System.Windows.Forms.Padding(15)
        Me.grpSubcategoryForm.Size = New System.Drawing.Size(370, 594)
        Me.grpSubcategoryForm.TabIndex = 0
        Me.grpSubcategoryForm.TabStop = False
        Me.grpSubcategoryForm.Text = "➕ Add/Edit Subcategory"
        '
        'pnlSubcategoryButtons
        '
        Me.pnlSubcategoryButtons.Controls.Add(Me.btnClearSubcategory)
        Me.pnlSubcategoryButtons.Controls.Add(Me.btnSaveSubcategory)
        Me.pnlSubcategoryButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSubcategoryButtons.Location = New System.Drawing.Point(15, 524)
        Me.pnlSubcategoryButtons.Name = "pnlSubcategoryButtons"
        Me.pnlSubcategoryButtons.Size = New System.Drawing.Size(340, 55)
        Me.pnlSubcategoryButtons.TabIndex = 7
        '
        'btnClearSubcategory
        '
        Me.btnClearSubcategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnClearSubcategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearSubcategory.FlatAppearance.BorderSize = 0
        Me.btnClearSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSubcategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearSubcategory.ForeColor = System.Drawing.Color.White
        Me.btnClearSubcategory.Location = New System.Drawing.Point(175, 5)
        Me.btnClearSubcategory.Name = "btnClearSubcategory"
        Me.btnClearSubcategory.Size = New System.Drawing.Size(150, 40)
        Me.btnClearSubcategory.TabIndex = 1
        Me.btnClearSubcategory.Text = "🔄 Clear"
        Me.btnClearSubcategory.UseVisualStyleBackColor = False
        '
        'btnSaveSubcategory
        '
        Me.btnSaveSubcategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnSaveSubcategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveSubcategory.FlatAppearance.BorderSize = 0
        Me.btnSaveSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveSubcategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveSubcategory.ForeColor = System.Drawing.Color.White
        Me.btnSaveSubcategory.Location = New System.Drawing.Point(15, 5)
        Me.btnSaveSubcategory.Name = "btnSaveSubcategory"
        Me.btnSaveSubcategory.Size = New System.Drawing.Size(150, 40)
        Me.btnSaveSubcategory.TabIndex = 0
        Me.btnSaveSubcategory.Text = "💾 Save Subcategory"
        Me.btnSaveSubcategory.UseVisualStyleBackColor = False
        '
        'txtSubcategoryDescription
        '
        Me.txtSubcategoryDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubcategoryDescription.Location = New System.Drawing.Point(15, 180)
        Me.txtSubcategoryDescription.Multiline = True
        Me.txtSubcategoryDescription.Name = "txtSubcategoryDescription"
        Me.txtSubcategoryDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSubcategoryDescription.Size = New System.Drawing.Size(340, 80)
        Me.txtSubcategoryDescription.TabIndex = 6
        '
        'lblSubcategoryDescription
        '
        Me.lblSubcategoryDescription.AutoSize = True
        Me.lblSubcategoryDescription.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubcategoryDescription.Location = New System.Drawing.Point(15, 155)
        Me.lblSubcategoryDescription.Name = "lblSubcategoryDescription"
        Me.lblSubcategoryDescription.Size = New System.Drawing.Size(88, 20)
        Me.lblSubcategoryDescription.TabIndex = 5
        Me.lblSubcategoryDescription.Text = "Description:"
        '
        'txtSubcategoryName
        '
        Me.txtSubcategoryName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSubcategoryName.Location = New System.Drawing.Point(15, 115)
        Me.txtSubcategoryName.Name = "txtSubcategoryName"
        Me.txtSubcategoryName.Size = New System.Drawing.Size(340, 27)
        Me.txtSubcategoryName.TabIndex = 4
        '
        'lblSubcategoryName
        '
        Me.lblSubcategoryName.AutoSize = True
        Me.lblSubcategoryName.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubcategoryName.Location = New System.Drawing.Point(15, 90)
        Me.lblSubcategoryName.Name = "lblSubcategoryName"
        Me.lblSubcategoryName.Size = New System.Drawing.Size(149, 20)
        Me.lblSubcategoryName.TabIndex = 3
        Me.lblSubcategoryName.Text = "Subcategory Name: *"
        '
        'cboParentCategory
        '
        Me.cboParentCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParentCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboParentCategory.FormattingEnabled = True
        Me.cboParentCategory.Location = New System.Drawing.Point(15, 60)
        Me.cboParentCategory.Name = "cboParentCategory"
        Me.cboParentCategory.Size = New System.Drawing.Size(340, 28)
        Me.cboParentCategory.TabIndex = 2
        '
        'lblParentCategory
        '
        Me.lblParentCategory.AutoSize = True
        Me.lblParentCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblParentCategory.Location = New System.Drawing.Point(15, 35)
        Me.lblParentCategory.Name = "lblParentCategory"
        Me.lblParentCategory.Size = New System.Drawing.Size(127, 20)
        Me.lblParentCategory.TabIndex = 1
        Me.lblParentCategory.Text = "Parent Category: *"
        '
        'lblSubcategoryNote
        '
        Me.lblSubcategoryNote.AutoSize = True
        Me.lblSubcategoryNote.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic)
        Me.lblSubcategoryNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblSubcategoryNote.Location = New System.Drawing.Point(15, 275)
        Me.lblSubcategoryNote.Name = "lblSubcategoryNote"
        Me.lblSubcategoryNote.Size = New System.Drawing.Size(334, 19)
        Me.lblSubcategoryNote.TabIndex = 0
        Me.lblSubcategoryNote.Text = "* Subcategories must be linked to a parent category"
        '
        'pnlSubcategoryList
        '
        Me.pnlSubcategoryList.BackColor = System.Drawing.Color.White
        Me.pnlSubcategoryList.Controls.Add(Me.dgvSubcategories)
        Me.pnlSubcategoryList.Controls.Add(Me.pnlSubcategoryActions)
        Me.pnlSubcategoryList.Controls.Add(Me.pnlSubcategoryFilter)
        Me.pnlSubcategoryList.Controls.Add(Me.lblSubcategoriesTitle)
        Me.pnlSubcategoryList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSubcategoryList.Location = New System.Drawing.Point(0, 0)
        Me.pnlSubcategoryList.Name = "pnlSubcategoryList"
        Me.pnlSubcategoryList.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlSubcategoryList.Size = New System.Drawing.Size(768, 624)
        Me.pnlSubcategoryList.TabIndex = 0
        '
        'dgvSubcategories
        '
        Me.dgvSubcategories.AllowUserToAddRows = False
        Me.dgvSubcategories.AllowUserToDeleteRows = False
        Me.dgvSubcategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSubcategories.BackgroundColor = System.Drawing.Color.White
        Me.dgvSubcategories.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSubcategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubcategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSubcategories.Location = New System.Drawing.Point(15, 110)
        Me.dgvSubcategories.Name = "dgvSubcategories"
        Me.dgvSubcategories.ReadOnly = True
        Me.dgvSubcategories.RowHeadersVisible = False
        Me.dgvSubcategories.RowHeadersWidth = 51
        Me.dgvSubcategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSubcategories.Size = New System.Drawing.Size(738, 424)
        Me.dgvSubcategories.TabIndex = 3
        '
        'pnlSubcategoryActions
        '
        Me.pnlSubcategoryActions.Controls.Add(Me.btnDeleteSubcategory)
        Me.pnlSubcategoryActions.Controls.Add(Me.btnEditSubcategory)
        Me.pnlSubcategoryActions.Controls.Add(Me.btnRefreshSubcategories)
        Me.pnlSubcategoryActions.Controls.Add(Me.lblSubcategoryCount)
        Me.pnlSubcategoryActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSubcategoryActions.Location = New System.Drawing.Point(15, 534)
        Me.pnlSubcategoryActions.Name = "pnlSubcategoryActions"
        Me.pnlSubcategoryActions.Size = New System.Drawing.Size(738, 75)
        Me.pnlSubcategoryActions.TabIndex = 2
        '
        'btnDeleteSubcategory
        '
        Me.btnDeleteSubcategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnDeleteSubcategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDeleteSubcategory.Enabled = False
        Me.btnDeleteSubcategory.FlatAppearance.BorderSize = 0
        Me.btnDeleteSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteSubcategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeleteSubcategory.ForeColor = System.Drawing.Color.White
        Me.btnDeleteSubcategory.Location = New System.Drawing.Point(165, 15)
        Me.btnDeleteSubcategory.Name = "btnDeleteSubcategory"
        Me.btnDeleteSubcategory.Size = New System.Drawing.Size(140, 40)
        Me.btnDeleteSubcategory.TabIndex = 3
        Me.btnDeleteSubcategory.Text = "🗑️ Delete"
        Me.btnDeleteSubcategory.UseVisualStyleBackColor = False
        '
        'btnEditSubcategory
        '
        Me.btnEditSubcategory.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.btnEditSubcategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditSubcategory.Enabled = False
        Me.btnEditSubcategory.FlatAppearance.BorderSize = 0
        Me.btnEditSubcategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditSubcategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnEditSubcategory.ForeColor = System.Drawing.Color.White
        Me.btnEditSubcategory.Location = New System.Drawing.Point(15, 15)
        Me.btnEditSubcategory.Name = "btnEditSubcategory"
        Me.btnEditSubcategory.Size = New System.Drawing.Size(140, 40)
        Me.btnEditSubcategory.TabIndex = 2
        Me.btnEditSubcategory.Text = "✏️ Edit"
        Me.btnEditSubcategory.UseVisualStyleBackColor = False
        '
        'btnRefreshSubcategories
        '
        Me.btnRefreshSubcategories.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnRefreshSubcategories.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefreshSubcategories.FlatAppearance.BorderSize = 0
        Me.btnRefreshSubcategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefreshSubcategories.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefreshSubcategories.ForeColor = System.Drawing.Color.White
        Me.btnRefreshSubcategories.Location = New System.Drawing.Point(315, 15)
        Me.btnRefreshSubcategories.Name = "btnRefreshSubcategories"
        Me.btnRefreshSubcategories.Size = New System.Drawing.Size(140, 40)
        Me.btnRefreshSubcategories.TabIndex = 1
        Me.btnRefreshSubcategories.Text = "🔄 Refresh"
        Me.btnRefreshSubcategories.UseVisualStyleBackColor = False
        '
        'lblSubcategoryCount
        '
        Me.lblSubcategoryCount.AutoSize = True
        Me.lblSubcategoryCount.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblSubcategoryCount.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSubcategoryCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.lblSubcategoryCount.Location = New System.Drawing.Point(583, 0)
        Me.lblSubcategoryCount.Name = "lblSubcategoryCount"
        Me.lblSubcategoryCount.Padding = New System.Windows.Forms.Padding(0, 25, 0, 0)
        Me.lblSubcategoryCount.Size = New System.Drawing.Size(155, 45)
        Me.lblSubcategoryCount.TabIndex = 0
        Me.lblSubcategoryCount.Text = "Total Subcategories: 0"
        Me.lblSubcategoryCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlSubcategoryFilter
        '
        Me.pnlSubcategoryFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.pnlSubcategoryFilter.Controls.Add(Me.cboFilterCategory)
        Me.pnlSubcategoryFilter.Controls.Add(Me.lblFilterCategory)
        Me.pnlSubcategoryFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSubcategoryFilter.Location = New System.Drawing.Point(15, 50)
        Me.pnlSubcategoryFilter.Name = "pnlSubcategoryFilter"
        Me.pnlSubcategoryFilter.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlSubcategoryFilter.Size = New System.Drawing.Size(738, 60)
        Me.pnlSubcategoryFilter.TabIndex = 1
        '
        'cboFilterCategory
        '
        Me.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cboFilterCategory.FormattingEnabled = True
        Me.cboFilterCategory.Items.AddRange(New Object() {"All Categories"})
        Me.cboFilterCategory.Location = New System.Drawing.Point(180, 15)
        Me.cboFilterCategory.Name = "cboFilterCategory"
        Me.cboFilterCategory.Size = New System.Drawing.Size(300, 28)
        Me.cboFilterCategory.TabIndex = 1
        '
        'lblFilterCategory
        '
        Me.lblFilterCategory.AutoSize = True
        Me.lblFilterCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblFilterCategory.Location = New System.Drawing.Point(10, 18)
        Me.lblFilterCategory.Name = "lblFilterCategory"
        Me.lblFilterCategory.Size = New System.Drawing.Size(164, 20)
        Me.lblFilterCategory.TabIndex = 0
        Me.lblFilterCategory.Text = "🔍 Filter by Category:"
        '
        'lblSubcategoriesTitle
        '
        Me.lblSubcategoriesTitle.AutoSize = True
        Me.lblSubcategoriesTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSubcategoriesTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblSubcategoriesTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblSubcategoriesTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblSubcategoriesTitle.Name = "lblSubcategoriesTitle"
        Me.lblSubcategoriesTitle.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblSubcategoriesTitle.Size = New System.Drawing.Size(240, 35)
        Me.lblSubcategoriesTitle.TabIndex = 0
        Me.lblSubcategoriesTitle.Text = "📑 Existing Subcategories"
        '
        'ConsumableCategoriesFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1200, 750)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.pnlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ConsumableCategoriesFrm"
        Me.Text = "Consumable Categories & Subcategories"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.tabCategories.ResumeLayout(False)
        Me.splitCategories.Panel1.ResumeLayout(False)
        Me.splitCategories.Panel2.ResumeLayout(False)
        CType(Me.splitCategories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitCategories.ResumeLayout(False)
        Me.pnlCategoryForm.ResumeLayout(False)
        Me.grpCategoryForm.ResumeLayout(False)
        Me.grpCategoryForm.PerformLayout()
        Me.pnlCategoryButtons.ResumeLayout(False)
        Me.pnlCategoryList.ResumeLayout(False)
        Me.pnlCategoryList.PerformLayout()
        CType(Me.dgvCategories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategoryActions.ResumeLayout(False)
        Me.pnlCategoryActions.PerformLayout()
        Me.tabSubcategories.ResumeLayout(False)
        Me.splitSubcategories.Panel1.ResumeLayout(False)
        Me.splitSubcategories.Panel2.ResumeLayout(False)
        CType(Me.splitSubcategories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitSubcategories.ResumeLayout(False)
        Me.pnlSubcategoryForm.ResumeLayout(False)
        Me.grpSubcategoryForm.ResumeLayout(False)
        Me.grpSubcategoryForm.PerformLayout()
        Me.pnlSubcategoryButtons.ResumeLayout(False)
        Me.pnlSubcategoryList.ResumeLayout(False)
        Me.pnlSubcategoryList.PerformLayout()
        CType(Me.dgvSubcategories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSubcategoryActions.ResumeLayout(False)
        Me.pnlSubcategoryActions.PerformLayout()
        Me.pnlSubcategoryFilter.ResumeLayout(False)
        Me.pnlSubcategoryFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabCategories As TabPage
    Friend WithEvents tabSubcategories As TabPage
    Friend WithEvents splitCategories As SplitContainer
    Friend WithEvents pnlCategoryForm As Panel
    Friend WithEvents grpCategoryForm As GroupBox
    Friend WithEvents txtCategoryName As TextBox
    Friend WithEvents lblCategoryName As Label
    Friend WithEvents txtCategoryDescription As TextBox
    Friend WithEvents lblCategoryDescription As Label
    Friend WithEvents pnlCategoryButtons As Panel
    Friend WithEvents btnSaveCategory As Button
    Friend WithEvents btnClearCategory As Button
    Friend WithEvents pnlCategoryList As Panel
    Friend WithEvents lblCategoriesTitle As Label
    Friend WithEvents dgvCategories As DataGridView
    Friend WithEvents pnlCategoryActions As Panel
    Friend WithEvents btnEditCategory As Button
    Friend WithEvents btnDeleteCategory As Button
    Friend WithEvents btnRefreshCategories As Button
    Friend WithEvents lblCategoryCount As Label
    Friend WithEvents splitSubcategories As SplitContainer
    Friend WithEvents pnlSubcategoryForm As Panel
    Friend WithEvents grpSubcategoryForm As GroupBox
    Friend WithEvents lblSubcategoryNote As Label
    Friend WithEvents cboParentCategory As ComboBox
    Friend WithEvents lblParentCategory As Label
    Friend WithEvents txtSubcategoryName As TextBox
    Friend WithEvents lblSubcategoryName As Label
    Friend WithEvents txtSubcategoryDescription As TextBox
    Friend WithEvents lblSubcategoryDescription As Label
    Friend WithEvents pnlSubcategoryButtons As Panel
    Friend WithEvents btnSaveSubcategory As Button
    Friend WithEvents btnClearSubcategory As Button
    Friend WithEvents pnlSubcategoryList As Panel
    Friend WithEvents lblSubcategoriesTitle As Label
    Friend WithEvents pnlSubcategoryFilter As Panel
    Friend WithEvents cboFilterCategory As ComboBox
    Friend WithEvents lblFilterCategory As Label
    Friend WithEvents dgvSubcategories As DataGridView
    Friend WithEvents pnlSubcategoryActions As Panel
    Friend WithEvents btnEditSubcategory As Button
    Friend WithEvents btnDeleteSubcategory As Button
    Friend WithEvents btnRefreshSubcategories As Button
    Friend WithEvents lblSubcategoryCount As Label
End Class