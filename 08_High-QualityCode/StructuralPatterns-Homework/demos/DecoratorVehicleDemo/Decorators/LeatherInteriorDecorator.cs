namespace DecoratorVehicleDemo.Decorators
{
    using System;

    using DecoratorVehicleDemo.Component;

    internal class LeatherInteriorDecorator : VehicleDecorator
    {
        private const decimal LeatherInteriorPrice = 7500;

        public LeatherInteriorDecorator(VehicleComponent vehicle)
            : base(vehicle)
        {
            this.Vehicle.UpdatePrice(LeatherInteriorPrice);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("++ Leather Interior Included");
        }
    }
}
