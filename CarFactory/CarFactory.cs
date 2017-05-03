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
                Car newCar = Car.Parse(line);
                newFactory.Cars.Add(newCar);
            }
            return cf;
        }
    }
}
