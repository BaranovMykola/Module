using System;

namespace MarketAndMath
{
    class NumberArg : EventArgs
    {
        public int Number { get; set; }

        public NumberArg(int number)
        {
            Number = number;
        }
    }
}