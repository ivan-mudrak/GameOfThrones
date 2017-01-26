using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace game
{
    class Kingdom : Land, IFight
    {
        public Collection<Point> Points
        {
            get;
            private set;
        }

        private readonly Random _rnd;
        private int _bonus = 0;
        public readonly Color Color;
        public readonly String Name;

        private static readonly Kingdom _Empty = new Kingdom(String.Empty, Color.Empty);
        public static Kingdom Empty { get { return _Empty; } }
        public bool IsEmpty() { return Points.Count == 0; }

        public Kingdom(String name, Color color)
        {
            Name = name;
            Color = color;
            _rnd = new Random(Guid.NewGuid().GetHashCode());
            Points = new Collection<Point>();
        }

        public override void AttachPoint(Point point)
        {
            Points.Add(point);
        }
  
        public override void AttachPointFrom(Point point, Land fromKingdom)
        {
            Points.Add(point);
            fromKingdom.RemovePoint(point);
        }

        public override void RemovePoint(Point point)
        {
            Points.Remove(point);
        }   

        public override Point GetRandomPoint()
        {
            return Points[_rnd.Next(Points.Count)];
        }

        // IFight
        public BattleResult Attack(Kingdom otherKingdom)
        {
            BattleResult result;
            if (this.Name.Equals(otherKingdom.Name))
            {
                _bonus++;
                result = BattleResult.Draw;
            }
            else
            {
                int ourPower = _rnd.Next(100);
                int otherKingdomPower = otherKingdom.Defend(this);

                if (ourPower > otherKingdomPower)
                {
                    result = BattleResult.Win;
                }
                else if (ourPower < otherKingdomPower)
                {
                    result = BattleResult.Lose;
                    _bonus--;
                }
                else
                {
                    result = BattleResult.Draw;
                }
            }

            return result;
        }

        public int Defend(Kingdom otherKingdom)
        {
            int power = _bonus + _rnd.Next(100);
            _bonus = 0;
            return power;
        }
    }
}
