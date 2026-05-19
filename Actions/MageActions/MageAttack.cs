using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Actions;
using CombatCore.Effects;

namespace CombatCore.Actions.MageActions
{
    class MageAttack : IAction
    {
        public string PlayerChoice(Character player)
        {
            while (true)
            {
                Console.WriteLine("Qual ataque de mago deseja?");
                Console.WriteLine($"9 - Ataque Normal");
                Console.WriteLine($"10 - Magia venenosa (10% de chance de erro)");
                Console.WriteLine($"11 - Magia flamejante (15% de chance de erro)");
                Console.WriteLine($"12 - Magia atordoante (20% de chance de erro)");
                Console.WriteLine($"13 - Magia curadora");
                Console.WriteLine($"Digite um número (9-13)");

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Entrada inválida! O campo não pode ser nulo ou vazio.");
                else if (int.Parse(input) < 9 || int.Parse(input) > 13)
                    Console.WriteLine("Digite um número de 9 a 13!");
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
                message = $"{attacker.Name} errou o ataque!";
                return (0, 0, message, effectMessage);
            }

            int attack = attacker.Attack;

            List<IEffect> effects = target.Effects;

            int choice = int.Parse(PlayerChoice(attacker));

            if (choice == 10)
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

            else if (choice == 11)
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

            else if (choice == 12)
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

            else if (choice == 13)
            {
                IEffect effect = new HealEffect();
                List<IEffect> effects2 = attacker.Effects;
                effects2.Add(effect);
                message = $"{attacker.Name} se curou!";
                return (0, 0, message, effectMessage);
            }

            int damage = attack + rand.Next(0, 11);
            message = $"{attacker.Name} atacou causando {damage} de dano em {target.Name}!";
            return (damage, 0, message, effectMessage);
        }
    }
}
