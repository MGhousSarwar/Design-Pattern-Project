using System;
using Dp_project.Classes;
using Dp_project.Interfaces;
using Dp_project.Enum;


namespace Dp_project.Classes
{
    [Serializable]
    public class Cidea
    {
    public int id { get; set; }	
        public string ideaname { get; set; }
        public string ideadescription { get; set; }
        public string linkifany { get; set; }
        public Cidea(int id,string ideaname, string ideadescription, string linkifany)
        {
            this.ideaname = ideaname;
            this.ideadescription=ideadescription;
            this.linkifany = linkifany;
        }



    }
}