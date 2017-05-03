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
            var cfList = CarFactory.Read(new System.IO.StreamReader("../../CarFactories.txt"));
            foreach (var item in cfList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
