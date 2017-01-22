using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public Kingdom ownerKingdom
        {
            get { return _ownerKingdom; }
            set { _ownerKingdom = value; }
        }
        private Kingdom _ownerKingdom;
    }
}
