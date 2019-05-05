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
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly EventRepository _eventRepository;
        readonly CreateEventRequestValidator _validator;


        public EventController()
        {
            _validator = new CreateEventRequestValidator();
            _eventRepository = new EventRepository();
        }

        [HttpPost("register")]
        public ActionResult<int> AddEvent(CreateEventRequest createRequest)
        {
            if (!_validator.Validate(createRequest))

                return BadRequest(new { error = "users must have a name and date" });

            var newLeapee = _eventRepository.AddEvent(createRequest.EventName, createRequest.EventDate);
            return Created($"api/event/{newLeapee.Id}", newLeapee);
        }
    }
}