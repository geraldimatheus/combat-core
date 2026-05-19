using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;

namespace CombatCore.Actions.WarriorActions
{
    class BasicWarriorAttack : IAction
    {
        private static Random rand = new Random();
        public (int damage, int heal, string message, string? effectMessage) Action(Character attacker, Character target)
        {
            int attack = attacker.Attack;
            string message;
            int damage = attack + 5;
            bool crit = rand.Next(0, 100) < 25;

            if (crit)
            {
                message = $"{attacker.Name} acertou um ataque crítico em {target.Name}! Causou {damage} de dano!";
                return (damage * 2, 0, message, null);
            }

            message = $"{attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, 0, message, null);
        }
    }
}
