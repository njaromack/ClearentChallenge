using ClearentChallenge.Business;
using System;

namespace ClearentChallenge.Model
{
    public abstract class CreditCard : ICreditCard
    {
        public abstract decimal InterestRate { get; }
        public decimal Balance { get; private set; }

        public IInterestCalculator InterestCalculator { get; set; }

        // default to SimpleInterestCalculator if not provided
        public CreditCard(decimal initialBalance=0):this(new SimpleInterestCalculator(), initialBalance) { }

        public CreditCard(IInterestCalculator interestCalculator, decimal initialBalance=0)
        {
            Balance = initialBalance;
            InterestCalculator = interestCalculator;
        }

        public decimal CalculateInterest()
        {
            try
            {
                return InterestCalculator.CalculateInterest(Balance, InterestRate);
            }
            catch(Exception exception)
            {
                // TODO: next steps - would not normally rethrow an exception with a message wrapper
                // need system behavior to be defined, i.e. log something / raise an alert / 
                // could make this a "TryCalculateInterest" method or a nullable return type
                throw new Exception("What should we do here?", exception);
            }
        }
    }
}
