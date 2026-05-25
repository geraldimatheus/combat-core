using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions.ArcherActions;
using CombatCore.Skills.ArrowSkills;
using CombatCore.Skills;

namespace CombatCore.Classes
{
    class ArcherClass : Character
    {
        public const string icon = "🏹";
        private const string _class = "Arqueiro";
        public ArcherClass(string name)
            : base(name, _class, icon, 100, 30)
        {
            basicAttack = new ArcherAttackAction();    

            Skills.Add(new FireArrow());
            Skills.Add(new PoisonArrow());
            Skills.Add(new StunArrow());
            Skills.Add(new HealSkill());
        }
    }
}
