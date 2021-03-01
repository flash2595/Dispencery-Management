using DispenceryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DispenceryManagement.Controllers
{
    public class PurchaseOrderController : ApiController
    {
        private ApplicationDbContext dbContext;
        
        int ID=1;
        string BillNumber;

        public PurchaseOrderController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
            ID++;
        }

        [HttpPost]
        public IHttpActionResult CreatePurchaseOrders(PatientCourse patientCourse)
        {
            if (patientCourse.DispenceryItemQuantity.Count() == 0)
                return BadRequest("No Dispencery Items were selected.");

            var Patients = dbContext.Patient
                .SingleOrDefault(c => c.Name == patientCourse.PatientName);

            if(Patients == null)
                return BadRequest("Invalid Patient.");

            List<DispenceryItems> SaveDispenceryItems = new List<DispenceryItems>();
            var DispenceryItems = dbContext.DispenceryItem
                .Where(m => patientCourse.DispenceryItemName.Contains(m.DispenceryItemName))
                .ToList();

            for (int i = 0; i <= patientCourse.DispenceryItemName.Count - 1; i++)
            {
                if (DispenceryItems.ElementAt(i).DispenceryItemName != patientCourse.DispenceryItemName.ElementAt(i))
                {
                    for (int k = 0; k <= patientCourse.DispenceryItemName.Count - 1; k++)
                    {
                        if (DispenceryItems.ElementAt(i).DispenceryItemName == patientCourse.DispenceryItemName.ElementAt(k))
                        {
                            DispenceryItems.ElementAt(i).DispenceryItemQuantity = patientCourse.DispenceryItemQuantity.ElementAt(k);
                            SaveDispenceryItems.Add(DispenceryItems.ElementAt(k));
                        }

                    }
                }
                else
                {
                    DispenceryItems.ElementAt(i).DispenceryItemQuantity = patientCourse.DispenceryItemQuantity.ElementAt(i);
                    SaveDispenceryItems.Add(DispenceryItems.ElementAt(i));
                }
            }

            if (patientCourse.DispenceryItemQuantity.Count() != DispenceryItems.Count())
                return BadRequest("Dispencery Items selected more than one.");

            if (dbContext.PurchaseDetails.Count() > 0)
            {
                BillNumber = dbContext.PurchaseDetails
                    .OrderByDescending(x => x.BillNo)
                    .FirstOrDefault().BillNo.ToString();

                var Number = BillNumber.Substring(8, 3);
                Number = Number != "999" ? Number : "001";
                BillNumber = (Convert.ToInt32(Number) + 1).ToString("D3");
            }
            else
                BillNumber = ID.ToString("D3");

            foreach (var Items in SaveDispenceryItems)
            {
                var order = new PurchaseCourse
                {
                    BillNo = DateTime.Now.ToString("yyyyMMdd") + BillNumber,
                    Patients = Patients,
                    DispenceryItemQuantityPurchase = Items.DispenceryItemQuantity,
                    DispenceryItems = Items,
                    PurchaseDate = DateTime.Now
                };

                dbContext.PurchaseDetails.Add(order);
                dbContext.SaveChanges();
            }

            //dbContext.SaveChanges();

            return Ok();
        }

    }
}
