namespace DecoratorVehicleDemo
{    
    using System;

    using DecoratorVehicleDemo.Component;
    using DecoratorVehicleDemo.Decorators;

    public class Client
    {
        public static void Main()
        {
            // Creating a car
            var basicCar = new Car("BMW", 85000);
            basicCar.DisplayInfo();
            LineSeparator();

            // Adding one option
            var updatedCar = new LeatherInteriorDecorator(basicCar);
            updatedCar.DisplayInfo();
            LineSeparator();

            // Adding all options
            var superCar = new V8EngineDecorator(new NavigationSystemDecorator(updatedCar));
            superCar.DisplayInfo();
            superCar.DriveOnTrack();
            LineSeparator();
        }

        private static void LineSeparator()
        {
            Console.WriteLine(new string('-', 50));
        }
    }
}
