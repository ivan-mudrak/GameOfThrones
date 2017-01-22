using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class BattleField : IDrawable
    {
        readonly uint numberOfKingdoms, vSize, hSize;
        private Array arrayOfKingdoms;

        public BattleField(uint hSize, uint vSize, uint numberOfKingdoms)
        {
            this.hSize = hSize;
            this.vSize = vSize;
            this.numberOfKingdoms = numberOfKingdoms;

        }

        public void Start()
        {

        }

        public void Stop()
        {

        }

        public void Pause()
        {

        }

        public void Resume()
        {

        }

        public void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }
    }
}
