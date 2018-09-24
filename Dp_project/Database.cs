using System;
using System.Windows.Forms;
using Dp_project.Classes;

namespace Dp_project
{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }
        public void refersh()
        {
            Program.obj.serialize(Program.database);
            Program.database = Program.obj.deserialize();
            dataGridView1.DataSource = Program.database.listofstudent;

            dataGridView2.DataSource = Program.database.listofadvisor;
            dataGridView3.DataSource = Program.database.listofinternal;
            dataGridView4.DataSource = Program.database.listofexternal;
            dataGridView5.DataSource = Program.database.userlist;
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();
            dataGridView4.Refresh();
            dataGridView5.Refresh();

        }
        private void Database_Load(object sender, EventArgs e)
        {
            refersh();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refersh();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new stduent
            Program.database.listofstudent.Add(new Cstudent()
            {
                id = (Program.database.listofstudent.Count) + 1,
                usernmae = "stduser" + DateTime.Now.Date.Day + (DateTime.Now.TimeOfDay.Hours + DateTime.Now.Minute + DateTime.Now.Millisecond).ToString(),
                password =(DateTime.Now.TimeOfDay.Hours+DateTime.Now.Minute+DateTime.Now.Millisecond).ToString(),
                address = "abcaddr " + DateTime.Now.TimeOfDay.ToString(),
                contactnumber = "012011",
                firstname = "stdfname " + DateTime.Now.TimeOfDay.ToString(),
            });

           
            refersh();
        }

        private void addNewAdvisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new advisor
            Program.database.listofadvisor.Add(new Cadvisor()
            {
                id = (Program.database.listofadvisor.Count) + 1,

                usernmae = "advisoruser" + DateTime.Now.Date.Day + (DateTime.Now.TimeOfDay.Hours + DateTime.Now.Minute + DateTime.Now.Millisecond).ToString(),
                password = (DateTime.Now.TimeOfDay.Hours + DateTime.Now.Minute + DateTime.Now.Millisecond).ToString(),
                address = "abcaddr " + DateTime.Now.TimeOfDay.ToString(),
                contactnumber = "012011",
                firstname = "advisorfname " + DateTime.Now.TimeOfDay.ToString(),
            });


            refersh();
        }

        private void addNewInternalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new internal
            Program.database.listofinternal.Add(new Cinternal()
            {
                id = (Program.database.listofinternal.Count) + 1,

                usernmae = "interuser" + DateTime.Now.Date.Day + (DateTime.Now.TimeOfDay.Hours + DateTime.Now.Minute + DateTime.Now.Millisecond).ToString(),
                password = (DateTime.Now.TimeOfDay.Hours + DateTime.Now.Minute + DateTime.Now.Millisecond).ToString(),
                address = "abcaddr " + DateTime.Now.TimeOfDay.ToString(),
                contactnumber = "012011",
                firstname = "interfname " + DateTime.Now.TimeOfDay.ToString(),
            });


            refersh();
        }

        private void addNewExternalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new external
            Program.database.listofexternal.Add(new Cexternal()
            {
                id = (Program.database.listofexternal.Count) + 1,

                usernmae = "exteruser" +DateTime.Now.Date.Day+ (DateTime.Now.TimeOfDay.Hours + DateTime.Now.Minute + DateTime.Now.Millisecond).ToString(),
                password = (DateTime.Now.TimeOfDay.Hours + DateTime.Now.Minute + DateTime.Now.Millisecond).ToString(),
                address = "abcaddr " + DateTime.Now.TimeOfDay.ToString(),
                contactnumber = "012011",
                firstname = "exterfname " + DateTime.Now.TimeOfDay.ToString(),
            });


            refersh();
        }
    }
}
