namespace FacadeMortgageApplicationDemo.BackEndLogic
{
    using System;

    internal class LoanRegistry
    {
        public bool HasNoBadLoans(Person person)
        {
            Console.WriteLine("Checking  " + person.Name + " credit history");

            // some logic
            return true;
        }
    }
}
