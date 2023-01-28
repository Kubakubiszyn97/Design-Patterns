using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Null_Object
{
    public interface ISingletonLog
    {
        void Warn();

        public static ISingletonLog Null => NullLog.Instance; // Completly hidden from user

        private sealed class NullLog : ISingletonLog
        {
            private NullLog()
            {

            }

            private static Lazy<NullLog> instance = new(() => new NullLog());

            public static ISingletonLog Instance => instance.Value;

            public void Warn()
            {
                throw new NotImplementedException();
            }
        }
    }
} 
