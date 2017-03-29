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
            for (int k = 1; k < 2; k++)
            {
                double modificator = (-1) * x * x / (4 * (k + 2) * (k + 2));
                sum += sum * modificator;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Foo(1,0.1));
            Console.ReadKey();
        }
    }
}
