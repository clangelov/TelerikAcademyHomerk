// StyleCop settings:
// Disabled: Documentation Rules
// Violation Count: 0 
namespace Task01.Log4NetAndStyleCop
{
    using System;
    using log4net;
    using log4net.Config;

    public class Log4NetDemo
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Log4NetDemo));

        public static void Main()
        {
            // This method initializes the log4net system to use a simple Console appender
            BasicConfigurator.Configure();

            Logger.Info("Start logging for this demo");

            try
            {
                Logger.Warn("Performing a difficult operation");
                int number = int.Parse("Useless string");    
            }
            catch (FormatException ex)
            {
                Logger.Error("You have an FormatException");
                Console.WriteLine("An " + ex.GetType() + " occured when trying to parse a string");
            }
            finally
            {
                Logger.Fatal("This program could not be of any use");
            }
        }
    }
}
