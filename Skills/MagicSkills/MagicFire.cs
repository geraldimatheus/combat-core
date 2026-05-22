using CombatCore.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills.MagicSkills
{
    class MagicFire : ISkill
    {
        public string Name { get { return "🔥 Fogo ardente"; } }

        private static Random rand = new Random();
        public (int damage, bool miss, bool crit) Skill(Character attacker, Character target)
        {
            int attack = attacker.Attack;
            List<IEffect> effects = target.Effects;
            bool miss = rand.Next(0, 100) < 15;

            if (miss)
                return (0, true, false);

            IEffect effect = new BurnEffect();
            effects.Add(effect);
            int damage = attack + rand.Next(0, 11);
            return (damage, false, false);
        }

    }
}
