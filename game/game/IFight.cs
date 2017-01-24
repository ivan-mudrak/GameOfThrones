using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    interface IFight
    {
        int Attack(Kingdom otherKingdom);
        int Defend(Kingdom otherKingdom);
    }
}
