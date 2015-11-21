namespace BugLogger.Api.Tests
{
    using System.Reflection;
    using System.Web.Http;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MyTested.WebApi;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("BugLogger.Api"));

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            MyWebApi.IsUsing(config);
        }
    }
}
