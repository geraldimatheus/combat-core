using CombatCore.Actions;
using CombatCore.Actions.ArcherActions;
using CombatCore.Actions.MageActions;
using CombatCore.Actions.WarriorActions;
using CombatCore.Skills;
using CombatCore.Skills.ArrowSkills;
using CombatCore.Skills.MagicSkills;
using CombatCore.Skills.SwordSkills;
using CombatCore.Effects;

namespace CombatCore.Logs
{
    class CombatLog
    {
        public static void StartCombatLog(Character attacker, Character target)
        {
            var attackerClass = attacker.basicAttack;
            var targetClass = target.basicAttack;

            Console.WriteLine("========== TURNO ==========");
            switch (attackerClass)
            {
                case WarriorAttackAction:
                    switch (targetClass)
                    {
                        case WarriorAttackAction:
                            Console.WriteLine($"⚔️ {attacker.Name} vs ⚔️ {target.Name}");
                            break;
                        case ArcherAttackAction:
                            Console.WriteLine($"⚔️ {attacker.Name} vs 🏹 {target.Name}");
                            break;
                        case MageAttackAction:
                            Console.WriteLine($"⚔️ {attacker.Name} vs 🧙 {target.Name}");
                            break;
                        default:
                            Console.WriteLine("⚠️ Erro ao iniciar batalha.");
                            break;
                    }
                    break;
                case ArcherAttackAction:
                    switch (targetClass)
                    {
                        case WarriorAttackAction:
                            Console.WriteLine($"🏹 {attacker.Name} vs ⚔️ {target.Name}");
                            break;
                        case ArcherAttackAction:
                            Console.WriteLine($"🏹 {attacker.Name} vs 🏹 {target.Name}");
                            break;
                        case MageAttackAction:
                            Console.WriteLine($"🏹 {attacker.Name} vs 🧙 {target.Name}");
                            break;
                        default:
                            Console.WriteLine("⚠️ Erro ao iniciar batalha.");
                            break;
                    }
                    break;
                case MageAttackAction:
                    switch (targetClass)
                    {
                        case WarriorAttackAction:
                            Console.WriteLine($"🧙 {attacker.Name} vs ⚔️ {target.Name}");
                            break;
                        case ArcherAttackAction:
                            Console.WriteLine($"🧙 {attacker.Name} vs 🏹 {target.Name}");
                            break;
                        case MageAttackAction:
                            Console.WriteLine($"🧙 {attacker.Name} vs 🧙 {target.Name}");
                            break;
                        default:
                            Console.WriteLine("⚠️ Erro ao iniciar batalha.");
                            break;
                    }
                    break;
            }
            Console.WriteLine("===========================");
        }

        public static (ISkill? skill, IAction? action) AttackTypeLog(Character player)
        {
            string? input;
            string? choose;
            int number;
            IAction? action;
            ISkill? choosenSkill;

            do
            {
                Console.WriteLine($"{player.Name}, qual ação você quer tomar?");
                Console.WriteLine($"1 - Ataque Básico");
                Console.WriteLine($"2 - Skills");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("⚠️ Entrada inválida! O campo não pode ser nulo ou vazio.");
                }
                else if (int.Parse(input) < 1 || int.Parse(input) > 2)
                    Console.WriteLine("⚠️ Digite 1 ou 2!");
                else
                    continue;
            }
            while (string.IsNullOrWhiteSpace(input));

            switch (int.Parse(input))
            {
                case 1:
                    action = player.basicAttack;
                    return (null, action);
                case 2:
                    do
                    {
                        int i = 0;
                        foreach (ISkill skill in player.Skills)
                        {
                            i++;
                            Console.WriteLine($"{i} - {skill.Name}");
                        }

                        Console.WriteLine($"{player.Name}, qual skill você quer usar?");
                        Console.WriteLine($"===========================");
                        choose = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(choose))
                        {
                            Console.WriteLine("⚠️ Entrada inválida! O campo não pode ser nulo ou vazio.");
                            continue;
                        }

                        number = int.Parse(choose);

                        if (number < 1 || number > (player.Skills.Count))
                        {
                            Console.WriteLine($"⚠️ Digite um número entre 1 e {player.Skills.Count}!");
                            continue;
                        }
                    }
                    while (string.IsNullOrWhiteSpace(choose) || int.Parse(choose) < 1 || int.Parse(choose) > (player.Skills.Count));

                    number = int.Parse(choose);
                    choosenSkill = player.Skills[number - 1];
                    return (choosenSkill, null);

                default:
                    Console.WriteLine("⚠️ Erro, tente novamente.");
                    return (null, null);
            }
        }

        public static void SkillLog(Character attacker, Character target, ISkill? skill, int damage, bool miss, bool crit)
        {
            if (skill is StunSword || skill is MagicStun || skill is StunArrow)
            {
                if (miss)
                {
                    Console.WriteLine($"❌ {attacker.Name} errou o ataque!");
                    return;
                }
                else
                {
                    Console.WriteLine($"💫 {target.Name} ficou atordoado!");
                    Console.WriteLine($"🩸 {attacker.Name} atacou causando {damage} de dano em {target.Name}!");
                    return;
                }
            }
            else if (skill is FireSword || skill is MagicFire || skill is FireArrow)
            {
                if (miss)
                {
                    Console.WriteLine($"❌ {attacker.Name} errou o ataque!");
                    return;
                }
                else
                {
                    Console.WriteLine($"🔥 {target.Name} foi queimado!");

                    if (crit)
                    {
                        Console.WriteLine($"💥 {attacker.Name} acertou um ataque crítico em {target.Name}! Causou {damage * 2} de dano!");
                        return;
                    }

                    Console.WriteLine($"🩸 {attacker.Name} atacou causando {damage} de dano em {target.Name}!");
                    return;
                }
            }
            else if (skill is PoisonSword || skill is MagicPoison || skill is PoisonArrow)
            {
                if (miss)
                {
                    Console.WriteLine($"❌ {attacker.Name} errou o ataque!");
                    return;
                }
                else
                {
                    Console.WriteLine($"☠️ {target.Name} foi envenenado!");

                    if (crit)
                    {
                        Console.WriteLine($"💥 {attacker.Name} acertou um ataque crítico em {target.Name}! Causou {damage * 2} de dano!");
                        return;
                    }

                    Console.WriteLine($"🩸 {attacker.Name} atacou causando {damage} de dano em {target.Name}!");
                    return;
                }
            }
            else if (skill is HealSkill)
            {
                Console.WriteLine($"❤️ {attacker.Name} se curou!");
                return;
            }
            else
            {
                Console.WriteLine("⚠️ Erro ao usar skill.");
                return;
            }
        }

        public static void ActionLog(Character attacker, Character target, IAction? action, int damage, bool miss, bool crit)
        {
			if (action is MageAttackAction)
			{
				if (miss)
				{
					Console.WriteLine($"❌ {attacker.Name} errou o ataque!");
					return;
				}
				else
				{
					Console.WriteLine($"🩸 {attacker.Name} atacou causando {damage} de dano em {target.Name}!");
					return;
				}
			}
			else if (action is WarriorAttackAction)
			{
				if (miss)
				{
					Console.WriteLine($"❌ {attacker.Name} errou o ataque!");
					return;
				}
				else
				{
					if (crit)
					{
						Console.WriteLine($"💥 {attacker.Name} acertou um ataque crítico em {target.Name}! Causou {damage * 2} de dano!");
						return;
					}

					Console.WriteLine($"🩸 {attacker.Name} atacou causando {damage} de dano em {target.Name}!");
					return;
				}
			}
			else if (action is ArcherAttackAction)
			{
				if (miss)
				{
					Console.WriteLine($"❌ {attacker.Name} errou o ataque!");
					return;
				}
				else
				{
					if (crit)
					{
						Console.WriteLine($"💥 {attacker.Name} acertou um ataque crítico em {target.Name}! Causou {damage * 2} de dano!");
						return;
					}

					Console.WriteLine($"🩸 {attacker.Name} atacou causando {damage} de dano em {target.Name}!");
					return;
				}
			}
			else
			{
				Console.WriteLine("⚠️ Erro ao usar ataque básico.");
				return;
			}

		}

        public static void EffectsLog(Character target, IEffect? effect, int damage, int heal, int turns)
        {
			if (effect is StunEffect)
			{
					Console.WriteLine($"{target.Name} está atordoado! Dura uma rodada.");
					return;
			}
			else if (effect is PoisonEffect)
			{
				Console.WriteLine($"☠️ {target.Name} está envenenado por {turns} rodadas! Sofreu {damage} de dano.");

				if (turns <= 0)
				{
					Console.WriteLine($"O efeito de envenenamento acabou.");
                    return;
				}
			}
			else if (effect is BurnEffect)
			{
				Console.WriteLine($"🔥 {target.Name} está queimando por {turns} rodadas! Sofreu {damage} de dano.");

				if (turns <= 0)
				{
					Console.WriteLine($"O efeito de queimação acabou.");
					return;
				}
			}
			else if (effect is HealEffect)
			{
				Console.WriteLine($"❤️ {target.Name} se curou em {heal} pontos de vida.");
				return;
			}
			else
			{
				Console.WriteLine("⚠️ Erro ao aplicar efeito.");
				return;
			}
		}

        public static void StartShiftLog(Character attacker)
        {
			Console.Clear();
			Console.WriteLine("================================");
			Console.WriteLine($" TURNO DE {attacker.Name.ToUpper()}");
			Console.WriteLine("================================");
		}

        public static void IsDeadLog(Character target)
        {
			if (target.IsDead())
			{
				Console.WriteLine($"☠️ {target.Name} morreu!");
				return;
			}
		}
	}
}
