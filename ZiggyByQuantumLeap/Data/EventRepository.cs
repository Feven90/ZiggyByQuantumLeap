using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ZiggyByQuantumLeap.Data;

namespace ZiggyByQuantumLeap.Models
{
    public class EventRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";
        public Event AddEvent(string eventName, DateTime eventDate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var Event = db.QueryFirstOrDefault<Event>(@"
                    Insert into Event(eventName,eventDate)
                    Output inserted.*
                    values(@eventName,@eventDate)",
                new { EventName = eventName, EventDate = eventDate });

                if (Event != null)
                {
                    return Event;
                }
                throw new Exception("No user is created");
            }
        }
    }
}
