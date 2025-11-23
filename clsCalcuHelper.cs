using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    internal class clsCalcuHelper
    {
        public static double PerformOperation(double num1, double num2, string op)
        {
            double result = 0;

            switch (op)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("Division by zero is not allowed!");
                    }
                    result = num1 / num2;
                    break;
            }

            return result;
        }

        public static void AddToHistory(ListBox lbHistory, double num1, string op, double num2, double result, int maxItems = 100)
        {
            string entry = $"{num1} {op} {num2} = {result}";
            lbHistory.Items.Add(entry);

            if (lbHistory.Items.Count > 0)
            {
                lbHistory.TopIndex = lbHistory.Items.Count - 1;
            }

            if (lbHistory.Items.Count > maxItems)
            {
                lbHistory.Items.RemoveAt(0);
            }
        }

        public static async void ShowToast(Label lblToast ,string M = "Copied successfully")
        {
            lblToast.Text = M;
            lblToast.Visible = true;
            await Task.Delay(4000);
            lblToast.Visible = false;
        }

        public static void SaveHistory(SaveFileDialog saveFileDialog1, ListBox lbHistory, Label lblToast)
        {
            saveFileDialog1.Title = "Save History";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.FileName = "Calculator_History.txt";
            saveFileDialog1.FilterIndex = 1;


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                /*
                string path = saveFileDialog1.FileName;
                if (File.Exists(path))
                {
                DialogResult result = MessageBox.Show
                ("File already exists. Do you want to append to it?\nChoose 'No' to overwrite.",
                "File Exists",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                return;
                }
                bool append = (result == DialogResult.Yes);
                 */
                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine();
                    foreach (var item in lbHistory.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
            ShowToast(lblToast, "File saved successfully ✅");
        }

        public static void HandleShortcut(KeyEventArgs e, Keys mainKey, Button btn,
            bool requireCtrl = false, bool requireShift = false, Keys? alternateKey = null)
        {
            bool ctrlOk = !requireCtrl || (requireCtrl && e.Control);
            bool shiftOk = !requireShift || (requireShift && e.Shift);

            bool mainKeyOk = ctrlOk && shiftOk && e.KeyCode == mainKey;
            bool altKeyOk = alternateKey.HasValue && e.KeyCode == alternateKey.Value && (!e.Control && !e.Shift);

            if (mainKeyOk || altKeyOk)
            {
                btn.PerformClick();
                e.Handled = true;
            }
        }

        public static bool HandleNumbersDotMinus(System.Windows.Forms.TextBox txt, KeyPressEventArgs e, bool allowMinusOnlyAtStart = true)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
                return e.Handled;
            }

            if (e.KeyChar == '.')
            {
                if (txt.Text.Contains(".") || txt.SelectionStart == 0)
                    e.Handled = true;
            }
            else if (e.KeyChar == '-')
            {
                if (allowMinusOnlyAtStart && (txt.Text.Contains("-") || txt.SelectionStart != 0))
                    e.Handled = true;
                else if (!allowMinusOnlyAtStart)
                    e.Handled = true;
            }

            return e.Handled;
        }

    }
}
