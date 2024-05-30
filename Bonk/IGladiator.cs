using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk
{
    /// <summary>
    /// Interface for gladiator class.
    /// </summary>
    interface IGladiator
    {
        /// <summary>
        /// The name of the gladiator.
        /// Read acceess.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The strength score of the gladiator.
        /// Read access.
        /// </summary>
        int Strength { get; }
        /// <summary>
        /// The agility score of the gladiator.
        /// Read access.
        /// </summary>
        int Agility { get; }
        /// <summary>
        /// The intelligence score of the gladiator.
        /// Read access.
        /// </summary>
        int Intelligence { get; }
        /// <summary>
        /// The constitution score of the gladiator.
        /// Read access.
        /// </summary>
        int Constitution { get; }
        /// <summary>
        /// Method where the gladiator rolls to hit.
        /// </summary>
        public void ActionRollHit();
        /// <summary>
        /// Method where the gladiator rolls for damage.
        /// </summary>
        public void ActionAttack();

    }
}
