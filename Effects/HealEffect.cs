using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Effects
{
    class HealEffect : IEffect
    {
        public string Name { get { return "Cura"; } }
        public (int damage, int heal, int turns) EffectAction(Character target)
        {
            int heal = 30;
            return (0, heal, 0);
        }
    }
}
