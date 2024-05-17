using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonk
{
    interface IGladiator
    {
        string Name { get; }
        int Strength { get; }
        int Agility { get; }
        int Intelligence { get; }
        int Constitution { get; }
    
    }
}
