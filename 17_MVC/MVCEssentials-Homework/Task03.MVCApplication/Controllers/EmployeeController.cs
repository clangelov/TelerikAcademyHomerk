namespace Task03.MVCApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class EmployeeController : Controller
    {
        TelerikAcademyEntities dbContext = new TelerikAcademyEntities();

        public ActionResult TopPaid()
        {
            var employees = dbContext.Employees
                .OrderByDescending(x => x.Salary)
                .Take(10)
                .ToList();

            return View(employees);
        }

        public ActionResult Details(int id)
        {
            var employee = dbContext.Employees
                .Where(e => e.EmployeeID == id)
                .FirstOrDefault();

            return View(employee);
        }
    }
}