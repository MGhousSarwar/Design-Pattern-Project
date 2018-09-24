using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dp_project.Interfaces
{
    interface Iadvisor
    {
        void acceptIdea(int studid,int ideaid);
        void recomendtointernal(int studid, int internalid);


    }
}
