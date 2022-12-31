using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Decorator
{
    public class MyStringBuilder
    {
        StringBuilder sb = new StringBuilder();

        public static implicit operator MyStringBuilder(string s)
        {
            var msb = new MyStringBuilder();
            msb.AppendLine(s);
            return msb;
        }

        public static MyStringBuilder operator +(MyStringBuilder msb, string s)
        {
            msb.Append(s);
            return msb;
        }

        public MyStringBuilder AppendLine(string stringToAppend)
        {
            sb.AppendLine(stringToAppend);
            return this;
        }

        public MyStringBuilder Append(string text)
        {
            sb.Append(text);
            return this;
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
