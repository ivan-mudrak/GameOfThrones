using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    interface IFight
    {
        void Attack(Kingdom otherKingdom);
        void Defend(Kingdom otherKingdom);
    }
}
