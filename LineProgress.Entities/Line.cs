namespace LineProgress.Entities
{
    public class Line
    {
        public required string LineName { get; set; }
        public int DailyPlan { get; set; }
        public int DailyActual { get; set; }
        public int MonthlyPlan { get; set; }
        public int MonthlyActual { get; set; }
        public int DailyDifference => DailyActual - DailyPlan;
        public int MonthlyDifference => MonthlyActual - MonthlyPlan;

        public string FormattedDailyPlan => DailyPlan.ToString("N0");
        public string FormattedDailyActual => DailyActual.ToString("N0");
        public string FormattedMonthlyPlan => MonthlyPlan.ToString("N0");
        public string FormattedMonthlyActual => MonthlyActual.ToString("N0");
    }
}
