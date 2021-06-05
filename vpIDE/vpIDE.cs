using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace vpIDE
{
    public partial class vpIDE : Form
    {
        public vpIDE()
        {
            InitializeComponent();
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == openToolStripButton)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Open a file...";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Clear();
                    FileStream fs = new FileStream(openFile.FileName, FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    StringBuilder sb = new StringBuilder();

                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        sb.Append(Convert.ToChar(br.ReadByte()));
                    }
                    richTextBox1.Text = sb.ToString();

                    br.Close();
                    fs.Close();

                    /*
                    using (StreamReader sr = new StreamReader(openFile.FileName))
                    {
                        richTextBox1.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                    */
                }
            }
            if (e.ClickedItem == saveToolStripButton)
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Title = "Save file as...";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                    txtoutput.Write(richTextBox1.Text);
                    txtoutput.Close();
                }
            }
            if (e.ClickedItem == copyToolStripButton)
            {
                richTextBox1.Copy();
            }
            if (e.ClickedItem == cutToolStripButton)
            {
                richTextBox1.Cut();
            }
            if (e.ClickedItem == pasteToolStripButton)
            {
                richTextBox1.Paste();
            }
            if (e.ClickedItem == undoButton)
            {
                richTextBox1.Undo();
            }
            if (e.ClickedItem == redoButton)
            {
                richTextBox1.Redo();
            }
            if (e.ClickedItem == selectAllButton)
            {
                richTextBox1.SelectAll();
            }
        }
    }
}
