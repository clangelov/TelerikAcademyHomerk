namespace MobilePhoneBuilderPatternDemo.Builders
{
    public abstract class PhoneBuilder
    {
        public Phone Phone { get; set; }

        public abstract void BuildBattery();

        public abstract void BuildScreen();

        public abstract void BuildOS();

        public abstract void PutPrice();
    }
}
