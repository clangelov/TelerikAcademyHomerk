namespace DecoratorVehicleDemo.Component
{
    using System;

    public class SUV : VehicleComponent
    {
        public SUV(string brand, decimal price)
        {
            this.Brand = brand;
            this.Price = price;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("{0} -----", this.GetType().Name);
            Console.WriteLine("Brand: {0}", this.Brand);
            Console.WriteLine("Price: {0}", this.Price);
        }

        public override void UpdatePrice(decimal updateCost)
        {
            this.Price += updateCost;
        }
    }
}
