namespace Task01.MobileSearch.Models
{
    using System.Collections.Generic;
    
    public class Producer
    {
        public IEnumerable<string> Models { get; set; }

        public string Name { get; set; }

        public static IEnumerable<Producer> GetProducers()
        {
            return new List<Producer>()
            {
                new Producer()
                {
                    Name = "BMW",
                    Models = new List<string>() { "530xd", "Z4", "X6" }
                },
                new Producer()
                {
                    Name = "Mercedes",
                    Models = new List<string>() { "E 63 AMG", "SL 500", "GLA 220" }

                },
                new Producer()
                {
                    Name = "Jaguar",
                    Models = new List<string>() { "XF", "XJ", "Insighnia" }
                }
            };
        }
    }
}