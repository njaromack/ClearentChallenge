namespace ClearentChallenge.Business
{
    public interface IInterestCalculator
    {
        decimal CalculateInterest(decimal principal, decimal interestRate);
    }
}
