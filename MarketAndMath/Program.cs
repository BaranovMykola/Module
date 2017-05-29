﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MarketAndMath
{
    class Program
    {

        public static event EventHandler<EventArgs> OnNMultiplier;
        public static event EventHandler OnFullScreen; 

        static Program()
        {
            OnNMultiplier += ShowNumber;
            OnFullScreen += AskUser;
        }

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
            Console.WriteLine();

            /*****************************************************************************************/

            try
            {
                TryAllNumbers(0, 2000000000, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Terminated...");
            }
            
            Console.ReadKey();

        }

        public static int GetDividersCount(int element)
        {
            int count = 0;
            int divider = 2;
            while (element >= divider)
            {
                if (element%divider == 0)
                {
                    element /= divider;
                    ++count;
                    continue;
                }
                ++divider;
            }
            return count;
        }

        public static void TryAllNumbers(int from, int to, int N)
        {
            int count = 0;
            for (int i = from; i < to; i++)
            {
                if (GetDividersCount(i) == N)
                {
                    ++count;
                    OnNMultiplier.Invoke(null, new NumberArg(i));
                    if (count == 10)
                    {
                        count = 0;
                        OnFullScreen.Invoke(null, EventArgs.Empty);
                    }
                }
            }
            Console.WriteLine("Process ended");
        }

        public static void ShowNumber(object sender, EventArgs args)
        {
            var numb = args as NumberArg;
            Console.WriteLine($"Found {numb.Number} number");
        }

        public static void AskUser(object sender, EventArgs args)
        {
            Console.WriteLine("Do you want to continue? [Y\\N]");
            var ans = (char)Console.Read();
            if (ans == 'N' || ans == 'n')
            {
                throw new TimeoutException();
            }
        }
    }
}