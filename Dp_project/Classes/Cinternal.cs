using Dp_project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dp_project.Classes
{
    [Serializable]
    class Cinternal : Cperson, Iinternal
    {
        public List<Cstudent> studentlist { get; set; }
        public Cinternal()
        {

        }
        public void provide_recommendation(int studid)
        {

        }
        public void view_project(int studid)
        {

        }
        public void recomendtoexternal(int studid, int internalid)
        {
        }
        
        private void save()
        {

        }

        public override void Update(Notifications notifica)
        {
            Received.Add(notifica);
            Program.database.listofinternal[this.id - 1] = this;

            sync();
        }

        
    }
}
