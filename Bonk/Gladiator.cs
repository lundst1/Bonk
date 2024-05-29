using Bonk.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Bonk
{
    /// <summary>
    /// Class for a gladiator.
    /// Is extended by classes Mage, Rouge and Warrior.
    /// Implements interface IGladiator.
    /// </summary>
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
        //Private enum variable for the class of the gladiator.
        private Classes gladiatorClass;
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
        [JsonIgnore]
        public int CurrentHealthPoints
        {
            get { return currentHealthPoints; }
            set { currentHealthPoints = value; }
        }
        /// <summary>
        /// Property for variable gladiatorClass.
        /// Both read and write access.
        /// </summary>
        public Classes GladiatorClass
        {
            get { return gladiatorClass; }
            set { gladiatorClass = value; }
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
            set { defenseScore = value; }
        }
        //Delegate to be used for the gladiators arena events.
        public delegate void EventHandler<ArenaEventArgs>(object sender, ArenaEventArgs e);
        //Event for rolling initiative.
        public event EventHandler<ArenaEventArgs> Initiative;
        //Event for beginning.
        public event EventHandler<ArenaEventArgs> Begin;
        //Event for rolling to hit or miss.
        public event EventHandler<ArenaEventArgs> Roll;
        //Event for rolling damage.
        public event EventHandler<ArenaEventArgs> Attack;
        //Event for fainting.
        public event EventHandler<ArenaEventArgs> Faint;
        /// <summary>
        /// Constructor for class Gladiator.
        /// </summary>
        public Gladiator() { }
        /// <summary>
        /// Constructor for Gladiator.
        /// </summary>
        /// <param name="name">The name of the gladiator.</param>
        /// <param name="strength">The strength score of the gladiator.</param>
        /// <param name="agility">The ability score of the gladiator.</param>
        /// <param name="intelligence">The intelligence score of the gladiator.</param>
        /// <param name="constitution">The constitution score of the gladiator.</param>
        public Gladiator(string name, int strength, int agility, int intelligence, int constitution) : this()
        {
            Name = name;
            Strength = strength;
            Agility = agility;
            Intelligence = intelligence;
            Constitution = constitution;

            CalculateMaxHealthPoints();
        }
        /// <summary>
        /// Method to calculate maximum health points.
        /// </summary>
        private void CalculateMaxHealthPoints()
        {
            maxHealthPoints = RollDice(20) + Constitution; 
        }
        /// <summary>
        /// Method to reset current health points.
        /// </summary>
        public void ResetCurrentHealthPoints()
        {
            currentHealthPoints = maxHealthPoints;
        }
        /// <summary>
        /// Method for raising the event Roll.
        /// Is used by extended classes Mage, Rouge and Warrior.
        /// </summary>
        /// <param name="e">The event arguments for the event.</param>
        internal void RaiseRollEvent(ArenaEventArgs e)
        {
            Roll(Name, e);
        }
        /// <summary>
        /// Method for raising the event Attack.
        /// Is used by extended classes Mage, Rouge and Warrior.
        /// </summary>
        /// <param name="e">The event arguments for the event.</param>
        internal void RaiseAttackEvent(ArenaEventArgs e)
        {
            Attack(Name, e);
        }
        /// <summary>
        /// Method to raise the event Initiative.
        /// Calculates initiative and raises the event.
        /// </summary>
        public void OnRollInitiative()
        {
            int initiative = RollDice(20);
            initiative += Agility;
            string message = $"rolls for initiative ({initiative})";
            ArenaEventArgs arenaEventArgs = new ArenaEventArgs(Name, message, initiative);
            Initiative(Name, arenaEventArgs);
        }
        /// <summary>
        /// Method to raise the event Begin.
        /// </summary>
        public void OnBegin()
        {
            ArenaEventArgs arenaEventArgs = new ArenaEventArgs(Name, "begins", 0);
            Begin(Name, arenaEventArgs);
        }
        /// <summary>
        /// Method to raise the event Faint.
        /// </summary>
        public void OnFaint()
        {
            ArenaEventArgs arenaEventArgs = new ArenaEventArgs(Name, "faints", 0);
            Faint(Name, arenaEventArgs);
        }
        /// <summary>
        /// Virtual method that is overridden by extending classes Mage, Rouge and Warrior.
        /// </summary>
        public virtual void OnRollHit() { }
        /// <summary>
        /// Virtual method that is overridden by extending classes Mage, Rouge and Warrior.
        /// </summary>
        public virtual void OnAttack() { }
        /// <summary>
        /// Method that simulates rolling a dice. 
        /// </summary>
        /// <param name="sides">An integer corresponding the amount of sides the dice has.</param>
        /// <returns>An integer between 1 and the given integer.</returns>
        public int RollDice(int sides)
        {
            int result;
            Random random = new Random();
            result = random.Next(1, sides+1);

            return result;
        }
    }
}
