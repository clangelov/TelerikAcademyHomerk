# Builder
### Creational Design Pattern

## Описание
Служи за създаване на обекти, при които е важна последователността на инициализиране на различните компоненти на обекта.
В общия случай различните компоненти са взаимно зависими, което налага определена последователност при създаването им.
Целта е да се раздели създаването на сложен обект от неговото представяне (интерфейс), за да може с един и същ процес да се създават обекти с различно представяне.
Често в практиката може след прилагането на Factory Method, да се надгради съществуващия код към използването на Builder, който е по-гъвкавия и сложен шаблон за дизайн.

## Решава следните проиблеми
* Наличието на твърде много параметри в конструктура
* Зависимост от последователността за изпълнение

## Implemntation
Кратко демо за създаването на мобилни телефони

![alt text](diagrams/builder.png)

###### public class Manufacturer – Играе ролята на Director, който определя последователността на стъпки по които трябва да се създаде един мобилен телфон
~~~c#
public class Manufacturer
    {
        public void Construct(PhoneBuilder phoneBuilder)
        {
            phoneBuilder.BuildBattery();            
            phoneBuilder.BuildScreen();
            phoneBuilder.BuildOS();
            phoneBuilder.PutPrice();
        }
    }
~~~

###### abstract class PhoneBuilder Играе ролята на Builder, определя от каков се състои един мобилен телефон
~~~c#
public abstract class PhoneBuilder
    {
        public Phone Phone { get; set; }

        public abstract void BuildBattery();

        public abstract void BuildScreen();

        public abstract void BuildOS();

        public abstract void PutPrice();
    }
~~~

###### public class SmartElectronics наследява Builder-а и дефинира собствените параметри на създавания обект
~~~c#
public class SmartElectronics : PhoneBuilder
    {
        public SmartElectronics()
        {
            this.Phone = new Phone("Smart Electronics");
        }

        public override void BuildBattery()
        {
            this.Phone["battery"] = "Li-Ion 1500 Mah";
        }

        public override void BuildScreen()
        {
            this.Phone["screen"] = "5\" OLDED";
        }

        public override void BuildOS()
        {
            this.Phone["os"] = "Android";
        }

        public override void PutPrice()
        {
            this.Phone["price"] = "$499";
        }
    }
~~~

###### public class Phone - продукта който се създава
~~~c#
public class Phone
    {
        private readonly string phoneManufacturer;
        private readonly Dictionary<string, string> info = new Dictionary<string, string>();

        public Phone(string vehicleType)
        {
            this.phoneManufacturer = vehicleType;
        }

        public string this[string key]
        {
            get { return this.info[key]; }
            set { this.info[key] = value; }
        }

        public void ShowInfo()
        {
            Console.WriteLine(new string('*', 30));
            Console.WriteLine("Phone Manufacturer: {0}", this.phoneManufacturer);
            Console.WriteLine(" Battery  : {0}", this.info["battery"]);
            Console.WriteLine(" Screen : {0}", this.info["screen"]);
            Console.WriteLine(" OS: {0}", this.info["os"]);
            Console.WriteLine(" Price : {0}", this.info["price"]);
            Console.WriteLine(new string('*', 30));
        }
    }
~~~

###### Използване от страна на клиента
~~~c#
public class Client
    {
        public static void Main()
        {
            PhoneBuilder builder;

            // We can choose concrete constructor (director)
            var constructor = new Manufacturer();

            // And we can choose concrete builder
            builder = new ShinyTech();
            constructor.Construct(builder);
            builder.Phone.ShowInfo();

            builder = new SmartElectronics();
            constructor.Construct(builder);
            builder.Phone.ShowInfo();
        }
    }
~~~

###### Демо: [Link to GitHub] https://github.com/clangelov/TelerikAcademyHomework/tree/master/08_High-QualityCode/CreationalPatterns-Homework/demos/MobilePhoneBuilderPatternDemo
