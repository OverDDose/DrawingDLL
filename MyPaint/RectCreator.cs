using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class RectCreator: Creator
    {
        public override Figure Create()
        {
            Rect r = new Rect();
            r.Resize(30, 30);
            return r;
        }
    }
}
