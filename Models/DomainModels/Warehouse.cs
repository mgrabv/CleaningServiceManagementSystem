using System.ComponentModel.DataAnnotations.Schema;

namespace CSMS.Models.DomainModels
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }

        public int Capacity { get; set; }

        [NotMapped]
        public Dictionary<int, Car> _cars { get; private set; } = new Dictionary<int, Car>();

        public HashSet<Car>? _carsValues
        {
            get { return _cars.Values.ToHashSet(); }
            private set { }
        }


        public Warehouse(int capacity)
        {
            Capacity = capacity;
        }

        public bool CarExists(int id)
        {
            return _cars.ContainsKey(id);
        }

        public Car GetCar(int id)
        {
            if (!CarExists(id))
            {
                throw new ArgumentException("This Car does not belong to this Warehouse.");
            }

            return (Car)_cars.Where(x => x.Key == id).First().Value;
        }

        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException("Car must exist to be added to a Warehouse.");
            }

            if (CarExists(car.CarID))
            {
                throw new ArgumentException("Given Car already belongs to this Warehouse.");
            }

            if (this._cars.Count == Capacity)
            {
                throw new InvalidOperationException("Maximum Warehouse capacity reached.");
            }

            _cars.Add(car.CarID, car);

            if (car._warehouse != this)
            {
                car.SetWarehouse(this);
            }
        }

        public void RemoveCar(int id)
        {
            if (!CarExists(id))
            {
                throw new ArgumentException("Car with given Id is not associated with this warehouse");
            }

            Car tmp = GetCar(id);
            _cars.Remove(id);

            if (tmp._warehouse == this)
            {
                tmp.RemoveWarehouse();
            }
        }
    }
}
