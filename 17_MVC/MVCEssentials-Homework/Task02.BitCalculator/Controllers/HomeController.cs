namespace Task02.BitCalculator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index(int quantity = 1, string type = "Bit", int kilo = 1024)
        {
            ViewBag.SelectedType = type;
            ViewBag.SelectedKilo = kilo;
            ViewBag.Quantity = quantity;
            double baseValue = this.BaseValue(kilo, type);
            var units = this.GetValues(kilo, quantity, baseValue);
            return View(units);
        }

        [NonAction]
        private List<DataViewModel> GetValues(int baseValue, int quantity, double typeBase)
        {
            var listOfUnits = new List<DataViewModel>()
            {
                new DataViewModel(){ Name = "Bit", Value = quantity / (Math.Pow(baseValue, 0)/typeBase) * 8},
                new DataViewModel(){ Name = "Byte", Value = quantity / (Math.Pow(baseValue, 0)/typeBase)},
                new DataViewModel(){ Name = "Kilobit", Value = quantity / (Math.Pow(baseValue, 1)/typeBase) * 8},
                new DataViewModel(){ Name = "Kilobyte", Value = quantity / (Math.Pow(baseValue, 1)/typeBase)},
                new DataViewModel(){ Name = "Megabit", Value = quantity / (Math.Pow(baseValue, 2)/typeBase) * 8},
                new DataViewModel(){ Name = "Megabyte", Value = quantity / (Math.Pow(baseValue, 2)/typeBase)},
                new DataViewModel(){ Name = "Gigabit", Value = quantity / (Math.Pow(baseValue, 3)/typeBase) * 8},
                new DataViewModel(){ Name = "Gigabyte", Value = quantity / (Math.Pow(baseValue, 3)/typeBase)},
                new DataViewModel(){ Name = "Terabit", Value = quantity / (Math.Pow(baseValue, 4)/typeBase) * 8},
                new DataViewModel(){ Name = "Terabyte", Value = quantity / (Math.Pow(baseValue, 4)/typeBase)},
                new DataViewModel(){ Name = "Petabit", Value =  quantity / (Math.Pow(baseValue, 5)/typeBase) * 8},
                new DataViewModel(){ Name = "Petabyte", Value = quantity / (Math.Pow(baseValue, 5)/typeBase)},
                new DataViewModel(){ Name = "Exabit", Value = quantity / (Math.Pow(baseValue, 6)/typeBase) * 8},
                new DataViewModel(){ Name = "Exabyte", Value = quantity / (Math.Pow(baseValue, 6)/typeBase)},
                new DataViewModel(){ Name = "Zettabit", Value = quantity / (Math.Pow(baseValue, 7)/typeBase) * 8},
                new DataViewModel(){ Name = "Zettabyte", Value = quantity / (Math.Pow(baseValue, 7)/typeBase)},
                new DataViewModel(){ Name = "Yottabit", Value = quantity / (Math.Pow(baseValue, 8)/typeBase) * 8},
                new DataViewModel(){ Name = "Yottabyte", Value = quantity / (Math.Pow(baseValue, 8)/typeBase)},
            };

            return listOfUnits;
        }

        [NonAction]
        private double BaseValue(int baseValue, string typeOfUnit)
        {
            var listOfEntities = new List<DataViewModel>()
            {
                new DataViewModel(){ Name = "Bit", Value = (Math.Pow(baseValue, 0)/8)},
                new DataViewModel(){ Name = "Byte", Value =  (Math.Pow(baseValue, 0))},
                new DataViewModel(){ Name = "Kilobit", Value =  (Math.Pow(baseValue, 1)/8)},
                new DataViewModel(){ Name = "Kilobyte", Value = (Math.Pow(baseValue, 1))},
                new DataViewModel(){ Name = "Megabit", Value = (Math.Pow(baseValue, 2)/8)},
                new DataViewModel(){ Name = "Megabyte", Value = (Math.Pow(baseValue, 2))},
                new DataViewModel(){ Name = "Gigabit", Value = (Math.Pow(baseValue, 3)/8)},
                new DataViewModel(){ Name = "Gigabyte", Value = (Math.Pow(baseValue, 3))},
                new DataViewModel(){ Name = "Terabit", Value = (Math.Pow(baseValue, 4)/8)},
                new DataViewModel(){ Name = "Terabyte", Value = (Math.Pow(baseValue, 4))},
                new DataViewModel(){ Name = "Petabit", Value =  (Math.Pow(baseValue, 5)/8)},
                new DataViewModel(){ Name = "Petabyte", Value = (Math.Pow(baseValue, 5))},
                new DataViewModel(){ Name = "Exabit", Value = (Math.Pow(baseValue, 6)/8)},
                new DataViewModel(){ Name = "Exabyte", Value = (Math.Pow(baseValue, 6))},
                new DataViewModel(){ Name = "Zettabit", Value = (Math.Pow(baseValue, 7)/8)},
                new DataViewModel(){ Name = "Zettabyte", Value = (Math.Pow(baseValue, 7))},
                new DataViewModel(){ Name = "Yottabit", Value = (Math.Pow(baseValue, 8)/8)},
                new DataViewModel(){ Name = "Yottabyte", Value = (Math.Pow(baseValue, 8))},
            };

            double value = listOfEntities.FirstOrDefault(u => u.Name == typeOfUnit).Value;

            return value;
        }
    }
}