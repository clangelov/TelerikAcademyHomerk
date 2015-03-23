namespace _08.Events
{
    using System;
    class Subscriber
    {
        private string id;
        public Subscriber(string ID, Publisher pub)
        {
            id = ID;
            // Subscribe to the event using C# 2.0 syntax
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        // Define what actions to take when the event is raised. 
        void HandleCustomEvent(object sender, EventInfo e)
        {
            Console.WriteLine(id + " received this message: {0}", e.Message);
        }
    }
}
