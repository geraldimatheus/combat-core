using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;

namespace CombatCore.Actions.MageActions
{
    class MageAttackAction : IAction
    {
        private static Random rand = new Random();
        public (int damage, string message, string? effectMessage) Action(Character attacker, Character target)
        {
            string message;
            bool miss = rand.Next(0, 100) < 10;
            if (miss)
            {
                message = $"❌ {attacker.Name} errou o ataque!";
                return (0, message, null);
            }

            int attack = attacker.Attack;
            int damage = attack + rand.Next(0, 11);
            message = $"🩸 {attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, message, null);
        }

    }
}
