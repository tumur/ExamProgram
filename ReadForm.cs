using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamProgram.Entity;
using DevExpress.XtraNavBar;


namespace ExamProgram
{
    public partial class ReadForm : Form
    {
        private NavBarItem[] items;
        private int aa;

        public ReadForm()
        {
            InitializeComponent();
            List<Question> questions = DbController.GetInstance().GetQuestionsByGroupId(1);
            aa = questions.Count;
            splitContainerControl1.Panel2.Text = "Хуулийн Тест";
            for (int i = aa-1; i >= 0; i--)
            {
                UcQuestionRead us = new UcQuestionRead(i + 1, questions[i]);
                us.Dock = DockStyle.Top;
                us.AutoSize = true;
                PanelContainer.Controls.Add(us);
            }
           
        }

        private void ReadForm_Load(object sender, EventArgs e)
        {
            items = new NavBarItem[43];
            navBarControl1.BeginUpdate();
            List<Grouping> group1 = DbController.GetInstance().GetGroupsByGeneralID(1);
            for (int i = 0; i < 40; i++)
            {
                items[i] = new NavBarItem((i+1).ToString()+": "+group1[i].groupName);
                items[i].SmallImageIndex = i;
                navBarGroup1.ItemLinks.Add(items[i]);   
            }
            List<Grouping> group2 = DbController.GetInstance().GetGroupsByGeneralID(2);
            items[40] = new NavBarItem((1).ToString() + ": " + group2[0].groupName);
            navBarGroup2.ItemLinks.Add(items[40]);

            List<Grouping> group3 = DbController.GetInstance().GetGroupsByGeneralID(3);
            items[40] = new NavBarItem((1).ToString() + ": " + group3[0].groupName);
            navBarGroup3.ItemLinks.Add(items[40]);

            List<Grouping> group4 = DbController.GetInstance().GetGroupsByGeneralID(4);
            items[40] = new NavBarItem((1).ToString() + ": " + group4[0].groupName);
            navBarGroup4.ItemLinks.Add(items[40]);
            navBarGroup1.Expanded = true;
            navBarControl1.EndUpdate();
            navBarControl1.LinkClicked += new NavBarLinkEventHandler(navBarControl1_LinkClicked);
        }

        private void navBarControl1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            PanelContainer.Controls.Clear();
            char[] chars = e.Link.Caption.ToCharArray();
            int a = Convert.ToInt32(chars[0].ToString()); // a - ni group id  
            List<Question> questions = DbController.GetInstance().GetQuestionsByGroupId(a);
            aa = questions.Count;

            for (int i = aa - 1; i >= 0; i--)
            {
                UcQuestionRead us = new UcQuestionRead(i + 1, questions[i]);
                us.Dock = DockStyle.Top;
                us.AutoSize = true;
                PanelContainer.Controls.Add(us);
            }
        }
    }
}
