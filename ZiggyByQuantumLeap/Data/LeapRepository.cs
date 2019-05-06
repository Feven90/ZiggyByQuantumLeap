using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ZiggyByQuantumLeap.Models;

namespace ZiggyByQuantumLeap.Data
{
    public class LeapRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";

        public Leap AddLeapeeToLeaper(int leaperId, int leapeeId)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var Leaps = db.Query<Leap>($@"INSERT INTO [dbo].[Leap]
                           ( LeaperId, LeapeeId , Cost)
                            Output inserted.*  
                     VALUES
                           ( @LeaperId, @LeapeeId, @Cost)", 
                           new {LeaperId = leaperId, LeapeeId= leapeeId}).ToList() ;

                if (Leaps != null)
                {
                    return Leaps;
                }
                throw new Exception("No leap is created");

            }

        }
    }
}
