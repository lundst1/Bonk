using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk
{
    /// <summary>
    /// Class used for displaying data from class Gladiator in ListView Gladiators.
    /// </summary>
    public class GladiatorListViewItem
    {
        /// <summary>
        /// Property for the name of the gladiator.
        /// Both read and write access.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property for the class of the gladiator.
        /// Both read and write access.
        /// </summary>
        public string Class {  get; set; }
        /// <summary>
        /// Property for the gladiators max hit points.
        /// Both read and write access.
        /// </summary>
        public int MaxHitPoints { get; set; }
        /// <summary>
        /// Property for the gladiators defense score. 
        /// Both read and write access.
        /// </summary>
        public int DefenseScore { get; set; }
        /// <summary>
        /// The index of the gladiator in the ListView.
        /// </summary>
        public int Index { get; set; }
    }
}
