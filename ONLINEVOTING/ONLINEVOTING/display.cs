using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace ONLINEVOTING
{
    public partial class display : Form
    {
        public display()
        {
            InitializeComponent();
        }

        private void display_Load(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
            SqlDataAdapter sda = new SqlDataAdapter("Select *from CONTESTING where party= '" + comboBox1.Text + "'", conn);
            SqlCommand cmd = new SqlCommand("Select *from CONTESTING where party= '" + comboBox1.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string fn = (string)dr["fname"].ToString();
                string ln = (string)dr["lname"].ToString();

                string cd = (string)dr["candidateid"].ToString();
                label1.Text = cd;
                label3.Text = fn;
                label6.Text = ln;
            }
            byte[] data = (byte[])dt.Rows[0]["IMAGE"];
            MemoryStream ms = new MemoryStream(data);
            pictureBox1.Image = Image.FromStream(ms);
        }
    }
}
