using CombatCore.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills
{
    class HealSkill : ISkill
    {
        public string Name { get { return "Curar"; } }
        public (int damage, string message, string? effectMessage) Skill(Character attacker, Character target)
        {
            string message;
            string? effectMessage = null;

            List<IEffect> effects = target.Effects;

            IEffect effect = new StunEffect();
            effects.Add(effect);

            message = $"❤️ {attacker.Name} se curou!";
            return (0, message, effectMessage);

        }
    }
}
