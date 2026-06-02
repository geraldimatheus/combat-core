using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CombatCore.Effects
{
    interface IEffect
    {
        string Name { get; }
        int InitialTurns { get; }
        public (int damage, int heal, int turns) EffectAction(Character target);
    }
}
