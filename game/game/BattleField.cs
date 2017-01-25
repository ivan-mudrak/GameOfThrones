using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace game
{
    class BattleField : IDrawable
    {
        private static BattleField _instance;
        private Random rnd;

        public uint HSize { get; private set; }
        public uint VSize { get; private set; }
        public uint NumberOfKingdoms { get; private set; }

        private readonly Collection<Kingdom> _kingdomCollection;
        private uint[,] fieldMap;

        private BattleField(uint hSize, uint vSize)
        {
            HSize = hSize;
            VSize = vSize;
            fieldMap = new uint[HSize, VSize];
            rnd = new Random(Guid.NewGuid().GetHashCode());

            _kingdomCollection = new Collection<Kingdom>
            {
                new Kingdom("Targaryens", Color.Black),
                new Kingdom("Bartheons", Color.Yellow),
                new Kingdom("Starks", Color.DarkGray),
                new Kingdom("Lannisters", Color.Red)
            };

            for (int i = 0; i < HSize; i++)
            {
                for (int j = 0; j < VSize; j++)
                {
                    var kingdomIndex = 0;
                    if (i < HSize / 2)
                    {
                        kingdomIndex = (j < VSize / 2) ? 0 : 1;
                    }
                    else
                    {
                        kingdomIndex = (j < vSize / 2) ? 2 : 3;
                    }
                    fieldMap[i, j] = (uint)kingdomIndex;
                    _kingdomCollection.ElementAt((int)kingdomIndex).DistributePoint(new Point(i, j));
                }
            }
        }

        public static BattleField Instance(uint hSize = 100, uint vSize = 100)
        {
            return _instance ?? (_instance = new BattleField(hSize, vSize));
        }


        public Point PointAt(int x, int y)
        {
            return new Point(x, y);
        }

        public Kingdom OwnerOf(Point point)
        {
            return _kingdomCollection.ElementAt((int)fieldMap[point.X, point.Y]);
        }

        public void Battle()
        {
            foreach (Kingdom kingdom in _kingdomCollection)
            {
                int defedingKingdomIndex = rnd.Next(_kingdomCollection.Count);
                Point conflictpoint = _kingdomCollection.ElementAt(defedingKingdomIndex).GetRandomPoint();

                if (0 < kingdom.Attack(_kingdomCollection.ElementAt(defedingKingdomIndex)))
                {
                    kingdom.AttachPointFrom(conflictpoint, _kingdomCollection.ElementAt(defedingKingdomIndex));
                    fieldMap[conflictpoint.X, conflictpoint.Y] = (uint)_kingdomCollection.IndexOf(kingdom);
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            int step = 4;
            Rectangle rectangle = new Rectangle();
            SolidBrush brush = new SolidBrush(Color.White);
            for (int i = 0; i < HSize; i++)
            {
                for (int j = 0; j < VSize; j++)
                {
                    rectangle.X = i * step;
                    rectangle.Y = j * step;
                    rectangle.Width = step;
                    rectangle.Height = step;
                    brush.Color = _kingdomCollection.ElementAt((int)fieldMap[i, j]).Color;
                    graphics.FillRectangle(brush, rectangle);
                }
            }


        }
    }
}
