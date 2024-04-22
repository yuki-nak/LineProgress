using LineProgress.Entities;
using LineProgress.Infrastructure;
namespace LineProgress.Services
{
    public class LineService
    {
        private readonly IOracleLineRepository _oracleLineRepository;
        public LineService(IOracleLineRepository oracleLineRepository)
        {
            _oracleLineRepository = oracleLineRepository;
        }
        public async Task<IEnumerable<Line>> GetAllLines()
        {
            return await _oracleLineRepository.GetAllLinesAsync();
        }
        public async Task<Line> GetLineByName(string lineName)
        {
            return await _oracleLineRepository.GetLineByNameAsync(lineName);
        }
    }
}