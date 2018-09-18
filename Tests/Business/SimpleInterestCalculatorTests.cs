using ClearentChallenge.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class SimpleInterestCalculatorTests
    {
        [TestMethod]
        public void CalculateInterest_PositiveBalance_PositiveInterestRate_ReturnsPositiveNumber()
        {
            // arrange
            var simpleInterestCalculator = new SimpleInterestCalculator();
            var principal = 1000.00m;
            var interest = 2.0m;

            // act
            var actual = simpleInterestCalculator.CalculateInterest(principal, interest);

            // assert
            Assert.IsTrue(actual > 0);
        }

        [TestMethod]
        public void CalculateInterest_ZeroBalance_PositiveInterestRate_ReturnsZero()
        {
            // arrange
            var simpleInterestCalculator = new SimpleInterestCalculator();
            var principal = 0.00m;
            var interest = 2.0m;

            // act
            var actual = simpleInterestCalculator.CalculateInterest(principal, interest);

            // assert
            Assert.IsTrue(actual == 0);
        }

        [TestMethod]
        public void CalculateInterest_PositiveBalance_ZeroInterestRate_ReturnsZero()
        {
            // arrange
            var simpleInterestCalculator = new SimpleInterestCalculator();
            var principal = 1000.00m;
            var interest = 0.0m;

            // act
            var actual = simpleInterestCalculator.CalculateInterest(principal, interest);

            // assert
            Assert.IsTrue(actual == 0);
        }

        [TestMethod]
        public void CalculateInterest_NegativeBalance_PositiveInterestRate_ReturnsZero()
        {
            // arrange
            var simpleInterestCalculator = new SimpleInterestCalculator();
            var principal = -1000.00m;
            var interest = 2.0m;

            // act
            var actual = simpleInterestCalculator.CalculateInterest(principal, interest);

            // assert
            Assert.IsTrue(actual == 0);
        }

        [TestMethod]
        public void CalculateInterest_PositiveBalance_MinValueInterestRate_ThrowsOverflowException()
        {
            // arrange
            var simpleInterestCalculator = new SimpleInterestCalculator();
            var principal = 1000.00m;
            var interest = decimal.MinValue;

            // act
            // assert
            Assert.ThrowsException<OverflowException>(()=>simpleInterestCalculator.CalculateInterest(principal, interest));
        }

        [TestMethod]
        public void CalculateInterest_MaxValueBalance_InterestRateGreaterThan100_ThrowsOverflowException()
        {
            // arrange
            var simpleInterestCalculator = new SimpleInterestCalculator();
            var principal = decimal.MaxValue;
            var interest = 100.1m;

            // act
            // assert
            Assert.ThrowsException<OverflowException>(() => simpleInterestCalculator.CalculateInterest(principal, interest));
        }
    }
}
