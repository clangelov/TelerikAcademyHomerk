namespace _02.BankAccounts
{
    using System;
    class MortgageAccount : Account, IDepositMoney
    {
        public MortgageAccount(Costumer holder, decimal balance, double interestRate)
            : base(holder, balance, interestRate)
        {
        }

        // Mortgage accounts have ½ interest for the first 12 months for companies 
        // and no interest for the first 6 months for individuals.
        public override decimal CalculateInterestAmount(int months)
        {
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException("Months must be positive number");
            }

            if (this.Holder.Type == AccountHolder.Individual && months > 6)
            {
                return (decimal)((this.InterestRate * (months - 6)) / 100.0) * this.Balance;
            }

            if (this.Holder.Type == AccountHolder.Company)
            {
                if (months <= 12)
                {
                    return (decimal)((this.InterestRate * ((double)months / 2)) / 100.0) * this.Balance;
                }
                else
                {
                    decimal first12Months = (decimal)(this.InterestRate * 6 / 100.0) * this.Balance;
                    decimal after12Months = (decimal)((this.InterestRate * (months - 12)) / 100.0) * this.Balance;
                    return first12Months + after12Months;
                }
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
