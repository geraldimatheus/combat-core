using CombatCore.Actions;
using CombatCore.Actions.ArcherActions;
using CombatCore.Actions.MageActions;
using CombatCore.Actions.WarriorActions;
using CombatCore.Classes;
using CombatCore.Effects;
using CombatCore.Skills;
using CombatCore.Skills.ArrowSkills;
using CombatCore.Skills.MagicSkills;
using CombatCore.Skills.SwordSkills;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace CombatCore
{
    abstract class Character
    {
        private string name;
        public string Name
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

        public IAction? basicAttack;

        private List<ISkill> skills = new List<ISkill>();
        public List<ISkill> Skills
        {
            get { return skills; }
        }

        public Character(string name, int maxHP, int attack)
        {
            this.name = name;
            Name = name;
            maxHP = maxHP < 0 ? 1 : maxHP;
            this.maxHP = maxHP;
            hp = maxHP;
            this.attack = attack;


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

            HP += heal;

            if (HP > maxHP)
                HP = maxHP;
        }
    
        public void ShowStatus()
        {
            if (basicAttack is WarriorAttackAction)
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"⚔️ {Name} - HP: {HP}/{MaxHP}");
                Console.WriteLine("==============================");
            }
            else if (basicAttack is ArcherAttackAction)
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"🏹 {Name} - HP: {HP}/{MaxHP}");
                Console.WriteLine("==============================");
            }
            else
            {
                Console.WriteLine("==============================");
                Console.WriteLine($"🧙 {Name} - HP: {HP}/{MaxHP}");
                Console.WriteLine("==============================");
            }
        }
        public bool IsDead()
        {
            return HP <= 0;
        }
    };
}
