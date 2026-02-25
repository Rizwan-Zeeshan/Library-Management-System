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
    public partial class Fine : Form
    {
        public Fine()
        {
            InitializeComponent();
        }

        private void LoadDataIntoDataGridView()
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Fines";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Fines (fine_id, borrowing_id, fine_amount, paid) VALUES (@fine_id, @borrowing_id, @fine_amount, @paid)", con);
                cmd.Parameters.AddWithValue("@Fine_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Borrowing_id", textBox2.Text);
                cmd.Parameters.AddWithValue("@Fine_amount", decimal.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Paid", int.Parse(textBox4.Text));
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

                SqlCommand cmd = new SqlCommand("UPDATE Fines SET fine_id=@fine_id, borrowing_id=@borrowing_id, fine_amount=@fine_amount,paid=@paid WHERE fine_id=@fine_id", con);
                cmd.Parameters.AddWithValue("@fine_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@borrowing_id", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@fine_amount", double.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@paid", int.Parse(textBox4.Text));
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

                SqlCommand cmd = new SqlCommand("DELETE FROM Fines WHERE fine_id=@fine_id", con);
                cmd.Parameters.AddWithValue("@fine_id", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Deleted");

                con.Close();
            }
        }
    }
}


