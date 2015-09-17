namespace DecoratorVehicleDemo.Decorators
{    
    using System;

    using DecoratorVehicleDemo.Component;

    internal class NavigationSystemDecorator : VehicleDecorator
    {
        private const decimal NavSystemPrice = 5500;

        public NavigationSystemDecorator(VehicleComponent vehicle)
            : base(vehicle)
        {
            this.Vehicle.UpdatePrice(NavSystemPrice);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("++ Navigation System Included");
        }
    }
}
