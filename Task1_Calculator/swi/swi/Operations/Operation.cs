namespace swi.Operations
{
    public abstract class Operation
    {
        protected double Value1 { get; private set; }
        protected double Value2 { get; private set; }

        public Operation(SingleOperation sinOp) 
        {
            Value1 = sinOp.Value1;
            Value2 = sinOp.Value2 ?? 0;
        }

        public abstract double Calculate();
    }
}
