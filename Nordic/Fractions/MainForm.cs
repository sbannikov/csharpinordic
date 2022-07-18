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
            int aN = textNumber1.Text.ToInt();
            int an = textNumerator1.Text.ToInt();
            int ad = textDenominator1.Text.ToInt();

            int bN = textNumber2.Text.ToInt();
            int bn = textNumerator2.Text.ToInt();
            int bd = textDenominator2.Text.ToInt();

            var a = new Fraction(an, ad);
            var b = new Fraction(bn, bd);

            Fraction summa = a + b;
            summa += aN;
            summa += bN;

            textNumber.Text = summa.Number.ToString();
            if (summa.Numerator != 0)
            {
                textNumerator.Visible = true;
                textDenominator.Visible = true;
                textNumerator.Text = summa.Numerator.ToString();
                textDenominator.Text = summa.Denominator.ToString();
            }
            else
            {
                textNumerator.Visible = false;
                textDenominator.Visible = false;
            }
        }
    }
}
