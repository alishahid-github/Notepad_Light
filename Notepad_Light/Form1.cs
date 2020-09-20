using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_Light
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        int last_find = 0;
        string text;
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FindForm fform = new FindForm())
            {
                fform.ShowDialog();
                text = fform.findTextBox.Text.ToString();
                last_find = richTextBox.Find(text);
                richTextBox.Select(last_find, text.Length);

            }


        }


        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }

        private void fIndNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            do
            {
                richTextBox.Select(last_find, text.Length);
                last_find = richTextBox.Find(text, last_find + 1, RichTextBoxFinds.None);
                richTextBox.Select(last_find, text.Length);
                Thread.Sleep(1000);
            } while (MessageBox.Show("Do you want to Find Next?", "Find", MessageBoxButtons.OKCancel) == DialogResult.OK);

        }
    }
}
