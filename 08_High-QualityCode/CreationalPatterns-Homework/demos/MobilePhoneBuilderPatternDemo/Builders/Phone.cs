namespace MobilePhoneBuilderPatternDemo.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Phone
    {
        private readonly string phoneManufacturer;
        private readonly Dictionary<string, string> info = new Dictionary<string, string>();

        public Phone(string vehicleType)
        {
            this.phoneManufacturer = vehicleType;
        }

        public string this[string key]
        {
            get { return this.info[key]; }
            set { this.info[key] = value; }
        }

        public void ShowInfo()
        {
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("Phone Manufacturer: {0}", this.phoneManufacturer);
            Console.WriteLine(" Battery  : {0}", this.info["battery"]);
            Console.WriteLine(" Screen : {0}", this.info["screen"]);
            Console.WriteLine(" OS: {0}", this.info["os"]);
            Console.WriteLine(" Price : {0}", this.info["price"]);
            Console.WriteLine(new string('*', 30));
        }
    }
}
