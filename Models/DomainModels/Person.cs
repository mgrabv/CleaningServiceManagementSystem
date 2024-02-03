using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        public string Email { get; set; }
        public string PhoneNo { get; set; }

        //Roles
        public Manager _manager { get; private set; }
        public Client _client { get; private set; }
        public Employee _employee { get; private set; }

        //Flag for assigning role (should be only possible through using predefined methods)
        public bool _baseClassCall { get; private set; } = false;


        //For EFC
        private Person() { }

        //Composition - Dynamic Inheritance
        public Person(string name, string? secondName, string surname, DateTime birthDate, string email, string phoneNo, double? payPerSqrMeter, double? payPerOrder, double? budget, string? licenceID)
        {
            if (budget == null && licenceID == null)
            {
                this.MakeEmployee(payPerSqrMeter, payPerOrder);
            }
            else if (budget != null && licenceID == null && payPerSqrMeter == null && payPerOrder == null)
            {
                this.MakeClient(budget.Value);
            }
            else if (budget == null && licenceID != null && payPerSqrMeter == null && payPerOrder == null)
            {
                this.MakeManager(licenceID);
            }
            else
            {
                throw new InvalidOperationException("Person can have only one role at a time.");
            }

            Name = name;
            SecondName = secondName;
            Surname = surname;
            BirthDate = birthDate;
            Email = email;
            PhoneNo = phoneNo;
        }


        public void GetInfo()
        {
            throw new NotImplementedException();                                                                  //Implement String method
        }

        //Client Role
        public void MakeClient(double budget)
        {
            if (_client != null)
            {
                throw new InvalidOperationException("This Person already is a Client.");
            }

            if (_manager != null)
            {
                RemoveManager();
            }

            if (_employee != null)
            {
                RemoveEmployee();
            }

            _baseClassCall = true;
            _client = Client.CreateClient(budget, this);
            _baseClassCall = false;
        }

        public void RemoveClient()
        {
            if (_client == null)
            {
                throw new InvalidOperationException("This Person is not a Client.");
            }

            if (_manager == null && _employee == null)
            {
                throw new InvalidOperationException("Person has to have at least one role.");
            }

            _baseClassCall = true;
            _client.RemoveLink();
            _baseClassCall = false;

            _client = null;
        }

        //Manager Role
        public void MakeManager(string licenceID)
        {
            if (_manager != null)
            {
                throw new InvalidOperationException("This Person already is a Manager.");
            }

            if (_client != null)
            {
                RemoveClient();
            }

            if (_employee != null)
            {
                RemoveEmployee();
            }

            _baseClassCall = true;
            _manager = Manager.CreateManager(licenceID, this);
            _baseClassCall = false;
        }

        public void RemoveManager()
        {
            if (_manager == null)
            {
                throw new InvalidOperationException("This Person is not a Manager.");
            }

            if (_client == null && _employee == null)
            {
                throw new InvalidOperationException("Person has to have at least one role.");
            }

            _baseClassCall = true;
            _manager.RemoveLink();
            _baseClassCall = false;

            _manager = null;
        }

        //Employee Role
        public void MakeEmployee(double? payPerSqrMeter, double? payPerOrder)
        {
            if (_employee != null)
            {
                throw new InvalidOperationException("This Person already is an Employee.");
            }

            if (payPerSqrMeter == null && payPerOrder == null)
            {
                throw new InvalidOperationException("Employee must have at least one role.");
            }

            if (_client != null)
            {
                RemoveClient();
            }

            if (_manager != null)
            {
                RemoveManager();
            }

            _baseClassCall = true;
            _employee = Employee.CreateEmployee(this, payPerSqrMeter, payPerOrder);
            _baseClassCall = false;
        }

        public void RemoveEmployee()
        {
            if (_employee == null)
            {
                throw new InvalidOperationException("This Person is not an Employee.");
            }

            if (_client == null && _manager == null)
            {
                throw new InvalidOperationException("Person has to have at least one role.");
            }

            _baseClassCall = true;
            _manager.RemoveLink();
            _baseClassCall = false;

            _manager = null;
        }
    }
}
