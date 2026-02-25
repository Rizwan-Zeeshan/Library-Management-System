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

namespace New_Db_Project
{
    public partial class Event : Form
    {
        public Event()
        {
            InitializeComponent();
        }
        private void LoadDataIntoDataGridView()
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Events";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V797NG6\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Events (event_id, event_name, event_date, location_id) VALUES (@event_id, @event_name, @event_date, @location_id)", con);
                cmd.Parameters.AddWithValue("@Event_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Event_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Event_date", textBox3.Text);
                cmd.Parameters.AddWithValue("@Location_id", int.Parse(textBox4.Text));
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

                SqlCommand cmd = new SqlCommand("UPDATE Events SET event_id=@event_id, event_name=@event_name, event_date=@event_date,location_id=@location_id WHERE event_id=@event_id", con);
                cmd.Parameters.AddWithValue("@Event_id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Event_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Event_date", DateTime.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@Location_id", int.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data Updated");

                con.Close();
            }
        }
    }
}
