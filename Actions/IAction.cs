using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Actions
{
    interface IAction
    {
        public (int damage, bool miss, bool crit) Action(Character attacker, Character target);
    }
}
