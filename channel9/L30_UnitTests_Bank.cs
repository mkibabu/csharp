using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

// Unit Tests for the Bank solution.
// Source: http://msdn.microsoft.com/en-us/library/ms182532(v=vs.110).aspx
namespace BankUTest
{
    //! Test class requirements:
    // The [TestClass] attribute, required by the Test Explorer.
    // Each emthod being tested must have a [TestMethod] attibute.
    [TestClass]
    public class BankAccountUnitTests
    {
        // Test the ebit method. Four possible outcomes, i.e.
        // 1. throw ArgumentOutOfRangeException if (debit amount) < 0
        // 2. throw ArgumentOutOfRangeException if (debit amount) > balance
        // 3. Throw Exception if (account is frozen)
        // 4. if 1-3 pass, the balance should be reduced by the amount.

        // Test method format:
        // MethodUnderTest_TestCondition_RespondsInThisManner()
        // { Arrange: Act; Assert }

        //! First test: verify that a valid amount leads to a withdrawal
        [TestMethod]
        public void Debit_WithValidAmount_ReducesBalance()
        {
            // arrange
            double startBalance = 11.99;
            double debitAmount = 10.00;
            double expectedBalance = 1.99;

            BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);

            // act
            testAccount.Debit(debitAmount);

            // assert
            double actualBalance = testAccount.Balance;
            // verify that the two amounts are equal, or within some specified
            // accuracy of one another.
            Assert.AreEqual(expectedBalance, actualBalance, 0.001, "Account not debited correctly");
        }

        //! Second test: verify that an ArgumentOutOfRange exception is thrown
        //! when the amount to withdraw is less than 0
       

        // Original unit test for amount less than 0. Adequate, but difficult to
        // decipher which part of the exception throws the error. Adding the 
        // costomized error messages to the test class, and altering the contructor
        // of the exceptions thrown, allows us to narrow down which exception is
        // thrown.

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void Debit_WhenAmountIsLessThanZero_ThrowsArgumentOutOfRangeException()
        //{
        //    // arrange
        //    double startBalance = 11.99;
        //    double debitAmount = -100.00;

        //    BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);

        //    // act
        //    testAccount.Debit(debitAmount);

        //    // assert
        //    // Here, assert is handled by the ExpectedException attribute            
        //}

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            double startBalance = 11.99;
            double debitAmount = -100.00;

            BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);

            // act
            try
            {
                testAccount.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.AmountLessThanZero);
                return;
            }

            // Code to run if ArgumentOutOfRangeException is not thrown.
            Assert.Fail("ArgumentOutOfRangeException was not thrown!");
        
        }

        //! Third test: verify that an ArgumentOutOfRange exception is thrown
        //! when the amount to withdraw is greater then the balance
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            double startBalance = 11.99;
            double debitAmount = 100.00;

            BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);

            try
            {
                // act
                testAccount.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.AmountMoreThanBalance);
                return;
            }

            // Code run when ArgumentOutOfRangeException is not thrown.
            Assert.Fail("ArgumentOutOfRangeException was not thrown!");
        }
    }
}
