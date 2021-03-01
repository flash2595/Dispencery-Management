using DispenceryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DispenceryManagement.ViewModel
{
    public class PurchaseOrderFormViewModel
    {
        public MembershipType MembershipTypes { get; set; }
        
        public IEnumerable<Patient> Patients { get; set; }

        public IEnumerable<DispenceryItems> purchaseDispenceryItems { get; set; }

        public IEnumerable<PurchaseCourse> purchaseCourses { get; set; }
    }
}