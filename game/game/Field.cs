using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Field
    {
        readonly Point point;

        public Field(Point point)
        {
            this.point = point;
        }

        public static explicit operator Point(Field field)
        {
            return field.point;
        }

        public Kingdom ownerKingdom
        {
            get { return _ownerKingdom; }
            set { _ownerKingdom = value; }
        }
        private Kingdom _ownerKingdom;

        public bool IsOccupied()
        {
            return _ownerKingdom != null;
        }
    }
}
