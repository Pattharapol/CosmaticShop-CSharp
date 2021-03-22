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

namespace CosmeticShopApplication.Forms.CustomerForms
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            RetriveCustomers(string.Empty);
        }

        private void RetriveCustomers(string searchvalue)
        {
            dgvCustomer.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select CustomerID [ID], Name [Customer], ContactNo [Contact], Address [Address], username [Created By], Description [Description] from v_CustomerList";
            }
            else
            {
                query = "select CustomerID [ID], Name [Customer], ContactNo [Contact], Address [Address], username [Created By], Description [Description] from v_CustomerList where Name like '%"+searchvalue.Trim()+"%' ";
            }

            DataTable dt = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvCustomer.DataSource = dt;
                dgvCustomer.Columns[0].Visible = false; // CustomerID
                dgvCustomer.Columns[1].Width = 200; // Name
                dgvCustomer.Columns[2].Width = 150; // ContactNo
                dgvCustomer.Columns[3].Width = 250; // Address
                dgvCustomer.Columns[4].Width = 130; // username
                dgvCustomer.Columns[5].Width = 250; // Description

            }
            else
            {
                dgvCustomer.DataSource = null;
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
            RetriveCustomers(string.Empty);
        }

        private void ClearForm()
        {
            txtCustomer.Clear();
            txtContactNo.Clear();
            txtAddress.Clear();
            txtDescription.Clear();
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
            if (txtCustomer.Text.Trim().Length == 0)
            {
                ep.SetError(txtCustomer, "Required missing field...");
                txtCustomer.Focus();
                return;
            }

            if (txtContactNo.Text.Trim().Length == 0)
            {
                ep.SetError(txtContactNo, "Required missing field...");
                txtContactNo.Focus();
                return;
            }

            if (txtAddress.Text.Trim().Length == 0)
            {
                ep.SetError(txtAddress, "Required missing field...");
                txtAddress.Focus();
                return;
            }

            DataTable dt = DatabaseAccess.Retrive("select * from CustomerTable where name = '" + txtCustomer.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim() + "' ");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ep.SetError(txtCustomer, "Already Exist...");
                    txtCustomer.Focus();
                    return;
                }
            }


            try
            {

                string insertquery = string.Format(@"insert into CustomerTable (EmployeeID, Name, ContactNo, Address, Description) values ('{0}', '{1}', '{2}', '{3}', '{4}') ", UserInfo.EmployeeID, txtCustomer.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtDescription.Text.Trim());
                bool result = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Insert(insertquery);
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
            if (txtCustomer.Text.Trim().Length == 0)
            {
                ep.SetError(txtCustomer, "Required missing field...");
                txtCustomer.Focus();
                return;
            }

            if (txtContactNo.Text.Trim().Length == 0)
            {
                ep.SetError(txtContactNo, "Required missing field...");
                txtContactNo.Focus();
                return;
            }

            if (txtAddress.Text.Trim().Length == 0)
            {
                ep.SetError(txtAddress, "Required missing field...");
                txtAddress.Focus();
                return;
            }

            DataTable dt = DatabaseAccess.Retrive("select * from CustomerTable where name = '" + txtCustomer.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim() + "' and CustomerID != '" + dgvCustomer.CurrentRow.Cells[0].Value.ToString() + "' ");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ep.SetError(txtCustomer, "Already Exist...");
                    txtCustomer.Focus();
                    return;
                }
            }

            try
            {
                string updatequery = string.Format(@"update CustomerTable set EmployeeID = '{0}', Name = '{1}', ContactNo = '{2}', Address = '{3}', 
                    Description = '{4}' where CustomerID = '{5}' ", UserInfo.EmployeeID, txtCustomer.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtDescription.Text.Trim(), dgvCustomer.CurrentRow.Cells[0].Value.ToString());
                bool result = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Update(updatequery);
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
                if (dgvCustomer != null)
                {
                    if (dgvCustomer.Rows.Count > 0)
                    {
                        if (dgvCustomer.SelectedRows.Count == 1)
                        {
                            //dgvSupplier.Columns[0].Visible = false; // SupplierID
                            //dgvSupplier.Columns[1].Width = 200; // Supplier
                            //dgvSupplier.Columns[2].Width = 150; // ContactNo
                            //dgvSupplier.Columns[3].Width = 250; // Address
                            //dgvSupplier.Columns[4].Width = 130; // username
                            //dgvSupplier.Columns[5].Width = 250; // Description

                            txtCustomer.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
                            txtContactNo.Text = dgvCustomer.CurrentRow.Cells[2].Value.ToString();
                            txtAddress.Text = dgvCustomer.CurrentRow.Cells[3].Value.ToString();
                            txtDescription.Text = dgvCustomer.CurrentRow.Cells[5].Value.ToString();
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
            RetriveCustomers(txtSearch.Text.Trim());
        }
    }
}
