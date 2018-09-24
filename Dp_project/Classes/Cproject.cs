using System.Collections.Generic;
using System;

namespace Dp_project.Classes
{
    [Serializable]
    public class Cproject
    {
        public Cidea projectidea { get; set; }
        public string project_git_address { get; set; }
        public List<string> comitt { get; set; }
        public Cproject(Cidea projectidea)
        {
            this.projectidea = projectidea;
            comitt = new List<string>();
        }

    }
}