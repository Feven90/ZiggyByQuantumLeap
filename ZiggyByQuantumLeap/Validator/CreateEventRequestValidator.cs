using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZiggyByQuantumLeap.Models;

namespace ZiggyByQuantumLeap.Validator
{
    public class CreateEventRequestValidator
    {
        public bool Validate(CreateEventRequest requestToValidate)
        {
            return !(string.IsNullOrEmpty(requestToValidate.EventName));
        }
    }
}
