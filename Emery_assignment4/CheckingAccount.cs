using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emery_assignment4
{
    class CheckingAccount : BankAccount
    {
        private const decimal OVERDRAFT_FEE = 25.00M;

        private int overdrafts = 0;

        public CheckingAccount() : base()
        {
        }

    
        public enum CheckingAccountType { Basic, Premier }

        public override string Owner => "Checking-" + base.Owner;
        
        public CheckingAccountType AccountType { get; set; }

        public void DepositAmount(decimal deposit)
        {

        }


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
            bool isPremier = base.WithdrawAmount(withdrawalAmount, type);

            if (isPremier)
                isPremier = false;
            else
                isPremier = true;

            return isPremier;
        }

    }
}
