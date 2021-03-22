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
    public partial class frmPasswordChange : Form
    {
        public frmPasswordChange()
        {
            InitializeComponent();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if(txtOldPassword.Text.Trim().Length == 0)
            {
                ep.SetError(txtOldPassword, "Required missing field...");
                txtOldPassword.Focus();
                return;
            }

            if (txtNewPassword.Text.Trim().Length == 0)
            {
                ep.SetError(txtNewPassword, "Required missing field...");
                txtNewPassword.Focus();
                return;
            }

            if (txtConfirmNewPassword.Text.Trim().Length == 0)
            {
                ep.SetError(txtConfirmNewPassword, "Required missing field...");
                txtConfirmNewPassword.Focus();
                return;
            }

            if(txtNewPassword.Text.Trim() != txtConfirmNewPassword.Text.Trim())
            {
                ep.SetError(txtConfirmNewPassword, "Not Match...");
                txtConfirmNewPassword.Focus();
                txtConfirmNewPassword.SelectAll();
                return;
            }

            if (txtOldPassword.Text.Trim() != UserInfo.Password)
            {
                ep.SetError(txtOldPassword, "Old Passwprd is incorrect...!");
                txtOldPassword.Focus();
                txtOldPassword.SelectAll();
                return;
            }


            string updatepassword = string.Format(@"update EmployeeTable set Password = '{0}' where EmployeeID = '{1}' ", txtNewPassword.Text.Trim(), UserInfo.EmployeeID);
            bool result = DatabasLayer.DatabaseAccess.Update(updatepassword);
            if(result == true)
            {
                MessageBox.Show("Your New Password has been Changed Successfully...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UserInfo.Password = txtNewPassword.Text.Trim();
                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmNewPassword.Clear();
            }
            else
            {
                MessageBox.Show("Some error!! , Please Try Again...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
