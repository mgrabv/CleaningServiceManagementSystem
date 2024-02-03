using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Models.DomainModels
{
    public class Car
    {
        public int CarID { get; set; }

        //One-to-one Association with Driver
        public Driver _driver { get; private set; }

        //Qualified Association with Warehouse
        public Warehouse? _warehouse { get; private set; }


        public Car() { }

        public void AssignDriver(Driver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(null, "Driver must exist to be assigned to a Car.");
            }

            if (!driver._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            _driver = driver;
        }

        public void RemoveDriver()
        {
            if (_driver == null)
            {
                throw new InvalidOperationException("There is no Driver assigned to this Car.");
            }

            if (!_driver._baseClassCall)
            {
                throw new InvalidOperationException("Not a call from base class.");
            }

            _driver = null;
        }

        public void SetWarehouse(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                throw new ArgumentNullException("Warehouse must exist to be able to hold Cars.");
            }

            if (_warehouse == warehouse)
            {
                throw new ArgumentException("This Car already belongs to given Warehouse.");
            }

            if (_warehouse != null)
            {
                _warehouse.RemoveCar(this.CarID);
            }

            _warehouse = warehouse;

            if (!warehouse.CarExists(this.CarID))
            {
                warehouse.AddCar(this);
            }
        }

        public void RemoveWarehouse()
        {
            if (_warehouse == null)
            {
                throw new ArgumentException("This firearm is currently not associated with any warehouse");
            }

            Warehouse tmp = _warehouse;
            _warehouse = null;

            if (tmp.CarExists(this.CarID))
            {
                tmp.RemoveCar(this.CarID);
            }
        }

    }
}
