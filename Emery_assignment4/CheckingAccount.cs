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

        private int overdrafts = 0;

        public CheckingAccount(string accountNumber, string firstName, string lastName) :
            base(accountNumber, firstName, lastName)
        {
        }

    
        public enum CheckingAccountType { Basic, Premier }
        public CheckingAccountType AccountType { get; set; }

        public override string Owner => "Checking-" + base.Owner;


        private int NumberOfOverdrafts
        {
            get
            {
                return overdrafts;
            }
        }


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
            MessageBox.Show("test");
            return isFeeDue;
        }

    }
}
