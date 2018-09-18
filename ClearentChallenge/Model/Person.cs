using System;
using System.Collections.Generic;

namespace ClearentChallenge.Model
{
    public class Person : IPerson
    {
        public List<IWallet> Wallets { get; private set; }

        public Person()
        {
            Wallets = new List<IWallet>();
        }

        public bool AddWallet(IWallet wallet)
        {
            var walletAdded = false;

            // TODO: any other wallet validation
            if (wallet != null)
            {
                if (Wallets == null)
                {
                    Wallets = new List<IWallet>();
                }

                Wallets.Add(wallet);
                walletAdded = true;
            }
            return walletAdded;
        }

        public decimal CalculateInterest()
        {
            decimal totalInterest = 0;
            if (Wallets != null)
            {
                foreach(var wallet in Wallets)
                {
                    try
                    {
                        totalInterest += wallet.CalculateInterest();
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
