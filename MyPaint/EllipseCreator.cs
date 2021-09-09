using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class EllipseCreator: Creator
    {
        public override Figure Create()
        {
            Ellipse e = new Ellipse();
            e.Resize(30, 30);
            return e;
        }
    }
}
