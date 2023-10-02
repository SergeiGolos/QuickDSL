namespace QuickDSL.Sequence
{

    public abstract class SimpleSequence           
    {
        public SimpleStep[] Steps { get; set; }

        public Dictionary<string, object> Execute()
        {
            var context = new SimpleContext();

            foreach (var step in Steps)
            {
                context.AddRange(step.Act(context));
            }
            return context;
        }
    }
}
