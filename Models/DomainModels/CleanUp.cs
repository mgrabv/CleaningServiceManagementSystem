using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class CleanUp
    {
        public int CleanUpID { get; set; }
        public static int DurationHrs { get; set; } = 5;

        //Composition - Multi-Aspect Inheritance
        public CleaningOffer _cleaningOffer { get; private set; }

        private CleanUp() { }

        public static CleanUp CreateCleanUp(CleaningOffer cleaningOffer)
        {
            if (cleaningOffer == null)
            {
                throw new ArgumentNullException(null, "CleaningOffer must exist to be a CleanUp CleaningOffer.");
            }

            if (!cleaningOffer._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class");
            }

            CleanUp cleanUp = new CleanUp();
            cleanUp._cleaningOffer = cleaningOffer;
            return cleanUp;
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
