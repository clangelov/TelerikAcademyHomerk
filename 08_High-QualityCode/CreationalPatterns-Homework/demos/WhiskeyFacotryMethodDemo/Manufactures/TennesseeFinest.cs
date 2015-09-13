namespace WhiskeyFacotryMethodDemo.Manufactures
{
    using WhiskeyFacotryMethodDemo.Products;

    public class TennesseeFinest : Distillery
    {
        public override AlcoholicBeverage MakeDrink()
        {
            var drink = new Bourbon { Taste = "Honey and Corn", YearsMatured = 5 };
            return drink;
        }
    }
}
