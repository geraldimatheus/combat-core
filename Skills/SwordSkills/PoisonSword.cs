using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;
using CombatCore.Effects;

namespace CombatCore.Skills.SwordSkills
{
    class PoisonSword : ISkill
    {
        private static Random rand = new Random();
        public (int damage, string message, string? effectMessage) Skill(Character attacker, Character target)
        {
            int attack = attacker.Attack;

            List<IEffect> effects = target.Effects;

            string message;
            string? effectMessage = null;
            bool miss = rand.Next(0, 100) < 10;
            if (miss)
            {
                message = $"{attacker.Name} errou o ataque!";
                return (0, message, effectMessage);
            }
            IEffect effect = new PoisonEffect();
            effects.Add(effect);
            effectMessage = $"{target.Name} foi envenenado!";
            int damage = attack + 5;
            bool crit = rand.Next(0, 100) < 25;

            if (crit)
            {
                message = $"{attacker.Name} acertou um ataque crítico em {target.Name}! Causou {damage} de dano!";
                return (damage * 2, message, effectMessage);
            }

            message = $"{attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, message, effectMessage);
        }

    }
}
