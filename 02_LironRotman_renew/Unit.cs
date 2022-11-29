using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    abstract class Unit
    {
        public virtual Dice Damage { get; set; }
        public virtual float HP { get; set; }
        public virtual Race RaceSet { get; set; }
        public virtual Weather WeatherSet { get; set; }

        public virtual Dice HitChance { get; set; }
        public virtual Dice DeffChance { get; set; }
        public int capacity;

        public virtual void Attack(Unit defender)
        {
            defender.TakeDmg(this.Damage.Roll());
        }
        public virtual void Defender(Unit attack)
        {
            attack.TakeDmg(this.Damage.Roll());
        }
        public virtual void TakeDmg(float dmg)
        {
            HP -= dmg;
        }
    }
    public enum Race { lizardPeople, humans, asians }
    public enum Weather { Snow, cloudy, clear }

    struct Dice
    {
        public uint scalar;
        public uint baseDice;
        public int modifier;

        public Dice(uint scalar, uint baseDice, int modifier)
        {
            this.scalar = scalar;
            this.baseDice = baseDice;
            this.modifier = modifier;
        }
        public int Roll()
        {
            var result = 0;
            for (int i = 0; i < scalar; i++)
            {
                result += Random.Shared.Next(1, (int)baseDice + 1);
                result += modifier;
            }
            return result;
        }

        public override string ToString()
        {
            return $"S:{scalar},D:{baseDice},M:{modifier}";
        }

        public override bool Equals(object obj)
        {
            var b = (Dice)obj;
            return this.scalar == b.scalar
                    && this.baseDice == b.baseDice
                    && this.modifier == b.modifier;
        }
    }

