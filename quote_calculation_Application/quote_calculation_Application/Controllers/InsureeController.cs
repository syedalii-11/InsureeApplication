using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using quote_calculation_Application.Models;

namespace quote_calculation_Application.Controllers
{
    public class InsureeController : Controller
    {
       // private readonly InsuranceDBEntities _context;
        private InsuranceDBEntities db = new InsuranceDBEntities();
        //public InsureeController(InsuranceDBEntities context)
        //{
        //    _context = context;
        //}

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.QuoteAmount = CalculateQuote(insuree);
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(insuree);
        }

      

      

       private decimal CalculateQuote(Insuree insuree)
        {
            decimal quote = 50m; // Base rate

            // Age-based price adjustment
            int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
            if (insuree.DateOfBirth > DateTime.Now.AddYears(-age)) age--; // Adjust for birthday

            if (age <= 18)
                quote += 100m;
            else if (age >= 19 && age <= 25)
                quote += 50m;
            else
                quote += 25m;

            // Car Year
            if (insuree.CarYear < 2000)
                quote += 25m;
            else if (insuree.CarYear > 2015)
                quote += 25m;

            // Car Make & Model
            if (insuree.CarMake.ToLower() == "porsche")
            {
                quote += 25m;
                if (insuree.CarModel.ToLower() == "911 carrera")
                    quote += 25m; // Additional charge for 911 Carrera
            }

            // Speeding Tickets
            quote += Convert.ToDecimal(insuree.SpeedingTickets * 10m);

            // DUI
            if (Convert.ToBoolean(insuree.HasDUI))
                quote *= 1.25m; // Increases by 25%

            // Full Coverage
            if (Convert.ToBoolean(insuree.IsFullCoverage))
                quote *= 1.50m; // Increases by 50%

            return quote;
        }
    }
}