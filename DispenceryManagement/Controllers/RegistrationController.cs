using DispenceryManagement.Models;
using DispenceryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DispenceryManagement.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        private ApplicationDbContext dbContext;

        public RegistrationController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }


        // GET: Registration
        public ActionResult Index()
        {            
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = dbContext.MembershipType.Where(c => c.Id > 0).ToList(),
                StaffRoles = dbContext.JobRole.ToList()
            };

            return View(viewModel);
        }
    }
}