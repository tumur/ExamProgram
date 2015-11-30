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

    public partial class UcQuestion : UserControl
    {
        private int qnumber;
        private int rightAnswer;

        public UcQuestion(int qnumber, Question question)
        {
            InitializeComponent();

            label1.Text = qnumber + ". " + question.question;
            this.qnumber = qnumber;
            label2.Text = question.answer1;
            label3.Text = question.answer2;
            label4.Text = question.answer3;
            label5.Text = question.answer4;

            this.rightAnswer = question.rightAnswer;

            this.radioButton1.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            this.radioButton2.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            this.radioButton3.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
            this.radioButton4.CheckedChanged += new System.EventHandler(this.AllCheckBoxes_CheckedChanged);
        }

        private void UcQuestion_Load(object sender, EventArgs e)
        {

        }

        private void panelControl1_ClientSizeChanged(object sender, EventArgs e)
        {
                    }

        private void panelControl1_ClientSizeChanged_1(object sender, EventArgs e)
        {
            label1.MaximumSize = new Size((sender as Control).ClientSize.Width - label1.Left - 10, 10000);
            label2.MaximumSize = new Size((sender as Control).ClientSize.Width - label1.Left - 10, 10000);
            label3.MaximumSize = new Size((sender as Control).ClientSize.Width - label1.Left - 10, 10000);
            label4.MaximumSize = new Size((sender as Control).ClientSize.Width - label1.Left - 10, 10000);
            label5.MaximumSize = new Size((sender as Control).ClientSize.Width - label1.Left - 10, 10000);
        }

        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RadioButton rb = (RadioButton)sender;
                //label1.Text = rb.Text;
                //ExamForm parent = this.ParentForm as ExamForm();
                //parent.ucRadioButtonChanged(i);
                //ExamForm.Instance.ucRadioButtonChanged(i);
            }
        }
    }
}
