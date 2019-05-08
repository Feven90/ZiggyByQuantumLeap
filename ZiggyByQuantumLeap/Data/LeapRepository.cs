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

        public Leap AddLeapeeToLeaper(int leapeeId, int leaperId, decimal cost)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var parameter = new { LeaperId = leaperId, LeapeeId = leapeeId, Cost = cost };
                var budget = db.QueryFirstOrDefault<Leaper>(@"select Budget from Leaper where id = @leaperId",parameter ).Budget;
                //var cost = db.QueryFirstOrDefault<Leap>(@"select")

                if (budget >= @cost)
                {
                    var Leaps = db.QueryFirstOrDefault<Leap>($@"INSERT INTO [dbo].[Leap]
                           ( LeaperId, LeapeeId , Cost)
                            Output inserted.*  
                     VALUES
                           ( @LeaperId, @LeapeeId, @Cost)",
                             parameter );
                    var budgetLeft = budget - cost;
                    var updateBudget = db.QueryFirstOrDefault<Leaper>(@"UPDATE [dbo].[Leaper]
                                                                     SET [Budget] = @budgetLeft
                                                                     WHERE id = @leaperId", 
                                                                     new { LeaperId = leaperId, BudgetLeft = budgetLeft });
                }
             
                throw new Exception("No leap is created, leaper has less budget");

            }

        }
    }
}
