using CombatCore.Actions.WarriorActions;
using CombatCore.Skills;
using CombatCore.Skills.SwordSkills;

namespace CombatCore.Classes
{
    class WarriorClass : Character
    {
        public const string icon = "⚔️";
        private const string _class = "Guerreiro";
        public WarriorClass(string name)
            : base(name, _class, icon, 115, 20)
        {
            basicAttack = new WarriorAttackAction();

            Skills.Add(new FireSword());
            Skills.Add(new PoisonSword());
            Skills.Add(new StunSword());
            Skills.Add(new HealSkill());
        }
    }
}
