using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    abstract class RangedUnit : Unit
    {

        public virtual float Range { get; set; }
        public override void Attack(Unit defender)
        {
            defender.TakeDmg(base.Damage.Roll() * Range);
        }
        public override void Defender(Unit attack)
        {
            attack.TakeDmg(base.Damage.Roll() / 4);
        }

    }

