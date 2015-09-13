namespace MobilePhoneBuilderPatternDemo.Builders
{
    public class ShinyTech : PhoneBuilder
    {
        public ShinyTech()
        {
            this.Phone = new Phone("Shiny Tech");
        }

        public override void BuildBattery()
        {
            this.Phone["battery"] = "Li-Poll 2000 Mah";
        }

        public override void BuildScreen()
        {
            this.Phone["screen"] = "5.5\" AMOLED";
        }

        public override void BuildOS()
        {
            this.Phone["os"] = " iOS 99";
        }

        public override void PutPrice()
        {
            this.Phone["price"] = "$999";
        }
    }
}
