using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    class Clock : IComparable<Clock>
    {
        public string Brand { get; set; }
        public string Producer { get; set; }

        public Clock(string brand, string producer)
        {
            Brand = brand;
            Producer = producer;
        }

        public override string ToString()
        {
            return string.Format("Brand: {0} Producer: {1}", Brand, Producer);
        }

        public static IEnumerable<Clock> ReadFromFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (var item in lines)
            {
                string[] line = item.Split(' ');
                if(line[0] == "Electronic")
                {
                    ElectonicClock.Battery battery;
                    ElectonicClock.Screen screen;
                    if(line[3] == ElectonicClock.Battery.Lion.ToString())
                    {
                        battery = ElectonicClock.Battery.Lion;
                    }
                    else
                    {
                        battery = ElectonicClock.Battery.Standart;
                    }
                    if (line[4] == ElectonicClock.Screen.Tft.ToString())
                    {
                        screen = ElectonicClock.Screen.Tft;
                    }
                    else
                    {
                        screen = ElectonicClock.Screen.Touch;
                    }
                    yield return new ElectonicClock(line[1], line[2], battery, screen);
                }
                else if (line[0] == "Mechanical")
                {
                    yield return new MechanicalClock(line[1], line[2], int.Parse(line[3]), int.Parse(line[4]));
                }
            }
        }

        public static void SortByName(Clock[] arr)
        {
            Array.Sort(arr);
        }

        int IComparable<Clock>.CompareTo(Clock other)
        {
            return Brand.CompareTo(other.Brand);
        }

        public static int CountOfElectronicClocks(IEnumerable<Clock> seq, string brand, ElectonicClock.Battery battery)
        {
            var filteredItems =
                from item in seq
                where ((item is ElectonicClock) && (item as ElectonicClock)?.BatteryType == battery && item.Brand == brand)
                select item;
            return filteredItems.ToArray<Clock>().Length;
        }

        public static Clock MetTheMostWarranty(IEnumerable<Clock> seq)
        {
            var filterMechanical =
                from item in seq
                where (item is MechanicalClock)
                orderby (item as MechanicalClock)?.WarrantYears ascending
                select item;
            return filterMechanical.Last<Clock>();
        }
    }
}
