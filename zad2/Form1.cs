using System.Collections;

namespace zad2
{
    public partial class Form1 : Form
    {
        Bank bank = new Bank();
        public Form1()
        {
            InitializeComponent();
            Bank.OnChangeBalance += ChangeBalance;
            Bank.OnChangeAmount += AmoutMoneys;
        }

        private void ChangeBalance(decimal balance) 
        {
            label2.Text = balance.ToString() + " Рублей";
        }

        private void AmoutMoneys()
        {
            listBox1.Items.Clear();
            foreach(var item in bank.nominalsCounter) 
            {
                listBox1.Items.Add($"{item.Key} P - {item.Value} к.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PutMoney form= new PutMoney();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WitdthDraw witdthDraw = new WitdthDraw();
            witdthDraw.Show();
        }
    }
}