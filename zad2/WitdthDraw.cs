using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zad2
{
    public partial class WitdthDraw : Form
    {
        public static Action<decimal, List<decimal>>? OnWitdhDraw;

        public WitdthDraw()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<decimal> nominal = new List<decimal>();
            List<string> list = checkedListBox1.CheckedItems.Cast<string>().ToList();
            list.Reverse();
            foreach(var check in list)
            {
               nominal.Add(Convert.ToDecimal(check));
            }
            if (!textBox1.Text.All(x => char.IsDigit(x)))
            {
                MessageBox.Show("Неверная сумма вывода!");
                return; 
            }
            OnWitdhDraw?.Invoke(Convert.ToDecimal(textBox1.Text), nominal);
            this.Close();
        }
    }
}
