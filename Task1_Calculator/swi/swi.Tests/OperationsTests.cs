using swi.Operations;

namespace swi.Tests
{
    public class OperationsTests
    {
        [Theory]
        [InlineData(1, 3, 4)]
        [InlineData(2, -7, -5)]
        [InlineData(1.5, 2.3, 3.8)]
        public void AddOperation_ShouldCalculateCorrectly(double a, double b, double expected)
        {
            var dto = new SingleOperation()
            {
                Value1 = a,
                Value2 = b
            };
            
            var op = new AddOperation(dto);

            var result = op.Calculate();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-2, 3, -6)]
        [InlineData(5, 0, 0)]
        public void MulOperation_ShouldCalculateCorrectly(double v1, double v2, double expected)
        {
            var dto = new SingleOperation { Value1 = v1, Value2 = v2 };
            var op = new MulOperation(dto);

            var result = op.Calculate();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SqrtOperation_ShouldCalculateCorrectly_WhenPositive()
        {
            var dto = new SingleOperation { Value1 = 16 };
            var op = new SqrtOperation(dto);

            Assert.Equal(4, op.Calculate());
        }

        [Fact]
        public void SqrtOperation_ShouldThrowException_WhenNegative()
        {
            var dto = new SingleOperation { Value1 = -4 };
            var op = new SqrtOperation(dto);

            Assert.Throws<ArithmeticException>(() => op.Calculate());
        }
    }
}
