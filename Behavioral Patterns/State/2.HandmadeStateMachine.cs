using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.HandmadeStateMachine
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

    public class Phone
    {
        private static Dictionary<State, List<(Trigger, State)>> rules = new Dictionary<State, List<(Trigger, State)>>
        {
            [State.OffHook] = new List<(Trigger, State)>
            {
                (Trigger.CallDialed,State.Connecting)
            },
            [State.Connecting] = new List<(Trigger, State)>
            {
                (Trigger.HungUp,State.OffHook),
                (Trigger.CallConnected,State.Connected)
            }
            //more rules here
        };

        private State state = State.OffHook;
        private State exitState = State.OnHook;

        public void Run()
        {
            do
            {
                Console.WriteLine($"The phone is currently {state}");
                Console.WriteLine("Select a trigger:");

                for (int i = 0; i < rules[state].Count; i++)
                {
                    var (t, _) = rules[state][i];
                    Console.WriteLine($"{i}. {t}");
                }
                var input = int.Parse(Console.ReadLine());
                var (_, s) = rules[state][input];
                state = s;
            } while (state != exitState);
            Console.WriteLine("We are done using the phone.");
        }
    }
}