using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory
{
    class Vechile : Car
    {
        public bool Automatic { get; set; } = false;
        public Vechile()
        {

        }
        public Vechile(string trade, int engineVolume, int price, int count, bool automatic) : base(trade, engineVolume, price, count)
        {
            Automatic = automatic;
        }

        public override string ToString() => string.Format("VACHILE:\t{0}\t| Automatic: {1}", base.ToString(), Automatic);
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj)
        {
            var car = obj as Vechile;
            if (car == null) return false;
            return base.Equals(obj) &&
                car.Automatic == Automatic &&
                car.Count == Count &&
                car.EngineVolume == EngineVolume &&
                car.Price == Price;
        }
    }
}
