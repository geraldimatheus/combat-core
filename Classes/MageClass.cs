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
        public const string icon = "🧙";
        private const string _class = "Mago";
        public MageClass(string name)
            : base(name, _class, icon, 85, 35)
        {
            basicAttack = new MageAttackAction();

            Skills.Add(new MagicFire());
            Skills.Add(new MagicPoison());
            Skills.Add(new MagicStun());
            Skills.Add(new HealSkill());
        }
    }
}
