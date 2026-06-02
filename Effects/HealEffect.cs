using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Effects
{
    class HealEffect : IEffect
    {
        public string Name { get { return "Cura"; } }
        public int InitialTurns => 1;
        public (int damage, int heal, int turns) EffectAction(Character target)
        {
            int heal = (int)Math.Round(target.HP / 0.4);
            target.ReceiveHeal(heal);
            return (0, heal, 0);
        }
    }
}
