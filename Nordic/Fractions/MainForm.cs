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

        private void buttonOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            int aN = textNumber1.Text.ToInt();
            int an = textNumerator1.Text.ToInt();
            int ad = textDenominator1.Text.ToInt();

            int bN = textNumber2.Text.ToInt();
            int bn = textNumerator2.Text.ToInt();
            int bd = textDenominator2.Text.ToInt();

            var a = new Fraction(aN, an, ad);
            var b = new Fraction(bN, bn, bd);

            Fraction summa;
            switch (button.Text)
            {
                case "+": summa = a + b; break;
                case "-": summa = a - b; break;
                case "*": summa = a * b; break;
                case "/": summa = a / b; break;
                default: summa = new Fraction(0, 0); break;
            }


            textNumber.Text = summa.Number.ToString();

            // Показываем дробную часть, если она есть (числитель ненулевой)
            bool visible = summa.Numerator !=0;
            textNumerator.Visible = visible;
            textDenominator.Visible = visible;
            textNumerator.Text = summa.Numerator.ToString();
            textDenominator.Text = summa.Denominator.ToString();
        }
    }
}
