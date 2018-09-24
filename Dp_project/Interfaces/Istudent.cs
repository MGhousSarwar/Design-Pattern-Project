using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dp_project.Interfaces
{

    interface Istudent
    {
        void proposeidea(string idea, string ideades, string link);
        
        void updateproject(String addr, String commit);

        void selectadvisor(int adviisorid);
    }

}
