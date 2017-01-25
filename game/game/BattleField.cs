using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace game
{
    class BattleField : IDrawable
    {
        private static BattleField _instance;
        private static Bitmap _bitmap;
        private static Graphics _graphics;
        private  const  int Scale = 4;
        private Random rnd;

        public int HSize { get; private set; }
        public int VSize { get; private set; }       

        private readonly Collection<Kingdom> _kingdomCollection;
        private uint[,] fieldMap;

        private BattleField(int hSize, int vSize)
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
                    _kingdomCollection.ElementAt(kingdomIndex).DistributePoint(new Point(i, j));
                }
            }
        }

        public static BattleField Instance(int hSize = 400, int vSize = 400)
        {
            if (_instance == null)
            {
                _instance = new BattleField(hSize / Scale, vSize / Scale);
            }
            return _instance;
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
                Point conflictPoint = _kingdomCollection.ElementAt(defedingKingdomIndex).GetRandomPoint();

                if (0 < kingdom.Attack(_kingdomCollection.ElementAt(defedingKingdomIndex)))
                {
                    ChangePointOwner(conflictPoint, _kingdomCollection.ElementAt(defedingKingdomIndex), kingdom);                    
                }
            }
        }

        private void ChangePointOwner(Point point, Kingdom fromKingdom, Kingdom toKingdom)
        {
            toKingdom.AttachPointFrom(point, fromKingdom);
            fieldMap[point.X, point.Y] = (uint)_kingdomCollection.IndexOf(toKingdom);

            Rectangle rectangle = new Rectangle
            {
                Width = Scale,
                Height = Scale,
                X = point.X * Scale,
                Y = point.Y * Scale
            };
            SolidBrush brush = new SolidBrush(_kingdomCollection.ElementAt((int) fieldMap[point.X, point.Y]).Color);
            _graphics.FillRectangle(brush, rectangle);
        }        

        public void Draw(Graphics graphicsOut)
        {
            if (_graphics == null)
            {
                CreateGraphics();
            }        
     
           graphicsOut.DrawImage(_bitmap, 0, 0);
        }

        private void CreateGraphics()
        {
            _bitmap = new Bitmap(HSize * Scale, VSize * Scale);
            _graphics = Graphics.FromImage(_bitmap);
            Rectangle rectangle = new Rectangle
            {
                Width = Scale,
                Height = Scale
            };
            SolidBrush brush = new SolidBrush(Color.Empty);
            for (int i = 0; i < HSize; i++)
            {
                for (int j = 0; j < VSize; j++)
                {
                    rectangle.X = i * Scale;
                    rectangle.Y = j * Scale;
                    brush.Color = _kingdomCollection.ElementAt((int)fieldMap[i, j]).Color;
                    _graphics.FillRectangle(brush, rectangle);
                }
            }
        }
    }
}
