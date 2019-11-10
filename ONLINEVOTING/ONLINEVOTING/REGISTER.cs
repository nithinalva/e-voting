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
    public partial class REGISTER : Form
    {
        public REGISTER()
        {
            InitializeComponent();
            
            
            
            
            
        }


    
        private void bunifuTextbox3_OnTextChange(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void REGISTER_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {


                if (textBox1.Text == "" || textBox8.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" ||textBox7.Text ==""|| dateTimePicker1.Text == "" )
                {
                    MessageBox.Show("PLEASE INSERT THE NECESSARY DETAILS");
                    this.Show();

                }
                else
                {
                    FileStream fs1 = new FileStream(textBox9.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    byte[] image = new byte[fs1.Length];
                    fs1.Read(image, 0, Convert.ToInt32(fs1.Length));
                    fs1.Close();
                    SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into adhardetails(fname,lname,fathername,mothername,phone,address,adharid,gender,dob,image) values ('" + textBox1.Text + "','" + textBox8.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "', '" + textBox4.Text + "','" + textBox7.Text + "','"+ comboBox1.Text + "','" + dateTimePicker1.Text + "',@pic)", conn);
                    SqlParameter prm = new SqlParameter("@pic", SqlDbType.VarBinary, image.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, image);
                    cmd.Parameters.Add(prm);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Aadhar successfully created");

                    textBox1.Text ="";
                    textBox8.Text ="";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    comboBox1.Text = "";
                    textBox7.Text = "";
                    textBox9.Text = "";
                    pictureBox1.Image = null;
                    dateTimePicker1.Text ="";







                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog Dialog = new OpenFileDialog { Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp", Title = "OpenFile Dialog", RestoreDirectory = true })
            {

                if (Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    pictureBox1.Image = new Bitmap(Dialog.FileName);
                    textBox9.Text = Dialog.FileName;

                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            label10.Visible = false;
            label12.Visible = false;
            label13.Visible = true;
            label14.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            label10.Visible = true;
            label11.Visible = false;
            panel3.Visible = true;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel8.Visible = false;
           
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
            label10.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel8.Visible = true;
            panel5.Visible = true;
            panel6.Visible = false;
           


        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            panel5.Visible = true;
            label11.Visible = false;
            label10.Visible = false;
            label12.Visible = true;
            label13.Visible = false;
            label14.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel8.Visible = false;
            panel6.Visible = false;
            panel6.Visible = false;
            

        }

        private void label13_Click(object sender, EventArgs e)
        {
         
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            label11.Visible = false;
            label10.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = true;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel6.Visible = false;
            
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Update();

                DateTime BirthDate = DateTime.Parse(dateTimePicker2.Text);
                DateTime CurrentDate = DateTime.Today;
                int Age = CurrentDate.Year - BirthDate.Year;
                if (Age < 25)
                {
                    MessageBox.Show("THE CANDIDATE IS NOT ELIGIBLE FOR CONTESTING  the MINIMUM AGE for contesting is 25");
                }

                else
                {

                    if (textBox6.Text == "" || textBox10.Text == "" || textBox12.Text == "" || dateTimePicker2.Text == "" || textBox11.Text == "" || textBox15.Text == "" || comboBox3.Text == "" || comboBox2.Text == "" || textBox13.Text == "")

                    {
                        MessageBox.Show("PLEASE INSERT THE NECESSARY DETAILS");
                        this.Show();
                    }
                    else
                    {
                        FileStream fs1 = new FileStream(textBox13.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        byte[] image = new byte[fs1.Length];
                        fs1.Read(image, 0, Convert.ToInt32(fs1.Length));
                        fs1.Close();
                        SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("Insert into candidatedetails(fname,lname,candidateid,dob,address,phone,gender,bloodgroup,image) values ('" + textBox6.Text + "','" + textBox10.Text + "','" + textBox12.Text + "','" + dateTimePicker2.Text + "','" + textBox11.Text + "', '" + textBox15.Text + "','" + comboBox3.Text + "','" + comboBox2.Text + "',@pic)", conn);
                        SqlParameter prm = new SqlParameter("@pic", SqlDbType.VarBinary, image.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, image);
                        cmd.Parameters.Add(prm);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("canidate successfully registered");
                    }
                }

                }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog Dialog = new OpenFileDialog { Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp", Title = "OpenFile Dialog", RestoreDirectory = true })
            {

                if (Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    pictureBox2.Image = new Bitmap(Dialog.FileName);
                    textBox13.Text = Dialog.FileName;

                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = dateTimePicker2.Value;
            DateTime to = DateTime.Now;
            TimeSpan tspan = to - from;
            double days = tspan.TotalDays;
            label24.Visible = true;
            label24.Text = (days / 360).ToString("0");

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(bunifuCustomDataGrid1.Columns[e.ColumnIndex].Name== "VIEW")
            {
                ADHARPRINT AR = new ADHARPRINT();
                AR.label1.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
                AR.label10.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
                AR.label16.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
                AR.label12.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
                AR.label13.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
                AR.label14.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[7].Value.ToString();
                AR.label15.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[8].Value.ToString();
                AR.label11.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[9].Value.ToString();
                AR.label18.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[10].Value.ToString();
                byte[] bytes = (byte[])bunifuCustomDataGrid1.CurrentRow.Cells[11].Value;
                MemoryStream ms = new MemoryStream(bytes);
                AR.pictureBox1.Image = Image.FromStream(ms);

                AR.ShowDialog();
            }

            if (bunifuCustomDataGrid1.Columns[e.ColumnIndex].Name == "MODIFY")
            {
                ADHARUPDATEcs AU = new ADHARUPDATEcs();
                AU.textBox1.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
                AU.textBox2.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
                AU.textBox3.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
                AU.textBox4.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
                AU.textBox5.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
                AU.textBox6.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[7].Value.ToString();
                AU.label11.Text= this.bunifuCustomDataGrid1.CurrentRow.Cells[8].Value.ToString();
                AU.comboBox1.Text= this.bunifuCustomDataGrid1.CurrentRow.Cells[9].Value.ToString();
                AU.dateTimePicker1.Text= this.bunifuCustomDataGrid1.CurrentRow.Cells[10].Value.ToString();
                byte[] bytes = (byte[])bunifuCustomDataGrid1.CurrentRow.Cells[11].Value;
                MemoryStream ms = new MemoryStream(bytes);
                AU.pictureBox1.Image = Image.FromStream(ms);
                AU.ShowDialog();
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
            conn.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(" select fname,lname,fathername,mothername,phone,address,adharid,gender,dob,image,createdon from adhardetails", conn);
            DataTable data = new DataTable();
            SDA.Fill(data);
            bunifuCustomDataGrid1.DataSource = data;
            conn.Close();
            VIEW.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
            SqlDataAdapter sda = new SqlDataAdapter("Select *from candidatedetails where candidateid ='" + textBox18.Text + "'", conn);
            SqlCommand cmd = new SqlCommand("Select *from candidatedetails where candidateid ='" + textBox18.Text + "'", conn);

            try
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);


                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader myReader;
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    string fname = (string)myReader["fname"].ToString();
                    string lname = (string)myReader["lname"].ToString();
                    string candidateid = (string)myReader["candidateid"].ToString();
                  

                    textBox14.Text = fname;
                    textBox16.Text = lname;





                }
                byte[] data = (byte[])dt.Rows[0]["IMAGE"];
                MemoryStream ms = new MemoryStream(data);
                pictureBox3.Image = Image.FromStream(ms);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox18.Text ==""||textBox14.Text==""||textBox16.Text==""||textBox17.Text=="")
                {
                    MessageBox.Show("PLEASE FILL THE REQUIRED FIELDS");
                }
                else
                {

                    FileStream fs1 = new FileStream(textBox19.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    byte[] image = new byte[fs1.Length];
                    fs1.Read(image, 0, Convert.ToInt32(fs1.Length));
                    fs1.Close();
                    SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into CONTESTING(candidateid,fname,lname,party,image) values ('" + textBox18.Text + "','" + textBox14.Text + "','" + textBox16.Text + "','" + textBox17.Text + "',@pic)", conn);
                    SqlParameter prm = new SqlParameter("@pic", SqlDbType.VarBinary, image.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, image);
                    cmd.Parameters.Add(prm);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("CANDIDATE PARTY HAS BEEN SUCCESSFULLY REGISTERED ALL THE BEST!!");
                    textBox18.Text = "";
                    textBox14.Text = "";
                    textBox16.Text = "";
                    textBox17.Text = "";

                }
            }
            catch (Exception )
            {
                MessageBox.Show("CANDIDATE HAS ALREADY REGISTERED ");
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog Dialog = new OpenFileDialog { Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp", Title = "OpenFile Dialog", RestoreDirectory = true })
            {

                if (Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    pictureBox4.Image = new Bitmap(Dialog.FileName);
                    textBox19.Text = Dialog.FileName;

                }
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint_1(object sender, PaintEventArgs e)
        {
            SqlConnection conn1=new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
            conn1.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select candidatehouse, count(adharid) as votes from result group by candidatehouse",conn1);
            DataTable data = new DataTable();
            sda.Fill(data);
            bunifuCustomDataGrid2.DataSource = data;
            conn1.Close();


        }

        private void bunifuCustomDataGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            
           

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fr = new Form1();
            fr.Show();
        }

        private void bunifuFlatButton11_Click_1(object sender, EventArgs e)
        {
            String constring = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True";
            String Query = "delete from result";

            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDatabase);
            SqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("DATA HAS BEEN RESET");
             



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

