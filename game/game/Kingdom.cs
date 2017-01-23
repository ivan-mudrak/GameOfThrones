using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{    
    class Kingdom : Land, IFight
    {
        private readonly Random rnd;

        public Kingdom(Point point, uint square)
        {
            rnd = new Random(Guid.NewGuid().GetHashCode());
            uint currentSquare = 0;

            do
            {
                
            } while ( currentSquare < square);
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
