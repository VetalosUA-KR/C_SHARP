using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_saper
{
    public partial class FormMainWindow : Form
    {
        public FormMainWindow()
        {
            InitializeComponent();
        }

        private void prostaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button b = new Button();

            b.Location = new Point(50, 50);
            b.Size = new Size(100, 100);
            b.Text = "Dynamiczny button";

            b.Click += B_Click;

            this.Controls.Add(b);
        }

        private void B_Click(object sender, EventArgs e)
        {
            Button b;
            if(sender is Button)
            {
                b = sender as Button;
                b.Text = "Po kliku";
            }
            
            
        }
    }
}
