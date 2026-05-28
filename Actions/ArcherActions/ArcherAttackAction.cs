using CombatCore.Actions;
using CombatCore.Actions.WarriorActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Actions.ArcherActions
{
    class ArcherAttackAction : IAction
    {
        private static Random rand = new Random();
        public (int damage, bool miss, bool crit) Action(Character attacker, Character target)
        {
            int damage = attacker.CalculateDamage(attacker.basicAttack, null);
            bool crit = rand.Next(0, 100) < 25;

            bool miss = rand.Next(0, 100) < 20;
            if (miss)
                return (0, true, false);

            if (crit)
                return (damage * 2, false, true);
            return (damage, false, false);
        }

    }
}
