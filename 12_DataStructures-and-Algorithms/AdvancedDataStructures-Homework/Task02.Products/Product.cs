namespace Task02.Products
{
    using System;

    public class Product : IComparable
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("You can not pass null as parameter");
            }

            var other = (Product)obj;

            int compareResult = this.Price.CompareTo(other.Price);

            return compareResult;
        }
    }
}
