using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Proxy
{
    //50% = 0.5 100 -> 

    [DebuggerDisplay("{value*100.0f}%")]
    public struct Percentage
    {
        private readonly float value;

        internal Percentage(float value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"{value * 100}%";
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p.value;
        }

        public static Percentage operator +(Percentage p1, Percentage p2)
        {
            return new Percentage(p1.value + p2.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}
