namespace Task01.MobileSearch.Models
{
    using System.Collections.Generic;

    public class Extra
    {
        public string Name { get; set; }

        public static IEnumerable<Extra> GetExtras()
        {        
            return new List<Extra>()
            {
                new Extra() { Name = "Electring windows"},
                new Extra() { Name = "Cruise control"},
                new Extra() { Name = "Sunroof"},
                new Extra() { Name = "Electric heated seats"},
                new Extra() { Name = "Navigation system"},
                new Extra() { Name = "On-board computer"},
                new Extra() { Name = "Adaptive lighting"},
                new Extra() { Name = "Xenon headlights"},
            };
}
    }
}