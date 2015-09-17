namespace DecoratorVehicleDemo.Decorators
{
    using System;

    using DecoratorVehicleDemo.Component;

    internal class V8EngineDecorator : VehicleDecorator
    {
         private const decimal V8EnginePrice = 27250;

         public V8EngineDecorator(VehicleComponent vehicle)
            : base(vehicle)
        {
            this.Vehicle.UpdatePrice(V8EnginePrice);            
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("++ Powerful V8 Engine Included");
        }

        public void DriveOnTrack()
        {
            Console.WriteLine("Driving around the local racing track");
        }
    }
}
