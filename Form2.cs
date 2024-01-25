using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            sqlCN = new SqlConnection("Server = DESKTOP-SMHGA8V\\SQL;DataBase= BikeStores;Integrated Security =true");
            sqlcmd = new SqlCommand();
            //sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlCN;
            //sqlcmd.CommandText = "select count(*) from production.products";
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "uspproductlist";
            sqlcmd.Parameters.Add("@name", SqlDbType.VarChar);
            sqlcmd.Parameters.Add("@min_price", SqlDbType.Decimal);
            sqlcmd.Parameters.Add("@max_price", SqlDbType.Decimal);
        }
        SqlConnection sqlCN;
        SqlCommand sqlcmd;
        private void Form2_Load(object sender, EventArgs e)
        {
            SqlCommand sqlGEtprdName = new SqlCommand("select product_name from production.products",sqlCN);
            sqlCN.Open();
            SqlDataReader Dr = sqlGEtprdName.ExecuteReader();
            //  comproductName.DataSource = Dr;
            while (Dr.Read())
            {
                comproductName.Items.Add(Dr["product_id"]);
                //comproductName.Items.Add(Dr.GetInt32("product_name"));
            }


            sqlCN.Close();

        }

        #region  Scalar
        //private void btnExecute_Click(object sender, EventArgs e)
        //{
        //   if (sqlCN.State == ConnectionState.Closed)
        //        sqlCN.Open();
        //   if (int.TryParse(sqlcmd.ExecuteScalar()?.ToString() ?? "0", out int N))
        //          this.Text = $"Product Count{N}";
        //    sqlCN.Close();
        //}
        #endregion
        private void btnExecute_Click(object sender, EventArgs e)
        {
            //if (sqlCN.State == ConnectionState.Closed)
            //    sqlCN.Open();
            // set value parameter 
            //sqlcmd.Parameters["@name"].Value= "Surly Wednesday Frameset -2016";
            //sqlcmd.Parameters["@min_price"].Value = 0; 
            //sqlcmd.Parameters["@max_price"].Value = 999999;
            if (int.TryParse(comproductName.SelectedItem?.ToString() ?? string.Empty, out  int prd_id ))
            {
                if(sqlCN.State == ConnectionState.Closed)
                sqlCN.Open();
                sqlcmd.Parameters["@product_id"].Value = prd_id;
                sqlcmd.Parameters["@product_name"].Value = textBox1.Text;

                int R = sqlcmd.ExecuteNonQuery(); // return integer
                this.Text = $"{R}Row Affected";
                sqlCN.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
