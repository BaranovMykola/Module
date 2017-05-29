/*
    Market data class
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

namespace MarketAndMath
{
    [Serializable]
    public class Market
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        public int Code { get; set; }
        public string CustomerName { get; set; }

        public Market()
        {
            
        }

        public Market(string name, int id, int price, int code, string customerName)
        {
            Name = name;
            Id = id;
            Price = price;
            Code = code;
            CustomerName = customerName;
        }

        public override string ToString() => $"Name [{Name}]\tId [{Id}]\tPrice [{Price}]\tCode[{Code}]\tCustomer name [{CustomerName}]";

        public static List<Market> ReadFromFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            List<Market> lst = new List<Market>();
            foreach (var line in lines)
            {
                var elements = line.Split(' ');
                lst.Add(new Market(elements[0], int.Parse(elements[1]), int.Parse(elements[2]), int.Parse(elements[3]), elements[4]));
            }
            return lst;
        }
    }
}