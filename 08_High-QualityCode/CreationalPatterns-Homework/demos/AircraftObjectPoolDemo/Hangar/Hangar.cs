namespace AircraftObjectPoolDemo.Hangar
{
    using System;
    using System.Collections.Generic;

    public class Hangar<T> where T : IDisposable, new()
    {
        private readonly List<T> availableAircarfts = new List<T>();
        private readonly List<T> aircraftsInUse = new List<T>();

        public Hangar()
        {
        }

        public T GetAircraft()
        {
            lock (this.availableAircarfts)
            {
                if (this.availableAircarfts.Count != 0)
                {
                    var equipment = this.availableAircarfts[0];
                    this.aircraftsInUse.Add(equipment);
                    this.availableAircarfts.RemoveAt(0);
                    return equipment;
                }
                else
                {
                    var equipment = new T();
                    this.aircraftsInUse.Add(equipment);
                    return equipment;
                }
            }
        }

        public void ReleaseEquipment(T equipment)
        {
            equipment.Dispose();

            lock (this.availableAircarfts)
            {
                this.availableAircarfts.Add(equipment);
                this.aircraftsInUse.Remove(equipment);
            }
        }
    }
}
