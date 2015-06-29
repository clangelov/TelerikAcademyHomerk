namespace Task01.ConsoleWriter
{
    using System;

    public class ConsoleVariableWriter
    {
        public void WriteBooleanToTheConsole(bool input)
        {
            string inpustAsString = input.ToString();
            Console.WriteLine(inpustAsString); 
        }
    }
}
