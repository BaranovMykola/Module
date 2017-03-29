/*
    ElectronicClock type
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

namespace Module
{
    class ElectonicClock : Clock
    {
        public enum Battery { Lion, Standart };
        public enum Screen { Tft, Touch };

        public Battery BatteryType { get; set; }
        public Screen ScreenType { get; set; }

        public ElectonicClock(string brand, string producer, Battery battery, Screen screen) : base(brand, producer)
        {
            BatteryType = battery;
            ScreenType = screen;
        }

        public override string ToString()
        {
            return string.Format("{0} Battery: {1} Screen: {2}", base.ToString(), BatteryType, ScreenType);
        }
    }
}
