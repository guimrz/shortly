namespace Shortly.Core.Tests
{
    public partial class GuardTests
    {
        [Fact]
        public void NotNull_ShouldThrowException_WhenNull()
        {
            object? expected = null;

            Assert.Throws<ArgumentNullException>(() => Guard.NotNull(expected));
        }

        [Fact]
        public void NotNull_ShouldReturnValue_WhenNotNull()
        {
            object? expected = new { };

            var actual = Guard.NotNull(expected);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NotDefault_ShouldThrowException_WhenDefault()
        {
            Guid expected = Guid.Empty;

            Assert.Throws<ArgumentException>(() => Guard.NotDefault(expected));
        }

        [Fact]
        public void NotDefault_ShouldReturnValue_WhenNotDefault()
        {
            Guid expected = Guid.NewGuid();

            var actual = Guard.NotDefault(expected);

            Assert.Equal(expected, actual);
        }
    }
}
