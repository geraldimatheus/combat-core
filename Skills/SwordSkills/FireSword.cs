using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;
using CombatCore.Effects;

namespace CombatCore.Skills.SwordSkills
{
    class FireSword : ISkill
    {
        public string Name { get { return "🔥 Espada flamejante"; }  }

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
            int damage = attack + 5;
            bool crit = rand.Next(0, 100) < 25;

            if (crit)
                return (damage * 2, false, true);

            return (damage, false, false);

        }
    }
}
