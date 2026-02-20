using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using swi.Operations;

namespace swi.Tests
{
    public class OperationFactoryTests
    {
        [Theory]
        [InlineData("add", typeof(AddOperation))]
        [InlineData("mul", typeof(MulOperation))]
        [InlineData("sub", typeof(SubOperation))]
        [InlineData("sqrt", typeof(SqrtOperation))]
        public void FactoryShouldGenerate_ObjectOfGivenType(string type, Type expectedType) 
        {
            var dto = new SingleOperation() { OperationType = type };

            var returnType = OperationFactory.GenerateOperation(dto);

            Assert.IsType(expectedType, returnType);
        }

        [Fact]
        public void FactoryShouldThrwException_OnInvalid_OperationType()
        {
            var dto = new SingleOperation() { OperationType = "badType" };
            
            Assert.Throws<ArgumentException>(() => OperationFactory.GenerateOperation(dto));
        }
    }
}
