namespace Movies.MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Movies.Data.Models;
    using Movies.MVC.Infrastructure.Mappings;

    public class MovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string MaleActorName { get; set; }

        public string FemaleActorName { get; set; }

        public int Year { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Movie, MovieViewModel>(this.GetType().Name)
               .ForMember(u => u.MaleActorName, opts => opts.MapFrom(x => x.MaleActor.Name))
               .ForMember(u => u.FemaleActorName, opts => opts.MapFrom(x => x.FemaleActor.Name));
        }
    }
}