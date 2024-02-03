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
    public partial class Manager_ModifyCleaners : Form
    {
        Order order;
        List<Cleaner> newlyAssigned = new List<Cleaner>();
        List<Cleaner> availableCleaners;
        ManagerRepository _repository = new ManagerRepository();
        bool fullscreenFlag;

        public Manager_ModifyCleaners(Order order, bool flag = false)
        {
            InitializeComponent();
            this.order = order;
            this.fullscreenFlag = flag;
        }

        private void Manager_ModifyCleaners_Load(object sender, EventArgs e)
        {
            Refreshsus();
        }

        private async void Refreshsus()
        {
            AssignedCleanersData.Rows.Clear();
            AvailableCleanersData.Rows.Clear();

            availableCleaners = await _repository.GetAvailableCleaners(order.JobDate);

            foreach (Cleaner cleaner in order._cleaners)
            {
                AssignedCleanersData.Rows.Add(
                        cleaner._employee._person.Name + " " + cleaner._employee._person.Surname
                    );
            }

            foreach (Cleaner cleaner in availableCleaners)
            {
                AvailableCleanersData.Rows.Add(
                        cleaner._employee._person.Name + " " + cleaner._employee._person.Surname
                    );
            }
        }

        private void AvailableCleanersData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                newlyAssigned.Add(availableCleaners[e.RowIndex]);
                AssignedCleanersData.Rows.Add(
                        availableCleaners[e.RowIndex]._employee._person.Name + " " + availableCleaners[e.RowIndex]._employee._person.Surname
                    );
                AvailableCleanersData.Rows.RemoveAt(e.RowIndex);
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            foreach (Cleaner cleaner in newlyAssigned)
            {
                await _repository.AssignCleanerToOrder(order.OrderID, cleaner);
            }
            this.Close();
            Application.OpenForms["Manager_OrderDetails"].Close();
            var updatedOrder = await _repository.GetOrder(order.OrderID);
            if (this.fullscreenFlag)
            {
                Form f = new Manager_OrderDetails(updatedOrder, true);
                f.Show();
            }
            else
            {
                Form f = new Manager_OrderDetails(updatedOrder);
                f.Show();
            }
        }
    }
}
