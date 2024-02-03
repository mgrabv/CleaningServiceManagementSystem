using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class Order
    {
        public int OrderID { get; set; }
        public string JobType { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime JobDate { get; set; }

        //One-To-Many Associations
        public Client _client { get; private set; }
        public CleaningOffer _offer { get; private set; }
        public Driver? _driver { get; private set; }

        //Many-To-Many Association
        public HashSet<Cleaner>? _cleaners { get; private set; } = new HashSet<Cleaner>();

        //Flag for view association (assigning new Client to CleaningOffer)
        public bool _baseClassCall { get; private set; } = false;


        //For EFC
        private Order() { }

        public Order(DateTime jobDate, Client client, CleaningOffer offer, HashSet<Cleaner> cleaners, Driver driver) //If Cleaners and Drivers -> order's confirmed (For use-case purpose implemented as constructor)
        {
            //Subset constraint changed to -> if check
            if (!client._viewedCleaningOffers.Contains(offer))
            {
                throw new InvalidOperationException("Client must view a CleaningOffer before purchasing it.");
            }

            OrderDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            JobDate = jobDate;
            _client = client;
            _offer = offer;

            if (offer._apartment != null && offer._cleanUp != null)
            {
                JobType = "Apartment CleanUp";
            }
            if (offer._apartment != null && offer._deepClean != null)
            {
                JobType = "Apartment DeepClean";
            }
            if (offer._facility != null && offer._cleanUp != null)
            {
                JobType = "Facility CleanUp";
            }
            if (offer._facility != null && offer._deepClean != null)
            {
                JobType = "Facility DeepClean";
            }

            _cleaners = cleaners;
            _driver = driver;

            client.AddOrder(this);
            offer.AddOrder(this);
            
            foreach (Cleaner cleaner in cleaners)
            {
                cleaner.AssignOrder(this);
            }

            driver.AssignOrder(this);
        }

        public Order(DateTime jobDate, Client client, CleaningOffer offer) //If no Cleaners and Drivers -> order's not confirmed
        {
            //Subset constraint changed to -> if check
            if (!client._viewedCleaningOffers.Contains(offer))
            {
                throw new InvalidOperationException("Client must view a CleaningOffer before purchasing it.");
            }

            OrderDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
            JobDate = jobDate;
            _client = client;
            _offer = offer;

            if (offer._apartment != null && offer._cleanUp != null)
            {
                JobType = "Apartment CleanUp";
            }
            if (offer._apartment != null && offer._deepClean != null)
            {
                JobType = "Apartment DeepClean";
            }
            if (offer._facility != null && offer._cleanUp != null)
            {
                JobType = "Facility CleanUp";
            }
            if (offer._facility != null && offer._deepClean != null)
            {
                JobType = "Facility DeepClean";
            }

            client.AddOrder(this);
            offer.AddOrder(this);
        }

        public void AddCleaner(Cleaner cleaner)     //Add constraint - only manager can use method?
        {
            if (cleaner == null)
            {
                throw new ArgumentNullException(null, "Cleaner must exist to be assigned to an order.");
            }
            _cleaners.Add(cleaner);
        }

        public void Remove()    //Add constraint - only manager can use method?
        {
            _baseClassCall = true;

            if (_client != null)
            {
                _client.RemoveOrder(this);
                _cleaners = null;
            }

            if (_offer != null)
            {
                _offer.RemoveOrder(this);
                _offer = null;
            }

            if (_cleaners != null)
            {
                foreach (Cleaner cleaner in _cleaners)
                {
                    cleaner.RemoveOrder(this);
                }

                _cleaners = null;
            }

            if (_driver != null)
            {
                _driver.RemoveOrder(this);
                _driver = null;
            }

            _baseClassCall = false;
        }
    }
}