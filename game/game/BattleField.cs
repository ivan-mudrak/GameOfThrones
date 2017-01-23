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

        private HashSet<Kingdom> kingdomHashSet;
        private Dictionary<int, Color> kingdomColor;
        private uint[,] fieldMap;

        private BattleField(uint hSize, uint vSize, uint numberOfKingdoms)
        {
            HSize = hSize;
            VSize = vSize;
            NumberOfKingdoms = numberOfKingdoms;
            fieldMap = new uint[HSize, VSize];

            rnd = new Random(Guid.NewGuid().GetHashCode());
            kingdomHashSet = new HashSet<Kingdom>();
            kingdomColor = new Dictionary<int, Color>();

            uint evenSquare = (uint)Math.Floor((double)(HSize * VSize) / (double)numberOfKingdoms);
            Point point = new Point();
            for (int i = 0; i < numberOfKingdoms; i++)
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
                kingdomColor.Add(i, Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));

            }
        }

        public static BattleField Instance(uint hSize, uint vSize, uint numberOfKingdoms = 4)
        {
            return _instance ?? (_instance = new BattleField(hSize, vSize, numberOfKingdoms));
        }

        public static BattleField Instance()
        {
            if (_instance == null)
            {
                throw new NotImplementedException("BattleField.Instance(uint hSize, uint vSize, uint numberOfKingdoms) must be called first");
            }
            return _instance;
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
                    brush.Color = kingdomColor[(int)fieldMap[i, j]];
                    graphics.FillRectangle(brush, rectangle);
                }
            }

        }
    }
}
