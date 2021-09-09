using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class Manipulator:Figure
    {
        public Figure selected;
        public void Attach(Figure f)
        {
            if (f != null)
            {
                Move(f.X, f.Y);
                Resize(f.W, f.H);
            }
            selected = f;
        }

        public override void Draw(Graphics g)
        {
            if (selected != null)
                g.DrawRectangle(Pens.Blue, X - 2, Y - 2, W + 4, H + 4);
        }

        public void Drag(float dx, float dy)
        {
            switch (ActivePoint)
            {
                case 0: { Move(X + dx, Y + dy); break; }
                case 1: { Move(X + dx, Y + dy); Resize(W - dx, H - dy); break; }
                case 2: { Move(X, Y+dy); Resize(W + dx, H - dy); break; }
                case 3: { Resize(W + dx, H + dy); break; }
                case 4: { Move(X + dx, Y); Resize(W - dx, H + dy); break; }
                default: break;
            }
        }

        public void Update()
        {
            if (selected != null)
            {
                selected.Move(X, Y);
                selected.Resize(W, H);
            }
        }

        public override Figure Clone()
        {
            return null;
        }
    }
}
