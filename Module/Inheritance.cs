using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    class Inheritance
    {
        public static double Foo(double x, double e)
        {
            double sum = x * x / 4;
            double deltaSum = 0;
            int k = 1;
            do
            {
                double modificator = (-1) * x * x / (4 * (k + 2) * (k + 2));
                deltaSum = sum * modificator;
                sum += deltaSum;
                ++k;
            }
            while (Math.Abs(deltaSum) > e);
            return sum;
        }
        public static void Tabulation(double a, double b, double h=1, double e = 0.001)
        {
            for (; a < b + h / 2; a += h)
            {
                Console.WriteLine("F({0}) = {1}", a, Foo(a, e));
            }
        }
        static void Main(string[] args)
        {
            Tabulation(5, 7, 0.5);
            Console.WriteLine();
            var arr = Clock.ReadFromFile("Clocks.txt").ToArray<Clock>();
            Clock.SortByName(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            string brand = "Brand5";
            Console.WriteLine("Total count of electronic clocks [{0}] is {1} (Battery is {2})", brand,
                Clock.CountOfElectronicClocks(arr, brand, ElectonicClock.Battery.Standart), ElectonicClock.Battery.Standart);
            Console.WriteLine();
            Console.WriteLine("Clock with max warranty - {0}", Clock.MetTheMostWarranty(arr));
            Console.ReadKey();
        }
    }
}
