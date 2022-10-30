using System;
using System.Collections.Generic;

#nullable disable

namespace Member.Models
{
    public partial class Claimtbl
    {
        public int ClaimId { get; set; }
        public string ClaimType { get; set; }
        public decimal? ClaimAmount { get; set; }
        public DateTime? ClaimDate { get; set; }
        public int? MemberId { get; set; }
    }
}
