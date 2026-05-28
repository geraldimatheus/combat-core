using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;

namespace CombatCore.Actions.WarriorActions
{
    class WarriorAttackAction : IAction
    {
        private static Random rand = new Random();
        public (int damage, bool miss, bool crit) Action(Character attacker, Character target)
        {
            int damage = attacker.CalculateDamage(attacker.basicAttack, null);

            bool crit = rand.Next(0, 100) < 25;
            if (crit)
                return (damage * 2, false, true);

            return (damage, false, false);
        }
    }
}
