using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;

namespace CombatCore.Actions.WarriorActions
{
    class WarriorAttackAction : IAction
    {
        private static Random rand = new Random();
        public (int damage, string message, string? effectMessage) Action(Character attacker, Character target)
        {
            int attack = attacker.Attack;
            string message;
            int damage = attack + 5;
            bool crit = rand.Next(0, 100) < 25;

            if (crit)
            {
                message = $"💥 {attacker.Name} acertou um ataque crítico em {target.Name}! Causou {damage * 2} de dano!";
                return (damage * 2, message, null);
            }

            message = $"🩸 {attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, message, null);
        }
    }
}
