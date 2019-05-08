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
    [Route("api/leaper")]
    [ApiController]
    public class LeaperController : ControllerBase
    {
        readonly LeaperRepository _leaperRepository;
        readonly CreateLeaperRequestValidator _validator;


        public LeaperController()
        {
            _validator = new CreateLeaperRequestValidator();
            _leaperRepository = new LeaperRepository();
        }

        [HttpPost("register")]
        public ActionResult<int> AddLeaper(CreateLeaperRequest createRequest)
        {
            if (!_validator.Validate(createRequest))

                return BadRequest(new { error = "users must have a username" });

            var newLeaper = _leaperRepository.AddLeaper(createRequest.Name, createRequest.Age, createRequest.Budget);
            return Created($"api/leaper/{newLeaper.Id}", newLeaper);
        }

        [HttpGet("getLeapers")]
        public ActionResult GetAllLeapers()
        {
            var allLeapers = _leaperRepository.GetAllLeapers();
            return Ok(allLeapers);
        }

    }
}