namespace Task03.MVCApplication.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class TownController : Controller
    {
        TelerikAcademyEntities dbContext = new TelerikAcademyEntities();

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Town townToAdd)
        { 
            dbContext.Towns.Add(townToAdd);
            dbContext.SaveChanges();
            
            return PartialView("_Detail", townToAdd);
        }
    }
}