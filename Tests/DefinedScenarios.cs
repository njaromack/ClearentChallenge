using ClearentChallenge.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DefinedScenarios
    {
        /// <summary>
        /// 1 person has 1 wallet and 3 cards (1 Visa, 1 MC 1 Discover) - Each Card has a balance of $100 -
        /// calculate the total interest (simple intereset) for this person and per card
        /// </summary>
        [TestMethod]
        public void ScenarioOne()
        {
            // arrange
            var person = new Person();
            var wallet = new Wallet();
            var visaCard = new VisaCard(100);
            var masterCard = new MasterCard(100);
            var discoverCard = new DiscoverCard(100);

            // act
            if (person.AddWallet(wallet))
            {
                wallet.AddCreditCard(visaCard);
                wallet.AddCreditCard(masterCard);
                wallet.AddCreditCard(discoverCard);
            }

            // assert
            Assert.AreEqual(16.00m, person.CalculateInterest());
            Assert.AreEqual(10.00m, visaCard.CalculateInterest());
            Assert.AreEqual(5.00m, masterCard.CalculateInterest());
            Assert.AreEqual(1.00m, discoverCard.CalculateInterest());
        }

        /// <summary>
        /// 1 person has 2 wallets Wallet 1 has a Visa and Discover, wallet 2 a MC - each card has $100 balance - 
        /// calculate the total interest (simple interest) for this person and interest per wallet
        /// </summary>
        [TestMethod]
        public void ScenarioTwo()
        {
            // arrange
            var person = new Person();
            var wallet1 = new Wallet();
            var wallet2 = new Wallet();
            var visaCard = new VisaCard(100);
            var discoverCard = new DiscoverCard(100);
            var masterCard = new MasterCard(100);

            // act
            if (person.AddWallet(wallet1))
            {
                wallet1.AddCreditCard(visaCard);
                wallet1.AddCreditCard(discoverCard);
            }

            if (person.AddWallet(wallet2))
            {
                wallet2.AddCreditCard(masterCard);
            }

            // assert
            Assert.AreEqual(16.00m, person.CalculateInterest());
            Assert.AreEqual(11.00m, wallet1.CalculateInterest());
            Assert.AreEqual(5.00m, wallet2.CalculateInterest());            
        }

        /// <summary>
        /// 2 people have 1 wallet each, person 1 has 1 wallet, with 2 cards MC and visa
        /// person 2 has 1 wallet - 1 visa and 1 MC - each card has $100 balance - 
        /// calculate the total interest (simple interest) for each person and interest per wallet
        /// </summary>
        [TestMethod]
        public void ScenarioThreeA()
        {
            // arrange
            var person1 = new Person();
            // TODO: some ambiguity around person 1, "2 cards MC and visa"
            // is it 2 cards total (1 MC and 1 Visa) <- testing this one
            // or is it 2 MC + 1 Visa
            // or is it 2 MC + 2 Visa
            var person2 = new Person();
            var wallet1 = new Wallet();
            var wallet2 = new Wallet();
            var visaCard = new VisaCard(100);
            var masterCard = new MasterCard(100);

            // act
            if (person1.AddWallet(wallet1))
            {
                wallet1.AddCreditCard(masterCard);
                wallet1.AddCreditCard(visaCard);                
            }

            if (person2.AddWallet(wallet2))
            {
                wallet2.AddCreditCard(masterCard);
                wallet2.AddCreditCard(visaCard);                
            }

            // assert
            Assert.AreEqual(15.00m, person1.CalculateInterest());
            Assert.AreEqual(15.00m, person2.CalculateInterest());
            Assert.AreEqual(15.00m, wallet1.CalculateInterest());
            Assert.AreEqual(15.00m, wallet2.CalculateInterest());            
        }

        /// <summary>
        /// 2 people have 1 wallet each, person 1 has 1 wallet, with 2 cards MC and visa
        /// person 2 has 1 wallet - 1 visa and 1 MC - each card has $100 balance - 
        /// calculate the total interest (simple interest) for each person and interest per wallet
        /// </summary>
        [TestMethod]
        public void ScenarioThreeB()
        {
            // arrange
            var person1 = new Person();
            // TODO: some ambiguity around person 1, "2 cards MC and visa"
            // is it 2 cards total (1 MC and 1 Visa) 
            // or is it 2 MC + 1 Visa <- testing this one
            // or is it 2 MC + 2 Visa
            var person2 = new Person();
            var wallet1 = new Wallet();
            var wallet2 = new Wallet();
            var visaCard = new VisaCard(100);
            var masterCard = new MasterCard(100);

            // act
            if (person1.AddWallet(wallet1))
            {
                wallet1.AddCreditCard(masterCard);
                wallet1.AddCreditCard(masterCard);
                wallet1.AddCreditCard(visaCard);
            }

            if (person2.AddWallet(wallet2))
            {
                wallet2.AddCreditCard(masterCard);
                wallet2.AddCreditCard(visaCard);
            }

            // assert
            Assert.AreEqual(20.00m, person1.CalculateInterest());
            Assert.AreEqual(15.00m, person2.CalculateInterest());
            Assert.AreEqual(20.00m, wallet1.CalculateInterest());
            Assert.AreEqual(15.00m, wallet2.CalculateInterest());
        }

        /// <summary>
        /// 2 people have 1 wallet each, person 1 has 1 wallet, with 2 cards MC and visa
        /// person 2 has 1 wallet - 1 visa and 1 MC - each card has $100 balance - 
        /// calculate the total interest (simple interest) for each person and interest per wallet
        /// </summary>
        [TestMethod]
        public void ScenarioThreeC()
        {
            // arrange
            var person1 = new Person();
            // TODO: some ambiguity around person 1, "2 cards MC and visa"
            // is it 2 cards total (1 MC and 1 Visa) 
            // or is it 2 MC + 1 Visa 
            // or is it 2 MC + 2 Visa <- testing this one
            var person2 = new Person();
            var wallet1 = new Wallet();
            var wallet2 = new Wallet();
            var visaCard = new VisaCard(100);
            var masterCard = new MasterCard(100);

            // act
            if (person1.AddWallet(wallet1))
            {
                wallet1.AddCreditCard(masterCard);
                wallet1.AddCreditCard(masterCard);
                wallet1.AddCreditCard(visaCard);
                wallet1.AddCreditCard(visaCard);
            }

            if (person2.AddWallet(wallet2))
            {
                wallet2.AddCreditCard(masterCard);
                wallet2.AddCreditCard(visaCard);
            }

            // assert
            Assert.AreEqual(30.00m, person1.CalculateInterest());
            Assert.AreEqual(15.00m, person2.CalculateInterest());
            Assert.AreEqual(30.00m, wallet1.CalculateInterest());
            Assert.AreEqual(15.00m, wallet2.CalculateInterest());
        }
    }
}
