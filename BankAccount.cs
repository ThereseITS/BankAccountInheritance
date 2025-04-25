using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountInheritance
{
    internal class BankAccount
    {
        string _accountNumber;
        static int accountNumberGenerator =0;
        public string AccountNumber {
            get { return _accountNumber; }        
            private set { _accountNumber = value; } 
        }
        public decimal Balance { get; protected set; }

        /// <summary>
        /// Basic Constructor
        /// </summary>
        public BankAccount() 
        { 
            Balance = 0;
            accountNumberGenerator++;
            _accountNumber = accountNumberGenerator.ToString();          
        }
        /// <summary>
        /// Constructor to set the initial balance
        /// </summary>
        /// <param name="balance"></param>
        public BankAccount(decimal balance)
        {
            this.Balance = balance;
            accountNumberGenerator++;
            _accountNumber = accountNumberGenerator.ToString();
        }
        /// <summary>
        /// Constructor for pre-existing account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="balance"></param>
        public BankAccount(string  accountNumber, decimal balance)
        { 
            this.Balance = balance;
            this._accountNumber = accountNumber;
        }

        /// <summary>
        /// Lodge money. Returns new balance.
        /// </summary>
        /// <param name="amount"> amount of money to lodge</param>
        public decimal Lodge(decimal amount)
        {
            Balance += amount;
            return Balance;
        }
/// <summary>
/// If there is enough money,this method subtracts the amount from the balance, returning the amount.
/// If there is not enough money, this method sets the balance to zero, returning the available amount.
///= </summary>
/// <param name="amount"></param>
/// <returns>amount withdrawn</returns>
        public virtual decimal Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;

            }
            else
            {
                amount = Balance;
                Balance = 0;
            }
            return amount;
        }
        public override string ToString()
        {
            return $"Account Number : {_accountNumber} Balance: {Balance}";
        }
    }
    /// <summary>
    /// Child clsas - current account
    /// </summary>
    class CurrentAccount:BankAccount
    {
        public decimal OverdraftLimit { get; private set; }

        public CurrentAccount() : base()
        {
            OverdraftLimit = 0;
        }

        /// <summary>
        /// note the calls to the metching  parent constructor, passing the required parameters
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="overdraftLimit"></param>
        public CurrentAccount(decimal balance, decimal overdraftLimit):base(balance)
        {
            this.OverdraftLimit = overdraftLimit;
        }
        public CurrentAccount(string accountNumber, decimal balance, decimal overdraftLimit) : base(accountNumber, balance)
        {
            this.OverdraftLimit = overdraftLimit;
        }

        public void SetNewOverdraft(decimal amount)
        {
            OverdraftLimit = amount;
        }
        public override decimal Withdraw(decimal amount)
        {
            if ((Balance+OverdraftLimit) >= amount)
            {
                Balance -= amount;

            }
            else
            {
                amount = Balance+OverdraftLimit;
                Balance = OverdraftLimit*(-1);
               
            }
            return amount;
        }
        public override string ToString()
        {
            return $" Current {base.ToString()} Overdraft Limit: {OverdraftLimit.ToString()}";
        }

    }
}
