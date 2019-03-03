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
                return 0;
            }
        }


        public virtual bool WithdrawAmount(decimal withdrawalAmount, Enum type)
        {
            bool validWithdrawal = false;
            if (type.Equals("Premier") && withdrawalAmount > Balance)
                validWithdrawal = true;
            else
            {
                try
                {
                    validWithdrawal = (withdrawalAmount < 300);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Your daily maximum withdrawal is $300 or less. Please enter a smaller amount");
                }
                try
                {
                    validWithdrawal = (Balance - withdrawalAmount >= 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insufficient Funds");
                    MessageBox.Show("No negative withdrawal amounts are allowed." +
                        "Please enter a valid amount.");
                }
            }

            return validWithdrawal;
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
