using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory
{
    class Truck : Car
    {
        public int MaxCargoWeight { get; set; }

        public Truck()
        {

        }
        public Truck(string trade, int engineVolume, int price, int count, int maxCargoWeight) : base(trade, engineVolume, price, count)
        {
            MaxCargoWeight = maxCargoWeight;
        }

        public override string ToString() => string.Format("TRUCK:\t{0}\t| Max Cargo Weight: {1}", base.ToString(), MaxCargoWeight);
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj)
        {
                var car = obj as Truck;
                if (car == null) return false;
                return base.Equals(obj) &&
                    car.MaxCargoWeight == MaxCargoWeight &&
                    car.Count == Count &&
                    car.EngineVolume == EngineVolume &&
                    car.Price == Price;
        }
    }
}
