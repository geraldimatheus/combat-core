using CombatCore;
using CombatCore.Effects;
using CombatCore.Actions;
using CombatCore.Skills;
using CombatCore.Classes;

void ApplyEffects(Character target)
{
    List<IEffect> effects = target.Effects;
    for (int i = effects.Count - 1; i >= 0; i--)
    {
        var value = effects[i].EffectAction(target);
        target.ReceiveHeal(value.heal);
        Console.WriteLine(value.message);
        if (value.turns == 0)
            effects.Remove(effects[i]);
    }
}

void ExecuteChoices(Character attacker, Character target, ISkill? Skill, IAction? Action)
{
   
    ISkill? skill = Skill;
    IAction? action = Action;

    if (skill != null)
    {
        var value = skill.Skill(attacker, target);
        target.ReceiveDamage(value.damage);
        string message = value.message;
        string? effectMessage = value.effectMessage;
        Console.WriteLine(message);
        if (effectMessage != null)
            Console.WriteLine(effectMessage);
    }
    else if (action != null)
    {
        var value = action.Action(attacker, target);
        string message = value.message;
        string? effectMessage = value.effectMessage;

        target.ReceiveDamage(value.damage);
        Console.WriteLine(message);

        if (effectMessage != null)
            Console.WriteLine(effectMessage);
    }
    else
        Console.WriteLine("Erro inesperado.");
}

void Turn(Character attacker, Character target, ISkill? skill, IAction? action)
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine($" TURNO DE {attacker.Name.ToUpper()}");
    Console.WriteLine("================================");
    ApplyEffects(attacker);
    Thread.Sleep(1000);
    if (target.IsDead())
    {
        Console.WriteLine($"{target.Name} morreu!");
        return;
    }

    ExecuteChoices(attacker, target, skill, action);
    Thread.Sleep(1000);
    if (target.IsDead())
    {
        Console.WriteLine($"{target.Name} morreu!");
        return;
    }

    attacker.ShowStatus();
    target.ShowStatus();
}

(ISkill? skill, IAction? action) AttackType(Character player)
{
    string? input;
    string? choose;
    int number;
    IAction? action;
    ISkill? choosenSkill;

    do
    {
        Console.WriteLine("");
        Console.WriteLine($"{player.Name}, qual ação você quer tomar?");
        Console.WriteLine($"1 - Ataque Básico");
        Console.WriteLine($"2 - Skills");
        Console.WriteLine($"===========================");
        input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Entrada inválida! O campo não pode ser nulo ou vazio.");
        }
        else if (int.Parse(input) < 1 || int.Parse(input) > 2)
            Console.WriteLine("Digite 1 ou 2!");
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

                Console.WriteLine("");
                Console.WriteLine($"{player.Name}, qual skill você quer usar?");
                Console.WriteLine($"===========================");
                choose = Console.ReadLine();
                Console.WriteLine("");
               
                if (string.IsNullOrWhiteSpace(choose))
                {
                    Console.WriteLine("Entrada inválida! O campo não pode ser nulo ou vazio.");
                    continue;
                }

                number = int.Parse(choose);

                if (number < 1 || number > (player.Skills.Count))
                {
                    Console.WriteLine($"Digite um número entre 1 e {player.Skills.Count}!");
                    continue;
                }
            }
            while (string.IsNullOrWhiteSpace(choose) || int.Parse(choose) < 1 || int.Parse(choose) > (player.Skills.Count));

            number = int.Parse(choose);
            choosenSkill = player.Skills[number - 1];
            return (choosenSkill, null);

        default:
            Console.WriteLine("Erro, tente novamente.");
            return (null, null);
    }
}

void Fight(Character attacker, Character target)
{
    Console.WriteLine("========== TURNO ==========");
    Console.WriteLine($"⚔️ {attacker.Name} vs 🏹 {target.Name}");
    Console.WriteLine("===========================");
    while (!attacker.IsDead() && !target.IsDead())
    {
        var result = AttackType(attacker);
        Turn(attacker, target, result.skill, result.action);
        if (target.IsDead())
            break;

        result = AttackType(target);
        Turn(target, attacker, result.skill, result.action);
        if (attacker.IsDead())
            break;
    }
}

List<Character> characters = new List<Character>()
{
    new Warrior("Guts"),
    new Mage("Strange"),
    new Archer("Usopp")
};

Character guts = characters[0];
Character usopp = characters[2];
Fight(guts, usopp);