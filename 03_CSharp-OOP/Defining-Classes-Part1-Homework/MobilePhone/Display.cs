namespace MobilePhone
{
    using System;
    using System.Text;

    // Problem 1. Define class
    public class Display
    {
        // setting some default values, to be used with the different constructors
        private const double DefautDisplaySize = 5;
        private const int DefaultDisplayColors = 16000000;
        private const DisplayType DefaultTypeOfDisplay = DisplayType.AMOLED;

        // private fields which are visible only within { } of the class
        private double displaySize;
        private int displayColors;

        // Problem 2. Constructors
        // Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it).
        public Display()
            : this(DefautDisplaySize, DefaultDisplayColors, DefaultTypeOfDisplay)
        {
        }

        public Display(double sizeDisplay)
            : this(sizeDisplay, DefaultDisplayColors, DefaultTypeOfDisplay)
        {
        }

        public Display(double sizeDisplay, int colorsDisplay)
            : this(sizeDisplay, colorsDisplay, DefaultTypeOfDisplay)
        {
        }

        // first creating this constructor and than just re-use it with : this
        public Display(double sizeDisplay, int colorsDisplay, DisplayType typeOfDisplay)
        {
            this.DisplaySize = sizeDisplay;
            this.DisplayColor = colorsDisplay;
            this.TypeOfTheDisplay = typeOfDisplay;
        }

        // Problem 3. Enumeration
        public enum DisplayType
        {
            AMOLED,
            TFT,
            OLED,
            LCD,
            LED
        }

        // Problem 5. Properties
        // Use properties to encapsulate the data fields inside the GSM, Battery and Display classes.
        public double DisplaySize
        {
            get
            {
                return this.displaySize;
            }
            // you can set the property only via the constructor
            private set
            {
                if (value < 1 || value > 8)
                {
                    throw new ArgumentOutOfRangeException("The value shoud be in the range between 1 and 8");
                }
                this.displaySize = value;
            }
        }

        public int DisplayColor
        {
            get
            {
                return this.displayColors;
            }
            private set
            {
                if (value < 1000 || value > int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException("The value shoud be in the range between 16 and int.MaxValue");
                }
                this.displayColors = value;
            }
        }
        public DisplayType TypeOfTheDisplay { get; private set; }

        // Problem 4. ToString
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Information about the Display:");
            result.AppendFormat(new string('-', 30) + "\n");
            result.AppendFormat("Display Size {0}\"\n", displaySize);
            result.AppendFormat("Colour Depth {0}k\n", displayColors / 1000);
            result.AppendFormat("Technology used {0}\n", TypeOfTheDisplay);
            result.AppendFormat(new string('-', 30) + "\n");

            return result.ToString();
        }
    }
}
