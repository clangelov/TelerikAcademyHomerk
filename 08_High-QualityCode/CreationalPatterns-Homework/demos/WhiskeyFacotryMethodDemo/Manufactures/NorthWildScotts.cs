namespace WhiskeyFacotryMethodDemo.Manufactures
{
    using WhiskeyFacotryMethodDemo.Products;

    public class NorthWildScotts : Distillery
    {
        public override AlcoholicBeverage MakeDrink()
        {
            var drink = new Whisky { Taste = "Very Smoky", YearsMatured = 12 };
            return drink;
        }
    }
}
