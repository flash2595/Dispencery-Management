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
    public class PatientController : Controller
    {

        private ApplicationDbContext dbContext;

        public PatientController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = dbContext.MembershipType.Where(c=>c.Id > 0).ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(CustomerFormViewModel patient)
        {
            int? userid = patient.Patients.Id;            

            if (userid == 0)
                dbContext.Patient.Add(patient.Patients);
            else
            {
                var customerInDb = dbContext.Patient.Single(c => c.Id == userid);
                customerInDb.Name = patient.Patients.Name;
                customerInDb.DateOfBirth = patient.Patients.DateOfBirth;

                if (!customerInDb.IsSubscribed)
                    customerInDb.IsSubscribed = patient.Patients.IsSubscribed;
                else
                    patient.Patients.IsSubscribed = true;

                if (patient.Patients.IsSubscribed)
                {
                    byte MembershipIdCheck = patient.Patients.MembershipTypeId != null ? patient.Patients.MembershipTypeId : Convert.ToByte(0);
                    customerInDb.MembershipTypeId = MembershipIdCheck;
                }
                else
                {
                    if(patient.Patients.AssignedStaffRoles != null)
                        customerInDb.AssignedRoleName = patient.Patients.AssignedStaffRoles.RoleName;

                    if(patient.Patients.AssignedRoleName != null)
                        customerInDb.AssignedRoleName = patient.Patients.AssignedRoleName;

                    //if(patient.Patients.AssignedStaffRoles.Id > 6) 
                    //{
                    //    ApplicationDbContext ADC = new ApplicationDbContext();
                    //    var RoleId = ADC.Roles.Where(b => b.Name == customerInDb.AssignedRoleName).Select(b => b.Id).FirstOrDefault();

                        
                    //}
                }

            }

            dbContext.SaveChanges();

            if(patient.Patients.IsSubscribed)
                return RedirectToAction("Index", "Patient");

            return RedirectToAction("Index", "Staff");
        }

        // GET: Patient
        public ActionResult Index()
        {
            var Customer = dbContext.Patient
                .Include(c => c.MembershipTypeCustomer)
                .Where(c => c.IsSubscribed == true)
                .ToList();

            if (User.IsInRole(RoleNames.Doctor) || User.IsInRole(RoleNames.Assitant_Doctor) || User.IsInRole(RoleNames.Nurse_Head) || User.IsInRole(RoleNames.Nurse))
                return View(Customer);

            return View("ReadonlyIndex",Customer);
        }

        [Authorize(Roles = RoleNames.Doctor + "," + RoleNames.Assitant_Doctor + "," + RoleNames.Nurse_Head + "," + RoleNames.Nurse)]
        public ActionResult Details(int id)
        {
            var customer = dbContext.Patient.Include(c => c.MembershipTypeCustomer).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Patients = customer,
                MembershipTypes = dbContext.MembershipType.Where(c => c.Id > 0).ToList()
            };

            return View("New",viewModel);
        }
    }
}