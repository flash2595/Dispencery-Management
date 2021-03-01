using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DispenceryManagement.Models
{
    public class PurchaseCourse
    {
        public int Id { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string BillNo { get; set; }

        [Required]
        public Patient Patients { get; set; }

        public int PatientId { get; set; }


        [Required]
        public DispenceryItems DispenceryItems { get; set; }

        public int DispenceryItemQuantityPurchase { get; set; }

        public DateTime PurchaseDate { get; set; }

    }
}