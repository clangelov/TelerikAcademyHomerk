namespace Twitter.MVC.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models;
    using Services.Data.Contracts;

    public class HomeController : Controller
    {
        private ITweetService tweetService;

        public HomeController(ITweetService tweetService)
        {
            this.tweetService = tweetService;
        }

        public ActionResult Index()
        {
            var latestTweets = this.tweetService
                .LastTen()
                .ProjectTo<TweetViewModel>();

            return View(latestTweets);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TweetPostModel model)
        {
            if (ModelState.IsValid)
            {
                var tags = model.Tags.Split().ToList();
                var user = this.User.Identity.Name;

                var test = this.tweetService.CrateTag(user, model.Content, tags);
                
                return this.RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize]
        [HttpGet]
        [OutputCache(Duration = 15 * 60, VaryByParam = "id")]
        public ActionResult Tag(string id)
        {
            var tweetsByTag = this.tweetService
                .ByTag(id)
                .ProjectTo<TweetViewModel>();

            return View(tweetsByTag);
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyTweets()
        {
            var myName = this.User.Identity.Name;

            var myTweets = this.tweetService
                .ByUser(myName)
                .ProjectTo<TweetViewModel>();

            return View(myTweets);
        }

    }
}