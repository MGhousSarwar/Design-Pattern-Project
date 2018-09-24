using Dp_project.Classes;
using Dp_project.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dp_project
{
    public partial class Login : Form
    {
        Form1 obj;


        public Login(Form1 obj)
        {
            this.obj = obj;

            //lstofuser = new;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {

            bool topass = false;
            if (checkBox1.Checked)
            {
                topass = true;
            }
            if (comboBox1.SelectedIndex != -1)
            {
                Cuser user = new Cuser(textBox2.Text, textBox1.Text, topass,comboBox1.SelectedItem.ToString());
                Cuser newuser = Program.database.userlist.Find(r => r.username == textBox2.Text && r.password == textBox1.Text && r.roles==comboBox1.SelectedItem.ToString());
                if (newuser != null)
                {
                    obj.rolecheck = newuser.person;

                    if (!newuser.remember && topass)
                    {
                        Program.database.userlist.Remove(newuser);
                        Program.database.userlist.Add(user);
                        Program.database.userlist[Program.database.userlist.Count - 1].person = obj.rolecheck;


                    }
                    obj.Username = textBox2.Text;
                    obj.role = comboBox1.SelectedItem.ToString();
                    obj.Show();
                    this.Hide();
                }
                else
                {
                    bool check = false;
                    string messagetoshow = "";
                    //check in remaining list
                   
                    switch (comboBox1.SelectedIndex)
                    {
                        //student
                        case 0:
                            obj.rolecheck = Program.database.listofstudent.Find(r => r.usernmae == textBox2.Text && r.password == textBox1.Text);
                            if (obj.rolecheck != null)
                            {
                                check = true;
                               
                            }
                            else
                            {
                                messagetoshow += "Student's username or password is incorrect";
                            }
                            break;

                        //advisor
                        case 1:
                            obj.rolecheck = Program.database.listofadvisor.Find(r => r.usernmae == textBox2.Text && r.password == textBox1.Text);
                            if (obj.rolecheck != null)
                            {
                                check = true;
                               
                            }
                            else
                            {
                                messagetoshow += "Advisor's username or password is incorrect";
                            }
                            break;

                        //internal
                        case 2:

                            obj.rolecheck = Program.database.listofinternal.Find(r => r.usernmae == textBox2.Text && r.password == textBox1.Text);
                            if (obj.rolecheck != null)
                            {
                                check = true;
                            }
                            else
                            {
                                messagetoshow += "Internal's username or password is incorrect";
                            }
                            break;

                        //external
                        case 3:
                            obj.rolecheck = Program.database.listofexternal.Find(r => r.usernmae == textBox2.Text && r.password == textBox1.Text);
                            if (obj.rolecheck != null)
                            {
                                check = true;
                            }
                            else
                            {
                                messagetoshow += "External's username or password is incorrect";
                            }
                            break;

                        default:
                            messagetoshow += "Kindly Select Role \n";
                            break;
                    }
                    if (!check)
                    {
                        MessageBox.Show(messagetoshow);
                    }
                    else
                    {
                       
                        Program.database.userlist.Add(user);
                        Program.database.userlist[Program.database.userlist.Count - 1].person=obj.rolecheck;
                        obj.Username = textBox2.Text ;
                        obj.role = comboBox1.SelectedItem.ToString();
                        obj.Show();
                        this.Hide();

                    }
                }
            }
            else
            {
                MessageBox.Show("Kindly Select Role \n");
            }
            Program.obj.serialize(Program.database);
            Program.database=Program.obj.deserialize();

        }



        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Kidnly Contact Admin Dapart of your University \n\tThank You");
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Cuser newuser = Program.database.userlist.Find(r => r.username == textBox2.Text.ToString().ToLower());
            if (newuser != null && newuser.remember == true)
            {
                textBox1.Text = newuser.password;
                comboBox1.SelectedItem = newuser.roles;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
