using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Id=1, Name="Shrek" };

            ViewData["Movie"] = movie;
            ViewBag.Movie = movie;
            TempData["Movie"] = movie;

            return View();
        }
    }
}