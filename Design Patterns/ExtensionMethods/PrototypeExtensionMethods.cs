using Design_Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class PrototypeExtensionMethods
{
    //this is to call IDeepCopyable.DeepCopy (because it needs to be called by casting to IDeepCopyable)
    public static T DeepCopy<T>(this IDeepCopyable<T> item) where T : new() 
    {
        return item.DeepCopy();
    }

    public static T DeepCopy<T>(this T person)
        where T : PrototypePerson, new()
    {
        return ((IDeepCopyable<T>)person).DeepCopy();
    }
}
