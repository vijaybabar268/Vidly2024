using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Id=1, Name="Shrek" };
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name= "Customer 1" },
                new Customer { Id = 2, Name= "Customer 2"},
                new Customer { Id = 3, Name= "Customer 3" },
                new Customer { Id = 4, Name= "Customer 4"},
                new Customer { Id = 5, Name= "Customer 5" },
                new Customer { Id = 6, Name= "Customer 6"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}