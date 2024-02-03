using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class Driver
    {
        public int DriverID { get; set; }
        public double PayPerOrder { get; set; }

        //Composition - Overlapping Inheritance
        public Employee _employee { get; private set; }

        //Order - one-to-many association
        public HashSet<Order> _assignedOrders { get; private set; } = new HashSet<Order>();

        //Car - one-to-one association
        public Car _car { get; private set; }

        //Flag for Car association
        public bool _baseClassCall { get; private set; } = false;

        private Driver(double payPerOrder)
        {
            PayPerOrder = payPerOrder;
        }

        public static Driver CreateDriver(double payPerOrder, Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(null, "Employee must exist to be a Driver.");
            }

            if (!employee._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            Driver driver = new Driver(payPerOrder);
            driver._employee = employee;
            return driver;
        }

        public void RemoveLink()                                                                                //Check if additional nullcheck needed - _person == null
        {
            if (!_employee._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            _employee = null;
        }

        public void UseCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(null, "Car must exist to be used.");
            }

            if (car._driver != null)
            {
                throw new InvalidOperationException("This Car is being used by someone else.");
            }

            _baseClassCall = true;
            car.AssignDriver(this);
            _baseClassCall = false;

            _car = car;
        }

        public void RemoveCar()
        {
            if (_car == null)
            {
                throw new InvalidOperationException("There is no Car assigned to this Driver.");
            }

            _baseClassCall = true;
            _car.RemoveDriver();
            _baseClassCall = false;

            _car = null;
        }

        public void AssignOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(null, "Order must exist to be Assigned to a Driver.");
            }

            if (order._driver != this)
            {
                throw new InvalidOperationException("This Order is not meant for this Driver.");
            }

            if (_assignedOrders.Contains(order))
            {
                throw new InvalidOperationException("This Order is already assigned to this Driver.");
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
                throw new InvalidOperationException("This Order is not associated with this Driver.");
            }

            _assignedOrders.Remove(order);
        }
    }
}
