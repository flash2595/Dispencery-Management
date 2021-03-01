using DispenceryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace DispenceryManagement.Controllers.Api
{
    public class DispenceryItemsController : ApiController
    {
        private ApplicationDbContext dbContext;

        public DispenceryItemsController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        //GET/api/DispenceryItems/1
        public DispenceryItems GetDispenceryItems(int i)
        {
            var dispenceryItems = dbContext.DispenceryItem.SingleOrDefault(m => m.Id == i);

            if (dispenceryItems == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return dispenceryItems;
        }

        public void GetDispenceryItems()
        {

        }

        public IHttpActionResult GetDispenceryItems(string id,string isgeneric)
        {
            IQueryable<DispenceryItems> dispenceryItemQuery;
            if (int.TryParse(isgeneric,out int res) && res <= 1)            
                dispenceryItemQuery = dbContext.DispenceryItem.Where(c=>c.IsGeneric == true);
            else
                dispenceryItemQuery = dbContext.DispenceryItem.Where(c => c.IsGeneric == false);

            if (!String.IsNullOrWhiteSpace(id))
                dispenceryItemQuery = dispenceryItemQuery.Where(c => c.DispenceryItemName.Contains(id));

            return Ok(dispenceryItemQuery);            
        }


        // DELETE /api/dispenceryItems/1
        [HttpDelete]
        public void DeleteDispenceryItems(int id)
        {
            var customerInDb = dbContext.DispenceryItem.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            dbContext.DispenceryItem.Remove(customerInDb);
            dbContext.SaveChanges();
        }
    }
}

