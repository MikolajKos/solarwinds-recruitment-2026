namespace swi.Operations
{
    public class AddOperation : Operation
    {
        public AddOperation(SingleOperation sinOp) : base(sinOp)
        {
        }

        public override double Calculate()
        {
            return Value1 + Value2;
        }
    }
}
