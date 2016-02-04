namespace Movies.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Models;
    using Services.Data.Contracts;

    public class MovieController : Controller
    {
        private IActorService actorService;

        private IMovieService movieService;

        public MovieController(IActorService actorService, IMovieService movieService)
        {
            this.actorService = actorService;
            this.movieService = movieService;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.movieService.DeleteById(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index()
        {
            var movies = this.movieService
                .All()
                .ProjectTo<MovieViewModel>();

            return View(movies);
        }        

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var femaleId = this.actorService.GetByName(model.FemaleActorName);
                var maleId = this.actorService.GetByName(model.MaleActorName);

                if (femaleId == -1 || maleId == -1)
                {
                    ViewBag.NoActor = "There are no such Actors";
                    return View(model); 
                }

                this.movieService.CreateMovie(model.Title, model.Year, model.Director, maleId, femaleId);

                return this.RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = this.movieService
                .GetById(id);

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie model)
        {
            if (ModelState.IsValid)
            {
                var movieToUpdate = this.movieService.GetById(model.Id);

                movieToUpdate.Title = model.Title;
                movieToUpdate.Year = model.Year;
                movieToUpdate.Director = model.Director;

                this.movieService.Update(movieToUpdate);

                return this.RedirectToAction("Index");
            }

            return View(model);
        }
    }
}