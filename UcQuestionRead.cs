using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamProgram.Entity;

namespace ExamProgram
{
    public partial class UcQuestionRead : UserControl
    {
        private int qnumber;

        public UcQuestionRead()
        {
            InitializeComponent();
        }

                public UcQuestionRead(int qnumber, Question question)
        {
            InitializeComponent();

            label1.Text = "АСУУЛТ:"+qnumber + ":\n " + question.question;
            this.qnumber = qnumber;
            label2.Text = question.answer1;

        }

        private void panelControl1_ClientSizeChanged(object sender, EventArgs e)
        {

            label1.MaximumSize = new Size((sender as Control).ClientSize.Width - label1.Left - 10, 10000);
            label2.MaximumSize = new Size((sender as Control).ClientSize.Width - label1.Left - 10, 10000);
        }

    }
}
