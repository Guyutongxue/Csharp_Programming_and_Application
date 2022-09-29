namespace Hw4
{
    internal class ATM
    {
        readonly Bank bank;
        public ATM(Bank bank)
        {
            this.bank = bank;
        }

        public event BigMoneyFetchedHandler? BigMoneyFetched;

        public void Transaction()
        {
            Show("Please insert your card");
            string id = GetInput();

            Show("Please enter your password");
            string pwd = GetInput();

            Account? account = bank[id](pwd);

            if (account == null)
            {
                Show("card invalid or password not corrent");
                return;
            }

            switch (AskOperation())
            {

                case Operation.Display:
                    {
                        Show("balance: " + account.Money);
                        break;
                    }
                case Operation.Save:
                    {
                        Show("save money");
                        double money = double.Parse(GetInput());

                        bool ok = account.SaveMoney(money);
                        if (new Random(Guid.NewGuid().GetHashCode()).NextDouble() > 0.8)
                        {
                            throw new BadCashException();
                        }
                        if (ok) Show("ok");
                        else Show("eeer");

                        Show("balance: " + account.Money);
                        break;
                    }
                case Operation.Withdraw:
                    {
                        Show("withdraw money");
                        double money = double.Parse(GetInput());

                        bool ok = account.WithdrawMoney(money);
                        if (ok) Show("ok");
                        else Show("eeer");

                        if (money > 1000)
                        {
                            BigMoneyFetched?.Invoke(this, new BigMoneyFetchedArgs(money));
                        }

                        Show("balance: " + account.Money);
                        break;
                    }
            }
        }


        static void Show(string msg)
        {
            Console.WriteLine(msg);
        }
        static string GetInput()
        {
            return Console.ReadLine() ?? throw new InvalidDataException();
        }

        // 枚举
        enum Operation { Display, Save, Withdraw };

        static Operation AskOperation()
        {
            Show("1: display; 2: save; 3: withdraw");
            var choice = int.Parse(GetInput());
            switch (choice)
            {
                case 1: return Operation.Display;
                case 2: return Operation.Save;
                case 3: return Operation.Withdraw;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
