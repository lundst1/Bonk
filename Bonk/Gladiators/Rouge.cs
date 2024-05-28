using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk.Gladiators
{
    public class Rouge : Gladiator
    {
        public Rouge(string name, int strength, int agility, int intelligence, int constitution)
        {
            base.Name = name;
            base.Strength = strength;
            base.Agility = agility;
            base.Intelligence = intelligence;
        }
        public override void OnRollHit()
        {
            int hitRoll = base.RollDice(20);
            hitRoll = hitRoll + Agility;
            ArenaEventArgs arenaEventargs = new ArenaEventArgs(Name, "sneaks around and attempts a stab", hitRoll);
            base.RaiseRollEvent(arenaEventargs);
        }
        public override void OnAttack()
        {
            int attackRoll = base.RollDice(20);
            attackRoll = attackRoll + Agility;
            ArenaEventArgs arenaEventArgs = new ArenaEventArgs(Name, "deals damage", attackRoll);
            base.RaiseAttackEvent(arenaEventArgs);
        }
    }
}
