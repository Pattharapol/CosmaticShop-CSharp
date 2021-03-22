using CosmaticShopApplication.DatabasLayer;
using CosmaticShopApplication.Forms.EmployeeForms;
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
    public partial class frmCreateUser : Form
    {
        public int EmployeeID = 0;

        public frmCreateUser()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmSearchEmployee frm = new frmSearchEmployee(txtSearch.Text.Trim(), this);
            frm.ShowDialog();
        }

        private void frmCreateUser_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (EmployeeID == 0)
                {
                    ep.SetError(btnFind, "Please Find Employee First...!");
                    txtSearch.Focus();
                    return;
                }

                if (txtUserName.Text.Trim().Length == 0)
                {
                    ep.SetError(txtUserName, "Please Enter UserName!");
                    txtUserName.Focus();
                    return;
                }

                if (txtPassword.Text.Trim().Length == 0)
                {
                    ep.SetError(txtPassword, "Please Enter Password..");
                    txtPassword.Focus();
                    return;
                }

                if (txtConfirmPassword.Text.Trim().Length == 0)
                {
                    ep.SetError(txtConfirmPassword, "Please Confirm your Password..");
                    txtConfirmPassword.Focus();
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    ep.SetError(txtConfirmPassword, "Not Match!!!");
                    txtConfirmPassword.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Retrive(string.Format(@"select * from EmployeeTable where UserName = '{0}' and EmployeeID != '{1}' ", txtUserName.Text.Trim(), EmployeeID));
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtUserName, "This UserName is Already Taken..!!");
                        txtUserName.Focus();
                        txtUserName.SelectAll();
                        return;
                    }
                }

                string createuser = string.Format(@"update EmployeeTable set UserName = '{0}', Password = '{1}' where EmployeeID = '{2}' ", txtUserName.Text.Trim(), txtPassword.Text.Trim(), EmployeeID);
                bool result = DatabaseAccess.Update(createuser);
                if (result == true)
                {
                    MessageBox.Show("User Created Successfully...!", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EmployeeID = 0;
                    txtUserName.Clear();
                    txtPassword.Clear();
                    txtConfirmPassword.Clear();
                    picEMP.Image = null;
                    lblFullName.Text = "";
                    lblCNIC.Text = "";
                    lblContactNo.Text = "";
                    txtSearch.Focus();
                }
                else
                {
                    MessageBox.Show("Cannot Create User, Please Try Again...!!", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot Create User, Please Try Again...!!", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
