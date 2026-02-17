using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swi.Operations
{
    public class SubOperation : Operation
    {
        public SubOperation(SingleOperation sinOp) : base(sinOp)
        {
        }

        public override double Calculate()
        {
            return Value1 - Value2;
        }
    }
}
