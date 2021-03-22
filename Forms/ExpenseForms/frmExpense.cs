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
    public partial class frmExpense : Form
    {
        public frmExpense()
        {
            InitializeComponent();
            AutoScroll = true;
        }

        private void frmExpense_Load(object sender, EventArgs e)
        {
            ComboboxHelper.FillExpenseCategories(cboCategory);
            RetriveExpenses(string.Empty);
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void RetriveExpenses(string searchvalue)
        {
            dgvExpense.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select expenseID [ID], title [Expenses], expCategoryID, Name [Category], ExpDate [Date], totalCost [Cost], reason, comments, username [Created By] from v_AllExpenses";
            }
            else
            {
                query = "select expenseID [ID], title [Expenses], expCategoryID, Name [Category], ExpDate [Date], totalCost [Cost], reason, comments, username [Created By] from v_AllExpenses where title like '%" + searchvalue+"%' or Name like '%"+ searchvalue + "%' or username like '%"+ searchvalue + "%' ";
            }

            DataTable dt = DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvExpense.DataSource = dt;
                dgvExpense.Columns[0].Visible = false; // expenseID
                dgvExpense.Columns[1].Width = 150; // title Expenses
                dgvExpense.Columns[2].Visible = false; // expCategoryID
                dgvExpense.Columns[3].Width = 150; // Category
                dgvExpense.Columns[4].Width = 150; // date
                dgvExpense.Columns[5].Width = 80; // totalcost
                dgvExpense.Columns[6].Width = 200; // reason
                dgvExpense.Columns[7].Width = 200; // comments
                dgvExpense.Columns[8].Width = 100; // username

            }
            else
            {
                dgvExpense.DataSource = null;
            }
        }

        private void EnableEditComponents()
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = false;
        }

        private void DisableEditComponents()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnClear.Visible = true;
            ClearForm();
            RetriveExpenses(string.Empty);
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            cboCategory.SelectedIndex = 0;
            txtCost.Clear();
            txtReason.Clear();
            txtComment.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveExpenses(txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableEditComponents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if(txtTitle.Text.Trim().Length == 0)
            {
                ep.SetError(txtTitle, "Required missing field...");
                txtTitle.Focus();
                return;
            }

            if (txtCost.Text.Trim().Length == 0)
            {
                ep.SetError(txtCost, "Required missing field...");
                txtCost.Focus();
                return;
            }

            if (txtReason.Text.Trim().Length == 0)
            {
                ep.SetError(txtReason, "Required missing field...");
                txtReason.Focus();
                return;
            }

            if(cboCategory.SelectedIndex == 0)
            {
                ep.SetError(cboCategory, "Please Select Category...");
                cboCategory.Focus();
                return;
            }

            float cost = 0;
            float.TryParse(txtCost.Text.Trim(), out cost);
            if (cost == 0)
            {
                ep.SetError(txtCost, "Required missing field...");
                txtCost.Focus();
                return;
            }
            try
            {

                string insertquery = string.Format(@"insert into expsenseTable (EmployeeID, expCategoryID, title, reason, comments, totalCost, ExpDate) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}') ", UserInfo.EmployeeID, cboCategory.SelectedValue, txtTitle.Text.Trim(), txtReason.Text.Trim(), txtComment.Text.Trim(), txtCost.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd hh:mm"));
                bool result = DatabasLayer.DatabaseAccess.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Record has been saved successfully...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisableEditComponents();
                }
                else
                {
                    MessageBox.Show("Please Provide Correct Details, Then Try Again...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DisableEditComponents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtTitle.Text.Trim().Length == 0)
            {
                ep.SetError(txtTitle, "Required missing field...");
                txtTitle.Focus();
                return;
            }

            if (txtCost.Text.Trim().Length == 0)
            {
                ep.SetError(txtCost, "Required missing field...");
                txtCost.Focus();
                return;
            }

            if (txtReason.Text.Trim().Length == 0)
            {
                ep.SetError(txtReason, "Required missing field...");
                txtReason.Focus();
                return;
            }

            if (cboCategory.SelectedIndex == 0)
            {
                ep.SetError(cboCategory, "Please Select Category...");
                cboCategory.Focus();
                return;
            }

            float cost = 0;
            float.TryParse(txtCost.Text.Trim(), out cost);
            if (cost == 0)
            {
                ep.SetError(txtCost, "Required missing field...");
                txtCost.Focus();
                return;
            }
            try
            {

                string updatequery = string.Format(@"update expsenseTable set EmployeeID = '{0}', expCategoryID = '{1}', title = '{2}', reason = '{3}', comments = '{4}', totalCost = '{5}', ExpDate = '{6}' where expenseID = '{7}' ", UserInfo.EmployeeID, cboCategory.SelectedValue, txtTitle.Text.Trim(), txtReason.Text.Trim(), txtComment.Text.Trim(), txtCost.Text.Trim(), DateTime.Now.ToString("yyyy-MM-dd hh:mm"), dgvExpense.CurrentRow.Cells[0].Value.ToString());
                bool result = DatabasLayer.DatabaseAccess.Update(updatequery);
                if (result == true)
                {
                    MessageBox.Show("Record has been updated successfully...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DisableEditComponents();
                }
                else
                {
                    MessageBox.Show("Please Provide Correct Details, Then Try Again...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DisableEditComponents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpense != null)
                {
                    if (dgvExpense.Rows.Count > 0)
                    {
                        if (dgvExpense.SelectedRows.Count == 1)
                        {
                            //dgvExpense.Columns[0].Visible = false; // expenseID
                            //dgvExpense.Columns[1].Width = 150; // title Expenses
                            //dgvExpense.Columns[2].Visible = false; // expCategoryID
                            //dgvExpense.Columns[3].Width = 150; // Category
                            //dgvExpense.Columns[4].Width = 150; // date
                            //dgvExpense.Columns[5].Width = 80; // totalcost
                            //dgvExpense.Columns[6].Width = 200; // reason
                            //dgvExpense.Columns[7].Width = 200; // comments
                            //dgvExpense.Columns[8].Width = 100; // username

                            txtTitle.Text = dgvExpense.CurrentRow.Cells[1].Value.ToString();
                            cboCategory.SelectedValue = dgvExpense.CurrentRow.Cells[2].Value.ToString();
                            txtCost.Text = dgvExpense.CurrentRow.Cells[5].Value.ToString();
                            txtReason.Text = dgvExpense.CurrentRow.Cells[6].Value.ToString();
                            txtComment.Text = dgvExpense.CurrentRow.Cells[7].Value.ToString();
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
    }
}
