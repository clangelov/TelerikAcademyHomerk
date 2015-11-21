namespace BugLogger.Services.Data.Tests.TestObjects
{
    using System;
    using BugLogger.Models;

    public static class TestObjectFactory
    {
        private static Random rand = new Random();

        public static InMemoryRepository<Bug> GetBugRepository(int numberOfBugs = 25)
        {
            var repo = new InMemoryRepository<Bug>();

            for (int i = 0; i < numberOfBugs; i++)
            {
                var date = new DateTime(2015, 11, 5, 23, 47, 12);
                date.AddDays(i);
                int bugStatus = rand.Next(0, 5);

                repo.Add(new Bug
                {
                    Id = i,
                    Logged = date,
                    Text = "Test Description " + i,
                    BugStatus = (BugStatus)bugStatus
                });
            }

            return repo;
        }
    }
}
