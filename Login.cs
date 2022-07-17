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
    
    public partial class Login : Form
    {


        SqlConnection con = new SqlConnection(@"Data Source=**
        public Login()
        {
            InitializeComponent();
            member.Memberrole = 2;
            librarian.Memberrole = 1;
            
        }
        private void Login_Load_1(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            SqlCommand comd = con.CreateCommand();
            comd.CommandType = CommandType.Text;
            comd.CommandText = "select * from person where username = '" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            comd.ExecuteNonQuery();
            DataTable cd = new DataTable();
            SqlDataAdapter ca = new SqlDataAdapter(comd);
            ca.Fill(cd);
            person.Username = textBox1.Text;
            count = Convert.ToInt32(cd.Rows.Count.ToString());
            if (count == 0)
            {
                MessageBox.Show("Login Failed");
                this.Close();

            }
            else
            {
                foreach (DataRow cr in cd.Rows)
                {
                    string a = cr["memberrole"].ToString();
                    string b = librarian.Memberrole.ToString();

                    if (a==b)
                    {
                        MessageBox.Show("Librarian login successful");
                        MDIParent1 mp = new MDIParent1();
                        mp.Show();
                        this.Hide();

                    }

                    else
                    {
                        MessageBox.Show("Member login successful");
                        memberscreen ms = new memberscreen();
                        ms.Show();
                        this.Hide();
                    }
                }
            }
        }
    

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            Register re = new Register();
            re.Show();
        }
    }
}
