using Dapper;
using LineProgress.Entities;
using LineProgress.Infrastructure;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Data;

namespace LineProgress.Tests.Infrastructure
{
    public class OracleLineRepositoryTests
    {
        [Fact]
        public async Task GetAllLinesAsync_Returns_All_Lines_From_Database()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(config => config.GetConnectionString("OracleConnection")).Returns("connection_string");

            var mockConnection = new Mock<IDbConnection>();
            var testLines = GetTestLines();
            mockConnection.Setup(conn => conn.QueryAsync<Line>(
                "SELECT LINENAME, PLAN, ACTUAL, PLAN_M, ACTUAL_M FROM LINE",
                null,
                null,
                null,
                default))
                .ReturnsAsync(testLines);

            var repository = new OracleLineRepository(mockConfiguration.Object);

            // Act
            var result = await repository.GetAllLinesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testLines, result);
        }

        [Fact]
        public async Task GetLineByNameAsync_Returns_Line_With_Given_Name_From_Database()
        {
            // Arrange
            var lineName = "TestLine";
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(config => config.GetConnectionString("OracleConnection")).Returns("connection_string");

            var mockConnection = new Mock<IDbConnection>();
            var testLine = new Line { LineName = lineName, DailyPlan = 100, DailyActual = 90 };
            mockConnection.Setup(conn => conn.QueryFirstOrDefaultAsync<Line>(
                "SELECT LINENAME, PLAN, ACTUAL, PLAN_M, ACTUAL_M FROM LINE WHERE LINENAME = :lineName",
                It.IsAny<object>(),
                null,
                null,
                default))
                .ReturnsAsync(testLine);

            var repository = new OracleLineRepository(mockConfiguration.Object);

            // Act
            var result = await repository.GetLineByNameAsync(lineName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testLine, result);
        }

        private IEnumerable<Line> GetTestLines()
        {
            return new List<Line>
            {
                new Line { LineName = "Line1", DailyPlan = 100, DailyActual = 90 },
                new Line { LineName = "Line2", DailyPlan = 150, DailyActual = 120 }
            };
        }
    }
}

