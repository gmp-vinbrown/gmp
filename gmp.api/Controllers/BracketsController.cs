using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gmp.DomainModels.Projections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gmp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BracketsController : ControllerBase
    {
        [HttpPost]
        public Task<List<EventActivityMatchDTO>> Get()
        {

        }
    }
}