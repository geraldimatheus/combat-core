using CombatCore.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills.ArrowSkills
{
    class StunArrow : ISkill
    {
        public string Name { get { return "Flecha atordoante"; } }

        private static Random rand = new Random();
        public (int damage, string message, string? effectMessage) Skill(Character attacker, Character target)
        {
            string message;
            string? effectMessage = null;
            int attack = attacker.Attack;

            List<IEffect> effects = target.Effects;
            bool miss = rand.Next(0, 100) < 20;

            if (miss)
            {
                message = $"{attacker.Name} errou o ataque!";
                return (0, message, effectMessage);
            }
            IEffect effect = new StunEffect();
            effects.Add(effect);
            effectMessage = $"{target.Name} foi stunado!";
            int damage = attack;

            message = $"{attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, message, effectMessage);

        }
    }
}
