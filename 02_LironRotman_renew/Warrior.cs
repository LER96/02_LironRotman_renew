using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    sealed class Warrior : MeleeUnit
    {
        public Warrior(Race race, Weather weather)
        {
            this.Damage = new Dice((uint)1, (uint)8, 3);
            this.HitChance = new Dice((uint)1, (uint)3, 2);
            this.DeffChance = new Dice((uint)1, (uint)6, 2);
            this.capacity = 10;
            this.HP = 20;
            this.Bleed = 1.2f;

            this.WeatherSet = weather;
            this.RaceSet = race;
        }
    }

