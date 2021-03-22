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

namespace CosmaticShopApplication.Forms.StockForms
{
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            ComboboxHelper.FillCategories(cmbCategory);
            RetriveList(string.Empty);
            chkStatus.Checked = true;
        }

        private void RetriveList(string searchvalue)
        {
            dgvStock.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select itemID [ID], IsActive [Status], Name [Product], CategoryID, Category, Qty, CurrentPurchasePrice [Purchase Unit Price], SaleUnitPrice [Sale Unit Price], manuDate [Manu Date], expDate [Exp Date ], username [Created By] from v_StockList";
            }
            else
            {
                query = "select itemID [ID], IsActive [Status], Name [Product], CategoryID, Category, Qty, CurrentPurchasePrice [Purchase Unit Price], SaleUnitPrice [Sale Unit Price], manuDate [Manu Date], expDate [Exp Date ], username [Created By] from v_StockList where Name like '%" + searchvalue.Trim() +"%' ";
            }

            DataTable dt = DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvStock.DataSource = dt;
                dgvStock.Columns[0].Visible = false; // itemID
                dgvStock.Columns[1].Width = 60; // IsActive
                dgvStock.Columns[2].Width = 150; // Name
                dgvStock.Columns[3].Visible = false; // CategoryID
                dgvStock.Columns[4].Width = 100; // Category
                dgvStock.Columns[5].Width = 80; // Qty
                dgvStock.Columns[6].Width = 80; // CurrentPurchasePrice
                dgvStock.Columns[7].Width = 80; // SaleUnitPrice
                dgvStock.Columns[8].Width = 80; // manuDate
                dgvStock.Columns[9].Width = 80; // expDate
                dgvStock.Columns[10].Width = 100; // username
            }
            else
            {
                dgvStock.DataSource = null;
            }
        }

        private void ClearForm()
        {
            txtItem.Clear();
            cmbCategory.SelectedIndex = 0;
            chkStatus.Checked = true;
        }

        private void EnableEditComponents()
        {
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = false;
            cmbCategory.SelectedIndex = 0;
            txtItem.Focus();
            txtItem.SelectAll();
        }

        private void DisableEditComponents()
        {
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnClear.Visible = true;
            txtItem.Clear();
            cmbCategory.SelectedIndex = 0;
            txtItem.Focus();
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
            if(txtItem.Text.Trim().Length == 0)
            {
                ep.SetError(txtItem, "Required missing field...");
                txtItem.Focus();
                return;
            }

            if(cmbCategory.SelectedIndex == 0)
            {
                ep.SetError(cmbCategory, "Please Select Category");
                cmbCategory.Focus();
                return;
            }

            try
            {
                DataTable dt = DatabasLayer.DatabaseAccess.Retrive(string.Format(@"select * from StockTable where '" + cmbCategory.SelectedValue + "' and '" + txtItem.Text.Trim() + "' "));
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtItem, "Already Exist...");
                        txtItem.Focus();
                        txtItem.SelectAll();
                        return;
                    }

                }

                string insertquery = string.Format(@"insert into StockTable (CategoryID, EmployeeID, Name, IsActive) values ('{0}', '{1}', '{2}', '{3}') ", cmbCategory.SelectedValue, UserInfo.EmployeeID, txtItem.Text.Trim(), chkStatus.Checked);
                bool result = DatabasLayer.DatabaseAccess.Insert(insertquery);
                if (result == true)
                {
                    MessageBox.Show("Product has been saved successfully...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RetriveList(string.Empty);
                    DisableEditComponents();
                }
                else
                {
                    MessageBox.Show("Please Provide Correct Details...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RetriveList(string.Empty);
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
            if (txtItem.Text.Trim().Length == 0)
            {
                ep.SetError(txtItem, "Required missing field...");
                txtItem.Focus();
                return;
            }

            if (cmbCategory.SelectedIndex == 0)
            {
                ep.SetError(cmbCategory, "Please Select Category");
                cmbCategory.Focus();
                return;
            }

            try
            {
                DataTable dt = DatabasLayer.DatabaseAccess.Retrive(string.Format(@"select * from StockTable where CategoryID = '" + cmbCategory.SelectedValue + "' and Name = '" + txtItem.Text.Trim() + "' and ItemID = '"+dgvStock.CurrentRow.Cells[0].Value.ToString()+"' "));
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtItem, "Already Exist...");
                        txtItem.Focus();
                        txtItem.SelectAll();
                        return;
                    }

                }

                string updatequery = string.Format(@"update StockTable set CategoryID = '{0}', EmployeeID = '{1}', Name = '{2}', IsActive  = '{3}' where ItemID = '{4}' ", cmbCategory.SelectedValue, UserInfo.EmployeeID, txtItem.Text.Trim(), chkStatus.Checked, dgvStock.CurrentRow.Cells[0].Value.ToString());
                bool result = DatabasLayer.DatabaseAccess.Insert(updatequery);
                if (result == true)
                {
                    MessageBox.Show("Product has been updated successfully...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RetriveList(string.Empty);
                    DisableEditComponents();
                }
                else
                {
                    MessageBox.Show("Please Provide Correct Details...", "C# dev by TIK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RetriveList(string.Empty);
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
                if (dgvStock != null)
                {
                    if (dgvStock.Rows.Count > 0)
                    {
                        if (dgvStock.SelectedRows.Count == 1)
                        {
                            txtItem.Text = dgvStock.CurrentRow.Cells[2].Value.ToString();
                            cmbCategory.SelectedValue = Convert.ToString(dgvStock.CurrentRow.Cells[3].Value);
                            chkStatus.Checked = Convert.ToBoolean(dgvStock.CurrentRow.Cells[1].Value);
                            txtItem.Focus();
                            txtItem.SelectAll();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RetriveList(txtSearch.Text.Trim());
        }
    }
}
