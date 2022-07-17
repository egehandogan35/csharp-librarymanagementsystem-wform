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
    public partial class ViewBook : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=**
        {
            
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comd = con.CreateCommand();
            comd.CommandType = CommandType.Text;
            comd.CommandText = "select * from books ";
            comd.ExecuteNonQuery();
            DataTable cd = new DataTable();
            SqlDataAdapter ca = new SqlDataAdapter(comd);
            ca.Fill(cd);
           
            dataGridView1.DataSource = cd;

            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comd = con.CreateCommand();
            comd.CommandType = CommandType.Text;
            comd.CommandText = "select * from books where bookname like ('%" + textBox1.Text + "%') ";
            comd.ExecuteNonQuery();
            DataTable cd = new DataTable();
            SqlDataAdapter ca = new SqlDataAdapter(comd);
            ca.Fill(cd);
            dataGridView1.DataSource = cd;

            con.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            SqlCommand comd = con.CreateCommand();
            comd.CommandType = CommandType.Text;
            comd.CommandText = "select * from books where bookname like ('%" + textBox1.Text + "%') ";
            comd.ExecuteNonQuery();
            DataTable cd = new DataTable();
            SqlDataAdapter ca = new SqlDataAdapter(comd);
            ca.Fill(cd);
            dataGridView1.DataSource = cd;

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand comd = con.CreateCommand();
            comd.CommandType = CommandType.Text;
            comd.CommandText = "select * from books where bookauthor like ('%" + textBox2.Text + "%') ";
            comd.ExecuteNonQuery();
            DataTable cd = new DataTable();
            SqlDataAdapter ca = new SqlDataAdapter(comd);
            ca.Fill(cd);
            dataGridView1.DataSource = cd;

            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                MessageBox.Show(i.ToString());

                con.Open();
                SqlCommand comd = con.CreateCommand();
                comd.CommandType = CommandType.Text;
                comd.CommandText = "select * from books where Id=" + i + "";
                comd.ExecuteNonQuery();
                DataTable cd = new DataTable();
                SqlDataAdapter ca = new SqlDataAdapter(comd);
                ca.Fill(cd);
                foreach (DataRow cr in cd.Rows)
                {
                    textBox3.Text = cr["bookname"].ToString();
                    textBox4.Text = cr["bookauthor"].ToString();
                    textBox6.Text = cr["booktype"].ToString();
                    dateTimePicker2.Value = Convert.ToDateTime(cr["publishdate"].ToString());

                }

                con.Close();
            } catch(Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           
            
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {

                SqlCommand comd = con.CreateCommand();
                SqlCommand myCommand = default(SqlCommand);

                myCommand = new SqlCommand("update books set bookname=@bookname, bookauthor=@bookauthor, booktype=@booktype, publishdate=@publishdate where Id=" + i +"", con);


                SqlParameter bookname = new SqlParameter("@bookname", SqlDbType.VarChar);
                SqlParameter bookauthor = new SqlParameter("@bookauthor", SqlDbType.VarChar);
                SqlParameter booktype = new SqlParameter("@booktype", SqlDbType.VarChar);
                SqlParameter publishdate = new SqlParameter("@publishdate", SqlDbType.Date);



                bookname.Value = textBox3.Text;
                bookauthor.Value = textBox4.Text;
                booktype.Value = textBox6.Text;
                publishdate.Value = dateTimePicker2.Text;
                myCommand.Parameters.Add(bookname);
                myCommand.Parameters.Add(bookauthor);
                myCommand.Parameters.Add(booktype);
                myCommand.Parameters.Add(publishdate);

                myCommand.Connection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);


                if (textBox3.Text != null && textBox4.Text != null && textBox6.Text != null && dateTimePicker2.Text != null )
                {

                   
                    MessageBox.Show("updated");
                   

                }
                if (con.State == ConnectionState.Open)
                {
                    con.Dispose();
                }



            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
        }
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comd = con.CreateCommand();
            comd.CommandType = CommandType.Text;
            comd.CommandText = "delete from books where Id = "+textBox5.Text+" ";
             comd.ExecuteNonQuery();
            DataTable cd = new DataTable();
            SqlDataAdapter ca = new SqlDataAdapter(comd);
            ca.Fill(cd);
            dataGridView1.DataSource = cd;
            MessageBox.Show("Book deleted");

            con.Close();


        }
    }
}
