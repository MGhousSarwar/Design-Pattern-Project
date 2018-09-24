using Dp_project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Dp_project.Classes
{
    [Serializable]
    public class Cstudent : Cperson, Istudent
    {
        public double cgpa { get; set; }
        public Cadvisor myadvisor { get; set; }
        public List<Cidea> lstofideas = new List<Cidea>();
        public Cproject selectedproject { get; set; }
        public Cstudent()
        {
            lstofideas = new List<Cidea>();
        }

        public void attachsubscribertostudent()
        {

            if (myadvisor != null)
            {
                sent.Detachall();
                sent.Attach(Program.database.listofadvisor.Find(r => r.id == myadvisor.id));
                for (int i = 0; i < Program.database.listofinternal.Count; i++)
                {
                    sent.Attach(Program.database.listofinternal[i]);

                }
                Program.database.listofstudent[this.id - 1] = this;
            }
            else
            {
                MessageBox.Show("Kindly Select Advisor First");
            }
            base.sync();
        }

        public override void sync()
        {
            base.sync();
            attachsubscribertostudent();
        }

        public void proposeidea(string idea, string ideades, string link)
        {
            lstofideas.Add(new Cidea(lstofideas.Count , idea, ideades, link));
            sent.addnewnotification(new Studentproposedidea(lstofideas[lstofideas.Count - 1], id));
        }

        public void updateproject(string addr, string commit)
        {
            selectedproject.project_git_address = addr;
            selectedproject.comitt.Add(commit);
            sent.addnewnotification(new Stduentupdateproject(this));
        }

        public void selectadvisor(int adviisorid)
        {
            myadvisor = Program.database.listofadvisor[adviisorid];
            sync();
        }

        public override void Update(Notifications notifica)
        {
            //update about the Notifications
            Received.Add(notifica);
            Program.database.listofstudent[this.id - 1] = this;
            sync();
        }


    }
}
