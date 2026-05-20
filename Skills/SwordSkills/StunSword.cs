using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;
using CombatCore.Effects;

namespace CombatCore.Skills.SwordSkills
{
    class StunSword : ISkill
    {

        private static Random rand = new Random();
        public (int damage, string message, string? effectMessage) Skill(Character attacker, Character target)
        {
            int attack = attacker.Attack;

            List<IEffect> effects = target.Effects;

            string message;
            string? effectMessage = null;
            bool miss = rand.Next(0, 100) < 20;
            if (miss)
            {
                message = $"{attacker.Name} errou o ataque!";
                return (0, message, effectMessage);
            }
            IEffect effect = new StunEffect();
            effects.Add(effect);
            effectMessage = $"{target.Name} foi stunado!";
            int damage = attack + 5;

            message = $"{attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, message, effectMessage);
        }

    }
}
