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
        public readonly Color Color;
        public readonly String Name;

        public Kingdom(String name, Color color)
        {
            Name = name;
            Color = color;
            rnd = new Random(Guid.NewGuid().GetHashCode());
        }

        // IFight
        public void Attack(Kingdom otherKingdom)
        {
            
        }

        public void Defend(Kingdom otherKingdom)
        {
            
        }
    }
}
