using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZiggyByQuantumLeap.Data;
using ZiggyByQuantumLeap.Models;
using ZiggyByQuantumLeap.Validator;

namespace ZiggyByQuantumLeap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeapController : ControllerBase
    {
        readonly LeapRepository _leapRepository;
        readonly CreateLeapRequestValidator _validator;


        public LeapController()
        {
            _validator = new CreateLeapRequestValidator();
            _leapRepository = new LeapRepository();
        }

        [HttpPost("register")]
        public ActionResult<int> AddLeap(CreateLeapRequest createRequest)
        {
            //if (!_validator.Validate(createRequest))

               // return BadRequest(new { error = "users must have a username" });

            var newLeap = _leapRepository.AddLeapeeToLeaper(createRequest.LeapeeId, createRequest.LeaperId, createRequest.Cost);
            return Created($"api/leaper", newLeap);
        }

        //[HttpGet("getLeapers")]
        //public ActionResult GetAllLeapers()
        //{
        //    var allLeapers = _leaperRepository.GetAllLeapers();
        //    return Ok(allLeapers);
        //}
    }
}