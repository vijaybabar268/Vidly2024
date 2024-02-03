using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Index
        public ActionResult Index()
        {
            var movies = GetMovies().ToList();

            return View(movies);
        }

        // GET: Movies/Details/Id
        public ActionResult Details(int id)
        {
            var movie = GetMovies().FirstOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [NonAction]
        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Major" },
                new Movie { Id = 2, Name = "Jawan" },
                new Movie { Id = 3, Name = "Pk" },
            };
        }
    }
}