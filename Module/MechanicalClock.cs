/*
    MechanicalClock type
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
    class MechanicalClock : Clock
    {
        public int LiveHours { get; set; }
        public int WarrantYears { get; set; }

        public MechanicalClock(string brand, string producer, int liveHours, int warrantYears) : base(brand, producer)
        {
            LiveHours = liveHours;
            WarrantYears = warrantYears;
        }

        public override string ToString()
        {
            return string.Format("{0} LiveHours: {1} WarrantYeras: {2}", base.ToString(), LiveHours, WarrantYears);
        }
    }
}
