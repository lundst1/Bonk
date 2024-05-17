using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk
{
    public class ArenaEventArgs : EventArgs
    {
       
        private string name;
        private string action;
        private int val;

        public string Name
        { 
            get { return name; }
            set { name = value; }
        }
        public string Action
        {
            get { return action; }
            set {  action = value; }
        }
        public int Val
        {
            get { return val; }
            set { val = value; }
        }

        public ArenaEventArgs(string name, string action, int val) 
        {
            this.name = name;
            this.action = action;
            this.val = val;
        }
    }
}
