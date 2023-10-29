using QuickDSL.Scanning;
using QuickDSL.Sequence;
using System;
using System.Collections.Generic;

namespace Tests.CalculatorSequance
{
    [Dsl]
    public class AttributeCalculator : ISimpleSequence
    {
        [Anchor]
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
