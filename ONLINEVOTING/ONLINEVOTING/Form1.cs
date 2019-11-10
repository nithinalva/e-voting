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

namespace ONLINEVOTING
{
    public partial class Form1 : Form
    {
        public static string  settext="";
        public Form1()

        {
            InitializeComponent();
            textBox4.PasswordChar = '*';
            textBox2.PasswordChar = '*';

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel10.Visible = true;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = true;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (panel2.Width == 50)
            {
                panel2.Visible = false;
                panel2.Width = 243;
                panelanimation.ShowSync(panel2);



            }
            else
            {
                panel2.Visible = false;
                panel2.Width = 50;
                panelanimation.ShowSync(panel2);

            }

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;


        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel8.Visible = true;
            panel7.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;


        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
            conn.Open();
            string newconn = "select fname,lname,fathername,mothername,phone,address,adharid,gender,dob,password from voter where adharid ='" + textBox3.Text + "'and password='" + textBox4.Text + "'";
            SqlCommand cmd = new SqlCommand(newconn, conn);
            SqlDataAdapter adp = new SqlDataAdapter(newconn, conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if(dt.Rows.Count>=1)
            {
                MessageBox.Show("LOGIN SUCCESSFULL");
                settext =textBox3.Text;
                voterwindow vw = new voterwindow();
                vw.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("PLEASE CHECH USER NAME AND PASSWORD");
            }

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            VOTERREGISTRATION VR = new VOTERREGISTRATION();
            VR.Show();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuTextbox3_OnTextChange(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            panel9.Visible= true;
            panel7.Visible = false;
            panel8.Visible = false;
            panel10.Visible = false;


        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("PLEASEE ENTER THE USERNAME AND PASSWORD");
            }
            else
            {
                SqlConnection conn1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
               
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) From Admin where username ='" + textBox1.Text + "'and password ='" + textBox2.Text + "'",conn1);
                DataTable dt=new DataTable();
                sda.Fill(dt);
                if(dt.Rows[0][0].ToString()=="1")
                



                {
                    MessageBox.Show("LOGIN SUCCESSFULL");
                    
                    
                    this.Hide();
                    REGISTER rg = new REGISTER();
                    rg.Show();

                }
                else
                {
                    MessageBox.Show("Please enter correct username and password");
                }
            }
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel9.Visible = false;
            panel8.Visible = false;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/nithin.merciless.5");
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://instagram.com/callme_m_e_r_c_y?utm_source=ig_profile_share&igshid=1o6w6d2b92em7");
        }
        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/vaibhav.talreja");
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://instagram.com/vaibhav7talreja?utm_source=ig_profile_share&igshid=vr3z89rpvguk");
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

