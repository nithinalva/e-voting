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
    public partial class voterwindow : Form
    {
        public static string settext = "";
        public voterwindow()
        {
            InitializeComponent();
            Fillcombo();
            panel2.Visible = true;
            textBox1.PasswordChar = '*';
            

        }
        void Fillcombo()
        {



            String constring = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True";
            String Query = "select * from CONTESTING";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();

                while (myReader.Read())
                {


                    string sname = myReader.GetString(myReader.GetOrdinal("party"));
                    comboBox1.Items.Add(sname);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            label6.Visible = true;

            label7.Visible = true;
            SqlConnection conn=new SqlConnection( @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
            SqlDataAdapter sda = new SqlDataAdapter("Select *from CONTESTING where party= '" + comboBox1.Text + "'", conn);
            SqlCommand cmd=new SqlCommand("Select *from CONTESTING where party= '" + comboBox1.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                string fn= (string)dr["fname"].ToString();
                string ln = (string)dr["lname"].ToString();

                string cd = (string)dr["candidateid"].ToString();
                label5.Text = cd;
                label6.Text = fn;
                label7.Text = ln;
            }
            byte[] data = (byte[])dt.Rows[0]["IMAGE"];
            MemoryStream ms = new MemoryStream(data);
            pictureBox1.Image = Image.FromStream(ms);
            


        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           

            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
                conn.Open();
                string newconn = "select fname,lname,fathername,mothername,phone,address,adharid,gender,dob,password from voter where adharid ='" + textBox2.Text + "'and password='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(newconn, conn);
                SqlDataAdapter adp = new SqlDataAdapter(newconn, conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    SqlConnection conn1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
                    conn1.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into result(adharid,candidateid,candidatename,candidatehouse) values('" + textBox2.Text + "','" + label5.Text + "','" + label6.Text + "','" + comboBox1.Text + "')", conn1);
                    cmd1.ExecuteNonQuery();

                    settext = textBox1.Text;
                    this.Hide();
                    Form1 fm = new Form1();
                    fm.Show();
                    MessageBox.Show("YOU HAVE SUCCESFFULLY CASTED YOUR VOTE!!");

                }
                else
                {
                    MessageBox.Show("PLEASE CHECK ADHARID  AND PASSWORD");
                }
            }catch(Exception)
            {
                MessageBox.Show("YOU HAVE ALREADY CASTED YOUR VOTE & YOU CANNOT VOTE MULTIPLE TIME");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        { 
            panel2.Visible = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            this.Hide() ;
            Form1 fm = new Form1();
            fm.Show();
        }
    }
}
