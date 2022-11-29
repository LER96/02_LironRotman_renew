using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    sealed class Archer : RangedUnit
    {
        public Archer(Race race, Weather weather)
        {
            this.Damage = new Dice(1, 6, 2);
            this.HitChance = new Dice(1, 8, 1);
            this.DeffChance = new Dice(1, 4, 0);
            this.capacity = 5;
            this.HP = 15;
            this.Range = 1.7f;

            this.WeatherSet = weather;
            this.RaceSet = race;
        }
    }

