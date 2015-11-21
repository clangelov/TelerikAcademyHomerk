namespace BugLogger.Api.Tests.RouteTests
{
    using System.Net.Http;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;

    [TestClass]
    public class BugControllerRouteTests
    {
        [TestMethod]
        public void GetAllShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Bug")
                .To<BugController>(b => b.Get());
        }

        [TestMethod]
        public void GetGetByDateShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Bug?date=2015-10-10")
                .To<BugController>(b => b.GetByDate("2015-10-10"));
        }

        [TestMethod]
        public void GetGetByStatusShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Bug?status=Test")
                .To<BugController>(b => b.GetByStatus("Test"));
        }

        [TestMethod]
        public void PostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Bug")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Text"": ""Can't Kill all Zergs"" }")
                .ToValidModelState();
        }

        [TestMethod]
        public void PostShouldMapCorrectlyWithInvalidModel()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/Bug")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Invalid"": ""Invalid"" }")
                .ToInvalidModelState();
        }
    }
}
