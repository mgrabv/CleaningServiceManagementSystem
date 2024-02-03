using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class Manager
    {
        public int ManagerID { get; set; }
        public string LicenceID { get; set; }
        public Person _person { get; private set; }


        //Composition
        private Manager(string licenceID)
        {
            LicenceID = licenceID;
        }

        public static Manager CreateManager(string licenceID, Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(null, "Person must exist to be a manager.");
            }

            if (!person._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            Manager manager = new Manager(licenceID);
            manager._person = person;
            return manager;
        }

        public void RemoveLink()                                                                                //Check if additional nullcheck needed - _person == null
        {
            if (!_person._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            _person = null;
        }
        
        ////Manager methods
        //public List<Order> GetConfirmedOrders()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Cleaner> GetAvailableCleaners(DateTime date)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AssignCleanerToOrder(Order order, Cleaner cleaner)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
