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
    public partial class memberscreen : Form
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=**
        public memberscreen()
        {


            InitializeComponent();
            textBox3.Text = person.Username;
            textBox7.Text = person.Username;
           
           
            
        }

        private void memberscreen_Load(object sender, EventArgs e)
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

            SqlCommand comd2 = con.CreateCommand();
            comd2.CommandType = CommandType.Text;
            comd2.CommandText = "select * from rentbooks ";
            comd2.ExecuteNonQuery();
            DataTable ed = new DataTable();
            SqlDataAdapter ab = new SqlDataAdapter(comd2);
            ab.Fill(ed);

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
                    textBox1.Text = cr["bookname"].ToString();
                    textBox2.Text = cr["bookauthor"].ToString();
                    textBox6.Text = cr["Id"].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(cr["publishdate"].ToString());
                    textBox8.Text = cr["booktype"].ToString();

                }

                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
        }
       

        public void button1_Click(object sender, EventArgs e)
        {
            con.Open();
           

            SqlCommand comd2 = con.CreateCommand();
            comd2.CommandType = CommandType.Text;
            comd2.CommandText = "SELECT * FROM person where username = '" + textBox3.Text + "' ";
            comd2.ExecuteNonQuery();

            DataTable ed = new DataTable();
            SqlDataAdapter ab = new SqlDataAdapter(comd2);
            ab.Fill(ed);
            count = Convert.ToInt32(ed.Rows.Count.ToString());
            if (count != 0)
            {

                foreach (DataRow er in ed.Rows)
                {
                    person.Penalty = 0;
                    string a = er["penalty"].ToString();
                    string b = person.Penalty.ToString();

                    con.Close();

                    if (a == b)
                    {
                        con.Open();
                        SqlCommand comd = con.CreateCommand();
                        SqlCommand myCommand = default(SqlCommand);

                        myCommand = new SqlCommand("INSERT INTO rentbooks(bookname, bookin, bookout, username) VALUES(@bookname, @bookin, @bookout,@username)", con);

                        SqlParameter bookname = new SqlParameter("@bookname", SqlDbType.VarChar);
                        SqlParameter bookin = new SqlParameter("@bookin", SqlDbType.DateTime);
                        SqlParameter bookout = new SqlParameter("@bookout", SqlDbType.DateTime);
                        SqlParameter username = new SqlParameter("@username", SqlDbType.VarChar);

                        bookname.Value = textBox1.Text;
                        bookin.Value = System.DateTime.Now;
                        bookout.Value = System.DateTime.Now.AddDays(14);


                        username.Value = textBox3.Text;
                        textBox3.Text = person.Username;
                        rentbooks.Bookout = System.DateTime.Now.AddDays(14);
                        myCommand.Parameters.Add(bookname);
                        myCommand.Parameters.Add(bookin);
                        myCommand.Parameters.Add(bookout);
                        myCommand.Parameters.Add(username);

                        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                        if (textBox1.Text != null && textBox2.Text != null)
                        {
                            MessageBox.Show("Rented");
                            this.Hide();
                            memberscreen ms = new memberscreen();
                            ms.Show();

                        }

                        else
                        {
                            MessageBox.Show("Renting Failed");

                            textBox1.Focus();

                        }
                       
                       

                    }
                    else
                    {
                        MessageBox.Show("You cant rent ");
                        this.Hide();
                    }
                }
            }
            if (con.State == ConnectionState.Open)
            {
                con.Dispose();
            }

        }




        public void button3_Click(object sender, EventArgs e)
        {
          
            if (textBox7.Text == textBox4.Text)
            {

                con.Open();
                int i = 0;
                rentbooks.Bookreturn = System.DateTime.UtcNow;
                




                SqlCommand comd3 = con.CreateCommand();
            comd3.CommandType = CommandType.Text;
            comd3.CommandText = "update rentbooks set bookreturn = '" + rentbooks.Bookreturn + "' where username = '" + textBox4.Text + "' and bookname ='"+textBox5.Text+"' ";
            comd3.ExecuteNonQuery();
            

                SqlCommand comd2 = con.CreateCommand();
                comd2.CommandType = CommandType.Text;
                comd2.CommandText = "select * from rentbooks where username  = '" + textBox4.Text + "' ";
                comd2.ExecuteNonQuery();
                DataTable ed = new DataTable();
                SqlDataAdapter ab = new SqlDataAdapter(comd2);
                ab.Fill(ed);
                dataGridView2.DataSource = ed;
                con.Close();
                i = Convert.ToInt32(ed.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show(" you have no books to show");
                }
            }
            else
            {
                MessageBox.Show("You dont have access ");
            }

        }
        public void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand comd3 = con.CreateCommand();
            comd3.CommandType = CommandType.Text;
            comd3.CommandText = "SELECT * FROM rentbooks where username = '" + textBox3.Text + "' ";
            comd3.ExecuteNonQuery();
            DataTable ed = new DataTable();
            SqlDataAdapter ab = new SqlDataAdapter(comd3);
            ab.Fill(ed);
            count = Convert.ToInt32(ed.Rows.Count.ToString());
            if (count != 0)
            {


                if (DateTime.Parse(dateTimePicker5.Text) < DateTime.Parse(dateTimePicker4.Text))
                {

                    
                    SqlCommand comd = con.CreateCommand();
                    comd.CommandType = CommandType.Text;
                    comd.CommandText = "delete from rentbooks where username  = '" + textBox4.Text + "' and bookname = '" + textBox5.Text + "' ";
                    comd.ExecuteNonQuery();
                    MessageBox.Show("You returned book, thank you");
                    con.Close();
                    this.Hide();
                    memberscreen ms = new memberscreen();
                    ms.Show();
                }
                else
                {

                    
                    SqlCommand comd = con.CreateCommand();
                    comd.CommandType = CommandType.Text;
                    comd.CommandText = "delete from rentbooks where username  = '" + textBox4.Text + "' and bookname = '" + textBox5.Text + "' ";
                    comd.ExecuteNonQuery();
                    MessageBox.Show("You returned book later than deadline, you got penalty.");
                    SqlCommand comd2 = con.CreateCommand();
                    comd2.CommandType = CommandType.Text;
                    comd2.CommandText = "Update person SET penalty = '1'  where username  = '" + textBox4.Text + "' ";
                    comd2.ExecuteNonQuery();
                    con.Close();
                    person.Penalty = 1;
                    this.Hide();
                    memberscreen ms = new memberscreen();
                    ms.Show();

                }
              
            }
            else
            {
                MessageBox.Show("You have no book");
            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
        

            
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
                
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
            }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int b;
            b = Convert.ToInt32(dataGridView2.SelectedCells[0].Value.ToString());

            try
            {



                MessageBox.Show(b.ToString());

                con.Open();
              
                SqlCommand comd2 = con.CreateCommand();
                comd2.CommandType = CommandType.Text;
                comd2.CommandText =  "SELECT * FROM rentbooks where username = '" + textBox4.Text+"' and Id = "+b+" ";
                comd2.ExecuteNonQuery();
               
                DataTable ed = new DataTable();
                SqlDataAdapter ab = new SqlDataAdapter(comd2);
                ab.Fill(ed);
              
               




                foreach (DataRow er in ed.Rows)
                {
                    textBox5.Text = er["bookname"].ToString();
                   
                    dateTimePicker3.Text = er["bookin"].ToString();
                    dateTimePicker4.Text = er["bookout"].ToString();
                    dateTimePicker5.Text = er["bookreturn"].ToString();
                   
                }
                



                con.Close();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
        }
       
       
    }
    }
    



