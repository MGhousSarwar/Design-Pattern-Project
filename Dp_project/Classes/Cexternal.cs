using Dp_project.Interfaces;
using System;
using System.Windows.Forms;

namespace Dp_project.Classes
{
    [Serializable]
    public class Cexternal : Cperson, Iexternal
    {
       

        public override void Update(Notifications notifica)
        {
            Received.Add(notifica);
            Program.database.listofexternal[this.id - 1] = this;

            sync();
        }
    }
}