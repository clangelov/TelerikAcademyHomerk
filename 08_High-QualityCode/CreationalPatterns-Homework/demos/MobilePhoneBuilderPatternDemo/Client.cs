namespace MobilePhoneBuilderPatternDemo
{
    using MobilePhoneBuilderPatternDemo.Builders;
    using MobilePhoneBuilderPatternDemo.Director;

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
}
