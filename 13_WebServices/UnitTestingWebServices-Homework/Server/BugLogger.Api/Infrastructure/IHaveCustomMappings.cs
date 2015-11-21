namespace BugLogger.Api.Infrastructure
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration config);
    }
}
