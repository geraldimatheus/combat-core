using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions.ArcherActions;
using CombatCore.Skills.ArrowSkills;

namespace CombatCore.Classes
{
    class Archer : Character
    {
        public Archer(string name)
            : base(name, 100, 30)
        {
            Actions.Add(new ArcherAttack());    

            Skills.Add(new FireArrow());
            Skills.Add(new PoisonArrow());
            Skills.Add(new StunArrow());
        }
    }
}
