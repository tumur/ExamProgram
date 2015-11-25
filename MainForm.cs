using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamProgram
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ExamForm exam = new ExamForm();
            exam.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ReadForm read = new ReadForm();
            read.Show();
        }
    }
}
