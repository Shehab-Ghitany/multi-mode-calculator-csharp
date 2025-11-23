using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Launcher_Form : Form
    {
        public Launcher_Form()
        {
            InitializeComponent();
        }

        private void btnTextMode_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmTextCalculator TextCalc1 = new frmTextCalculator();
            TextCalc1.ShowDialog();
            this.Show();
        }

        private void btnClassicMode_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmClassicCalculator ClassicCalc1 = new frmClassicCalculator();
            ClassicCalc1.ShowDialog();
            this.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (frmAbout about = new frmAbout())
            {
                about.ShowDialog();
            }
        }
    }
}
