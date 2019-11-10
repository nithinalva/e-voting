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
    public partial class ADHARUPDATEcs : Form
    {
        public ADHARUPDATEcs()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuFlatButton3.Visible = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true; 
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
           




        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            dateTimePicker1.Enabled = false ;
            comboBox1.Enabled = false;


            String constring = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True";
            String Query="delete from adhardetails where adharid ='"+this.label11.Text+ "'";

            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("DELTED SUCCESSFULLY");
                this.Hide();
               


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            String constring = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True";
            String Query = "update adhardetails set fname = '" + textBox1.Text + "',lname = '" + textBox2.Text + "',fathername = '" + textBox3.Text + "',mothername = '" + textBox4.Text + "',phone = '" + textBox5.Text + "',address= '" + textBox6.Text + "',dob= '" + dateTimePicker1.Text + "',gender = '" + comboBox1.Text +"'where adharid='"+label11.Text+ "'";

            SqlConnection conDatabase1 = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase1);
            SqlDataReader myReader;
            try
            {
                conDatabase1.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("updated SUCCESSFULLY");

                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                dateTimePicker1.Enabled = false;
                comboBox1.Enabled = false;
                bunifuFlatButton3.Visible = false;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
