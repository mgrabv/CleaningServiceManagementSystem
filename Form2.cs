using CSMS.Models.DomainModels;
using CSMS.Repositories;

namespace CSMS
{
    public partial class Manager_Orders : Form
    {
        private bool _allowClose = true;
        private List<Order> orders;
        private ManagerRepository _repository = new ManagerRepository();

        public Manager_Orders()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            Refreshsus();
        }

        public async void Refreshsus()
        {
            OrdersView.Rows.Clear();

            orders = await _repository.GetConfirmedOrders();

            foreach (Order order in orders)
            {
                OrdersView.Rows.Add(
                        "Job-Type: " + order.JobType + "\n" +
                        "Job-Date: " + order.JobDate.ToShortDateString()
                    );
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _allowClose = false;
            this.Close();

            Application.OpenForms["Manager_MainMenu"].Show();
            if (this.WindowState == FormWindowState.Maximized)
            {
                Application.OpenForms["Manager_MainMenu"].WindowState = FormWindowState.Maximized;
            }
        }

        private void Manager_Orders_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_allowClose)
            {
                Application.Exit();
            }
        }

        private async void ConfirmedButton_Click(object sender, EventArgs e)
        {
            Refreshsus();
        }

        private void OrdersView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    Form f = new Manager_OrderDetails(this.orders[e.RowIndex], true);
                    f.ShowDialog();
                }
                else
                {
                    Form f = new Manager_OrderDetails(this.orders[e.RowIndex]);
                    f.ShowDialog();
                }
            }
        }

        private void Manager_Orders_Activated(object sender, EventArgs e)
        {
            _allowClose = true;
        }

        private void Manager_Orders_Deactivate(object sender, EventArgs e)
        {
            _allowClose = false;
        }
    }
}