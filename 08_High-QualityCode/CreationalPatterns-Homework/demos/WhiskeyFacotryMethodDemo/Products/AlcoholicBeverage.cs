namespace WhiskeyFacotryMethodDemo.Products
{
    using System.Text;

    public abstract class AlcoholicBeverage
    {
        public string Taste { get; set; }

        public int YearsMatured { get; set; }

        public string CountryOfOrigin { get; protected set; }

        public override string ToString()
        {
            var drinkAsString = new StringBuilder();
            drinkAsString.AppendFormat("Drink type: {0}", this.GetType().Name);
            drinkAsString.AppendLine();
            drinkAsString.AppendFormat("Tastes: {0}", this.Taste);
            drinkAsString.AppendLine();
            drinkAsString.AppendFormat("Matured for: {0} years", this.YearsMatured);
            drinkAsString.AppendLine();
            drinkAsString.AppendFormat("Made in: {0}", this.CountryOfOrigin);
            return drinkAsString.ToString();
        }
    }
}
