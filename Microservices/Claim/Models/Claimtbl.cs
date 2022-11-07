using System;
using System.Collections.Generic;

#nullable disable

namespace Claim.Models
{
    public partial class Claimtbl
    {
        public int ClaimId { get; set; }
        public string ClaimType { get; set; }
        public decimal? ClaimAmount { get; set; }
        public DateTime? ClaimDate { get; set; }
        public int? MemberId { get; set; }
        public string Remarks { get; set; }
    }
}
