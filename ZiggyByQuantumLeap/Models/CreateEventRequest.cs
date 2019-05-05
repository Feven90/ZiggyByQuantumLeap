using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZiggyByQuantumLeap.Models
{
    public class CreateEventRequest
    {
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
