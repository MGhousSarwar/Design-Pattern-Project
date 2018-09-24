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
    public class Cadvisor : Cperson, Iadvisor
    {
        public List<Cstudent> mystud=new List<Cstudent>();
        public void attachedsubstoadvosor()
        {
            sent.Detachall();
            for (int i = 0; i < mystud.Count; i++)
            {
                Program.database.listofstudent[mystud[i].id-1] = mystud[i];
            }
            
            for (int i = 0; i < mystud.Count; i++)
            {
                sent.Attach(mystud[i]);
            }
            foreach (Cinternal item in Program.database.listofinternal)
            {
                sent.Attach(item);
            }
            //sync();
        }
        public void acceptIdea(int studid, int ideaid)
        {
            Cidea toaccept = Program.database.listofstudent[studid-1].lstofideas[ideaid];
            Program.database.listofstudent[studid-1 ].selectedproject = new Cproject(toaccept);
            attachedsubstoadvosor();
            sent.addnewnotification(new Advisoracceptidea(toaccept, studid - 1,this));
            sync();
        }

        public void recomendtointernal(int studid, int internalid)
        {
            throw new NotImplementedException();
        }

       

        public override void Update(Notifications notifica)
        {
            Received.Add(notifica);
            Program.database.listofadvisor[this.id - 1] = this;

            sync();
        }
    }
}