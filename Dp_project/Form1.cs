using Dp_project.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dp_project
{
    public partial class Form1 : Form

    {
        //coment
        public string Username { get; set; }
        public bool userset { get; set; }
        public string role { get; set; }
        public Cperson rolecheck { get; set; }

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var thread = new Thread(() =>
            {
                Database obj = new Database();

                obj.ShowDialog();
            });
            thread.Start();


            Login objj = new Login(this);
            this.Hide();
            objj.ShowDialog();

            
            label1.Text = "Welcome " + Username;
            userset = true;
            Cperson temp = null;
            switch (role)
            {
                case "Student":
                    temp = Program.database.listofstudent[rolecheck.id - 1];
                    advpanel.Visible = false;
                    interpanel.Visible = false;
                    exterpanel.Visible = false;
                    stdpanel.Dock = DockStyle.Fill;
                    setstdienviroment();
                    break;
                case "Advisor":
                    temp = Program.database.listofadvisor[rolecheck.id - 1];

                    advpanel.Dock = DockStyle.Fill;
                    interpanel.Visible = false;
                    exterpanel.Visible = false;
                    stdpanel.Visible = false;
                    setadvienviroment();
                    break;
                case "Internal":
                    temp = Program.database.listofinternal[rolecheck.id - 1];

                    advpanel.Visible = false;
                    interpanel.Dock = DockStyle.Fill;
                    exterpanel.Visible = false;
                    stdpanel.Visible = false;
                    setinterenviroment();
                    break;
                case "External":
                    temp = Program.database.listofexternal[rolecheck.id - 1];

                    advpanel.Visible = false;
                    interpanel.Visible = false;
                    exterpanel.Dock = DockStyle.Fill;
                    stdpanel.Visible = false;
                    setexterenviroment();
                    break;
                default:
                    break;
            }

            shownotificaton(temp);

        }

        private void shownotificaton(Cperson temp)
        {
            richTextBox3.Clear();
            richTextBox2.Clear();
            for (int i = 0; i < temp.sent.notifications.Count; i++)
            {
                richTextBox3.Text+="\n\n"+temp.sent.notifications[i].notifications.des;
            }
            for (int i = 0; i < temp.Received.Count; i++)
            {
                richTextBox2.Text+="\n\n"+temp.Received[i].notifications.des;
            }
        }

        private void setadvienviroment()
        {
            //throw new NotImplementedException();
        }

        private void setexterenviroment()
        {
            throw new NotImplementedException();
        }

        private void setinterenviroment()
        {
        }

        private void setstdienviroment()
        {
            Cstudent temp = Program.database.listofstudent[rolecheck.id - 1];
            if (temp.myadvisor==null)
            {
                dataGridView1.DataSource = Program.database.listofadvisor;
                label12.Text = "Select Your Advisor";
                panel6.Visible = false;
                panel5.Visible = false;
                label13.Text = "";

            }
            else
            {
                //show advisor
                ShowAdvisor(temp);
                if (temp.selectedproject==null)
                {
                    label13.Text = "Project Selection is Still pending";
                    panel6.Visible = false;
                }
                else
                {
                    panel5.Visible = false;
                }
            }

        }

        private void ShowAdvisor(Cstudent temp)
        {
            button2.Enabled = false;
            label7.Visible = false;
            dataGridView1.Visible = false;
            label12.Visible = true;
            panel5.Visible = true;
            label12.Text = "Selected Advisor: " + temp.myadvisor.firstname;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        //select advisor
        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            Program.database.listofstudent[rolecheck.id - 1].selectadvisor(id - 1) ;
            Program.database.listofadvisor[id - 1].mystud.Add(Program.database.listofstudent[rolecheck.id - 1]);
            sync();
            ShowAdvisor(Program.database.listofstudent[rolecheck.id - 1]);
        }

        private static void sync()
        {
            Program.obj.serialize(Program.database);
            Program.database = Program.obj.deserialize();
        }

        //proposed
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            string name = textBox2.Text;
            string des = richTextBox1.Text;
            string link = textBox5.Text;
            Program.database.listofstudent[rolecheck.id - 1].proposeidea(name, des, link);
            sync();
            shownotificaton(Program.database.listofstudent[rolecheck.id - 1]);

        }
        //accept
        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            Program.database.listofadvisor[rolecheck.id - 1].acceptIdea(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text));
            sync();
            shownotificaton(Program.database.listofadvisor[rolecheck.id - 1]);
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
