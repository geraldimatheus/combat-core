using CombatCore.Actions.WarriorActions;
using CombatCore.Skills;
using CombatCore.Skills.SwordSkills;

namespace CombatCore.Classes
{
    class WarriorClass : Character
    {
        public WarriorClass(string name)
            : base(name, 115, 20)
        {
            basicAttack = new WarriorAttackAction();

            Skills.Add(new FireSword());
            Skills.Add(new PoisonSword());
            Skills.Add(new StunSword());
            Skills.Add(new HealSkill());
        }
    }
}
