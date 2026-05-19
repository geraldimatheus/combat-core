using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Effects
{
    class BurnEffect : IEffect
    {
        int turns = 3;
        public (int turns, int heal, string message) EffectAction(Character target)
        {
            int damage = ((target.MaxHP * 5) / 100);
            string message = $"{target.Name} está queimando por {turns} rodadas! Sofreu {damage} de dano.";
            target.ReceiveDamage(damage);
            turns--;

            if (turns <= 0)
            {
                message = $"O efeito de queimação acabou.";
                return (0, 0, message);
            }
            return (turns, 0, message);
        }
    }
}
