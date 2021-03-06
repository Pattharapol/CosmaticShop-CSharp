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

namespace CosmaticShopApplication.Forms.ExpenseForms
{
    public partial class frmExpenseCategory : Form
    {
        public frmExpenseCategory()
        {
            InitializeComponent();
        }

        private void frmExpenseCategory_Load(object sender, EventArgs e)
        {
            RetriveExpenseCategories(string.Empty);
        }

        private void RetriveExpenseCategories(string searchvalue)
        {
            dgvCategory.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select expCategoryID [ID], Name [Category], username [Created By] from v_ExpenseCategories";
            }
            else
            {
                query = "select expCategoryID [ID], Name [Category], username [Created By] from v_ExpenseCategories where Name like '%" + searchvalue.Trim()+"%' ";
            }

            DataTable dt = DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvCategory.DataSource = dt;
                dgvCategory.Columns[0].Visible = false; // expCategoryID
                dgvCategory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Category
                dgvCategory.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // username
            }
            else
            {
                dgvCategory.DataSource = null;
            }
        }

        private void EnableEditComponents()
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = false;
            txtCategory.Focus();
            txtCategory.SelectAll();
        }

        private void DisableEditComponents()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnClear.Visible = true;
            txtCategory.Clear();
            txtCategory.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveExpenseCategories(txtSearch.Text.Trim());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableEditComponents();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategory.Clear();
            txtCategory.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtCategory.Text.Trim().Length == 0)
            {
                ep.SetError(txtCategory, "Required missing field...");
                txtCategory.Focus();
                return;
            }

            try
            {
                DataTable dt = DatabasLayer.DatabaseAccess.Retrive(string.Format(@"select * from expenseCategoryTable where Name = '{0}' ", txtCategory.Text.Trim()));
                if (dt != null)
                {
                    if (dt.Rows.Count == 1)
                    {
                        ep.SetError(txtCategory, "Already Exists...");
                        txtCategory.Focus();
                        txtCategory.SelectAll();
                        return;
                    }
                }

                string insertquery = string.Format(@"insert into expenseCategoryTable (Name, EmployeeID) values ('{0}', '{1}')", txtCategory.Text.Trim(), UserInfo.EmployeeID);
                bool result = DatabasLayer.DatabaseAccess.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Category has been saved successfully...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCategory.Clear();
                    txtCategory.Focus();
                    RetriveExpenseCategories(string.Empty);
                    return;
                }
                else
                {
                    MessageBox.Show("Please Enter Correct Details, Try Again...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategory.Focus();
                    txtCategory.SelectAll();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Message : " + ex.Message, "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategory.Focus();
                txtCategory.SelectAll();
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtCategory.Text.Trim().Length == 0)
            {
                ep.SetError(txtCategory, "Required missing field...");
                txtCategory.Focus();
                return;
            }

            try
            {
                DataTable dt = DatabasLayer.DatabaseAccess.Retrive(string.Format(@"select * from expenseCategoryTable where Name = '{0}' and CategoryID != '{1}' ", txtCategory.Text.Trim(), dgvCategory.CurrentRow.Cells[0].Value.ToString()));
                if (dt != null)
                {
                    if (dt.Rows.Count == 1)
                    {
                        ep.SetError(txtCategory, "Already Exists...");
                        txtCategory.Focus();
                        txtCategory.SelectAll();
                        return;
                    }
                }

                string updatequery = string.Format(@"update expenseCategoryTable set Name = '{0}', EmployeeID = '{1}' where expCategoryID = '{2}' ", txtCategory.Text.Trim(), UserInfo.EmployeeID, dgvCategory.CurrentRow.Cells[0].Value.ToString());
                bool result = DatabasLayer.DatabaseAccess.Insert(updatequery);
                if (result == true)
                {
                    MessageBox.Show("Category has been updated successfully...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisableEditComponents();
                    RetriveExpenseCategories(string.Empty);
                    return;
                }
                else
                {
                    MessageBox.Show("Please Enter Correct Details, Try Again...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategory.Focus();
                    txtCategory.SelectAll();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Message : " + ex.Message, "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategory.Focus();
                txtCategory.SelectAll();
                return;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategory != null)
                {
                    if (dgvCategory.Rows.Count > 0)
                    {
                        if (dgvCategory.SelectedRows.Count == 1)
                        {
                            txtCategory.Text = dgvCategory.CurrentRow.Cells[1].Value.ToString();
                            EnableEditComponents();
                        }
                        else
                        {
                            MessageBox.Show("Please Select One Record...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("List is Empty...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
            
        }
    }
}
