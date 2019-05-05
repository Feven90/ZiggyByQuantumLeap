using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ZiggyByQuantumLeap.Data;

namespace ZiggyByQuantumLeap.Models
{
    public class LeaperRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";
        public Leaper AddLeaper(string name, string age)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var Leapers = db.QueryFirstOrDefault<Leaper>(@"
                    Insert into Leaper(name,age)
                    Output inserted.*
                    values(@name,@age)",
                new { Name = name, Age = age });

                if (Leapers != null)
                {
                    return Leapers;
                }
                throw new Exception("No user is created");
            }
        }

        public Leaper GetAllLeapers()
        { 
            using (var db= new SqlConnection(ConnectionString))
            {
                var Leapers = db.QueryFirstOrDefault<Leaper>(@"
                    Select * from Leaper");
               
                if(Leapers != null)
                {
                    return Leapers;
                }
                throw new Exception("No user is found");
            }
            }

    }
}
