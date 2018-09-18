namespace ClearentChallenge.Model
{
    public class VisaCard : CreditCard
    {
        public override decimal InterestRate => 10.0m;

        public VisaCard(decimal initialBalance=0) : base(initialBalance) { }
    }
}
