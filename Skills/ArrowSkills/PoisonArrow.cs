using CombatCore.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills.ArrowSkills
{
    class PoisonArrow : ISkill
    {
        public string Name { get { return "☠️ Flecha venenosa"; } }

        private static Random rand = new Random();
        public (int damage, bool miss, bool crit) Skill(Character attacker, Character target)
        {
            List<IEffect> effects = target.Effects;
            bool miss = rand.Next(0, 100) < 10;

            if (miss)
                return (0, true, false);

            IEffect effect = new PoisonEffect();
            effects.Add(effect);
            int damage = attacker.CalculateDamage(null, new PoisonArrow());
            bool crit = rand.Next(0, 100) < 10;

            if (crit)
                return (damage * 2, false, true);

            return (damage, false, false);
        }

    }
}
