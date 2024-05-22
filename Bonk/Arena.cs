using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListManager;
using Bonk.Gladiators;
using System.Windows.Controls;

namespace Bonk
{
    public class Arena
    { 
        private ListManager<Gladiator> gladiatorManager = new ListManager<Gladiator>();
        private Gladiator activeGladiator;
        private Gladiator nonActiveGladiator;
        private ListView lstArena;
        public Arena(ListView lstArena) 
        { 
            this.lstArena = lstArena;
        }
        public void AddGladiator(Gladiator gladiator)
        {
            gladiator.Roll += OnRollToHit;
            gladiatorManager.Add(gladiator);
        }
        public bool DeleteGladiator(int index)
        {
            bool success = gladiatorManager.DeleteAt(index);
        
            return success;
        }
        public bool EditGladiator(int index, Gladiator gladiator)
        {
            bool success = gladiatorManager.ChangeAt(gladiator, index);

            return success;
        } 

        public void OnRollToHit(object sender, ArenaEventArgs e)
        {
            string name = e.Name;
            string action = e.Action;
            int hitRoll = e.Val;
            bool canAttack = false;

            string message = action;

            if (hitRoll > nonActiveGladiator.DefenseScore)
            {
                message += ", and it hits!";
            }
            else
            {
                message += ", and it misses!";
            }

            //TODO: Display message

            if (canAttack)
            {
                if (sender is Mage)
                {
                    Mage mage = (Mage)sender;
                    mage.OnAttack();
                }
                if (sender is Rouge)
                {
                    Rouge rouge = (Rouge)sender;
                    rouge.OnAttack();
                }
                if (sender is Warrior)
                {
                    Warrior warrior = (Warrior)sender;
                    warrior.OnAttack();
                }
            }

        }
        public void OnRollForDamage(object sender, ArenaEventArgs e) 
        {
            int damage = e.Val;
            nonActiveGladiator.CurrentHealthPoints -= damage;

            //TODO: Display message
        }
        public void OnFaint()
        {

        }
        private void DisplayEvent()
        {

        }
        /// <summary>
        /// Private method to switch which gladiator is active.
        /// </summary>
        private void Switch()
        {
            Gladiator oldActiveGladiator = activeGladiator;
            activeGladiator = nonActiveGladiator;
            nonActiveGladiator = oldActiveGladiator;
        }

    }
}
