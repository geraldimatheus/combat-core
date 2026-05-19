using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Actions
{
    interface IAction
    {
        public (int damage, int heal, string message, string? effectMessage) Action(Character attacker, Character target);
    }
}
