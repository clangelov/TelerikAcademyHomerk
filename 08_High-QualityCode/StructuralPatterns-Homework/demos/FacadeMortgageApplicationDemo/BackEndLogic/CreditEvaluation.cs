namespace FacadeMortgageApplicationDemo.BackEndLogic
{
    using System;

    internal class CreditEvaluation
    {
        public bool HasGoodCreditRating(Person person)
        {
            Console.WriteLine("Check credit rating for " + person.Name);

            // some logic
            return true;
        }
    }
}
