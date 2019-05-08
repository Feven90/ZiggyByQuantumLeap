using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ZiggyByQuantumLeap.Data;
using ZiggyByQuantumLeap.Models;

namespace ZiggyByQuantumLeap.Data
{
    public class LeaperRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";
        public Leaper AddLeaper(string name, string age, decimal budget)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var Leapers = db.QueryFirstOrDefault<Leaper>(@"
                    Insert into Leaper(name,age,budget)
                    Output inserted.*
                    values(@name,@age,@budget)",
                new { Name = name, Age = age, Budget = budget });

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
