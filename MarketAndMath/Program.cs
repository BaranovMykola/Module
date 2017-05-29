using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MarketAndMath
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Market> lst = Market.ReadFromFile("../../Markets.txt");
            lst = lst.OrderBy(s => s.Name).ToList();
            foreach (var market in lst)
            {
                Console.WriteLine(market);
            }
            using (var stream = File.Open("../../Markets.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Market>));
                xml.Serialize(stream, lst);
            }
            var query =
                from item in lst
                group item by item.Id
                into grp
                let x = new {Id = grp.Key, Count = grp.Count(), Max = grp.Max(s => s.Price)}
                orderby x.Count, x.Id
                select x;
            Console.WriteLine();
            foreach (var item in query)
            {
                Console.WriteLine($"Quantity [{item.Count}]\tId [{item.Id}]\tMax price [{item.Max}]");
            }
            Console.ReadKey();


        }
    }
}
