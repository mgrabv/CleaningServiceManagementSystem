using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class Client
    {
        public int ClientID { get; set; }
        public double Budget { get; set; }
        public Person _person { get; private set; }
        
        //View - many-to-many association
        public HashSet<CleaningOffer> _viewedCleaningOffers { get; private set; } = new HashSet<CleaningOffer>();

        //Order - one-to-many association
        public HashSet<Order> _orders { get; private set; } = new HashSet<Order>();
        
        //Flag for view association (assigning new Client to CleaningOffer)
        public bool _baseClassCall { get; private set; } = false;


        private Client(double budget)
        {
            Budget = budget;
        }

        public static Client CreateClient(double budget, Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(null, "Person must exist to be a Client.");
            }
            
            if (!person._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            Client client = new Client(budget);
            client._person = person;
            return client;
        }

        public void RemoveLink()                                                                                //Check if additional nullcheck needed - _person == null
        {
            if (!_person._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            _person = null;
        }

        public void ViewOffer(CleaningOffer offer)
        {
            if (offer == null)
            {
                throw new ArgumentNullException(null, "Offer to be viewed cannot be null.");
            }

            if (!_viewedCleaningOffers.Contains(offer))
            {
                _baseClassCall = true;
                offer.ViewByClient(this);
                _baseClassCall = false;

                _viewedCleaningOffers.Add(offer);
            }
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(null, "Order must exist to be Purchased by Client.");
            }

            if (order._client != this)
            {
                throw new InvalidOperationException("This Order is not meant for this client.");
            }

            if (_orders.Contains(order))
            {
                throw new InvalidOperationException("This Order already belongs to this Client.");
            }

            if (this.Budget < order._offer.Price)
            {
                throw new InvalidOperationException("This Client doesn't have enough money for this Order.");
            }

            this.Budget -= order._offer.Price;
            _orders.Add(order);
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

            if (!_orders.Contains(order))
            {
                throw new InvalidOperationException("This Order is not associated with this Client.");
            }

            _orders.Remove(order);
        }
    }
}
