using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notatnik
{
    public partial class FormConfig : Form
    {
        //public Color configBackColor;
        public FormConfig()
        {
            InitializeComponent();
        }

        public Color configBackColor
        {
            get
            {
                return buttonBackColor.BackColor;
            }
            set
            {
                buttonBackColor.BackColor = value;
                buttonFont.BackColor = value;
            }
        }

        public Color configForeColor
        {
            get
            {
                return buttonForeColor.BackColor;
            }
            set
            {
                buttonForeColor.BackColor = value;
                buttonFont.ForeColor = value;
            }
        }

        public Font configFont
        {
            get
            {
                return buttonFont.Font;
            }
            set
            {
                buttonFont.Font = value;
            }
        }

        private void buttonBackColor_Click(object sender, EventArgs e)
        {
            if(colorDialogBack.ShowDialog() == DialogResult.OK)
            {
                configBackColor = colorDialogBack.Color;
            }
        }
        private void buttonForeColor_Click(object sender, EventArgs e)
        {
            if(colorDialogFore.ShowDialog() == DialogResult.OK)
            {
                configForeColor = colorDialogFore.Color;
            }
        }
        private void buttonFont_Click(object sender, EventArgs e)
        {
            if(fontDialog.ShowDialog() == DialogResult.OK)
            {
                configFont = fontDialog.Font;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        
    }
}
