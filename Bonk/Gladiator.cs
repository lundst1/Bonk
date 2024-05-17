using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk
{
    class Gladiator : IGladiator
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
        public string Name 
        { 
            get { return name; } 
        }
        public int Strength 
        { 
            get { return strength; }
        }
        public int Agility 
        { 
            get { return agility; } 
        }
        public int Intelligence 
        { 
            get {  return intelligence; } 
        }
        public int Constitution 
        { 
            get {  return constitution; } 
        }
        public delegate void EventHandler<ArenaEventArgs>(object sender, ArenaEventArgs e);
        public event EventHandler<ArenaEventArgs> Roll;
        public event EventHandler<ArenaEventArgs> Attack;
        public event EventHandler<ArenaEventArgs> Faint;

        private int Dice(int sides)
        {
            int result;
            Random random = new Random();
            result = random.Next(1, sides+1);

            return result;
        }
    }
}
