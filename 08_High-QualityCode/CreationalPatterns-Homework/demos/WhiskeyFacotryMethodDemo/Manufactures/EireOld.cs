namespace WhiskeyFacotryMethodDemo.Manufactures
{
    using WhiskeyFacotryMethodDemo.Products;

    public class EireOld : Distillery
    {
        public override AlcoholicBeverage MakeDrink()
        {
            var drink = new Whiskey { Taste = "Very Balanced", YearsMatured = 7 };
            return drink;
        }
    }
}
