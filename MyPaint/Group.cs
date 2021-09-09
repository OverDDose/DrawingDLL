using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class Group: Figure, IComposite
    {
        List<Figure> figs = new List<Figure>();
        //Manipulator manip = new Manipulator();

        public void Add(Figure f)
        {
            if (f == null)
                return;
            if (f == this)
                return;
            if (figs.Contains(f))
                return;
            figs.Add(f);

            float minx = int.MaxValue;
            float miny = int.MaxValue;
            float maxx = int.MinValue;
            float maxy = int.MinValue;

            foreach (Figure ff in figs)
            {
                if (ff.X < minx) minx = ff.X;
                if (ff.Y < miny) miny = ff.Y;
                if (ff.X + ff.W > maxx) maxx = ff.X + ff.W;
                if (ff.Y + ff.H > maxy) maxy = ff.Y + ff.H;
            }
            
            base.Move(minx, miny);
            base.Resize(maxx-minx, maxy-miny);
        }

        public void Remove(Figure f)
        {
            figs.Remove(f);
        }

        public bool Contains(Figure f)
        {
            if (figs.Contains(f))
                return true;
            else
                return false;
        }

        public Figure GetChild(int m)
        {
            if (m < figs.Count)
                return figs[m];
            return null;
        }

        public Figure GetFigure(float ax, float ay)
        {
            foreach (Figure f in figs)
            {
                if (f.Check(ax, ay))
                    return f;
            }
            return null;
        }

        public int GetCount()
        {
            return figs.Count;
        }

        public override void Draw(Graphics g)
        {
            foreach (Figure f in figs)
            {
                f.Draw(g);
            }
        }

        public override Figure Clone()
        {
            Group gr = new Group();
            foreach (Figure f in figs)
            {
                gr.Add(f.Clone());
            }
            return gr;
        }

        public override void Move(float ax, float ay)
        {
            float dx = ax - X;
            float dy = ay - Y;
            base.Move(ax, ay);
            foreach (Figure f in figs)
            {
                f.Move(f.X + dx, f.Y + dy);
            }
        }

        public override bool Check(float ax, float ay)
        {
            foreach (Figure f in figs)
            {
                if (f.Check(ax, ay))
                    return true;
            }
            return false;
        }

        public override void Resize(float aw, float ah)
        {
            float kw = aw / W;
            float kh = ah / H;
            base.Resize(aw, ah);
            foreach (Figure f in figs)
            {
                f.Resize(f.W * kw, f.H * kh);
                f.Move(X+kw*(f.X-X), Y+kh*(f.Y-Y));
            }
        }
    }
}
