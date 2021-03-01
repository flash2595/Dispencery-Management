using DispenceryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DispenceryManagement.ViewModel
{
    public class RandomCustomerViewModel
    {
        public DispenceryItems DisItems { get; set; }

        public List<Patient> Patients { get; set; }
    }
}