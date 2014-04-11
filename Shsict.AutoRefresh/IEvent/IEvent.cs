using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shsict.AutoRefresh
{
    public interface IEvent
    {
        void Execute(object state);
    }
}
