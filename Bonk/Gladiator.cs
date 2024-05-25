using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk
{
    public class Gladiator : IGladiator
    {
        //Private string variable for the gladiators name.
        private string name;
        //Private int variable for the gladiators strength ability score.
        private int strength;
        //Private int variable for the gladiators agility ability score.
        private int agility;
        //Private int variable for the gladiators intelligence ability score.
        private int intelligence;
        //Private int variable for the gladiators constitution ability score.
        private int constitution;
        //Private int variable for the gladiators current health points during a fight.
        private int currentHealthPoints;
        //Private int variabel for the gladiators max health point
        private int maxHealthPoints;
        //Private int for the gladiators defence score
        private int defenseScore;
       /// <summary>
       /// Public property for variable name.
       /// Read access.
       /// </summary>
        public string Name 
        { 
            get { return name; } 
            set { name = value; }
        }
        /// <summary>
        /// Property for variable strength.
        /// Read access.
        /// </summary>
        public int Strength 
        { 
            get { return strength; }
            set { strength = value; }
        }
        /// <summary>
        /// Property for variable agility.
        /// Read access.
        /// </summary>
        public int Agility 
        { 
            get { return agility; } 
            set { agility = value; }
        }
        /// <summary>
        /// Property for variable intelligence.
        /// Read access.
        /// </summary>
        public int Intelligence 
        { 
            get {  return intelligence; } 
            set { intelligence = value; }
        }
        /// <summary>
        /// Property for variable constitution.
        /// Read access.
        /// </summary>
        public int Constitution 
        { 
            get {  return constitution; }
            set { constitution = value; }
        }
        /// <summary>
        /// Property for variable currentHealthPoints.
        /// Both read and write access.
        /// </summary>
        public int CurrentHealthPoints
        {
            get { return currentHealthPoints; }
            set { currentHealthPoints = value; }
        }
        /// <summary>
        /// Property for variable maxHealthPoints.
        /// Read access. 
        /// </summary>
        public int MaxHealthPoints
        {
            get { return maxHealthPoints;  } 
        }
        public int DefenseScore
        {
            get { return defenseScore; }
        }
        public delegate void EventHandler<ArenaEventArgs>(object sender, ArenaEventArgs e);
        public event EventHandler<ArenaEventArgs> Roll;
        public event EventHandler<ArenaEventArgs> Attack;
        public event EventHandler<ArenaEventArgs> Faint;

        internal void RaiseRollEvent(ArenaEventArgs e)
        {
            Roll(Name, e);
        }
        internal void RaiseAttackEvent(ArenaEventArgs e)
        {
            Attack(Name, e);
        }
        public void OnFaint()
        {
            ArenaEventArgs arenaEventArgs = new ArenaEventArgs(Name, "faints", 0);
        }

        public virtual void OnAttack() { }

        public int RollDice(int sides)
        {
            int result;
            Random random = new Random();
            result = random.Next(1, sides+1);

            return result;
        }
    }
}
