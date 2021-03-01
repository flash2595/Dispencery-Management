using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DispenceryManagement.Models
{
    public class PatientCourse
    {
        public string PatientName { get; set; }

        public List<string> DispenceryItemName { get; set; }   
        
        public List<int> DispenceryItemQuantity { get; set; }
    }
}