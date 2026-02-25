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


namespace New_Db_Project
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }
        
        private void LoadDataIntoDataGridView()
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Books";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            int bookId, authorId, genreId, publisherId, publicationYear;
            if (!int.TryParse(textBox1.Text, out bookId) ||
                !int.TryParse(textBox3.Text, out authorId) ||
                !int.TryParse(textBox4.Text, out genreId) ||
                !int.TryParse(textBox5.Text, out publisherId) ||
                !int.TryParse(textBox6.Text, out publicationYear))
            {
                MessageBox.Show("Invalid input. Please enter valid numeric values.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO Books (book_id, title, author_id, genre_id, publisher_id, publication_year) VALUES (@book_id, @title, @author_id, @genre_id, @publisher_id, @publication_year)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@book_id", bookId);
                    cmd.Parameters.AddWithValue("@title", textBox2.Text);
                    cmd.Parameters.AddWithValue("@author_id", authorId);
                    cmd.Parameters.AddWithValue("@genre_id", genreId);
                    cmd.Parameters.AddWithValue("@publisher_id", publisherId);
                    cmd.Parameters.AddWithValue("@publication_year", publicationYear);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data Saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Books SET title=@title, author_id=@author_id, genre_id=@genre_id, publisher_id=@publisher_id, publication_year=@publication_year WHERE book_id=@book_id", con);
                cmd.Parameters.AddWithValue("@book_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@title", textBox2.Text);
                cmd.Parameters.AddWithValue("@author_id", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@genre_id", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@publisher_id", int.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@publication_year", int.Parse(textBox6.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Updated");

                con.Close();
            }
        }

        //private void button4_Click_1(object sender, EventArgs e)
        //{
        //    string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();

        //        SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE book_id=@book_id", con);
        //        cmd.Parameters.AddWithValue("@book_id", int.Parse(textBox1.Text));
        //        cmd.ExecuteNonQuery();

        //        MessageBox.Show("Data Deleted");

        //        con.Close();
        //    }
        //}
        private void button4_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Check if textBox1.Text is a valid integer
                    if (int.TryParse(textBox1.Text, out int bookId))
                    {
                        SqlCommand cmd = new SqlCommand("DELETE FROM Books WHERE book_id=@book_id", con);
                        cmd.Parameters.AddWithValue("@book_id", bookId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Deleted");
                        }
                        else
                        {
                            MessageBox.Show("No data found for the provided Book ID.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid Book ID.");
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }
}
