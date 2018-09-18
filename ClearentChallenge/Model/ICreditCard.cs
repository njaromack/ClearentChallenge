namespace ClearentChallenge.Model
{
    public interface ICreditCard:IInterestable
    {
        decimal InterestRate { get; }
        decimal Balance { get; }
    }
}
