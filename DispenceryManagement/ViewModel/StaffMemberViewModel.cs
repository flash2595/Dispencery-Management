using DispenceryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DispenceryManagement.ViewModel
{
    public class StaffMemberViewModel
    {
        public IEnumerable<StaffRole> StaffRoles { get; set; }
        public Patient Patients { get; set; }
    }
}