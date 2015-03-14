namespace MobilePhone
{
    using System;
    using System.Text;

    // Problem 1. Define class
    public class Battery
    {
        // setting some default values, to be used with the different constructors
        private const int DefautHoursTalk = 10;
        private const int DefaultHoursReady = 100;
        private const BatteryType DefaultTypeOfBattery = BatteryType.LiIon;

        // private fields which are visible only within { } of the class
        private int hoursTalk;
        private int hoursReady;

        // Problem 2. Constructors
        // Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it).
        public Battery()
            : this(DefautHoursTalk, DefaultHoursReady, DefaultTypeOfBattery)
        {
        }

        public Battery(int hoursTalk)
            : this(hoursTalk, DefaultHoursReady, DefaultTypeOfBattery)
        {
        }

        public Battery(int hoursTalk, int hoursReady)
            : this(hoursTalk, hoursReady, DefaultTypeOfBattery)
        {
        }

        // first creating this constructor and than just re-use it with : this
        public Battery(int hoursTalk, int hoursReady, BatteryType typeOfBattery)
        {
            this.HoursTalk = hoursTalk;
            this.HoursReady = hoursReady;
            this.TypeOfBattery = typeOfBattery;
        }

        // Problem 5. Properties
        // Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            // you can set the property only via the constructor
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentOutOfRangeException("The value shoud be in the range between 1 and 50");
                }
                this.hoursTalk = value;
            }
        }

        public int HoursReady
        {
            get
            {
                return this.hoursReady;
            }
            private set
            {
                if (value < 1 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("The value shoud be in the range between 1 and 500");
                }
                this.hoursReady = value;
            }
        }
        public BatteryType TypeOfBattery { get; private set; }

        // Problem 4. ToString
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Information about the Battery:");
            result.AppendFormat(new string('-', 30) + "\n");
            result.AppendFormat("Talk time up to {0}h\n", hoursTalk);
            result.AppendFormat("Standby time up to {0}h\n", hoursReady);
            result.AppendFormat("Type of the battery {0}\n", TypeOfBattery);
            result.AppendFormat(new string('-', 30) + "\n");

            return result.ToString();
        }
    }   
}
