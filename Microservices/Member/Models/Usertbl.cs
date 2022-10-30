using System;
using System.Collections.Generic;

#nullable disable

namespace Member.Models
{
    public partial class Usertbl
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Conpassword { get; set; }
        public string UserRole { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModiDate { get; set; }
    }
}
