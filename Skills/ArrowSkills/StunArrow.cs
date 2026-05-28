using CombatCore.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills.ArrowSkills
{
    class StunArrow : ISkill
    {
        public string Name { get { return "⚡ Flecha atordoante"; } }

        private static Random rand = new Random();
        public (int damage, bool miss, bool crit) Skill(Character attacker, Character target)
        {
            List<IEffect> effects = target.Effects;
            bool miss = rand.Next(0, 100) < 20;

            if (miss)
                return (0, true, false);

            IEffect effect = new StunEffect();
            effects.Add(effect);
            int damage = attacker.CalculateDamage(null, new StunArrow());
            return (damage, false, false);

        }
    }
}
