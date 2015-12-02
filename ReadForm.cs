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
            List<Grouping> groupResponse = DbController.GetInstance().GetGroupByGroupID(1);
            splitContainerControl1.Panel2.Text = groupResponse[0].groupName + ":                                      Нийт Асуулт:" + aa.ToString();
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
            navBarGroup1.Expanded = false;
            navBarGroup2.Expanded = false;
            navBarGroup3.Expanded = false;
            navBarGroup4.Expanded = false;
            navBarControl1.EndUpdate();
            navBarControl1.LinkClicked += new NavBarLinkEventHandler(navBarControl1_LinkClicked);
               
            
        }

        private void navBarControl1_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            PanelContainer.Controls.Clear();
            int a=1;
            char[] chars = e.Link.Caption.ToCharArray();
            if (chars[0] == 'М') { a = 41; }
            else
            {
                if (chars[0] == 'А') { a = 42; }
                else { if (chars[0] == 'К') { a = 43; } }
            }
            if (a < 41)
            {
                {
                    a = Convert.ToInt32(chars[0].ToString());
                    if (chars[1] > 46 && chars[1] < 58)
                    { a = a * 10 + Convert.ToInt32(chars[1].ToString()); }
                }
            }
            List<Question> questions = DbController.GetInstance().GetQuestionsByGroupId(a);
            aa = questions.Count;
            List<Grouping> groupResponse = DbController.GetInstance().GetGroupByGroupID(a);
            splitContainerControl1.Panel2.Text = groupResponse[0].groupName + ":                                      Нийт Асуулт:" + aa.ToString();

            for (int i = aa - 1; i >= 0; i--)
            {
                UcQuestionRead us = new UcQuestionRead(i + 1, questions[i]);
                us.Dock = DockStyle.Top;
                us.AutoSize = true;
                PanelContainer.Controls.Add(us);
            }
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
