using CosmaticShopApplication.DatabasLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CosmaticShopApplication.SourceCode
{
    public class ComboboxHelper
    {
        // Fill data into Combobox
        public static void FillUserType(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserTypeID");
            dt.Columns.Add("UserType");
            dt.Rows.Add("0", "----Select Type----"); //Add 1 row (row0, value : ----select type----)
            var dbdt = DatabaseAccess.Retrive("select UserTypeID, UserType from UserTypeTable");
            if(dbdt != null)
            {
                if(dbdt.Rows.Count > 0)
                {
                    foreach(DataRow usertype in dbdt.Rows) // User foreach to select data from table
                    {
                        dt.Rows.Add(usertype["UserTypeID"], usertype["UserType"]);
                    }
                }
            }

            cmb.DataSource = dt;
            cmb.DisplayMember = "UserType"; // display usertype
            cmb.ValueMember = "UserTypeID"; // value of usertypeID such like ID
        }

        public static void FillCategories(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CategoryID");
            dt.Columns.Add("Name");
            dt.Rows.Add("0", "----Select Category----"); //Add 1 row (row0, value : ----select type----)
            var dbdt = DatabaseAccess.Retrive("select CategoryID, Name from CategoryTable");
            if (dbdt != null)
            {
                if (dbdt.Rows.Count > 0)
                {
                    foreach (DataRow Categorytype in dbdt.Rows) // User foreach to select data from table
                    {
                        dt.Rows.Add(Categorytype["CategoryID"], Categorytype["Name"]);
                    }
                }
            }

            cmb.DataSource = dt;
            cmb.DisplayMember = "Name"; // display usertype
            cmb.ValueMember = "CategoryID"; // value of usertypeID such like ID
        }

        public static void FillExpenseCategories(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("expCategoryID");
            dt.Columns.Add("Name");
            dt.Rows.Add("0", "----Select ExpenseCategory----"); //Add 1 row (row0, value : ----select type----)
            var dbdt = DatabaseAccess.Retrive("select expCategoryID, Name from expenseCategoryTable");
            if (dbdt != null)
            {
                if (dbdt.Rows.Count > 0)
                {
                    foreach (DataRow Categorytype in dbdt.Rows) // User foreach to select data from table
                    {
                        dt.Rows.Add(Categorytype["expCategoryID"], Categorytype["Name"]);
                    }
                }
            }

            cmb.DataSource = dt;
            cmb.DisplayMember = "Name"; // display usertype
            cmb.ValueMember = "expCategoryID"; // value of usertypeID such like ID
        }

        public static void FillProducts(ComboBox cmb, string categoryid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("itemID");
            dt.Columns.Add("Name");
            dt.Rows.Add("0", "----Select Product----"); //Add 1 row (row0, value : ----select type----)
            var dbdt = DatabaseAccess.Retrive("select itemID, Name from StockTable where CategoryID = '"+categoryid+"' ");
            if (dbdt != null)
            {
                if (dbdt.Rows.Count > 0)
                {
                    foreach (DataRow Categorytype in dbdt.Rows) // User foreach to select data from table
                    {
                        dt.Rows.Add(Categorytype["itemID"], Categorytype["Name"]);
                    }
                }
            }

            cmb.DataSource = dt;
            cmb.DisplayMember = "Name"; // display usertype
            cmb.ValueMember = "itemID"; // value of usertypeID such like ID
        }
    }
}
