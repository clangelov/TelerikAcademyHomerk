namespace MobilePhoneBuilderPatternDemo.Builders
{
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
}
