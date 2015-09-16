namespace FacadeMortgageApplicationDemo
{
    using System;

    public class Client
    {
        public static void Main()
        {
            var mortgage = new MortgageFacade();
            var person = new Person("Mike Johnson", 1050M);
            bool eligible = mortgage.IsEligible(person);

            Console.WriteLine("{0} has been {1} for a mortgage", person.Name, eligible ? "Approved" : "Rejected"); 
        }
    }
}
