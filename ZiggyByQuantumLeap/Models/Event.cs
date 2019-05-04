using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZiggyByQuantumLeap.Data
{
    public class Event
    {
        public int Id { get; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}