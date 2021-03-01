using DispenceryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DispenceryManagement.ViewModel;

namespace DispenceryManagement.Controllers
{
    public class StaffController : Controller
    {

        private ApplicationDbContext dbContext;

        public StaffController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        // GET: Staff
        public ActionResult Index()
        {
            var Customer = dbContext.Patient
                .Include(c => c.AssignedStaffRoles)
                .Where(c => c.IsSubscribed == false)
                .ToList();

            if (User.IsInRole(RoleNames.Doctor) || User.IsInRole(RoleNames.Assitant_Doctor))
                return View(Customer);

            return View("ReadonlyIndex",Customer);            
        }

        [Authorize(Roles = RoleNames.Doctor + "," + RoleNames.Assitant_Doctor + "," + RoleNames.Nurse_Head + "," + RoleNames.Nurse)]
        public ActionResult Details(int? id)
        {
            var customer = dbContext.Patient.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new StaffMemberViewModel
            {
                Patients = customer,
                StaffRoles = dbContext.JobRole.ToList()
            };

            return View(viewModel);
        }
    }
}