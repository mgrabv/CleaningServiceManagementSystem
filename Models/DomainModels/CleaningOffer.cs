using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class CleaningOffer
    {
        public int CleaningOfferID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        //MultiAspect 'Roles'
        public Apartment _apartment { get; private set; }
        public Facility _facility { get; private set; }
        public CleanUp _cleanUp { get; private set; }
        public DeepClean _deepClean { get; private set; }

        //View - many-to-many association
        public HashSet<Client> _viewedByClients { get; private set; } = new HashSet<Client>();

        //Order - one-to-many Association
        public HashSet<Order> _ordersCreated { get; private set; } = new HashSet<Order>();

        //Flag for assigning role (should be only possible through using predefined methods)
        public bool _baseClassCall { get; private set; } = false;


        //For EFC
        private CleaningOffer() { }
        
        //Composition - Multi-Aspect Inheritance
        public CleaningOffer(string name, double price, int? roomCount, double? squareMeters, List<string>? specialChemicals)
        {
            if (roomCount != null && squareMeters == null && specialChemicals == null)
            {
                this.MakeApartmentCleanUp(roomCount.Value);
            }
            else if (roomCount != null && squareMeters == null && specialChemicals != null)
            {
                this.MakeApartmentDeepClean(roomCount.Value, specialChemicals);
            }
            else if (roomCount == null && squareMeters != null && specialChemicals == null)
            {
                this.MakeFacilityCleanUp(squareMeters.Value);
            }
            else if (roomCount == null && squareMeters != null && specialChemicals != null)
            {
                this.MakeFacilityDeepClean(squareMeters.Value, specialChemicals);
            }
            else
            {
                throw new InvalidOperationException("Invalid attribute combination. CleaningOffer must have one aspect from each inheritance branch.");
            }

            Name = name;
            Price = price;
        }

        private void MakeApartmentCleanUp(int roomCount)
        {
            _baseClassCall = true;
            _apartment = Apartment.CreateApartment(roomCount, this);
            _cleanUp = CleanUp.CreateCleanUp(this);
            _baseClassCall = false;
        }

        private void MakeApartmentDeepClean(int roomCount, List<string> specialChemicals)
        {
            _baseClassCall = true;
            _apartment = Apartment.CreateApartment(roomCount, this);
            _deepClean = DeepClean.CreateDeepClean(specialChemicals, this);
            _baseClassCall = false;
        }

        private void MakeFacilityCleanUp(double squareMeters)
        {
            _baseClassCall = true;
            _facility = Facility.CreateFacility(squareMeters, this);
            _cleanUp = CleanUp.CreateCleanUp(this);
            _baseClassCall = false;
        }

        private void MakeFacilityDeepClean(double squareMeters, List<string> specialChemicals)
        {
            _baseClassCall = true;
            _facility = Facility.CreateFacility(squareMeters, this);
            _deepClean = DeepClean.CreateDeepClean(specialChemicals, this);
            _baseClassCall = false;
        }

        public void Remove()
        {
            //Supply with checks in the future

            _baseClassCall = true;

            if (_apartment != null)
            {
                _apartment.RemoveLink();
                _apartment = null;
            }

            if (_facility != null)
            {
                _facility.RemoveLink();
                _facility = null;
            }

            if (_cleanUp != null)
            {
                _cleanUp.RemoveLink();
                _cleanUp = null;
            }

            if (_deepClean != null)
            {
                _deepClean.RemoveLink();
                _deepClean = null;
            }

            _baseClassCall = false;
        }

        public void ViewByClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(null, "Client must exist to view CleaningOffers.");
            }

            if (!client._baseClassCall)
            {
                throw new InvalidOperationException("Not a base class call.");
            }

            if (!_viewedByClients.Contains(client))
            {
                _viewedByClients.Add(client);
            }
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(null, "Order must exist to be associated with a CleaningOffer.");
            }

            if (order._offer != this)
            {
                throw new InvalidOperationException("This Order is not meant for this Offer.");
            }

            if (_ordersCreated.Contains(order))
            {
                throw new InvalidOperationException("This Order is already associated with this CleaningOffer.");
            }

            _ordersCreated.Add(order);
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

            if (!_ordersCreated.Contains(order))
            {
                throw new InvalidOperationException("This Order is not associated with this CleaningOffer.");
            }

            _ordersCreated.Remove(order);
        }
    }
}