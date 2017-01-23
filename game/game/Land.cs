using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    abstract class Land 
    {         
        public virtual bool Contains(Point point)
        {
            return false;
        }

        public virtual void Append(Point point)
        {
            
        }

        public virtual void Remove(Point point)
        {
            
        }
    }
}
