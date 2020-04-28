using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notatnik
{
    public partial class FormMainWindow : Form
    {
        private FormConfig configDialog = new FormConfig();
        private FormReplace replaceDialog = new FormReplace();
        private string currentFailName = "";
        public FormMainWindow()
        {
            InitializeComponent();
        }

        private void zamkniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                textBoxEditor.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                currentFailName = openFileDialog.FileName;
                this.Text = Path.GetFileNameWithoutExtension(currentFailName);

            }

        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (currentFailName != "")
            {
                File.WriteAllText(currentFailName, textBoxEditor.Text);
            }
            else
            {
                zapiszJakoToolStripMenuItem_Click(null, null);
            }
        }
        

        private void nowyDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxEditor.Text = "";
            currentFailName = "";
            this.Text = "";
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFailName = saveFileDialog.FileName;
                this.Text = Path.GetFileNameWithoutExtension(currentFailName);
                File.WriteAllText(currentFailName, textBoxEditor.Text);
            }
        }

        private void configuracjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configDialog.configBackColor = textBoxEditor.BackColor;
            configDialog.configForeColor = textBoxEditor.ForeColor;
            configDialog.configFont = textBoxEditor.Font;

            if (configDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxEditor.BackColor = configDialog.configBackColor;
                textBoxEditor.ForeColor = configDialog.configForeColor;
                textBoxEditor.Font = configDialog.configFont;
            }
        }

        private void zamienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (replaceDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxEditor.Text = textBoxEditor.Text.Replace(replaceDialog.currentString, replaceDialog.targetString);
            }
        }
    }
}
