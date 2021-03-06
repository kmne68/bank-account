﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emery_assignment4
{
    public partial class Form1 : Form
    {
        private int selectedActivity = 0;
        private string accountNumber = "";
        private string accountFirstName = "";
        private string accountLastName = "";

        private BankAccount account;

        public Form1()
        {
            InitializeComponent();
            PopulateCombo();

            btn_deposit.Enabled     = false;
            btn_withdraw.Enabled    = false;
            btn_show.Enabled        = false;
            btn_print.Enabled       = false;
            tb_deposit.Enabled      = false;
            tb_withdraw.Enabled     = false;
            
//            cb_accountTypes.SelectedIndex = 0;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            string balanceString = account.ShowBalance();
            MessageBox.Show(balanceString, "Meramec Online Banking System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public bool IsPresent(TextBox textBox, string name)
        {
            if(textBox.Name == "tb_fName" && textBox.Text == "")
            {
                MessageBox.Show("Customer's First Name is blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false;
            }
            if (textBox.Name == "tb_lName" && textBox.Text == "")
            {
                MessageBox.Show("Customer's Last Name is blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                return false;
            }
            return true;
        }


        private void PopulateCombo()
        {
            cb_accountTypes.Items.Add("--- Select An Account Type ---");
            cb_accountTypes.Items.Add("Checking");
            cb_accountTypes.Items.Add("Savings");
            cb_accountTypes.Items.Add("Money Market");
            cb_accountTypes.Items.Add("Certificate of Deposit");

            cb_accountTypes.SelectedIndex = 0;
        }


        private void MethodNotImplemented()
        {
            MessageBox.Show("Method implementation pending","", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        }


        private void btn_welcome_Click(object sender, EventArgs e)
        {

            try
            {
                if (cb_accountTypes.SelectedIndex > 0)
                {
                    selectedActivity = cb_accountTypes.SelectedIndex;
                }
                else
                {
                    MessageBox.Show("No account type was selected!");
                }
                accountNumber = mtb_accountNumber.Text;
                Console.WriteLine("accountNumber is " + accountNumber);

                //   int accountNumber = Convert.ToInt16(tb_acctnmbr.Text);
            }
            catch
            {
                MessageBox.Show("Customer Account Number is blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (IsPresent(tb_fName, "First Name") && IsPresent(tb_lName, "Last Name"))
                {
                    accountFirstName = tb_fName.Text;
                    accountLastName = tb_lName.Text;

                    // Test
                    if (selectedActivity == 1 || selectedActivity == 2)
                    {
                        MessageBox.Show("Customer " + accountFirstName + " " +
                            accountLastName + " has $0.02 in the " + cb_accountTypes.SelectedItem.ToString() + " account.");
                    }
                    else if (selectedActivity == 3 || selectedActivity == 4)
                    {
                        MessageBox.Show("Customer " + accountFirstName + " " + accountLastName + " does not have a " + cb_accountTypes.SelectedItem.ToString() + " account.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unknown error has occurred.");
            }

            // Test Bank Account owner
            if (selectedActivity == 1)
            {
                account = new CheckingAccount(accountNumber, accountFirstName, accountLastName);
                Console.WriteLine("Checking TEST OUTPUT = " + account.Owner);
            }
            if (selectedActivity == 2)
            {
                account = new SavingsAccount(accountNumber, accountFirstName, accountLastName);
                Console.WriteLine("Saving TEST OUTPUT = " + account.Owner);
            }
            
            EnableButtons();
            gb_customerInfo.Enabled = false;
        }


        private void btn_Deposit_Click(object sender, EventArgs e)
        {
            decimal depositAmount = 0;

            try
            {
                // FutureFeature();
                depositAmount = Convert.ToDecimal(tb_deposit.Text);
            }
            catch (NotImplementedException ex)
            {
                MethodNotImplemented();
            }

            if (selectedActivity == 2)
            {
                account.DepositAmount(depositAmount);
            }
        }


        private void btn_withdraw_Click(object sender, EventArgs e)
        {
            decimal withdrawalAmount = 0;

            try
            {
                // FutureFeature();
                withdrawalAmount = Convert.ToDecimal(tb_withdraw.Text);
            }
            catch (NotImplementedException ex)
            {
                MethodNotImplemented();
            }

            if(selectedActivity == 1)
            {
                account.WithdrawAmount(withdrawalAmount, account.AccountType);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                string statementString = account.PrintStatement();
                MessageBox.Show(statementString);
            }
            catch (NotImplementedException ex)
            {
                MethodNotImplemented();
            }
        }

        private void FutureFeature()
        {
            throw new NotImplementedException();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_deposit.Text = "";
            tb_fName.Text = "";
            tb_lName.Text = "";
            tb_withdraw.Text = "";
            mtb_accountNumber.Text = "";
            cb_accountTypes.Text = "";
        }


        private void EnableButtons()
        {
            btn_deposit.Enabled     = true;
            btn_withdraw.Enabled    = true;
            btn_show.Enabled        = true;
            btn_print.Enabled       = true;
            tb_deposit.Enabled      = true;
            tb_withdraw.Enabled     = true;
        }


    }
}
