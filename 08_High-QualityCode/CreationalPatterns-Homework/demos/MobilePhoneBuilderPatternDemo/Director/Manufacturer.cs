namespace MobilePhoneBuilderPatternDemo.Director
{
    using MobilePhoneBuilderPatternDemo.Builders;

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
}
