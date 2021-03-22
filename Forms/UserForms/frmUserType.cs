using CosmaticShopApplication.DatabasLayer;
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
    public partial class frmUserType : Form
    {
        private string title = "C# dev by TIK";

        public frmUserType()
        {
            InitializeComponent();
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
        }

        // Filldata in DGV -- START
        private void FillGrid(string searchvalue)
        {
            dgvUserType.DataSource = null;
            string query = "";
            if (string.IsNullOrEmpty(searchvalue))
            {
                query = "select UserTypeID [ID], UserType [User Type] from UserTypeTable";
            }
            else
            {
                query = "select UserTypeID [ID], UserType [User Type] from UserTypeTable where UserType like '%"+searchvalue+"%' ";
            }

            DataTable dt = DatabaseAccess.Retrive(query);
            if(dt != null)
            {
                dgvUserType.DataSource = dt;
                if(dt.Rows.Count > 0)
                {
                    dgvUserType.Columns[0].Width = 100;
                    dgvUserType.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    dgvUserType.DataSource = null;
                }
            }
        }// Filldata in DGV -- END


        // Clear method
        private void Clear()
        {
            txtSearch.Clear();
            txtUserType.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void frmUserType_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
            dgvUserType.ClearSelection();
        }


        // Search by UserType -- START
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }// Search by UserType -- END


        // Save data -- START
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtUserType.Text.Trim().Length == 0)
                {
                    ep.SetError(txtUserType, "Please Enter UserType...");
                    txtUserType.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Retrive("select * from UserTypeTable where UserType = '" + txtUserType.Text.Trim() + "' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtUserType, txtUserType.Text + " is Already Registered!");
                        txtUserType.SelectAll();
                        txtUserType.Focus();
                        return;
                    }
                }

                string insertquery = string.Format(@"insert into UserTypeTable(UserType) values ('"+txtUserType.Text.Trim()+"')");
                bool result = DatabaseAccess.Insert(insertquery);
                if(result == true)
                {
                    btnClear_Click(sender, e);
                    MessageBox.Show("Saved Successfully...", title);
                }
                else
                {
                    MessageBox.Show("Save Failed, Please try again...", title);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }// Save data -- END


        // DGV Edit method -- START
        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            if(dgvUserType != null)
            {
                if(dgvUserType.Rows.Count > 0)
                {
                    if(dgvUserType.SelectedRows.Count == 1)
                    {
                        txtUserType.Text = dgvUserType.CurrentRow.Cells[1].Value.ToString();
                        EnableComponents();
                    }
                    else
                    {
                        MessageBox.Show("Please select one record!", title);
                        ResetComponents();
                    }
                }
            }
        }// DGV Edit method -- END


        // When Edit -- START
        private void EnableComponents()
        {
            btnClear.Enabled = false;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = true;
            dgvUserType.Enabled = false;
            btnSave.Enabled = false;
            txtSearch.Enabled = false;
            txtUserType.Focus();
            txtUserType.SelectAll();
            lblCancel.Visible = true;
        }// When Edit -- END


        // When not Edit -- START
        private void ResetComponents()
        {
            btnClear.Enabled = true;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
            dgvUserType.Enabled = true;
            btnSave.Enabled = true;
            txtSearch.Enabled = true;
            txtUserType.Clear();
            txtUserType.Enabled = true;
            txtUserType.Focus();
            FillGrid(string.Empty);
            lblCancel.Visible = false;
        }// When not Edit -- END


        // Edit Data -- START
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (txtUserType.Text.Trim().Length == 0)
                {
                    ep.SetError(txtUserType, "Please Enter UserType...");
                    txtUserType.Focus();
                    return;
                }

                DataTable dt = DatabaseAccess.Retrive("select * from UserTypeTable where UserType = '" + txtUserType.Text.Trim() + "' ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(txtUserType, txtUserType.Text + " is Already Registered!");
                        txtUserType.SelectAll();
                        txtUserType.Focus();
                        return;
                    }
                }

                string updatequery = string.Format(@"update UserTypeTable set UserType = '" + txtUserType.Text.Trim() + "' where UserTypeID = '"+dgvUserType.CurrentRow.Cells[0].Value.ToString()+"' ");
                bool result = DatabaseAccess.Update(updatequery);
                if (result == true)
                {
                    ResetComponents();
                    MessageBox.Show("Updated Successfully...", title);
                }
                else
                {
                    ResetComponents();
                    MessageBox.Show("Update Failed, Please try again...", title);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }// Edit Data -- END

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetComponents();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
