using QuickDSL.Scanning;

namespace Tests.CalculatorSequance
{
    [Verb("multiply")]
    public class MultiplyStep : NumberStep
    {        
        public override int Act(int current, int value)
        {
            return current * value;
        }
    }
}
