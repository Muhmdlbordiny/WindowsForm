using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration.Assemblies;
using System.Xml.XmlConfiguration;

namespace part1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlCN;


        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCN = new SqlConnection();


             sqlCN.ConnectionString = "Server = DESKTOP-SMHGA8V\\SQL;DataBase= BikeStores;Integrated Security =true";
            //    "Data Source=.;Initial Catalog = BikeStores; Integrated Security =true";
            //true => window Auth
            //false :sql Auth

            //sqlCN.ConnectionString= ConfigurationManager.ConnectionStrings["BikeStores"].ConnectionString ;
            //this.Text = ConfigurationManager.AppSettings["BranchId"];
            sqlCN.StateChange += (hel, o) =>
                           this.Text = $"State was {o.OriginalState}and changed to {o.CurrentState}";
            sqlCN.InfoMessage += (hel, o) => MessageBox.Show(o.Message);
            this.FormClosed += (hel, o) => sqlCN?.Dispose();


        }






    

             private void SqlCN_StateChange(object sender, StateChangeEventArgs e)
              {
                     throw new NotImplementedException();
              }

             private void button1_Click(object sender, EventArgs e)
             {
            if (sqlCN.State==ConnectionState.Closed)
            sqlCN.Open();
           // MessageBox.Show(sqlCN.State.ToString());

           
              }

             private void button2_Click(object sender, EventArgs e)
            {
             if (sqlCN.State != ConnectionState.Closed)  // no exeception
                sqlCN.Close();
                // MessageBox.Show(sqlCN.State.ToString());

              }

            private void btnChangeDB_Click(object sender, EventArgs e)
             {
                  if (sqlCN.State == ConnectionState.Open)
                 {
                sqlCN.ChangeDatabase("egypt");

                  }
            }
    }
}
