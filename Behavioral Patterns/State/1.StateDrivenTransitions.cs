using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.StateDrivenTransitions
{
    //There are three problem:
    //1. A state typically doesn't switch itself;
    //2. A list of possible transitions should not appear all over the place; it's best to keep it in one place
    //3. There is no need to have actual classes modeling states unless they have class-specific behaviors
    public class Switch
    {
        public State state = new OffState();

        public void On()
        {
            state.On(this);
        }

        public void Off()
        {
            state.Off(this);
        }
    }

    public abstract class State
    {
        public virtual void On(Switch sw)
        {
            Console.WriteLine("Light is already on.");
        }

        public virtual void Off(Switch sw)
        {
            Console.WriteLine("Light is already off.");
        }
    }

    public class OnState : State
    {
        public OnState()
        {
            Console.WriteLine("Light turned on.");
        }

        public override void Off(Switch sw)
        {
            Console.WriteLine("Turning light off...");
            sw.state = new OffState();
        }
    }

    public class OffState : State
    {
        public OffState()
        {
            Console.WriteLine("Light turned off.");
        }

        public override void On(Switch sw)
        {
            Console.WriteLine("Turning light on...");
            sw.state = new OnState();
        }
    }
}