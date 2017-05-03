/*
    Main File
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

            var cfList = CarFactory.Read(new System.IO.StreamReader("../../CarFactories.txt"));
            Console.WriteLine("Factory's car ordered by enbgine volume");
            foreach (var item in cfList)
            {
                var cars = item.Cars.OrderBy(s => s.EngineVolume);
                Console.WriteLine("\t{0}", item.Name);
                foreach (var c in cars)
                {
                    Console.WriteLine("\t\t{0}", c);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            int lowerBound = 3;
            int upperBound = 5;
            Dictionary<CarFactory, int> carsCount = new Dictionary<CarFactory, int>();
            Console.WriteLine("Cars between {0} and {1} price", lowerBound, upperBound);
            foreach (var item in cfList)
            {
                carsCount.Add(item, item.Cars.Count(s => lowerBound <= s.Price && s.Price <= upperBound));
                Console.WriteLine("{0}\t-\t{1}", carsCount.Last().Key.Name, carsCount.Last().Value);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Atuomatic vechile");

            var automatic =
                (from item in cfList
                 where item.Cars.Any(s => (s is Vechile) && (s as Vechile).Automatic)
                 orderby item.Name ascending
                 select item.Name);
            foreach (var item in automatic)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Remove factories which produces more trucks");

            cfList =
                (from item in cfList
                where item.Cars.Count(s => s is Truck) <= item.Cars.Count(s => s is Vechile)
                select item).ToList();

            foreach (var item in cfList)
            {
                Console.WriteLine(item.Name);
            }
            }
            catch (Exception error)
            {
                Console.WriteLine("Fatal error ocurred: {0}", error.Message);
            }
            Console.ReadKey();
        }
    }
}
