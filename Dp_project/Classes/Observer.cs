using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dp_project.Classes
{
    [Serializable]
    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    /// 
   public abstract class Observer
    {

        public List<Notifications> notifications { get; set; }

        private List<Cperson> subscriber = new List<Cperson>();

        // Constructor
        public Observer()
        {
            notifications = new List<Notifications>();
        }
        public void Attach(Cperson person)
        {
            subscriber.Add(person);
        }
        
        public void Detach(Cperson person)
        {
            subscriber.Remove(person);
        }
        public void Detachall()
        { 
            subscriber = new List<Cperson>();
        }
        public void Notify()
        {
            Program.obj.serialize(Program.database);
            Program.database = Program.obj.deserialize();
            foreach (Cperson sub in subscriber)
            {
                sub.Update(notifications[notifications.Count-1]);
            }
            //Console.WriteLine("");
        }
        public void addnewnotification(Notifications obj)
        {
            notifications.Add(obj);
            Notify();
        }

    }
    [Serializable]
    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
   public class Mailbox : Observer
    {
        public Mailbox()
        {
        }
    }
    /// <summary>
    /// The 'Observer' interface Cperson
    /// </summary>

    /// <summary>
    /// The 'ConcreteObserver' class std advosir etc
    /// </summary>


}
