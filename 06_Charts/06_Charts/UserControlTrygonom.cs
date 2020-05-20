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
    public partial class UserControlTrygonom : UserControl, IFunction
    {
        public UserControlTrygonom()
        {
            InitializeComponent();
            groupBox1.Text = FunctionName;
        }

        public string FunctionName
        {
            get
            {
                return string.Format("f(x) = {0} * {1} + {2}", numericUpDownA.Value, comboBoxFunc.Text, numericUpDownB.Value);
            }
        }

        public event emptyFunction FunctionChanged;

        public double Value(double x)
        {
            if(comboBoxFunc.Text == "sin")
            {
                return (double)(numericUpDownA.Value) * Math.Sin(x) + (double)numericUpDownB.Value;
            }
            else
            {
                return (double)(numericUpDownA.Value) * Math.Cos(x) + (double)numericUpDownB.Value;
            }
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            groupBox1.Text = FunctionName;
            if (FunctionChanged != null)
            {
                FunctionChanged();
            }
        }

        private void comboBoxFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            FunctionChanged();
            groupBox1.Text = FunctionName;
        }
    }
}
