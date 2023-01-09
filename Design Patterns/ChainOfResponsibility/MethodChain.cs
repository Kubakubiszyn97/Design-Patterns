using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.ChainOfResponsibility
{
    public class Creature
    {
        public string Name;
        public int Attack, Defense;

        public Creature(string name, int attack, int defense )
        {
            Name = name;
            Attack = attack;
            Defense = defense;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }

    public class CreatureModifier
    {
        protected Creature creature;
        protected CreatureModifier next; // linked list;

        public CreatureModifier(Creature creature)
        {
            this.creature = creature;
        }

        public void Add(CreatureModifier modifier)
        {
            if (next != null) next.Add(modifier);
            else next = modifier;
        }

        public virtual void Handle() => next?.Handle();
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Doubling {creature.Name}'s attack");
            creature.Attack *= 2;
            base.Handle();
        }
    }

    public class NoBonusesModifier : CreatureModifier
    {
        public NoBonusesModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
        }
    }

    public class IncreasedDefenseModifier : CreatureModifier
    {
        public IncreasedDefenseModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Increase {creature.Name}'s defense");
            creature.Defense *= 3;
            base.Handle();
        }
    }
}
