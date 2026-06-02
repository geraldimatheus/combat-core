global using System;
global using System.Collections.Generic;
global using System.Text;

namespace CombatCore.Effects
{
    class StunEffect : IEffect
    {
        public string Name { get { return "Atordoamento"; } }
        public int InitialTurns => 1;
        public (int damage, int heal, int turns) EffectAction(Character target)
        {
            return (0, 0, 0);
        }
    }
}
