namespace ClearentChallenge.Model
{
    public class MasterCard : CreditCard
    {
        public override decimal InterestRate => 5.0m;

        public MasterCard(decimal initialBalance=0) : base(initialBalance) { }
    }
}
