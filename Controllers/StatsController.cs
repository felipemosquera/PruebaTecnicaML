
using Felipe_ML.Domain;
using Microsoft.AspNetCore.Mvc;


namespace Felipe_ML.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatsController : Controller
    {
        
        private readonly IStats _service;

        public StatsController(IStats service)
        {
            _service = service;
           
        }

        [HttpGet]
        [Route("getStats")]
        public ActionResult stats()
        {
            return Ok(_service.GetStatsDna());
        }
    }
}