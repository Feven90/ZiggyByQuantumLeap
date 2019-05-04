using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZiggyByQuantumLeap.Models;

namespace ZiggyByQuantumLeap.Validator
{
    public class CreateLeaperRequestValidator
    {
        public bool Validate(CreateLeaperRequest requestToValidate)
        {
            return !(string.IsNullOrEmpty(requestToValidate.Name)
                || string.IsNullOrEmpty(requestToValidate.Age));
        }
    }
}
