namespace Task03.MVCApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class TownController : Controller
    {
        TelerikAcademyEntities dbContext = new TelerikAcademyEntities();

        public ActionResult All()
        {
            var towns = dbContext.Towns
                .ToList();

            return View(towns);
        }
    }
}