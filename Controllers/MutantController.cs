using System;
using Felipe_ML.Domain;
using Felipe_ML.Models;
using Microsoft.AspNetCore.Mvc;

namespace Felipe_ML.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MutantController : ControllerBase
    {
        private readonly IMutant _service;
        public MutantController(IMutant service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("mutant")]
        public ActionResult isMutant(IsMutantRequest isMutantRequest)
        {
            try
            {
                bool isMutant = _service.isMutant(isMutantRequest.dna);
                if (isMutant)
                {
                    return Ok(isMutant);
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}