namespace MobilePhone
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    // Problem 1. Define class
    public class GSM
    {
        // setting some default values, to be used with the different constructors
        private const string DefaultOwner = "Private";
        private const decimal DefaultPrice = 499M;

        // Problem 11. Call price - Assume the price per minute is fixed and is provided as a parameter.
        private const decimal DefaultPricePerMinute = 0.37M;

        // Problem 9. Call history
        // Try to use the system class List<Call>.
        private readonly List<Calls> callHistory;

        // Problem 6. Static field
        // Add a static field IPhone6 in the GSM class to hold the information about iPhone6.
        private static GSM IPhone6 = new GSM
        ("Apple", "iPhone 6", "Andy", 1199M,
        new Display(4.7, 16000000, Display.DisplayType.LED),
        new Battery(14, 250, BatteryType.LiIon));

        // private fields which are visible only within { } of the class
        private string manufacturer;
        private string model;
        private string owner;
        private decimal price;
        private Display display;
        private Battery battery;

        // Problem 2. Constructors
        // Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it).
        public GSM(string manufacturer, string model)
            : this(manufacturer, model, DefaultOwner, DefaultPrice, new Display(), new Battery())
        {

        }
        public GSM(string manufacturer, string model, decimal price)
            : this(manufacturer, model, DefaultOwner, price, new Display(), new Battery())
        {

        }
        public GSM(string manufacturer, string model, string owner, decimal price)
            : this(manufacturer, model, owner, price, new Display(), new Battery())
        {

        }

        // first creating this constructor and than just re-use it with : this
        public GSM(string manufacturer, string model, string owner, decimal price, Display display, Battery battery)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Owner = owner;
            this.Price = price;
            this.display = display;
            this.battery = battery;
            this.callHistory = new List<Calls>();
        }

        // Problem 6. Static field
        // Add a static property IPhone_6 in the GSM class to hold the information about iPhone6.
        public static GSM IPhone_6
        {
            get { return IPhone6; }
        }

        // Problem 5. Properties
        // Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            // you can set the property only via the constructor
            private set
            {
                this.manufacturer = CheckValue(value);
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = CheckValue(value);
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = CheckValue(value);
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 1 || value >= 2000)
                {
                    throw new ArgumentOutOfRangeException("The value shoud be in the range between 1 and 2000");
                }
                this.price = value;
            }
        }
        public Display Display
        {
            get { return this.display; }
            private set { this.display = value; }
        }
        public Battery Battery
        {
            get { return this.battery; }
            private set { this.battery = value; }
        }

        // Problem 9. Call history
        public List<Calls> CallHistory
        {
            get { return new List<Calls>(this.callHistory); }
        }

        // Creating an method which will validate the input data for Owner, Manufacturer and Model, because they follow the same patern
        private static string CheckValue(string value)
        {
            if (value.Length < 3 || value.Length > 15)
            {
                throw new ArgumentOutOfRangeException("The input length shoud be in the range between 3 and 15");
            }
            else
            {
                return value;
            }

        }
        // Problem 4. ToString
        // Add a method in the GSM class for displaying all information about it.
        // Try to override ToString().
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Information about the Phone:");
            result.AppendFormat(new string('-', 30) + "\n");
            result.AppendFormat("Brand: {0}\n", manufacturer);
            result.AppendFormat("Model: {0}\n", model);
            result.AppendFormat("Owner: {0}\n", owner);
            result.AppendFormat("Price: {0:C}\n", price);
            result.AppendFormat(new string('-', 30) + "\n");

            return result.ToString();
        }

        // Creating a method which gets the whole information from the classes GSM, Display and Battery
        public static string FullPhoneInfo(GSM input)
        {
            StringBuilder result = new StringBuilder();

            result.Append(input.ToString());
            result.Append(input.display.ToString());
            result.Append(input.battery.ToString());

            return result.ToString();
        }

        // Problem 10. Add calls
        public void AddCall(Calls call)
        {
            this.callHistory.Add(call);
        }

        // Problem 10. Delete calls
        // This will delete the last call
        public void RemoveCall(Calls call)
        {
            int index = callHistory.IndexOf(call);
            if (index >= 0)
            {
                this.callHistory.RemoveAt(index);
            }
            else
            {
                throw new ArgumentOutOfRangeException("There is no matching call in the Call history");
            }
        }

        public void RemoveLastCall()
        {
            if (callHistory.Count > 0)
            {
                this.callHistory.RemoveAt(callHistory.Count - 1);
            }
            else
            {
                throw new ArgumentOutOfRangeException("There are no calls in the Call history, which can be deleted");
            }
        }

        // Problem 10. Add/Delete calls
        // Add a method to clear the call history.
        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        // Problem 11. Call price
        // Add a method that calculates the total price of the calls in the call history.
        public decimal PriceOfCall()
        {
            long seconds = 0;

            foreach (var callTime in this.CallHistory)
            {
                seconds += callTime.CallDuration;
            }

            decimal totalPrice = (decimal)(seconds / 60) * DefaultPricePerMinute;

            return totalPrice;
        }
    }
}
