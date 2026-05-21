using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;

namespace CombatCore.Actions.ArcherActions
{
    class ArcherAttack : IAction
    {
        private static Random rand = new Random();
        public (int damage, int heal, string message, string? effectMessage) Action(Character attacker, Character target)
        {
            string message;
            int attack = attacker.Attack;
            int damage = attack;
            bool crit = rand.Next(0, 100) < 25;

            if (crit)
            {
                message = $"{attacker.Name} acertou um ataque crítico em {target.Name}! Causou {damage * 2} de dano!";
                return (damage * 2, 0, message, null);
            }

            message = $"{attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, 0, message, null);
        }

    }
}
