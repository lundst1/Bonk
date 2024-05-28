using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk.Gladiators
{
    public class Warrior : Gladiator
    {
        public Warrior(string name, int strength, int agility, int intelligence, int constitution) : base(name, strength, agility, intelligence, constitution)
        {
            CalculateDefenseScore();
        }
        public override void OnRollHit()
        {
            int hitRoll = base.RollDice(20);
            hitRoll = hitRoll + Strength;
            ArenaEventArgs arenaEventargs = new ArenaEventArgs(Name, "tries to hit", hitRoll);
            base.RaiseRollEvent(arenaEventargs);
        }
        public override void OnAttack()
        {
            int attackRoll = base.RollDice(20);
            attackRoll = attackRoll + Strength;
            string message = $"deals {attackRoll} damage";
            ArenaEventArgs arenaEventArgs = new ArenaEventArgs(Name, message, attackRoll);
            base.RaiseAttackEvent(arenaEventArgs);
        }
        private void CalculateDefenseScore()
        {
            base.DefenseScore = RollDice(20) + base.Strength;
        }
    }
}
