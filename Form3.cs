using CSMS.Models.DomainModels;
using CSMS.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSMS
{
    public partial class Manager_OrderDetails : Form
    {
        private bool _allowClose = true;
        private Order order;
        private bool _fulscreenFlag;

        public Manager_OrderDetails(Order order, bool flag = false)
        {
            InitializeComponent();
            this.order = order;
            this._fulscreenFlag = flag;
        }

        private void Manager_OrderDetails_Load(object sender, EventArgs e)
        {
            Refreshsus();
        }

        public async void Refreshsus()
        {
            OrderIDData.Text = order.OrderID.ToString();
            JobTypeData.Text = order.JobType;
            JobDateData.Text = order.JobDate.ToShortDateString();
            OrderDateData.Text = order.OrderDate.ToShortDateString();
            ClientData.Text = order._client._person.Name + " " + order._client._person.Surname;
            CleanersData.Text = order._cleaners.Count.ToString();
            DriverData.Text = order._driver._employee._person.Name + " " + order._driver._employee._person.Surname;
        }

        private void ModifyCleanersButton_Click(object sender, EventArgs e)
        {
            if (this._fulscreenFlag)
            {
                Form f = new Manager_ModifyCleaners(order, true);
                f.ShowDialog();
            }
            else
            {
                Form f = new Manager_ModifyCleaners(order);
                f.ShowDialog();
            }
            _allowClose = false;
        }

        private void Manager_OrderDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_allowClose)
            {
                Application.OpenForms["Manager_Orders"].Close();
                Form f = new Manager_Orders();
                if (this._fulscreenFlag)
                {
                    f.WindowState = FormWindowState.Maximized;
                }
                f.Show();
            }
        }
    }
}
