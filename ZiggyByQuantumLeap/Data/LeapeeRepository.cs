using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ZiggyByQuantumLeap.Data;

namespace ZiggyByQuantumLeap.Models
{
    public class LeapeeRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";
        public Leapee AddLeapee(string name, string age)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var Leapees = db.QueryFirstOrDefault<Leapee>(@"
                    Insert into Leapee(name,age)
                    Output inserted.*
                    values(@name,@age)",
                new { Name = name, Age = age });

                if (Leapees != null)
                {
                    return Leapees;
                }
                throw new Exception("No user is created");
            }
        }
    }
}
