namespace Task03.MVCApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class DepartmentController : Controller
    {
        TelerikAcademyEntities dbContext = new TelerikAcademyEntities();

        public ActionResult All()
        {
            var departments = dbContext.Departments
                .OrderByDescending(x => x.Employees.Count)
                .ToList();

            return View(departments);
        }
    }
}