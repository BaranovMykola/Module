/*
    Base class Clock
    Copyright (C) 2017  Baranov Mykola

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
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
