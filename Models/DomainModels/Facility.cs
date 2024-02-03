using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class Facility
    {
        public int FacilityID { get; set; }
        public double SquareMeters { get; set; }

        //Composition - Multi-Aspect Inheritance
        public CleaningOffer _cleaningOffer { get; private set; }

        private Facility(double squareMeters)
        {
            SquareMeters = squareMeters;
        }

        public static Facility CreateFacility(double squareMeters, CleaningOffer cleaningOffer)
        {
            if (cleaningOffer == null)
            {
                throw new ArgumentNullException(null, "CleaningOffer must exist to be a Facility CleaningOffer.");
            }

            if (!cleaningOffer._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class");
            }

            Facility facility = new Facility(squareMeters);
            facility._cleaningOffer = cleaningOffer;
            return facility;
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
