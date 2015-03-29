/*
 * A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage
 * All accounts have customer, balance and interest rate (monthly based).
*/
namespace _02.BankAccounts
{
    using System;
    abstract class Account
    {
        private Costumer holder;
        private decimal balance;
        private double interestRate;

        public Account(Costumer holder, decimal balance, double interestRate)
        {
            this.Holder = holder;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Costumer Holder
        {
            get
            {
                return this.holder;
            }
            private set
            {
                this.holder = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Initial balance should be 0 or more");
                }
                this.balance = value;
            }
        }

        public double InterestRate
        {
            get
            {
                return this.interestRate;
            }
            private set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Montly interest should be in the range 0.1-10");
                }
                this.interestRate = value;
            }
        }

        // All accounts can calculate their interest amount for a given period (in months). 
        // In the common case its is calculated as follows: number_of_months * interest_rate.
        public abstract decimal CalculateInterestAmount(int months);

    }
}
