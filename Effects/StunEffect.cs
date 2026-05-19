global using System;
global using System.Collections.Generic;
global using System.Text;

namespace CombatCore.Effects
{
    class StunEffect : IEffect
    {
        public (int turns, int heal, string message) EffectAction(Character target)
        {
            string message = $"{target.Name} está stunado! Dura uma rodada.";

            return (0, 0, message);
        }
    }
}
