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
        private List<RadioButton> radioButtons = new List<RadioButton>();

        public UcQuestion(int qnumber, Question question)
        {
            InitializeComponent();

            label1.Text = qnumber + ". " + question.question;
            this.qnumber = qnumber;
            label2.Text = question.answer1;
            label3.Text = question.answer2;
            label4.Text = question.answer3;
            label5.Text = question.answer4;

            Random random = new Random();
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < 4)
            {
                numbers.Add(random.Next(1, 4));
            }

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

        private bool changing = false;

        private void AllCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            if (!changing)
            {
                changing = true;

                if (sender == this.radioButton1)
                {
                    this.radioButton2.Checked = !this.radioButton1.Checked;
                    this.radioButton3.Checked = !this.radioButton1.Checked;
                    this.radioButton4.Checked = !this.radioButton1.Checked;
                }
                else if (sender == this.radioButton2)
                {
                    this.radioButton1.Checked = !this.radioButton2.Checked;
                    this.radioButton3.Checked = !this.radioButton2.Checked;
                    this.radioButton4.Checked = !this.radioButton2.Checked;
                }
                else if (sender == this.radioButton3)
                {
                    this.radioButton1.Checked = !this.radioButton3.Checked;
                    this.radioButton2.Checked = !this.radioButton3.Checked;
                    this.radioButton4.Checked = !this.radioButton3.Checked;
                }
                else if (sender == this.radioButton4)
                {
                    this.radioButton1.Checked = !this.radioButton4.Checked;
                    this.radioButton2.Checked = !this.radioButton4.Checked;
                    this.radioButton3.Checked = !this.radioButton4.Checked;
                }

                changing = false;
            }
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                //RadioButton rb = (RadioButton)sender;
                //label1.Text = rb.Text;
                ExamForm parent = this.ParentForm as ExamForm;
                parent.ucRadioButtonChanged(qnumber-1);
                //ExamForm.Instance.ucRadioButtonChanged(i);
            }
        }
    }
}
