using CSMS.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class Apartment
    {
        public int ApartmentID { get; set; }
        public int RoomCount { get; set; }

        //Composition - Multi-Aspect Inheritance
        public CleaningOffer _cleaningOffer { get; private set; }

        private Apartment(int roomCount)
        {
            RoomCount = roomCount;
        }

        public static Apartment CreateApartment(int roomCount, CleaningOffer cleaningOffer)
        {
            if (cleaningOffer == null)
            {
                throw new ArgumentNullException(null, "CleaningOffer must exist to be an Apartment CleaningOffer.");
            }

            if (!cleaningOffer._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class");
            }

            Apartment apartment = new Apartment(roomCount);
            apartment._cleaningOffer = cleaningOffer;
            return apartment;
        }

        public void RemoveLink()                                                                                //Check if additional nullcheck needed - _person == null
        {
            if (!_cleaningOffer._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            _cleaningOffer = null;
        }
    }
}
