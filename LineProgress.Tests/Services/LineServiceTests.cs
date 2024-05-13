using LineProgress.Entities;
using LineProgress.Infrastructure;
using LineProgress.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineProgress.Tests.Services
{
    public class LineServiceTests
    {
        [Fact]
        public async Task GetAllLinesAsync_Returns_All_Lines_From_Repository()
        {
            // Arrange
            var mockRepository = new Mock<ILineRepository>();
            var expectedLines = new List<Line>
        {
            new Line { LineName = "Line1", DailyPlan = 100, DailyActual = 90 },
            new Line { LineName = "Line2", DailyPlan = 150, DailyActual = 120 }
        };
            mockRepository.Setup(repo => repo.GetAllLinesAsync()).ReturnsAsync(expectedLines);
            var lineService = new LineService(mockRepository.Object);

            // Act
            var result = await lineService.GetAllLinesAsync();

            // Assert
            Assert.Equal(expectedLines, result);
        }

        [Fact]
        public async Task GetLineByNameAsync_Returns_Line_With_Given_Name_From_Repository()
        {
            // Arrange
            var mockRepository = new Mock<ILineRepository>();
            var expectedLine = new Line { LineName = "Line1", DailyPlan = 100, DailyActual = 90 };
            mockRepository.Setup(repo => repo.GetLineByNameAsync("Line1")).ReturnsAsync(expectedLine);
            var lineService = new LineService(mockRepository.Object);

            // Act
            var result = await lineService.GetLineByNameAsync("Line1");

            // Assert
            Assert.Equal(expectedLine, result);
        }
    }
}
