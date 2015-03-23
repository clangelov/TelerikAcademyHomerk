namespace _08.Events
{
    using System;
    class EventInfo : EventArgs
    {
        private string message;
        public EventInfo(string message)
        {
            this.Message = message;
        }  
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
