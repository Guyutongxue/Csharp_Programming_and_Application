namespace Hw3
{
    internal class Account
    {
        // 属性
        protected double money;
        public virtual double Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Negative money is unacceptable.");
                }
                money = value;
            }
        }
        // 自动属性
        public string Id { get; set; }
        public string Pwd { get; set; }

        public Account(string id, string pwd, double money)
        {
            Id = id;
            Pwd = pwd;
            Money = money;
        }

        public bool SaveMoney(double money)
        {
            if (money < 0) return false;

            Money += money;
            return true;
        }

        public bool WithdrawMoney(double money)
        {
            try
            {
                Money -= money;
                return true;
            } catch
            {
                return false;
            }
        }

        public bool IsMatch(string id, string pwd)
        {
            return id == Id && pwd == Pwd;
        }
    }

    // 继承
    internal class CreditAccount: Account
    {
        double Credit { get; set; }

        public CreditAccount(string id, string pwd, double money, double credit) : 
            base(id, pwd, money) {
            Credit = credit;
        }


        // 重写属性
        public override double Money
        {
            get { return money; }
            set
            {
                if (money < Credit)
                {
                    throw new ArgumentException("Out of credits");
                }
                money = value;
            }
        }
    }
}
