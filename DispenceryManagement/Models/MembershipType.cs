using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DispenceryManagement.Models
{
    public class MembershipType
    {
        public byte DiscountRate { get; set; }

        public byte Id { get; set; }

        public string MedicineType { get; set; }
    }
}