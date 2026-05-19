using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Effects
{
    class HealEffect : IEffect
    {
        public (int turns, int heal, string message) EffectAction(Character target)
        {
            int heal = 30;

            string message = $"{target.Name} se curou em {heal} pontos de vida.";
            return (0, heal, message);
        }
    }
}
