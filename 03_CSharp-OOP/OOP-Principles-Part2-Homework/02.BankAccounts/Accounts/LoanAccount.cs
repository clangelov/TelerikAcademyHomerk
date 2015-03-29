namespace _02.BankAccounts
{
    using System;
    class LoanAccount : Account, IDepositMoney
    {
        public LoanAccount(Costumer holder, decimal balance, double interestRate)
            : base(holder, balance, interestRate)
        {
        }

        // Loan accounts have no interest for the first 3 months if are held by individuals 
        // and for the first 2 months if are held by a company.
        public override decimal CalculateInterestAmount(int months)
        {
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException("Months must be positive number");
            }

            if (this.Holder.Type == AccountHolder.Individual)
            {
                if (months > 3)
                {
                    return (decimal)((this.InterestRate * (months - 3)) / 100.0) * this.Balance;
                }
                else
                {
                    return 0;
                }
            }

            if (this.Holder.Type == AccountHolder.Company && months > 2)
            {
                return (decimal)((this.InterestRate * (months - 2)) / 100.0) * this.Balance;
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
    }
}
