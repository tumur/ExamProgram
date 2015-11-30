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

namespace ExamProgram
{
    public partial class ExamForm : Form
    {
        //public static ExamForm Instance { public get; private set; }
        private int counter = 5000;
        private Timer timer1 = new Timer();

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
            navBarGroup1.Caption = counter.ToString();
            
            //List<Grouping> groups = DbController.GetInstance().GetGroups();
            List<Question> questions = DbController.GetInstance().GetQuestions();

            Random random = new Random();
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < 40)
            {
                numbers.Add(random.Next(0, questions.Count-1));
            }
            //Array ee = numbers.ToArray();
            //ee.GetValue(1);

            for (int i = 39; i >= 0; i--)
            {
                UcQuestionTest us = new UcQuestionTest(i + 1, questions[Convert.ToInt32(numbers.ToArray().GetValue(i))]);
                us.Dock = DockStyle.Top;
                us.AutoSize = true;
                xtraTabPage1.Controls.Add(us);
            }

            

            
            //navBarItem1.Caption = groups[0].groupName;
            //navBarItem2.Caption = groups[1].groupName;
            //navBarItem3.Caption = groups[3].groupName;

            List<General> generals = DbController.GetInstance().GetGenerals();
            navBarItem1.Caption = generals[0].generalName;
            navBarItem2.Caption = generals[1].generalName;
            navBarItem3.Caption = generals[2].generalName;
            navBarItem4.Caption = generals[3].generalName;
            navBarItem1.Caption = "test";
        }

        public void ucRadioButtonChanged(int i)
        {
            navBarItem1.Caption = "lolzmaa";
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
                navBarGroup1.Caption = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
            }
            else
            {
                navBarGroup1.Caption = counter.ToString();
            }
        }

        private void ExamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void ExamForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
    }
}
