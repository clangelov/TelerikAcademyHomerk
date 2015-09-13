namespace AircraftObjectPoolDemo
{
    using System;
    using System.Threading;

    using AircraftObjectPoolDemo.Hangar;
    using AircraftObjectPoolDemo.Objects;    
    
    public class Client
    {
        public static void Main()
        {
            var grafIgnatievo = new Hangar<Airplane>();

            var equipment1 = grafIgnatievo.GetAircraft();
            equipment1.PilotName = "Bubi Hartmann";
            Console.WriteLine(
                "Airplane 1 ordered on {0:MM/dd/yyyy hh:mm:ss.fff tt} used by {1}",
                equipment1.RequestedAt,
                equipment1.PilotName);
            Thread.Sleep(2000);

            var equipment2 = grafIgnatievo.GetAircraft();
            equipment1.PilotName = "Chuck DeBellevue";
            Console.WriteLine(
                "Airplane 2 ordered on {0:MM/dd/yyyy hh:mm:ss.fff tt} used by {1}",
                equipment2.RequestedAt,
                equipment1.PilotName);
            Thread.Sleep(2000);

            grafIgnatievo.ReleaseEquipment(equipment1);

            equipment1.PilotName = "Ilmari Juutilainen";
            Console.WriteLine(
                "Airplane 3 ordered on {0:MM/dd/yyyy hh:mm:ss.fff tt} used by {1}",
                equipment1.RequestedAt,
                equipment1.PilotName);
            Thread.Sleep(2000);
        }
    }
}
