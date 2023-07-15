

namespace zad2
{
    public partial class PutMoney : Form
    {

        public static Action<Dictionary<decimal, int>>? OnPutMoney;

        public PutMoney()
        {
            InitializeComponent();
        }

         

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<decimal, int> nominals = new Dictionary<decimal, int>
            {
                { 10, Convert.ToInt32(textBox1.Text.All(x => char.IsDigit(x)) ? textBox1.Text : -1 ) },
                { 50, Convert.ToInt32(textBox2.Text.All(x => char.IsDigit(x)) ? textBox2.Text : -1 ) },
                { 100, Convert.ToInt32(textBox3.Text.All(x => char.IsDigit(x)) ? textBox3.Text : -1) },
                { 500, Convert.ToInt32(textBox4.Text.All(x => char.IsDigit(x)) ? textBox6.Text : -1) },
                { 1000, Convert.ToInt32(textBox5.Text.All(x => char.IsDigit(x)) ? textBox4.Text : -1) },
                { 5000, Convert.ToInt32(textBox5.Text.All(x => char.IsDigit(x)) ? textBox5.Text : -1) }
            };
            if (!nominals.All(x => x.Value != -1))
            {
                MessageBox.Show("Некорекктный ввод значений!");
                return;
            }
            OnPutMoney?.Invoke(nominals);
            this.Close();
        }
    }
}
