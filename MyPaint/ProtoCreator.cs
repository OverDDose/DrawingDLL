using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    class ProtoCreator : Creator
    {
        Figure prototype;
        public ProtoCreator(Figure f)
        {
            prototype = f.Clone();
        }
        public override Figure Create()
        {
            return prototype.Clone();
        }
    }
}
