using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emery_assignment4
{
    class SavingsAccount : BankAccount
    {

        private const decimal INTEREST = 0.02m;
        private const decimal BALANCE_CHECK = 100m;

        public override string Owner => "Saving-" + base.Owner;

        // Default constructor
        public SavingsAccount()
        {
        }

        public SavingsAccount(string accountNumber, string firstName, string lastName) :
            base(accountNumber, firstName, lastName)
            {

        }


        public decimal AddInterest()
        {
            decimal interest = 0;

            if (Balance > 100)
                interest = Balance * INTEREST;

            return interest;
        }


        public override string PrintStatement()
        {
            DateTime today = DateTime.Today;
            string date = today.ToString("MM/dd/yyyy");
            string statementString =
                Owner + " as of " + date + "\n" +
                "Savings Account balance is $" + Balance + "\n" +
                "Interest earned for the month is " + "$" + "\n" +
                AddInterest() + "\n" + "The total savings account balance including interest is " +
                Balance;

            return statementString;
        }


        public override string ShowBalance()
        {
            //    return base.ShowBalance();
            return Owner + " has $" + Balance + " in Savings Account.";

        }

    }
}
