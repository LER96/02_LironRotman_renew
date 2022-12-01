using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    abstract class MeleeUnit : Unit
    {
        public virtual float Bleed { get; set; }
        public override void Attack(Unit defender)
        {
            defender.TakeDmg(base.Damage.GiveRandom() * Bleed);
        }
        public override void Defender(Unit attack)
        {
            attack.TakeDmg(base.Damage.GiveRandom() / 4);
        }
    }

