using CombatCore.Effects;

namespace CombatCore.Skills.SwordSkills
{
    class StunSword : ISkill
    {
        public string Name { get { return "⚡ Espada atordoante"; } }

        private static Random rand = new Random();
        public (int damage, bool miss, bool crit) Skill(Character attacker, Character target)
        {
            int attack = attacker.Attack;
            List<IEffect> effects = target.Effects;
            bool miss = rand.Next(0, 100) < 20;

            if (miss)
                return (0, true, false);

            IEffect effect = new StunEffect();
            effects.Add(effect);
            int damage = attack + 5;

            return (damage, false, false);
        }

    }
}
