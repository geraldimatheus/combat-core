using CombatCore.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills.MagicSkills
{
    class MagicFire : ISkill
    {
        private static Random rand = new Random();
        public (int damage, string message, string? effectMessage) Skill(Character attacker, Character target)
        {
            string message;
            string? effectMessage = null;
            int attack = attacker.Attack;

            List<IEffect> effects = target.Effects;
            bool miss = rand.Next(0, 100) < 15;

            if (miss)
            {
                message = $"{attacker.Name} errou o ataque!";
                return (0, message, effectMessage);
            }

            IEffect effect = new BurnEffect();
            effects.Add(effect);
            effectMessage = $"{target.Name} foi queimado!";

            int damage = attack + rand.Next(0, 11);

            message = $"{attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, message, effectMessage);
        }

    }
}
