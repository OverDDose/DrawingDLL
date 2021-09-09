using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    abstract class Figure
    {
        private float x, y;
        private float w, h;
        public int ActivePoint = -1;

        public float X { get { return x; } }
        public float Y { get { return y; } }
        public float W { get { return w; } }
        public float H { get { return h; } }

        public abstract Figure Clone();
        public virtual void Move(float ax, float ay)
        {
            x = ax; y = ay;
        }

        public virtual void Resize(float aw, float ah)
        {
            w = aw; h = ah;
        }

        public virtual void Draw(Graphics g)
        { }

        public virtual bool Check(float ax, float ay)   // Проверяем попал ли я в точку? (для манипулятора)
        {
 

            if (Math.Abs(ax - x) + Math.Abs(ay - y) < 5)
            {
                ActivePoint = 1;
                return true;
            }

            if (Math.Abs(ax - x - w) + Math.Abs(ay - y ) < 5)
            {
                ActivePoint = 2;
                return true;
            }

            if (Math.Abs(ax - x - w) + Math.Abs(ay - y - h) < 5)
            {
                ActivePoint = 3;
                return true;
            }

            if (Math.Abs(ax - x) + Math.Abs(ay - y - h) < 5)
            {
                ActivePoint = 4;
                return true;
            }

            if (ax >= X && ay >= Y && ax <= (X + W) && ay <= (Y + H))
            {
                ActivePoint = 0; // живот
                return true;
            }

            return false;
        }
    }
}
