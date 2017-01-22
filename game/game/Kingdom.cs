using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Kingdom : Land, IFight
    {
        private readonly Random rnd;

        public Kingdom()
        {
            rnd = new Random(Guid.NewGuid().GetHashCode());
        }

        // IFight
        public void Attack(Kingdom otherKingdom)
        {
            throw new NotImplementedException();
        }

        public void Defend(Kingdom otherKingdom)
        {
            throw new NotImplementedException();
        }
    }
}
