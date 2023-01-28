using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.State
{
    public enum State { OffHook, Connecting, Connected, OnHold }
    public enum Trigger { CallDialed, HungUp, CallConnected, PlacedOnHold, TakenOffHold, LeftMessage }
}
