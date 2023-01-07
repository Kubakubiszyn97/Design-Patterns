
using Design_Patterns.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.ExtensionMethods
{
    public static class PercentageExtensions
    {
        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }
    }
}
