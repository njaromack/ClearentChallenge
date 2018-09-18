using System;
using System.Collections.Generic;

namespace ClearentChallenge.Model
{
    public class Wallet : IWallet
    {
        public List<ICreditCard> CreditCards { get; private set; }

        public Wallet()
        {
            CreditCards = new List<ICreditCard>();
        }

        public bool AddCreditCard(ICreditCard creditCard)
        {
            var creditCardAdded = false;

            // TODO: any other credit card validation
            if (creditCard != null)
            {
                if (CreditCards == null)
                {
                    CreditCards = new List<ICreditCard>();
                }

                CreditCards.Add(creditCard);
                creditCardAdded = true;
            }
            return creditCardAdded;
        }

        public decimal CalculateInterest()
        {
            decimal totalInterest = 0;
            if (CreditCards != null)
            {
                foreach(var creditCard in CreditCards)
                {
                    try
                    {
                        totalInterest += creditCard.CalculateInterest();
                    }
                    catch (Exception exception)
                    {
                        // TODO: next steps - would not normally rethrow an exception with a message wrapper
                        // need system behavior to be defined, i.e. log something / raise an alert / 
                        // could make this a "TryCalculateInterest" method or a nullable return type
                        throw new Exception("What should we do here?", exception);
                    }                    
                }
            }
            return totalInterest;
        }
    }
}
