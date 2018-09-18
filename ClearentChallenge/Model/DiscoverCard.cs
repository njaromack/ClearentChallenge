namespace ClearentChallenge.Model
{
    public class DiscoverCard : CreditCard
    {
        public override decimal InterestRate => 1.0m;

        public DiscoverCard(decimal initialBalance=0) : base(initialBalance) {}
    }
}
