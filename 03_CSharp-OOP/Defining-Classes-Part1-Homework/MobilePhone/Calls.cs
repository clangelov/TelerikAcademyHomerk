/*
 * Problem 8. Calls
 * Create a class Call to hold a call performed through a GSM.
 * It should contain date, time, dialled phone number and duration (in seconds).
*/
namespace MobilePhone
{
    using System;
    using System.Text;
    public class Calls
    {
        private const string PhoneCode = "+359";

        private DateTime dateTime;
        private string phoneNumber;
        private int callDuration;

        public Calls(string phoneNumber, int callDuration)
        {
            this.dateTime = DateTime.Now;
            this.PhoneNumber = PhoneCode + phoneNumber;
            this.CallDuration = callDuration;
        }

        public DateTime DateTime { get; private set; }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                if (value.Length < 4 || value.Length > 13)
                {
                    throw new ArgumentOutOfRangeException("The Phone number length should be between 4 and 9 digits");
                }
                this.phoneNumber = value;
            }
        }

        public int CallDuration
        {
            get
            {
                return this.callDuration;
            }
            set
            {
                if (value < 1 || value > 180000)
                {
                    throw new ArgumentOutOfRangeException("The Call Duration can not be shorter than 1 sec and there is no battery that can support longer conversations than 180000 sec");
                }
                this.callDuration = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Information about the Call:");
            result.AppendFormat("On {0:d} you dialed {1} and talked for {2} sec."
                , dateTime, PhoneNumber, callDuration);

            return result.ToString();
        }
    }  
}
