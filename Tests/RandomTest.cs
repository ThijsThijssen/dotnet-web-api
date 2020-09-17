using Xunit;

namespace TodoApi.Tests
{
    public class RandomTest {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(6, Add(4, 2));
        }

        int Add(int x, int y) {
            return x + y;
        }
    }
}