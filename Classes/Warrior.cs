using CombatCore.Actions.WarriorActions;
using CombatCore.Skills.SwordSkills;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Classes
{
    class Warrior : Character
    {
        public Warrior(string name)
            : base(name, 115, 20)
        {
            basicAttack = new WarriorAttack();

            Skills.Add(new FireSword());
            Skills.Add(new PoisonSword());
            Skills.Add(new StunSword());
        }
    }
}
