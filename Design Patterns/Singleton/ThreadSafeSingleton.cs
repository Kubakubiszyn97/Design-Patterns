using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Singleton per Thread
namespace Design_Patterns.Singleton
{
    public sealed class PerThreadSingleton
    {
        private static ThreadLocal<PerThreadSingleton> threadInstance
            = new ThreadLocal<PerThreadSingleton>(
                () => new PerThreadSingleton());
        
        public static PerThreadSingleton Instance => threadInstance.Value;

        public int Id;

        private PerThreadSingleton()
        {
            Id = Thread.CurrentThread.ManagedThreadId;
        }
    }
}
