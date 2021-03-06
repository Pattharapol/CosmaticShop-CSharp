namespace CosmeticShopApplication.Forms.PurchaseForms
{
    partial class frmNewPurchase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnADD = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSaleUnitPrice = new System.Windows.Forms.TextBox();
            this.txtPurchaseUnitPrice = new System.Windows.Forms.TextBox();
            this.txtPurchaseQty = new System.Windows.Forms.TextBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblItemCost = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCurrentSaleUnitPrice = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurrentPurchaseUnitPrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCurrentQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPurchaseCart = new System.Windows.Forms.DataGridView();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label15 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.chkIsPaymentSucceed = new System.Windows.Forms.CheckBox();
            this.btnPurchaseCancel = new System.Windows.Forms.Button();
            this.btnPurchaseConfirm = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseCart)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.lblContactNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblSupplierName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(33, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1319, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Supplier";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(39, 69);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(235, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblContactNo
            // 
            this.lblContactNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblContactNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(734, 69);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(235, 30);
            this.lblContactNo.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(730, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Contact No";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSupplierName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.Location = new System.Drawing.Point(328, 69);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(361, 30);
            this.lblSupplierName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Supplier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Supplier";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnADD);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.txtSaleUnitPrice);
            this.groupBox2.Controls.Add(this.txtPurchaseUnitPrice);
            this.groupBox2.Controls.Add(this.txtPurchaseQty);
            this.groupBox2.Controls.Add(this.cmbProduct);
            this.groupBox2.Controls.Add(this.cmbCategory);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblItemCost);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(33, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 388);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Products";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(285, 348);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(190, 348);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 30);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnADD
            // 
            this.btnADD.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnADD.FlatAppearance.BorderSize = 0;
            this.btnADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnADD.ForeColor = System.Drawing.Color.White;
            this.btnADD.Location = new System.Drawing.Point(193, 348);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(86, 30);
            this.btnADD.TabIndex = 6;
            this.btnADD.Text = "Add";
            this.btnADD.UseVisualStyleBackColor = false;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(285, 348);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 30);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtSaleUnitPrice
            // 
            this.txtSaleUnitPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaleUnitPrice.Location = new System.Drawing.Point(128, 242);
            this.txtSaleUnitPrice.Name = "txtSaleUnitPrice";
            this.txtSaleUnitPrice.Size = new System.Drawing.Size(216, 30);
            this.txtSaleUnitPrice.TabIndex = 1;
            this.txtSaleUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaleUnitPrice_KeyPress);
            // 
            // txtPurchaseUnitPrice
            // 
            this.txtPurchaseUnitPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseUnitPrice.Location = new System.Drawing.Point(128, 188);
            this.txtPurchaseUnitPrice.Name = "txtPurchaseUnitPrice";
            this.txtPurchaseUnitPrice.Size = new System.Drawing.Size(216, 30);
            this.txtPurchaseUnitPrice.TabIndex = 1;
            this.txtPurchaseUnitPrice.TextChanged += new System.EventHandler(this.txtPurchaseUnitPrice_TextChanged);
            this.txtPurchaseUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseUnitPrice_KeyPress);
            // 
            // txtPurchaseQty
            // 
            this.txtPurchaseQty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchaseQty.Location = new System.Drawing.Point(128, 134);
            this.txtPurchaseQty.Name = "txtPurchaseQty";
            this.txtPurchaseQty.Size = new System.Drawing.Size(216, 30);
            this.txtPurchaseQty.TabIndex = 1;
            this.txtPurchaseQty.TextChanged += new System.EventHandler(this.txtPurchaseQty_TextChanged);
            this.txtPurchaseQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseQty_KeyPress);
            // 
            // cmbProduct
            // 
            this.cmbProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(128, 83);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(216, 27);
            this.cmbProduct.TabIndex = 1;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(128, 32);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(216, 27);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 304);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "Item Cost";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 241);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 38);
            this.label13.TabIndex = 0;
            this.label13.Text = "Sale \r\nUnit Price";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(35, 185);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 38);
            this.label12.TabIndex = 0;
            this.label12.Text = "Purchase \r\nUnit Price";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Purchase Qty";
            // 
            // lblItemCost
            // 
            this.lblItemCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemCost.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCost.Location = new System.Drawing.Point(128, 296);
            this.lblItemCost.Name = "lblItemCost";
            this.lblItemCost.Size = new System.Drawing.Size(216, 30);
            this.lblItemCost.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(53, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Product";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Category";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCurrentSaleUnitPrice);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblCurrentPurchaseUnitPrice);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblCurrentQty);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(33, 545);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 178);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Product Status";
            // 
            // lblCurrentSaleUnitPrice
            // 
            this.lblCurrentSaleUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentSaleUnitPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSaleUnitPrice.Location = new System.Drawing.Point(173, 139);
            this.lblCurrentSaleUnitPrice.Name = "lblCurrentSaleUnitPrice";
            this.lblCurrentSaleUnitPrice.Size = new System.Drawing.Size(202, 30);
            this.lblCurrentSaleUnitPrice.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sale Unit Price";
            // 
            // lblCurrentPurchaseUnitPrice
            // 
            this.lblCurrentPurchaseUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentPurchaseUnitPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPurchaseUnitPrice.Location = new System.Drawing.Point(173, 87);
            this.lblCurrentPurchaseUnitPrice.Name = "lblCurrentPurchaseUnitPrice";
            this.lblCurrentPurchaseUnitPrice.Size = new System.Drawing.Size(202, 30);
            this.lblCurrentPurchaseUnitPrice.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 38);
            this.label6.TabIndex = 0;
            this.label6.Text = "Current \r\nPurchase Price";
            // 
            // lblCurrentQty
            // 
            this.lblCurrentQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentQty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentQty.Location = new System.Drawing.Point(173, 35);
            this.lblCurrentQty.Name = "lblCurrentQty";
            this.lblCurrentQty.Size = new System.Drawing.Size(202, 30);
            this.lblCurrentQty.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current Qty";
            // 
            // dgvPurchaseCart
            // 
            this.dgvPurchaseCart.AllowUserToAddRows = false;
            this.dgvPurchaseCart.AllowUserToDeleteRows = false;
            this.dgvPurchaseCart.AllowUserToResizeColumns = false;
            this.dgvPurchaseCart.AllowUserToResizeRows = false;
            this.dgvPurchaseCart.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvPurchaseCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductID,
            this.colProduct,
            this.colCategoryID,
            this.colCategory,
            this.colQty,
            this.colPurchaseUnitPrice,
            this.colSaleUnitPrice,
            this.colItemCost});
            this.dgvPurchaseCart.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPurchaseCart.Location = new System.Drawing.Point(450, 173);
            this.dgvPurchaseCart.MultiSelect = false;
            this.dgvPurchaseCart.Name = "dgvPurchaseCart";
            this.dgvPurchaseCart.ReadOnly = true;
            this.dgvPurchaseCart.RowHeadersVisible = false;
            this.dgvPurchaseCart.RowTemplate.Height = 24;
            this.dgvPurchaseCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseCart.Size = new System.Drawing.Size(902, 464);
            this.dgvPurchaseCart.TabIndex = 2;
            // 
            // colProductID
            // 
            this.colProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProductID.HeaderText = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colProductID.Visible = false;
            // 
            // colProduct
            // 
            this.colProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProduct.HeaderText = "ProductName";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            this.colProduct.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colCategoryID
            // 
            this.colCategoryID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCategoryID.HeaderText = "CategoryID";
            this.colCategoryID.Name = "colCategoryID";
            this.colCategoryID.ReadOnly = true;
            this.colCategoryID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCategoryID.Visible = false;
            // 
            // colCategory
            // 
            this.colCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCategory.Width = 105;
            // 
            // colQty
            // 
            this.colQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            this.colQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colQty.Width = 63;
            // 
            // colPurchaseUnitPrice
            // 
            this.colPurchaseUnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPurchaseUnitPrice.HeaderText = "PurchaseUnitPrice";
            this.colPurchaseUnitPrice.Name = "colPurchaseUnitPrice";
            this.colPurchaseUnitPrice.ReadOnly = true;
            this.colPurchaseUnitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPurchaseUnitPrice.Width = 175;
            // 
            // colSaleUnitPrice
            // 
            this.colSaleUnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSaleUnitPrice.HeaderText = "SaleUnitPrice";
            this.colSaleUnitPrice.Name = "colSaleUnitPrice";
            this.colSaleUnitPrice.ReadOnly = true;
            this.colSaleUnitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSaleUnitPrice.Width = 137;
            // 
            // colItemCost
            // 
            this.colItemCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colItemCost.HeaderText = "ItemCost";
            this.colItemCost.Name = "colItemCost";
            this.colItemCost.ReadOnly = true;
            this.colItemCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colItemCost.Width = 102;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 52);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(446, 151);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 19);
            this.label15.TabIndex = 0;
            this.label15.Text = "Purchase Cart";
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(449, 655);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 19);
            this.label17.TabIndex = 0;
            this.label17.Text = "Total Cost :";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalCost.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCost.Location = new System.Drawing.Point(544, 650);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(202, 30);
            this.lblTotalCost.TabIndex = 0;
            // 
            // chkIsPaymentSucceed
            // 
            this.chkIsPaymentSucceed.AutoSize = true;
            this.chkIsPaymentSucceed.Checked = true;
            this.chkIsPaymentSucceed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsPaymentSucceed.Location = new System.Drawing.Point(554, 683);
            this.chkIsPaymentSucceed.Name = "chkIsPaymentSucceed";
            this.chkIsPaymentSucceed.Size = new System.Drawing.Size(192, 23);
            this.chkIsPaymentSucceed.TabIndex = 3;
            this.chkIsPaymentSucceed.Text = "Is Payment Succeed?";
            this.chkIsPaymentSucceed.UseVisualStyleBackColor = true;
            // 
            // btnPurchaseCancel
            // 
            this.btnPurchaseCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPurchaseCancel.FlatAppearance.BorderSize = 0;
            this.btnPurchaseCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseCancel.ForeColor = System.Drawing.Color.White;
            this.btnPurchaseCancel.Location = new System.Drawing.Point(767, 673);
            this.btnPurchaseCancel.Name = "btnPurchaseCancel";
            this.btnPurchaseCancel.Size = new System.Drawing.Size(152, 68);
            this.btnPurchaseCancel.TabIndex = 6;
            this.btnPurchaseCancel.Text = "Cancel";
            this.btnPurchaseCancel.UseVisualStyleBackColor = false;
            this.btnPurchaseCancel.Click += new System.EventHandler(this.btnPurchaseCancel_Click);
            // 
            // btnPurchaseConfirm
            // 
            this.btnPurchaseConfirm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPurchaseConfirm.FlatAppearance.BorderSize = 0;
            this.btnPurchaseConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseConfirm.ForeColor = System.Drawing.Color.White;
            this.btnPurchaseConfirm.Location = new System.Drawing.Point(1200, 673);
            this.btnPurchaseConfirm.Name = "btnPurchaseConfirm";
            this.btnPurchaseConfirm.Size = new System.Drawing.Size(152, 68);
            this.btnPurchaseConfirm.TabIndex = 4;
            this.btnPurchaseConfirm.Text = "Purchase \r\n Confirm";
            this.btnPurchaseConfirm.UseVisualStyleBackColor = false;
            this.btnPurchaseConfirm.Click += new System.EventHandler(this.btnPurchaseConfirm_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(925, 650);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Purchase comments : ";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(929, 673);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(265, 68);
            this.txtComments.TabIndex = 7;
            // 
            // frmNewPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 786);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.btnPurchaseConfirm);
            this.Controls.Add(this.chkIsPaymentSucceed);
            this.Controls.Add(this.btnPurchaseCancel);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvPurchaseCart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmNewPurchase";
            this.Text = "New Purchase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNewPurchase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseCart)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblSupplierName;
        public System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label lblCurrentSaleUnitPrice;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblCurrentPurchaseUnitPrice;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblCurrentQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label lblItemCost;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.TextBox txtSaleUnitPrice;
        private System.Windows.Forms.TextBox txtPurchaseUnitPrice;
        private System.Windows.Forms.TextBox txtPurchaseQty;
        private System.Windows.Forms.DataGridView dgvPurchaseCart;
        private System.Windows.Forms.Label label15;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnUpdate;
        protected System.Windows.Forms.Button btnADD;
        protected System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkIsPaymentSucceed;
        public System.Windows.Forms.Label lblTotalCost;
        protected System.Windows.Forms.Button btnPurchaseConfirm;
        protected System.Windows.Forms.Button btnPurchaseCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtComments;
    }
}