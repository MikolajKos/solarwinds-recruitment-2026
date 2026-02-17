using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using swi.Operations;

namespace swi
{
    public static class OperationFactory
    {
        public static Operation GenerateOperation(SingleOperation sinOp)
        {
            var opType = sinOp.OperationType;

            return opType.ToLower() switch
            {
                "add" => new AddOperation(sinOp),
                "sub" => new SubOperation(sinOp),
                "mul" => new MulOperation(sinOp),
                "sqrt" => new SqrtOperation(sinOp),
                _ => throw new ArgumentException($"Operation not found: {opType}")
            };  
        }
    }
}
