using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lab_3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            О_программе programm = new О_программе();
            programm.ShowDialog();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ActiveMdiChild != null)
            ActiveMdiChild.Close();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.Name = "MDI";
            f.MdiParent = this;
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            f.Controls.Add(richTextBox);
            f.Show();
        }

        private void закрытьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] f = MdiChildren;
            foreach (Form form in f) {
                form.Close();
            }
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
            richTextBox.Copy();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
            richTextBox.Cut();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
            richTextBox.Paste();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                Form f = new Form();
                f.Name = "MDI";
                f.MdiParent = this;
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Dock = DockStyle.Fill;
                f.Controls.Add(richTextBox);

                // получаем выбранный файл
                string filename = openFileDialog.FileName;
                // читаем файл в строку
                string fileText = System.IO.File.ReadAllText(filename);
                richTextBox.Text = fileText;
                MessageBox.Show("Файл открыт");

                f.Show();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename + ".txt", richTextBox.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() == DialogResult.OK & !String.IsNullOrEmpty(richTextBox.Text))
            {
                richTextBox.SelectionFont = fontDialog.Font;
                richTextBox.SelectionColor = fontDialog.Color;
            }
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() == DialogResult.OK & !String.IsNullOrEmpty(richTextBox.Text))
            {
                richTextBox.SelectionFont = fontDialog.Font;
                richTextBox.SelectionColor = fontDialog.Color;
            }
        }

        private void цветToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK & !String.IsNullOrEmpty(richTextBox.Text))
            {
                richTextBox.SelectionColor = colorDialog.Color;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusBar1.Panels[0].Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
            richTextBox.BackColor = System.Drawing.Color.Red;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            RichTextBox richTextBox = this.ActiveMdiChild.Controls[0] as RichTextBox;
            richTextBox.SelectionColor = System.Drawing.Color.DarkKhaki;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"c:\\");
        }
    }
}
