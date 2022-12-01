using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


sealed class Warrior : MeleeUnit
{
    public Warrior(Race race, Weather weather)
    {
        this.Damage = new Bag(10);
        this.HitChance = new Bag(12);
        this.DeffChance = new Bag(15);
        this.capacity = 10;
        this.HP = 20;
        this.Bleed = 1.2f;

        this.WeatherSet = weather;
        this.RaceSet = race;
    }
}

