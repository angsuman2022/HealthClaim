using System;
using System.Collections.Generic;

#nullable disable

namespace Member.Models
{
    public partial class MemberDet
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConPassword { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string MemberType { get; set; }
        public int? PhysianId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModiDate { get; set; }
    }
}
