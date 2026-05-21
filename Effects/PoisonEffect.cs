using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Effects
{
    class PoisonEffect : IEffect
    {
        int turns = 3;
        public (int turns, int heal, string message) EffectAction(Character target)
        {
            int damage = ((target.MaxHP * 3) / 100);
            string message = $"☠️ {target.Name} foi envenenado por {turns} rodadas! Sofreu {damage} de dano.";
            target.ReceiveDamage(damage);
            turns--;

            if (turns <= 0)
            {
                message = $"O efeito de envenenamento acabou.";
                return (0, 0, message);
            }
            return (turns, 0, message);
        }
    }
}
