using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZiggyByQuantumLeap.Models;

namespace ZiggyByQuantumLeap.Validator
{
    public class CreateLeapeeRequestValidator
    {
        public bool Validate(CreateLeapeeRequest requestToValidate)
        {
            return !(string.IsNullOrEmpty(requestToValidate.Name)
                || string.IsNullOrEmpty(requestToValidate.Age));
        }
    }
}
