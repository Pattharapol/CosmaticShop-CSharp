namespace CosmaticShopApplication.Forms.EmployeeForms
{
    partial class frmSearchEmployee
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
            this.dgvSearchEmployee = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchEmployee)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSearchEmployee
            // 
            this.dgvSearchEmployee.AllowUserToAddRows = false;
            this.dgvSearchEmployee.AllowUserToDeleteRows = false;
            this.dgvSearchEmployee.AllowUserToOrderColumns = true;
            this.dgvSearchEmployee.AllowUserToResizeColumns = false;
            this.dgvSearchEmployee.AllowUserToResizeRows = false;
            this.dgvSearchEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearchEmployee.BackgroundColor = System.Drawing.Color.White;
            this.dgvSearchEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSearchEmployee.ColumnHeadersVisible = false;
            this.dgvSearchEmployee.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvSearchEmployee.Location = new System.Drawing.Point(18, 91);
            this.dgvSearchEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSearchEmployee.MultiSelect = false;
            this.dgvSearchEmployee.Name = "dgvSearchEmployee";
            this.dgvSearchEmployee.ReadOnly = true;
            this.dgvSearchEmployee.RowHeadersVisible = false;
            this.dgvSearchEmployee.RowTemplate.Height = 24;
            this.dgvSearchEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchEmployee.Size = new System.Drawing.Size(837, 511);
            this.dgvSearchEmployee.TabIndex = 11;
            this.dgvSearchEmployee.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchEmployee_CellContentDoubleClick);
            this.dgvSearchEmployee.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchEmployee_CellDoubleClick);
            this.dgvSearchEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSearchEmployee_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 28);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.selectToolStripMenuItem.Text = "Select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(107, 18);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(600, 27);
            this.txtSearch.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Search : ";
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Location = new System.Drawing.Point(713, 14);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(141, 32);
            this.btnFind.TabIndex = 13;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // frmSearchEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 609);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.dgvSearchEmployee);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSearchEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Employee";
            this.Load += new System.EventHandler(this.frmSearchEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchEmployee)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSearchEmployee;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
    }
}