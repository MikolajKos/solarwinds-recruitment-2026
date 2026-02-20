namespace swi.Operations
{
    public class MulOperation : Operation
    {
        public MulOperation(SingleOperation sinOp) : base(sinOp)
        {
        }

        public override double Calculate()
        {
            return Value1 * Value2;
        }
    }
}
