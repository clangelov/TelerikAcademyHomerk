namespace BugLogger.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using BugLogger.Api.Infrastructure;
    using BugLogger.Models;

    public class BugResponcseModel : IMapFrom<Bug>, IHaveCustomMappings
    {
        [Required]
        [MaxLength(100)]
        public string Text { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/2015", "31/12/2050")]
        public DateTime Logged { get; set; }

        public string BugStatus { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Bug, BugResponcseModel>()
                .ForMember(s => s.BugStatus, opts => opts.MapFrom(s => s.BugStatus.ToString()));
        }
    }
}