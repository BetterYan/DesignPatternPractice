using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.WithStateLessLib
{
    public enum State
    {
        OffHook,
        Connecting,
        Connected,
        OnHook
    }

    public enum Trigger
    {
        CallDialed,
        HungUp,
        CallConnected,
        PlacedOnHold,
        TakenOffHold,
        LeftMessage
    }

    public static class Test
    {
        public static void Execute()
        {
            var call = new StateMachine<State, Trigger>(State.OffHook);
            call.Configure(State.OffHook).Permit(Trigger.CallDialed, State.Connected);
            //and so on.
            call.Fire(Trigger.CallDialed);
        }
    }
}