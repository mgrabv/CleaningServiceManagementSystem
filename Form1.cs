namespace CSMS
{
    public partial class Manager_MainMenu : Form
    {

        public Manager_MainMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new Manager_Orders();
            form.Show();
            if (this.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EmployeesButton_Click(object sender, EventArgs e)
        {

        }
    }
}