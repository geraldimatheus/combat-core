using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CombatCore.Effects
{
    interface IEffect
    {
        public (int turns, int heal, string message) EffectAction(Character target);
    }
}
