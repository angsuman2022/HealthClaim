using System;
using System.Collections.Generic;

#nullable disable

namespace Claim.Models
{
    public partial class Logtbl
    {
        public int Slno { get; set; }
        public string ErrorMsg { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
