using CombatCore.Actions.MageActions;
using CombatCore.Skills.MagicSkills;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Classes
{
    class Mage : Character
    {
        public Mage(string name)
            : base(name, 85, 35)
        {
            basicAttack = new MageAttack();

            Skills.Add(new MagicFire());
            Skills.Add(new MagicPoison());
            Skills.Add(new MagicStun());
        }
    }
}
