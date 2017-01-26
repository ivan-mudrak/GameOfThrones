using System.Drawing;

namespace game
{
    abstract class Land 
    {
        public virtual Point GetRandomPoint()
        {
            return Point.Empty;
        }

        public virtual void AttachPoint(Point point)
        {
            
        }

        public virtual void AttachPointFrom(Point point, Land fromLand)
        {

        }

        public virtual void RemovePoint(Point point)
        {
            
        }
    }
}
