using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZiggyByQuantumLeap.Models;
using ZiggyByQuantumLeap.Validator;

namespace ZiggyByQuantumLeap.Controllers
{
    [Route("api/leapee")]
    [ApiController]
    public class LeapeeController : ControllerBase
    {
        readonly LeapeeRepository _leapeeRepository;
        readonly CreateLeapeeRequestValidator _validator;


        public LeapeeController()
        {
            _validator = new CreateLeapeeRequestValidator();
            _leapeeRepository = new LeapeeRepository();
        }

        [HttpPost("register")]
        public ActionResult<int> AddLeapee(CreateLeapeeRequest createRequest)
        {
            if (!_validator.Validate(createRequest))

                return BadRequest(new { error = "users must have a username" });

            var newLeapee = _leapeeRepository.AddLeapee(createRequest.Name, createRequest.Age);
            return Created($"api/leapee/{newLeapee.Id}", newLeapee);
        }

    }
}