using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk
{
    /// <summary>
    /// Class for event argument for arena events.
    /// Implements EventArgs.
    /// </summary>
    public class ArenaEventArgs : EventArgs
    {
        //Private string variable for name of the gladiator.
        private string name;
        //Private string variable for the description of the action.
        private string action;
        //Private int variable for a numerical value from the action.
        private int val;
        /// <summary>
        /// Public property for variable name.
        /// Both read and write access.
        /// </summary>
        public string Name
        { 
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Public property for variable action.
        /// Both read and write access.
        /// </summary>
        public string Action
        {
            get { return action; }
            set {  action = value; }
        }
        /// <summary>
        /// Public property for variable val.
        /// Both read and write access.
        /// </summary>
        public int Val
        {
            get { return val; }
            set { val = value; }
        }
        /// <summary>
        /// Constructor for ArenaEventArgs.
        /// </summary>
        /// <param name="name">The name of the gladiator.</param>
        /// <param name="action">A description of the action.</param>
        /// <param name="val">A numerical value from the action.</param>
        public ArenaEventArgs(string name, string action, int val) 
        {
            this.name = name;
            this.action = action;
            this.val = val;
        }
    }
}
