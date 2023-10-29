using QuickDSL.Scanning;

namespace Tests.CalculatorSequance
{
    [Verb("add")]
    public class AddStep : NumberStep
    {
        public override int Act(int current, int value)
        {
            return current + value;
        }
    }
}
