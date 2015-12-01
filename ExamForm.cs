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
    public partial class ExamForm : Form
    {
        //public static ExamForm Instance { public get; private set; }
        private List<UcQuestion> group1_questions = new List<UcQuestion>();
        private List<NavBarItem> group1_navbarItems = new List<NavBarItem>();
        private int timerSec = 2400;
        private Timer timer1 = new Timer();
        private int g1Anwser = 40;
        private int g2Anwser = 15;
        private int g3Anwser = 15;

        public ExamForm()
        {
            InitializeComponent();
            //Instance = this;
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            panelControl1.Dock = DockStyle.Top;
            xtraTabControl1.Dock = DockStyle.Top;
            
            //List<Grouping> groups = DbController.GetInstance().GetGroups();
            List<Question> questions = DbController.GetInstance().GetQuestions();

            Random random = new Random();
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < g1Anwser)
            {
                numbers.Add(random.Next(0, questions.Count-1));
            }
            //Array ee = numbers.ToArray();
            //ee.GetValue(1);


            for (int i = g1Anwser-1; i >= 0; i--)
            {
                UcQuestion uc = new UcQuestion(i + 1, questions[Convert.ToInt32(numbers.ToArray().GetValue(i))]);
                uc.Dock = DockStyle.Top;
                uc.AutoSize = true;

                xtraTabPage1.Controls.Add(uc);
                group1_questions.Add(uc);

                NavBarItem item = new NavBarItem();
                item.Caption = "Асуулт "+(g1Anwser - i);
                item.Tag = i;
                navBarGroup1.ItemLinks.Add(item);
                group1_navbarItems.Add(item);
            }

            questions.Clear();

            

            
            //navBarItem1.Caption = groups[0].groupName;
            //navBarItem2.Caption = groups[1].groupName;
            //navBarItem3.Caption = groups[3].groupName;

            //List<General> generals = DbController.GetInstance().GetGenerals();
            //navBarItem1.Caption = generals[0].generalName;
            //navBarItem2.Caption = generals[1].generalName;
            //navBarItem3.Caption = generals[2].generalName;
            //navBarItem4.Caption = generals[3].generalName;
            //navBarItem1.Caption = "test";
        }

        public void ucRadioButtonChanged(int i)
        {
            group1_navbarItems[i].Visible = false;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            timerSec--;
            if (timerSec == 0)
            {
                timer1.Stop();
                label1.Text = "00:00";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
            }
            else
            {
                //navBarGroup1.Caption = timerSec.ToString();
                TimeSpan span = TimeSpan.FromSeconds(timerSec);
                label1.Text = span.ToString(@"mm\:ss");
            }
        }

        private void ExamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void ExamForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
