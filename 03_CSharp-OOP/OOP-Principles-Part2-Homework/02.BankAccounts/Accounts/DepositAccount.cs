namespace _02.BankAccounts
{
    using System;
    class DepositAccount : Account, IDepositMoney, IWithdrawMoney
    {
        public DepositAccount(Costumer holder, decimal balance, double interestRate)
            : base(holder, balance, interestRate)
        {
        }

        // Deposit accounts have no interest if their balance is positive and less than 1000.
        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Balance >= 1000)
            {
                return (decimal)((this.InterestRate * months) / 100.0) * this.Balance;
            }

            return 0;
        }

        public void DepositMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("You can deposit only positive amount of money");
            }

            this.Balance += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            if (this.Balance - amount >= 0)
            {
                this.Balance -= amount;
            }
            else
            {
                Console.WriteLine("Invalid operation");
            }
        }
    }
}
