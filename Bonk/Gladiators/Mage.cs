using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk.Gladiators
{
    public class Mage : Gladiator
    {
        public Mage (string name, int strength, int agility, int intelligence, int constitution)
        {
            base.Name = name;
            base.Strength = strength;
            base.Agility = agility;
            base.Intelligence = intelligence;
        }
        public void OnRoll()
        {
            int hitRoll = base.RollDice(20);
            hitRoll = hitRoll + Intelligence;
            ArenaEventArgs arenaEventargs = new ArenaEventArgs(Name, "casts a spell", hitRoll);
            base.RaiseRollEvent(arenaEventargs);
        }
        public override void OnAttack()
        {
            int attackRoll = base.RollDice(20);
            attackRoll = attackRoll + Intelligence;
            ArenaEventArgs arenaEventArgs = new ArenaEventArgs(Name, "deals damage", attackRoll);
            base.RaiseAttackEvent(arenaEventArgs);
        }
    }
}
