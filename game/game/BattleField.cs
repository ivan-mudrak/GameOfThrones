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
        private static Bitmap _bitmap;
        private static Graphics _graphics;
        private const int Scale = 40;
        private Random rnd;

        public int HSize { get; private set; }
        public int VSize { get; private set; }

        private readonly Collection<Kingdom> _kingdomCollection;
        private int[,] fieldMap;

        public BattleField(int hSize, int vSize, Dictionary<string, Color> kingdomsNameColorDictionary)
        {
            HSize = hSize / Scale;
            VSize = vSize / Scale;
            fieldMap = new int[HSize, VSize];
            rnd = new Random(Guid.NewGuid().GetHashCode());

            _kingdomCollection = new Collection<Kingdom>();
            for (int i = 0; i < kingdomsNameColorDictionary.Count; i++)
            {
                _kingdomCollection.Add(new Kingdom(kingdomsNameColorDictionary.ElementAt(i).Key,
                                                   kingdomsNameColorDictionary.ElementAt(i).Value));
            }

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
                        kingdomIndex = (j < VSize / 2) ? 2 : 3;
                    }
                    fieldMap[i, j] = kingdomIndex;
                    _kingdomCollection.ElementAt(kingdomIndex).AttachPoint(new Point(i, j));
                }
            }
        }

        public Kingdom OwnerOf(Point point)
        {
            return _kingdomCollection.ElementAt((int)fieldMap[point.X, point.Y]);
        }

        public void Battle()
        {
            Stack<int> kingdomIndiciesToRemove = new Stack<int>();
            foreach (Kingdom kingdom in _kingdomCollection)
            {
                int defedingKingdomIndex;
                do
                {
                    defedingKingdomIndex = rnd.Next(_kingdomCollection.Count);
                } while (_kingdomCollection.ElementAt(defedingKingdomIndex).IsEmpty());

                Point conflictPoint = _kingdomCollection.ElementAt(defedingKingdomIndex).GetRandomPoint();
                if (0 < kingdom.Attack(_kingdomCollection.ElementAt(defedingKingdomIndex)))
                {
                    ChangePointOwner(conflictPoint, _kingdomCollection.ElementAt(defedingKingdomIndex), kingdom);
                    if (_kingdomCollection.ElementAt(defedingKingdomIndex).IsEmpty()) { kingdomIndiciesToRemove.Push(defedingKingdomIndex); }
                }
            }

            while (kingdomIndiciesToRemove.Count > 0)
            {
                DestroyKingdom(_kingdomCollection.ElementAt(kingdomIndiciesToRemove.Pop()));
            }
        }

        private void ChangePointOwner(Point point, Kingdom fromKingdom, Kingdom toKingdom)
        {
            toKingdom.AttachPointFrom(point, fromKingdom);
            fieldMap[point.X, point.Y] = _kingdomCollection.IndexOf(toKingdom);

            Rectangle rectangle = new Rectangle
            {
                Width = Scale,
                Height = Scale,
                X = point.X * Scale,
                Y = point.Y * Scale
            };
            SolidBrush brush = new SolidBrush(_kingdomCollection.ElementAt(_kingdomCollection.IndexOf(toKingdom)).Color);
            _graphics.FillRectangle(brush, rectangle);
        }

        private void DestroyKingdom(Kingdom kingdomToDestroy)
        {
            _kingdomCollection.Remove(kingdomToDestroy);
        }

        public int GetKingdomScore(string kingdomName)
        {
            int score = 0;
            var linqKingdom = from kingdom in _kingdomCollection
                              where (kingdom.Name.Equals(kingdomName))
                              select kingdom;
            if (linqKingdom.Any())
            {
                score = linqKingdom.First().Points.Count;
            }

            return score;
        }

        public void DrawOnGraphics(Graphics graphicsOut)
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
