using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tranfusion
{
    public partial class JarControl : UserControl
    {
        public const int HeightRatio = 50;

        public JarControl(int size = 5)
        {
            InitializeComponent();

            panel.Height = HeightRatio * size;
            AutoSize = true;
        }
    }
}
