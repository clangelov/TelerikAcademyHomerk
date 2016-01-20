namespace SumNumbersInMVC.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index(int? sum)
        {
            this.ViewBag.Sum = "Result is " + sum;
            return this.View();
        }

        public ActionResult Sum(int firstNumber, int secondNumber)
        {
            return this.RedirectToAction("Index", new { sum = firstNumber + secondNumber });
        }
    }
}