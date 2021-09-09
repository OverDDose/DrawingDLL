using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class Rect: Figure 
    {
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, X, Y, W, H);
        }

        public override bool Check(float ax, float ay)
        {
            return ( ax >= X && ay >= Y && ax <= (X+W) && ay <= (Y+H) );
        }

        public override Figure Clone()
        {
            Rect r = new Rect();
            r.Move(X, Y);
            r.Resize(W, H);
            return r;
        }
    }
}
