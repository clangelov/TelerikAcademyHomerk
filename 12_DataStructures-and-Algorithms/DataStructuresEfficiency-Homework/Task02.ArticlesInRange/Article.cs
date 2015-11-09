namespace Task02.ArticlesInRange
{
    using System;

    public class Article : IComparable<Article>
    {
        public int BarCode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Article other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("You can not pass null as parameter");
            }

            if (this.Price.CompareTo(other.Price) == 0)
            {
                if (this.Title.CompareTo(other.Title) == 0)
                {
                    return this.Vendor.CompareTo(other.Vendor);                    
                }

                return this.Title.CompareTo(other.Title);
            }

            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            string output = string.Format("{0}'s {1} price {2:C2}", this.Vendor, this.Title, this.Price);
            return output;
        }
    }
}
