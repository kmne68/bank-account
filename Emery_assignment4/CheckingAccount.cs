using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emery_assignment4
{
    class CheckingAccount : BankAccount
    {
        private const decimal OVERDRAFT_FEE = 25.00M;

        public CheckingAccount(string accountNumber, string firstName, string lastName) :
            base(accountNumber, firstName, lastName)
        {
        }


        public enum CheckingAccountType { Basic, Premier }
        public CheckingAccountType AccountType { get; set; }

        public override string Owner => "Checking-" + base.Owner;


        private int NumberOfOverdrafts { get; set; } = 0;

        private decimal OverDraftFee
        {
            get
            {
                return Balance - OVERDRAFT_FEE;
            }
        }


        public override bool WithdrawAmount(decimal withdrawalAmount, Enum type)
        {
            bool isFeeDue = base.WithdrawAmount(withdrawalAmount, type);

            if (isFeeDue)
                NumberOfOverdrafts++;
            MessageBox.Show("overdrafts = " + NumberOfOverdrafts);
            return isFeeDue;
        }


        public override string PrintStatement()
        {
            DateTime today = DateTime.Today;
            string date = today.ToString("MM/dd/yyyy");
            string statementString =
                Owner + " as of " + date + "\n" +
                "Checking Account balance is $" + Balance + "\n" +
                "Amount of overdraft fee for the month is " + "$XX.XX" + "\n" +
                "The number of overdrafts is " + NumberOfOverdrafts;

            return statementString;        
        }


        public override string ShowBalance()
        {
            //    return base.ShowBalance();
            return Owner + " has $" + Balance + " in Checking Account.";
            
        }

    }
}
