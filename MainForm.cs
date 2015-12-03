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

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label4.Text = label4.Text + "\n МОНГОЛ ХЭЛ";
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void czxc(object sender, EventArgs e)
        {
            pictureEdit6.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\update_b.png");
            label7.ForeColor = System.Drawing.Color.Gray;
        }

        private void MouseOver(object sender, EventArgs e)
        {
            pictureEdit1.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\exam_b.png");
            label2.ForeColor = System.Drawing.Color.Gray;
        }

        private void pictureEdit1_MouseLeave(object sender, EventArgs e)
        {
            pictureEdit1.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\exam_a.png");
            label2.ForeColor = System.Drawing.Color.Black;
            
        }

        private void pictureEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void mouseOverLaw(object sender, EventArgs e)
        {
            pictureEdit3.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\law_b.png");
            label3.ForeColor = System.Drawing.Color.Gray;
        }

        private void pictureEdit3_MouseLeave(object sender, EventArgs e)
        {
            pictureEdit3.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\law_a.png");
            label3.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureEdit2_MouseHover(object sender, EventArgs e)
        {
            pictureEdit2.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\letter_b.png");
            label4.ForeColor = System.Drawing.Color.Gray;
        }

        private void pictureEdit2_MouseLeave(object sender, EventArgs e)
        {
            pictureEdit2.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\letter_a.png");
            label4.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureEdit4_MouseHover(object sender, EventArgs e)
        {
            pictureEdit4.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\computer_b.png");
            label5.ForeColor = System.Drawing.Color.Gray;
        }

        private void pictureEdit4_MouseLeave(object sender, EventArgs e)
        {
            pictureEdit4.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\computer_a.png");
            label5.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureEdit5_MouseHover(object sender, EventArgs e)
        {
            pictureEdit5.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\read_b.png");
            label6.ForeColor = System.Drawing.Color.Gray;
        }

        private void pictureEdit5_MouseLeave(object sender, EventArgs e)
        {
            pictureEdit5.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\read_a.png");
            label6.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureEdit6_MouseLeave(object sender, EventArgs e)
        {
            pictureEdit6.Image = Image.FromFile(@"C:\Users\snip\Documents\GitHub\ExamProgram\Resources\update_a.png");
            label7.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            ExamForm read = new ExamForm();
            read.Show();
        }

        private void pictureEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit5_Click(object sender, EventArgs e)
        {
            ReadForm read = new ReadForm();
            read.Show();
        }

        private void pictureEdit8_Click(object sender, EventArgs e)
        {
            ActiveForm.WindowState  = FormWindowState.Minimized;
        }

        private void pictureEdit7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }}
