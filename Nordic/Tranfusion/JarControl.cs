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

        /// <summary>
        /// Высота кувшина в условных единицах
        /// </summary>
        private int size;

        public int Level
        {
            set
            {
                level.Top = (size - value) * HeightRatio;
                level.Height = value * HeightRatio;
                text.Text = value.ToString();
            }
        }

        public JarControl(int size = 5)
        {
            InitializeComponent();

            this.size = size;
            jar.Height = HeightRatio * size;
            Level = 1;
            AutoSize = true;
        }
    }
}
