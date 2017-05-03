using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory
{
    abstract public class Car
    {
        public string Trade { get; set; } = "<none>";
        public int EngineVolume { get; set; } = 0;
        public int Price { get; set; } = 0;
        public int Count { get; set; } = 0;

        public Car()
        {

        }
        public Car(string trade, int engineVolume, int price, int count)
        {
            Trade = trade;
            EngineVolume = engineVolume;
            Price = price;
            Count = count;
        }

        public override string ToString() => string.Format("Car: {0}\tEngine: v{1}\tPrice: {2}\tCount: {3}", Trade, EngineVolume, Price, Count);
        public override int GetHashCode() => ToString().GetHashCode();

        public static Car Parse(string raw)
        {
            var rawData = raw.Split(' ');
            if(rawData[0].Trim() == "Vechile")
            {
                var vech = new Vechile(rawData[1], int.Parse(rawData[2]), int.Parse(rawData[3]), int.Parse(rawData[4]), bool.Parse(rawData[5]));
                return vech;
            }
            else if (rawData[0].Trim() == "Truck")
            {
                var truck = new Truck(rawData[1], int.Parse(rawData[2]), int.Parse(rawData[3]), int.Parse(rawData[4]), int.Parse(rawData[5]));
                return truck;
            }
            return new Vechile();
        }
    }
}
