using System.Linq;
using System.Web.Mvc;


namespace quote_calculation_Application.Controllers
{
   
   
    public class AdminController : Controller
    {
        private InsuranceDBEntities db = new InsuranceDBEntities();


        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {
            using (var db = new InsuranceDBEntities())
            {
                var insurees = db.Insurees.ToList().AsEnumerable(); // Convert List to IEnumerable
                return View(insurees);
            }
        }

        public ActionResult Details(int id)
        {
            var insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        public ActionResult Delete(int id)
        {
            var insuree = db.Insurees.Find(id);
            if (insuree != null)
            {
                db.Insurees.Remove(insuree);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
             
           


                if (email == "Admin@gmail.com" && password == "123456")
                {
                    return RedirectToAction("Index", "Admin"); 
                }
                else
                {
                    return RedirectToAction("Create", "Insuree"); 
                }
          
          
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Admin model)
        {
            if (ModelState.IsValid)
            {
              
                    db.Admins.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Login");
               
            }
            return View(model);
        }

    }

}
