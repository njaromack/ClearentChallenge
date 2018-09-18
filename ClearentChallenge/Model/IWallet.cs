using System.Collections.Generic;

namespace ClearentChallenge.Model
{
    public interface IWallet:IInterestable
    {
        List<ICreditCard> CreditCards { get; }
        bool AddCreditCard(ICreditCard creditCard);
    }
}
