using Claim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Claim.Services;

namespace Claim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        IClaimService claimService;
        public ClaimController(IClaimService _claimService)
        {
            claimService = _claimService;
        }
        [HttpPost]
        [Route("Claim-Add")]
        public IActionResult ClaimAdd(Claimtbl obj)
        {
            string chk = claimService.ClaimAdd(obj);

            var response = new { Status = chk };
            return Ok(response);

        }
    }
}
