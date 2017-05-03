/*
    CarFactory class
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

namespace CarFactory
{
    class CarFactory
    {
        public string Name { get; set; } = "";
        public List<Car> Cars { get; set; } = new List<Car>();
        public CarFactory()
        {

        }
        public CarFactory(string name)
        {
            Name = name;
        }
        public CarFactory(IEnumerable<Car> cars)
        {
            Cars = cars.ToList();
        }
        public CarFactory(string name, IEnumerable<Car> cars)
        {
            Name = name;
            Cars = cars.ToList();
        }

        public override string ToString()
        {
            string output = string.Format("Car factory:\t [{0}]\n\n\t", Name);
            output += string.Join<Car>("\n\t", Cars);
            return output;
        }
        public static List<CarFactory> Read(StreamReader sr)
        {
            List<CarFactory> cf = new List<CarFactory>();
            CarFactory newFactory = null;// = new CarFactory();
            string line;
            while((line = sr.ReadLine()) != null)
            {
                if(line == "#")
                {
                    if (newFactory != null)
                    {
                        cf.Add(newFactory);
                    }
                    newFactory = new CarFactory();
                    newFactory.Name = sr.ReadLine();
                    continue;
                }
                try
                {
                    Car newCar = Car.Parse(line);
                    newFactory.Cars.Add(newCar);
                }
                catch (Exception error)
                {
                    Console.WriteLine("[CarFactory]: {0}", error.Message);
                    Console.WriteLine("Line: {0}", line);
                    continue;
                }
            }
            return cf;
        }
    }
}
