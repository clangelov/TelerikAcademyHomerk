namespace BugLogger.Api.Tests.ControllerTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Services.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Controllers;
    using MyTested.WebApi;
    using Models;

    [TestClass]
    public class BugConteollerTestsWithMyTestedWebApi
    {
        private IControllerBuilder<BugController> controller;

        [TestInitialize]
        public void Initialize()
        {
            this.controller = MyWebApi
                .Controller<BugController>()
                .WithResolvedDependencyFor(ObjectFactory.GetBugService());
        }

        [TestMethod]
        public void TestIfGetAllWillReturnACollectionOfBugs()
        {
            this.controller
                 .Calling(c => c.Get())
                 .ShouldReturn()
                 .Ok()
                 .WithResponseModelOfType<List<BugResponcseModel>>()
                 .Passing(c => c.Count() == 2);
        }

        [TestMethod]
        public void TestIfGetByDateWillReturnBadRequestWithEmtyData()
        {
            this.controller
                 .Calling(c => c.GetByDate(null))
                 .ShouldReturn()
                 .BadRequest();
        }

        [TestMethod]
        public void TestifGetByDateWorksCorrectly()
        {
            this.controller
                .Calling(c => c.GetByDate("2010-10-10"))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<BugResponcseModel>>()
                .Passing(c => c.Count() == 2);
        }

        [TestMethod]
        public void TestifGetByDateWorksWithDateFromTheFuture()
        {
            this.controller
                .Calling(c => c.GetByDate("2017-10-10"))
                .ShouldReturn()
                .NotFound();
        }


        [TestMethod]
        public void TestIfGetByStatusWillReturnBadRequestWithEmtyData()
        {
            this.controller
                .Calling(c => c.GetByStatus(null))
                .ShouldReturn()
                .BadRequest();
        }

        [TestMethod]
        public void TestifGetByStatusWorksCorrectly()
        {
            this.controller
                .Calling(c => c.GetByStatus("Fixed"))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<BugResponcseModel>>()
                .Passing(c => c.Count() == 2);
        }

        [TestMethod]
        public void TestIfPostIsValidatingModel()
        {
            var model = ObjectFactory.GetInvalidModel();

            this.controller
                .Calling(c => c.PostNewBug(model))
                .ShouldReturn()
                .BadRequest();
        }

        [TestMethod]
        public void TestIfPostWithValidModelWillWork()
        {
            var model = ObjectFactory.GetValidModel();

            this.controller
               .Calling(c => c.PostNewBug(model))
               .ShouldReturn()
               .Ok()
               .WithResponseModelOfType<int>()
               .Passing(c => c == 1);
        }

        [TestMethod]
        public void TestIfupdateStatusIsValidatingTheStatus()
        {
            this.controller
                .Calling(c => c.PutStatus(1, null))
                .ShouldReturn()
                .BadRequest();
        }

        [TestMethod]
        public void TestIfupdateStatusIsCalled()
        {
            this.controller
               .Calling(c => c.PutStatus(1, "Resolved"))
               .ShouldReturn()
               .Ok();
        }
    }
}
