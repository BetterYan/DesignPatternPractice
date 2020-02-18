using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain.MethodChain
{
    //Step1: we have something at first
    public class Creature
    {
        public string Name;
        public int Attack, Defense;

        public Creature(string name, int attack, int defense)
        {
            this.Name = name;
            this.Attack = attack;
            this.Defense = defense;
        }

        public override string ToString()
        {
            return $"[Name]: {Name},[Attack]: {Attack},[Defense]: {Defense}";
        }
    }

    //Step2: The creatue will become much more powerful
    public class CreatureModifier
    {
        protected Creature creature;
        protected CreatureModifier next;

        public CreatureModifier(Creature creature)
        {
            this.creature = creature;
        }

        public void Add(CreatureModifier creatureModifier)
        {
            if (next != null) next.Add(creatureModifier);
            else next = creatureModifier;
        }

        public virtual void Handle() => next?.Handle();
    }

    //Step3: Thing becomes interesting
    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Double {creature.Name}'s attack");
            creature.Attack *= 2;
            base.Handle();
        }
    }

    public class IncreaseDefenseModifier : CreatureModifier
    {
        public IncreaseDefenseModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            if (creature.Attack <= 2)
            {
                Console.WriteLine($"Increasing {creature.Name}'s defense");
                creature.Defense++;
            }
            base.Handle();
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var player = new Creature("John", 1, 1);
            Console.WriteLine(player);
            var root = new CreatureModifier(player);
            root.Add(new IncreaseDefenseModifier(player));
            root.Add(new DoubleAttackModifier(player));
            root.Add(new DoubleAttackModifier(player));
            root.Handle();
            Console.WriteLine(player);
        }
    }
}