using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emery_assignment4
{
    class BankAccount : IPrintable
    {
        private string accountNumber = "";
        private string firstName = "";
        private string lastName = "";

        public virtual string Owner
        {
            get
            {
                return "Account # " +
                    AccountNumber +
                    "--" +
                    firstName +
                    " " +
                    lastName;
            }
        }

        private decimal Balance
        {
            get
            {
                return 0;
            }
        }

        public string AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }


        // default constructor
        public BankAccount()
        {
        }

        public BankAccount(string accountNumber, string firstName, string lastName)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
        }


        public void DepositAmount(decimal deposit)
        {

        }


        public virtual bool WithdrawAmount(decimal withdrawalAmount, Nullable<int> type)
        {
            bool isPremier = false;

            if (type == 1)
                isPremier = false;
            else
                isPremier = true;

            return isPremier;
        }

        public String PrintStatement()
        {
            String result = "";

            return result;
        }

        public String ShowBalance()
        {
            String result = "";

            return result;
        }


    }
}
