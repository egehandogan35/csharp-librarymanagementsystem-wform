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

namespace deneme
{

    public partial class Register : Form
    {
       
        SqlConnection con = new SqlConnection(@"Data Source=**
        public Register()
        {
            InitializeComponent();
            member.Memberrole = 2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand comd = con.CreateCommand();
                comd.CommandType = CommandType.Text;
                comd.CommandText = "insert into person (username,password,memberrole) Values ('" + textBox1.Text + "', '" + textBox2.Text + "','"+member.Memberrole+"')";
                comd.ExecuteNonQuery();

                MessageBox.Show("Registered");
                con.Close();
                this.Hide();
                Login ms = new Login();
                ms.Show();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }

        }
    }
}
