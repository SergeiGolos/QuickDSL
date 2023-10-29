using QuickDSL.Scanning;

namespace Tests.CalculatorSequance
{
    [Verb("sub")]
    public class SubStep : NumberStep
    {
        public override int Act(int current, int value)
        {
            return current - value;
        }
    }
}
