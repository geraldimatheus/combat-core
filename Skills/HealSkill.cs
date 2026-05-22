using CombatCore.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills
{
    class HealSkill : ISkill
    {
        public string Name { get { return "❤️ Curar"; } }
        public (int damage, bool miss, bool crit) Skill(Character attacker, Character target)
        {
            List<IEffect> effects = attacker.Effects;
            IEffect effect = new HealEffect();
            effects.Add(effect);
            return (0, false, false);

        }
    }
}
