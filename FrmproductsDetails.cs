using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part1
{
    public partial class FrmproductsDetails : Form
    {
        public FrmproductsDetails()
        {
            InitializeComponent();
        }
        SqlConnection sqlCN = new SqlConnection("Server = DESKTOP-SMHGA8V\\SQL;DataBase= BikeStores;Integrated Security =true");
        SqlCommand cmd;
        SqlDataAdapter DA;
        DataTable Dt = new DataTable();
        private void FrmproductsDetails_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from production.products",sqlCN);
            DA = new SqlDataAdapter(cmd);
            DA.Fill(Dt);
            //  to Move  through Data Source 
             productBindingSource = new BindingSource(Dt,"");



            // simple Data binding 
            //lblproductid.DataBindings.Add("Text", Dt, "product_id");
            //txtproductName.DataBindings.Add("Text", Dt, "product_name");
            //numunitsbrand.DataBindings.Add("Text", Dt, "brand_id");


            lblproductid.DataBindings.Add("Text", productBindingSource, "product_id");
            txtproductName.DataBindings.Add("Text", productBindingSource, "product_name");
            numunitsbrand.DataBindings.Add("Text", productBindingSource, "brand_id");
        }
        BindingSource productBindingSource;
        

        private void btnNext_Click(object sender, EventArgs e)
        {
            productBindingSource.MoveNext();
            
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            productBindingSource.MovePrevious();
        }
    }
}
