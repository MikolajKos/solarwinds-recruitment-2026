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
            Operation op;
            var opType = sinOp.OperationType;
            
            switch (opType.ToLower())
            {
                case "add":
                    op = new AddOperation(sinOp);
                    break;
                case "sub":
                    op = new SubOperation(sinOp);
                    break;
                case "mul":
                    op = new MulOperation(sinOp);
                    break;
                case "sqrt":
                    op = new SqrtOperation(sinOp);
                    break;
                default:
                    throw new Exception($"Operation not found: {opType}");
            }

            return op;
        }
    }
}
