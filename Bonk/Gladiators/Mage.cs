using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk.Gladiators
{
    /// <summary>
    /// Class for the gladiator class Mage. Extends class Gladiator.
    /// </summary>
    public class Mage : Gladiator
    {
        /// <summary>
        /// Constructor for class Mage.
        /// </summary>
        /// <param name="name">The name of the gladiator.</param>
        /// <param name="strength">The strength score of the gladiator.</param>
        /// <param name="agility">The agility score of the gladiator.</param>
        /// <param name="intelligence">The intelligence score of the gladiator.</param>
        /// <param name="constitution">The constitution score of the gladiator.</param>
        public Mage (string name, int strength, int agility, int intelligence, int constitution) : base(name, strength, agility, intelligence, constitution) 
        { 
            CalculateDefenseScore();
            base.GladiatorClass = Enums.Classes.Mage;
        }
        /// <summary>
        /// Method to roll for hitting the opponent.
        /// Calculates a hitroll and raises event for rolling to hit.
        /// </summary>
        public override void ActionRollHit()
        {
            int hitRoll = base.RollDice(20);
            hitRoll = hitRoll + Intelligence;
            ArenaEventArgs arenaEventargs = new ArenaEventArgs(Name, "casts a spell", hitRoll);
            base.RaiseRollEvent(arenaEventargs);
        }
        /// <summary>
        /// Method to roll for damage.
        /// Calculates damage and raises event for rolling damage.
        /// </summary>
        public override void ActionAttack()
        {
            int attackRoll = base.RollDice(20);
            attackRoll = attackRoll + Intelligence;
            string message = $"deals {attackRoll} damage";
            ArenaEventArgs arenaEventArgs = new ArenaEventArgs(Name, message, attackRoll);
            base.RaiseAttackEvent(arenaEventArgs);
        }
        /// <summary>
        /// Method to calculate defencescore.
        /// </summary>
        private void CalculateDefenseScore()
        {
            base.DefenseScore = RollDice(20) + base.Intelligence;
        }
    }
}
