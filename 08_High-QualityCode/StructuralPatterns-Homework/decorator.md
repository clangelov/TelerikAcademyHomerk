# Decorator
### Structural Design Pattern

## Описание
Този шаблон за дизайн ни позволява да добавяме допълнителна функционалност към даден базов клас по време на изпълнението на нашата програма. Като това се случва без да се променя поведението на други обекти от същия клас.

Освновният плюс е че ни предпазва от това да създаваме нови под-класове за да добавим нова функционалност. Като за всеки даден вариант и комбинация да имаме отделн клас (в примера по-надолу това щеше да заничи да имаме по 6 подкласа за всяко превозно средство, за да покрием възможността да се комбинират 3 екстри)   

Същото така Decorator ни позволява да спазваме Open/Close принципа.


## Implemntation
Кратко демо за това как може да модифицираме дадено превозно средство

![alt text](diagrams/decorator.png)

###### public abstract class VehicleComponent – това е базовия клас както и за стандартните обекти, така и за тези които ще бъдат "декорирани". Ако нямаме някаква специфична функционалност може да използваме интерфейс 
~~~c#
public abstract class VehicleComponent
    {
        public string Brand { get; set; }

        public decimal Price { get; set; }

        public abstract void DisplayInfo();

        public abstract void UpdatePrice(decimal updateCost);
    }
~~~

###### public class Car е т.нар. Concrete Component клас. Той ще бъде изпозлван от декоратора за да му бъде добавена нова функционлност или да бъде модифициран. 
~~~c#
public class Car : VehicleComponent
    {
        public Car(string brand, decimal price)
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
~~~

###### internal abstract class VehicleDecorator - това е базовият клас за всички декоратори. Класа наследява VehicleComponent, за да може неговите наследници да го ползват вместо Concrete Components (в случая Car или SUV). Създава собствен конструктур който приема VehicleComponent, което ни позволява да подаваме дори други декоратори или различни наследници на базовия клас. 
~~~c#
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
~~~

###### internal class V8EngineDecorator - добавя допълнителни функционалност или информация за подадения му обект
~~~c#
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
~~~

###### Използване от страна на клиента - позволява ни лесно да комбинираме различните опции и лесно да изпозлваме нова функционалност. 
~~~c#
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
~~~

###### Демо: [Link to GitHub](https://github.com/clangelov/TelerikAcademyHomework/tree/master/08_High-QualityCode/StructuralPatterns-Homework/demos/DecoratorVehicleDemo)
