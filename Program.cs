using CombatCore;
using CombatCore.Effects;
using CombatCore.Actions;
using CombatCore.Skills;
using CombatCore.Classes;
using CombatCore.Logs;

void ApplyEffects(Character player)
{
    List<IEffect> effects = player.Effects;
    for (int i = effects.Count - 1; i >= 0; i--)
    {
        IEffect effect = effects[i];
        var value = effects[i].EffectAction(player);
        CombatLog.EffectsLog(player, effect, value.damage, value.heal, value.turns);
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
        CombatLog.SkillLog(attacker, target, skill, value.damage, value.miss, value.crit);
    }
    else if (action != null)
    {
        var value = action.Action(attacker, target);
        target.ReceiveDamage(value.damage);
        CombatLog.ActionLog(attacker, target, action, value.damage, value.miss, value.crit);
    }
    else
        Console.WriteLine("⚠️ Erro ao executar ações");
}



void Shift(Character attacker, Character target, ISkill? skill, IAction? action)
{
    Thread.Sleep(1000);
    CombatLog.StartShiftLog(attacker);

    ApplyEffects(target);

    CombatLog.IsDeadLog(target);
    Thread.Sleep(1000);

    CombatLog.IsDeadLog(target);
    Thread.Sleep(1000);

    ExecuteChoices(attacker, target, skill, action);

    Thread.Sleep(1000);
    CombatLog.IsDeadLog(target)
        ;
    attacker.ShowStatus();
    target.ShowStatus();
}

void Fight(Character attacker, Character target)
{
    CombatLog.StartCombatLog(attacker, target);
    while (!attacker.IsDead() && !target.IsDead())
    {
        if (CombatLog.IsDeadLog(target))
            break;
        var result = attacker.CharDecision(target);
        Shift(attacker, target, result.skill, result.action);
        if (CombatLog.IsDeadLog(target))
            break;

        if (CombatLog.IsDeadLog(attacker))
            break;
        result = target.CharDecision(attacker);
        Shift(target, attacker, result.skill, result.action);
        if (CombatLog.IsDeadLog(attacker))
            break;
    }
}

List<Character> characters = new List<Character>()
{
    new WarriorClass("Guts"),
    new MageClass("Strange"),
    new ArcherClass("Usopp"),
    new WarriorClass("Zoro"),
    new MageClass("Natsu"),
    new ArcherClass("Yasopp")
};

Character guts = characters[0];
Character strange = characters[1];
Character usopp = characters[2];
Character zoro = characters[3];
Character natsu = characters[4];
Character yasopp = characters[5];

Fight(strange, natsu);
Fight(strange, natsu);
Fight(strange, natsu);