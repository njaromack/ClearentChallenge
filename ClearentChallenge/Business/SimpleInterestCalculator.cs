using System;

namespace ClearentChallenge.Business
{
    public class SimpleInterestCalculator : IInterestCalculator
    {
        public decimal CalculateInterest(decimal principal, decimal interestRate)
        {
            var calculatedInterest = 0.00m;

            try
            {
                // ASSUMPTION: if the balance is negative, don't allow to "earn" interest
                if (principal > 0)
                {
                    calculatedInterest = principal * (interestRate / 100);
                    // TODO: next steps - what rounding rule (if any) to use?
                }            
            }
            catch (OverflowException overflowException)
            {
                // TODO: next steps - would not normally rethrow an exception with a message wrapper
                // need system behavior to be defined, i.e. log something / raise an alert / etc
                // could make this a "TryCalculateInterest" method or a nullable return type
                throw new OverflowException("What should we do here?", overflowException);
            }

            return calculatedInterest;
        }
    }
}
