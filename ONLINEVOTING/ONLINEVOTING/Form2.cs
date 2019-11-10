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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\DBMS MINI PROJECT\ONLINEVOTING\ONLINEVOTING\onlinevoting.mdf; Integrated Security = True");
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("insert into DATE(adharid) values('" + textBox1.Text +  "')", conn1);
            cmd1.ExecuteNonQuery();

           
            MessageBox.Show("YOU HAVE SUCCESFFULLY CASTED YOUR VOTE!!");
        }
    }
}
