using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// The Woodgrove Bank sample project is a simple bank account project used to
// generate unit tests. The code starts with an intentional error in the 
// Debit(double) method, which has a + sign rather than the correct - sign.
// Fixed as the unit tests project goes on.

// Source: "Sample Project for creating unit tests", MSDN
// http://msdn.microsoft.com/en-us/library/ms243176\(v=vs.110\).aspx

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class
    /// </summary>
    public class BankAccount
    {
        private string m_customerName;
        private double m_balance;
        private bool m_frozen = false;

        // variables used for error messages
        public const string AmountLessThanZero = "Amount is less than zero";
        public const string AmountMoreThanBalance = "Amount is more than available balance";

        // good practice to always have a default contructor; however, to keep
        // other classes from calling it, make it private.
        private BankAccount()
        {

        }

        // Main (and only) constructor
        public BankAccount(string aCustomerName, double aBalance)
        {
            m_customerName = aCustomerName;
            m_balance = aBalance;
        }

        // Properties. Makes the customerName and balance variables readonly,
        // without needing the readonly keyword (which means variables must be
        // initlalized in constructor or at declaration)
        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance;  }
        }

        // private methods. Never repeat/copy-paste code
        private void checkIfAccountFrozen()
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }
        }

        private void checkIfAmountInvalid(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount", amount, AmountLessThanZero);
            }
        }

        private void freezeAccount()
        {
            m_frozen = true;
        }

        private void unfreezeAccount()
        {
            m_frozen = false;
        }


        //! Starts with a known error: amount should be subtracted from
        //! balance, not added. Corrected as project progresses, but original
        // erroneous line commented out.
        public void Debit(double amount)
        {
            checkIfAccountFrozen();

            checkIfAmountInvalid(amount);

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("Amount", amount, AmountMoreThanBalance);
            }

            // m_balance += amount;    // original intentionally erroneous code
            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            checkIfAccountFrozen();
            
            checkIfAmountInvalid(amount);

            m_balance += amount;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nBalance: {1:C}\nFrozen? (Y/N): {2}",
                this.CustomerName, this.Balance, m_frozen ? "Y" : "N");
        }
    }

    public class BankMain
    {
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine(ba.ToString());

            Console.ReadLine();
        }
    }
}
