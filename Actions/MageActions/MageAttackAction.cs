using CombatCore.Actions;
using CombatCore.Actions.WarriorActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Actions.MageActions
{
    class MageAttackAction : IAction
    {
        private static Random rand = new Random();
        public (int damage, bool miss, bool crit) Action(Character attacker, Character target)
        {
            bool miss = rand.Next(0, 100) < 10;
            if (miss)
                return (0, true, false);

            int damage = attacker.CalculateDamage(attacker.basicAttack, null);
            return (damage, false, false);
        }

    }
}
