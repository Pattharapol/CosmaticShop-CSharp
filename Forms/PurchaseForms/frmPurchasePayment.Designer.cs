namespace CosmeticShopApplication.Forms.PurchaseForms
{
    partial class frmPurchasePayment
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRPB = new System.Windows.Forms.Label();
            this.lblRCB = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.btnPayment = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remaining Prevoius Balance : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enter Payment : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Remaining Current Balance : ";
            // 
            // lblRPB
            // 
            this.lblRPB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRPB.Location = new System.Drawing.Point(124, 75);
            this.lblRPB.Name = "lblRPB";
            this.lblRPB.Size = new System.Drawing.Size(266, 38);
            this.lblRPB.TabIndex = 0;
            this.lblRPB.Text = "0.00";
            this.lblRPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRCB
            // 
            this.lblRCB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRCB.Location = new System.Drawing.Point(124, 241);
            this.lblRCB.Name = "lblRCB";
            this.lblRCB.Size = new System.Drawing.Size(266, 34);
            this.lblRCB.TabIndex = 0;
            this.lblRCB.Text = "0.00";
            this.lblRCB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(124, 148);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(266, 30);
            this.txtPayment.TabIndex = 1;
            this.txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            this.txtPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayment_KeyPress);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnPayment.FlatAppearance.BorderSize = 0;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Location = new System.Drawing.Point(292, 291);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(98, 41);
            this.btnPayment.TabIndex = 7;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // frmPurchasePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 347);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.txtPayment);
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
            this.Name = "frmPurchasePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Payment";
            this.Load += new System.EventHandler(this.frmPurchasePayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRPB;
        private System.Windows.Forms.Label lblRCB;
        private System.Windows.Forms.TextBox txtPayment;
        protected System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.ErrorProvider ep;
    }
}