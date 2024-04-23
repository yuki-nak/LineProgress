using LineProgress.Entities;

namespace LineProgress.Services
{
    public class LineViewModel
    {
        public List<Line> Lines { get; set; }
        public Line SelectedLine { get; set; }
        public string SelectedLineName { get; set; }

        public LineViewModel()
        {
            Lines = new List<Line>();
        }
    }
}
