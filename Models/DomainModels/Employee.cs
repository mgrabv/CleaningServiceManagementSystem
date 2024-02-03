using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public static int MinAge { get; private set; } = 18;
        public Person _person { get; private set; }

        //Flag for assigning role (should be only possible through using predefined methods)
        public bool _baseClassCall { get; private set; } = false;

        //Roles
        public Cleaner _cleaner { get; private set; }
        public Driver _driver { get; private set; }


        //Composition - Overlapping Inheritance
        private Employee() { }

        public static Employee CreateEmployee(Person person, double? payPerSqrMeter, double? payPerOrder)
        {
            if (person == null)
            {
                throw new ArgumentNullException(null, "Person must exist to be a Employee.");
            }

            if (!person._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            Employee employee = new Employee();
            employee._person = person;

            if (payPerSqrMeter != null)
            {
                employee.MakeCleaner(payPerSqrMeter.Value);
            }

            if (payPerOrder != null)
            {
                employee.MakeDriver(payPerOrder.Value);
            }

            return employee;
        }

        public void RemoveLink()                                                                                //Check if additional nullcheck needed - _person == null
        {
            if (!_person._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            if (_cleaner != null)
            {
                RemoveCleaner();
            }

            if (_driver != null)
            {
                RemoveDriver();
            }

            _person = null;
        }

        public void MakeCleaner(double payPerSqrMeter)
        {
            if (_cleaner != null)
            {
                throw new InvalidOperationException("This Employee is already a Cleaner.");
            }

            _baseClassCall = true;
            _cleaner = Cleaner.CreateCleaner(payPerSqrMeter, this);
            _baseClassCall = false;
        }

        private void RemoveCleaner()
        {
            _baseClassCall = true;
            _cleaner.RemoveLink();
            _baseClassCall = false;

            _cleaner = null;
        }

        public void MakeDriver(double payPerOrder)
        {
            if (_driver != null)
            {
                throw new InvalidOperationException("This Employee is already a Driver.");
            }

            _baseClassCall = true;
            _driver = Driver.CreateDriver(payPerOrder, this);
            _baseClassCall = false;
        }

        private void RemoveDriver()
        {
            _baseClassCall = true;
            _driver.RemoveLink();
            _baseClassCall = false;

            _driver = null;
        }
    }
}
