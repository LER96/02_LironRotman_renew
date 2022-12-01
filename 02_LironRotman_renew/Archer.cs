using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


sealed class Archer : RangedUnit
{
    public Archer(Race race, Weather weather)
    {
        this.Damage = new Bag(8);
        this.HitChance = new Bag(20);
        this.DeffChance = new Bag(10);
        this.capacity = 5;
        this.HP = 15;
        this.Range = 1.7f;

        this.WeatherSet = weather;
        this.RaceSet = race;
    }
}

