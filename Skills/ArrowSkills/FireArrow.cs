using CombatCore.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills.ArrowSkills
{
    class FireArrow : ISkill
    {
        public string Name { get { return "🔥 Flecha flamejante"; } }

        private static Random rand = new Random();
        public (int damage, bool miss, bool crit) Skill(Character attacker, Character target)
        {
            List<IEffect> effects = target.Effects;
            bool miss = rand.Next(0, 100) < 15;

            if (miss)
                return (0, true, false);

            IEffect effect = new BurnEffect();
            effects.Add(effect);
            int damage = attacker.CalculateDamage(null, new FireArrow());
            bool crit = rand.Next(0, 100) < 10;

            if (crit)
                return (damage * 2, false, true);

            return (damage, false, false);
        }

    }
}
