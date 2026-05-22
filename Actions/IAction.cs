using System;
using System.Collections.Generic;
using System.Text;

namespace CombatCore.Actions
{
    interface IAction
    {
        public (int damage, string message, string? effectMessage) Action(Character attacker, Character target);
    }
}
