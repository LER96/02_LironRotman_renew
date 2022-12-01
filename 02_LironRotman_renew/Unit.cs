using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Unit
{
    public virtual IRandomProvider Damage { get; set; }
    public virtual float HP { get; set; }
    public virtual Race RaceSet { get; set; }
    public virtual Weather WeatherSet { get; set; }

    public virtual IRandomProvider HitChance { get; set; }
    public virtual IRandomProvider DeffChance { get; set; }
    public int capacity;

    public virtual void Attack(Unit defender)
    {
        defender.TakeDmg(this.Damage.GiveRandom());
    }
    public virtual void Defender(Unit attack)
    {
        attack.TakeDmg(this.Damage.GiveRandom());
    }
    public virtual void TakeDmg(float dmg)
    {
        HP -= dmg;
    }
}
public enum Race { lizardPeople, humans, asians }
public enum Weather { Snow, cloudy, clear }

struct Dice : IRandomProvider
{
    public uint scalar;
    public uint baseDice;
    public int modifier;

    public int GiveRandom() { return Roll();}
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
struct Bag: IRandomProvider
{
    List<int> bag = new();
    List<int> bagCopy = new();
    int num=0;
    public Bag(int num)
    {
        for(int i = 0; i < num; i++)
        {
            bag.Add(i);
        }
    }
    public int GiveRandom()
    {
        if (bag.Count > 1)
        {
            var num1 = Random.Shared.Next(0, bag.Count);
            num = bag[num1];
            bagCopy.Add(bag[num1]);
            bag.Remove(bag[num1]);
        }
        else if (bagCopy.Count ==1)
        {
            num = bag[0];
            bagCopy.Add(bag[0]);
            bag.Remove(bag[0]);

            bag = bagCopy;
            bagCopy.Clear();
        }

        return num;
    }
}
public interface IRandomProvider
{
    public int GiveRandom();
}


