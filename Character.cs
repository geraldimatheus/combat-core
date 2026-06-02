using CombatCore.Actions;
using CombatCore.Effects;
using CombatCore.Skills;
using CombatCore.Skills.ArrowSkills;
using static System.Net.Mime.MediaTypeNames;


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

        private string _class;
        public string _Class
        {
            get { return _class; }
            set
            {
                _class = string.IsNullOrWhiteSpace(value) ? "Sem classe" : value;
            }
        }

        private string icon;
        public string Icon
        {
            get { return icon; }
            set
            {
                icon = string.IsNullOrWhiteSpace(value) ? "❓" : value;
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

        public Character(string name, string _class, string icon, int maxHP, int attack)
        {
            this.name = name;
            Name = name;
            this._class = _class;
            _Class = _class;
            this.icon = icon;
            Icon = icon;
            maxHP = maxHP < 0 ? 1 : maxHP;
            this.maxHP = maxHP;
            hp = maxHP;
            this.attack = attack;


            effects = new List<IEffect>();
            skills = new List<ISkill>();

        }

        private static Random rand = new Random();

        public int CalculateDamage(IAction? action, ISkill? skill)
        {
            int damage = attack;
            if (skill != null)
            {
                if (skill.Name.Contains("🔥"))
                    return damage += 7;
                if (skill.Name.Contains("⚡") || skill.Name.Contains("🌀"))
                    return damage;
                if (skill.Name.Contains("☠️"))
                    return damage += rand.Next(0, 11);
                else
                    return 0;
            }

            if (action != null)
            {
                if (this._Class.Contains("Mago"))
                    return damage += rand.Next(0, 11);
                if (this._Class.Contains("Guerreiro"))
                    return damage += 5;
                if (this._Class.Contains("Arqueiro"))
                    return damage += 3;
                else
                    return 0;
            }

            return 0;
        }

        public int CalculateEffectDamage(Character target, ISkill skill)
        {
            if (skill != null)
            {
                if (skill.Name.Contains("🔥"))
                    return (2 * (target.MaxHP * 5) / 100);
                if (skill.Name.Contains("☠️"))
                    return (3 * (target.MaxHP * 4) / 100);
                else
                    return 0;
            }

            return 0;
        }

        public (IAction? action, ISkill? skill) CharDecision(Character target)
        {
            static bool IsTargetWeak(Character target)
            {
                if (target.hp <= (target.MaxHP / 2 - 10))
                    return true;
                return false;
            }

            bool IsPlayerWeak()
            {
                if (hp <= (MaxHP / 2 - 10))
                    return true;
                return false;
            }

            ISkill? StrongestSkill()
            {
                ISkill? _strongestSkill = null;
                int skilldamage = 0;

                foreach (ISkill s in Skills)
                {
                    int _currentDamage = this.CalculateDamage(null, s);
                    if (_currentDamage > skilldamage)
                    {
                        skilldamage = _currentDamage;
                        _strongestSkill = s;
                    }
                }

                return _strongestSkill;
            }

            ISkill? GetMostEffectiveSkill()
            {
                ISkill? _mostEffectiveSkill = null;
                int effectDamage = 0;

                foreach (ISkill s in Skills)
                {
                    int _currentDamage = CalculateEffectDamage(target, s);
                    if (_currentDamage > effectDamage)
                    {
                        effectDamage = _currentDamage;
                        _mostEffectiveSkill = s;
                    }
                }
                return _mostEffectiveSkill;
            }

            /*
            Características por classe:
            - Guerreiro: Agressivo (Alvo fraco - finaliza)
            - Arqueiro: Foca em stun (caso o alvo não tenha efeitos/esteja com pouca vida)
            - Mago: Foca em skills (com pouca vida, se cura ao invés de atacar)
            */

            IAction? action = null;
            ISkill? skill = null;
            if (IsPlayerWeak())
            {
                if (this._Class == "Guerreiro" && IsTargetWeak(target))
                    return (basicAttack, skill);
                else if (this._Class == "Guerreiro")
                    return (action, new HealSkill());

                if (this._Class == "Arqueiro")
                {
                    bool stunskill = rand.Next(0, 100) > 40;
                    if (stunskill)
                        return (action, new StunArrow());
                    else
                        return (action, new HealSkill());
                }

                return (action, new HealSkill());
            }

            if (IsTargetWeak(target))
            {
                if (this._Class == "Guerreiro")
                {
                    bool useSkill = rand.Next(0, 100) > 60;
                    if (useSkill)
                        return (action, StrongestSkill());
                    else
                        return (basicAttack, skill);
                }

                if (target.Effects.Count != 0)
                    return (basicAttack, skill);
                else
                    return (action, StrongestSkill());
            }
            else
            {
                if (target.Effects.Count != 0)
                    return (basicAttack, skill);
                else
                {
                    if (this._Class == "Arqueiro")
                    {
                        bool stunskill = rand.Next(0, 100) > 60;
                        if (stunskill)
                            return (action, new StunArrow());
                        else
                            return (action, GetMostEffectiveSkill());
                    }

                    return (action, GetMostEffectiveSkill());
                }
            }
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
            Console.WriteLine("==============================");
            Console.WriteLine($"{Icon} {Name} - HP: {HP}/{MaxHP}");
            Console.WriteLine("==============================");
        }
        public bool IsDead()
        {
            return HP <= 0;
        }
    };
}
