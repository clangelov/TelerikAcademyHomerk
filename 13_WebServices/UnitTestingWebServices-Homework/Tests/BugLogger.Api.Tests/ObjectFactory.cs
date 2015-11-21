namespace BugLogger.Api.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using BugLogger.Models;
    using Moq;
    using Services.Data;

    public static class ObjectFactory
    {
        public static IQueryable<Bug> bugs = new List<Bug>
        {
            new Bug
            {
                Logged = new DateTime(2015, 11, 5, 23, 47, 12),
                Text = "Test Description",
                Id = 1
            },
            new Bug
            {
                Logged = new DateTime(2015, 11, 5, 23, 47, 12),
                Text = "Test Bug",
                Id = 2
            }
        }.AsQueryable();

        public static IBugService GetBugService()
        {
            var bugsService = new Mock<IBugService>();

            bugsService.Setup(pr => pr.All())
                .Returns(bugs);

            bugsService.Setup(pr => pr.GetAfterDate(
                    It.Is<DateTime>(d => d < new DateTime(2015,11,5))))
                .Returns(bugs);

            bugsService.Setup(pr => pr.GetAllByStatus(
                    It.IsAny<string>()))
                .Returns(bugs);

            bugsService.Setup(pr => pr.Post(
                    It.IsAny<string>()))
                .Returns(1);

            bugsService.Setup(pr => pr.ChangeBugStatus(
                It.IsAny<int>(),
                It.IsAny<string>()))
                .Verifiable();

            return bugsService.Object;
        }

        public static SaveBugModel GetValidModel()
        {
            return new SaveBugModel {Text = "A valid bug" };
        }

        public static SaveBugModel GetInvalidModel()
        {
            return new SaveBugModel();
        }
    }
}
