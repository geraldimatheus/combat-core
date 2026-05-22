using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;

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

            int attack = attacker.Attack;
            int damage = attack + rand.Next(0, 11);
            return (damage, false, false);
        }

    }
}
