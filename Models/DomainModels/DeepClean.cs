using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class DeepClean
    {
        public int DeepCleanID { get; set; }
        public static int DurationHrs { get; set; } = 12;
        public List<string> SpecialChemicals { get; set; } 

        //Composition - Multi-Aspect Inheritance
        public CleaningOffer _cleaningOffer { get; private set; }

        private DeepClean(List<string> specialChemicals)
        {
            SpecialChemicals = specialChemicals;
        }

        public static DeepClean CreateDeepClean(List<string> specialChemicals, CleaningOffer cleaningOffer)
        {
            if (cleaningOffer == null)
            {
                throw new ArgumentNullException(null, "CleaningOffer must exist to be a DeepClean CleaningOffer.");
            }
            if (!cleaningOffer._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class");
            }

            DeepClean deepClean = new DeepClean(specialChemicals);
            deepClean._cleaningOffer = cleaningOffer;
            return deepClean;
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
