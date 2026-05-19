using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
using CombatCore.Effects;

using static System.Collections.Specialized.BitVector32;

namespace CombatCore.Actions.WarriorActions
{
    class WarriorAttack : IAction
    {
        public string PlayerChoice(Character player)
        {
            while (true)
            {
                Console.WriteLine("Qual ataque de guerreiro deseja usar?");
                Console.WriteLine("1 - Ataque Normal");
                Console.WriteLine("2 - Espadada venenosa (10% de chance de erro)");
                Console.WriteLine("3 - Espadada flamejante (15% de chance de erro)");
                Console.WriteLine("4 - Espadada atordoante (20% de chance de erro)");
                Console.WriteLine("Digite um número (1-4):");

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Entrada inválida! O campo não pode ser nulo ou vazio.");
                else if (int.Parse(input) < 1 || int.Parse(input) > 4)
                    Console.WriteLine("Digite um número de 1 a 4!");
                else
                    return input;
            }
        }

        private static Random rand = new Random();
        public (int damage, int heal, string message, string? effectMessage) Action(Character attacker, Character target)
        {
            int attack = attacker.Attack;

            List<IEffect> effects = target.Effects;

            string message;
            string? effectMessage = null;

            int choice = int.Parse(PlayerChoice(attacker));

            if (choice == 2)
            {
                bool miss = rand.Next(0, 100) < 10;
                if (miss)
                {
                    message = $"{attacker.Name} errou o ataque!";
                    return (0, 0, message, effectMessage);
                }
                IEffect effect = new PoisonEffect();
                effects.Add(effect);
                effectMessage = $"{target.Name} foi envenenado!";
            }
            else if (choice == 3)
            {
                bool miss = rand.Next(0, 100) < 15;
                if (miss)
                {
                    message = $"{attacker.Name} errou o ataque!";
                    return (0, 0, message, effectMessage);
                }
                IEffect effect = new BurnEffect();
                effects.Add(effect);
                effectMessage = $"{target.Name} foi queimado!";
            }
            else if (choice == 4)
            {
                bool miss = rand.Next(0, 100) < 20;
                if (miss)
                {
                    message = $"{attacker.Name} errou o ataque!";
                    return (0, 0, message, effectMessage);
                }
                IEffect effect = new StunEffect();
                effects.Add(effect);
                effectMessage = $"{target.Name} foi stunado!";
            }

            int damage = attack + 5;
            bool crit = rand.Next(0, 100) < 25;

            if (crit)
            {
                message = $"{attacker.Name} acertou um ataque crítico em {target.Name}! Causou {damage} de dano!";
                return (damage * 2, 0, message, effectMessage);
            }

            message = $"{attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, 0, message, effectMessage);
        }
    }
}
