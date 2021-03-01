using DispenceryManagement.Models;
using DispenceryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DispenceryManagement.Controllers
{
    public class DispenceryController : Controller
    {

        private ApplicationDbContext dbContext;

        public DispenceryController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        public ActionResult New()
        {
            var DispenceryItemsList = dbContext.DispenceryTypes.ToList();
            DispenceryItems dispenceryitem = new DispenceryItems();
            dispenceryitem.DispenceryItemQuantity = 1;
            var viewModel = new DispenceryItemFormViewModel
            {
                DispenceryTypes = DispenceryItemsList,
                DispenceryItem = dispenceryitem
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(DispenceryItemFormViewModel dispenceryItems)
        {
            if (dispenceryItems.DispenceryItem.Id == 0)
            {                
                dbContext.DispenceryItem.Add(dispenceryItems.DispenceryItem);
            }
            else
            {
                var movieInDb = dbContext.DispenceryItem.Single(m => m.Id == dispenceryItems.DispenceryItem.Id);
                movieInDb.DispenceryItemName = dispenceryItems.DispenceryItem.DispenceryItemName;
                movieInDb.DispenceryItemType = dispenceryItems.DispenceryItem.DispenceryItemType;
                movieInDb.IsGeneric = dispenceryItems.DispenceryItem.IsGeneric;
            }
           dbContext.SaveChanges();

            return RedirectToAction("Index", "Dispencery");
        }

        // GET: Dispencery
        public ActionResult Index()
        {
            var DispenceryItem = dbContext.DispenceryItem.ToList();

            if (User.IsInRole(RoleNames.Doctor) || User.IsInRole(RoleNames.Assitant_Doctor) || User.IsInRole(RoleNames.Nurse_Head) || User.IsInRole(RoleNames.Nurse))
                return View(DispenceryItem);


            return View("ReadonlyIndex",DispenceryItem);
        }

        public ActionResult Random()
        {
            var DisItem = new DispenceryItems() { DispenceryItemName = "Lysol", Id = 1 };

            var Patient = new List<Patient>
            {
                new Patient { Name = "Pat 1"},
                new Patient { Name = "Pat 2"}
            };

            var RandomViewModel = new RandomCustomerViewModel
            {
                Patients = Patient,
                DisItems = DisItem
            };

            return View(RandomViewModel);
        }

        [Authorize(Roles = RoleNames.Doctor + "," + RoleNames.Assitant_Doctor + "," + RoleNames.Nurse_Head + "," + RoleNames.Nurse)]
        public ActionResult Details(int? id)
        {
            var DispenceryItem = dbContext.DispenceryItem.SingleOrDefault(c => c.Id == id);

            if (DispenceryItem == null)
                return HttpNotFound(); 

            var viewModel = new DispenceryItemFormViewModel
            {
                DispenceryItem = DispenceryItem,
                DispenceryTypes = dbContext.DispenceryTypes.ToList()
            };

            return View("New",viewModel);
        }
    }
}