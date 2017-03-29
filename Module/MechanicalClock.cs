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
