namespace FacadeMortgageApplicationDemo.BackEndLogic
{
    using System;

    internal class Bank
    {
        private const decimal MinimumMonthlyIncome = 1000;

        public bool HasSufficientSavings(Person person)
        {
            if (person.MonthlyIncome > MinimumMonthlyIncome)
            {
                Console.WriteLine("Checking for sufficient monthly income of {0}", person.Name);
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
