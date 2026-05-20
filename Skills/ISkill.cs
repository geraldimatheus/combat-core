using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Skills
{
    interface ISkill
    {
        public (int damage, string message, string? effectMessage) Skill(Character attacker, Character target);
    }
}
