/*
    Truck class
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
    class Truck : Car
    {
        public int MaxCargoWeight { get; set; }

        public Truck()
        {

        }
        public Truck(string trade, int engineVolume, int price, int count, int maxCargoWeight) : base(trade, engineVolume, price, count)
        {
            MaxCargoWeight = maxCargoWeight;
        }

        public override string ToString() => string.Format("TRUCK:\t{0}\t| Max Cargo Weight: {1}", base.ToString(), MaxCargoWeight);
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj)
        {
                var car = obj as Truck;
                if (car == null) return false;
                return base.Equals(obj) &&
                    car.MaxCargoWeight == MaxCargoWeight &&
                    car.Count == Count &&
                    car.EngineVolume == EngineVolume &&
                    car.Price == Price;
        }
    }
}
