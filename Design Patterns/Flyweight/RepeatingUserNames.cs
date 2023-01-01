using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Flyweight
{
    public class User
    {
        private string fullName;

        public User(string fullName)
        {
            this.fullName = fullName;
        }
    }

    //Memory optimization
    public class User2
    {
        static List<string> strings = new List<string>();
        private int[] names;
        public string FullName => string.Join(" ",
            names.Select(i => strings[i]));

        public User2(string fullname)
        {
            int getOrAdd(string s)
            {
                int index = strings.IndexOf(s);
                if (index != -1) return index;
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }

            names = fullname.Split(' ').Select(getOrAdd).ToArray();
        }
    }
}
