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
    public partial class AddBook : Form
    {
        SqlConnection con = new SqlConnection**
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comd = con.CreateCommand();
            SqlCommand myCommand = default(SqlCommand);

            myCommand = new SqlCommand("INSERT INTO books( bookname, bookauthor, booktype, publishdate) VALUES( @bookname, @bookauthor, @booktype, @publishdate)", con);

          
            SqlParameter bookname = new SqlParameter("@bookname", SqlDbType.VarChar);
            SqlParameter bookauthor = new SqlParameter("@bookauthor", SqlDbType.VarChar);
            SqlParameter booktype = new SqlParameter("@booktype", SqlDbType.VarChar);
            SqlParameter publishdate = new SqlParameter("@publishdate", SqlDbType.Date);



            bookname.Value = textBox1.Text;
            bookauthor.Value = textBox2.Text;
            booktype.Value = textBox3.Text;
            publishdate.Value = dateTimePicker2.Text;
            myCommand.Parameters.Add(bookname);
            myCommand.Parameters.Add(bookauthor);
            myCommand.Parameters.Add(booktype);
            myCommand.Parameters.Add(publishdate);


            SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && dateTimePicker2.Text != null )
            {
                MessageBox.Show("Book Added");
                this.Hide();
            }

            else
            {
                MessageBox.Show("Adding Failed!");

                textBox1.Focus();

            }
            if (con.State == ConnectionState.Open)
            {
                con.Dispose();
            }

        }
    }
}
