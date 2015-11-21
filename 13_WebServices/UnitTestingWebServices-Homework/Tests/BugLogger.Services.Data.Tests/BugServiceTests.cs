namespace BugLogger.Services.Data.Tests
{
    using System;
    using System.Linq;
    using Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestObjects;

    [TestClass]
    public class BugServiceTests
    {
        private IBugService bugsService;

        private InMemoryRepository<Bug> bugsRepo;

        [TestInitialize]
        public void Init()
        {
            this.bugsRepo = TestObjectFactory.GetBugRepository();

            this.bugsService = new BugService(bugsRepo);
        }

        [TestMethod]
        public void TestReturnAllIfReturnsQueryableOfBug()
        {
            var result = this.bugsService.All();

            Assert.IsInstanceOfType(result, typeof(IQueryable<Bug>));
        }

        [TestMethod]
        public void TestChangeBugStatusDoesNotTrowWithValidData()
        {
            this.bugsService.ChangeBugStatus(1, "Fixed");
        }

        [TestMethod]
        public void TestGetAfterValidDateToReturnCorrectAnswer()
        {
            var dateToCheck = new DateTime(2010, 10, 10);

            int expectedNumberOfBugs = 25;
            var result = this.bugsService.GetAfterDate(dateToCheck).ToList();

            Assert.AreEqual(expectedNumberOfBugs, result.Count());
        }

        [TestMethod]
        public void TestIfThereWillBeNoAnswersWithADateFromTheFarFuture()
        {
            var dateToCheck = new DateTime(2020, 10, 10);

            int expectedNumberOfBugs = 0;
            var actual = this.bugsService.GetAfterDate(dateToCheck).ToList();

            Assert.AreEqual(expectedNumberOfBugs, actual.Count);
        }

        [TestMethod]
        public void TestIfRetrunAllByGivenStatusWorksOK()
        {
            BugStatus status = BugStatus.Fixed;
            int expected = this.bugsRepo.All().Where(b => b.BugStatus == status).ToList().Count;

            var actual = this.bugsService.GetAllByStatus(status.ToString()).ToList();

            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestIfPostInvokeSaveChanges()
        {
            var result = this.bugsService.Post("Visual Studio 2015");

            Assert.AreEqual(1, this.bugsRepo.NumberOfSaves);
        }

        [TestMethod]
        public void TestIfPostPopulateBugsDatabase()
        {
            string bugName = "undefined is not a function";
            var result = this.bugsService.Post(bugName);

            var bug = this.bugsRepo.All().FirstOrDefault(pr => pr.Text == bugName);

            Assert.IsNotNull(bug);
            Assert.AreEqual(bugName, bug.Text);
            Assert.AreEqual(BugStatus.Pending, bug.BugStatus);
        }
    }
}
