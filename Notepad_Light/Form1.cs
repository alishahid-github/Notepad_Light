using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }

        string fileNameAndPath = "";

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(fileNameAndPath))
            {
                richTextBox.SaveFile(fileNameAndPath);

            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileNameAndPath = saveFileDialog1.FileName;
                    richTextBox.SaveFile(fileNameAndPath);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileNameAndPath = saveFileDialog1.FileName;
                richTextBox.SaveFile(fileNameAndPath);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string data = File.ReadAllText(openFileDialog1.FileName);
                richTextBox.Text = data;
            }
                
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox.WordWrap)
                richTextBox.WordWrap = false;
            else
                richTextBox.WordWrap = true;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog()==DialogResult.OK)
            {
                richTextBox.Font = fontDialog1.Font;
                
            }
        }

        private void richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            LinesLabel.Text = "Lines " + richTextBox.Lines.Length;
        }
        int zoomCounter = 1;
        private void zoomIncreaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomCounter++;
            if (zoomCounter >= 1 && zoomCounter < 64)
                richTextBox.ZoomFactor = zoomCounter;
        }

        private void zoomUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zoomCounter--;
            if (zoomCounter >= 1 && zoomCounter < 64)
                richTextBox.ZoomFactor = zoomCounter;
        }
    }
}
