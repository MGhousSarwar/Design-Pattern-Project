using Dp_project.Enum;
using System.Collections.Generic;
using System;


namespace Dp_project.Classes
{



    //product
    [Serializable]

    public abstract class subject
    {
        public string des { get; set; }

    }
    //concreate product
    [Serializable]

    class Proposed_Idea : subject
    {
        public Cidea Idea;

        public Proposed_Idea(Cidea idea, int id)
        {
            Idea = idea;
            des = "An idea has been proposed by student\n Std ID: " + id + "\n Idea Name: " + idea.ideaname + "\n Idea Description: " + idea.ideadescription;

        }
    }
    [Serializable]

    class Idea_Accepted : subject
    {
        public Idea_Accepted(Cidea idea, int id, Cadvisor advosir)
        {
            des = "An idea has been Accepted by Advosor\n Advisor ID: " + advosir.id + "\n Advisor Name: " + advosir.firstname + "\n Std ID: " + (id + 1) + "\n Idea Id: " + idea.id + "\n Idea Description: " + idea.ideadescription;

        }
    }
    [Serializable]
    class Project_Updated : subject
    {
        public Project_Updated(Cstudent std)
        {
            des = "A Student Updated Project \nID: {0}\n Name: {1}" + std.id + std.firstname;
        }
    }

    //creator
    [Serializable]

    public abstract class Notifications
    {
        protected subject notification;
        public subject notifications
        {
            get { return notification; }
        }
    }

    //concreate creator
    [Serializable]

    class Studentproposedidea : Notifications
    {
        public Studentproposedidea(Cidea Idea, int studid)
        {
            notification = new Proposed_Idea(Idea, studid);
        }

    }
    [Serializable]

    class Advisoracceptidea : Notifications
    {
        public Advisoracceptidea(Cidea idea, int studid, Cadvisor advosir)
        {
            notification = new Idea_Accepted(idea, studid, advosir);
        }


        //

    }
    [Serializable]
    class Stduentupdateproject : Notifications
    {
        public Stduentupdateproject(Cstudent std)
        {
            notification = new Project_Updated(std);
        }
    }
}