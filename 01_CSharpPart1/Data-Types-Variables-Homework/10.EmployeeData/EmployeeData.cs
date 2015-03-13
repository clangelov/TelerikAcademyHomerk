using System;
class EmployeeData
{
    /* Problem 10. Employee Data
     * A marketing company wants to keep record of its employees. Each record would have the following characteristics
     * First name
     * Last name
     * Age (0...100)
     * Gender (m or f)
     * Personal ID number (e.g. 8 306 112 507)
     * Unique employee number (27560000…27569999)
     * Declare the variables needed to keep the information for a single employee using appropriate primitive data types. Use descriptive names. Print the data at the console.
    */
    static void Main()
    {
        string firstName = "Christiano";
        string secondName = "Ronaldo";
        byte age = 29;
        char gender = 'm';
        long personalIDNumber = 8502052222;
        int employeeNumber = 27569999;
        Console.WriteLine(firstName + "\n" + secondName + "\n" + age);
        Console.WriteLine(gender + "\n" + personalIDNumber + "\n" + employeeNumber);    
    }
}

