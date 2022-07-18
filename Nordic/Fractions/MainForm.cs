using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractions
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            int an = int.Parse(textNumerator1.Text);
            int ad = int.Parse(textDenominator1.Text);
            int bn = int.Parse(textNumerator2.Text);
            int bd = int.Parse(textDenominator2.Text);
            var a = new Fraction(an, ad);
            var b = new Fraction(bn, bd);           
            Fraction summa = a + b;
            textNumerator.Text = summa.Numerator.ToString();
            textDenominator.Text = summa.Denominator.ToString();
        }
    }
}
