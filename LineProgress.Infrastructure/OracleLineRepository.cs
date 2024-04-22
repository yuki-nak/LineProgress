using Dapper;
using LineProgress.Entities;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
namespace LineProgress.Infrastructure
{
    public class OracleLineRepository : IOracleLineRepository
    {
        private readonly string _connectionString;
        public OracleLineRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection");
        }
        public async Task<IEnumerable<Line>> GetAllLinesAsync()
        {
            using OracleConnection dbConnection = new(_connectionString);
            await dbConnection.OpenAsync();
            return await dbConnection.QueryAsync<Line>("SELECT LINENAME, PLAN, ACTUAL, PLAN_M, ACTUAL_M FROM LINE");
        }
        public async Task<Line> GetLineByNameAsync(string lineName)
        {
            using OracleConnection dbConnection = new(_connectionString);
            await dbConnection.OpenAsync();
            var queryResult = await dbConnection.QueryFirstOrDefaultAsync<Line>("SELECT LINENAME AS LineName, PLAN AS DailyPlan, ACTUAL AS DailyActual, PLAN_M AS MonthlyPlan, ACTUAL_M AS MonthlyActual FROM LINE WHERE LINENAME = :lineName", new { lineName });
            if (queryResult == null)
            {
                throw new Exception("Line not found");
            }
            else
            {
                return queryResult;
            }
        }
    }
}