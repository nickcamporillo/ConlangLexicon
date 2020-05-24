using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dummy.Service
{
    public interface IDumbService: IDisposable
    {
        void Activate();
    }
}
