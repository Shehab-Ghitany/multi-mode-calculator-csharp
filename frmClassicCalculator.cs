using Calculator;
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
    public partial class frmClassicCalculator : Form
    {
        public frmClassicCalculator()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.MinimumSize = new Size(350, 480);
            this.MaximumSize = new Size(500, 480);
        }

        private void frmClassicCalculator_KeyDown(object sender, KeyEventArgs e)
        {

            clsCalcuHelper.HandleShortcut(e, Keys.Escape, btnClearAll);
            clsCalcuHelper.HandleShortcut(e, Keys.C, btnC);
            clsCalcuHelper.HandleShortcut(e, Keys.C, btnCopyResult, true);
            clsCalcuHelper.HandleShortcut(e, Keys.Oemplus, btnPlus, false, true, Keys.Add);
            clsCalcuHelper.HandleShortcut(e, Keys.OemMinus, btnMinus, alternateKey: Keys.Subtract);
            clsCalcuHelper.HandleShortcut(e, Keys.D8, btnMultiply, false, true, Keys.Multiply);
            clsCalcuHelper.HandleShortcut(e, Keys.Divide, btnDivide);

            clsCalcuHelper.HandleShortcut(e, Keys.D0, btnNum0, alternateKey: Keys.NumPad0);
            clsCalcuHelper.HandleShortcut(e, Keys.D1, btnNum1, alternateKey: Keys.NumPad1);
            clsCalcuHelper.HandleShortcut(e, Keys.D2, btnNum2, alternateKey: Keys.NumPad2);
            clsCalcuHelper.HandleShortcut(e, Keys.D3, btnNum3, alternateKey: Keys.NumPad3);
            clsCalcuHelper.HandleShortcut(e, Keys.D4, btnNum4, alternateKey: Keys.NumPad4);
            clsCalcuHelper.HandleShortcut(e, Keys.D5, btnNum5, alternateKey: Keys.NumPad5);
            clsCalcuHelper.HandleShortcut(e, Keys.D6, btnNum6, alternateKey: Keys.NumPad6);
            clsCalcuHelper.HandleShortcut(e, Keys.D7, btnNum7, alternateKey: Keys.NumPad7);
            clsCalcuHelper.HandleShortcut(e, Keys.D8, btnNum8, alternateKey: Keys.NumPad8);
            clsCalcuHelper.HandleShortcut(e, Keys.D9, btnNum9, alternateKey: Keys.NumPad9);

            clsCalcuHelper.HandleShortcut(e, Keys.Back, btnBackspace);
            clsCalcuHelper.HandleShortcut(e, Keys.Enter, btnCalculate);
            clsCalcuHelper.HandleShortcut(e, Keys.Decimal, btnPoint, alternateKey: Keys.OemPeriod);
            clsCalcuHelper.HandleShortcut(e, Keys.F1, btnhelpText);

        }

        private void txtOperation_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

            clsCalcuHelper.HandleNumbersDotMinus(txt, e);

            if (e.KeyChar == '+' || e.KeyChar == '*' || e.KeyChar == '/')
            {
                // Allow operator only if there's no existing operator
                if (txt.Text.Contains("+") || txt.Text.Contains("-") || txt.Text.Contains("*") || txt.Text.Contains("/"))
                {
                    btnPlus.PerformClick();
                    btnMultiply.PerformClick();
                    btnDivide.PerformClick();
                    e.Handled = true;
                }
            }

        }

        string lastOperation = "";
        double? lastResult = null;

        public void Calculate(string operation)
        {
            string input = txtOperation.Text;

            int opIndex = input.IndexOf(operation, 1);
            if (opIndex == -1)
            {
                lblResult.Text = "Invalid input";
                return;
            }

            string firstPart = input.Substring(0, opIndex);
            string secondPart = input.Substring(opIndex + 1);

            double num1, num2;

            if (lastResult.HasValue && operation == lastOperation)
            {
                num1 = lastResult.Value;
                if (!double.TryParse(secondPart.Trim(), out num2))
                {
                    lblResult.Text = "Invalid input";
                    return;
                }
            }
            else
            {
                if (!double.TryParse(firstPart.Trim(), out num1) ||
                    !double.TryParse(secondPart.Trim(), out num2))
                {
                    lblResult.Text = "Invalid input";
                    return;
                }
            }

            double result = 0;

            result = clsCalcuHelper.PerformOperation(num1, num2, operation);

            lblResult.Text = result.ToString();
            lastResult = result;
            lastOperation = operation;

            txtOperation.Text = num1 + operation + secondPart;

            clsCalcuHelper.AddToHistory(lbHistory, num1, operation, num2, result);
        }

        string currentOperator = "";
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Calculate(currentOperator);
        }

        private void btnNumClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            //if (btn != null && btn.Tag != null)
            txtOperation.Text += btn.Tag.ToString();
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string op = btn.Tag?.ToString();

            if (string.IsNullOrEmpty(op)) return;

            if (!string.IsNullOrEmpty(currentOperator))
                return;

            txtOperation.Text += op;
            currentOperator = op;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            string text = txtOperation.Text;

            if (string.IsNullOrEmpty(text))
            {
                txtOperation.Text = "-";
                return;
            }

            if (text.EndsWith("-"))
                return;

            if (!string.IsNullOrEmpty(currentOperator))
                return;

            txtOperation.Text += "-";
            currentOperator = "-";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            string lastNumber = txtOperation.Text;
            int lastOpIndex = Math.Max(
                Math.Max(lastNumber.LastIndexOf('+'), lastNumber.LastIndexOf('-')),
                Math.Max(lastNumber.LastIndexOf('*'), lastNumber.LastIndexOf('/'))
            );

            if (lastOpIndex != -1)
            {
                lastNumber = lastNumber.Substring(lastOpIndex + 1);
            }

            if (lastNumber.Contains("."))
                return;

            txtOperation.Text += ".";

        }

        private void btnCopyResult_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblResult.Text);
            lblResult.Select();

            clsCalcuHelper.ShowToast(lblToast);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtOperation.Clear();
            currentOperator = "";
            lastOperation = "";
            lastResult = null;
            txtOperation.Focus();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtOperation.Clear();
            lblResult.Text = "0";
            currentOperator = "";
            lastOperation = "";
            lastResult = null;
            txtOperation.Focus();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtOperation.Text.Length > 0)
            {
                char lastChar = txtOperation.Text[txtOperation.Text.Length - 1];
                if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                {
                    currentOperator = "";
                }

                txtOperation.Text = txtOperation.Text.Substring(0, txtOperation.Text.Length - 1);
            }
        }

        bool isExpanded = false;
        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            if (!isExpanded)
            {
                this.Size = this.MaximumSize;
                isExpanded = true;

                //lstHistory.Visible = true;
            }
            else
            {
                this.Size = this.MinimumSize;
                isExpanded = false;

                //lstHistory.Visible = false;
            }

        }

        private void lbHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbHistory.SelectedItem == null) return;

            string entry = lbHistory.SelectedItem.ToString();
            var parts = entry.Split(' ');
            txtOperation.Text = parts[0];
            txtOperation.Text += parts[1];
            txtOperation.Text += parts[2];
            lblResult.Text = parts[4];

            lastOperation = parts[1];
            lastResult = Convert.ToDouble(parts[0]);
            currentOperator = parts[1];

            Clipboard.SetText(entry);

            clsCalcuHelper.ShowToast(lblToast);
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
                        if (ctrl == btnCalculate)
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
                        if (ctrl == btnDarkMode || ctrl == btnShowHistory || ctrl == btnCopyResult)
                        {
                            ctrl.BackColor = SystemColors.InactiveCaption;
                            continue;
                        }
                        if (ctrl == btnBackspace || ctrl == btnC || ctrl == btnDarkMode)
                        {
                            ctrl.BackColor = SystemColors.ControlLight;
                            continue;
                        }
                        if (ctrl == btnCalculate)
                        {
                            btnCalculate.ForeColor = Color.White;
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
            string helpText = @"Classic Calculator Instructions:

Keyboard Shortcuts:
- Escape  : Clear All
- C       : Clear Entry
- Ctrl + C: Copy Result
- Enter   : Calculate
- NumPad 0-9 / Top Row 0-9: Enter Numbers
  + - * / : Operations - from NumPad or Top Row
- Backspace: Delete last digit

Features:
- History: Click an entry to reuse or copy
- Dark/Light Mode: Toggle colors
- Expand/Collapse History: Toggle history panel

Tips:
- Only one operator allowed per calculation.
- Continue calculations from last result using same operator.
- Use decimal point for fractional numbers.";

            MessageBox.Show(helpText, "Help - Classic Calculator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
