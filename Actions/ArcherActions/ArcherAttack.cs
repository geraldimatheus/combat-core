using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;
using CombatCore.Effects;

namespace CombatCore.Actions.ArcherActions
{
    class ArcherAttack : IAction
    {
        public string PlayerChoice(Character player)
        {
            while (true)
            {
                Console.WriteLine("Qual ataque de arqueiro deseja?");
                Console.WriteLine($"5 - Ataque Normal");
                Console.WriteLine($"6 - Flecha venenosa (10% de chance de erro)");
                Console.WriteLine($"7 - Flecha flamejante (15% de chance de erro)");
                Console.WriteLine($"8 - Flecha atordoante (20% de chance de erro)");
                Console.WriteLine($"Digite um número (5-8)");

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Entrada inválida! O campo não pode ser nulo ou vazio.");
                else if (int.Parse(input) < 5 || int.Parse(input) > 8)
                    Console.WriteLine("Digite um número de 5 a 8!");
                else
                    return input;
            }
        }

        private static Random rand = new Random();
        public (int damage, int heal, string message, string? effectMessage) Action(Character attacker, Character target)
        {
            string message;
            string? effectMessage = null;
            bool miss = rand.Next(0, 100) < 10;
            if (miss)
            {
                message =  $"{attacker.Name} errou o ataque!";
                return (0, 0, message, effectMessage);
            }

            int attack = attacker.Attack;

            List<IEffect> effects = target.Effects;

            int choice = int.Parse(PlayerChoice(attacker));

            if (choice == 6)
            {
                miss = rand.Next(0, 100) < 10;
                if (miss)
                {
                    message = $"{attacker.Name} errou o ataque!";
                    return (0, 0, message, effectMessage);
                }
                IEffect effect = new PoisonEffect();
                effects.Add(effect);
                effectMessage = $"{target.Name} foi envenenado!";
            }
            else if (choice == 7)
            {
                miss = rand.Next(0, 100) < 15;
                if (miss)
                {
                    message = $"{attacker.Name} errou o ataque!";
                    return (0, 0, message, effectMessage);
                }
                IEffect effect = new BurnEffect();
                effects.Add(effect);
                effectMessage = $"{target.Name} foi queimado!";
            }
            else if (choice == 8)
            {
                miss = rand.Next(0, 100) < 20;
                if (miss)
                {
                    message = $"{attacker.Name} errou o ataque!";
                    return (0, 0, message, effectMessage);
                }
                IEffect effect = new StunEffect();
                effects.Add(effect);
                effectMessage = $"{target.Name} foi stunado!";
            }

            int damage = attack;
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
