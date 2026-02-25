using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace New_Db_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void LoadDataIntoDataGridView()
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Returns";
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

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Returns (return_id, borrowing_id, return_date,fine_id ) VALUES (@return_id, @borrowing_id, @return_date,@fine_id)", con);
                cmd.Parameters.AddWithValue("@Return_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Borrowing_id", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Return_Date", DateTime.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Fine_id", int.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Saved");

                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Returns SET return_id=@return_id, borrowing_id=@borrowing_id, return_date=@return_date,fine_id=@fine_id WHERE return_id=@return_id", con);
                cmd.Parameters.AddWithValue("@return_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@borrowing_id", textBox2.Text);
                cmd.Parameters.AddWithValue("@return_date", DateTime.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@fine_id", int.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Updated");

                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Returns WHERE return_id=@return_id", con);
                cmd.Parameters.AddWithValue("@return_id", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Deleted");

                con.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
