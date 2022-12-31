using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Decorator
{
    public class CodeBuilder
    {
        private StringBuilder builder = new StringBuilder();

        public CodeBuilder Clear()
        {
            builder.Clear();
            return this;
        }

        public CodeBuilder Append(char value, int repeatCount)
        {
            builder.Append(value, repeatCount);
            return this;
        }

        public CodeBuilder Append(char[] value, int startIndex, int charCount)
        {
            builder.Append(value, startIndex, charCount);
            return this;
        }

        public CodeBuilder AppendLine(string stringToAppend)
        {
            builder.AppendLine(stringToAppend);
            return this;
        }

        public override string ToString()
        {
            return builder.ToString();
        }
        //for all delegate members;
    }
}
