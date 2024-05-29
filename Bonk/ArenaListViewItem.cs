using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk
{
    /// <summary>
    /// Class for displaying data in ListView lstArena.
    /// </summary>
    public class ArenaListViewItem
    {
        /// <summary>
        /// String property for the name of the gladiator doing an action.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// String property for a message describing the gladiators action.
        /// </summary>
        public string Message { get; set; }
    }
}
