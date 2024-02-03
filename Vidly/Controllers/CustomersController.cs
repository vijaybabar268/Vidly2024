using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers/Index
        public ActionResult Index()
        {
            var customers = GetCustomers().ToList();

            return View(customers);
        }

        // GET: Customers/Details/Id
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [NonAction]
        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Vijay Babar" },
                new Customer { Id = 2, Name = "Ajit Phadtare" },
                new Customer { Id = 3, Name = "Bilal Shaikh" },
            };
        }
    }
}