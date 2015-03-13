using System;
class BankAccountData
{
    /* Problem 11. Bank Account Data
     * A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account.
     * Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.
    */
    static void Main()
    {
        string firstName = "Christiano";
        string middleName = "Roanldo";
        string lastName = "dos Santos";
        object fullName = firstName + " " + middleName + " " + lastName;
        int balance = 10000000;
        string bankName = "Real Madrid Bank";
        string iBAN = "2132165486GHKHJ465464654";
        string bic = "STSABGSF";
        long firstCard = 1111222233334444;
        long secondCard = 1111333355557777;
        long thirdCard = 2222444466668888;
        Console.WriteLine("Holder Name: {0}",fullName);
        Console.WriteLine("Balance: {0:C}", balance);
        Console.WriteLine("Bank: {0}" + "\n" + "IBAN: {1}" + "\n" + "BIC: {2}", bankName, iBAN, bic);
        Console.WriteLine("Card Number 1: {0} \nCard Number 2: {1} \nCard Number 3: {2}", 
            firstCard, secondCard, thirdCard);
    }
}

