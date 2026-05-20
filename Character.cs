using System;
using System.Collections.Generic;
using System.Text;
using CombatCore.Effects;
using CombatCore.Skills;
using CombatCore.Skills.ArrowSkills;
using CombatCore.Skills.MagicSkills;
using CombatCore.Skills.SwordSkills;
using CombatCore.Actions;
using CombatCore.Actions.WarriorActions;
using CombatCore.Actions.MageActions;
using CombatCore.Actions.ArcherActions;


namespace CombatCore
{
    abstract class Character
    {
        private string? name;
        public string? Name
        {
            get { return name; }
            set {
                name = string.IsNullOrWhiteSpace(value) ? "Sem nome" : value;
            }
        }

        private int hp;
        private int maxHP;
        public int HP
        {
            get { return hp; }
            set { hp = value < 0 ? 0 : value; }
        }
        public int MaxHP
        {
            get { return maxHP; }
        }

        private int attack;
        public int Attack
        {
            get { return attack; }
            set {
                attack = value < 0 ? 0 : value;
            }
        }

        private List<IEffect> effects;
        public List<IEffect> Effects
        {
            get { return effects; }
        }

        private List<IAction> actions;
        public List<IAction> Actions
        {
            get { return actions; }
        }

        private List<ISkill> skills = new List<ISkill>();
        public List<ISkill> Skills
        {
            get { return skills; }
        }

        public Character(string name, int maxHP, int attack)
        {
            Name = name;
            maxHP = maxHP < 0 ? 1 : maxHP;
            hp = maxHP;
            this.attack = attack;

            actions = new List<IAction>();
            effects = new List<IEffect>();
            skills = new List<ISkill>();

        }
        public void ReceiveDamage(int damage)
        {
            if (damage < 0)
                damage = 0;

            hp -= damage;

            if (hp < 0)
                hp = 0;
        }
        public void ReceiveHeal(int heal)
        {
            if (heal < 0)
                heal = 0;

            hp += heal;

            if (hp > maxHP)
                hp = maxHP;
        }
    
        public void ShowStatus()
        {
            Console.WriteLine($"Personagem: {Name} - HP:{HP}");
        }
        public bool IsDead()
        {
            return HP <= 0;
        }
    };
}
