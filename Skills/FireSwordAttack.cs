using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;
using CombatCore.Effects;

namespace CombatCore.Skills
{
    class FireSwordAttack : IAction
    {
        private static Random rand = new Random();
        public (int damage, int heal, string message, string? effectMessage) Action(Character attacker, Character target)
        {
            int attack = attacker.Attack;

            List<IEffect> effects = target.Effects;

            string message;
            string? effectMessage = null;
            bool miss = rand.Next(0, 100) < 15;
            if (miss)
            {
                message = $"{attacker.Name} errou o ataque!";
                return (0, 0, message, effectMessage);
            }
            IEffect effect = new BurnEffect();
            effects.Add(effect);
            effectMessage = $"{target.Name} foi queimado!";        
            int damage = attack + 5;
            bool crit = rand.Next(0, 100) < 25;

            if (crit)
            {
                message = $"{attacker.Name} acertou um ataque crítico em {target.Name}! Causou {damage} de dano!";
                return (damage * 2, 0, message, effectMessage);
            }

            message = $"{attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, 0, message, effectMessage);

        }
    }
}
