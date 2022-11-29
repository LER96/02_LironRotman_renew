//C# II(Dor Ben Dor)
//Liron Rotman
//28/11/2022

using System;
List<Unit> fightersAsians = new()
            {
                new Archer(Race.asians, Weather.Snow),
                new Warrior(Race.asians, Weather.clear),
            };

List<Unit> fightersHumans = new()
            {
                new Archer(Race.humans, Weather.cloudy),
                new Warrior(Race.humans, Weather.Snow),
            };

ToBattle(fightersHumans, fightersAsians);

void ToBattle(List<Unit> p1, List<Unit> p2)
{
    var amountTaken1 = 0;
    var amountTaken2 = 0;
    //who's starting
    var turn = Random.Shared.Next(1, 3);
    Console.WriteLine($"P{turn} is starting\n");
    while (p1.Count>0 && p2.Count>0)
    {
        //pick random player from both teams
        var place1= Random.Shared.Next(0, p1.Count);
        var place2= Random.Shared.Next(0, p2.Count);

        //P1's turn
        if(turn==1)
        {
            //copy of the players (for more readable code)
            var warrior1 = p1[place1];
            var warrior2 = p2[place2];

            //Roll cube VS Deff cube
            if (warrior1.HitChance.Roll() > warrior2.DeffChance.Roll())
            {
                Console.WriteLine($"Noice! P1:{warrior1} manage to attack P2:{warrior2}");
                warrior1.Attack(warrior2);

                if (warrior2.HP <= 0)
                {
                    amountTaken1 += warrior2.capacity;
                    Console.WriteLine($"P2:{warrior2} is dead");
                    p2.Remove(p2[place2]);
                }
            }
            else
            {
                Console.WriteLine($"P2:{warrior2} Blocked! P1:{warrior1} takes dmg");
                warrior2.Defender(warrior1);
            }
            
            turn = 2;
            continue;
        }
        //P2's turn
        else if (turn == 2)
        {

            var warrior1 = p2[place2];
            var warrior2 = p1[place1];

            if (warrior1.HitChance.Roll() > warrior2.DeffChance.Roll())
            {
                Console.WriteLine($"Noice! P2:{warrior1} manage to attack P1:{warrior2}");
                warrior1.Attack(warrior2);

                if (warrior2.HP <= 0)
                {
                    amountTaken2 += warrior2.capacity;
                    Console.WriteLine($"P1:{warrior2} is dead");
                    p1.Remove(p1[place1]);
                }
            }
            else
            {
                Console.WriteLine($"P1:{warrior2} Blocked! P2:{warrior1} takes dmg");
                warrior2.Defender(warrior1);
            }
            turn = 1;
            continue;
        }
    }
    if (p1.Count > 0)
    {
        Console.WriteLine($"P1 wins! and took {amountTaken1} loots");
    }
    else
        Console.WriteLine($"P2 wins! and took {amountTaken2} loots");

}
