using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DispenceryManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Address { get; set; }

        public bool IsSubscribed { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public MembershipType MembershipTypeCustomer { get; set; }

        public RoleAssignment AssignedStaffRoles { get; set; }

        [Display(Name = "Role Name")]
        public string AssignedRoleName { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}