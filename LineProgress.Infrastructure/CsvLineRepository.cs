using CsvHelper;
using CsvHelper.Configuration;
using LineProgress.Entities;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace LineProgress.Infrastructure
{
    public class CsvLineRepository : IOracleLineRepository
    {
        private readonly string _csvFilePath;

        public CsvLineRepository(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }
        public async Task<IEnumerable<Line>> GetAllLinesAsync()
        {
            
            using (var reader = new StreamReader(_csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<LineMap>();
                var records = await csv.GetRecordsAsync<Line>().ToListAsync();
                return records;
            }
        }

        public async Task<Line> GetLineByNameAsync(string lineName)
        {
            using (var reader = new StreamReader(_csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<LineMap>();
                var records = await csv.GetRecordsAsync<Line>().ToListAsync();
                return records.FirstOrDefault(l => l.LineName == lineName);
            }
        }
    }
    public sealed class LineMap : ClassMap<Line>
    {
        public LineMap()
        {
            Map(m => m.LineName).Name("LINENAME"); // カラム名とプロパティのマッピング
            Map(m => m.DailyPlan).Name("PLAN");
            Map(m => m.DailyActual).Name("ACTUAL");
            Map(m => m.MonthlyPlan).Name("PLAN_M");
            Map(m => m.MonthlyActual).Name("PLAN_A");
        }
    }
}
