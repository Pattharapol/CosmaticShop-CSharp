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

namespace CosmeticShopApplication.Forms.SupplierForm
{
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            RetriveSuppliers(string.Empty);
        }


        private void RetriveSuppliers(string searchvalue)
        {
            dgvSupplier.DataSource = null;
            string query = string.Empty;
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select SupplierID [ID], Name [Supplier], ContactNo [ContactNo], Address [Address], username [Created By], Description [Description] from v_SupplierList";
            }
            else
            {
                query = "select SupplierID [ID], Name [Supplier], ContactNo [ContactNo], Address [Address], username [Created By], Description [Description] from v_SupplierList where Name like '%"+ searchvalue.Trim() + "%' or ContactNo like '%"+ searchvalue.Trim() + "%' or Address like '%"+ searchvalue.Trim() + "%' or username like '%"+ searchvalue.Trim() + "%' ";
            }

            DataTable dt = CosmaticShopApplication.DatabasLayer.DatabaseAccess.Retrive(query);
            if (dt != null)
            {
                dgvSupplier.DataSource = dt;
                dgvSupplier.Columns[0].Visible = false; // SupplierID
                dgvSupplier.Columns[1].Width = 200; // Supplier
                dgvSupplier.Columns[2].Width = 150; // ContactNo
                dgvSupplier.Columns[3].Width = 250; // Address
                dgvSupplier.Columns[4].Width = 130; // username
                dgvSupplier.Columns[5].Width = 250; // Description

            }
            else
            {
                dgvSupplier.DataSource = null;
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
            RetriveSuppliers(string.Empty);
        }

        private void ClearForm()
        {
            txtSupplierName.Clear();
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
            if (txtSupplierName.Text.Trim().Length == 0)
            {
                ep.SetError(txtSupplierName, "Required missing field...");
                txtSupplierName.Focus();
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

            DataTable dt = DatabaseAccess.Retrive("select * from SupplierTable where name = '" + txtSupplierName.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim() + "' ");
            if(dt != null)
            {
                if(dt.Rows.Count > 0)
                {
                    ep.SetError(txtSupplierName, "Already Exist...");
                    txtSupplierName.Focus();
                    return;
                }
            }

            
            try
            {

                string insertquery = string.Format(@"insert into SupplierTable (EmployeeID, Name, ContactNo, Address, Description) values ('{0}', '{1}', '{2}', '{3}', '{4}') ", UserInfo.EmployeeID, txtSupplierName.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtDescription.Text.Trim());
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
            if (txtSupplierName.Text.Trim().Length == 0)
            {
                ep.SetError(txtSupplierName, "Required missing field...");
                txtSupplierName.Focus();
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

            DataTable dt = DatabaseAccess.Retrive("select * from SupplierTable where name = '" + txtSupplierName.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim() + "' and SupplierID != '"+dgvSupplier.CurrentRow.Cells[0].Value.ToString()+"' ");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ep.SetError(txtSupplierName, "Already Exist...");
                    txtSupplierName.Focus();
                    return;
                }
            }
            
            try
            {
                string updatequery = string.Format(@"update SupplierTable set EmployeeID = '{0}', Name = '{1}', ContactNo = '{2}', Address = '{3}', 
                    Description = '{4}' where SupplierID = '{5}' ", UserInfo.EmployeeID, txtSupplierName.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), txtDescription.Text.Trim(), dgvSupplier.CurrentRow.Cells[0].Value.ToString());
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
                if (dgvSupplier != null)
                {
                    if (dgvSupplier.Rows.Count > 0)
                    {
                        if (dgvSupplier.SelectedRows.Count == 1)
                        {
                            //dgvSupplier.Columns[0].Visible = false; // SupplierID
                            //dgvSupplier.Columns[1].Width = 200; // Supplier
                            //dgvSupplier.Columns[2].Width = 150; // ContactNo
                            //dgvSupplier.Columns[3].Width = 250; // Address
                            //dgvSupplier.Columns[4].Width = 130; // username
                            //dgvSupplier.Columns[5].Width = 250; // Description

                            txtSupplierName.Text = dgvSupplier.CurrentRow.Cells[1].Value.ToString();
                            txtContactNo.Text = dgvSupplier.CurrentRow.Cells[2].Value.ToString();
                            txtAddress.Text = dgvSupplier.CurrentRow.Cells[3].Value.ToString();
                            txtDescription.Text = dgvSupplier.CurrentRow.Cells[5].Value.ToString();
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
            RetriveSuppliers(txtSearch.Text.Trim());
        }
    }
}
