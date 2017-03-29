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
