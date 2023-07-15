

namespace zad2
{
    public class Bank
    {


        public static Action<decimal>? OnChangeBalance;

        public static Action? OnChangeAmount;

        private decimal balance;

        public Dictionary<decimal, int> nominalsCounter = new Dictionary<decimal, int>();

        decimal Balance { get { return balance; } set { balance = value; OnChangeBalance?.Invoke(balance); } }

        public Bank()
        {
            nominalsCounter.Add(10, 0);
            nominalsCounter.Add(50, 0);
            nominalsCounter.Add(100, 0);
            nominalsCounter.Add(500, 0);
            nominalsCounter.Add(1000, 0);
            nominalsCounter.Add(5000, 0);
            PutMoney.OnPutMoney += putMoney;
            WitdthDraw.OnWitdhDraw += widthdraw;
        }
        ~Bank()
        {
            PutMoney.OnPutMoney -= putMoney;
        }

        public void widthdraw(decimal amount, List<decimal> listnominal)
        {
            decimal sum = amount;
            Dictionary<decimal, int> counterNominal = new Dictionary<decimal, int>();
            counterNominal = nominalsCounter;
            if (listnominal.Count == 0)
            {
                foreach (var nom in nominalsCounter.Reverse())
                {
                    listnominal.Add(nom.Key);
                }
            }
            foreach (var nominal in listnominal)
            {
                int counter = 0;
                counter = (int)amount / (int)nominal;
                amount -= counter * (int)nominal;
                if (counterNominal[nominal] - counter >= 0)
                    counterNominal[nominal] -= counter;
                else
                {
                    MessageBox.Show("Не хватает купюр выбранных номиналов для вывода средств");
                    return;
                }
            }

            if (amount == 0)
            {
                Balance -= sum;
                nominalsCounter = counterNominal;
                OnChangeAmount?.Invoke();
            }
            else
                MessageBox.Show("Не хватает купюр выбранных номиналов для вывода средств");


            return;


        }
        public void putMoney(Dictionary<decimal, int> moneys)
        {
            foreach (var mon in moneys)
            {
                nominalsCounter[mon.Key] += mon.Value;
                Balance += mon.Key * mon.Value;
            }
            OnChangeAmount?.Invoke();
        }
    }
}
