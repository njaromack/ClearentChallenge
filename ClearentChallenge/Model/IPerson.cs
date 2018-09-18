using System.Collections.Generic;

namespace ClearentChallenge.Model
{
    public interface IPerson:IInterestable
    {
        List<IWallet> Wallets { get; }
        bool AddWallet(IWallet wallet);
    }
}
