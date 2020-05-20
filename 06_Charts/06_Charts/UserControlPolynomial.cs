using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_Charts
{
    public partial class UserControlPolynomial : UserControl, IFunction
    {
        /*Label newLable;
        NumericUpDown newNumericUpDown;*/

        public UserControlPolynomial()
        {
            InitializeComponent();
            groupBox1.Text = FunctionName;
        }

        public string FunctionName
        {
            get
            {
                return string.Format("f(x) = {0} * x + {1}", numericUpDownA.Value, numericUpDownB.Value);
            }
        }

        public event emptyFunction FunctionChanged;

        public double Value(double x)
        {
            return (double)(numericUpDownA.Value) * x  + (double)numericUpDownB.Value;
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            groupBox1.Text = FunctionName;
            if(FunctionChanged != null)
            {
                FunctionChanged();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (flowLayoutPanelABC.Controls.Count > (int)numericUpDownN.Value)
            {
                while (flowLayoutPanelABC.Controls.Count > (int)numericUpDownN.Value)
                {
                    flowLayoutPanelABC.Controls.RemoveAt(flowLayoutPanelABC.Controls.Count - 1);
                }
            }
            else if (flowLayoutPanelABC.Controls.Count < (int)numericUpDownN.Value)
            {
                //flowLayoutPanelABC.Controls.Clear();
                int nr = flowLayoutPanelABC.Controls.Count;
                for (int i = flowLayoutPanelABC.Controls.Count; i < (int)numericUpDownN.Value; i++)
                {
                    Panel p = new Panel();
                    Label l = new Label();
                    NumericUpDown n = new NumericUpDown();
                    n.ValueChanged += ValueChanged;



                    l.Text = Convert.ToChar((Convert.ToInt32('A') + (nr++))).ToString();
                    n.Width = 50;
                    n.Location = new Point(70, 0);



                    p.Controls.Add(n);
                    p.Controls.Add(l);



                    p.AutoSize = true;
                    p.AutoSizeMode = AutoSizeMode.GrowAndShrink;



                    flowLayoutPanelABC.Controls.Add(p);
                }
                double y = 0;
                int pot = flowLayoutPanelABC.Controls.Count - 1;
                foreach (Panel p in flowLayoutPanelABC.Controls)
                {
                    y += (double)(p.Controls[0] as NumericUpDown).Value *
                        Math.Pow(x, pot--);
                }
                return y;
            }
        }
    }
}
