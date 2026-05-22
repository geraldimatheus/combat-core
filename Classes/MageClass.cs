using CombatCore.Actions.MageActions;
using CombatCore.Skills.MagicSkills;
using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Skills;


namespace CombatCore.Classes
{
    class MageClass : Character
    {
        public MageClass(string name)
            : base(name, 85, 35)
        {
            basicAttack = new MageAttackAction();

            Skills.Add(new MagicFire());
            Skills.Add(new MagicPoison());
            Skills.Add(new MagicStun());
            Skills.Add(new HealSkill());
        }
    }
}
