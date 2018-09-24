using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dp_project.Classes
{
    [Serializable]
    class C_Db
    {
        //Facade
        /*
        Provide a unified interface to a set of interfaces in a subsystem.Façade defines 
        a higher-level interface that makes the subsystem easier to use.
        */

        //here C_Db is Facade

        //these are subsystems
        public List<Cstudent> listofstudent = new List<Cstudent>();
        public List<Cadvisor> listofadvisor = new List<Cadvisor>();
        public List<Cinternal> listofinternal = new List<Cinternal>();
        public List<Cexternal> listofexternal = new List<Cexternal>();
        public List<Cuser> userlist = new List<Cuser>();
    }
}
