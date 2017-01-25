using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    enum FieldNeighbor
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

    class Field
    {
        private readonly Point _point;

        public Field(int x, int y, Kingdom kingdom)
        {
            _point = new Point(x, y);
            OwnerKingdom = kingdom;
        }

        public Field(Point point, Kingdom kingdom)
        {
            _point = point;
            OwnerKingdom = kingdom;
        }

        public static explicit operator Point(Field field)
        {
            return field._point;
        }

        public Kingdom OwnerKingdom { get; set; }

        private static readonly Field _Empty = new Field(Point.Empty, Kingdom.Empty);
        public static Field Empty { get { return _Empty; }}        
    }
}
