using QuickDSL.Sequence;
using System;
using System.Collections.Generic;

namespace Tests.CalculatorSequance
{
    public class SimpleCalculator : ISimpleSequence
    {
        public SimpleStep[] Steps { get; set; }

        public Dictionary<string, object> Execute()
        {
            var context = new SimpleContext().Set("value", 0);
            foreach (var step in Steps ?? Array.Empty<SimpleStep>())
            {
                context.AddRange(step.Act(context));
            }
            return context;
        }
    }
}
