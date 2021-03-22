namespace CosmeticShopApplication.Forms.PurchaseForms
{
    partial class frmAllPurchases
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.paymentDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvAllPurchase = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.purchaseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseReportToolStripMenuItem,
            this.toolStripSeparator1,
            this.paymentDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 86);
            // 
            // paymentDetailsToolStripMenuItem
            // 
            this.paymentDetailsToolStripMenuItem.Name = "paymentDetailsToolStripMenuItem";
            this.paymentDetailsToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.paymentDetailsToolStripMenuItem.Text = "Payment Details";
            this.paymentDetailsToolStripMenuItem.Click += new System.EventHandler(this.paymentDetailsToolStripMenuItem_Click);
            // 
            // dgvAllPurchase
            // 
            this.dgvAllPurchase.AllowUserToAddRows = false;
            this.dgvAllPurchase.AllowUserToDeleteRows = false;
            this.dgvAllPurchase.AllowUserToResizeColumns = false;
            this.dgvAllPurchase.AllowUserToResizeRows = false;
            this.dgvAllPurchase.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllPurchase.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAllPurchase.Location = new System.Drawing.Point(21, 63);
            this.dgvAllPurchase.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAllPurchase.MultiSelect = false;
            this.dgvAllPurchase.Name = "dgvAllPurchase";
            this.dgvAllPurchase.ReadOnly = true;
            this.dgvAllPurchase.RowHeadersVisible = false;
            this.dgvAllPurchase.RowTemplate.Height = 24;
            this.dgvAllPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllPurchase.Size = new System.Drawing.Size(914, 554);
            this.dgvAllPurchase.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "From Date : ";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd MMMM yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(115, 15);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(206, 30);
            this.dtpFromDate.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(351, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 23);
            this.label2.TabIndex = 35;
            this.label2.Text = "To Date : ";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd MMMM yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(430, 14);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(206, 30);
            this.dtpToDate.TabIndex = 36;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.Teal;
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(671, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(116, 32);
            this.btnFind.TabIndex = 37;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalAmount.Location = new System.Drawing.Point(751, 624);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(184, 43);
            this.lblTotalAmount.TabIndex = 39;
            this.lblTotalAmount.Text = "0.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(497, 631);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 28);
            this.label3.TabIndex = 38;
            this.label3.Text = "Total All Purchases Amount";
            // 
            // purchaseReportToolStripMenuItem
            // 
            this.purchaseReportToolStripMenuItem.Name = "purchaseReportToolStripMenuItem";
            this.purchaseReportToolStripMenuItem.Size = new System.Drawing.Size(185, 24);
            this.purchaseReportToolStripMenuItem.Text = "Purchase Report";
            this.purchaseReportToolStripMenuItem.Click += new System.EventHandler(this.purchaseReportToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // frmAllPurchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 676);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAllPurchase);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAllPurchases";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAllPurchases";
            this.Load += new System.EventHandler(this.frmAllPurchases_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPurchase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem paymentDetailsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvAllPurchase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem purchaseReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}