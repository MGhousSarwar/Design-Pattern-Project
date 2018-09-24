using Dp_project.Enum;
using System;
using Dp_project.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dp_project.Classes
{

    [Serializable]
    public abstract class Cperson
    {

        public int id { get; set; }
        public string usernmae { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string contactnumber { get; set; }
        public DateTime doB { get; set; }
        public string email { get; set; }
        public Egender gender { get; set; }
        public string cnic { get; set; }

        public abstract void Update(Notifications notifica);
        public Mailbox sent = new Mailbox();
        public List<Notifications> Received = new List<Notifications>();
        public virtual void sync()
        {
            Program.obj.serialize(Program.database);
            Program.database = Program.obj.deserialize();
        }
    }
}