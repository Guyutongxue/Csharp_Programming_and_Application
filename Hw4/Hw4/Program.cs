// 顶级语句
using Hw4;

var bank = new Bank();
bank.OpenAccount("2222", "2222", 20, 20);
bank.OpenAccount("3333", "3333", 1020);
var atm = new ATM(bank);

// Lambda 表达式
atm.BigMoneyFetched += (obj, args) =>
{
    Console.WriteLine($"BIG MONEY FETCHED: {args.Money}");
};

try
{
    for (var i = 0; i < 5; i++)
    {
        atm.Transaction();
    }

} catch (BadCashException e)
{
    Console.WriteLine($"{e}");
}