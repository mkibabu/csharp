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

        //! First test:
        // Verify that a newly created account is not frozen
        [TestMethod]
        public void Account_NewAccountIsUnfrozen()
        {
            // arrange
            double startBalance = 100.99;
            // act
            BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);
            // assert
            Assert.AreEqual(testAccount.AccountFrozen, false, "New account should not be frozen");
        }
        
        // Verify that an account can be frozen
        [TestMethod]
        public void AccountFrozen_UnfrozenAccountCanBeFrozen()
        {
            // arrange
            double startBalance = 100.99;
            BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);

            // act
            testAccount.AccountFrozen = true;

            // assert
            Assert.AreEqual(testAccount.AccountFrozen, true, "Frozen account should have its \"Frozen\" status set to \"true\"");
        }

        // Verify that an account can be unfrosen, once frozen
        [TestMethod]
        public void AccountFrozen_FrozenAccountCanBeUnfrozen()
        {
            // arrange
            double startBalance = 11.99;
            BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);
            testAccount.AccountFrozen = true;

            // act
            if (testAccount.AccountFrozen)
            {
                testAccount.AccountFrozen = false;
            }
            else
            {
                Assert.Fail("Account freezing failed, thus unfreezing could not be tested.");
                return;
            }
            
            // assert
            Assert.AreEqual(testAccount.AccountFrozen, false, "Frozen account could not be unfrozen");

        }
        // verify that a valid amount leads to a withdrawal

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

        // verify that an ArgumentOutOfRange exception is thrown when the amount
        // to withdraw is less than 0
       

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
                StringAssert.Contains(e.Message, BankAccount.AmountLessThanZeroMessage);
                return;
            }

            // Code to run if ArgumentOutOfRangeException is not thrown.
            Assert.Fail("ArgumentOutOfRangeException was not thrown!");
        
        }

        // verify that an ArgumentOutOfRange exception is thrown when the amount
        // to withdraw is greater than the balance
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
                StringAssert.Contains(e.Message, BankAccount.AmountMoreThanBalanceMessage);
                return;
            }

            // Code run when ArgumentOutOfRangeException is not thrown.
            Assert.Fail("ArgumentOutOfRangeException was not thrown!");
        }

        // Verify that an Exception is thrown when an attempt is made to debit 
        // from a frozen account.
        [TestMethod]
        public void Debit_AccountFrozenValidAmount_ThrowsException()
        {
            // arrange
            double startBalance = 10.00;
            double debitAmount = 4.00;

            BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);
            testAccount.AccountFrozen = true;

            // act
            try
            {
                testAccount.Debit(debitAmount);
            }
            catch (Exception e)
            {
                // assert
                if (testAccount.AccountFrozen)
                {
                    StringAssert.Contains(e.Message, BankAccount.AccountFrozenMessage);
                }
                else
                {
                    Assert.Fail("Frozen account's \"frozen\" status not set to correct value");
                }

                return;
            }


            // Exception not called; test failed
            Assert.Fail("Excpected exception not called");
        
        }

        // verify that a valid amount leads to a deposit
        [TestMethod]
        public void Credit_ValidAmount_IncreasesBalance()
        {
            // arrange
            double startBalance = 11.99;
            double creditAmount = 5.00;
            double expectedBalance = 16.99;

            BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);

            // act
            testAccount.Credit(creditAmount);

            // assert
            double actualBalance = testAccount.Balance;
            // verify that the two amounts are equal, or within some specified
            // accuracy of one another.
            Assert.AreEqual(expectedBalance, actualBalance, 0.001, "Account not credited correctly");
 
        }
        
        // verify that an ArgumentOutOfRange exception is thrown when the amount
        // to deposit is less than zero
        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            // arrange
            double startBalance = 11.99;
            double debitAmount = -100.00;

            BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);

            // act
            try
            {
                testAccount.Credit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.AmountLessThanZeroMessage);
                return;
            }

            // Code to run if ArgumentOutOfRangeException is not thrown.
            Assert.Fail("ArgumentOutOfRangeException was not thrown!");
        
        }
        
        // Verify that an Exception is thrown when an attempt is made to credit
        // to a frozen account.
        [TestMethod]
        public void Credit_AccountFrozenValidAmount_ThrowsException()
        {
            // arrange
            double startBalance = 10.00;
            double creditAmount = 4.00;

            BankAccount testAccount = new BankAccount("Mr. Cookie Monster", startBalance);
            testAccount.AccountFrozen = true;

            // act
            try
            {
                testAccount.Credit(creditAmount);
            }
            catch (Exception e)
            {
                // assert
                if (testAccount.AccountFrozen)
                {
                    StringAssert.Contains(e.Message, BankAccount.AccountFrozenMessage);
                }
                else
                {
                    Assert.Fail("Frozen account's \"frozen\" status does not reflect correct status");
                }
                
                return;
            }


            // Exception not called; test failed
            Assert.Fail("Expected exception not called");
        
        }   
    }
}
