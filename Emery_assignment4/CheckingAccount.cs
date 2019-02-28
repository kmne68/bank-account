using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emery_assignment4
{
    class CheckingAccount : BankAccount
    {
        public CheckingAccount() : base()
        {
        }


        public enum CheckingAccountType { Basic, Premier }

        public override string Owner => "Checking-" + base.Owner;
        
        public CheckingAccountType AccountType { get; set; }

        
    }
}
