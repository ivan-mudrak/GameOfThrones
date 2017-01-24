using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace game
{
    class Kingdom : Land, IFight
    {
        public Point[] Points
        {
            get; 
            private set; 
        }
        private readonly Random rnd;
        private int bonus = 0;
        public readonly Color Color;
        public readonly String Name;

        public Kingdom(String name, Color color)
        {
            Name = name;
            Color = color;           
            rnd = new Random(Guid.NewGuid().GetHashCode());
        }

        public void BuildPoints()
        {
            
        }


        public Point GetRandomPoint()
        {
            return Points[rnd.Next(Points.Length)];
        }

        // IFight
        public int Attack(Kingdom otherKingdom)
        {
            int result;
            if (this.Name.Equals(otherKingdom.Name))
            {
                bonus++;
                result = 0;
            }
            else
            {
                int ourPower = rnd.Next(100);
                int otherKingdomPower = otherKingdom.Defend(this);

                if (ourPower > otherKingdomPower)
                {
                    result =                   1;
                }
                else if (ourPower < otherKingdomPower)
                {
                    result = -1;
                }
                else
                {
                    result = 0;
                }
            }

            return result;
        }

        public int Defend(Kingdom otherKingdom)
        {
            int power = bonus + rnd.Next(100);
            bonus = 0;
            return power;
        }
    }
}
