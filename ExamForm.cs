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
        private int counter = 5;
        private Timer timer1 = new Timer();

        public ExamForm()
        {
            InitializeComponent();
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            navBarGroup1.Caption = counter.ToString();

            //List<Grouping> groups = DbController.GetInstance().GetGroups();
            //navBarItem1.Caption = groups[0].groupName;
            //navBarItem2.Caption = groups[1].groupName;
            //navBarItem3.Caption = groups[3].groupName;

            List<General> generals = DbController.GetInstance().GetGenerals();
            navBarItem1.Caption = generals[0].generalName;
            navBarItem2.Caption = generals[1].generalName;
            navBarItem3.Caption = generals[2].generalName;
            navBarItem4.Caption = generals[3].generalName;
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
    }
}
