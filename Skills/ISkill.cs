using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills
{
    interface ISkill
    {
        string Name { get; }
        public (int damage, bool miss, bool crit) Skill(Character attacker, Character target);
    }
}
