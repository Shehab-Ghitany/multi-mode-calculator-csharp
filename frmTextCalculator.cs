using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator
{
    public partial class frmTextCalculator : Form
    {
        public frmTextCalculator()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.MinimumSize = new Size(500, 400);
            this.MaximumSize = new Size(950, 495);
        }

        private void frmTextCalculator_KeyDown(object sender, KeyEventArgs e)
        {

            clsCalcuHelper.HandleShortcut(e, Keys.Escape, btnClearAll);
            clsCalcuHelper.HandleShortcut(e, Keys.C, btnCopyResult, true);
            clsCalcuHelper.HandleShortcut(e, Keys.Oemplus, btnPlus, false, true, Keys.Add);
            clsCalcuHelper.HandleShortcut(e, Keys.OemMinus, btnMinus, alternateKey: Keys.Subtract);
            clsCalcuHelper.HandleShortcut(e, Keys.D8, btnMultiply, false, true, Keys.Multiply);
            clsCalcuHelper.HandleShortcut(e, Keys.Divide, btnDivide);
            clsCalcuHelper.HandleShortcut(e, Keys.F1, btnhelpText);

        }

        private void NumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;
            
            clsCalcuHelper.HandleNumbersDotMinus(txt, e);
        }

        private bool ClearedTexts()
        {
            if (string.IsNullOrWhiteSpace(txtNum1.Text) || string.IsNullOrWhiteSpace(txtNum2.Text))
            {
                return true;
            }
            return false;
        }

        private void Continuous()
        {
            double? temp = null;

            if (txtResult.Text != "")
            {
                temp = Convert.ToDouble(txtResult.Text);
            }

            if (temp != null)
            {
                txtNum1.Text = temp.ToString();
            }
        }

        private void Calculate(string operation)
        {
            if (ClearedTexts())
                return;

            Continuous();

            double num1 = Convert.ToDouble(txtNum1.Text);
            double num2 = Convert.ToDouble(txtNum2.Text);
            double result = 0;

            result = clsCalcuHelper.PerformOperation(num1, num2, operation);

            txtResult.Text = result.ToString();

            clsCalcuHelper.AddToHistory(lbHistory, num1, operation, num2, result);
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;

            string op = btn.Tag?.ToString();

            Calculate(op);
        }
        
        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtResult.Text))
                return;

            Clipboard.SetText(txtResult.Text);

            txtResult.Focus();
            txtResult.SelectAll();

            clsCalcuHelper.ShowToast(lblToast);
        }
  
        private void txtNum1_TextChanged(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtNum1.Clear();
            txtNum2.Clear();
            txtResult.Clear();

            txtNum1.Focus();
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            lbHistory.Items.Clear();
        }

        private void lbHistory_Click(object sender, EventArgs e)
        {
            if (lbHistory.SelectedItem == null) return;

            string entry = lbHistory.SelectedItem.ToString();
            var parts = entry.Split(' ');
            txtNum1.Text = parts[0];
            txtNum2.Text = parts[2];
            txtResult.Text = parts[4];

            Clipboard.SetText(entry);

            clsCalcuHelper.ShowToast(lblToast);
        }

        private void btnSaveHistory_Click(object sender, EventArgs e)
        {
            clsCalcuHelper.SaveHistory(saveFileDialog1, lbHistory, lblToast);
        }

        bool dark_light = false;
        private void btnDarkMode_Click(object sender, EventArgs e)
        {
            if (dark_light == false)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                foreach (Control ctrl in this.Controls)
                {
                    ctrl.ForeColor = Color.White;
                    if (ctrl is System.Windows.Forms.TextBox)
                    {
                        ctrl.BackColor = Color.FromArgb(30, 30, 30);
                    }
                    if (ctrl is System.Windows.Forms.Button)
                    {
                        if (ctrl == btnClearAll)
                        {
                            continue;
                        }
                        ctrl.BackColor = Color.FromArgb(30, 30, 30);
                    }
                }
                lbHistory.BackColor = Color.FromArgb(30, 30, 30);
                btnDarkMode.BackColor = Color.FromArgb(119, 92, 94);
                dark_light = true;
            }
            else
            {
                this.BackColor = SystemColors.InactiveCaption;
                foreach (Control ctrl in this.Controls)
                {
                    ctrl.ForeColor = Color.Black;
                    if (ctrl is System.Windows.Forms.TextBox)
                    {
                        ctrl.BackColor = Color.White;
                    }
                    if (ctrl is System.Windows.Forms.Button)
                    {
                        if (ctrl == btnClearAll)
                        {
                            continue;
                        }
                        if (ctrl == btnDarkMode)
                        {
                            ctrl.BackColor = SystemColors.InactiveCaption;
                            continue;
                        }
                        if (ctrl == btnClearHistory || ctrl == btnSaveHistory || ctrl == btnDarkMode || ctrl == btnCopyResult)
                        {
                            ctrl.BackColor = SystemColors.ControlLight;
                            continue;
                        }
                        
                        ctrl.BackColor = SystemColors.ActiveCaption;
                    }

                    lbHistory.BackColor = Color.White;

                }
                dark_light = false;
            }
        }

        private void btnhelpText_Click(object sender, EventArgs e)
        {
            string helpText = @"Calculator Instructions:

Keyboard Shortcuts:
- Ctrl + C : Copy Result
- Enter    : Calculate
- Escape   : Clear All
- NumPad 0-9 / Top Row 0-9 : Enter Numbers
  + - * /  : Operations - from NumPad or Top Row

Features:
- History: Click an entry to reuse or copy
- Dark/Light Mode: Toggle colors
- Save History: Save all past calculations to a file

Tips:
- Press an operation again to continue calculating using the last result.
- Use Backspace to remove the last character in input.";

            MessageBox.Show(helpText, "Help - Text Calculator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
