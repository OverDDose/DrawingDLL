using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    interface IComposite
    {
        void Add(Figure f);
        void Remove(Figure f);
        Figure GetChild(int m);
        int GetCount();
    }
}
