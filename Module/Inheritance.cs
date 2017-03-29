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
            //for (int k = 1; k < 2; k++)
            //{
            //    double modificator = (-1) * x * x / (4 * (k + 2) * (k + 2));
            //    sum += sum * modificator;
            //}
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
            Tabulation(0, 10, 0.9);
            Console.ReadKey();
        }
    }
}
