using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    class Picture
    {
        private List<Figure> figs = new List<Figure>();
        public Manipulator manip = new Manipulator();

        public Group tmpGrp = new Group(); // В нее добавлять


        public void Draw(Graphics g)
        {
            tmpGrp.Draw(g);

            //if (tmpGrp.)
            //manip.


            foreach (var f in figs)
                f.Draw(g);

            if (manip.selected != null)
                manip.Draw(g);
        }

        public void Add(Figure f)
        {
            if (f != null && !figs.Contains(f))
                figs.Add(f);
        }

        public Figure Select(float ax, float ay)
        {
            Figure f = null;

            if (manip.Check(ax,ay))
            {
                return manip.selected;
            }
            
            foreach (Figure af in figs)
                if (af.Check(ax, ay))
                {
                    f = af;
                    break;
                }

            manip.Attach(f);
            return f;
        }


        // добавлена мной
        public Figure GetFigure(float ax, float ay)
        {
            foreach (Figure f in figs)
            {
                if (f.Check(ax, ay))
                    return f;
            }
            return null;
        }
    }
}
