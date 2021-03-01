using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DispenceryManagement.Models
{
    public class RoleAssignment
    {
        public int Id { get; set; }

        public string MemberName { get; set; }

        public StaffRole StaffRoles { get; set; }

        public byte RoleId { get; set; }

        public string RoleName { get; set; }

        public DateTime AddedDateTime { get; set; }
    }
}