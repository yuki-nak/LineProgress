using LineProgress.Entities;

namespace LineProgress.Infrastructure
{
    public interface IOracleLineRepository
    {
        Task<IEnumerable<Line>> GetAllLinesAsync();
        Task<Line> GetLineByNameAsync(string lineName);
    }
}