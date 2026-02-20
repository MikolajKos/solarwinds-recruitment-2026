namespace swi.Operations
{
    public class SqrtOperation : Operation
    {
        public SqrtOperation(SingleOperation sinOp) : base(sinOp)
        {
        }

        public override double Calculate()
        {
            if (Value1 < 0) throw new ArithmeticException("You can't square root negative numbers");
            return Math.Sqrt(Value1);
        }
    }
}
