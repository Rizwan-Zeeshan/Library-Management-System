namespace New_Db_Project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Books bookinfo = new Books();
            bookinfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Members members = new Members();
            members.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Borrowings borrowings = new Borrowings();
            borrowings.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fine fine = new Fine();
            fine.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            Form2 returns = new Form2();
            returns.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Event @event = new Event();
            @event.Show();
        }
    }
}
