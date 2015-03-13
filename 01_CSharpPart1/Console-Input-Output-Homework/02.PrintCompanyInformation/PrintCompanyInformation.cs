using System;
class PrintCompanyInformation
{
    /* Problem 2. Print Company Information
     * A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number.
     * Write a program that reads the information about a company and its manager and prints it back on the console.
    */
    static void Main()
    {
        Console.Write("Enter company name: ");
        string companyName = Console.ReadLine();

        Console.Write("Enter company address: ");
        string companyAddress = Console.ReadLine();

        Console.Write("Enter company phone number: ");
        string companyPhone = Console.ReadLine();

        Console.Write("Enter company fax number: ");
        string companyFax = Console.ReadLine();

        Console.Write("Enter company web site: ");
        string companyWeb = Console.ReadLine();

        Console.Write("Enter manager's first name: ");
        string managerFName = Console.ReadLine();

        Console.Write("Enter manager's last name: ");
        string managerLName = Console.ReadLine();

        Console.Write("Enter manager's age: ");
        byte managerAge = byte.Parse(Console.ReadLine());

        Console.Write("Enter manager's phone: ");
        string managerPhone = Console.ReadLine();

        Console.Clear();

        Console.WriteLine(companyName);
        Console.WriteLine("Adress: {0}",companyAddress);
        Console.WriteLine(companyPhone.Length > 9 ? "Tel. {0}" : "Tel. (no tel)",companyPhone);
        Console.WriteLine(companyFax.Length > 9 ? "Fax: {0}" : "Fax: (no fax)",companyFax);
        Console.WriteLine("Web site: {0}", companyWeb);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel.{3})", managerFName, managerLName, managerAge, managerPhone);
    }
}

