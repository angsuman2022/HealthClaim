using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Claim.Models;

namespace Claim.Services
{
    public interface IClaimService
    {
        string ClaimAdd(Claimtbl obj);
        
    }
}
