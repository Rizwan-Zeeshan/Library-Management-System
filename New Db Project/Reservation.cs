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
using Microsoft.VisualBasic;

namespace New_Db_Project
{
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
        }

        private void LoadDataIntoDataGridView()
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Reservations";
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

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Reservations (reservation_id, book_id, member_id, reservation_date) VALUES (@reservation_id, @book_id, @member_id, @reservation_date)", con);
                cmd.Parameters.AddWithValue("@Reservation_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Book_id", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Member_Id", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Reservation_date", DateTime.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Saved");

                con.Close();
            }
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

                SqlCommand cmd = new SqlCommand("UPDATE Reservations SET reservation_id=@reservation_id, book_id=@book_id, member_id=@member_id,reservation_date=@reservation_date WHERE reservation_id=@reservation_id", con);
                cmd.Parameters.AddWithValue("@reservation_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Book_id", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Member_id;", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Reservation_date",DateTime.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Updated");

                con.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Reservations WHERE reservation_id=@reservation_id", con);
                cmd.Parameters.AddWithValue("@reservation_id", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Deleted");

                con.Close();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }
    }
}
