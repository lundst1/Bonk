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
        //Private variable for instance of ListManager<Gladiator>.
        private ListManager<Gladiator> gladiatorManager = new ListManager<Gladiator>();
        //Private variable for the currently active gladiator in the arena fight.
        private Gladiator activeGladiator;
        //Private variable for the currently non active gladiator in the arena fight.
        private Gladiator nonActiveGladiator;
        //Private variable for reference to the listview for the arena fights.
        private ListView lstArena;
        private Dictionary<Gladiator, int> initiatives = new Dictionary<Gladiator, int>();
        public Arena(ListView lstArena) 
        { 
            this.lstArena = lstArena;
        }
        /// <summary>
        /// Method to add gladiator to gladiatorManager.
        /// Subscribes eventhandlers to events.
        /// </summary>
        /// <param name="gladiator">The gladiator to be added.</param>
        public void AddGladiator(Gladiator gladiator)
        {
            gladiator.Initiative += OnInitiative;
            gladiator.Begin += OnBegin;
            gladiator.Roll += OnRollToHit;
            gladiator.Attack += OnRollForDamage;
            gladiator.Faint += OnFaint;
            gladiatorManager.Add(gladiator);
        }
        /// <summary>
        /// Method to delete gladiator given the gladiators index.
        /// </summary>
        /// <param name="index">The index of the gladiator.</param>
        /// <returns>Returns true if the index is within bounds.</returns>
        public bool DeleteGladiator(int index)
        {
            bool success = gladiatorManager.DeleteAt(index);
        
            return success;
        }
        /// <summary>
        /// Method to update gladiator.
        /// </summary>
        /// <param name="index">The index of the gladiator to be updated.</param>
        /// <param name="gladiator">The new gladiator.</param>
        /// <returns>Returns true if the index is within bounds.</returns>
        public bool EditGladiator(int index, Gladiator gladiator)
        {
            bool success = gladiatorManager.ChangeAt(gladiator, index);

            gladiator.Initiative += OnInitiative;
            gladiator.Begin += OnBegin;
            gladiator.Roll += OnRollToHit;
            gladiator.Attack += OnRollForDamage;
            gladiator.Faint += OnFaint;

            return success;
        }
        /// <summary>
        /// Method to retrieve gladiator from gladiatorManager.
        /// </summary>
        /// <param name="index">The index of the gladiator.</param>
        /// <returns>An instance of class Gladiator.</returns>
        public Gladiator GetGladiator(int index)
        {
            Gladiator gladiator = gladiatorManager.GetAt(index);
            return gladiator;
        }
        /// <summary>
        /// Method to retrieve the gladiators in gladiatorManager as a list.
        /// </summary>
        /// <returns>A list of instances of class Gladiator.</returns>
        public List<Gladiator> GetGladiatorList()
        {
            List<Gladiator> gladiatorList = gladiatorManager.List;
            return gladiatorList;
        }
        /// <summary>
        /// Eventhandler for initiative rolls.
        /// Sets initiative for active gladiator.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnInitiative(object sender, ArenaEventArgs e)
        {
            Gladiator gladiator = activeGladiator;
            int initiative = e.Val;
            initiatives[gladiator] = initiative;

            DisplayEvent(new ArenaListViewItem{Name = e.Name, Message = e.Action });
        }
        /// <summary>
        /// Eventhandler to pass the message on which gladiator begins.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnBegin(object sender, ArenaEventArgs e)
        {
            DisplayEvent(new ArenaListViewItem { Name = e.Name, Message = e.Action });
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
                canAttack = true;
            }
            else
            {
                message += ", and it misses!";
                canAttack = false;
            }

            DisplayEvent(new ArenaListViewItem { Name = name, Message = message });

            if (canAttack)
            {
                activeGladiator.OnAttack();
            }

        }
        public void OnRollForDamage(object sender, ArenaEventArgs e) 
        {
            int damage = e.Val;
            nonActiveGladiator.CurrentHealthPoints -= damage;

            DisplayEvent(new ArenaListViewItem { Name = e.Name, Message = e.Action });
        }
        public void OnFaint(object sender, ArenaEventArgs e)
        {
            DisplayEvent(new ArenaListViewItem { Name = e.Name, Message = e.Action});
        }
        private void DisplayEvent(ArenaListViewItem item)
        {
            lstArena.Items.Add(item);
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
        public void Fight(Gladiator[] gladiators)
        {
            lstArena.Items.Clear();

            Gladiator gladiator1 = gladiators[0];
            Gladiator gladiator2 = gladiators[1];
            gladiator1.ResetCurrentHealthPoints();
            gladiator2.ResetCurrentHealthPoints();

            activeGladiator = gladiator1;
            activeGladiator.OnRollInitiative();
            activeGladiator = gladiator2;
            activeGladiator.OnRollInitiative();

            int initiative1 = initiatives[gladiator1];
            int initiative2 = initiatives[gladiator2];

            if (initiative1 != initiative2)
            {
                if (initiative1 > initiative2) 
                { 
                    activeGladiator = gladiator1;
                    nonActiveGladiator = gladiator2;
                }
                if (initiative1 < initiative2)
                {
                    activeGladiator = gladiator2;
                    nonActiveGladiator = gladiator1;
                }
            }
            else
            {
                Random random = new Random();
                int coinToss = random.Next(0, 1);

                if (coinToss == 0) 
                {
                    activeGladiator = gladiator1;
                    nonActiveGladiator = gladiator2;
                }
                else
                {
                    activeGladiator = gladiator2;
                    nonActiveGladiator = gladiator1;
                }
            }

            activeGladiator.OnBegin();

            while (gladiator1.CurrentHealthPoints > 0 && gladiator2.CurrentHealthPoints > 0)
            {
                activeGladiator.OnRollHit();

                Switch();
            }

            if (gladiator1.CurrentHealthPoints <= 0)
            {
                gladiator1.OnFaint();
            }
            if (gladiator2.CurrentHealthPoints <= 0)
            {
                gladiator2.OnFaint();
            }
        }
    }
}
