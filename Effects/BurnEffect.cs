using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Effects
{
    class BurnEffect : IEffect
    {
        public string Name { get { return "Queimadura"; } }

        int turns = 3;
        public (int damage, int heal, int turns) EffectAction(Character target)
        {
            int damage = ((target.MaxHP * 5) / 100);
            target.ReceiveDamage(damage);
            turns--;

            if (turns <= 0)
                return (0, 0, 0);
            return (damage, 0, turns);
        }
    }
}
