using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;

namespace CombatCore.Actions.ArcherActions
{
    class ArcherAttackAction : IAction
    {
        private static Random rand = new Random();
        public (int damage, string message, string? effectMessage) Action(Character attacker, Character target)
        {
            string message;
            int attack = attacker.Attack;
            int damage = attack;
            bool crit = rand.Next(0, 100) < 25;

            bool miss = rand.Next(0, 100) < 20;
            if (miss)
            {
                message = $"❌ {attacker.Name} errou o ataque!";
                return (0, message, null);
            }

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
