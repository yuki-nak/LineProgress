using LineProgress.Services;

namespace LineProgress.Tests.Services
{
    public class LineViewModelTests
    {
        [Fact]
        public void Constructor_Initializes_Lines_Property()
        {
            // Arrange
            var viewModel = new LineViewModel();

            // Assert
            Assert.NotNull(viewModel.Lines);
            Assert.Empty(viewModel.Lines);
        }
    }
}
