namespace _08.Events
{
    using System;
    class Publisher
    {
        // Declare the event using EventHandler<T> 
        public event EventHandler<EventInfo> RaiseCustomEvent;

        public void PrintSomeText()
        {
            // A useless method
            OnRaiseCustomEvent(new EventInfo("Event rised"));
        }

        // Wrap event invocations inside a protected virtual method 
        // to allow derived classes to override the event invocation behavior 
        protected virtual void OnRaiseCustomEvent(EventInfo e)
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler<EventInfo> handler = RaiseCustomEvent;

            // Event will be null if there are no subscribers 
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += String.Format(" at {0}", DateTime.Now.ToString());

                // Use the () operator to raise the event.
                handler(this, e);
            }
        }
    }
}
