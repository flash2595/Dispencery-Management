using DispenceryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DispenceryManagement.Controllers.Api
{
    public class PatientsController : ApiController
    {
        private ApplicationDbContext dbContext;

        public PatientsController()
        {
            dbContext = new ApplicationDbContext();
        }



        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }    

        //GET/api/patients/1
        public Patient GetPatients(int i)
        {
            var patient = dbContext.Patient.Where(m => m.IsSubscribed == true).SingleOrDefault(m => m.Id == i);

            if (patient == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return patient;
        }

        public IHttpActionResult GetPatients(string id = null)
        {
            var patientQuery = dbContext.Patient.Where(m => m.IsSubscribed == true);

            if (!String.IsNullOrWhiteSpace(id))
                patientQuery = patientQuery.Where(c => c.Name.Contains(id));

            return Ok(patientQuery);
        }
    }
}
