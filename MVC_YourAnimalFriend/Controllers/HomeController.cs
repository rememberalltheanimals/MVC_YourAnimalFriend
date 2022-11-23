using MVC_YourAnimalFriend.Models;
using System.Web.Mvc;

namespace MVC_YourAnimalFriend.Controllers
{
    public class HomeController : Controller
    {
        public int year;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            Volunteer vt = new Volunteer();
            ViewBag.Volunteer = vt;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Greeting()
        {
            ViewBag.Message = "Happy New Year! Let's help the animal of your birth year and the animal of new year!";

            return View();
        }

        [HttpPost]
        public ActionResult AnimalOfYear(int? year)
        {
            if (year % 12 == 0)
            {
                ViewBag.Message = "Your birth year animal friend is monkey/gorilla/chimpanzee/orangutan." +
                    "They can really use your help!";
            }
            else if (year % 12 == 1)
            {
                ViewBag.Message = "Your birth year animal friend is chicken/duck/goose/bird." +
                    "They can really use your help!";
            }
            else if (year % 12 == 2)
            {
                ViewBag.Message = "Your birth year animal friend is dog/cat." +
                    "They can really use your help!";
            }
            else if (year % 12 == 3)
            {
                ViewBag.Message = "Your birth year animal friend is pig." +
                    "They can really use your help!";
            }
            else if (year % 12 == 4)
            {
                ViewBag.Message = "Your birth year animal friend is mouse/rat." +
                    "They can really use your help!";
            }
            else if (year % 12 == 5)
            {
                ViewBag.Message = "Your birth year animal friend is cow/ox." +
                    "They can really use your help!";
            }
            else if (year % 12 == 6)
            {
                ViewBag.Message = "Your birth year animal friend is tiger/lion." +
                    "They can really use your help!";
            }
            else if (year % 12 == 7)
            {
                ViewBag.Message = "Your birth year animal friend is rabbit." +
                    "They can really use your help!";
            }
            else if (year % 12 == 8)
            {
                ViewBag.Message = "Your birth year animal friend is dragon and any animals on earth." +
                    "They can really use your help!";
            }
            else if (year % 12 == 9)
            {
                ViewBag.Message = "Your birth year animal friend is snake and any animals not mentioned." +
                    "They can really use your help!";
            }
            else if (year % 12 == 10)
            {
                ViewBag.Message = "Your birth year animal friend is horse/donkey/camal." +
                    "They can really use your help!";
            }
            else if (year % 12 == 11)
            {
                ViewBag.Message = "Your birth year animal friend is sheep/goat." +
                    "They can really use your help!";
            }
            return View();
        }
    }
}


