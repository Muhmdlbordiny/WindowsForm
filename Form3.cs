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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection sqlCN= new SqlConnection("Server = DESKTOP-SMHGA8V\\SQL;DataBase= BikeStores;Integrated Security =true");
        SqlCommand cmd;
        SqlDataAdapter DA;
        DataTable Dt;

        private void Form3_Load(object sender, EventArgs e)
        {
        //    cmd = new SqlCommand("select * from production.products ", sqlCN);
        //    DA = new SqlDataAdapter(cmd);
            Dt = new DataTable();

            //Demo 
            this.listBox1.Items.Add(new { id = 1, name = "lolo" });
            this.listBox1.Items.Add(new { id = 2, name = "mori" });
        }

        private void btn_Ex_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("select * from production.products Where  brand_id >@brand_id ", sqlCN);
            cmd.Parameters.AddWithValue("@brand_id",4);
            DA = new SqlDataAdapter(cmd);

            DA.Fill(Dt); // open sqlconnection,execute selectCommand ,fetch data into data table
            //this.Text = Dt.Rows.Count.ToString();
            ////complex Data Binding
            //listBox1.DataSource = Dt;
            //listBox1.DisplayMember = "product_name";
            //listBox1.ValueMember = "product_id";
             dataGridView1.DataSource = Dt;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = $"{listBox1.SelectedValue}";
        }

        private void Saving_Click(object sender, EventArgs e)
        {
            // sqlCommandBuilder
            DA.Update(Dt); // Execute  insertCommand,UpdateCommand ,DeleteCommand
        }
    }
}
