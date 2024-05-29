using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bonk.Gladiators
{
    public class Rouge : Gladiator
    {
        public Rouge(string name, int strength, int agility, int intelligence, int constitution) : base(name, strength, agility, intelligence, constitution) 
        {
            CalculateDefenseScore();
            base.GladiatorClass = Enums.Classes.Rouge;

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
            string message = $"deals {attackRoll} damage";
            ArenaEventArgs arenaEventArgs = new ArenaEventArgs(Name, message, attackRoll);
            base.RaiseAttackEvent(arenaEventArgs);
        }
        private void CalculateDefenseScore()
        {
            base.DefenseScore = RollDice(20) + base.Agility;
        }
    }
}
