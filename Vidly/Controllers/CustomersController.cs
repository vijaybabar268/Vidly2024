using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageCustomers))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        
        [Authorize(Roles = RoleName.CanManageCustomers)]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var membershipTypes = _context.MembershipTypes.ToList();
                var model = new CustomerFormViewModel
                {
                    Customer = new Customer(),
                    MembershipTypes = membershipTypes
                };

                return View("CustomerForm", model);
            }

            if(viewModel.Customer.Id == 0)
            {
                _context.Customers.Add(viewModel.Customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);
                customerInDb.Name = viewModel.Customer.Name;
                customerInDb.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                customerInDb.BirthDate = viewModel.Customer.BirthDate;
                customerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageCustomers)]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}