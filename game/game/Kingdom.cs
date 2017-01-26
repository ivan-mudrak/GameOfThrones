﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace game
{
    enum PointNeighbor
    {
        Top,
        TopRight,
        Right,
        BottomRight,
        Bottom,
        BottomLeft,
        Left,
        TopLeft
    }

    class Kingdom : Land, IFight
    {
        public Collection<Point> Points
        {
            get;
            private set;
        }

        private readonly Random rnd;
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
            rnd = new Random(Guid.NewGuid().GetHashCode());
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

   /*     public static Point GetNeigborPoint(Point sourcePoint, PointNeighbor whichNeighbor)
        {
            Point neighborPoint = Point.Empty;
            switch (whichNeighbor)
            {
                case PointNeighbor.Top:
                    neighborPoint = (sourcePoint.Y > 0) ? new Point(sourcePoint.X, sourcePoint.Y - 1) : Point.Empty;
                    break;
                case PointNeighbor.TopRight:
                    neighborPoint = ((sourcePoint.X < BattleField.Instance().HSize - 1) && (sourcePoint.Y > 0)) ? new Point(sourcePoint.X + 1, sourcePoint.Y - 1) : Point.Empty;
                    break;
                case PointNeighbor.Right:
                    neighborPoint = (sourcePoint.X < BattleField.Instance().HSize - 1) ? new Point(sourcePoint.X + 1, sourcePoint.Y) : Point.Empty;
                    break;
                case PointNeighbor.BottomRight:
                    neighborPoint = ((sourcePoint.X < BattleField.Instance().HSize - 1) && (sourcePoint.Y < BattleField.Instance().VSize - 1)) ? new Point(sourcePoint.X + 1, sourcePoint.Y + 1) : Point.Empty;
                    break;
                case PointNeighbor.Bottom:
                    neighborPoint = (sourcePoint.Y < BattleField.Instance().VSize - 1) ? new Point(sourcePoint.X, sourcePoint.Y + 1) : Point.Empty;
                    break;
                case PointNeighbor.BottomLeft:
                    neighborPoint = ((sourcePoint.X > 0) && (sourcePoint.Y < BattleField.Instance().VSize - 1)) ? new Point(sourcePoint.X - 1, sourcePoint.Y + 1) : Point.Empty;
                    break;
                case PointNeighbor.Left:
                    neighborPoint = (sourcePoint.X > 0) ? new Point(sourcePoint.X - 1, sourcePoint.Y) : Point.Empty;
                    break;
                case PointNeighbor.TopLeft:
                    neighborPoint = ((sourcePoint.X > 0) && (sourcePoint.Y > 0)) ? new Point(sourcePoint.X - 1, sourcePoint.Y - 1) : Point.Empty;
                    break;
            }

            return neighborPoint;
        }
        */

        public Point GetRandomPoint()
        {
            return Points[rnd.Next(Points.Count)];
        }

        // IFight
        public int Attack(Kingdom otherKingdom)
        {
            int result;
            if (this.Name.Equals(otherKingdom.Name))
            {
                _bonus++;
                result = 0;
            }
            else
            {
                int ourPower = rnd.Next(100);
                int otherKingdomPower = otherKingdom.Defend(this);

                if (ourPower > otherKingdomPower)
                {
                    result = 1;
                }
                else if (ourPower < otherKingdomPower)
                {
                    result = -1;
                    _bonus--;
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
            int power = _bonus + rnd.Next(100);
            _bonus = 0;
            return power;
        }
    }
}
