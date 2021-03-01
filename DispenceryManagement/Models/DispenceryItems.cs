using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DispenceryManagement.Models
{
    public class DispenceryItems
    {
        public int Id { get; set; }

        public DispenceryType dispenceryType { get; set; }

        [Display(Name = "Dispencery Item Type")]
        [Required]
        public byte dispenceryTypeId { get; set; }

        [Display(Name = "Dispencery Name")]
        public string DispenceryItemName { get; set; }

        [Display(Name = "Dispencery Item Type")]
        public string DispenceryItemType { get; set; }

        public bool IsGeneric { get; set; }

        [Display(Name = "Dispencery Item Price")]
        public int DispenceryItemPrice { get; set; }

        [Range(1,10)]
        public int DispenceryItemQuantity { get; set; }
    }
}