using CosmaticShopApplication.DatabasLayer;
using CosmaticShopApplication.SourceCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShopApplication.Forms.UserForms
{
    public partial class frmUserLogin : Form
    {
        private HomeForm homeForm;

        public frmUserLogin(HomeForm Formhome)
        {
            InitializeComponent();
            this.homeForm = Formhome;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if(txtUsername.Text.Trim().Length == 0)
            {
                ep.SetError(txtUsername, "Please Enter UserName...");
                txtUsername.Focus();
                return;
            }

            if(txtPassword.Text.Trim().Length == 0)
            {
                ep.SetError(txtPassword, "Please Enter UserName...");
                txtPassword.Focus();
                return;
            }

            DataTable dt = DatabaseAccess.Retrive(string.Format(@"select * from EmployeeTable where username = '{0}' and password = '{1}' ", txtUsername.Text.Trim(), txtPassword.Text.Trim()));
            if(dt != null)
            {
                if(dt.Rows.Count == 1)
                {
                    // preparing data for change password


                    UserInfo.EmployeeID = Convert.ToInt32(dt.Rows[0][0]);
                    UserInfo.UserTypeID = Convert.ToInt32(dt.Rows[0][2]);
                    UserInfo.Email = Convert.ToString(dt.Rows[0][4]);
                    UserInfo.Password = Convert.ToString(dt.Rows[0][10]);


                    lblAlert.Visible = false;
                    MessageBox.Show("Login Successfully!!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    homeForm.Login();
                    this.Close();
                }
                else
                {
                    lblAlert.Visible = true;
                }
            }
            else
            {
                lblAlert.Visible = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            frmForgotPassword frm = new frmForgotPassword();
            frm.ShowDialog();
        }

       
    }
}
