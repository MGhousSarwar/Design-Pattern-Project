using Dp_project.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dp_project.Classes
{
    [Serializable]
    class Cuser
    {
        public bool remember { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string roles { get; set; }
        public Cperson person { get; set; }
        public Cuser(string username,string pass,bool remember,string role)
        {
            this.remember = remember;
            this.username = username;
            password = pass;
            roles = role;
          
        }

    }
}
