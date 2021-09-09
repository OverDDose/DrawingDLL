using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class GroupCreator: Creator
    {
        public override Figure Create()
        {
            Group gr = new Group();
            Rect r = new Rect();
            r.Resize(30, 30);

            Ellipse e = new Ellipse();
            e.Resize(30, 30);
            e.Move(20, 20);
            gr.Add(r);
            gr.Add(e);
            return gr;
        }
    }
}
