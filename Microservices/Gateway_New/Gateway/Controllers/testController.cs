using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
         [HttpPost]
        [Route("Claim-Add")]
        public IActionResult Post(Claimtbl obj)
        {
            string chk = claimService.ClaimAdd(obj);

            var response = new { Status = chk };
            return Ok(response);

        }
    }
}
