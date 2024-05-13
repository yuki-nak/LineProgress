using LineProgress.Entities;

namespace LineProgress.Infrastructure
{
    public interface ILineRepository
    {
        Task<IEnumerable<Line>> GetAllLinesAsync();
        Task<Line> GetLineByNameAsync(string lineName);
    }
}