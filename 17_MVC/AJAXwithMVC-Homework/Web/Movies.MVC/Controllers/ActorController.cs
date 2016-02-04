namespace Movies.MVC.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Services.Data.Contracts;

    public class ActorController : Controller
    {
        private IActorService actorService;

        public ActorController(IActorService actorService)
        {
            this.actorService = actorService;
        }

        public ActionResult Index()
        {
            var actors = this.actorService.All();

            return View(actors);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            this.actorService.DeleteById(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor model)
        {
            if (ModelState.IsValid)
            {
                if (model.Studio == null)
                {
                    model.Studio = "No Studio";
                }

                if (model.StudioAdress == null)
                {
                    model.StudioAdress = "No Studio Adress";
                }

                var result = this.actorService.CreateActor(model.Name, model.Age, model.Studio, model.StudioAdress);
                return this.RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var actor = this.actorService
                .GetById(id);

            return View(actor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor model)
        {
            if (ModelState.IsValid)
            {
                var actorToUpdate = this.actorService.GetById(model.Id);

                actorToUpdate.Name = model.Name;
                actorToUpdate.Studio = model.Studio;
                actorToUpdate.StudioAdress = model.StudioAdress;

                this.actorService.Update(actorToUpdate);

                return this.RedirectToAction("Index");
            }

            return View(model);
        }
    }
}