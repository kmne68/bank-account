using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emery_assignment4
{
    class BankAccount : IPrintable
    {

        private string accountNumber = "";
        private string firstName = "";
        private string lastName = "";
       
        public string AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public enum CheckingAccountType { Basic, Premier }
        public CheckingAccountType AccountType { get; set; }


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

        public decimal Balance
        {
            get
            {
                return 273.07M;
            }
        }


        public void DepositAmount(decimal deposit)
        {
        }


        public virtual bool WithdrawAmount(decimal withdrawalAmount, Enum type)
        {
            bool feeIsDue = false;

            if (type.Equals("Premier") && withdrawalAmount > Balance)
                feeIsDue = true;
            else
            {
                try
                {
                    if (withdrawalAmount > Balance)
                        throw new Exception("Withdrawal is too large.");
                }
                catch(Exception e)
                {
                    MessageBox.Show("No negative withdrawal amounts are allowed.\n" +
                        "Insufficient Funds\n" + "Please enter a valid amount.");
                }
                try
                {
                    if (withdrawalAmount > 300)
                        throw new Exception("Withdrawal greater than $300.");
                }
                catch(Exception e)
                {
                    MessageBox.Show("Your daily maximum withdrawal is $300 or less. Please enter a smaller amount");
                }

            }

            return feeIsDue;
        }


        public virtual String PrintStatement()
        {
            String result = "";

            return result;
        }

        public virtual String ShowBalance()
        {
            String result = "";

            return result;
        }


    }
}
