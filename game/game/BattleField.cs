using System;
using System.Collections;
using System.Collections.Generic;
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

        private readonly HashSet<Kingdom> _kingdomHashSet;       
        private uint[,] fieldMap;

        private BattleField(uint hSize, uint vSize)
        {
            HSize = hSize;
            VSize = vSize;
           
            fieldMap = new uint[HSize, VSize];

            rnd = new Random(Guid.NewGuid().GetHashCode());
            _kingdomHashSet = new HashSet<Kingdom>
            {
                new Kingdom("Targaryens", Color.Black),
                new Kingdom("Bartheons", Color.Yellow),
                new Kingdom("Starks", Color.DarkGray),
                new Kingdom("Lannisters", Color.Red)
            };

            Point point = new Point();
            uint evenSquare = (uint) Math.Floor((HSize * VSize) / (double) _kingdomHashSet.Count);
            for (int i = 0; i < _kingdomHashSet.Count; i++)
            {
                for (int j = 0; j < evenSquare; j++)
                {
                    do
                    {
                        point.X = (int)Math.Abs(rnd.Next() % HSize);
                        point.Y = (int)Math.Abs(rnd.Next() % VSize);
                    } while (fieldMap[point.X, point.Y] != 0);
                    fieldMap[point.X, point.Y] = (uint)i;
                }                
            }
        }

        public static BattleField Instance(uint hSize = 100, uint vSize = 100)
        {
            return _instance ?? (_instance = new BattleField(hSize, vSize));
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
                    brush.Color = _kingdomHashSet.ElementAt((int)fieldMap[i, j]).Color;
                    graphics.FillRectangle(brush, rectangle);
                }
            }

        }
    }
}
