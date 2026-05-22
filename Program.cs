using CombatCore;
using CombatCore.Effects;
using CombatCore.Actions;
using CombatCore.Skills;
using CombatCore.Classes;
using CombatCore.Logs;

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
        BattleLog.SkillLog(attacker, target, skill, value.damage, value.miss, value.crit);
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
        Console.WriteLine($"☠️ {target.Name} morreu!");
        return;
    }

    ExecuteChoices(attacker, target, skill, action);
    Thread.Sleep(1000);
    if (target.IsDead())
    {
        Console.WriteLine($"☠️ {target.Name} morreu!");
        return;
    }

    attacker.ShowStatus();
    target.ShowStatus();
}

void Fight(Character attacker, Character target)
{
    BattleLog.StartBattleLog(attacker, target);
    while (!attacker.IsDead() && !target.IsDead())
    {
        var result = BattleLog.AttackTypeLog(attacker);
        Turn(attacker, target, result.skill, result.action);
        if (target.IsDead())
            break;

        result = BattleLog.AttackTypeLog(attacker);
        Turn(target, attacker, result.skill, result.action);
        if (attacker.IsDead())
            break;
    }
}

List<Character> characters = new List<Character>()
{
    new WarriorClass("Guts"),
    new MageClass("Strange"),
    new ArcherClass("Usopp")
};

Character guts = characters[0];
Character usopp = characters[2];
Fight(guts, usopp);