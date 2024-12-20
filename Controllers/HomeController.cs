using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MVCSelf1.Models;
using PartyInvites.Models;
using System.Linq;

namespace MVCSelf1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //          Due to below we test on the basic of book
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            ViewBag.Title = "Privacy";
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Test2()
        {
            return View();
        }

        public ActionResult About()
        {
            // Optionally, pass some data to the view
            ViewBag.Message = "Your application description page.";
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        //Product page render

        public IActionResult Product()
        {
            // Fetch dynamic product data from the database if necessary
            ViewBag.ProductName = "Sample Product";
            ViewBag.Description = "This is a sample product description.";
            return PartialView("Product");
        }

        public IActionResult ContactDetails()
        {
            ViewBag.ContactInfo = "You can reach us at contact@company.com.";
            return PartialView("_ContactDetails");
        }


        //2.9 form book##################################################################################################################################################
        public ViewResult RsvpForm()
        {
            return View();
        }

        //getting the input from the form

        [HttpPost]
        // public IActionResult RsvpForm(GuestResponse model)                           //redirect to the error page 
        // {
        //     if (ModelState.IsValid)
        //     {
        //         // Process the form
        //         return RedirectToAction("Confirmation");
        //     }

        //     return View(model); // Redisplay the form with errors
        // }
        // [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)                         // Solution is here
        {
            // // TODO: store repsonse from guest 
            // Repository.AddResponse(guestResponse);          //new
            // return View("Thanks", guestResponse);
            // // return View();                               //old 

            //super new 
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error  
                return View();
            }
        }
        public ViewResult ListResponses()                                               //After submission thanks response 2.17
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }

        public IActionResult Confirmation()
        {
            return View();
        }
        //Adding dynamin from Book Learning


        public ViewResult MyView()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";

            return View();
        }

        //
        //end form book


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
