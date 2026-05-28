using CombatCore.Effects;
using CombatCore.Skills.ArrowSkills;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills.MagicSkills
{
    class MagicStun : ISkill
    {
        public string Name { get { return "🌀 Gás atordoante"; } }

        private static Random rand = new Random();
        public (int damage, bool miss, bool crit) Skill(Character attacker, Character target)
        {
            List<IEffect> effects = target.Effects;
            bool miss = rand.Next(0, 100) < 20;

            if (miss)
                return (0, true, false);

            IEffect effect = new StunEffect();
            effects.Add(effect);
            int damage = attacker.CalculateDamage(null, new MagicStun());
            return (damage, false, false);
        }

    }
}
