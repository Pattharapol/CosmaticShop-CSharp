namespace CosmeticShopApplication.Forms.SaleForms
{
    partial class frmSalePayment
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
            this.btnPayment = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRCB = new System.Windows.Forms.Label();
            this.lblRPB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPayment.FlatAppearance.BorderSize = 0;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Location = new System.Drawing.Point(263, 263);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(110, 59);
            this.btnPayment.TabIndex = 14;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(74, 131);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(299, 30);
            this.txtAmount.TabIndex = 13;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Remaining Current Balance : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Enter Amount : ";
            // 
            // lblRCB
            // 
            this.lblRCB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRCB.Location = new System.Drawing.Point(74, 199);
            this.lblRCB.Name = "lblRCB";
            this.lblRCB.Size = new System.Drawing.Size(299, 49);
            this.lblRCB.TabIndex = 10;
            this.lblRCB.Text = "0.00";
            this.lblRCB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRPB
            // 
            this.lblRPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRPB.Location = new System.Drawing.Point(74, 42);
            this.lblRPB.Name = "lblRPB";
            this.lblRPB.Size = new System.Drawing.Size(299, 43);
            this.lblRPB.TabIndex = 11;
            this.lblRPB.Text = "0.00";
            this.lblRPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Remaining Previous Balance : ";
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // frmSalePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 351);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRCB);
            this.Controls.Add(this.lblRPB);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale Payment";
            this.Load += new System.EventHandler(this.frmSalePayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRCB;
        private System.Windows.Forms.Label lblRPB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider ep;
    }
}