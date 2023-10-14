using QuickDSL.Sequence;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tests.CalculatorSequance
{
    public abstract class NumberStep : SimpleStep
    {
        [XmlText]
        public int Value { get; set; }

        public override IEnumerable<(string, object)> Act(SimpleContext context)
        {
            var current = context.Get<int>("value");
            var result = this.Act(current, this.Value);
            yield return ("value", result);
        }

        public abstract int Act(int current, int value);
    }
}
