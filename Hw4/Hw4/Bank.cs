namespace Hw4
{
    internal class Bank
    {
        // 简化 new
        readonly List<Account> accounts = new();

        // 可空值类型
        public Account OpenAccount(string id, string pwd, double money, double? credit = null)
        {
            Account account;
            if (credit is double creditV)
            {
                account = new CreditAccount(id, pwd, money, creditV);
            }
            else
            {
                account = new Account(id, pwd, money);
            }
            accounts.Add(account);
            return account;
        }

        public bool CloseAccount(Account account)
        {
            int idx = accounts.IndexOf(account);
            if (idx < 0) return false;
            accounts.Remove(account);
            return true;
        }

        // 索引器
        public Func<string, Account?> this[string id]
        {
            get
            {
                return (string pwd) => FindAccount(id, pwd);
            }
        }

        // 可空引用类型标注
        private Account? FindAccount(string id, string pwd)
        {
            foreach (var account in accounts)
            {
                if (account.IsMatch(id, pwd))
                {
                    return account;
                }
            }
            return null;
        }
    }

}
