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
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
        }

        private void LoadDataIntoDataGridView()
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Members";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Members WHERE member_id=@member_id", con);
                cmd.Parameters.AddWithValue("@member_id", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Deleted");

                con.Close();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Members (member_id, name, email, address) VALUES (@member_id, @name, @email, @address)", con);
                cmd.Parameters.AddWithValue("@Member_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Saved");

                con.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE Members SET member_id=@member_id, name=@name, email=@email,address=@address WHERE member_id=@member_id", con);
                cmd.Parameters.AddWithValue("@Member_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Email;", textBox3.Text);
                cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");

                con.Close();
            }
        }
    }
}
