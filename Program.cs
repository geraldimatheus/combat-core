using CombatCore;
using CombatCore.Effects;
using CombatCore.Actions;
using CombatCore.Actions.WarriorActions;
using CombatCore.Actions.ArcherActions;
using CombatCore.Actions.MageActions;

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

void ExecuteActions(Character attacker, Character target)
{
    List<IAction> actions = attacker.Actions;
    for (int i = actions.Count - 1; i >= 0; i--)
    {
        var value = actions[i].Action(attacker, target);
        target.ReceiveDamage(value.damage);
        actions.Remove(actions[i]);
        string message = value.message;
        string? effectMessage = value.effectMessage;
        Console.WriteLine(message);
        if (effectMessage != null)
            Console.WriteLine(effectMessage);
    }
}

void Turn(Character attacker, Character target)
{
    ExecuteActions(attacker, target);
    ApplyEffects(target);

    if (target.IsDead())
    {
        Console.WriteLine($"{target.Name} morreu!");
        return;
    }

    attacker.ShowStatus();
    target.ShowStatus();
}

void AttackType(Character player)
{
    string? input;
    do
    {
        Console.WriteLine($"{player.Name}, qual ação você quer tomar?");
        Console.WriteLine($"1 - Ataque de Guerreiro");
        Console.WriteLine($"2 - Ataque de Arqueiro");
        Console.WriteLine($"3 - Ataque de Mago");
        input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Entrada inválida! O campo não pode ser nulo ou vazio.");
        }
    }
    while (string.IsNullOrWhiteSpace(input));

    switch (int.Parse(input))
    {
        case 1:
            IAction action = new WarriorAttack();
            player.Actions.Add(action);
            break;
        case 2:
            action = new ArcherAttack();
            player.Actions.Add(action);
            break;
        case 3:
            action = new MageAttack();
            player.Actions.Add(action);
            break;
        default:
            Console.WriteLine("Digite um número de 1 a 3!");
            break;
    }
}

void Fight(Character attacker, Character target)
{
    while (!attacker.IsDead() && !target.IsDead())
    {
        AttackType(attacker);
        Turn(attacker, target);
        if (target.IsDead())
            break;

        AttackType(target);
        Turn(target, attacker);
        if (attacker.IsDead())
            break;
    }
}

List<Character> characters = new List<Character>()
{
    new Character("Guts", 100, 25),
    new Character("Strange", 80, 35),
    new Character("Usopp", 90, 30)
};

Character guts = characters[0];
Character usopp = characters[2];
Fight(guts, usopp);