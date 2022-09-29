namespace Hw4
{
    internal class BigMoneyFetchedArgs
    {
        public double Money { get; }
        public BigMoneyFetchedArgs(double money)
        {
            Money = money;
        }
    }

    delegate void BigMoneyFetchedHandler(object sender, BigMoneyFetchedArgs args);
}
