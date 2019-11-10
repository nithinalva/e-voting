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
    public partial class VOTERREGISTRATION : Form
    {
        public VOTERREGISTRATION()
        {
            InitializeComponent();
            textBox9.PasswordChar = '*';
            textBox8.PasswordChar = '*';
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
            SqlDataAdapter sda=new  SqlDataAdapter("Select * from adhardetails where adharid ='" + bunifuTextbox1.text + "'", conn);
            SqlCommand cmd = new SqlCommand("Select * from adhardetails where adharid ='" + bunifuTextbox1.text + "'",conn);
           
            SqlDataReader myReader;
            
            try
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                
                conn.Open();
                cmd.ExecuteNonQuery();
                myReader = cmd.ExecuteReader();
                while(myReader.Read())
                {
                    string fname = (string)myReader["fname"].ToString();
                    string lname = (string)myReader["lname"].ToString();
                    string fathername = (string)myReader["fathername"].ToString();
                    string mothername = (string)myReader["mothername"].ToString();
                    string phone = (string)myReader["phone"].ToString();
                    string address = (string)myReader["address"].ToString();
                    string gender = (string)myReader["gender"].ToString();
                    string dob = (string)myReader["dob"].ToString();
                    textBox1.Text = fname;
                    textBox6.Text = lname;
                    textBox2.Text = fathername;
                    textBox3.Text = mothername;
                    textBox4.Text = phone;
                    textBox5.Text = address;
                    textBox7.Text = gender;
                    dateTimePicker1.Text = dob;




                }
                byte[] data= (byte[])dt.Rows[0]["IMAGE"];
                MemoryStream ms = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(ms);


            }catch(Exception)
            {
                MessageBox.Show("WRONG ADHAR ID !!! please Check the ADHAR ID");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            
          
        }

        private void bunifuTextbox3_OnTextChange(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker1.Value;
            DateTime to = DateTime.Now;
            TimeSpan tspan = to - from;
            double days = tspan.TotalDays;
            label11.Visible = true;
            label11.Text = (days / 360).ToString("0");


        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Update();

                DateTime BirthDate = DateTime.Parse(dateTimePicker1.Text);
                DateTime CurrentDate = DateTime.Today;
                int Age = CurrentDate.Year - BirthDate.Year;
                if (Age < 18)
                {
                    MessageBox.Show("SORRY YOU ARE NOT ELIGIBLE FOR CASTING VOTE ,the minimum Age for Voting is 18 and above");
                }

                else
                {
                    if (textBox9.Text != textBox8.Text)
                    {
                        MessageBox.Show("PASSWORD DIDNOT MATCH !! PLEASE RE-ENTTER THE PASSWORD");

                    }

                    else
                    {
                        if (textBox9.Text == "" || bunifuTextbox1.text == "")
                        {
                            MessageBox.Show("PLEASE INSERT THE NECESSARY DETAILS");
                            this.Show();

                        }


                        else
                        {


                            SqlConnection conn1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
                            conn1.Open();
                            SqlCommand cmd = new SqlCommand("AddVoter", conn1);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@fname", textBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@lname", textBox6.Text.Trim());

                            cmd.Parameters.AddWithValue("@fathername", textBox2.Text.Trim());
                            cmd.Parameters.AddWithValue("@mothername", textBox3.Text.Trim());
                            cmd.Parameters.AddWithValue("@phone", textBox4.Text.Trim());
                            cmd.Parameters.AddWithValue("@address", textBox5.Text.Trim());
                            cmd.Parameters.AddWithValue("@adharid", bunifuTextbox1.text.Trim());
                            cmd.Parameters.AddWithValue("@gender", textBox7.Text.Trim());
                            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", textBox9.Text.Trim());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("VOTER SUCCESSFULLY REGISTERED");
                            this.Hide();
                            Form1 R1 = new Form1();
                            R1.Show();

                        }

                        }
                    
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
