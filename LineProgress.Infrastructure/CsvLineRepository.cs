using CsvHelper;
using LineProgress.Entities;
using System.Globalization;

namespace LineProgress.Infrastructure
{
    public class CsvLineRepository : IOracleLineRepository
    {
        private readonly string _csvFilePath;

        public CsvLineRepository(string csvFilePath)
        {
            _csvFilePath = _csvFilePath;
        }
        public async Task<IEnumerable<Line>> GetAllLinesAsync()
        {
            using (var reader = new StreamReader(_csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = await csv.GetRecordsAsync<Line>().ToListAsync();
                return records;
            }
        }

        public async Task<Line> GetLineByNameAsync(string lineName)
        {
            using (var reader = new StreamReader(_csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = await csv.GetRecordsAsync<Line>().ToListAsync();
                return records.FirstOrDefault(l => l.LineName == lineName);
            }
        }
    }
}
