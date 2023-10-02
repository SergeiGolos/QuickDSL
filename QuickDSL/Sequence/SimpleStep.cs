namespace QuickDSL.Sequence
{
    public abstract class SimpleStep
    {
        public abstract IEnumerable<(string, object)> Act(SimpleContext context);
    }
}
