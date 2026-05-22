using CombatCore;
using CombatCore.Effects;
using CombatCore.Actions;
using CombatCore.Skills;
using CombatCore.Classes;
using CombatCore.Logs;

void ApplyEffects(Character attacker, Character target)
{
    List<IEffect> effects = target.Effects;
    for (int i = effects.Count - 1; i >= 0; i--)
    {
        IEffect effect = effects[i];
        if (effect is HealEffect)
        {
            var value = effects[i].EffectAction(target);
            target.ReceiveHeal(value.heal);
            CombatLog.EffectsLog(target, effect, value.damage, value.heal, value.turns);
            if (value.turns == 0)
                effects.Remove(effects[i]);
        }
        else
        {
            var value = effects[i].EffectAction(attacker);
            CombatLog.EffectsLog(attacker, effect, value.damage, value.heal, value.turns);
            if (value.turns == 0)
                effects.Remove(effects[i]);
        }
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
    CombatLog.StartShiftLog(attacker);
    ApplyEffects(attacker, target);
    Thread.Sleep(1000);

    CombatLog.IsDeadLog(target);
    ExecuteChoices(attacker, target, skill, action);
    Thread.Sleep(1000);

    CombatLog.IsDeadLog(target);
    attacker.ShowStatus();
    target.ShowStatus();
}

void Fight(Character attacker, Character target)
{
    CombatLog.StartCombatLog(attacker, target);
    while (!attacker.IsDead() && !target.IsDead())
    {
        var result = CombatLog.AttackTypeLog(attacker);
        Shift(attacker, target, result.skill, result.action);
        if (target.IsDead())
            break;

        result = CombatLog.AttackTypeLog(target);
        Shift(target, attacker, result.skill, result.action);
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