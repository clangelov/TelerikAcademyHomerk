namespace DecoratorVehicleDemo.Decorators
{    
    using System;

    using DecoratorVehicleDemo.Component;

    internal abstract class VehicleDecorator : VehicleComponent
    {
        protected VehicleDecorator(VehicleComponent vehicle)
        {
            this.Vehicle = vehicle;
        }

        protected VehicleComponent Vehicle { get; set; }

        public override void DisplayInfo()
        {
            this.Vehicle.DisplayInfo();
        }

        public override void UpdatePrice(decimal updateCost)
        {
            this.Vehicle.UpdatePrice(updateCost);
        }
    }
}
