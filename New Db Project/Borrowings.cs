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
    public partial class Borrowings : Form
    {
        public Borrowings()
        {
            InitializeComponent();
        }

        private void LoadDataIntoDataGridView()
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Borrowings";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Borrowings SET borrowing_id=@borrowing_id, book_id=@book_id, member_id=@member_id, borrow_date=@borrow_date, return_date=@return_date,due_date=@due_date WHERE borrowing_id=@borrowing_id", con);
                cmd.Parameters.AddWithValue("@borrowing_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@book_id", textBox2.Text);
                cmd.Parameters.AddWithValue("@member_id", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@borrow_date", DateTime.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@return_date", DateTime.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@due_date", DateTime.Parse(textBox6.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");

                con.Close();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Borrowings (borrowing_id, book_id, member_id, borrow_date, return_date, due_date) VALUES (@borrowing_id, @book_id, @member_id, @borrow_date, @return_date, @due_date)", con);
                cmd.Parameters.AddWithValue("@Borrowing_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Book_Id", textBox2.Text);
                cmd.Parameters.AddWithValue("@Member_id", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Borrow_date", DateTime.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@Return_date", DateTime.Parse(textBox5.Text));
                cmd.Parameters.AddWithValue("@Due_date", DateTime.Parse(textBox6.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Saved");

                con.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Borrowings WHERE borrowing_id=@borrowing_id", con);
                cmd.Parameters.AddWithValue("@borrowing_id", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Deleted");

                con.Close();
            }
        }
    }
}
