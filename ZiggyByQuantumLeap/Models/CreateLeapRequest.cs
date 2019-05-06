using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZiggyByQuantumLeap.Models
{
    public class CreateLeapRequest
    {
        public int LeapeeId { get; set; }
        public int EventId { get; set; }
        public int LeaperId { get; set; }
        public decimal Cost { get; set; }
    }
}
