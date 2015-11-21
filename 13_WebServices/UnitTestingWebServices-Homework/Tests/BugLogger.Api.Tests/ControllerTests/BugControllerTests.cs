namespace BugLogger.Api.Tests.ControllerTests
{
    using System.Collections.Generic;
    using Services.Data;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Http;
    using Models;
    using System.Web.Http.Results;

    [TestClass]
    public class BugControllerTests
    {
        private IBugService bugService;
        private BugController controller;

        [TestInitialize]
        public void Init()
        {
            this.bugService = ObjectFactory.GetBugService();
            this.controller = new BugController(this.bugService);
            this.controller.Configuration = new HttpConfiguration();
        }

        [TestMethod]
        public void TestIfGetAllWillReturnACollectionOfBugs()
        {
            var result = this.controller.Get();

            var okResult = result as OkNegotiatedContentResult<List<BugResponcseModel>>;

            Assert.IsNotNull(okResult);

            Assert.AreEqual(2, okResult.Content.Count);
        }

        [TestMethod]
        public void TestIfGetByDateWillReturnBadRequestWithEmtyData()
        {
            var result = this.controller.GetByDate(null);

            var badResult = result as BadRequestResult;

            Assert.IsNotNull(badResult);
        }

        [TestMethod]
        public void TestifGetByDateWorksCorrectly()
        {
            var result = this.controller.GetByDate("2010-10-10");

            var okResult = result as OkNegotiatedContentResult<List<BugResponcseModel>>;

            Assert.IsNotNull(okResult);

            Assert.AreEqual(2, okResult.Content.Count);
        }

        [TestMethod]
        public void TestIfGetByStatusWillReturnBadRequestWithEmtyData()
        {
            var result = this.controller.GetByStatus(null);

            var badResult = result as BadRequestResult;

            Assert.IsNotNull(badResult);
        }

        [TestMethod]
        public void TestifGetByStatusWorksCorrectly()
        {
            var result = this.controller.GetByStatus("Fixed");

            var okResult = result as OkNegotiatedContentResult<List<BugResponcseModel>>;

            Assert.IsNotNull(okResult);

            Assert.AreEqual(2, okResult.Content.Count);
        }

        [TestMethod]
        public void TestIfPostIsValidatingModel()
        {
            var model = ObjectFactory.GetInvalidModel();

            this.controller.Validate(model);

            var result = controller.PostNewBug(model);

            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [TestMethod]
        public void TestIfPostWithValidModelWillWork()
        {
            var model = ObjectFactory.GetValidModel();

            var result = controller.PostNewBug(model);

            var okResult = result as OkNegotiatedContentResult<int>;

            Assert.IsNotNull(okResult);

            Assert.AreEqual(1, okResult.Content);
        }

        [TestMethod]
        public void TestIfupdateStatusIsValidatingTheStatus()
        {
            var result = this.controller.PutStatus(1, null);

            var badResult = result as BadRequestResult;

            Assert.IsNotNull(badResult);
        }

        [TestMethod]
        public void TestIfupdateStatusIsCalled()
        {
            var result = this.controller.PutStatus(1, "Resolved");

            var okResult = result as OkResult;

            Assert.IsNotNull(okResult);
        }
    }
}
