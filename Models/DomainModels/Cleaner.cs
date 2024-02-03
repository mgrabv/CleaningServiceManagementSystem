using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class Cleaner
    {
        public int CleanerID { get; set; }
        public double PayPerSqrMeter { get; set; }

        //Composition - Overlapping Inheritance
        public Employee _employee { get; private set; }

        //many-to-many association with Order
        public SortedSet<Order> _assignedOrders { get; private set; } = new SortedSet<Order>(new MAScomparer()); //Ordered constraint

        class MAScomparer : IComparer<Order>
        {
            public int Compare(Order? x, Order? y)
            {
                return x.JobDate.CompareTo(y.JobDate);
            }
        }

        private Cleaner(double payPerSqrMeter)
        {
            PayPerSqrMeter = payPerSqrMeter;
        }

        public static Cleaner CreateCleaner(double payPerSqrMeter, Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(null, "Employee must exist to be a Cleaner.");
            }

            if (!employee._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            Cleaner cleaner = new Cleaner(payPerSqrMeter);
            cleaner._employee = employee;
            return cleaner;
        }

        public void RemoveLink()                                                                                //Check if additional nullcheck needed - _person == null
        {
            if (!_employee._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            _employee = null;
        }

        //One-to-many Order association
        public void AssignOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(null, "Order must exist to be Assigned to a Cleaner.");
            }

            if (!order._cleaners.Contains(this))
            {
                throw new InvalidOperationException("This Order is not meant for this Cleaner.");
            }

            if (_assignedOrders.Contains(order))
            {
                throw new InvalidOperationException("This Order is already assigned to this Cleaner.");
            }

            _assignedOrders.Add(order);
        }

        public void RemoveOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(null, "Order has to exist to be removed.");
            }

            if (!order._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            if (!_assignedOrders.Contains(order))
            {
                throw new InvalidOperationException("This Order is not associated with this Cleaner.");
            }

            _assignedOrders.Remove(order);
        }
    }
}
