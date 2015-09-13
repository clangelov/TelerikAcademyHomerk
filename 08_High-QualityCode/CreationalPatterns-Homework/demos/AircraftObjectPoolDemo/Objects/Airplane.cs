namespace AircraftObjectPoolDemo.Objects
{
    using System;

    public class Airplane : IDisposable
    {
        private readonly DateTime requestedAt = DateTime.Now;

        public DateTime RequestedAt
        {
            get { return this.requestedAt; }
        }

        public string PilotName { get; set; }

        public void Dispose()
        {
            this.PilotName = null;
        }
    }
}
