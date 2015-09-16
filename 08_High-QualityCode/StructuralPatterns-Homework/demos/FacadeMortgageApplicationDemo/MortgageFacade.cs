namespace FacadeMortgageApplicationDemo
{
    using System;

    using FacadeMortgageApplicationDemo.BackEndLogic;

    public class MortgageFacade
    {
        private Bank bank = new Bank();
        private LoanRegistry loanRegistry = new LoanRegistry();
        private CreditEvaluation creditEvaluation = new CreditEvaluation();

        public bool IsEligible(Person person)
        {
            Console.WriteLine("{0} applies for mortgage", person.Name);

            bool eligible = true;

            // Check creditworthyness of applicant
            if (!this.bank.HasSufficientSavings(person))
            {
                eligible = false;
            }
            else if (!this.loanRegistry.HasNoBadLoans(person))
            {
                eligible = false;
            }
            else if (!this.creditEvaluation.HasGoodCreditRating(person))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}
