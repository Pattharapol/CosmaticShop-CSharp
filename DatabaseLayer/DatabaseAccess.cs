using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;

namespace CosmaticShopApplication.DatabasLayer
{
    public class DatabaseAccess
    {
        private static SqlConnection conn;


        // Connection method
        public static SqlConnection ConnOpen()
        {
            if(conn == null)
            {
                conn = new SqlConnection(@"Data Source=MSI-TIK\SQLEXPRESS;Initial Catalog=CosmaticShopDb;Integrated Security=True");
            }

            if(conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }


        // Check Insert method
        public static bool Insert(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                int noOfRecord = cmd.ExecuteNonQuery();
                if (noOfRecord > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Chech Update method
        public static bool Update(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                int noOfRecord = cmd.ExecuteNonQuery();
                if (noOfRecord > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        // Chech Delete method
        public static bool Delete(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, ConnOpen());
                int noOfRecord = cmd.ExecuteNonQuery();
                if (noOfRecord > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DataTable Retrive Data method
        public static DataTable Retrive(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, ConnOpen());
                da.Fill(dt);
                if(dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    return dt;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        // ImageCheck
        public static Image Base64ToImage(string base64String)
        {
            try
            {
                // Convert Base64 String to byte[]
                if (!string.IsNullOrEmpty(base64String) && !string.IsNullOrWhiteSpace(base64String))
                {
                    byte[] imageBytes = Convert.FromBase64String(base64String);
                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                    // Convert byte[] to Image
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    Image image = Image.FromStream(ms, true);
                    return image;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Image Again
        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            // Convert Image to byte[]
            MemoryStream ms = new MemoryStream();
            image.Save(ms, format);
            byte[] imageBtye = ms.ToArray();

            // Convert byte[] to Base64 String
            string base64String = Convert.ToBase64String(imageBtye);
            return base64String;
        }
    }
}
