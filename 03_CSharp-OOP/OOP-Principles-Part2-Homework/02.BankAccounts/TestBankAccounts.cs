/*
 * Problem 2. Bank accounts
*/
namespace _02.BankAccounts
{
    using System;
    class TestBankAccounts
    {
        static void Main()
        {
            
            var depsoitTest = new DepositAccount(new Costumer("Wayne Rooney", AccountHolder.Individual), 200000, 0.25);

            var loanTestIndividual = new LoanAccount(new Costumer("Juan Mata", AccountHolder.Individual), 250000, 0.85);
            var loanTestCompany = new LoanAccount(new Costumer("Manchester Ltd", AccountHolder.Company), 250000, 0.85);

            var mortgageTestIndividual =  new MortgageAccount(new Costumer("Falcao", AccountHolder.Individual)
                , 750000, 0.75);
            var mortgageTestCompany = new MortgageAccount(new Costumer("United Ltd", AccountHolder.Company)
                , 750000, 0.75);

            depsoitTest.WithdrawMoney(199500); // less than 1000 = interest of 0
            Console.WriteLine(string.Format("{0} will receive interest of {1:C} for 12 months", depsoitTest.Holder.ToString(), depsoitTest.CalculateInterestAmount(12)));

            Console.WriteLine(new string('=', 50));

            // Loan accounts have no interest for the first 3 months if are held by individuals 
            // and for the first 2 months if are held by a company.
            Console.WriteLine(string.Format("{0} needs to pay interest of {1:C} for the next 12 months", loanTestIndividual.Holder.Name, loanTestIndividual.CalculateInterestAmount(12)));
            Console.WriteLine(string.Format("{0} needs to pay interest of  {1:C} for the next 12 months", loanTestCompany.Holder.Name, loanTestCompany.CalculateInterestAmount(12)));

            Console.WriteLine(new string('=', 50));

            // Mortgage accounts have ½ interest for the first 12 months for companies 
            // and no interest for the first 6 months for individuals.
            Console.WriteLine(string.Format("{0} needs to pay interest of {1:C} for the next 7 months", mortgageTestIndividual.Holder.Name, mortgageTestIndividual.CalculateInterestAmount(7)));
            Console.WriteLine(string.Format("{0} needs to pay interest of {1:C} for the next 7 months", mortgageTestCompany.Holder.Name, mortgageTestCompany.CalculateInterestAmount(7)));

            Console.WriteLine();
        }
    }
}
